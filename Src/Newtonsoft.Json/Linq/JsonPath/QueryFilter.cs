using System;
using System.Collections.Generic;

namespace Yodiwo.Json.Linq.JsonPath
{
    internal class QueryFilter : PathFilter
    {
        public QueryExpression Expression { get; set; }

        public override IEnumerable<JToken> ExecuteFilter(JToken root, IEnumerable<JToken> current, bool errorWhenNoMatch)
        {
            foreach (JToken t in current)
            {
                foreach (JToken v in t)
                {
                    if (Expression.IsMatch(root, v))
                    {
                        yield return v;
                    }
                }
            }
        }
    }
}