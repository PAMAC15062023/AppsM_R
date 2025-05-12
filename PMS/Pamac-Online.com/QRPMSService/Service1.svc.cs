using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;

namespace PMSService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        SqlConnection sqlcon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

        public string Login(string UserId, string Password)
        {
            string abc = null;

            try
            {
                sqlcon.Open();

                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlcon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "sp_getuser";
                sqlCom.CommandTimeout = 0;

                SqlParameter UserId1 = new SqlParameter();
                UserId1.SqlDbType = SqlDbType.VarChar;
                UserId1.Value = UserId;
                UserId1.ParameterName = "@UserId";
                sqlCom.Parameters.Add(UserId1);

                SqlParameter Password1 = new SqlParameter();
                Password1.SqlDbType = SqlDbType.VarChar;
                Password1.Value = Password;
                Password1.ParameterName = "@Password";
                sqlCom.Parameters.Add(Password1);

                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = sqlCom;

                DataTable dt = new DataTable();
                sqlDA.Fill(dt);

                if (dt.Rows.Count > 0)
                {


                    abc = dt.Rows[0]["userId"].ToString();



                }
                else
                {
                    abc = "-1";
                }

            }
            catch (Exception ex)
            {
                abc = ex.Message;
            }
            finally
            {
                sqlcon.Close();
            }
            return abc;
        }

        public string GetData(string UserId, string transferid)
        {


            string result = "";

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
                    sqlCom.CommandText = "Get_Asstesinfo_update";
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
                        result = result + arraytransferChange[k] + ",";
                    }
                    else
                    {

                        result = "not updated";
                    
                    }


                }

                catch (Exception ex)
                {
                    result = ex.Message;

                }
                finally
                {
                    sqlcon.Close();
                }
            }
            return result;

        }
    }
}
