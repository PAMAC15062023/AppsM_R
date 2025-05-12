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
    public partial class Designation_Master : System.Web.UI.Page
    {
        private string hdnID;

        public DataTable DataTable { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //   Mainpanel.Visible = false;
                AnsGrid();
            }



        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            lblMsgXls.Text = "";
            SaveandUpdateDetils();

        }
        protected void ClearData()
        {
            TxtDsigName.Text = "";
            TxtDsigCode.Text = "";
            chbIsactive.Checked = false;
        }
        protected void AnsGrid()
        {
            // Object SaveUSERInfo = (Object)Session["UserInfo"];
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Qn_designationMaster_Grid";
            sqlCom.CommandTimeout = 0;

            sqlCon.Open();

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            DataTable dt = new DataTable();
            sqlDA.Fill(dt);

            sqlCon.Close();


            if (dt.Rows.Count > 0)
            {
                GrdDesignation.DataSource = dt;
                GrdDesignation.DataBind();
            }
            else
            {
                GrdDesignation.DataSource = null;
                GrdDesignation.DataBind();
            }
        }
        protected void SaveandUpdateDetils()
        {

            string msg = string.Empty;
            Object SaveUSERInfo = (Object)Session["UserInfo"];
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);



            if (TxtDsigName.Text == "")
            {
                msg = msg + "please enter the Designation Name ";
            }
            if (TxtDsigCode.Text == "")
            {
                msg = msg + "please enter the Designation Code ";
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
                    sqlCom.CommandText = "Qn_Designation_Master_SP";
                    sqlCom.CommandTimeout = 0;

                    SqlDataAdapter sda = new SqlDataAdapter();
                    sda.SelectCommand = sqlCom;

                    SqlParameter Designation = new SqlParameter();
                    Designation.SqlDbType = SqlDbType.VarChar;
                    Designation.Value = TxtDsigName.Text.ToString();
                    Designation.ParameterName = "@DesignationName";
                    sqlCom.Parameters.Add(Designation);

                    SqlParameter Designation_code = new SqlParameter();
                    Designation_code.SqlDbType = SqlDbType.VarChar;
                    Designation_code.Value = TxtDsigCode.Text.ToString();
                    Designation_code.ParameterName = "@Designation_code";
                    sqlCom.Parameters.Add(Designation_code);

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
                        lblMsgXls.Text = "Designation Added Suessfully!!";
                        ClearData();
                        AnsGrid();
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
            SaveandUpdateDetils();
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserMenuPage.aspx", false);
        }
        protected void btn_Edit_Click(object sender, EventArgs e)
        {
            lblMsgXls.Text = "";
            Button btn = (Button)sender;
            GridViewRow gr = (GridViewRow)btn.NamingContainer;
            hdnID = GrdDesignation.DataKeys[gr.RowIndex]["Designation_id"].ToString();

            Label lblDesignation = (Label)gr.FindControl("lblDesignation");
            TxtDsigName.Text = lblDesignation.Text.Trim();

            Label lblDesignationCode = (Label)gr.FindControl("lblDesignationCode");
            TxtDsigCode.Text = lblDesignationCode.Text.Trim();

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