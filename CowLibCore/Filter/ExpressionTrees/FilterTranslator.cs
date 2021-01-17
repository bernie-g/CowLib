// Copyright (c) Gecko. All Rights Reserved. Written by Bernie G.

using System;
using System.Linq.Expressions;
using Newtonsoft.Json.Linq;

namespace CowLibCore.Molang.ExpressionTrees
{
    internal static class FilterTranslator
    {
        public static string TranslateExpressionTree(Expression<Func<bool>> expression)
        {
            if(expression.NodeType != ExpressionType.Lambda) throw new InvalidOperationException("Top level filter expression must be of type Expression.Lambda");
            JArray rootObject = new JArray();
                return "";
        }
    }

    public class Filter
    {
        public Filter(Expression<Func<bool>> molangFunction)
        {
            this.FilterJson = FilterTranslator.TranslateExpressionTree(molangFunction);
        }

        public string FilterJson { get; set; }
    }
}