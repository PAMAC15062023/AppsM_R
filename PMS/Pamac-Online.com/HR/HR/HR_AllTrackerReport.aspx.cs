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
using System.IO;
using System.Drawing;
using System.Data.OleDb;


public partial class HR_HR_HR_AllTrackerReport : System.Web.UI.Page
{
    CBISENTRY CBE = new CBISENTRY();
    DataSet ds = new DataSet();
    CCommon con = new CCommon();
    byte[] raw;

    protected void Page_Load(object sender, EventArgs e)
    {
        CCommon objConn = new CCommon();
        sdsSubcetre.ConnectionString = objConn.ConnectionString;  //Sir
        sdsCentre.ConnectionString = objConn.ConnectionString;  //Sir
        sdsCluster.ConnectionString = objConn.ConnectionString;  //Sir

        if (!IsPostBack)
        {
        }

        string Var_UserId = Session["UserID"].ToString();

        if (Var_UserId == "101149128" || Var_UserId == "101103516" || Var_UserId == "101103390")
        {
            btnHrFinalPenalty.Visible = true;
        }
        else
        {
            btnHrFinalPenalty.Visible = false;
        }

        if (Var_UserId == "101151209" || Var_UserId == "101147887" || Var_UserId == "101149128")
        {
            FileUpload1.Visible = true;
            BtnUploadImg.Visible = true;
        }
        else
        {
            FileUpload1.Visible = false;
            BtnUploadImg.Visible = false;
        }

        btnExportExcel.Visible = false;
        xslFileUpload.Visible = false;
        btnUplaod.Visible = false;
        Label1.Visible = false;
    }

    //protected void btnSearch_Click(object sender, EventArgs e)
    //{
    //    if (ddlCluter.Visible == true && ddlCentre.Visible == true && ddlSubcentre.Visible == true)
    //    {
    //        CBE.ClusterID = ddlCluter.SelectedValue;
    //        CBE.CentreID = ddlCentre.SelectedValue;
    //        CBE.SubCentreID = ddlSubcentre.SelectedValue;

    //    }
    //    else if (ddlCentre.Visible == true && ddlSubcentre.Visible == true)
    //    {
    //        CBE.CentreID = ddlCentre.SelectedValue;
    //        CBE.SubCentreID = ddlSubcentre.SelectedValue;
    //        CBE.ClusterID = Session["ClusterId"].ToString();
    //    }
    //    else if (ddlSubcentre.Visible == true)
    //    {
    //        CBE.SubCentreID = ddlSubcentre.SelectedValue;
    //        CBE.CentreID = Session["CentreId"].ToString();
    //        CBE.ClusterID = Session["ClusterId"].ToString();
    //    }
    //    else
    //    {
    //        CBE.SubCentreID = Session["SubcentreID"].ToString();
    //        CBE.CentreID = Session["CentreId"].ToString();
    //        CBE.ClusterID = Session["ClusterId"].ToString();
    //    }

    //    try
    //    {
    //        CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
    //        sqlcon.Open();

    //        SqlCommand sqlcmd = new SqlCommand();
    //        sqlcmd.Connection = sqlcon;
    //        sqlcmd.CommandType = CommandType.StoredProcedure;
    //        sqlcmd.CommandText = ddlSelectReport.SelectedValue.ToString();
    //        sqlcmd.CommandTimeout = 0;

    //        SqlParameter FromDate = new SqlParameter();
    //        FromDate.SqlDbType = SqlDbType.DateTime;
    //        FromDate.Value = strDate(txtFromDate.Text.Trim());
    //        FromDate.ParameterName = "@FromDate";
    //        sqlcmd.Parameters.Add(FromDate);

    //        SqlParameter ToDate = new SqlParameter();
    //        ToDate.SqlDbType = SqlDbType.DateTime;
    //        ToDate.Value = strDate(txtToDate.Text.Trim());
    //        ToDate.ParameterName = "@ToDate";
    //        sqlcmd.Parameters.Add(ToDate);

    //        //if (ddlSelectReport.SelectedValue != "DOlUpdationReport")
    //        //{

    //        if (ddlSelectReport.SelectedValue != "OJT_MIS")
    //        {

    //            if (ddlSelectReport.SelectedValue == "GET_OJTCOUNTReport" || ddlSelectReport.SelectedValue == "dolUpdationReport12")
    //            {
    //                SqlParameter CentreID = new SqlParameter();
    //                CentreID.SqlDbType = SqlDbType.VarChar;
    //                CentreID.Value = ddlCentre.SelectedValue.ToString();
    //                CentreID.ParameterName = "@CentreID";
    //                sqlcmd.Parameters.Add(CentreID);
    //            }
    //            else if (ddlSelectReport.SelectedValue == "Sp_Pivot_OJT" || ddlSelectReport.SelectedValue == "Sp_Pivot_OJT_PANINDA")
    //            {
    //                if (ddlCentre.SelectedIndex == 0)
    //                {
    //                    SqlParameter CentreID = new SqlParameter();
    //                    CentreID.SqlDbType = SqlDbType.VarChar;
    //                    CentreID.Value = 0;
    //                    CentreID.ParameterName = "@CentreID";
    //                    sqlcmd.Parameters.Add(CentreID);
    //                }
    //                else
    //                {
    //                    SqlParameter CentreID = new SqlParameter();
    //                    CentreID.SqlDbType = SqlDbType.VarChar;
    //                    CentreID.Value = ddlCentre.SelectedValue.ToString();
    //                    CentreID.ParameterName = "@CentreID";
    //                    sqlcmd.Parameters.Add(CentreID);
    //                }

    //                if (ddlSubcentre.SelectedIndex == 0)
    //                {
    //                    SqlParameter SubcentreID = new SqlParameter();
    //                    SubcentreID.SqlDbType = SqlDbType.VarChar;
    //                    SubcentreID.Value = 0;
    //                    SubcentreID.ParameterName = "@SubcentreID";
    //                    sqlcmd.Parameters.Add(SubcentreID);
    //                }
    //                else
    //                {
    //                    SqlParameter SubcentreID = new SqlParameter();
    //                    SubcentreID.SqlDbType = SqlDbType.VarChar;
    //                    SubcentreID.Value = ddlSubcentre.SelectedValue.ToString();
    //                    SubcentreID.ParameterName = "@SubcentreID";
    //                    sqlcmd.Parameters.Add(SubcentreID);
    //                }
    //            }
    //            else
    //            {

    //                if (ddlSelectReport.SelectedValue == "Get_OjtDetailsData" || ddlSelectReport.SelectedValue == "Get_OjtDetailsData_AllCentre" || ddlSelectReport.SelectedValue == "Get_OjtDetailsDataNotUpdated" || ddlSelectReport.SelectedValue == "Get_OjtDetailsDataNotUpdated_Allcentre")
    //                {
    //                    SqlParameter Vertical = new SqlParameter();
    //                    Vertical.SqlDbType = SqlDbType.VarChar;
    //                    Vertical.Value = ddlVertical.SelectedValue.ToString();
    //                    Vertical.ParameterName = "@Vertical";
    //                    sqlcmd.Parameters.Add(Vertical);
    //                }

