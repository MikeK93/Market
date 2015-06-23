// --------------------------------------------------------------------------
// <copyright file="ObjectReaderBase.cs" company="MK inc.">
//      Copyright © MK inc. 2014-2015. All rights reserved.
// </copyright>
// <author>Kozlov M.M.</author>
//---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Windows.Forms;
using Market.Middleware;

namespace Market.Core
{
    /// <summary>
    /// Class represents a basic function for all object readers.
    /// </summary>
    /// <typeparam name="T">Type of Object to read.</typeparam>
    public abstract class ObjectReaderBase<T> : IMarket
        where T : class
    {
        #region Constants

        private const string DATABASE_NAME = "Market_DB";

        #endregion

        #region Fields

        private static string _tableName = typeof(T).Name;

        private static DbDataAdapter _dataAdapter;

        private static Dictionary<string, DataTable> _tables = new Dictionary<string, DataTable>();

        private static string _provider = ConfigurationManager.ConnectionStrings[DATABASE_NAME].ProviderName;

        private static string _connectionString = ConfigurationManager.ConnectionStrings[DATABASE_NAME].ConnectionString;

        private static DbProviderFactory _providerFactory = DbProviderFactories.GetFactory(_provider);

        private static DbConnection _connection = _providerFactory.CreateConnection();

        private static DataTable _currentTable;

        private bool _isAll = false;

        private DbCommand _command;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor for creating new ObjectReader.
        /// </summary>
        static ObjectReaderBase()
        { _connection.ConnectionString = _connectionString; }

        /// <summary>
        /// Constructor for creating new ObjectReader.
        /// </summary>
        /// <param name="tableName">Custom name for table.</param>
        public ObjectReaderBase(string tableName = "")
            : this()
        { TableName = (tableName == string.Empty) ? typeof(T).Name : tableName; }

        /// <summary>
        /// Constructor for creating new ObjectReader.
        /// </summary>
        public ObjectReaderBase()
        {
            DataAdapter = _providerFactory.CreateDataAdapter();
            _command = _providerFactory.CreateCommand();
            DbCommandBuilder cb = _providerFactory.CreateCommandBuilder();
            cb.ConflictOption = ConflictOption.OverwriteChanges;
            cb.DataAdapter = DataAdapter;
            _command.Connection = (DbConnection)Connection;
            _command.CommandText = "SELECT * FROM [" + TableName + "]";
            _currentTable = new DataTable();
            _currentTable.TableName = TableName;
            DataAdapter.SelectCommand = _command;
            DataAdapter.InsertCommand = cb.GetInsertCommand();
            DataAdapter.UpdateCommand = cb.GetUpdateCommand();
            DataAdapter.DeleteCommand = cb.GetDeleteCommand();
            Fill("1=2");
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets list of objects from cache.
        /// </summary>
        public List<T> GetAllItems
        {
            get
            {
                var res = new List<T>();

                if (_isAll)
                    res = GetByQuery();
                else
                {
                    Table.Clear();
                    ExecuteQuery();
                    _isAll = true;
                    res = GetByQuery();
                }

                return res;
            }
        }

        /// <summary>
        /// Gets or sets a table name.
        /// </summary>
        protected static string TableName
        {
            get { return _tableName; }
            set { _tableName = value; }
        }

        /// <summary>
        /// Gets a table which represents a database table.
        /// </summary>
        protected static DataTable Table
        {
            get { return _currentTable; }
        }

        /// <summary>
        /// Gets or sets a tables.
        /// </summary>
        protected static Dictionary<string, DataTable> Tables
        {
            get { return ObjectReaderBase<T>._tables; }
            set { ObjectReaderBase<T>._tables = value; }
        }

        /// <summary>
        /// Gets or sets a dataAdapter for a table.
        /// </summary>
        protected static DbDataAdapter DataAdapter
        {
            get { return ObjectReaderBase<T>._dataAdapter; }
            set { ObjectReaderBase<T>._dataAdapter = value; }
        }

        private static IDbConnection Connection
        {
            get
            {
                if (_connection.State == ConnectionState.Broken) _connection.Close();
                if (_connection.State == ConnectionState.Closed) _connection.Open();

                return _connection;
            }
        }

        #endregion

        #region Implementation of Contract

        /// <summary>
        /// Gets data from a table by the type of an entity.
        /// </summary>
        /// <param name="dataType">Type of items to get.</param>
        /// <param name="mType">Type of a method to be executed.</param>
        /// <param name="query">Query for getting data from table, if mType = GetByQuery.</param>
        /// <param name="id">Id of an item to look up, if mType = GetById.</param>
        /// <returns>List of objects of type T</returns>
        public List<PackedObject> GetData(string dataType, MethodType mType, string query, Guid id)
        {
            try
            {
                MapperBase<T> mapper = GetMapper();
                switch (mType)
                {
                    case MethodType.GetById:
                        return mapper.Pack(GetById(id));
                    case MethodType.GetByQuery:
                        return mapper.Pack(GetByQuery(query));
                    case MethodType.GetAllItems:
                        return mapper.Pack(GetAllItems);
                }
                return null;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error in type: " + GetType() + Environment.NewLine + "Error msg:" + e.Message);
                return null;
            }
        }

        /// <summary>
        /// Updates a data in table by an entity.
        /// </summary>
        /// <param name="packedObject">Object to update.</param>
        /// <param name="uType">Update type.</param>
        public void UpdateOne(PackedObject packedObject, UpdateType uType)
        {
            MapperBase<T> mapper = GetMapper();
            try
            {
                switch (uType)
                {
                    case UpdateType.Save:
                        T itemToSave = mapper.UnPack(packedObject);
                        Save(new List<T>() { itemToSave });
                        break;
                    case UpdateType.Delete:
                        T itemToDelete = mapper.UnPack(packedObject);
                        Delete(itemToDelete);
                        break;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error in type: " + GetType() + Environment.NewLine + "Error msg:" + e.Message);
            }
        }

        /// <summary>
        /// Updates a data in table by a list of entities.
        /// </summary>
        /// <param name="packedObjects">Objects to update.</param>
        /// <param name="uType">Update type.</param>
        /// <returns>Number of updated items.</returns>
        public int UpdateList(List<PackedObject> packedObjects, UpdateType uType)
        {
            var mapper = GetMapper();
            try
            {
                switch (uType)
                {
                    case UpdateType.Save:
                        Save(mapper.UnPack(packedObjects));
                        break;
                    case UpdateType.Delete:
                        Delete(mapper.UnPack(packedObjects));
                        break;
                }

                return packedObjects.Count;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error in type: " + GetType() + Environment.NewLine + "Error msg:" + e.Message);
                return 0;
            }
        }
        #endregion

        #region Methods

        /// <summary>
        /// Method saves object with of type <see cref="T"/>
        /// </summary>
        /// <param name="item">Object of type <see cref=">T"/>.</param>
        /// <param name="isNew">Value indicates whether the objetc is new.</param>
        public abstract void Save(T item, bool isNew);

        /// <summary>
        /// Method saves list of objects of type <see cref=">T"/>.
        /// </summary>
        /// <param name="items">List of objects of type <see cref=">T"/>.</param>
        public abstract void Save(List<T> items);

        /// <summary>
        /// Method deletes object of type <see cref=">T"/>.
        /// </summary>
        /// <param name="item">Object of type <see cref=">T"/>.</param>
        public abstract void Delete(T item);

        /// <summary>
        /// Method deletes list of objetcts of type <see cref=">T"/>.
        /// </summary>
        /// <param name="items">List of objects of type<see cref="T"/>.</param>
        public abstract void Delete(List<T> items);

        /// <summary>
        /// Get object by its id.
        /// </summary>
        /// <param name="id">Id of an object.</param>
        /// <param name="tableName">Table to look object up. By default "" means The name of an entity.</param>
        /// <returns>Objects by its id.</returns>
        public List<T> GetById(Guid id, string tableName = "")
        { return GetByQuery(" ID = '" + id + "'", tableName == string.Empty ? TableName : tableName); }

        /// <summary>
        /// Gets list of objects selected with query.
        /// </summary>
        /// <param name="query">Query by which to find objects.</param>
        /// <param name="tableName">Table to look objects up. By default "" means The name of an entity.</param>
        /// <returns>List of objects.</returns>
        public List<T> GetByQuery(string query = "", string tableName = "", bool fullQuery = false)
        {
            _command.CommandText =
                string.Format("SELECT * FROM [{0}] {1}", tableName == string.Empty ? TableName : tableName, query);
            MapperBase<T> mapper = GetMapper();
            //if (query.IndexOf("OR") != -1)
            //    Table.Clear();
            while (true)
            {
                try
                {
                    var rows = Table.Select(query);
                    if (rows.Length != 0)
                    {
                        string modifiedQuery = IsAllAdded(rows, query);
                        if (modifiedQuery != string.Empty)
                        {
                            ExecuteQuery(modifiedQuery, fullQuery);
                            rows = Table.Select(query);
                        }

                        return mapper.MapAll(rows);
                    }
                    else
                    {
                        int addedItems = ExecuteQuery(query, fullQuery);
                        if (addedItems == 0)
                            return new List<T>();
                    }
                }
                catch (Exception e) { throw e; }
            }
        }

        /// <summary>
        /// Gets row from table by object's ID.
        /// </summary>
        /// <param name="item">Item to get form table.</param>
        /// <returns>DataRow object.</returns>
        public abstract DataRow GetDataRow(T item, bool isNew);

        /// <summary>
        /// Method gets the list of items from real database and adds them to cache table.
        /// </summary>
        /// <param name="query">The command text without 'SELECT [PARAM].* FROM [TABLE_NAME]'.</param>
        /// <param name="fullQuery">Indicates whether it's a complete request or no.
        ///                         If so, you have to be sure of a query being legibly work.</param>
        /// <returns>List of objects.</returns>
        protected int ExecuteQuery(string query = "", bool fullQuery = false)
        {
            IDbCommand command = Connection.CreateCommand();
            command.Connection = Connection;
            int count = 0;

            if (!fullQuery)
            {
                if (query != string.Empty)
                {
                    query = TransformQuery(query, command);
                    command.CommandText = string.Format("SELECT * FROM [{0}] {1}", TableName, query != string.Empty ? "WHERE " + query : string.Empty);
                }
                else
                    command.CommandText = string.Format("SELECT * FROM [{0}]", TableName, query);
            }
            else
                command.CommandText = string.Format("SELECT * FROM [{0}] WHERE {1}", TableName, query);

            using (IDataReader reader = command.ExecuteReader())
            {
                try
                {
                    MapperBase<T> mapper = GetMapper();
                    while (reader.Read())
                    {
                        DataRow row = Table.NewRow();
                        row = mapper.GenerateRow(reader, row); // set RowState to Detached.
                        Table.Rows.Add(row);                   // set RowState to Added.
                        Table.AcceptChanges();                 // set RowState to UnChanged.
                        row.SetModified();                     // set RowState to Modified.
                        count++;
                    }

                    return count;
                }
                catch { return count; }
                finally { reader.Close(); }
            }
        }

        /// <summary>
        /// Methods gets a mapper for type <see cref="T"/>.
        /// </summary>
        /// <returns>Mapper for concrete type.</returns>
        protected abstract MapperBase<T> GetMapper();

        /// <summary>
        /// Method updates a real database.
        /// </summary>
        /// <param name="row">Row to apdate.</param>
        /// <param name="isNew">Indicates whether the row is new.</param>
        protected void Update(DataRow row, bool isNew)
        {
            if (isNew)
                Table.Rows.Add(row);
            DataAdapter.Update(new DataRow[] { row });
        }

        /// <summary>
        /// Method transform regular query to parametrized.
        /// </summary>
        /// <param name="query">Query to transform.</param>
        /// <param name="command">Command in which the query is used.</param>
        /// <returns>Parametrized query.</returns>
        private static string TransformQuery(string query, IDbCommand command)
        {
            if (query.IndexOf("IS NOT NULL") != -1)
                return query;

            string[] paramNames;
            bool IsANDOrOR = (query.IndexOf("OR") != -1) || (query.IndexOf("AND") != -1);

            if (!IsANDOrOR)
            {

                paramNames = query.Replace("'", string.Empty).Replace(" ", string.Empty).Split('=');
                query = string.Empty;
                DbParameter p = new SqlParameter("@" + paramNames[0].Trim(), paramNames[1].Trim());
                command.Parameters.Add(p);
                query += p.ParameterName.Replace("@", string.Empty) + "=" + p.ParameterName;
            }
            else
            {
                if (query.IndexOf("OR") == -1)
                {
                    paramNames = query.Replace("'", string.Empty).Replace("AND", "&").Split('&');
                    query = string.Empty;
                    for (int i = 0; i < paramNames.Length; i++)
                    {
                        string[] pNameAndValue = paramNames[i].Split('=');
                        DbParameter p = new SqlParameter("@" + pNameAndValue[0].Trim(), pNameAndValue[1].Trim());
                        command.Parameters.Add(p);
                        query += p.ParameterName.Replace("@", string.Empty) + "=" + p.ParameterName + ((i % 2 == 0 && paramNames.Length > 1) ? " AND " : string.Empty);
                    }
                }
                else
                {
                    paramNames = query.Replace("'", string.Empty).Replace("OR", "&").Split('&');
                    query = string.Empty;
                    for (int i = 0; i < paramNames.Length; i++)
                    {
                        string[] pNameAndValue = paramNames[i].Split('=');
                        DbParameter p = new SqlParameter("@value_" + i, pNameAndValue[1].Trim());
                        command.Parameters.Add(p);
                        if (i == 0)
                            query += pNameAndValue[0].Trim() + " IN (" + p.ParameterName + ", ";
                        else
                            query += p.ParameterName + (i != paramNames.Length - 1 ? ", " : ")");
                    }
                }
            }

            return query;
        }

        /// <summary>
        /// Method checked if all data was downloaded form database to cache table.
        /// </summary>
        /// <param name="addedRows">Array of rows that were downloaded to cache table.</param>
        /// <param name="query">Query by which to look up data.</param>
        /// <returns>If not all data was downloaded returns modified query with ids to add, otherwise empty string.</returns>
        private string IsAllAdded(DataRow[] addedRows, string query)
        {
            var res = string.Empty;
            DataTable table = null;
            IDbCommand command = Connection.CreateCommand();
            command.Connection = Connection;

            if (query != string.Empty)
            {
                query = TransformQuery(query, command);
                command.CommandText = string.Format("SELECT ID FROM [{0}] {1}", TableName, query != string.Empty ? "WHERE " + query : string.Empty);
            }
            else
                command.CommandText = string.Format("SELECT ID FROM [{0}]", TableName, query);

            using (IDataReader reader = command.ExecuteReader())
            {
                try
                {
                    MapperBase<T> mapper = GetMapper();
                    table = new DataTable();
                    table.Columns.Add("ID");
                    while (reader.Read())
                    {
                        DataRow row = table.NewRow();
                        row["ID"] = reader["ID"];              // set RowState to Detached.
                        table.Rows.Add(row);                   // set RowState to Added.
                        table.AcceptChanges();                 // set RowState to UnChanged.
                        row.SetModified();                     // set RowState to Modified.
                    }

                    var ids = string.Empty;
                    DataRowCollection drCollection = addedRows.CopyToDataTable().Rows;
                    //if (addedRows.Length >= table.Rows.Count)
                    //    ids = FindDistincts(drCollection, table.Rows);
                    //else
                    ids = FindDistincts(table.Rows, drCollection);

                    return ids;
                }
                catch (Exception ex) { return string.Empty; }
                finally { reader.Close(); }
            }
        }

        private string FindDistincts(DataRowCollection primary, DataRowCollection secondary)
        {
            var res = string.Empty;
            bool toAdd = false;
            for (int i = 0; i < primary.Count; i++)
            {
                for (int j = 0; j < secondary.Count; j++)
                {
                    if (primary[i]["ID"].ToString() != secondary[j]["ID"].ToString())
                        toAdd = true;
                    else
                    {
                        toAdd = false;
                        j = secondary.Count - 1;
                    }

                    if (j == secondary.Count - 1 && toAdd)
                        res += " ID = '" + primary[i]["ID"].ToString() + "' OR";
                }
            }

            if (res.Length != 0)
                res = res.Remove(res.Length - 3);

            return res;
        }

        /// <summary>
        /// Puts data from database to cache table. And retrieve requested data.
        /// </summary>
        /// <param name="query">Query to procced.</param>
        /// <param name="tableName">Table to look objects up. By default "" means The name of an entity.</param>
        private void Fill(string query = "", string tableName = "")
        {
            _command.CommandText =
                string.Format("SELECT * FROM [{0}] {1}", tableName == string.Empty ? TableName : tableName, query == string.Empty ? string.Empty : " WHERE " + query);

            try
            {
                _currentTable = Tables[TableName];
            }
            catch
            {
                DataAdapter.Fill(_currentTable);
                Tables.Add(TableName, _currentTable);
            }
        }

        private List<T> MapObjects()
        {
            MapperBase<T> mapper = GetMapper();
            IDataReader reader = Table.CreateDataReader();
            return mapper.MapAll(reader);
        }

        #endregion
    }
}