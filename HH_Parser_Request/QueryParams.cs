using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH_Parser_Request
{
    class QueryParam
    {
        public QueryParam(string i_key, string i_value)
        {
            Key = i_key;
            Value = i_value;
        }
        public string Key { get; set; }
        public string Value { get; set; }
    }
    class QueryParams
    {
        List<QueryParam> Params;
        public QueryParams(List<QueryParam> ListOfParams)
        {
            Params = ListOfParams;
        }
        public QueryParams()
        {
            Params = new List<QueryParam>();
        }
        public void PushParam(QueryParam QParamToAdd)
        {
            Params.Add(QParamToAdd);
        }
        public void RemoveParam(QueryParam QParamToPull)
        {
            Params.Remove(QParamToPull);
        }
    }
}
