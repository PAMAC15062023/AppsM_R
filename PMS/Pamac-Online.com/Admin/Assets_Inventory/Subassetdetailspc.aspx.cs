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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;


public partial class Admin_Assets_Inventory_Subassetdetailspc : System.Web.UI.Page
{
    string hddtrans = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            txtemptrans.Text.Trim();

            Panel1.Visible = false;
            //Panel3.Visible = false;
            if (Request.QueryString["CentreID"] != "" && Request.QueryString["CentreID"] != null && Request.QueryString["SubcentreID"] != "" && Request.QueryString["SubcentreID"] != null)
            {
                hdnCentre.Value = Request.QueryString["CentreID"].ToString();

                hdnSubcentre.Value = Request.QueryString["SubcentreID"].ToString();
            }

            if (Request.QueryString["TranRefNo"] != "" && Request.QueryString["TranRefNo"] != null)
            {
                hdnTranRefNo.Value = Request.QueryString["TranRefNo"].ToString();

            }
            /////////added by prachi/////////////
            if (Request.QueryString["PageSttaus"] != "" && Request.QueryString["PageSttaus"] != null)
            {
                hdnScrapStats.Value = Request.QueryString["PageSttaus"].ToString();

            }
            /////////////////////
            if (Request.QueryString["AssetType"] != "" && Request.QueryString["AssetType"] != null)
            {
                hdnAssetType.Value = Request.QueryString["AssetType"].ToString();
            }
            if (Request.QueryString["EmpCode"] != "" && Request.QueryString["EmpCode"] != null)
            {
                hdnEmpCode.Value = Request.QueryString["EmpCode"].ToString();
            }

