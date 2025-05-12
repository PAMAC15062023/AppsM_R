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
    public partial class Qn_Type_Master : System.Web.UI.Page
    {
        private object hdnID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                QnTypeGrid();
            }
        }
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            lblMsgXls.Text = "";
            SaveandUpdateQnTypeDetils();

        }
        protected void ClearData()
        {
            TxtQuType.Text = "";            
            chbIsactive.Checked = false;
        }
        protected void QnTypeGrid()
        {
            // Object SaveUSERInfo = (Object)Session["UserInfo"];
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Qn_Type_Master_Grid";
            sqlCom.CommandTimeout = 0;

            sqlCon.Open();

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            DataTable dt = new DataTable();
            sqlDA.Fill(dt);

            sqlCon.Close();


            if (dt.Rows.Count > 0)
            {
                GrdQn_Type.DataSource = dt;
                GrdQn_Type.DataBind();
            }
            else
            {
                GrdQn_Type.DataSource = null;
                GrdQn_Type.DataBind();
            }
        }
        protected void SaveandUpdateQnTypeDetils()
        {

            string msg = string.Empty;
            Object SaveUSERInfo = (Object)Session["UserInfo"];
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);



            if (TxtQuType.Text == "")
            {
                msg = msg + "please enter the Question type Name ";
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
                    sqlCom.CommandText = "Qn_Type_Master_SP";
                    sqlCom.CommandTimeout = 0;

                    SqlDataAdapter sda = new SqlDataAdapter();
                    sda.SelectCommand = sqlCom;

                    SqlParameter QnType = new SqlParameter();
                    QnType.SqlDbType = SqlDbType.VarChar;
                    QnType.Value = TxtQuType.Text.ToString();
                    QnType.ParameterName = "@TypeName";
                    sqlCom.Parameters.Add(QnType);                    

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
                        lblMsgXls.Text = "Question type Added Suessfully!!";
                        ClearData();
                        QnTypeGrid();
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
            SaveandUpdateQnTypeDetils();
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
            hdnID = GrdQn_Type.DataKeys[gr.RowIndex]["ID"].ToString();

            Label lblQuestionName = (Label)gr.FindControl("lblQuestionName");
            TxtQuType.Text = lblQuestionName.Text.Trim();

            
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