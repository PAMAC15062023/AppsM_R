using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace RESDOT
{
    public partial class RES_Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            string @userid = txtUserName.Text;
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

                sqlCon.Open();
                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "SP_getRoleid_1";

                SqlParameter LoginName = new SqlParameter();
                LoginName.SqlDbType = SqlDbType.VarChar;
                LoginName.Value = txtUserName.Text.Trim();
                LoginName.ParameterName = "@userid";
                sqlCom.Parameters.Add(LoginName);

                SqlParameter Password = new SqlParameter();
                Password.SqlDbType = SqlDbType.VarChar;
                Password.Value = CEncDec.Encrypt(txtPassword.Text.Trim(), txtPassword.Text.Trim());
                Password.ParameterName = "@password";
                sqlCom.Parameters.Add(Password);

                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = sqlCom;

                DataTable dt = new DataTable();
                sqlDA.Fill(dt);
                sqlCon.Close();

                if (dt.Rows.Count > 0)
                {
                    UserInfo.structUSERInfo SaveUSERInfo = new UserInfo.structUSERInfo();
                    Session["Rolename"] = dt.Rows[0]["Rolename"];
                    Session["Roleid"] = Convert.ToInt32(dt.Rows[0]["DesignID"]);
                    Session["fullName"] = Convert.ToString(dt.Rows[0]["fullName"]);
                    Session["UserId"] = txtUserName.Text;  //add on 15/12/23


                    if (Convert.ToInt32(dt.Rows[0]["DesignID"]) == 3)
                    {
                        Session["ActivityId"] = 0;
                        Session["ActivityName"] = "";
                    }
                    else
                    {
                        //Session["ActivityId"] = ddlActivityList.SelectedValue;
                        //Session["ActivityName"] = ddlActivityList.SelectedItem;
                    }
                    Session["empslno"] = dt.Rows[0]["empslno"];
                    Session["CountryID"] = "11";

                }
                else
                {

                    // lblError.Visible = true;
                    // lblError.Text = "Please enter correct Userid & Password ";
                    return;
                }

            }
            //     SaveUSERInfo.RoleId = Convert.ToInt32(dt.Rows[0]["RoleId"]);
            // lblError.Visible = false;
            int roleid = Convert.ToInt32(Session["Roleid"].ToString());
            if (roleid == 3)
            {
                Response.Redirect("RES_Menu.aspx", false);
            }
            else
            {
                Response.Redirect("RES_Menu.aspx", false);
            }
        }
    }
}