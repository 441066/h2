using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HH_Parser_Request
{
    internal class QueryParam
    {
        public QueryParam() { }
        public QueryParam(string key, string value)
        {
            Key = key;
            Value = value;
        }
        public string Key { get; set; }
        public string Value { get; set; }
    }

    internal class QueryParams : ListViewItem
    {
        public BindingList<QueryParam> Params { get; set; }

        public QueryParams(BindingList<QueryParam> queryParams)
        {
            Params = queryParams;
        }
        public QueryParams()
        {
            Params = new BindingList<QueryParam>()
            {
                AllowNew = true,
                AllowRemove = true,
                AllowEdit = true
            };
            SetText();
        }
        public void PushParam(QueryParam queryParam)
        {
            Params.Add(queryParam);
        }
        public void RemoveParam(QueryParam queryParam)
        {
            Params.Remove(queryParam);
        }

        /// <summary>
        /// Set text property of ListViewItem
        /// </summary>
        public void SetText()
        {
            var keyValuePairList = Params.Select(currentParam => currentParam.Key + "=" + currentParam.Value).ToList();
            Text = Params.Count == 0 ? "Empty string" : string.Join("&", keyValuePairList);
        }
    }
}
