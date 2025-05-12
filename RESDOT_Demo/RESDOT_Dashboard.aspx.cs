using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RESDOT
{
    public partial class RESDOT_Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bindcasecount();
            }


        }

         
            protected void Bindcasecount()
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
                if (sqlCon.State == ConnectionState.Closed)
                {
                    sqlCon.Open();
                }
                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "SP_getcasecount";
                sqlCom.CommandTimeout = 0;

                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = sqlCom;

                int SqlRow = 0;
                SqlRow = sqlCom.ExecuteNonQuery();

                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                  
                    //lblMessage.ext = " I am here";

                    grv1.DataSource = dt;
                    grv1.DataBind();
                    //if (menuid < 24)
                    //{
                    //    //  grv1.Columns[0].Visible = false;
                    //    grv1.Columns[1].Visible = false;
                    //}
                }
                else
                {
                    grv1.DataSource = null;
                    grv1.DataBind();
                }
                //     }

                //
                //        if (ds != null && ds.Tables.Count > 0)
                //            {
                //                ddlActivityList.DataTextField = "activity_name";
                //                ddlActivityList.DataValueField = "activity_id";
                //                ddlActivityList.DataSource = ds.Tables[0];
                //                ddlActivityList.DataBind();

                //                ddlActivityList.Items.Insert(0, "--Select--");
                //                ddlActivityList.SelectedIndex = 0;
                //            }
            }
            catch (Exception ex)
            {

            }
        }


        protected void lnkWIP_Click(object sender, EventArgs e)
        {
            //lblMsgXls.Text = "";
            string selval = null;
            {
                for (int i = 0; i <= grv1.Rows.Count - 1; i++)
                {
                       CheckBox chkSelect = (CheckBox)grv1.Rows[i].FindControl("chkSelect");

                    LinkButton WIP = (LinkButton)grv1.Rows[i].FindControl("lnkWIP");
                    
                    string grdate = grv1.Rows[i].Cells[1].Text.Trim();
                    // txtAPSID.Text = gvData.Rows[i].Cells[2].Text.Trim();

                    ViewState["grdate"] = grv1.Rows[i].Cells[1].Text.Trim();

                    //ViewState["APS_ID_7_Digits"] = gvData.Rows[i].Cells[3].Text.Trim();

                    //if (ViewState["APS_ID"] != " " && chkSelect.Checked == true)
                    //{
                    //    panel1.Visible = true;


                    //}

                    if (chkSelect.Checked == true)
                    {
                        //PlaceholderControls.Controls.Clear();
                        string headerRowText = grv1.HeaderRow.Cells[1].Text;
                        selval = grv1.Rows[i].Cells[2].Text.Trim();
                        //numboxchecked = 1;

                        ////lblMessage.Text = selval;
                        //field_show_in = 3;

                        //topfields_3(field_show_in, headerRowText, selval);
                        break;
                    }

                }
                string dated = selval; //  "2019-07-31"; // Request.QueryString["dated"];

                DateTime Crdate = DateTime.Parse(dated);

                Panel1.Visible = true;

                Bindcasestatus(Crdate);


                //  Response.Redirect("RESDOT_Dailycount.aspx?dated=" + dateid, false);
            }
        }
        protected void Bindcasestatus(DateTime crdate)
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
                if (sqlCon.State == ConnectionState.Closed)
                {
                    sqlCon.Open();
                }
                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "SP_getcasestatuswise";
                sqlCom.CommandTimeout = 0;

                SqlParameter crdated = new SqlParameter();
                crdated.SqlDbType = SqlDbType.Date;
                crdated.Value = crdate;
                crdated.ParameterName = "@crdate";
                sqlCom.Parameters.Add(crdated);


                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = sqlCom;

                int SqlRow = 0;
                SqlRow = sqlCom.ExecuteNonQuery();

                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count > 0)
                {

                    //lblMessage.ext = " I am here";

                    grv2.DataSource = dt;
                    grv2.DataBind();
                    //if (menuid < 24)
                    //{
                    //    //  grv1.Columns[0].Visible = false;
                    //    grv1.Columns[1].Visible = false;
                    //}
                }
                else
                {
                    grv2.DataSource = null;
                    grv2.DataBind();
                }
                //     }

                //
                //        if (ds != null && ds.Tables.Count > 0)
                //            {
                //                ddlActivityList.DataTextField = "activity_name";
                //                ddlActivityList.DataValueField = "activity_id";
                //                ddlActivityList.DataSource = ds.Tables[0];
                //                ddlActivityList.DataBind();

                //                ddlActivityList.Items.Insert(0, "--Select--");
                //                ddlActivityList.SelectedIndex = 0;
                //            }
            }
            catch (Exception ex)
            {

            }
        }
        //    protected void lkbtnforgotPassword_Click(object sender, EventArgs e)
        //    {
        //        lblError.Visible = true;
        //        lblError.Text = "Please contact your admin";
        //    }

        //    protected void btnLogin_Click(object sender, EventArgs e)
        //    {

        //        string @userid = txtUserName.Text;
        //        {
        //            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

        //            sqlCon.Open();
        //            SqlCommand sqlCom = new SqlCommand();
        //            sqlCom.Connection = sqlCon;
        //            sqlCom.CommandType = CommandType.StoredProcedure;
        //            sqlCom.CommandText = "SP_getRoleid";

        //            SqlParameter LoginName = new SqlParameter();
        //            LoginName.SqlDbType = SqlDbType.VarChar;
        //            LoginName.Value = txtUserName.Text.Trim();
        //            LoginName.ParameterName = "@userid";
        //            sqlCom.Parameters.Add(LoginName);
        //            SqlDataAdapter sqlDA = new SqlDataAdapter();
        //            sqlDA.SelectCommand = sqlCom;

        //            DataTable dt = new DataTable();
        //            sqlDA.Fill(dt);
        //            sqlCon.Close();


        //            UserInfo.structUSERInfo SaveUSERInfo = new UserInfo.structUSERInfo();
        //            Session["Rolename"] = dt.Rows[0]["Rolename"];
        //            Session["Roleid"] = Convert.ToInt32(dt.Rows[0]["DesignationID"]);
        //            Session["UserName"] = Convert.ToString(dt.Rows[0]["UserName"]);
        //            Session["ActivityName"] = ddlActivityList.SelectedItem;
        //            Session["ActivityId"] = ddlActivityList.SelectedValue;

        //        }
        //   //     SaveUSERInfo.RoleId = Convert.ToInt32(dt.Rows[0]["RoleId"]);
        //        lblError.Visible = false;
        //        Response.Redirect("RESDOT_MenuPage.aspx", false);
        //    }
        // }
    }
}
