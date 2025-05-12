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
using System.Data.SqlClient;

public partial class HO_ADMIN_SHARES_ReportViewer : System.Web.UI.Page
{
    int CurrentIndex = 0;
    int ShareHolderId = 0;
    int DetailId = 0;
    string[] arr = new string[2];
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count == 0)
        {
            Response.Redirect("~/Index.aspx?Message=Session expired.Please select the zone again.");
        }

        if (Request.QueryString.Count == 2)
        {
           
            arr[0] = Request.QueryString["ID"];
            arr[1] = Request.QueryString["DID"];

            string arrList = arr[1];
            string[] arrMain = arrList.Split('|'); ;
            

            if (arrMain.Length >= CurrentIndex)
            {

                Load_Image(Convert.ToInt32(arr[0]), Convert.ToInt32(arrMain[CurrentIndex]));
            }
            if (arrMain.Length==2)
            {
                imgNext.Enabled = false;
                imgPrevious.Enabled = false;
            }
        }
        
        
    }
    protected void imgNext_Click(object sender, ImageClickEventArgs e)
    {
        string arrList=arr[1];
        string[] arrMain = arrList.Split('|'); ;
        CurrentIndex = CurrentIndex + 1;

        if (arrMain.Length-1 >=CurrentIndex)
        {

            Load_Image(Convert.ToInt32(arr[0]), Convert.ToInt32(arrMain[CurrentIndex]));
        }
        
    }

    protected void imgPrevious_Click(object sender, ImageClickEventArgs e)
    {
        string arrList = arr[1];
        string[] arrMain = arrList.Split('|'); ;
        CurrentIndex = CurrentIndex - 1;

        if (arrMain.Length - 1 <= CurrentIndex)
        {

            Load_Image(Convert.ToInt32(arr[0]), Convert.ToInt32(arrMain[CurrentIndex]));
        }
    }
    private void Load_Image(int pShareHolderID, int pDetailID)
    {


        CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);

        sqlcon.Open();
        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlcon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = "Get_ShareCertificate_Print";

        SqlParameter ShareHolderID = new SqlParameter();
        ShareHolderID.SqlDbType = SqlDbType.Int;
        ShareHolderID.Value = Convert.ToInt32(pShareHolderID);
        ShareHolderID.ParameterName = "@ShareHolderID";
        sqlCom.Parameters.Add(ShareHolderID);

        SqlParameter DetailID = new SqlParameter();
        DetailID.SqlDbType = SqlDbType.Int;
        DetailID.Value = Convert.ToInt32(pDetailID);
        DetailID.ParameterName = "@DetailID";
        sqlCom.Parameters.Add(DetailID);


        SqlDataAdapter sqlDA = new SqlDataAdapter();
        sqlDA.SelectCommand = sqlCom;

        DataTable dt = new DataTable();
        sqlDA.Fill(dt);
        sqlcon.Close();

        if (dt.Rows.Count > 0)
        {

            string ReportPath = String.Concat("ReportRender.aspx?1=", dt.Rows[0]["ShareHolderName"].ToString(), "&2=", dt.Rows[0]["Folio_No"].ToString(), "&3=", dt.Rows[0]["Certificate_No"].ToString(), "&4=", dt.Rows[0]["No_of_Shares_Text"].ToString(), "&5=", dt.Rows[0]["Dist_No"].ToString());

            IFrame1.Attributes.Add("src", ReportPath);
        }
    
    }
}
