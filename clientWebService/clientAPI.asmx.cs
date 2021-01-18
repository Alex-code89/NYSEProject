using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using Newtonsoft.Json;

namespace clientWebService
{
    /// <summary>
    /// Summary description for clientAPI
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class clientAPI : System.Web.Services.WebService
    {
        DBAccess db = new DBAccess();
        DataTable dt = new DataTable();

        [WebMethod]
        public string usersDT(string symbol)
        {
            string query = @"Select * From Stocks Where StockSymbol= '" + symbol + "' ";
            db.readDatathroughAdapter(query, dt);
            string result = JsonConvert.SerializeObject(dt);

            return result;

        }
    }
}
