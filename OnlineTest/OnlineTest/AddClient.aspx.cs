using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineTest
{
    public partial class AddClient : System.Web.UI.Page
    {
        private string hdnID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClientGrid();
            }
        }
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            lblMsgXls.Text = "";
            SaveandUpdateClienttDetils();

        }
        protected void ClearData()
        {
            TxtClientName.Text = "";
            chbIsactive.Checked = false;
        }
        protected void ClientGrid()
        {
            // Object SaveUSERInfo = (Object)Session["UserInfo"];
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Qn_ClientMaster_Grid";
            sqlCom.CommandTimeout = 0;

            sqlCon.Open();

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            DataTable dt = new DataTable();
            sqlDA.Fill(dt);

            sqlCon.Close();


            if (dt.Rows.Count > 0)
            {
                GrdClient.DataSource = dt;
                GrdClient.DataBind();
            }
            else
            {
                GrdClient.DataSource = null;
                GrdClient.DataBind();
            }
        }
        protected void SaveandUpdateClienttDetils()
        {

            string msg = string.Empty;
            Object SaveUSERInfo = (Object)Session["UserInfo"];
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);



            if (TxtClientName.Text == "")
            {
                msg = msg + "please enter the Product Name ";
            }



            if (msg != "")
            {

                ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "alert('" + msg + "');", true);
                return;
            }

            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                {

                    lblMsgXls.Text = "";
                    SqlCommand sqlCom = new SqlCommand();
                    sqlCom.Connection = sqlCon;
                    sqlCom.CommandType = CommandType.StoredProcedure;
                    //sqlCom.CommandText = "savequestion";
                    sqlCom.CommandText = "Qn_Client_Master_SP";
                    sqlCom.CommandTimeout = 0;

                    SqlDataAdapter sda = new SqlDataAdapter();
                    sda.SelectCommand = sqlCom;

                    SqlParameter Client = new SqlParameter();
                    Client.SqlDbType = SqlDbType.VarChar;
                    Client.Value = TxtClientName.Text.ToString();
                    Client.ParameterName = "@ClientName";
                    sqlCom.Parameters.Add(Client);


                    SqlParameter Isactive = new SqlParameter();
                    Isactive.SqlDbType = SqlDbType.Bit;
                    Isactive.Value = chbIsactive.Checked;
                    Isactive.ParameterName = "@Isactive";
                    sqlCom.Parameters.Add(Isactive);

                    SqlParameter AddedBy = new SqlParameter();
                    AddedBy.SqlDbType = SqlDbType.VarChar;
                    AddedBy.Value = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
                    AddedBy.ParameterName = "@CreatedBy";
                    sqlCom.Parameters.Add(AddedBy);


                    sqlCon.Open();
                    int SqlRow = 0;
                    SqlRow = sqlCom.ExecuteNonQuery();



                    if (SqlRow > 0)
                    {
                        lblMsgXls.Text = "Client Added Suessfully!!";
                        ClearData();
                        ClientGrid();
                    }
                    else
                    {
                    }
                }
            }
            catch (SqlException sqlex)
            {
                lblMsgXls.Text = sqlex.Message.ToString();
            }
            catch (SystemException ex)
            {
                lblMsgXls.Text = ex.Message.ToString();
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                }
            }
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            SaveandUpdateClienttDetils();
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserMenuPage.aspx", false);
        }
        protected void btn_Edit_Click1(object sender, EventArgs e)
        {
            lblMsgXls.Text = "";
            Button btn = (Button)sender;
            GridViewRow gr = (GridViewRow)btn.NamingContainer;
            hdnID = GrdClient.DataKeys[gr.RowIndex]["ClientID"].ToString();

            Label lblClientName = (Label)gr.FindControl("lblClientName");
            TxtClientName.Text = lblClientName.Text.Trim();


            Label lblisactive = (Label)gr.FindControl("lblisactive");
            String Data = lblisactive.Text.Trim();

            if (Data == "True")
            {
                chbIsactive.Checked = true;

            }
            else
            {

                chbIsactive.Checked = false;
            }
        }
    }
}