    //                SqlParameter CentreID = new SqlParameter();
    //                CentreID.SqlDbType = SqlDbType.VarChar;
    //                CentreID.Value = ddlCentre.SelectedValue.ToString();
    //                CentreID.ParameterName = "@CentreID";
    //                sqlcmd.Parameters.Add(CentreID);

    //                SqlParameter SubcentreID = new SqlParameter();
    //                SubcentreID.SqlDbType = SqlDbType.VarChar;
    //                SubcentreID.Value = ddlSubcentre.SelectedValue.ToString();
    //                SubcentreID.ParameterName = "@SubcentreID";
    //                sqlcmd.Parameters.Add(SubcentreID);


    //                if (txtEmpCode.Text == "" || txtEmpCode.Text == null)
    //                {
    //                    SqlParameter EmpCode = new SqlParameter();
    //                    EmpCode.SqlDbType = SqlDbType.VarChar;
    //                    EmpCode.Value = "ALL";
    //                    EmpCode.ParameterName = "@Emp_Code";
    //                    sqlcmd.Parameters.Add(EmpCode);
    //                }
    //                else
    //                {
    //                    SqlParameter EmpCode = new SqlParameter();
    //                    EmpCode.SqlDbType = SqlDbType.VarChar;
    //                    EmpCode.Value = txtEmpCode.Text.Trim();
    //                    EmpCode.ParameterName = "@Emp_Code";
    //                    sqlcmd.Parameters.Add(EmpCode);
    //                }


    //                SqlParameter Cluster_ID = new SqlParameter();
    //                Cluster_ID.SqlDbType = SqlDbType.VarChar;
    //                Cluster_ID.Value = Session["ClusterId"].ToString();
    //                Cluster_ID.ParameterName = "@Cluster_ID";
    //                sqlcmd.Parameters.Add(Cluster_ID);

    //            }
    //        }
    //        //}



    //        SqlDataAdapter sqlda = new SqlDataAdapter();
    //        sqlda.SelectCommand = sqlcmd;

    //        DataTable dt = new DataTable();
    //        sqlda.Fill(dt);

    //        sqlcon.Close();


    //        if (dt.Rows.Count > 0)
    //        {
    //            GvPaMis.DataSource = dt;
    //            GvPaMis.DataBind();
    //            btnExportExcel.Visible = true;
    //            lblMsg.Text = "Total Record Found Is: " + dt.Rows.Count;
    //            lblMsg.Visible = true;
    //        }
    //        else
    //        {
    //            GvPaMis.DataSource = null;
    //            GvPaMis.DataBind();
    //            lblMsg.Text = "Record Not Found";
    //            lblMsg.Visible = true;
    //        }


    //    }
    //    catch (Exception ex)
    //    {
    //        lblMsg.Text = ex.Message;
    //    }

    //}

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (ddlCluter.Visible == true && ddlCentre.Visible == true && ddlSubcentre.Visible == true)
        {
            CBE.ClusterID = ddlCluter.SelectedValue;
            CBE.CentreID = ddlCentre.SelectedValue;
            CBE.SubCentreID = ddlSubcentre.SelectedValue;


        }

        else if (ddlCentre.Visible == true && ddlSubcentre.Visible == true)
        {
            CBE.CentreID = ddlCentre.SelectedValue;
            CBE.SubCentreID = ddlSubcentre.SelectedValue;
            CBE.ClusterID = Session["ClusterId"].ToString();
        }
        else if (ddlSubcentre.Visible == true)
        {
            CBE.SubCentreID = ddlSubcentre.SelectedValue;
            CBE.CentreID = Session["CentreId"].ToString();
            //CBE.ClusterID = Session["ClusterId"].ToString();
        }
        else
        {
            CBE.SubCentreID = Session["SubcentreID"].ToString();
            CBE.CentreID = Session["CentreId"].ToString();
            CBE.ClusterID = Session["ClusterId"].ToString();
        }

