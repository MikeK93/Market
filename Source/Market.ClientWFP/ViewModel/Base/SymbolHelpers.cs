//-----------------------------------------------------------------------
// <copyright file="SymbolHelpers.cs" company="HamsterSoft">
//     Copyright © HamsterSoft 2011. All rights reserved.
// </copyright>
// <author>Reflexor ltd.</author>
//-----------------------------------------------------------------------

using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace Command.ViewModel.Base
{
    public static class SymbolHelpers
    {
        public static string GetPropertyName<T>(Expression<Func<T>> propertyExpression)
        {
            if (propertyExpression == null || propertyExpression.Body == null)
                return "";

            var memberExpression = propertyExpression.Body as MemberExpression;
            var propertyName = memberExpression.Member.Name;
            return propertyName;
        }
    }
}