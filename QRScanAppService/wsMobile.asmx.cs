using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;

namespace QRScanAppService
{
    /// <summary>
    /// Summary description for wsMobile
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class wsMobile : System.Web.Services.WebService
    {
        public class Response
        {
            public string Data
            {
                get;
                set;
            }
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void Login(string UserId, string Password, string Region)
        {
            Response response = new Response();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings[Region]);
            try
            {
                sqlcon.Open();

                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlcon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "uspValidateQRLogin";
                sqlCom.CommandTimeout = 0;

                SqlParameter UserId1 = new SqlParameter();
                UserId1.SqlDbType = SqlDbType.VarChar;
                UserId1.Value = UserId;
                UserId1.ParameterName = "@UserId";
                sqlCom.Parameters.Add(UserId1);

                SqlParameter Password1 = new SqlParameter();
                Password1.SqlDbType = SqlDbType.VarChar;
                Password1.Value = CEncDec.Encrypt(Password, Password);
                Password1.ParameterName = "@Password";
                sqlCom.Parameters.Add(Password1);

                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = sqlCom;

                DataTable dt = new DataTable();
                sqlDA.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    response.Data = dt.Rows[0]["userId"].ToString();
                }
                else
                {
                    response.Data = "-1";
                }
            }
            catch (Exception ex)
            {
                response.Data = ex.Message;
            }
            finally
            {
                sqlcon.Close();
            }
            Context.Response.Write(js.Serialize(response));
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void UpdateScannedDetails(string UserId, string transferid, string Region)
        {
            Response response = new Response();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings[Region]);
            string transferChange = transferid.Replace("#bs", "\\");
            string[] arraytransferChange = transferChange.Split(',');
            int arraylenght = arraytransferChange.Length;
            for (int k = 0; k < arraylenght; k++)
            {
                try
                {
                    sqlcon.Open();

                    SqlCommand sqlCom = new SqlCommand();
                    sqlCom.Connection = sqlcon;
                    sqlCom.CommandType = CommandType.StoredProcedure;
                    sqlCom.CommandText = "uspUpdateScannedQRData";
                    sqlCom.CommandTimeout = 0;

                    SqlParameter transfer = new SqlParameter();
                    transfer.SqlDbType = SqlDbType.VarChar;
                    transfer.Value = arraytransferChange[k];
                    transfer.ParameterName = "@transrefno";
                    sqlCom.Parameters.Add(transfer);

                    SqlParameter FromDate = new SqlParameter();
                    FromDate.SqlDbType = SqlDbType.VarChar;
                    FromDate.Value = UserId;
                    FromDate.ParameterName = "@ScanuserId";
                    sqlCom.Parameters.Add(FromDate);

                    int i = 0;
                    i = sqlCom.ExecuteNonQuery();

                    if (i > 0)
                    {
                        response.Data = response.Data + arraytransferChange[k] + ",";
                    }
                    else
                    {
                        response.Data = "not updated";
                    }
                }
                catch (Exception ex)
                {
                    response.Data = ex.Message;

                }
                finally
                {
                    sqlcon.Close();
                }
            }
            Context.Response.Write(js.Serialize(response));
        }
    }
}
