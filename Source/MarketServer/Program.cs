// --------------------------------------------------------------------------
// <copyright file="Program.cs" company="MK inc.">
//      Copyright © MK inc. 2014-2015. All rights reserved.
// </copyright>
// <author>Kozlov M.M.</author>
//---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Market.ServiceCore;

namespace MarketService
{
    /// <summary>
    /// Main Class.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Method starts service.
        /// </summary>
        /// <param name="args">Arguments for additional functionality.</param>
        public static void Main(string[] args)
        {
            try
            {
                Uri uri = new Uri(ConfigurationManager.AppSettings["Addr"]);
                ServiceHost host = new ServiceHost(typeof(ServiceManager), uri);
                host.Open();
                WriteLine(string.Format("Market service listens on endpoint: {0}", uri.ToString()), newLine: true);
                WriteLine("Press ENTER to stop");
                WriteLine(" market ", ConsoleColor.Yellow);
                WriteLine("service...");

                Console.ReadLine();
                host.Abort();
                host.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error:" + e.Message);
                Console.ReadLine();
            }
        }

        static void WriteLine(string line, ConsoleColor foreColor = ConsoleColor.White, bool newLine = false)
        {
            Console.ForegroundColor = foreColor;
            if (newLine)
            {
                Console.WriteLine(line);
                return;
            }
            Console.Write(line);
        }
    }
}