        try
        {
            CCommon objConn = new CCommon();
            SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = ddlSelectReport.SelectedValue.ToString();
            sqlcmd.CommandTimeout = 0;

            SqlParameter FromDate = new SqlParameter();
            FromDate.SqlDbType = SqlDbType.DateTime;
            FromDate.Value = strDate(txtFromDate.Text.Trim());
            FromDate.ParameterName = "@FromDate";
            sqlcmd.Parameters.Add(FromDate);

            SqlParameter ToDate = new SqlParameter();
            ToDate.SqlDbType = SqlDbType.DateTime;
            ToDate.Value = strDate(txtToDate.Text.Trim());
            ToDate.ParameterName = "@ToDate";
            sqlcmd.Parameters.Add(ToDate);

            //if (ddlSelectReport.SelectedValue != "DOlUpdationReport")
            //{


            if (ddlSelectReport.SelectedValue != "OJT_MIS_New")
            {

                if (ddlSelectReport.SelectedValue == "GET_OJTCOUNTReport" || ddlSelectReport.SelectedValue == "dolUpdationReport12")
                {
                    SqlParameter CentreID = new SqlParameter();
                    CentreID.SqlDbType = SqlDbType.VarChar;
                    CentreID.Value = ddlCentre.SelectedValue.ToString();
                    CentreID.ParameterName = "@CentreID";
                    sqlcmd.Parameters.Add(CentreID);
                }


                else if (ddlSelectReport.SelectedValue == "Sp_Pivot_OJT" || ddlSelectReport.SelectedValue == "Sp_Pivot_OJT_PANINDA")
                {
                    if (ddlCentre.SelectedIndex == 0)
                    {
                        SqlParameter CentreID = new SqlParameter();
                        CentreID.SqlDbType = SqlDbType.VarChar;
                        CentreID.Value = 0;
                        CentreID.ParameterName = "@CentreID";
                        sqlcmd.Parameters.Add(CentreID);
                    }
                    else
                    {
                        SqlParameter CentreID = new SqlParameter();
                        CentreID.SqlDbType = SqlDbType.VarChar;
                        CentreID.Value = ddlCentre.SelectedValue.ToString();
                        CentreID.ParameterName = "@CentreID";
                        sqlcmd.Parameters.Add(CentreID);
                    }

                    if (ddlSubcentre.SelectedIndex == 0)
                    {
                        SqlParameter SubcentreID = new SqlParameter();
                        SubcentreID.SqlDbType = SqlDbType.VarChar;
                        SubcentreID.Value = 0;
                        SubcentreID.ParameterName = "@SubcentreID";
                        sqlcmd.Parameters.Add(SubcentreID);
                    }
                    else
                    {
                        SqlParameter SubcentreID = new SqlParameter();
                        SubcentreID.SqlDbType = SqlDbType.VarChar;
                        SubcentreID.Value = ddlSubcentre.SelectedValue.ToString();
                        SubcentreID.ParameterName = "@SubcentreID";
                        sqlcmd.Parameters.Add(SubcentreID);
                    }
                }

                else
                {

                    if (ddlSelectReport.SelectedValue == "Get_OjtDetailsData" || ddlSelectReport.SelectedValue == "Get_OjtDetailsData_AllCentre" || ddlSelectReport.SelectedValue == "Get_OjtDetailsDataNotUpdated" || ddlSelectReport.SelectedValue == "Get_OjtDetailsDataNotUpdated_Allcentre")
                    {

                        SqlParameter Vertical = new SqlParameter();
                        Vertical.SqlDbType = SqlDbType.VarChar;
                        Vertical.Value = ddlVertical.SelectedValue.ToString();
                        Vertical.ParameterName = "@Vertical";
                        sqlcmd.Parameters.Add(Vertical);
                    }

                    SqlParameter CentreID = new SqlParameter();
                    CentreID.SqlDbType = SqlDbType.VarChar;
                    CentreID.Value = ddlCentre.SelectedValue.ToString();
                    CentreID.ParameterName = "@CentreID";
                    sqlcmd.Parameters.Add(CentreID);

                    SqlParameter SubcentreID = new SqlParameter();
                    SubcentreID.SqlDbType = SqlDbType.VarChar;
                    SubcentreID.Value = ddlSubcentre.SelectedValue.ToString();
                    SubcentreID.ParameterName = "@SubcentreID";
                    sqlcmd.Parameters.Add(SubcentreID);


                    if (txtEmpCode.Text == "" || txtEmpCode.Text == null)
                    {
                        SqlParameter EmpCode = new SqlParameter();
                        EmpCode.SqlDbType = SqlDbType.VarChar;
                        EmpCode.Value = "ALL";
                        EmpCode.ParameterName = "@Emp_Code";
                        sqlcmd.Parameters.Add(EmpCode);
                    }
                    else
                    {
                        SqlParameter EmpCode = new SqlParameter();
                        EmpCode.SqlDbType = SqlDbType.VarChar;
                        EmpCode.Value = txtEmpCode.Text.Trim();
                        EmpCode.ParameterName = "@Emp_Code";
                        sqlcmd.Parameters.Add(EmpCode);
                    }

                    if (ddlCluter.SelectedIndex == 0)
                    {
                        SqlParameter Cluster_ID = new SqlParameter();
                        Cluster_ID.SqlDbType = SqlDbType.VarChar;
                        Cluster_ID.Value = "ALL";
                        Cluster_ID.ParameterName = "@Cluster_ID";
                        sqlcmd.Parameters.Add(Cluster_ID);
                    }
                    else
                    {
                        SqlParameter Cluster_ID = new SqlParameter();
                        Cluster_ID.SqlDbType = SqlDbType.VarChar;
                        Cluster_ID.Value = ddlCluter.SelectedValue.ToString();
                        Cluster_ID.ParameterName = "@Cluster_ID";
                        sqlcmd.Parameters.Add(Cluster_ID);
                    }

                }
            }
            //}

            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;

            DataTable dt = new DataTable();
            sqlda.Fill(dt);

            sqlcon.Close();

            if (dt.Rows.Count > 0)
            {
                GvPaMis.DataSource = dt;
                GvPaMis.DataBind();
                if (ddlSelectReport.SelectedItem.Text.ToString() == "Attendance Intime Deviation Tracker")
                {
                    xslFileUpload.Visible = true;
                    btnUplaod.Visible = true;
                    Label1.Visible = true;
                }
                btnExportExcel.Visible = true;
                lblMsg.Text = "Total Record Found Is: " + dt.Rows.Count;
                lblMsg.Visible = true;
            }
            else
            {
                GvPaMis.DataSource = null;
                GvPaMis.DataBind();
                lblMsg.Text = "Record Not Found";
                lblMsg.Visible = true;
            }


        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }

    }

    protected void btnExportExcel_Click(object sender, EventArgs e)
    {
        String attachment = "attachment; filename=Tracker.xls";
        Response.ClearHeaders();
        Response.ClearContent();
        Response.Clear();
        Context.Response.AddHeader("content-disposition", attachment);
        Context.Response.ContentType = "application/vnd.ms-excel";
        StringWriter sw = new System.IO.StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        Table tblSpace = new Table();
        TableRow tblRow = new TableRow();
        TableCell tblCell = new TableCell();
        tblCell.Text = " ";

        TableRow tblRow1 = new TableRow();
        TableCell tblCell1 = new TableCell();
        tblCell1.ColumnSpan = 20;// 10;
        tblCell1.Text = "<b><font size='3'>PAMAC FINSERVE PVT. LTD.</font></b> <br/>" +
                        "<b><font size='2'>Tracker Report FROM : " + txtFromDate.Text.Trim() + "  TO : " + txtToDate.Text.Trim() + "  </font></b> <br/><br/><br/>";
        tblRow.Cells.Add(tblCell);
        tblRow1.Cells.Add(tblCell1);
        tblRow.Height = 20;
        tblSpace.Rows.Add(tblRow);
        tblSpace.Rows.Add(tblRow1);
        tblSpace.RenderControl(htw);
        Table tbl = new Table();
        GvPaMis.GridLines = GridLines.Both;
        GvPaMis.EnableViewState = false;
        GvPaMis.RenderControl(htw);
        Response.Write(sw.ToString());
        Response.End();

    }

    public override void VerifyRenderingInServerForm(Control control)
    {


        //Now if you want to see the view schema definition for the above view is not possible. We have stored in the encrypted format. This is a significant option to hide the important calculations inside the view from the others.

        //In case of any alter in the view must be stored externally somewhere else. 

        //SELECT text FROM SYSCOMMENTS WHERE id = OBJECT_ID('[DBO].Vw_SqlObjects_Encrypted') 
        //SELECT definition FROM SYS.sql_modules WHERE object_id = OBJECT_ID('[DBO].Vw_SqlObjects_Encrypted') 
        //sp_helptext Vw_SqlObjects_Encrypted

        //If you execute the above queries then it will say like view is encrypted.

        //There are three types of views in the sql server 2005.

        //They are  
        //1.	Normal or Standard view
        //2.	Indexed or permanent view 
        //3.	Partitioned view
        //Normal or Standard view:

        //This view is most frequently used by the developers. When create the view the schema will be stored an object in the database. When we retrieve the content from this virtual table, it will be executed the schema and stored the data from the parent table.

        //Here if you have the result from the same table then it can be updated and inserted. The deleted row will be reflected in the original table.

        //USE [Northwind]
        //GO
        //IF OBJECT_ID('[DBO].vw_ViewProducts','V') IS NOT NULL
        //BEGIN
        //  DROP VIEW [DBO].vw_ViewProducts
        //  PRINT '<< [DBO].vw_ViewProducts view dropped.. >>'
        //END
        //GO
        //CREATE VIEW [DBO].vw_ViewProducts
        //AS
        // SELECT 
        //    ProductID,ProductName,SupplierID,CategoryID,QuantityPerUnit,UnitPrice,UnitsInStock,UnitsOnOrder,ReorderLevel,Discontinued
        // FROM Products
        //GO
        //IF OBJECT_ID('[DBO].vw_ViewProducts','V') IS NOT NULL
        //BEGIN
        //  PRINT '<< [DBO].vw_ViewProducts view created.. >>'
        //END
        //GO
        //--O/P
        //SELECT * FROM [DBO].vw_ViewProducts
        //--INSERT
        //INSERT INTO [DBO].vw_ViewProducts(ProductName,SupplierID,CategoryID,QuantityPerUnit,UnitPrice,UnitsInStock,UnitsOnOrder,ReorderLevel,Discontinued)
        //VALUES('Test View',1,2,'100 per bag',25.45,89,57,15,0)
        //--DELETE
        //DELETE FROM [DBO].vw_ViewProducts WHERE ProductID = 81

        //Here you can do the DML operations in the view when you have only one table. 

        //Indexed views:

        //The indexed or permanent view is one of the new features introduced in the sql server 2005 version. We have seen that the view only store the schema definition and it will get execute and load the data into the virtual table at the time of view used. But this view creates the permanent view and we can create the indexes on the table. It allows us to create the instead of trigger.

        //The indexed view can be created with the WITH SCHEMA BINDING option while creating the view.

        //The indexed view has some restrictions like cannot use the TOP, DISTINCT, UNION, ORDER BY and aggregate functions.

        //It allows us to use the GROUP BY statement but we cannot use COUNT statement. Instead of that COUNT_BIG statement can be used.

        //IF EXISTS(SELECT OBJECT_ID FROM SYS.OBJECTS WHERE OBJECT_ID = OBJECT_ID(N'[DBO].Vw_Product_Sales_Report',N'V'))
        //BEGIN
        //  DROP VIEW [DBO].Vw_Product_Sales_Report
        //  PRINT '<< [DBO].Vw_Product_Sales_Report view dropped >>'
        //END
        //GO
        //CREATE VIEW [DBO].Vw_Product_Sales_Report
        //WITH SCHEMABINDING
        //AS
        //  SELECT 
        //      O.OrderID
        //     ,C.CustomerID
        //     ,C.CompanyName
        //     ,C.Address+', '+C.City AS [Customer Address]
        //     ,OD.ProductID
        //     ,P.ProductName
        //     ,OD.UnitPrice
        //     ,OD.Quantity
        //     ,(OD.UnitPrice * OD.Quantity) AS [Total]
        //     ,(OD.UnitPrice * OD.Quantity) * OD.Discount/100 AS [Discount]
        //   FROM
        //     [DBO].Orders O (NOLOCK)
        //   INNER JOIN [DBO]."Order Details" OD (NOLOCK) ON OD.OrderID = O.OrderID
        //   INNER JOIN [DBO].Customers C (NOLOCK) ON C.CustomerID = O.CustomerID
        //   INNER JOIN [DBO].Products P (NOLOCK) ON P.ProductID = OD.ProductID
        //GO
        //IF EXISTS(SELECT OBJECT_ID FROM SYS.OBJECTS WHERE OBJECT_ID = OBJECT_ID(N'[DBO].Vw_Product_Sales_Report',N'V'))
        //BEGIN
        //  PRINT '<< [DBO].Vw_Product_Sales_Report view created >>'
        //END
        //GO

        //Here the  indexed view has created. When you retrieve the data from this table, it will execute like normal table.

        //There are some retrictions while creating this indexed view like the name of the view must be two part name and we cannot use select * in the view schema defintion.

        //Normally view cannot have the triggers but from the sql server 2005 onwards We can create the Instead of trigger on the instead of trigger.

        //Partitioned Views:

        //The partitioned view and its execution is like normal view. It will work across the database and across the server.

        //There are two types of Partitioned views. They are  
        //1.	Local Partitioned View
        //2.	Global Partitioned View

        //1. Local Partitioned View:

        //The local partitioned view can be created within same server but different database.

        //The view schema definition will be stored in the executed database. But when we try to retrieve the data from the table, it has to execute the schema definition internally and load the data.

        //Let us see an example.

        //USE [Northwind]
        //GO
        //CREATE TABLE EmployeeList
        //(
        //  iEmployeeID INT IDENTITY(1,1),
        //  vFirstName VARCHAR(25) NOT NULL,
        //  vLastName VARCHAR(25) NOT NULL,
        //  iDeptID INT,
        //  vAddress VARCHAR(25) NOT NULL,
        //  vCity VARCHAR(25) NOT NULL,
        //  vState VARCHAR(25) NOT NULL,
        //  vCountry VARCHAR(25) NOT NULL,
        //)
        //GO
        //USE [Master]
        //GO
        //CREATE TABLE Department
        //(
        //  iDeptID INT IDENTITY(1,1) PRIMARY KEY,
        //  vDeptName VARCHAR(50),
        //  vDeptDesc VARCHAR(25),
        //  vDeptAddedBy VARCHAR(50),
        //  vPostedDate DATETIME DEFAULT GETDATE()
        //)
        //GO
        //--SELECT * FROM Department
        //USE [Northwind]
        //GO
        //IF OBJECT_ID('[DBO].vw_LocalPartion_View','V') IS NOT NULL
        //BEGIN
        //  DROP VIEW [DBO].vw_LocalPartion_View
        //  PRINT '[DBO].vw_LocalPartion_View view dropped...'
        //END
        //GO
        //CREATE VIEW [DBO].vw_LocalPartion_View
        //AS
        //SELECT E.iEmployeeID,E.vFirstName+SPACE(1)+E.vLastName AS [Name],
        //       D.vDeptName,E.vAddress,E.vCity,E.vState
        //FROM EmployeeList E
        //--INNER JOIN Master..Department D ON D.iDeptID = E.iDeptID --Either one of the way will be used.
        //INNER JOIN Master.dbo.Department D ON D.iDeptID = E.iDeptID
        //GO
        //IF OBJECT_ID('[DBO].vw_LocalPartion_View','V') IS NOT NULL
        //BEGIN
        //  PRINT '[DBO].vw_LocalPartion_View view created...'
        //END
        //GO
        //--O/p
        //SELECT * FROM [DBO].vw_LocalPartion_View 

        //2. Global Partitioned View

        //The global Partitioned view will work across the server. The view can be created to join the table across the server.

        //The accessing format will be like this.

        //[Server Name].  Database Name. Table Name

        //When we execute the view if it is not linked with the current server then it will ask us to link the external server.

        //The following system stored procedure will be used to link the server.

        //sp_addlinkedserver 'Server name'

        //The following system catalog table is used to see the list of linked servers.

        //SELECT * FROM SYS.SERVERS

        //INSTEAD OF Triggers on the Indexed View

        //Normally the triggers cannot be created on the view. But sql server 2005 onwards we can create the INSTEAD OF trigger on the indexed views.

        //USE [Northwind]
        //GO
        //IF OBJECT_ID('[DBO].[VW_Trigger_Example') IS NOT NULL
        //BEGIN
        //   DROP VIEW [DBO].[VW_Trigger_Example]
        //   PRINT '[DBO].[VW_Trigger_Example view dropped..'
        //END
        //GO
        //CREATE VIEW [DBO].[VW_Trigger_Example]
        //WITH SCHEMABINDING
        //AS
        //  SELECT P.ProductID,P.ProductName,P.SupplierID,
        //         OD.OrderID,OD.UnitPrice,OD.Quantity
        //  FROM [DBO].Products P
        //  INNER JOIN [DBO].[Order Details] OD ON OD.ProductID = P.ProductID
        //GO
        //IF OBJECT_ID('[DBO].[VW_Trigger_Example') IS NOT NULL
        //BEGIN
        //   PRINT '[DBO].[VW_Trigger_Example view created..'
        //END
        //GO
        //--SELECT * FROM VW_Trigger_Example
        //IF OBJECT_ID('[DBO].Tr_Delete_TriggerExample','TR') IS NOT NULL
        //BEGIN
        //  DROP TRIGGER [DBO].Tr_Delete_TriggerExample
        //  PRINT '[DBO].Tr_Delete_TriggerExample trigger dropped..'
        //END
        //GO
        //CREATE TRIGGER [DBO].Tr_Delete_TriggerExample
        //ON [DBO].VW_Trigger_Example
        //INSTEAD OF DELETE
        //AS
        //BEGIN
        //   PRINT '----------------------------------------'
        //   PRINT 'This is an example of INSTEAD OF Trigger'
        //   PRINT '----------------------------------------'
        //   SELECT TOP 1 * FROM DELETED
        //END
        //GO
        //IF OBJECT_ID('[DBO].Tr_Delete_TriggerExample','TR') IS NOT NULL
        //BEGIN
        //  PRINT '[DBO].Tr_Delete_TriggerExample trigger created..'
        //END
        //GO
        //--O/P
        //--SELECT * FROM [DBO].[VW_Trigger_Example] WHERE ProductID = 11
        //DELETE FROM [DBO].[VW_Trigger_Example] WHERE ProductID=11

        //How to view the Created Views?

        //There are few ways to view the scehema definition of the created views.

        //SP_HELPTEXT vw_LocalPartion_View
        //SELECT id,text FROM SYSCOMMENTS WHERE id = OBJECT_ID('[DBO].vw_LocalPartion_View')
        //SELECT object_id,definition FROM SYS.SQL_MODULES WHERE OBJECT_ID = OBJECT_ID('[DBO].vw_LocalPartion_View')

        //How to drop the View?

        //If you want to drop the view then you can use the following statement. When you drop the table underlying view will not be deleted. But if you run that view it will thrown an error.

        //DROP VIEW VIEW_NAME

        //How to alter the view?

        //If you want to do changes in the created views then you can alter the view whatever you want to view the same view name.

        //ALTER VIEW VIEW_NAME 
        //AS 
        //SELECT [Columns List]....

        //Conclusion:

        //So far, we have seen the views in the sql server 2005. I hope that, this has given enough idea about the views. If there is any correction or suggestions about this article please post your feedback. 



    }

    protected void ddlCentre_DataBound(object sender, EventArgs e)
    {
        ddlCentre.Items.Insert(0, new ListItem("--All--", "ALL"));
    }

    protected void ddlSubcentre_DataBound(object sender, EventArgs e)
    {
        ddlSubcentre.Items.Insert(0, new ListItem("--All--", "ALL"));
    }

    protected void ddlCentre_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlCluter.Visible == true)
            {
                if (ddlCentre.SelectedIndex == 0)
                {
                    sdsSubcetre.SelectCommand = "Select SubCentreName,SubCentreId from SubCentreMaster order by SubCentreName";
                    ddlSubcentre.DataBind();
                }
                else
                {
                    sdsSubcetre.SelectCommand = "Select SubCentreName,SubCentreId from SubCentreMaster where CentreId=" + ddlCentre.SelectedValue + " order by SubCentreName";
                    ddlSubcentre.DataBind();
                }
            }
            else
            {
                if (ddlCentre.SelectedIndex == 0)
                {
                    sdsSubcetre.SelectCommand = "Select SubCentreName,SubCentreId from SubCentreMaster where  ClusterId ='" + Session["ClusterID"] + "'   order by SubCentreName";
                    ddlSubcentre.DataBind();
                }
                else
                {
                    sdsSubcetre.SelectCommand = "Select SubCentreName,SubCentreId from SubCentreMaster where  ClusterId ='" + Session["ClusterID"] + "' and CentreID='" + ddlCentre.SelectedValue + "'  order by SubCentreName";
                    ddlSubcentre.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;

        }
    }

    protected void ddlCluter_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlCluter.SelectedIndex == 0)
            {
                sdsCentre.SelectCommand = "SELECT [CENTRE_ID], [CENTRE_NAME] FROM [CENTRE_MASTER] order by CENTRE_NAME ";
                ddlCentre.DataBind();
            }
            else
            {
                sdsCentre.SelectCommand = "SELECT [CENTRE_ID], [CENTRE_NAME] FROM [CENTRE_MASTER] WHERE ([CLUSTER_ID] = " + ddlCluter.SelectedValue + ") order by CENTRE_NAME";
                ddlCentre.DataBind();
            }
            if (ddlCentre.SelectedIndex == 0)
            {
                string strRole = Session["RoleID"].ToString();
                string[] strRole1 = strRole.Split(',');


                foreach (string str in strRole1)
                {
                    if (str == "25")
                    {
                        sdsSubcetre.SelectCommand = "Select SubCentreName,SubCentreId from SubCentreMaster where ClusterID=" + Session["ClusterId"].ToString() + " order by SubCentreName";
                    }
                    if (str == "24")
                    {
                        sdsSubcetre.SelectCommand = "Select SubCentreName,SubCentreId from SubCentreMaster  order by SubCentreName";

                    }
                }
                ddlSubcentre.DataBind();
            }
            else
            {
                sdsSubcetre.SelectCommand = "Select SubCentreName,SubCentreId from SubCentreMaster where CentreId=" + ddlCentre.SelectedValue + " order by SubCentreName";
                ddlSubcentre.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }

    protected void ddlCluter_DataBound(object sender, EventArgs e)
    {
        ddlCluter.Items.Insert(0, new ListItem("--All--", "0"));
    }

    public string strDate(string strInDate)
    {
        string strDD = strInDate.Substring(0, 2);

        string strMM = strInDate.Substring(3, 2);

        string strYYYY = strInDate.Substring(6, 4);

        string strMMDDYYYY = strMM + "/" + strDD + "/" + strYYYY;  //on Server 

        //string strMMDDYYYY = strDD + "/" + strMM + "/" + strYYYY;   //On local machine

        DateTime dtConvertDate = Convert.ToDateTime(strMMDDYYYY);

        string strOutDate = dtConvertDate.ToString("dd-MMM-yyyy");

        return strOutDate;
    }

    public void ExcelUpload()
    {
        {
            try
            {
                if (xslFileUpload.HasFile)
                {
                    String strPath = "";
                    String MyFile = "";
                    string strDateTime = DateTime.Now.ToString("ddMMyyyyhhmmss");

                    strPath = Server.MapPath("../../ImportFiles/");
                    MyFile = strDateTime + ".xls";
                    strPath = (strPath + MyFile);
                    xslFileUpload.PostedFile.SaveAs(strPath);

                    string strFileName = xslFileUpload.FileName.ToString();

                    FileInfo fi = new FileInfo(strFileName);
                    string strExt = fi.Extension;

                    if (strExt.ToLower() == ".xls")
                    {
                        string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strPath + @";Extended Properties=""Excel 8.0;IMEX=1""";

                        OleDbConnection oleCon = new OleDbConnection(strConn);
                        oleCon.Open();

                        OleDbCommand oleCom = new OleDbCommand("SELECT * FROM [sheet1$]");
                        oleCom.Connection = oleCon;

                        OleDbDataAdapter oleDA = new OleDbDataAdapter();
                        oleDA.SelectCommand = oleCom;

                        DataTable dt = new DataTable();
                        oleDA.Fill(dt);
                        oleCon.Close();

                        if (dt.Rows.Count > 0)
                        {
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                UpdatePenaltyManual(dt.Rows[i]);
                            }
                            lblMsg.Text = "Record Save Successfully...!!! Total Count: " + dt.Rows.Count;
                            btnExportExcel.Visible = true;
                            xslFileUpload.Visible = true;
                            btnUplaod.Visible = true;
                            Label1.Visible = true;
                        }

                        string strFile = Server.MapPath("../../ImportFiles/") + MyFile;
                        if (File.Exists(strFile))
                        {
                            File.Delete(strFile);
                        }
                    }
                    else
                    {
                        lblMsg.Visible = true;
                        lblMsg.Text = "It's Not An Excel File...!!!";
                        btnExportExcel.Visible = true;
                        xslFileUpload.Visible = true;
                        btnUplaod.Visible = true;
                        Label1.Visible = true;
                    }
                }
                else
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Please Select Excel File To Import...!!!";
                    btnExportExcel.Visible = true;
                    xslFileUpload.Visible = true;
                    btnUplaod.Visible = true;
                    Label1.Visible = true;
                }
            }
            catch (Exception ex)
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Error :" + ex.Message;
                btnExportExcel.Visible = true;
                xslFileUpload.Visible = true;
                btnUplaod.Visible = true;
                Label1.Visible = true;
            }
        }
    }

    protected void UpdatePenaltyManual(DataRow dr)
    {
        CCommon objConn = new CCommon();
        SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Sp_TimeTrackerOut_ManualPenalty_New";
        sqlcmd.CommandTimeout = 0;

        //SqlParameter ManualPenaltydays = new SqlParameter();
        //ManualPenaltydays.SqlDbType = SqlDbType.VarChar;
        //ManualPenaltydays.Value = dr["ManualPenaltydays"].ToString().Trim();//dc.ColumnName[0].ToString().Trim();
        //ManualPenaltydays.ParameterName = "@ManualPenaltydays";
        //sqlcmd.Parameters.Add(ManualPenaltydays);

        SqlParameter penalty1 = new SqlParameter();
        penalty1.SqlDbType = SqlDbType.Decimal;
        penalty1.Value = Convert.ToDecimal(dr["<30 min Days"]);//dc.ColumnName[0].ToString().Trim();
        penalty1.ParameterName = "@penalty1";
        sqlcmd.Parameters.Add(penalty1);

        SqlParameter penalty2 = new SqlParameter();
        penalty2.SqlDbType = SqlDbType.Decimal;
        penalty2.Value = Convert.ToDecimal(dr[">30 &< 1 hr Days"]);//dc.ColumnName[0].ToString().Trim();
        penalty2.ParameterName = "@penalty2";
        sqlcmd.Parameters.Add(penalty2);

        SqlParameter penalty3 = new SqlParameter();
        penalty3.SqlDbType = SqlDbType.Decimal;
        penalty3.Value = Convert.ToDecimal(dr["> 1hr Days"]);//dc.ColumnName[0].ToString().Trim();
        penalty3.ParameterName = "@penalty3";
        sqlcmd.Parameters.Add(penalty3);

        SqlParameter emp_code = new SqlParameter();
        emp_code.SqlDbType = SqlDbType.VarChar;
        emp_code.Value = dr["emp_code"].ToString().Trim();//dc.ColumnName[0].ToString().Trim();
        emp_code.ParameterName = "@emp_code";
        sqlcmd.Parameters.Add(emp_code);

        SqlParameter AddedBy = new SqlParameter();
        AddedBy.SqlDbType = SqlDbType.VarChar;
        AddedBy.Value = Session["UserID"].ToString();
        AddedBy.ParameterName = "@AddedBy";
        sqlcmd.Parameters.Add(AddedBy);

        int RowEffected = 0;
        RowEffected = sqlcmd.ExecuteNonQuery();
        sqlcon.Close();

        if (RowEffected > 0)
        {
            lblMsg.Visible = true;
        }
    }

    protected void btnUplaod_Click(object sender, EventArgs e)
    {
        ExcelUpload();
        try
        {
            CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            //sqlcmd.CommandText = "Sp_Final_TimetrackerOut";
            sqlcmd.CommandText = "Sp_Final_TimetrackerOut";
            sqlcmd.CommandTimeout = 0;

            SqlParameter FromDate = new SqlParameter();
            FromDate.SqlDbType = SqlDbType.DateTime;
            FromDate.Value = strDate(txtFromDate.Text.Trim());
            FromDate.ParameterName = "@FromDate";
            sqlcmd.Parameters.Add(FromDate);

            SqlParameter ToDate = new SqlParameter();
            ToDate.SqlDbType = SqlDbType.DateTime;
            ToDate.Value = strDate(txtToDate.Text.Trim());
            ToDate.ParameterName = "@ToDate";
            sqlcmd.Parameters.Add(ToDate);

            //if (ddlSelectReport.SelectedValue != "DOlUpdationReport")
            //{


            if (ddlSelectReport.SelectedValue != "OJT_MIS")
            {

                if (ddlSelectReport.SelectedValue == "GET_OJTCOUNTReport" || ddlSelectReport.SelectedValue == "dolUpdationReport12")
                {
                    SqlParameter CentreID = new SqlParameter();
                    CentreID.SqlDbType = SqlDbType.VarChar;
                    CentreID.Value = ddlCentre.SelectedValue.ToString();
                    CentreID.ParameterName = "@CentreID";
                    sqlcmd.Parameters.Add(CentreID);
                }


                else if (ddlSelectReport.SelectedValue == "Sp_Pivot_OJT" || ddlSelectReport.SelectedValue == "Sp_Pivot_OJT_PANINDA")
                {
                    if (ddlCentre.SelectedIndex == 0)
                    {
                        SqlParameter CentreID = new SqlParameter();
                        CentreID.SqlDbType = SqlDbType.VarChar;
                        CentreID.Value = 0;
                        CentreID.ParameterName = "@CentreID";
                        sqlcmd.Parameters.Add(CentreID);
                    }
                    else
                    {
                        SqlParameter CentreID = new SqlParameter();
                        CentreID.SqlDbType = SqlDbType.VarChar;
                        CentreID.Value = ddlCentre.SelectedValue.ToString();
                        CentreID.ParameterName = "@CentreID";
                        sqlcmd.Parameters.Add(CentreID);
                    }

                    if (ddlSubcentre.SelectedIndex == 0)
                    {
                        SqlParameter SubcentreID = new SqlParameter();
                        SubcentreID.SqlDbType = SqlDbType.VarChar;
                        SubcentreID.Value = 0;
                        SubcentreID.ParameterName = "@SubcentreID";
                        sqlcmd.Parameters.Add(SubcentreID);
                    }
                    else
                    {
                        SqlParameter SubcentreID = new SqlParameter();
                        SubcentreID.SqlDbType = SqlDbType.VarChar;
                        SubcentreID.Value = ddlSubcentre.SelectedValue.ToString();
                        SubcentreID.ParameterName = "@SubcentreID";
                        sqlcmd.Parameters.Add(SubcentreID);
                    }
                }

                else
                {

                    if (ddlSelectReport.SelectedValue == "Get_OjtDetailsData" || ddlSelectReport.SelectedValue == "Get_OjtDetailsData_AllCentre" || ddlSelectReport.SelectedValue == "Get_OjtDetailsDataNotUpdated" || ddlSelectReport.SelectedValue == "Get_OjtDetailsDataNotUpdated_Allcentre")
                    {

                        SqlParameter Vertical = new SqlParameter();
                        Vertical.SqlDbType = SqlDbType.VarChar;
                        Vertical.Value = ddlVertical.SelectedValue.ToString();
                        Vertical.ParameterName = "@Vertical";
                        sqlcmd.Parameters.Add(Vertical);
                    }

                    SqlParameter CentreID = new SqlParameter();
                    CentreID.SqlDbType = SqlDbType.VarChar;
                    CentreID.Value = ddlCentre.SelectedValue.ToString();
                    CentreID.ParameterName = "@CentreID";
                    sqlcmd.Parameters.Add(CentreID);

                    SqlParameter SubcentreID = new SqlParameter();
                    SubcentreID.SqlDbType = SqlDbType.VarChar;
                    SubcentreID.Value = ddlSubcentre.SelectedValue.ToString();
                    SubcentreID.ParameterName = "@SubcentreID";
                    sqlcmd.Parameters.Add(SubcentreID);


                    if (txtEmpCode.Text == "" || txtEmpCode.Text == null)
                    {
                        SqlParameter EmpCode = new SqlParameter();
                        EmpCode.SqlDbType = SqlDbType.VarChar;
                        EmpCode.Value = "ALL";
                        EmpCode.ParameterName = "@Emp_Code";
                        sqlcmd.Parameters.Add(EmpCode);
                    }
                    else
                    {
                        SqlParameter EmpCode = new SqlParameter();
                        EmpCode.SqlDbType = SqlDbType.VarChar;
                        EmpCode.Value = txtEmpCode.Text.Trim();
                        EmpCode.ParameterName = "@Emp_Code";
                        sqlcmd.Parameters.Add(EmpCode);
                    }

                    if (ddlCluter.SelectedIndex == 0)
                    {
                        SqlParameter Cluster_ID = new SqlParameter();
                        Cluster_ID.SqlDbType = SqlDbType.VarChar;
                        Cluster_ID.Value = "ALL";
                        Cluster_ID.ParameterName = "@Cluster_ID";
                        sqlcmd.Parameters.Add(Cluster_ID);
                    }
                    else
                    {
                        SqlParameter Cluster_ID = new SqlParameter();
                        Cluster_ID.SqlDbType = SqlDbType.VarChar;
                        Cluster_ID.Value = ddlCluter.SelectedValue.ToString();
                        Cluster_ID.ParameterName = "@Cluster_ID";
                        sqlcmd.Parameters.Add(Cluster_ID);
                    }

                }
            }

            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;

            DataTable dt = new DataTable();
            sqlda.Fill(dt);

            sqlcon.Close();

            if (dt.Rows.Count > 0)
            {
                GvPaMis.DataSource = dt;
                GvPaMis.DataBind();
                btnExportExcel.Visible = true;
                xslFileUpload.Visible = true;
                btnUplaod.Visible = true;
                Label1.Visible = true;
                lblMsg.Text = "Total Record Found Is: " + dt.Rows.Count;
                lblMsg.Visible = true;
            }
            else
            {
                GvPaMis.DataSource = null;
                GvPaMis.DataBind();
                lblMsg.Text = "Record Not Found";
                lblMsg.Visible = true;
            }
        }
        catch (Exception ex)
        {
        }
        finally
        {

        }

    }

    protected void btnHrFinalPenalty_Click(object sender, EventArgs e)
    {
        try
        {
            CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Sp_Final_TimetrackerOut_FinalPenalty_Combine";
            sqlcmd.CommandTimeout = 0;

            SqlParameter FromDate = new SqlParameter();
            FromDate.SqlDbType = SqlDbType.DateTime;
            FromDate.Value = strDate(txtFromDate.Text.Trim());
            FromDate.ParameterName = "@FromDate";
            sqlcmd.Parameters.Add(FromDate);

            SqlParameter ToDate = new SqlParameter();
            ToDate.SqlDbType = SqlDbType.DateTime;
            ToDate.Value = strDate(txtToDate.Text.Trim());
            ToDate.ParameterName = "@ToDate";
            sqlcmd.Parameters.Add(ToDate);

            //if (ddlSelectReport.SelectedValue != "DOlUpdationReport")
            //{


            if (ddlSelectReport.SelectedValue != "OJT_MIS")
            {

                if (ddlSelectReport.SelectedValue == "GET_OJTCOUNTReport" || ddlSelectReport.SelectedValue == "dolUpdationReport12")
                {
                    SqlParameter CentreID = new SqlParameter();
                    CentreID.SqlDbType = SqlDbType.VarChar;
                    CentreID.Value = ddlCentre.SelectedValue.ToString();
                    CentreID.ParameterName = "@CentreID";
                    sqlcmd.Parameters.Add(CentreID);
                }


                else if (ddlSelectReport.SelectedValue == "Sp_Pivot_OJT" || ddlSelectReport.SelectedValue == "Sp_Pivot_OJT_PANINDA")
                {
                    if (ddlCentre.SelectedIndex == 0)
                    {
                        SqlParameter CentreID = new SqlParameter();
                        CentreID.SqlDbType = SqlDbType.VarChar;
                        CentreID.Value = 0;
                        CentreID.ParameterName = "@CentreID";
                        sqlcmd.Parameters.Add(CentreID);
                    }
                    else
                    {
                        SqlParameter CentreID = new SqlParameter();
                        CentreID.SqlDbType = SqlDbType.VarChar;
                        CentreID.Value = ddlCentre.SelectedValue.ToString();
                        CentreID.ParameterName = "@CentreID";
                        sqlcmd.Parameters.Add(CentreID);
                    }

                    if (ddlSubcentre.SelectedIndex == 0)
                    {
                        SqlParameter SubcentreID = new SqlParameter();
                        SubcentreID.SqlDbType = SqlDbType.VarChar;
                        SubcentreID.Value = 0;
                        SubcentreID.ParameterName = "@SubcentreID";
                        sqlcmd.Parameters.Add(SubcentreID);
                    }
                    else
                    {
                        SqlParameter SubcentreID = new SqlParameter();
                        SubcentreID.SqlDbType = SqlDbType.VarChar;
                        SubcentreID.Value = ddlSubcentre.SelectedValue.ToString();
                        SubcentreID.ParameterName = "@SubcentreID";
                        sqlcmd.Parameters.Add(SubcentreID);
                    }
                }

                else
                {

                    if (ddlSelectReport.SelectedValue == "Get_OjtDetailsData" || ddlSelectReport.SelectedValue == "Get_OjtDetailsData_AllCentre" || ddlSelectReport.SelectedValue == "Get_OjtDetailsDataNotUpdated" || ddlSelectReport.SelectedValue == "Get_OjtDetailsDataNotUpdated_Allcentre")
                    {

                        SqlParameter Vertical = new SqlParameter();
                        Vertical.SqlDbType = SqlDbType.VarChar;
                        Vertical.Value = ddlVertical.SelectedValue.ToString();
                        Vertical.ParameterName = "@Vertical";
                        sqlcmd.Parameters.Add(Vertical);
                    }

                    SqlParameter CentreID = new SqlParameter();
                    CentreID.SqlDbType = SqlDbType.VarChar;
                    CentreID.Value = ddlCentre.SelectedValue.ToString();
                    CentreID.ParameterName = "@CentreID";
                    sqlcmd.Parameters.Add(CentreID);

                    SqlParameter SubcentreID = new SqlParameter();
                    SubcentreID.SqlDbType = SqlDbType.VarChar;
                    SubcentreID.Value = ddlSubcentre.SelectedValue.ToString();
                    SubcentreID.ParameterName = "@SubcentreID";
                    sqlcmd.Parameters.Add(SubcentreID);


                    if (txtEmpCode.Text == "" || txtEmpCode.Text == null)
                    {
                        SqlParameter EmpCode = new SqlParameter();
                        EmpCode.SqlDbType = SqlDbType.VarChar;
                        EmpCode.Value = "ALL";
                        EmpCode.ParameterName = "@Emp_Code";
                        sqlcmd.Parameters.Add(EmpCode);
                    }
                    else
                    {
                        SqlParameter EmpCode = new SqlParameter();
                        EmpCode.SqlDbType = SqlDbType.VarChar;
                        EmpCode.Value = txtEmpCode.Text.Trim();
                        EmpCode.ParameterName = "@Emp_Code";
                        sqlcmd.Parameters.Add(EmpCode);
                    }

                    if (ddlCluter.SelectedIndex == 0)
                    {
                        SqlParameter Cluster_ID = new SqlParameter();
                        Cluster_ID.SqlDbType = SqlDbType.VarChar;
                        Cluster_ID.Value = "ALL";
                        Cluster_ID.ParameterName = "@Cluster_ID";
                        sqlcmd.Parameters.Add(Cluster_ID);
                    }
                    else
                    {
                        SqlParameter Cluster_ID = new SqlParameter();
                        Cluster_ID.SqlDbType = SqlDbType.VarChar;
                        Cluster_ID.Value = ddlCluter.SelectedValue.ToString();
                        Cluster_ID.ParameterName = "@Cluster_ID";
                        sqlcmd.Parameters.Add(Cluster_ID);
                    }

                }
            }

            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;

            DataTable dt = new DataTable();
            sqlda.Fill(dt);

            sqlcon.Close();

            if (dt.Rows.Count > 0)
            {
                GvPaMis.DataSource = dt;
                GvPaMis.DataBind();

                GvPaMis.HeaderRow.Cells[8].BackColor = Color.Orange;
                GvPaMis.HeaderRow.Cells[9].BackColor = Color.Orange;
                GvPaMis.HeaderRow.Cells[10].BackColor = Color.Orange;
                GvPaMis.HeaderRow.Cells[11].BackColor = Color.Orange;
                GvPaMis.HeaderRow.Cells[12].BackColor = Color.Orange;
                GvPaMis.HeaderRow.Cells[13].BackColor = Color.Orange;
                GvPaMis.HeaderRow.Cells[14].BackColor = Color.Orange;
                GvPaMis.HeaderRow.Cells[15].BackColor = Color.Orange;
                GvPaMis.HeaderRow.Cells[16].BackColor = Color.Orange;

                GvPaMis.HeaderRow.Cells[17].BackColor = Color.Green;
                GvPaMis.HeaderRow.Cells[18].BackColor = Color.Green;
                GvPaMis.HeaderRow.Cells[19].BackColor = Color.Green;
                GvPaMis.HeaderRow.Cells[20].BackColor = Color.Green;
                GvPaMis.HeaderRow.Cells[21].BackColor = Color.Green;
                GvPaMis.HeaderRow.Cells[22].BackColor = Color.Green;
                GvPaMis.HeaderRow.Cells[23].BackColor = Color.Green;
                GvPaMis.HeaderRow.Cells[24].BackColor = Color.Green;
                GvPaMis.HeaderRow.Cells[25].BackColor = Color.Green;

                GvPaMis.HeaderRow.Cells[26].BackColor = Color.Red;
                GvPaMis.HeaderRow.Cells[27].BackColor = Color.Red;
                GvPaMis.HeaderRow.Cells[28].BackColor = Color.Red;
                GvPaMis.HeaderRow.Cells[29].BackColor = Color.Red;
                GvPaMis.HeaderRow.Cells[30].BackColor = Color.Red;
                GvPaMis.HeaderRow.Cells[31].BackColor = Color.Red;
                GvPaMis.HeaderRow.Cells[32].BackColor = Color.Red;
                GvPaMis.HeaderRow.Cells[33].BackColor = Color.Red;
                GvPaMis.HeaderRow.Cells[34].BackColor = Color.Red;

                btnExportExcel.Visible = true;
                xslFileUpload.Visible = true;
                btnUplaod.Visible = true;
                Label1.Visible = true;
                lblMsg.Text = "Total Record Found Is: " + dt.Rows.Count;
                lblMsg.Visible = true;
            }
            else
            {
                GvPaMis.DataSource = null;
                GvPaMis.DataBind();
                lblMsg.Text = "Record Not Found";
                lblMsg.Visible = true;
            }
        }
        catch (Exception ex)
        {
        }
        finally
        {

        }
    }

    protected void GvPaMis_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void BtnUploadImg_Click(object sender, EventArgs e)
    {
        try
        {
            CCommon objConn = new CCommon();
            SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            if ((FileUpload1.FileName != ""))
            {
                //to allow only jpg gif and png files to be uploaded.
                string extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
                if (((extension == ".jpg") || ((extension == ".gif") || (extension == ".png"))))
                {
                    FileStream fs = new FileStream(FileUpload1.PostedFile.FileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    raw = new byte[fs.Length];
                    fs.Read(raw, 0, Convert.ToInt32(fs.Length));

                    sqlcon.Open();
                    SqlCommand cmd = new SqlCommand("Insert_CENTRE_MASTER_assets", sqlcon);
                    cmd.CommandType = CommandType.StoredProcedure;

                    string RepStr = FileUpload1.FileName.Replace(@"&fs", @"\").Trim();
                    //string a = RepStr.Replace(@"\\", @"\");
                    string str = RepStr.Remove(RepStr.Length - 4);
                    //string output = RepStr.Substring(RepStr.IndexOf('.') - 3);

                    cmd.Parameters.AddWithValue("@TransRefNo", str);
                    cmd.Parameters.AddWithValue("@CENTRE_PAMACSEAL", raw);
                    //sqlcon.Open();
                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        //string script = "<script>alert('Data Added Successfully')</script>";
                        //Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Added", script);
                        lblMsg.Text = "Data Added Successfully'";
                    }
                    else
                    {
                        //string script = "<script>alert('Error Adding Data')</script>";
                        //Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Error", script);
                        lblMsg.Text = "Error Adding Data";
                    }
                }
                else
                {
                    lblMsg.Text = "Only Jpg,gif or Png files are permitted";
                }
            }
            else
            {
                lblMsg.Text = "Kindly Select a File.....";
            }
            sqlcon.Close();
        }
        catch (Exception e1)
        {

        }
    }

}
