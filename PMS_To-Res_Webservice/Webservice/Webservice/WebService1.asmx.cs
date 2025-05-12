using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services;
using Newtonsoft.Json;

namespace Webservice
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        public class Message
        {
            public string status { get; set; }
            public string errorMessage { get; set; }
        }

        [WebMethod]
        public void AcceptPush()
        {
            Message msg = new Message();
            try
            {
                string[] mesg = new string[2];
                mesg[0] = "FAILED";
                mesg[1] = "Content-Type not applicable for this API !!";
                string message = "";

                string contentType = HttpContext.Current.Request.ContentType;

                if (false == contentType.StartsWith("application/json", StringComparison.OrdinalIgnoreCase))
                {
                    msg.status = mesg[0];
                    msg.errorMessage = mesg[1]; // provide error if FAILED                  
                }
                else
                {
                    using (System.IO.Stream stream = HttpContext.Current.Request.InputStream)
                    using (System.IO.StreamReader reader = new System.IO.StreamReader(stream))
                    {
                        stream.Seek(0, System.IO.SeekOrigin.Begin);

                        string bodyText = reader.ReadToEnd(); bodyText = bodyText == "" ? "{}" : bodyText;

                        var json = Newtonsoft.Json.Linq.JObject.Parse(bodyText);
                        var temp = json.ToString(Newtonsoft.Json.Formatting.None);

                        mesg = SaveData(temp);
                        msg.status = mesg[0];
                        msg.errorMessage = mesg[1];
                    }
                }
                message = JsonConvert.SerializeObject(msg);
                Context.Response.Clear();
                Context.Response.ContentType = "application/json";
                Context.Response.AddHeader("content-length", message.Length.ToString());
                Context.Response.Flush();
                Context.Response.Write(message);
                HttpContext.Current.ApplicationInstance.CompleteRequest();



                //HttpContext.Current.Response.Write(message);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        public string[] SaveData(string myjson)
        {
            string[] mesg = new string[2];
            mesg[0] = "SUCCESS";
            mesg[1] = "false";

            try
            {
                SqlConnection sqlConW = new SqlConnection(ConfigurationManager.ConnectionStrings["WestConnectionString"].ConnectionString);

                int result = 0;

                string splittedString = "[" + myjson.Split('[')[1].Split(']')[0] + "]";
                DataTable dt = (DataTable)JsonConvert.DeserializeObject(splittedString, (typeof(DataTable)));

                dt = OrderingdtColumns(dt);
                sqlConW.Open();
                SqlCommand cmd9 = new SqlCommand("[dbo].[PMS_APPLICATION_Res_RV_BV_APIValidation]", sqlConW);
                cmd9.CommandType = CommandType.StoredProcedure;
                cmd9.Parameters.AddWithValue("@ApplicationType_RV_BV", dt);

                DataTable resultdt = new DataTable();
                SqlDataAdapter sdA = new SqlDataAdapter(cmd9);
                sdA.Fill(resultdt);


                if (resultdt != null && resultdt.Rows.Count > 0)
                {
                    mesg[0] = resultdt.Rows[0][0].ToString();
                    mesg[1] = resultdt.Rows[0][1].ToString();
                    return mesg;
                }

                List<string> SQLconn = new List<string>();
                SQLconn.Add("WestConnectionString");
                SQLconn.Add("EastConnectionString");
                SQLconn.Add("SouthConnectionString");
                SQLconn.Add("NorthConnectionString");
                SQLconn.Add("MumbaiConnectionString");

                foreach (var actualconn in SQLconn)
                {

                    SqlCommand cmd4 = new SqlCommand("PMS_APPLICATION_Res_RV_BV");
                    SqlConnection sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings[actualconn].ConnectionString);
                    cmd4.Connection = sqlconnection;
                    cmd4.CommandType = CommandType.StoredProcedure;
                    cmd4.Parameters.AddWithValue("@ApplicationType_RV_BV", dt);
                    sqlconnection.Open();
                    result = cmd4.ExecuteNonQuery();
                    sqlconnection.Close();
                }




                // bvrv  table another table insert and delete records from bvrv table

                if (result > 0)
                {
                    foreach (var actualconn in SQLconn)
                    {

                        SqlCommand cmd11 = new SqlCommand("USP_InsertdatainCKYC"); // _01Oct2021
                        SqlConnection sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings[actualconn].ConnectionString);
                        cmd11.Connection = sqlconnection;
                        cmd11.CommandType = CommandType.StoredProcedure;
                        sqlconnection.Open();
                        cmd11.ExecuteNonQuery();
                        sqlconnection.Close();
                    }

                }


            }
            catch (Exception ex)
            {
                ErrorLogging(ex, myjson);
                mesg[0] = "FAILED";
                mesg[1] = "Something went wrong, Kindly contact Administrator !!";
            }

            return mesg;
        }

        public static void ErrorLogging(Exception ex, string json)
        {
            string strPath = HttpContext.Current.Server.MapPath("~/Log.txt");
            if (!File.Exists(strPath))
            {
                File.Create(strPath).Dispose();
            }
            using (StreamWriter sw = File.AppendText(strPath))
            {
                sw.WriteLine("=============Error Logging ===========");
                sw.WriteLine("===========Start============= " + DateTime.Now);
                sw.WriteLine("Error Message: " + ex.Message);
                sw.WriteLine("Stack Trace: " + ex.StackTrace);
                sw.WriteLine("My JSON: " + json);
                sw.WriteLine("===========End============= " + DateTime.Now);

            }
        }

        private DataTable OrderingdtColumns(DataTable dataTable) // rv 94
        {


            SqlConnection sqlConW = new SqlConnection(ConfigurationManager.ConnectionStrings["WestConnectionString"].ConnectionString);


            SqlCommand cmd4 = new SqlCommand("Get_Json_RV_BV_Columns", sqlConW);
            cmd4.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adp = new SqlDataAdapter(cmd4);
            DataTable dtcolumns = new DataTable();
            adp.Fill(dtcolumns);
            if (dtcolumns != null && dtcolumns.Rows.Count > 0) // 100
            {

                int i = 0;
                foreach (DataRow row in dtcolumns.Rows)
                {
                    // if column not exists add it and set its order no.
                    if (!dataTable.Columns.Contains(Convert.ToString(row["Column_Name"])))
                    {
                        dataTable.Columns.Add(Convert.ToString(row["Column_Name"]));
                        dataTable.AcceptChanges();
                    }
                    dataTable.Columns[Convert.ToString(row["Column_Name"])].SetOrdinal(i);
                    i++;
                }
                dataTable.AcceptChanges();
            }
            return dataTable;
        }


    }

}