            Get_ClusterList();
            GetCentreList();
            GetSubCentreList();
            GetSubCentreName();
            Get_Empname();
            Get_DescriptionData2();
            getdetails();
            
        }

    }

    public string strDate(string strInDate)
    {
        string strDD = strInDate.Substring(0, 2);
        string strMM = strInDate.Substring(3, 2);
        string strYYYY = strInDate.Substring(6, 4);
        string strMMDDYYYY = strMM + "/" + strDD + "/" + strYYYY;
        //string strMMDDYYYY = strDD + "/" + strMM + "/" + strYYYY;
        DateTime dtConvertDate = Convert.ToDateTime(strMMDDYYYY);
        string strOutDate = dtConvertDate.ToString("dd-MMM-yyyy");
        return strOutDate;
    }
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        if (txtemptrans.Text != "")
        {
            hdnTranRefNo.Value = txtemptrans.Text.Trim();
        }
        else
        {

        }

        Get_DescriptionData2();
        getdetails();
    }
    public void getdetails()
    {
        CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "GetAlldetails_1203";//"GetAlldetails";
        sqlcmd.CommandTimeout = 0;

        SqlParameter TransRefNo = new SqlParameter();
        TransRefNo.SqlDbType = SqlDbType.VarChar;
        TransRefNo.Value = hdnTranRefNo.Value;
        TransRefNo.ParameterName = "@TransRefNo";
        sqlcmd.Parameters.Add(TransRefNo);

        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;
        DataTable dt = new DataTable();
        sqlda.Fill(dt);
        sqlcon.Close();

        if (dt.Rows.Count > 0)
        {
            lblsubcentre.Text = dt.Rows[0]["SubCentreName"].ToString();
            lblcentre.Text = dt.Rows[0]["CENTRE_NAME"].ToString();
            lblempname.Text = dt.Rows[0]["Emp_name"].ToString();////////////
            hdnCluster.Value = dt.Rows[0]["Cluster_Name"].ToString();/////////////
            hdnEmpCodeScrap.Value = dt.Rows[0]["emp_code"].ToString();/////////added by prachi
            if (hdnScrapStats.Value == "ScrapPage")//////////////
            {
                pnlScrap.Visible = false;
                pnlTransfer.Visible = false;
                Panel1.Visible = false;
            }
            else
            {
                pnlScrap.Visible = false;
                pnlTransfer.Visible = false;
                Panel1.Visible = true;
                ddlscrpatrnsfr.Visible = false;
                btnsave.Visible = true;
            }
        }
        else
        {
            lblsubcentre.Text = "";
            lblcentre.Text = "";
            lblempname.Text = "";
        }

    }
    private void Get_DescriptionData2()
    {


        CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Get_SubDescriptionData12_cpu1203";//"Get_SubDescriptionData12_cpu";//"Get_SubDescriptionData12";//"Get_DescriptionData12";
        sqlcmd.CommandTimeout = 0;

        if (hdnTranRefNo.Value != "")
        {
            SqlParameter TransRefNo = new SqlParameter();
            TransRefNo.SqlDbType = SqlDbType.VarChar;
            TransRefNo.Value = hdnTranRefNo.Value;//hdnTranRefNo.Value;
            TransRefNo.ParameterName = "@TransRefNo";
            sqlcmd.Parameters.Add(TransRefNo);
        }
        else
        {
            return;
        }


        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;
        DataSet dt = new DataSet();
        sqlda.Fill(dt);
        sqlcon.Close();

        if (dt.Tables.Count > 0)
        {

            if (dt.Tables[0].Rows.Count > 0 || dt.Tables[1].Rows.Count > 0 || dt.Tables[2].Rows.Count > 0 || dt.Tables[3].Rows.Count > 0 || dt.Tables[4].Rows.Count > 0)
            {
                GetDetails(hdnTranRefNo.Value);
                Panel1.Visible = true;
                //Panel3.Visible = true;
                //lblempname.Text = dt.Tables[0].Rows[0]["Model Name"].ToString();
                //lblcentre.Text = dt.Tables[0].Rows[0]["Processor Name"].ToString();
                //lblsubcentre.Text = dt.Tables[0].Rows[0]["Processor Name"].ToString();

                if (dt.Tables[0].Rows.Count > 0)
                {
                    if (dt.Tables[0].Rows[0]["TransRefNo"].ToString() != "")
                    {
                        lbltransrefno.Text = dt.Tables[0].Rows[0]["TransRefNo"].ToString();

                    }
                    //moniter
                    lblmonitorSubTrans.Text = dt.Tables[0].Rows[0]["Sub Transref No"].ToString();
                    if (dt.Tables[0].Rows[0]["MONtype"].ToString() != "")
                    {
                        ddlscreentype.SelectedValue = dt.Tables[0].Rows[0]["MONtype"].ToString();
                    }
                    else
                    {
                        ddlscreentype.SelectedIndex = 0;
                    }
                    txtcompnamemonitor.Text = dt.Tables[0].Rows[0]["mncompname"].ToString();
                    txtmodelnamemonitor.Text = dt.Tables[0].Rows[0]["mnmodelname"].ToString();
                    txtmoncost.Text = dt.Tables[0].Rows[0]["costMN"].ToString();
                    // lblmnprstatus.Text = dt.Tables[0].Rows[0]["MNPRSTATUS"].ToString();
                }
                else
                {
                    lbltransrefno.Text = "";
                    lblmonitorSubTrans.Text = "";
                    ddlscreentype.SelectedIndex = 0;
                    txtcompnamemonitor.Text = "";
                    txtmodelnamemonitor.Text = "";
                    txtmoncost.Text = "";

                }
                //cpu
                if (dt.Tables[1].Rows.Count > 0)
                {
                    if (dt.Tables[1].Rows[0]["TransRefNo"].ToString() != "")
                    {
                        lbltransrefno.Text = dt.Tables[1].Rows[0]["TransRefNo"].ToString();

                    }

                    //cpu
                    lblSubTranscpu.Text = dt.Tables[1].Rows[0]["Sub Transref No"].ToString();
                    txtcompnamecpu.Text = dt.Tables[1].Rows[0]["cpucompname"].ToString();
                    txtmodelnamecpu.Text = dt.Tables[1].Rows[0]["cpumodelname"].ToString();
                    txtprocnamecpu.Text = dt.Tables[1].Rows[0]["Processor Name"].ToString();
                    txtprocessorcpu.Text = dt.Tables[1].Rows[0]["Processor"].ToString();
                    txtRam.Text = dt.Tables[1].Rows[0]["Ram"].ToString();
                    // txtharddisk.Text = dt.Tables[1].Rows[0]["hard Disc"].ToString();
                    txtmothernme.Text = dt.Tables[1].Rows[0]["Mother board Name"].ToString();
                    txtcostcpu.Text = dt.Tables[1].Rows[0]["costcpu"].ToString();
                    //  lblcpuprstatus.Text = dt.Tables[1].Rows[0]["CPUPRSTATUS"].ToString();
                }
                else
                {

                    lblSubTranscpu.Text = "";
                    txtcompnamecpu.Text = "";
                    txtmodelnamecpu.Text = "";
                    txtprocnamecpu.Text = "";
                    txtprocessorcpu.Text = "";
                    txtRam.Text = "";
                    txtharddisk.Text = "";
                    txtmothernme.Text = "";
                    txtcostcpu.Text = "";

                }
                if (dt.Tables[2].Rows.Count > 0)
                {
                    //keyboard
                    if (dt.Tables[2].Rows[0]["TransRefNo"].ToString() != "")
                    {
                        lbltransrefno.Text = dt.Tables[2].Rows[0]["TransRefNo"].ToString();

                    }
                    lblsubtranskb.Text = dt.Tables[2].Rows[0]["Sub Transref No"].ToString();
                    txtcompnamekb.Text = dt.Tables[2].Rows[0]["kbcompname"].ToString();
                    txtmodelnamekb.Text = dt.Tables[2].Rows[0]["kbmodelname"].ToString();
                    txtkbtype.Text = dt.Tables[2].Rows[0]["Kbtype"].ToString();
                    //lblkbprstatus.Text = dt.Tables[2].Rows[0]["KBPRSTATUS"].ToString();
                }
                else
                {

                    //keyboard
                    lblsubtranskb.Text = "";
                    txtcompnamekb.Text = "";
                    txtmodelnamekb.Text = "";
                    txtkbtype.Text = "";
                    lblkbprstatus.Text = "";
                }
                if (dt.Tables[3].Rows.Count > 0)
                {
                    if (dt.Tables[3].Rows[0]["TransRefNo"].ToString() != "")
                    {
                        lbltransrefno.Text = dt.Tables[3].Rows[0]["TransRefNo"].ToString();

                    }
                    //mouse
                    lblsubtransmouse.Text = dt.Tables[3].Rows[0]["Sub Transref No"].ToString();
                    txtcompnamemouse.Text = dt.Tables[3].Rows[0]["mscompname"].ToString();
                    txtmodelnamemouse.Text = dt.Tables[3].Rows[0]["msmodelname"].ToString();
                    txtmstype.Text = dt.Tables[3].Rows[0]["MStype"].ToString();
                    txtcostms.Text = dt.Tables[3].Rows[0]["costMS"].ToString();
                    //lblmsprstatus.Text = dt.Tables[3].Rows[0]["MSPRSTATUS"].ToString();

                }
                else
                {
                    lblsubtransmouse.Text = "";
                    txtcompnamemouse.Text = "";
                    txtmodelnamemouse.Text = "";
                    txtcostms.Text = "";

                }


                if (dt.Tables[4].Rows.Count > 0)
                {
                    if (dt.Tables[4].Rows[0]["TransRefNo"].ToString() != "")
                    {
                        lbltransrefno.Text = dt.Tables[4].Rows[0]["TransRefNo"].ToString();

                    }
                    //Hard Disc
                    lblSubTranshdd.Text = dt.Tables[4].Rows[0]["Sub Transref No"].ToString();
                    txtcompnamehdd.Text = dt.Tables[4].Rows[0]["hddcompname"].ToString();
                    txtmodelnamehdd.Text = dt.Tables[4].Rows[0]["hddmodelname"].ToString();
                    txtharddisk.Text = dt.Tables[4].Rows[0]["hdd"].ToString();
                    hddcost.Text = dt.Tables[4].Rows[0]["costhdd"].ToString();
                    hddtype.Text = dt.Tables[4].Rows[0]["HdType"].ToString();
                    // lblhddprstatus.Text = dt.Tables[4].Rows[0]["HDDPRSTATUS"].ToString();
                }
                else
                {
                    lblSubTranshdd.Text = "";
                    txtcompnamehdd.Text = "";
                    txtmodelnamehdd.Text = "";
                    txtharddisk.Text = "";
                    hddcost.Text = "";
                    hddtype.Text = "";
                }
            }
            Getassetdata();
            GetDetails(hdnTranRefNo.Value);
        }
        else
        {
            Lblmessage2.Text = "No Record Found...!";
            GetDetails(hdnTranRefNo.Value);
            //Panel3.Visible = false;
            Panel1.Visible = false;
            lblmonitorSubTrans.Text = "";
            ddlscreentype.SelectedIndex = 0;
            txtcompnamemonitor.Text = "";
            txtmodelnamemonitor.Text = "";
            lblSubTranscpu.Text = "";
            txtcompnamecpu.Text = "";
            txtmodelnamecpu.Text = "";
            txtprocnamecpu.Text = "";
            txtprocessorcpu.Text = "";
            txtRam.Text = "";
            txtharddisk.Text = "";
            txtmothernme.Text = "";

            //keyboard
            lblsubtranskb.Text = "";
            txtcompnamekb.Text = "";
            txtmodelnamekb.Text = "";
            lblsubtransmouse.Text = "";
            txtcompnamemouse.Text = "";
            txtmodelnamemouse.Text = "";
            lbltransrefno.Text = "";
            lblSubTranscpu.Text = "";
            //
            //  lblSubTranshdd.Text = "";
            txtcompnamehdd.Text = "";
            txtmodelnamehdd.Text = "";
            txtharddisk.Text = "";
            hddcost.Text = "";
            hddtype.Text = "";
            lblhddprstatus.Text = "";
            lblmsprstatus.Text = "";

            Getassetdata();
        }
    }
    public void Getassetdata()
    {


        CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Get_SubDescriptionData12_main1203";//"Get_SubDescriptionData12";//"Get_DescriptionData12";
        sqlcmd.CommandTimeout = 0;

        SqlParameter TransRefNo = new SqlParameter();
        TransRefNo.SqlDbType = SqlDbType.VarChar;
        TransRefNo.Value = hdnTranRefNo.Value;//hdnTranRefNo.Value;
        TransRefNo.ParameterName = "@TransRefNo";
        sqlcmd.Parameters.Add(TransRefNo);

        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;
        DataTable dt = new DataTable();
        sqlda.Fill(dt);
        sqlcon.Close();

        if (dt.Rows.Count > 0)
        {
            Panel1.Visible = true;
            lbltransrefno.Text = dt.Rows[0]["TransRefNo"].ToString();
            lblempname.Text = dt.Rows[0]["Emp_Name"].ToString();

        }
        else
        {
            Panel1.Visible = false;
            lbltransrefno.Text = "";
            lblempname.Text = "";
        }


    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        //checkvalidation();
        SaveRecord();

    }
    public void SaveRecord()
    {
        try
        {
            if (ddlcpustatus.SelectedIndex == 0 || ddlmonStatus.SelectedIndex == 0 || ddlsbmouse.SelectedIndex == 0 || ddlhddstatus.SelectedIndex == 0 || ddlkbstatus.SelectedIndex == 0)
            {
                Lblmessage2.Text = "Please select Status  First First...!";
                return;

            }
            else
            {
                Lblmessage2.Text = "";
            }


            if (ddlmonStatus.SelectedValue == "Replace" & txtreplacemntdatemon.Text == "")
            {
                Lblmessage2.Text = "Please select monitor replacement Date..!";
                return;

            }

            if (ddlcpustatus.SelectedValue == "Replace" & txtreplacemntdatecpu.Text == "")
            {
                Lblmessage2.Text = "Please select CPU replacement Date..!";
                return;

            }

            if (ddlhddstatus.SelectedValue == "Replace" & txtreplacemntharddiskm.Text == "")
            {
                Lblmessage2.Text = "Please select Harddisk replacement Date..!";
                return;
            }
            if (ddlkbstatus.SelectedValue == "Replace" & TextBox1.Text == "")
            {
                Lblmessage2.Text = "Please select keyboard replacement Date..!";
                return;
            }
            if (ddlsbmouse.SelectedValue == "Replace" & txtreplacementdatems.Text == "")
            {
                Lblmessage2.Text = "Please select Mouse replacement Date..!";
                return;
            }


            CCommon objConn = new CCommon();
            SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "SaveSubAssetDetails23_new11203";//"SaveSubAssetDetails23_new";//"SaveSubAssetDetails23";//"SaveSubAssetDetails2";//"SaveSubAssetDetails";//"Get_SubDescriptionData12";//"Get_DescriptionData12";
            sqlcmd.CommandTimeout = 0;

            SqlParameter TransRefNo = new SqlParameter();
            TransRefNo.SqlDbType = SqlDbType.VarChar;
            TransRefNo.Value = hdnTranRefNo.Value;//hdnTranRefNo.Value;
            TransRefNo.ParameterName = "@TransRefNo";
            sqlcmd.Parameters.Add(TransRefNo);

            //subtransmon
            if (lblmonitorSubTrans.Text.ToString() != "")
            {
                SqlParameter SubTransRefNoMon = new SqlParameter();
                SubTransRefNoMon.SqlDbType = SqlDbType.VarChar;
                SubTransRefNoMon.Value = lblmonitorSubTrans.Text.ToString();//hdnTranRefNo.Value;
                SubTransRefNoMon.ParameterName = "@SubTransRefNoMon";
                sqlcmd.Parameters.Add(SubTransRefNoMon);
            }
            else
            {
                SqlParameter SubTransRefNoMon = new SqlParameter();
                SubTransRefNoMon.SqlDbType = SqlDbType.VarChar;
                SubTransRefNoMon.Value = DBNull.Value;
                SubTransRefNoMon.ParameterName = "@SubTransRefNoMon";
                sqlcmd.Parameters.Add(SubTransRefNoMon);
            }
            //subtranscpu
            if (lblSubTranscpu.Text.ToString() != "")
            {
                SqlParameter SubTransRefNoCPU = new SqlParameter();
                SubTransRefNoCPU.SqlDbType = SqlDbType.VarChar;
                SubTransRefNoCPU.Value = lblSubTranscpu.Text.ToString();//hdnTranRefNo.Value;
                SubTransRefNoCPU.ParameterName = "@SubTransRefNoCPU";
                sqlcmd.Parameters.Add(SubTransRefNoCPU);
            }
            else
            {
                SqlParameter SubTransRefNoMon = new SqlParameter();
                SubTransRefNoMon.SqlDbType = SqlDbType.VarChar;
                SubTransRefNoMon.Value = DBNull.Value;
                SubTransRefNoMon.ParameterName = "@SubTransRefNoCPU";
                sqlcmd.Parameters.Add(SubTransRefNoMon);
            }
            //subtranskb
            if (lblsubtranskb.Text.ToString() != "")
            {
                SqlParameter SubTransRefNoKB = new SqlParameter();
                SubTransRefNoKB.SqlDbType = SqlDbType.VarChar;
                SubTransRefNoKB.Value = lblsubtranskb.Text.ToString();//hdnTranRefNo.Value;
                SubTransRefNoKB.ParameterName = "@SubTransRefNoKB";
                sqlcmd.Parameters.Add(SubTransRefNoKB);
            }
            else
            {
                SqlParameter SubTransRefNoMon = new SqlParameter();
                SubTransRefNoMon.SqlDbType = SqlDbType.VarChar;
                SubTransRefNoMon.Value = DBNull.Value;
                SubTransRefNoMon.ParameterName = "@SubTransRefNoKB";
                sqlcmd.Parameters.Add(SubTransRefNoMon);
            }

            //subtransms
            if (lblsubtransmouse.Text.ToString() != "")
            {
                SqlParameter SubTransRefNoMS = new SqlParameter();
                SubTransRefNoMS.SqlDbType = SqlDbType.VarChar;
                SubTransRefNoMS.Value = lblsubtransmouse.Text.ToString();//hdnTranRefNo.Value;
                SubTransRefNoMS.ParameterName = "@SubTransRefNoMS";
                sqlcmd.Parameters.Add(SubTransRefNoMS);
            }
            else
            {
                SqlParameter SubTransRefNoMon = new SqlParameter();
                SubTransRefNoMon.SqlDbType = SqlDbType.VarChar;
                SubTransRefNoMon.Value = DBNull.Value;
                SubTransRefNoMon.ParameterName = "@SubTransRefNoMS";
                sqlcmd.Parameters.Add(SubTransRefNoMon);
            }
            //subtranshdd
            if (lblSubTranshdd.Text.ToString() != "")
            {
                SqlParameter SubTransRefNohdd = new SqlParameter();
                SubTransRefNohdd.SqlDbType = SqlDbType.VarChar;
                SubTransRefNohdd.Value = lblSubTranshdd.Text.ToString();//hdnTranRefNo.Value;
                SubTransRefNohdd.ParameterName = "@SubTransRefNohdd";
                sqlcmd.Parameters.Add(SubTransRefNohdd);
            }

            else
            {
                SqlParameter SubTransRefNohdd = new SqlParameter();
                SubTransRefNohdd.SqlDbType = SqlDbType.VarChar;
                SubTransRefNohdd.Value = DBNull.Value;
                SubTransRefNohdd.ParameterName = "@SubTransRefNohdd";
                sqlcmd.Parameters.Add(SubTransRefNohdd);
            }

            //monitor
            SqlParameter compname = new SqlParameter();
            compname.SqlDbType = SqlDbType.VarChar;
            compname.Value = txtcompnamemonitor.Text.ToString();
            compname.ParameterName = "@mncompname";
            sqlcmd.Parameters.Add(compname);


            SqlParameter modelname = new SqlParameter();
            modelname.SqlDbType = SqlDbType.VarChar;
            modelname.Value = txtmodelnamemonitor.Text.ToString();
            modelname.ParameterName = "@mnmodelname";
            sqlcmd.Parameters.Add(modelname);

            SqlParameter MONtype = new SqlParameter();
            MONtype.SqlDbType = SqlDbType.VarChar;
            MONtype.Value = ddlscreentype.SelectedValue.ToString();
            MONtype.ParameterName = "@MONtype";
            sqlcmd.Parameters.Add(MONtype);

            SqlParameter costMN = new SqlParameter();
            costMN.SqlDbType = SqlDbType.VarChar;
            costMN.Value = txtmodelnamemonitor.Text.ToString();
            costMN.ParameterName = "@costMN";
            sqlcmd.Parameters.Add(costMN);

            //cpu
            SqlParameter compnamecpu = new SqlParameter();
            compnamecpu.SqlDbType = SqlDbType.VarChar;
            compnamecpu.Value = txtcompnamecpu.Text.ToString();
            compnamecpu.ParameterName = "@cpucompname";
            sqlcmd.Parameters.Add(compnamecpu);


            SqlParameter modelnamecpu = new SqlParameter();
            modelnamecpu.SqlDbType = SqlDbType.VarChar;
            modelnamecpu.Value = txtmodelnamecpu.Text.ToString();
            modelnamecpu.ParameterName = "@cpumodelname";
            sqlcmd.Parameters.Add(modelnamecpu);


            SqlParameter processorname = new SqlParameter();
            processorname.SqlDbType = SqlDbType.VarChar;
            processorname.Value = txtprocnamecpu.Text.ToString();
            processorname.ParameterName = "@processorname";
            sqlcmd.Parameters.Add(processorname);

            SqlParameter processor = new SqlParameter();
            processor.SqlDbType = SqlDbType.VarChar;
            processor.Value = txtprocessorcpu.Text.ToString();
            processor.ParameterName = "@processor";
            sqlcmd.Parameters.Add(processor);

            SqlParameter ram = new SqlParameter();
            ram.SqlDbType = SqlDbType.VarChar;
            ram.Value = txtRam.Text.ToString();
            ram.ParameterName = "@ram";
            sqlcmd.Parameters.Add(ram);

            //SqlParameter hdd = new SqlParameter();
            //hdd.SqlDbType = SqlDbType.VarChar;
            //hdd.Value = txtharddisk.Text.ToString();
            //hdd.ParameterName = "@hdd";
            //sqlcmd.Parameters.Add(hdd);

            SqlParameter motherboardmake = new SqlParameter();
            motherboardmake.SqlDbType = SqlDbType.VarChar;
            motherboardmake.Value = txtmothernme.Text.ToString();
            motherboardmake.ParameterName = "@motherboardmake";
            sqlcmd.Parameters.Add(motherboardmake);

            SqlParameter costcpu = new SqlParameter();
            costcpu.SqlDbType = SqlDbType.VarChar;
            costcpu.Value = txtcostcpu.Text.ToString();
            costcpu.ParameterName = "@costcpu";
            sqlcmd.Parameters.Add(costcpu);

            //kb
            SqlParameter compnamekb = new SqlParameter();
            compnamekb.SqlDbType = SqlDbType.VarChar;
            compnamekb.Value = txtcompnamekb.Text.ToString();
            compnamekb.ParameterName = "@kbcompname";
            sqlcmd.Parameters.Add(compnamekb);


            SqlParameter keyboard = new SqlParameter();
            keyboard.SqlDbType = SqlDbType.VarChar;
            keyboard.Value = txtmodelnamekb.Text.ToString();
            keyboard.ParameterName = "@kbmodelname";
            sqlcmd.Parameters.Add(keyboard);

            SqlParameter Kbtype = new SqlParameter();
            Kbtype.SqlDbType = SqlDbType.VarChar;
            Kbtype.Value = txtmodelnamekb.Text.ToString();
            Kbtype.ParameterName = "@Kbtype";
            sqlcmd.Parameters.Add(Kbtype);


            SqlParameter costKB = new SqlParameter();
            costKB.SqlDbType = SqlDbType.VarChar;
            costKB.Value = txtmodelnamekb.Text.ToString();
            costKB.ParameterName = "@costKB";
            sqlcmd.Parameters.Add(costKB);

            //ms
            SqlParameter compnamems = new SqlParameter();
            compnamems.SqlDbType = SqlDbType.VarChar;
            compnamems.Value = txtcompnamemouse.Text.ToString();
            compnamems.ParameterName = "@mscompname";
            sqlcmd.Parameters.Add(compnamems);

            SqlParameter mnmodelname = new SqlParameter();
            mnmodelname.SqlDbType = SqlDbType.VarChar;
            mnmodelname.Value = txtmodelnamemouse.Text.ToString();
            mnmodelname.ParameterName = "@msmodelname";
            sqlcmd.Parameters.Add(mnmodelname);

            SqlParameter costMS = new SqlParameter();
            costMS.SqlDbType = SqlDbType.VarChar;
            costMS.Value = txtcostms.Text.ToString();
            costMS.ParameterName = "@costMS";
            sqlcmd.Parameters.Add(costMS);


            SqlParameter MStype = new SqlParameter();
            MStype.SqlDbType = SqlDbType.VarChar;
            MStype.Value = txtmstype.Text.ToString();
            MStype.ParameterName = "@MStype";
            sqlcmd.Parameters.Add(MStype);

            //HDD

            SqlParameter hddcompname = new SqlParameter();
            hddcompname.SqlDbType = SqlDbType.VarChar;
            hddcompname.Value = txtcompnamehdd.Text.ToString();
            hddcompname.ParameterName = "@hddcompname";
            sqlcmd.Parameters.Add(hddcompname);

            SqlParameter hddmodelname = new SqlParameter();
            hddmodelname.SqlDbType = SqlDbType.VarChar;
            hddmodelname.Value = txtmodelnamehdd.Text.ToString();
            hddmodelname.ParameterName = "@hddmodelname";
            sqlcmd.Parameters.Add(hddmodelname);

            SqlParameter HdType = new SqlParameter();
            HdType.SqlDbType = SqlDbType.VarChar;
            HdType.Value = hddtype.Text.ToString();
            HdType.ParameterName = "@HdType";
            sqlcmd.Parameters.Add(HdType);

            SqlParameter hdd = new SqlParameter();
            hdd.SqlDbType = SqlDbType.VarChar;
            hdd.Value = txtharddisk.Text.ToString();
            hdd.ParameterName = "@hdd";
            sqlcmd.Parameters.Add(hdd);

            SqlParameter costhdd = new SqlParameter();
            costhdd.SqlDbType = SqlDbType.VarChar;
            costhdd.Value = hddcost.Text.ToString();
            costhdd.ParameterName = "@costhdd";
            sqlcmd.Parameters.Add(costhdd);


            SqlParameter Cluster = new SqlParameter();
            Cluster.SqlDbType = SqlDbType.VarChar;
            Cluster.Value = hdnCluster.Value;//"Scrap".ToString();
            Cluster.ParameterName = "@Cluster";
            sqlcmd.Parameters.Add(Cluster);


            ////////added by prachi/////////

            SqlParameter EmpName = new SqlParameter();
            EmpName.SqlDbType = SqlDbType.VarChar;
            EmpName.Value = lblempname.Text.ToString();
            EmpName.ParameterName = "@EmpName";
            sqlcmd.Parameters.Add(EmpName);

            SqlParameter Centre = new SqlParameter();
            Centre.SqlDbType = SqlDbType.VarChar;
            Centre.Value = lblcentre.Text.ToString();
            Centre.ParameterName = "@Centre";
            sqlcmd.Parameters.Add(Centre);

            SqlParameter SubCentre = new SqlParameter();
            SubCentre.SqlDbType = SqlDbType.VarChar;
            SubCentre.Value = lblsubcentre.Text.ToString();
            SubCentre.ParameterName = "@SubCentre";
            sqlcmd.Parameters.Add(SubCentre);

            SqlParameter EmpCode = new SqlParameter();
            EmpCode.SqlDbType = SqlDbType.VarChar;
            EmpCode.Value = hdnEmpCodeScrap.Value;
            EmpCode.ParameterName = "@EmpCode";
            sqlcmd.Parameters.Add(EmpCode);


            SqlParameter Replacementdatemon = new SqlParameter();
            Replacementdatemon.SqlDbType = SqlDbType.VarChar;
            Replacementdatemon.Value = txtreplacemntdatemon.Text.ToString();
            Replacementdatemon.ParameterName = "@Replacementdatemon";
            sqlcmd.Parameters.Add(Replacementdatemon);

            SqlParameter txtreplacementkb = new SqlParameter();
            txtreplacementkb.SqlDbType = SqlDbType.VarChar;
            txtreplacementkb.Value = TextBox1.Text.ToString();
            txtreplacementkb.ParameterName = "@Replacementdatekb";
            sqlcmd.Parameters.Add(txtreplacementkb);

            SqlParameter Replacementdatems = new SqlParameter();
            Replacementdatems.SqlDbType = SqlDbType.VarChar;
            Replacementdatems.Value = txtreplacementdatems.Text.ToString();
            Replacementdatems.ParameterName = "@Replacementdatems";
            sqlcmd.Parameters.Add(Replacementdatems);

            SqlParameter Replacementdatecpu = new SqlParameter();
            Replacementdatecpu.SqlDbType = SqlDbType.VarChar;
            Replacementdatecpu.Value = txtreplacemntdatecpu.Text.ToString();
            Replacementdatecpu.ParameterName = "@Replacementdatecpu";
            sqlcmd.Parameters.Add(Replacementdatecpu);

            SqlParameter txtreplacemntharddisk = new SqlParameter();
            txtreplacemntharddisk.SqlDbType = SqlDbType.VarChar;
            txtreplacemntharddisk.Value = txtreplacemntharddiskm.Text.ToString();
            txtreplacemntharddisk.ParameterName = "@txtreplacemntharddisk";
            sqlcmd.Parameters.Add(txtreplacemntharddisk);




            int i = sqlcmd.ExecuteNonQuery();

            if (i > 0)
            {
                Lblmessage2.Text = "Details Saved successfully...!";

                Get_DescriptionData2();
            }
            else
            {
                Get_DescriptionData2();
                Lblmessage2.Text = "Details Not Saved successfully...!";

            }
        }
        catch (Exception ex)
        {
            Lblmessage2.Text = "Error :" + ex.Message;
        }

    }
    public void scrapSoldRecord()
    {
        try
        {
            CCommon objConn = new CCommon();
            SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "SUb_AssetsInventoryDataScrap11203";//"SUb_AssetsInventoryDataScrap1";//SUb_AssetsInventoryDataScrap
            sqlcmd.CommandTimeout = 0;

            if (lbltransrefno.Text.ToString() != "")
            {
                SqlParameter TransRefNo = new SqlParameter();
                TransRefNo.SqlDbType = SqlDbType.VarChar;
                TransRefNo.Value = hdnTranRefNo.Value;
                TransRefNo.ParameterName = "@TransRefNo";
                sqlcmd.Parameters.Add(TransRefNo);
            }
            else
            {
                Lblmessage2.Text = "Please select Transrefno";
                return;
            }


            string subtrans = "";
            hddtrans = "";
            if (ddlmonStatus.SelectedItem.Text != "Available" && ddlmonStatus.SelectedIndex != 0)
            {
                subtrans = lblmonitorSubTrans.Text.ToString();
            }
            else if (ddlcpustatus.SelectedItem.Text != "Available" && ddlcpustatus.SelectedIndex != 0)
            {
                subtrans = lblSubTranscpu.Text.ToString();
                hddtrans = lblSubTranshdd.Text.ToString();
            }
            else if (ddlkbstatus.SelectedItem.Text != "Available" && ddlkbstatus.SelectedIndex != 0)
            {
                subtrans = lblsubtranskb.Text.ToString();
            }
            else if (ddlsbmouse.SelectedItem.Text != "Available" && ddlsbmouse.SelectedIndex != 0)
            {
                subtrans = lblsubtransmouse.Text.ToString();
            }
            else if (ddlhddstatus.SelectedItem.Text != "Available" && ddlhddstatus.SelectedIndex != 0)
            {
                subtrans = lblSubTranshdd.Text.ToString();
            }



            if (hddtrans != "")
            {
                scrapSoldRecordhdd();
            }

            if (lbltransrefno.Text.ToString() != "")
            {
                SqlParameter Subtransrefno = new SqlParameter();
                Subtransrefno.SqlDbType = SqlDbType.VarChar;
                Subtransrefno.Value = subtrans.ToString();
                Subtransrefno.ParameterName = "@Subtransrefno";
                sqlcmd.Parameters.Add(Subtransrefno);
            }
            else
            {
                Lblmessage2.Text = "Please select Sub Transrefno";
                return;
            }



            SqlParameter SSRAprovBy = new SqlParameter();
            SSRAprovBy.SqlDbType = SqlDbType.VarChar;
            SSRAprovBy.Value = txtscrapby.Text.ToString();
            SSRAprovBy.ParameterName = "@ssrApprovedby";
            sqlcmd.Parameters.Add(SSRAprovBy);

            SqlParameter ssrApproveddate = new SqlParameter();
            ssrApproveddate.SqlDbType = SqlDbType.VarChar;
            ssrApproveddate.Value = txtscrapdate.Text.ToString();
            ssrApproveddate.ParameterName = "@ssrApproveddate";
            sqlcmd.Parameters.Add(ssrApproveddate);

            SqlParameter AmtRec = new SqlParameter();
            AmtRec.SqlDbType = SqlDbType.VarChar;
            AmtRec.Value = txtamt.Text.ToString();
            AmtRec.ParameterName = "@AmtRec";
            sqlcmd.Parameters.Add(AmtRec);

            SqlParameter vendorName = new SqlParameter();
            vendorName.SqlDbType = SqlDbType.VarChar;
            vendorName.Value = txtVendorName.Text.ToString();
            vendorName.ParameterName = "@vendorname";
            sqlcmd.Parameters.Add(vendorName);

            SqlParameter Approveddate = new SqlParameter();
            Approveddate.SqlDbType = SqlDbType.VarChar;
            Approveddate.Value = txtDateApprvl.Text.ToString();
            Approveddate.ParameterName = "@Approveddate";
            sqlcmd.Parameters.Add(Approveddate);

            SqlParameter TransferStatus = new SqlParameter();
            TransferStatus.SqlDbType = SqlDbType.VarChar;
            TransferStatus.Value = HdnTransStatus.Value;//"Scrap".ToString();
            TransferStatus.ParameterName = "@TransferStatus";
            sqlcmd.Parameters.Add(TransferStatus);


            int i = sqlcmd.ExecuteNonQuery();

            if (i > 0)
            {
                Lblmessage2.Text = "data Saved Successfully...";


            }
            Get_DescriptionData2();
        }
        catch (Exception ex)
        {

            Lblmessage2.Text = "Error:" + ex.Message;
        }

    }
    public void scrapSoldRecord1()/////for subasset transfer
    {
        try
        {
            CCommon objConn = new CCommon();
            SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            sqlcon.Open();


            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "SUb_AssetsInventoryDataScrapComplete1203";//Insert_AssetsInventoryDataScrapBarcode
            sqlcmd.CommandTimeout = 0;

            if (lbltransrefno.Text.ToString() != "")
            {
                SqlParameter TransRefNo = new SqlParameter();
                TransRefNo.SqlDbType = SqlDbType.VarChar;
                TransRefNo.Value = hdnTranRefNo.Value;
                TransRefNo.ParameterName = "@TransRefNo";
                sqlcmd.Parameters.Add(TransRefNo);
            }
            else
            {
                Lblmessage2.Text = "Please select Transrefno";
                return;
            }



            SqlParameter SSRAprovBy = new SqlParameter();
            SSRAprovBy.SqlDbType = SqlDbType.VarChar;
            SSRAprovBy.Value = txtscrapby.Text.ToString();
            SSRAprovBy.ParameterName = "@ssrApprovedby";
            sqlcmd.Parameters.Add(SSRAprovBy);


            SqlParameter ssrApproveddate = new SqlParameter();
            ssrApproveddate.SqlDbType = SqlDbType.VarChar;
            ssrApproveddate.Value = txtscrapdate.Text.ToString();
            ssrApproveddate.ParameterName = "@ssrApproveddate";
            sqlcmd.Parameters.Add(ssrApproveddate);

            SqlParameter vendorName = new SqlParameter();
            vendorName.SqlDbType = SqlDbType.VarChar;
            vendorName.Value = txtVendorName.Text.ToString();
            vendorName.ParameterName = "@vendorname";
            sqlcmd.Parameters.Add(vendorName);

            SqlParameter Approveddate = new SqlParameter();
            Approveddate.SqlDbType = SqlDbType.VarChar;
            Approveddate.Value = txtDateApprvl.Text.ToString();
            Approveddate.ParameterName = "@Approveddate";
            sqlcmd.Parameters.Add(Approveddate);

            SqlParameter AmtRec = new SqlParameter();
            AmtRec.SqlDbType = SqlDbType.VarChar;
            AmtRec.Value = txtamt.Text.ToString();
            AmtRec.ParameterName = "@AmtRec";
            sqlcmd.Parameters.Add(AmtRec);

            SqlParameter TransferStatus = new SqlParameter();
            TransferStatus.SqlDbType = SqlDbType.VarChar;
            TransferStatus.Value = "Scrap";//"Scrap".ToString();
            TransferStatus.ParameterName = "@TransferStatus";
            sqlcmd.Parameters.Add(TransferStatus);

            if (ddlscrpatrnsfr.SelectedValue == "Complete")
            {
                SqlParameter ScrpTransferStatus = new SqlParameter();
                ScrpTransferStatus.SqlDbType = SqlDbType.VarChar;
                ScrpTransferStatus.Value = "COM";
                ScrpTransferStatus.ParameterName = "@ScrpTransferStatus";
                sqlcmd.Parameters.Add(ScrpTransferStatus);

            }
            else
            {
                SqlParameter ScrpTransferStatus = new SqlParameter();
                ScrpTransferStatus.SqlDbType = SqlDbType.VarChar;
                ScrpTransferStatus.Value = DBNull.Value;
                ScrpTransferStatus.ParameterName = "@ScrpTransferStatus";
                sqlcmd.Parameters.Add(ScrpTransferStatus);

            }

            int i = sqlcmd.ExecuteNonQuery();

            if (i > 0)
            {
                Lblmessage2.Text = "data Saved Successfully...";
                scrapSoldRecord_maainasset();


            }
            else
            {

                scrapSoldRecord_maainasset();
            }
            Get_DescriptionData2();
        }
        catch (Exception ex)
        {

            Lblmessage2.Text = "Error:" + ex.Message;
        }


    }
    //scraphdd
    public void scrapSoldRecordhdd()
    {
        try
        {
            CCommon objConn = new CCommon();
            SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "SUb_AssetsInventoryDataScrap11203";//"SUb_AssetsInventoryDataScrap1";//SUb_AssetsInventoryDataScrap
            sqlcmd.CommandTimeout = 0;

            if (lbltransrefno.Text.ToString() != "")
            {
                SqlParameter TransRefNo = new SqlParameter();
                TransRefNo.SqlDbType = SqlDbType.VarChar;
                TransRefNo.Value = hdnTranRefNo.Value;
                TransRefNo.ParameterName = "@TransRefNo";
                sqlcmd.Parameters.Add(TransRefNo);
            }
            else
            {
                Lblmessage2.Text = "Please select Transrefno";
                return;
            }

            if (lbltransrefno.Text.ToString() != "")
            {
                SqlParameter Subtransrefno = new SqlParameter();
                Subtransrefno.SqlDbType = SqlDbType.VarChar;
                Subtransrefno.Value = hddtrans;
                Subtransrefno.ParameterName = "@Subtransrefno";
                sqlcmd.Parameters.Add(Subtransrefno);
            }
            else
            {
                Lblmessage2.Text = "Please select Sub Transrefno";
                return;
            }


            SqlParameter SSRAprovBy = new SqlParameter();
            SSRAprovBy.SqlDbType = SqlDbType.VarChar;
            SSRAprovBy.Value = txtscrapby.Text.ToString();
            SSRAprovBy.ParameterName = "@ssrApprovedby";
            sqlcmd.Parameters.Add(SSRAprovBy);

            SqlParameter ssrApproveddate = new SqlParameter();
            ssrApproveddate.SqlDbType = SqlDbType.VarChar;
            ssrApproveddate.Value = txtscrapdate.Text.ToString();
            ssrApproveddate.ParameterName = "@ssrApproveddate";
            sqlcmd.Parameters.Add(ssrApproveddate);

            SqlParameter AmtRec = new SqlParameter();
            AmtRec.SqlDbType = SqlDbType.VarChar;
            AmtRec.Value = txtamt.Text.ToString();
            AmtRec.ParameterName = "@AmtRec";
            sqlcmd.Parameters.Add(AmtRec);

            SqlParameter vendorName = new SqlParameter();
            vendorName.SqlDbType = SqlDbType.VarChar;
            vendorName.Value = txtVendorName.Text.ToString();
            vendorName.ParameterName = "@vendorname";
            sqlcmd.Parameters.Add(vendorName);

            SqlParameter Approveddate = new SqlParameter();
            Approveddate.SqlDbType = SqlDbType.VarChar;
            Approveddate.Value = txtDateApprvl.Text.ToString();
            Approveddate.ParameterName = "@Approveddate";
            sqlcmd.Parameters.Add(Approveddate);

            SqlParameter TransferStatus = new SqlParameter();
            TransferStatus.SqlDbType = SqlDbType.VarChar;
            TransferStatus.Value = HdnTransStatus.Value;//"Scrap".ToString();
            TransferStatus.ParameterName = "@TransferStatus";
            sqlcmd.Parameters.Add(TransferStatus);


            int i = sqlcmd.ExecuteNonQuery();

            if (i > 0)
            {
                Lblmessage2.Text = "data Saved Successfully...";


            }

        }
        catch (Exception ex)
        {

            Lblmessage2.Text = "Error:" + ex.Message;
        }


    }
    public void scrapSoldRecord_maainasset()/////for main transfer
    {
        try
        {
            CCommon objConn = new CCommon();
            SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Insert_AssetsInventoryDataScrapBarcode1203";//Insert_AssetsInventoryDataScrapBarcode
            sqlcmd.CommandTimeout = 0;

            if (lbltransrefno.Text.ToString() != "")
            {
                SqlParameter TransRefNo = new SqlParameter();
                TransRefNo.SqlDbType = SqlDbType.VarChar;
                TransRefNo.Value = hdnTranRefNo.Value;
                TransRefNo.ParameterName = "@TransRefNo";
                sqlcmd.Parameters.Add(TransRefNo);
            }
            else
            {
                Lblmessage2.Text = "Please select Transrefno";
                return;
            }

            //string subtrans = "";
            //if (ddlmonStatus.SelectedItem.Text != "Available")
            //{
            //    subtrans = lblmonitorSubTrans.Text.ToString();
            //}
            //else if (ddlcpustatus.SelectedItem.Text != "Available")
            //{
            //    subtrans = lblSubTranscpu.Text.ToString();
            //}
            //else if (ddlkbstatus.SelectedItem.Text != "Available")
            //{
            //    subtrans = lblsubtranskb.Text.ToString();
            //}
            //else if (ddlsbmouse.SelectedItem.Text != "Available")
            //{
            //    subtrans = lblsubtransmouse.Text.ToString();
            //}


            //if (lbltransrefno.Text.ToString() != "")
            //{
            //    SqlParameter Subtransrefno = new SqlParameter();
            //    Subtransrefno.SqlDbType = SqlDbType.VarChar;
            //    Subtransrefno.Value = subtrans.ToString();
            //    Subtransrefno.ParameterName = "@Subtransrefno";
            //    sqlcmd.Parameters.Add(Subtransrefno);
            //}
            //else
            //{
            //    Lblmessage2.Text = "Please select Sub Transrefno";
            //    return;
            //}

            SqlParameter SSRAprovBy = new SqlParameter();
            SSRAprovBy.SqlDbType = SqlDbType.VarChar;
            SSRAprovBy.Value = txtscrapby.Text.ToString();
            SSRAprovBy.ParameterName = "@ssrApprovedby";
            sqlcmd.Parameters.Add(SSRAprovBy);

            SqlParameter ssrApproveddate = new SqlParameter();
            ssrApproveddate.SqlDbType = SqlDbType.VarChar;
            ssrApproveddate.Value = txtscrapdate.Text.ToString();
            ssrApproveddate.ParameterName = "@ssrApproveddate";
            sqlcmd.Parameters.Add(ssrApproveddate);

            SqlParameter AmtRec = new SqlParameter();
            AmtRec.SqlDbType = SqlDbType.VarChar;
            AmtRec.Value = txtamt.Text.ToString();
            AmtRec.ParameterName = "@AmtRec";
            sqlcmd.Parameters.Add(AmtRec);

            SqlParameter vendorName = new SqlParameter();
            vendorName.SqlDbType = SqlDbType.VarChar;
            vendorName.Value = txtVendorName.Text.ToString();
            vendorName.ParameterName = "@vendorname";
            sqlcmd.Parameters.Add(vendorName);

            SqlParameter Approveddate = new SqlParameter();
            Approveddate.SqlDbType = SqlDbType.VarChar;
            Approveddate.Value = txtDateApprvl.Text.ToString();
            Approveddate.ParameterName = "@Approveddate";
            sqlcmd.Parameters.Add(Approveddate);

            SqlParameter TransferStatus = new SqlParameter();
            TransferStatus.SqlDbType = SqlDbType.VarChar;
            TransferStatus.Value = "Scrap";//"Scrap".ToString();
            TransferStatus.ParameterName = "@TransferStatus";
            sqlcmd.Parameters.Add(TransferStatus);

            if (ddlscrpatrnsfr.SelectedValue == "Complete")
            {
                SqlParameter ScrpTransferStatus = new SqlParameter();
                ScrpTransferStatus.SqlDbType = SqlDbType.VarChar;
                ScrpTransferStatus.Value = "COM";
                ScrpTransferStatus.ParameterName = "@ScrpTransferStatus";
                sqlcmd.Parameters.Add(ScrpTransferStatus);

            }
            else
            {
                SqlParameter ScrpTransferStatus = new SqlParameter();
                ScrpTransferStatus.SqlDbType = SqlDbType.VarChar;
                ScrpTransferStatus.Value = DBNull.Value;
                ScrpTransferStatus.ParameterName = "@ScrpTransferStatus";
                sqlcmd.Parameters.Add(ScrpTransferStatus);

            }


            int i = sqlcmd.ExecuteNonQuery();

            if (i > 0)
            {
                Lblmessage2.Text = "data Saved Successfully...";

            }

        }
        catch (Exception ex)
        {

            Lblmessage2.Text = "Error:" + ex.Message;
        }


    }
    protected void ddlmonStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        if ((ddlmonStatus.SelectedValue == "Sold") || (ddlmonStatus.SelectedValue == "Scrap") || (ddlmonStatus.SelectedValue == "Returned  to Vendor"))
        {
            pnlScrap.Visible = true;
            pnlTransfer.Visible = false;
            HdnTransStatus.Value = ddlmonStatus.SelectedValue.ToString();
            btntransfer.Visible = false;
            btnsave.Visible = false;
            Button1.Visible = true;
        }
        else if ((ddlmonStatus.SelectedValue == "Transferred to Other Branch") || (ddlmonStatus.SelectedValue == "Transferred to other PAMACian"))
        {
            pnlScrap.Visible = false;
            pnlTransfer.Visible = true;
            HdnTransStatus.Value = ddlmonStatus.SelectedValue.ToString();
            btntransfer.Visible = true;

            txtdateofTrasfer.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
        }
        else
        {
            pnlScrap.Visible = false;
            pnlTransfer.Visible = false;
            btnsave.Visible = true;
        }
    }
    protected void ddlcpustatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        if ((ddlcpustatus.SelectedValue == "Sold") || (ddlcpustatus.SelectedValue == "Scrap") || (ddlcpustatus.SelectedValue == "Returned  to Vendor"))
        {
            pnlScrap.Visible = true;
            pnlTransfer.Visible = false;
            HdnTransStatus.Value = ddlcpustatus.SelectedValue.ToString();
        }
        else if ((ddlcpustatus.SelectedValue == "Transferred to Other Branch") || (ddlcpustatus.SelectedValue == "Transferred to other PAMACian"))
        {
            pnlScrap.Visible = false;
            pnlTransfer.Visible = true;
            HdnTransStatus.Value = ddlcpustatus.SelectedValue.ToString();
            txtdateofTrasfer.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
        }
        else
        {
            pnlScrap.Visible = false;
            pnlTransfer.Visible = false;
        }
    }
    protected void ddlkbstatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        if ((ddlkbstatus.SelectedValue == "Sold") || (ddlkbstatus.SelectedValue == "Scrap") || (ddlkbstatus.SelectedValue == "Returned  to Vendor"))
        {
            pnlScrap.Visible = true;
            pnlTransfer.Visible = false;
            HdnTransStatus.Value = ddlkbstatus.SelectedValue.ToString();
        }
        else if ((ddlkbstatus.SelectedValue == "Transferred to Other Branch") || (ddlkbstatus.SelectedValue == "Transferred to other PAMACian"))
        {
            pnlScrap.Visible = false;
            pnlTransfer.Visible = true;
            HdnTransStatus.Value = ddlkbstatus.SelectedValue.ToString();
            txtdateofTrasfer.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
        }
        else
        {
            pnlScrap.Visible = false;
            pnlTransfer.Visible = false;
        }
    }
    protected void ddlsbmouse_SelectedIndexChanged(object sender, EventArgs e)
    {
        if ((ddlsbmouse.SelectedValue == "Sold") || (ddlsbmouse.SelectedValue == "Scrap") || (ddlsbmouse.SelectedValue == "Returned  to Vendor"))
        {
            pnlScrap.Visible = true;
            pnlTransfer.Visible = false;
            HdnTransStatus.Value = ddlsbmouse.SelectedValue.ToString();
        }
        else if ((ddlsbmouse.SelectedValue == "Transferred to Other Branch") || (ddlsbmouse.SelectedValue == "Transferred to other PAMACian"))
        {
            pnlScrap.Visible = false;
            pnlTransfer.Visible = true;
            HdnTransStatus.Value = ddlsbmouse.SelectedValue.ToString();
            txtdateofTrasfer.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
        }
        else
        {
            pnlScrap.Visible = false;
            pnlTransfer.Visible = false;
        }
    }
    protected void btntransfer_Click(object sender, EventArgs e)
    {
        TransferRecord();
    }
    protected void ddlclustername_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetCentreList();
        //Get_Empname();
    }
    protected void ddlCenterList_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetSubCentreName();


    }
    protected void ddlsubcentrename_SelectedIndexChanged(object sender, EventArgs e)
    {
        Get_Empname();

    }
    protected void ddlpamaciantransfer_SelectedIndexChanged(object sender, EventArgs e)
    {
        CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Get_EmpDetails2";
        sqlcmd.CommandTimeout = 0;

        SqlParameter Emp_id = new SqlParameter();
        Emp_id.SqlDbType = SqlDbType.VarChar;
        Emp_id.Value = ddlpamaciantransfer.SelectedValue.ToString();
        Emp_id.ParameterName = "@Emp_id";
        sqlcmd.Parameters.Add(Emp_id);

        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;

        DataTable dt = new DataTable();
        sqlda.Fill(dt);

        sqlcon.Close();

        if (dt.Rows.Count > 0)
        {
            HdnTrsEMPCODE.Value = dt.Rows[0]["Emp_code"].ToString();
            HdnTransEmpName.Value = dt.Rows[0]["Fullname"].ToString();

        }
    }
    private void GetCentreList()
    {
        CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);


        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Get_CentreName1";//"Get_CentreName";
        sqlcmd.CommandTimeout = 0;

        SqlParameter ClusterID = new SqlParameter();
        ClusterID.SqlDbType = SqlDbType.VarChar;
        ClusterID.Value = ddlclustername.SelectedValue.ToString();
        ClusterID.ParameterName = "@ClusterID";
        sqlcmd.Parameters.Add(ClusterID);

        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;


        sqlcon.Open();

        DataTable dt = new DataTable();
        sqlda.Fill(dt);

        sqlcon.Close();

        if (dt.Rows.Count > 0)
        {
            ddlCenterList.DataTextField = "Centre_name";
            ddlCenterList.DataValueField = "centre_id";

            ddlCenterList.DataSource = dt;
            ddlCenterList.DataBind();

            ddlCenterList.Items.Insert(0, new ListItem("--Select--", "0"));
        }

    }
    private void GetSubCentreList()
    {
        CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.Text;
        sqlcmd.CommandText = "Select SubCentreName,SubCentreId from SubCentreMaster where CentreId=" + Session["CentreId"].ToString() + " order by SubCentreName";
        //sqlcmd.CommandText = "Get_SubCentername";
        sqlcmd.CommandTimeout = 0;


        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;

        DataTable dt = new DataTable();
        sqlda.Fill(dt);

        sqlcon.Close();

        if (dt.Rows.Count > 0)
        {
            //ddlSubCentre.DataTextField = "SubCentreName";
            //ddlSubCentre.DataValueField = "SubCentreId";

            //ddlSubCentre.DataSource = dt;
            //ddlSubCentre.DataBind();

            //ddlSubCentre.Items.Insert(0, new ListItem("--All--", "0"));
        }

    }
    private void GetSubCentreName()
    {
        CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);


        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Get_SubCenternameReports2";//"Get_SubCenternameReports";
        sqlcmd.CommandTimeout = 0;

        SqlParameter Clusterid = new SqlParameter();
        Clusterid.SqlDbType = SqlDbType.VarChar;
        Clusterid.Value = ddlclustername.SelectedValue.ToString();
        Clusterid.ParameterName = "@Clusterid";
        sqlcmd.Parameters.Add(Clusterid);

        SqlParameter CentreId = new SqlParameter();
        CentreId.SqlDbType = SqlDbType.VarChar;
        CentreId.Value = ddlCenterList.SelectedValue.ToString();
        CentreId.ParameterName = "@Centreid";
        sqlcmd.Parameters.Add(CentreId);

        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;

        sqlcon.Open();

        DataTable dt = new DataTable();
        sqlda.Fill(dt);

        sqlcon.Close();

        if (dt.Rows.Count > 0)
        {
            ddlsubcentrename.DataTextField = "SubCentreName";
            ddlsubcentrename.DataValueField = "SubCentreId";

            ddlsubcentrename.DataSource = dt;
            ddlsubcentrename.DataBind();

            ddlsubcentrename.Items.Insert(0, new ListItem("--Select--", "0"));
        }

    }
    private void Get_Empname()
    {
        CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Get_Empname";
        sqlcmd.CommandTimeout = 0;

        SqlParameter Centre_id = new SqlParameter();
        Centre_id.SqlDbType = SqlDbType.VarChar;
        Centre_id.Value = ddlCenterList.SelectedValue.ToString();
        Centre_id.ParameterName = "@Centre_id";
        sqlcmd.Parameters.Add(Centre_id);

        SqlParameter Subcentre_id = new SqlParameter();
        Subcentre_id.SqlDbType = SqlDbType.VarChar;
        Subcentre_id.Value = ddlsubcentrename.SelectedValue.ToString();
        Subcentre_id.ParameterName = "@Subcentre_id";
        sqlcmd.Parameters.Add(Subcentre_id);


        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;
        DataTable dt = new DataTable();
        sqlda.Fill(dt);
        sqlcon.Close();

        if (dt.Rows.Count > 0)
        {
            ddlpamaciantransfer.DataTextField = "fullname";
            ddlpamaciantransfer.DataValueField = "Emp_id";


            ddlpamaciantransfer.DataSource = dt;
            ddlpamaciantransfer.DataBind();
            ddlpamaciantransfer.SelectedIndex = 0;

        }
        else
        {
            ddlpamaciantransfer.DataSource = null;
            ddlpamaciantransfer.DataBind();
        }


    }
    private void Get_ClusterList()
    {
        CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Get_ClusterMaster";
        sqlcmd.CommandTimeout = 0;

        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;

        DataTable dt = new DataTable();
        sqlda.Fill(dt);

        sqlcon.Close();

        if (dt.Rows.Count > 0)
        {
            ddlclustername.DataTextField = "CLUSTER_NAME";
            ddlclustername.DataValueField = "CLUSTER_ID";

            ddlclustername.DataSource = dt;
            ddlclustername.DataBind();

            ddlclustername.Items.Insert(0, new ListItem("--Select--", "0"));
        }
    }
    protected void Btnserachemp_Click(object sender, EventArgs e)
    {
        Get_EmpnameNew();
    }
    private void Get_EmpnameNew()
    {
        CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Get_EmpnameNew";
        sqlcmd.CommandTimeout = 0;


        SqlParameter emp_code = new SqlParameter();
        emp_code.SqlDbType = SqlDbType.VarChar;
        emp_code.Value = txtsearch2.Text.Trim();
        emp_code.ParameterName = "@emp_code";
        sqlcmd.Parameters.Add(emp_code);


        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;
        DataTable dt = new DataTable();
        sqlda.Fill(dt);
        sqlcon.Close();

        if (dt.Rows.Count > 0)
        {
            ddlpamaciantransfer.DataTextField = "fullname";
            ddlpamaciantransfer.DataValueField = "Emp_id";


            ddlpamaciantransfer.DataSource = dt;
            ddlpamaciantransfer.DataBind();
            ddlpamaciantransfer.SelectedIndex = 0;
        }
        else
        {
            ddlpamaciantransfer.DataSource = null;
            ddlpamaciantransfer.DataBind();
        }


    }
    public void TransferRecord()
    {
        try
        {
            CCommon objConn = new CCommon();
            SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "SUb_AssetsInventoryDataTransfer11203";//SUb_AssetsInventoryDataTransfer
            sqlcmd.CommandTimeout = 0;


            if (lbltransrefno.Text.ToString() != "")
            {
                SqlParameter TransRefNo = new SqlParameter();
                TransRefNo.SqlDbType = SqlDbType.VarChar;
                TransRefNo.Value = lbltransrefno.Text.ToString();
                TransRefNo.ParameterName = "@TransRefNo";
                sqlcmd.Parameters.Add(TransRefNo);
            }
            else
            {
                Lblmessage2.Text = "Please select Transrefno";
                return;
            }

            string subtrans = "";
            string assettype = "";
            if (ddlmonStatus.SelectedItem.Text != "Available")
            {
                subtrans = lblmonitorSubTrans.Text.ToString();
                assettype = "MN";
            }
            else if (ddlcpustatus.SelectedItem.Text != "Available")
            {
                subtrans = lblSubTranscpu.Text.ToString();
                assettype = "CPU";
            }
            else if (ddlkbstatus.SelectedItem.Text != "Available")
            {
                subtrans = lblsubtranskb.Text.ToString();
                assettype = "KB";
            }
            else if (ddlsbmouse.SelectedItem.Text != "Available")
            {
                subtrans = lblsubtransmouse.Text.ToString();
                assettype = "MS";
            }
            else if (ddlsbmouse.SelectedItem.Text != "Available")
            {
                subtrans = lblSubTranshdd.Text.ToString();
                assettype = "HDD";
            }

            if (lbltransrefno.Text.ToString() != "")
            {
                SqlParameter Subtransrefno = new SqlParameter();
                Subtransrefno.SqlDbType = SqlDbType.VarChar;
                Subtransrefno.Value = subtrans.ToString();
                Subtransrefno.ParameterName = "@Subtransrefno";
                sqlcmd.Parameters.Add(Subtransrefno);
            }
            else
            {
                Lblmessage2.Text = "Please select Sub Transrefno";
                return;
            }



            SqlParameter SubAssettype = new SqlParameter();
            SubAssettype.SqlDbType = SqlDbType.VarChar;
            SubAssettype.Value = assettype.ToString();
            SubAssettype.ParameterName = "@SubAssettype";
            sqlcmd.Parameters.Add(SubAssettype);

            SqlParameter SSRAprovBy = new SqlParameter();
            SSRAprovBy.SqlDbType = SqlDbType.VarChar;
            SSRAprovBy.Value = txttrfApprovby.Text.ToString();
            SSRAprovBy.ParameterName = "@TransApprovedby";
            sqlcmd.Parameters.Add(SSRAprovBy);

            SqlParameter ssrApproveddate = new SqlParameter();
            ssrApproveddate.SqlDbType = SqlDbType.VarChar;
            ssrApproveddate.Value = txtdateofTrasfer.Text.ToString();
            ssrApproveddate.ParameterName = "@TransApproveddate";
            sqlcmd.Parameters.Add(ssrApproveddate);

            if (txtsearch2.Text.ToString() != "")
            {
                SqlParameter Transemp = new SqlParameter();
                Transemp.SqlDbType = SqlDbType.VarChar;
                Transemp.Value = txtsearch2.Text.ToString();
                Transemp.ParameterName = "@Transemp";
                sqlcmd.Parameters.Add(Transemp);
            }

            else
            {
                Lblmessage2.Text = "please select Employee First..!";
                return;
            }
            if ((ddlmonStatus.SelectedValue == "Transferred to Other Branch") || (ddlcpustatus.SelectedValue == "Transferred to Other Branch") || (ddlkbstatus.SelectedValue == "Transferred to Other Branch") || (ddlsbmouse.SelectedValue == "Transferred to Other Branch"))
            {
                SqlParameter TransferToEmp_Id = new SqlParameter();
                TransferToEmp_Id.SqlDbType = SqlDbType.VarChar;
                //TransferToEmp_Id.Value = HdnEmp.Value;
                TransferToEmp_Id.Value = ddlpamaciantransfer.SelectedValue.ToString();
                TransferToEmp_Id.ParameterName = "@TransferToEmp_Id";
                sqlcmd.Parameters.Add(TransferToEmp_Id);
            }
            else
            {
                SqlParameter TransferToEmp_Id = new SqlParameter();
                TransferToEmp_Id.SqlDbType = SqlDbType.VarChar;
                TransferToEmp_Id.Value = ddlpamaciantransfer.SelectedValue.ToString();
                TransferToEmp_Id.ParameterName = "@TransferToEmp_Id";
                sqlcmd.Parameters.Add(TransferToEmp_Id);
            }

            SqlParameter TransferBy = new SqlParameter();
            TransferBy.SqlDbType = SqlDbType.VarChar;
            TransferBy.Value = Session["Userid"].ToString();
            TransferBy.ParameterName = "@TransferBy";
            sqlcmd.Parameters.Add(TransferBy);

            SqlParameter TransferToCluster = new SqlParameter();
            TransferToCluster.SqlDbType = SqlDbType.VarChar;
            TransferToCluster.Value = ddlclustername.SelectedValue.ToString();
            TransferToCluster.ParameterName = "@TransferToCluster";
            sqlcmd.Parameters.Add(TransferToCluster);

            SqlParameter TransferToCentre = new SqlParameter();
            TransferToCentre.SqlDbType = SqlDbType.VarChar;
            TransferToCentre.Value = ddlCenterList.SelectedValue.ToString();
            TransferToCentre.ParameterName = "@TransferToCentre";
            sqlcmd.Parameters.Add(TransferToCentre);

            SqlParameter TransferToSubcentre = new SqlParameter();
            TransferToSubcentre.SqlDbType = SqlDbType.VarChar;
            TransferToSubcentre.Value = ddlsubcentrename.SelectedValue.ToString();
            TransferToSubcentre.ParameterName = "@TransferToSubcentre";
            sqlcmd.Parameters.Add(TransferToSubcentre);

            SqlParameter TransferStatus = new SqlParameter();
            TransferStatus.SqlDbType = SqlDbType.VarChar;
            TransferStatus.Value = HdnTransStatus.Value;//"Transfer".ToString();
            TransferStatus.ParameterName = "@TransferStatus";
            sqlcmd.Parameters.Add(TransferStatus);


            int i = sqlcmd.ExecuteNonQuery();

            if (i > 0)
            {
                Lblmessage2.Text = "Data Saved Successfully...";


            }
            else
            {
                Lblmessage2.Text = "Already Exists...";
            }

        }
        catch (Exception ex)
        {

            Lblmessage2.Text = "Error:" + ex.Message;
        }


    }
    public void GetDetails(string transvalue)
    {

        CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);

        sqlcon.Open();
        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlcon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = "GetReplacedetails1203";

        SqlCommand sqlCom2 = new SqlCommand();
        sqlCom2.Connection = sqlcon;
        sqlCom2.CommandType = CommandType.StoredProcedure;
        sqlCom2.CommandText = "GetDetailsreplacetrans1203";

        SqlParameter transrefno = new SqlParameter();
        transrefno.SqlDbType = SqlDbType.VarChar;
        transrefno.Value = transvalue;
        transrefno.ParameterName = "@transrefno";
        sqlCom.Parameters.Add(transrefno);

        SqlParameter transrefno1 = new SqlParameter();
        transrefno1.SqlDbType = SqlDbType.VarChar;
        transrefno1.Value = transvalue;
        transrefno1.ParameterName = "@transrefno";
        sqlCom2.Parameters.Add(transrefno1);

        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlCom;

        SqlDataAdapter sqlda1 = new SqlDataAdapter();
        sqlda1.SelectCommand = sqlCom2;

        DataSet dt = new DataSet();
        sqlda.Fill(dt);


        DataSet dt1 = new DataSet();
        sqlda1.Fill(dt1);

        sqlcon.Close();

        //if (dt.Tables[0].Rows.Count > 0 || dt.Tables[1].Rows.Count > 0 || dt.Tables[2].Rows.Count > 0 || dt.Tables[3].Rows.Count > 0 || dt.Tables[4].Rows.Count > 0)
        //{

        if (dt.Tables[0].Rows.Count > 0 && dt.Tables[0].Rows[0]["MN"].ToString() != "")
        {
            lblmnsubprstatus.Text = "Available";
        }
        else if (dt1.Tables[0].Rows.Count > 0 && dt1.Tables[0].Rows[0]["MN"].ToString() != "")
        {
            lblmnsubprstatus.Text = "Scrap";
        }
        else
        {
            lblmnsubprstatus.Text = "Unavailable";
        }


        if (dt.Tables[1].Rows.Count > 0 && dt.Tables[1].Rows[0]["CPU"].ToString() != "")
        {
            lblcpuprstatus.Text = "Available";
        }
        else if (dt1.Tables[1].Rows.Count > 0 && dt1.Tables[1].Rows[0]["CPU"].ToString() != "")
        {
            lblcpuprstatus.Text = "Scrap";

        }
        else
        {
            lblcpuprstatus.Text = "Unavailable";

        }

        if (dt.Tables[2].Rows.Count > 0 && dt.Tables[2].Rows[0]["KB"].ToString() != "")
        {
            lblkbprstatus.Text = "Available";
        }
        else if (dt1.Tables[2].Rows.Count > 0 && dt1.Tables[2].Rows[0]["KB"].ToString() != "")
        {

            lblkbprstatus.Text = "Scrap";
        }
        else
        {
            lblkbprstatus.Text = "Unavailable";

        }

        if (dt.Tables[3].Rows.Count > 0 && dt.Tables[3].Rows[0]["HDD"].ToString() != "")
        {
            lblhddprstatus.Text = "Available";

        }
        else if (dt1.Tables[3].Rows.Count > 0 && dt1.Tables[3].Rows[0]["HDD"].ToString() != "")
        {
            lblhddprstatus.Text = "Scrap";

        }
        else
        {
            lblhddprstatus.Text = "Unavailable";

        }

        if (dt.Tables[4].Rows.Count > 0 && dt.Tables[4].Rows[0]["MS"].ToString() != "")
        {
            lblmsprstatus.Text = "Available";
        }
        else if (dt1.Tables[4].Rows.Count > 0 && dt1.Tables[4].Rows[0]["MS"].ToString() != "")
        {
            lblmsprstatus.Text = "Scrap";

        }
        else
        {
            lblmsprstatus.Text = "Unavailable";

        }

        //}
        //else
        //{
        //    lblmnsubprstatus.Text = "Unavailable";
        //    lblcpuprstatus.Text = "Unavailable";
        //    lblkbprstatus.Text = "Unavailable";
        //    lblmsprstatus.Text = "Unavailable";
        //    lblhddprstatus.Text = "Unavailable";
        //}
    }
    protected void ddlscrpatrnsfr_SelectedIndexChanged(object sender, EventArgs e)
    {
        if ((ddlscrpatrnsfr.SelectedValue == "Complete") && (ddlscrpatrnsfr.SelectedValue != "--Select--"))
        {
            pnlScrap.Visible = true;
            pnlTransfer.Visible = false;
            Panel1.Visible = false;
            txtscrapdate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
        }
        else
        {
            pnlScrap.Visible = true;
            pnlTransfer.Visible = false;
            Panel1.Visible = true;
            btnsave.Visible = false;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (ddlscrpatrnsfr.SelectedValue == "Complete")
        {
            scrapSoldRecord1();
        }
        else
        {
            scrapSoldRecord();
        }

    }
    protected void ddlhddstatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        if ((ddlhddstatus.SelectedValue == "Sold") || (ddlhddstatus.SelectedValue == "Scrap") || (ddlhddstatus.SelectedValue == "Returned  to Vendor"))
        {
            pnlScrap.Visible = true;
            pnlTransfer.Visible = false;
            HdnTransStatus.Value = ddlhddstatus.SelectedValue.ToString();
        }
        else if ((ddlhddstatus.SelectedValue == "Transferred to Other Branch") || (ddlhddstatus.SelectedValue == "Transferred to other PAMACian"))
        {
            pnlScrap.Visible = false;
            pnlTransfer.Visible = true;
            HdnTransStatus.Value = ddlhddstatus.SelectedValue.ToString();
        }
        else
        {
            pnlScrap.Visible = false;
            pnlTransfer.Visible = false;
        }
    }

}
