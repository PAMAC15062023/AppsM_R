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
    public partial class Product_Master : System.Web.UI.Page
    {
        private string hdnID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ProductGrid();
            }

        }
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            lblMsgXls.Text = "";
            SaveandUpdateProductDetils();

        }
        protected void ClearData()
        {
            TxtProdName.Text = "";
            chbIsactive.Checked = false;
        }
        protected void ProductGrid()
        {
            // Object SaveUSERInfo = (Object)Session["UserInfo"];
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Qn_ProductMaster_Grid";
            sqlCom.CommandTimeout = 0;

            sqlCon.Open();

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            DataTable dt = new DataTable();
            sqlDA.Fill(dt);

            sqlCon.Close();


            if (dt.Rows.Count > 0)
            {
                GrdProduct.DataSource = dt;
                GrdProduct.DataBind();
            }
            else
            {
                GrdProduct.DataSource = null;
                GrdProduct.DataBind();
            }
        }
        protected void SaveandUpdateProductDetils()
        {

            string msg = string.Empty;
            Object SaveUSERInfo = (Object)Session["UserInfo"];
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);



            if (TxtProdName.Text == "")
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
                    sqlCom.CommandText = "Qn_Product_Master_SP";
                    sqlCom.CommandTimeout = 0;

                    SqlDataAdapter sda = new SqlDataAdapter();
                    sda.SelectCommand = sqlCom;

                    SqlParameter Product = new SqlParameter();
                    Product.SqlDbType = SqlDbType.VarChar;
                    Product.Value = TxtProdName.Text.ToString();
                    Product.ParameterName = "@product_name";
                    sqlCom.Parameters.Add(Product);


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
                        lblMsgXls.Text = "Product Added Suessfully!!";
                        ClearData();
                        ProductGrid();
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
            SaveandUpdateProductDetils();
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
            hdnID = GrdProduct.DataKeys[gr.RowIndex]["product_id"].ToString();

            Label lblProductName = (Label)gr.FindControl("lblProductName");
            TxtProdName.Text = lblProductName.Text.Trim();


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