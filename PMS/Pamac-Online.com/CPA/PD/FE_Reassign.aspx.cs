using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class CPA_PD_FE_Reassign : System.Web.UI.Page
{



    //protected void Page_Load(object sender, EventArgs e)
    //{
    //    sqlcon = new SqlConnection(objConn.AppConnectionString);

      
    //}

    //protected void fillgrid()
    //{
    //    try
    //    {
    //        sqlcon.Open();
    //        SqlCommand cmd = new SqlCommand();
    //        cmd.Connection = sqlcon;
    //        cmd.CommandType = CommandType.StoredProcedure;
    //        cmd.CommandText = ddlCase.SelectedValue.ToString();
    //        cmd.CommandTimeout = 0;

    //        if (Hdnmaster.Value == "2")
    //        {
    //            SqlParameter center_name = new SqlParameter();
    //            center_name.SqlDbType = SqlDbType.VarChar;
    //            center_name.Value = ddlcenter.SelectedValue.ToString();
    //            center_name.ParameterName = "@Centre_Name";
    //            cmd.Parameters.Add(center_name);

    //            SqlParameter Cluster_id = new SqlParameter();
    //            Cluster_id.SqlDbType = SqlDbType.VarChar;
    //            Cluster_id.Value = ddlclustername.SelectedValue.ToString();
    //            Cluster_id.ParameterName = "@Cluster_id";
    //            cmd.Parameters.Add(Cluster_id);
    //        }
    //        else
    //        {
    //            SqlParameter Cluster_id = new SqlParameter();
    //            Cluster_id.SqlDbType = SqlDbType.VarChar;
    //            Cluster_id.Value = Session["Clusterid"].ToString();
    //            Cluster_id.ParameterName = "@Cluster_id";
    //            cmd.Parameters.Add(Cluster_id);

    //            SqlParameter center_name = new SqlParameter();
    //            center_name.SqlDbType = SqlDbType.VarChar;
    //            center_name.Value = Session["Centreid"].ToString();
    //            center_name.ParameterName = "@Centre_Name";
    //            cmd.Parameters.Add(center_name);
    //        }

    //        //SqlParameter verificationtype = new SqlParameter();
    //        //verificationtype.SqlDbType = SqlDbType.VarChar;
    //        //verificationtype.Value = ddlverificationtype.SelectedValue.ToString();
    //        //verificationtype.ParameterName = "@Verification_type_code";
    //        //cmd.Parameters.Add(verificationtype);

    //        SqlDataAdapter sqlda1 = new SqlDataAdapter();
    //        sqlda1.SelectCommand = cmd;

    //        DataTable dt = new DataTable();
    //        sqlda1.Fill(dt);
    //        sqlcon.Close();

    //        if (dt.Rows.Count > 0)
    //        {
    //            lblMsgXls.Text = "Total Count : " + dt.Rows.Count;

    //            Grvcasedata.DataSource = dt;
    //            Grvcasedata.DataBind();
    //        }
    //        else
    //        {
    //            lblMsgXls.Text = "No Records Found...!!!";

    //            Grvcasedata.DataSource = null;
    //            Grvcasedata.DataBind();
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        lblMsgXls.Text = ex.Message;
    //    }
    //}
}
