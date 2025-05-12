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

public partial class Admin_Assets_Inventory_Assets_DescriptionFormat : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();
        if (!IsPostBack)
        {
            if (Request.QueryString["CentreID"] != "" && Request.QueryString["CentreID"] != null && Request.QueryString["SubcentreID"] != "" && Request.QueryString["SubcentreID"] != null)
            {
                hdnCentre.Value = Request.QueryString["CentreID"].ToString();

                hdnSubcentre.Value = Request.QueryString["SubcentreID"].ToString();
            }

            if (Request.QueryString["TranRefNo"] != "" && Request.QueryString["TranRefNo"] != null)
            {
                hdnTranRefNo.Value = Request.QueryString["TranRefNo"].ToString();

            }
            if (Request.QueryString["AssetType"] != "" && Request.QueryString["AssetType"] != null)
            {
                hdnAssetType.Value = Request.QueryString["AssetType"].ToString();
            }
            if (Request.QueryString["EmpCode"] != "" && Request.QueryString["EmpCode"] != null)
            {
                hdnEmpCode.Value = Request.QueryString["EmpCode"].ToString();
            }

            GetDescriptionData();
            Get_DescriptionData2();
            SaveValidation();



        }
        //if (txtCompName.Text != "")
        //{
        //    btnSave.Visible = false;
        //}

    }

    private void SaveValidation()
    {
        btnSave.Attributes.Add("onclick", "javascript:return SaveValidationControl();");
    }


    private void GetDescriptionData()
    {
        //sqlconnection sqlcon = new sqlconnection(ConfigurationSettings.AppSettings["constring"]);
        //sqlcon.Open();


        CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Get_DiscripationMain";
        sqlcmd.CommandTimeout = 0;

        SqlParameter EmpID = new SqlParameter();
        EmpID.SqlDbType = SqlDbType.VarChar;
        EmpID.Value = hdnTranRefNo.Value;
        EmpID.ParameterName = "@TranRefNo";
        sqlcmd.Parameters.Add(EmpID);

        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;
        DataTable dt = new DataTable();
        sqlda.Fill(dt);
        sqlcon.Close();

        if (dt.Rows.Count > 0)
        {
            lblUserName.Text = dt.Rows[0]["FullName"].ToString().Trim();
            lblCentreName.Text = dt.Rows[0]["Centre_name"].ToString().Trim();
            lblSubcentreName.Text = dt.Rows[0]["SubcentreName"].ToString().Trim();
            lblVerticalName.Text = dt.Rows[0]["Vertical_Name"].ToString().Trim();
            lblAssetsType.Text = dt.Rows[0]["Assets_Type"].ToString().Trim();

            //GetSubAssetsData();
            Get_SubAssets();


            if (lblAssetsType.Text == "PC")
            {
                lblCompName.Visible = true;
                txtCompName.Visible = true;

                lblModelName.Visible = true;
                txtModelName.Visible = true;

                lblWarrantyType.Visible = true;
                ddlWarrantyType.Visible = true;


                lblProcessor.Visible = true;
                ddlProcessor.Visible = true;

                lblProcessorName.Visible = true;
                txtProcessorName.Visible = true;

                lblKeyBoard.Visible = true;
                ddlKeyboard.Visible = true;

                lblMouse.Visible = true;
                ddlMouse.Visible = true;

                lblRamType.Visible = true;
                ddlRam.Visible = true;

                lblHddGb.Visible = true;
                ddlHdd.Visible = true;

                lblMotherBoardMake.Visible = true;
                txtMotherBoardMake.Visible = true;

            }
            else if (lblAssetsType.Text == "KBT")
            {
                lblCompName.Visible = true;
                txtCompName.Visible = true;

                //lblModelName.Visible = true;
                //txtModelName.Visible = true;
            }

            else if (lblAssetsType.Text == "RC")
            {
                lblCompName.Visible = true;
                txtCompName.Visible = true;
                lblModelName.Visible = true;
                txtModelName.Visible = true;
                lblWarrantyType.Visible = true;
                ddlWarrantyType.Visible = true;

                lblCassetteCD.Visible = true;
                txtCassetteCD.Visible = true;
                lblUsbPortAvil.Visible = true;
                ddlUsbPortAvil.Visible = true;
            }
            else if (lblAssetsType.Text == "CB")
            {
                lblCompName.Visible = true;
                txtCompName.Visible = true;
                lblModelName.Visible = true;
                txtModelName.Visible = true;
                lblWarrantyType.Visible = true;
                ddlWarrantyType.Visible = true;

                lblTotalRacks.Visible = true;
                txtTotalRacks.Visible = true;
                lblLockerAvil.Visible = true;
                ddlLockerAvil.Visible = true;
            }
            else if (lblAssetsType.Text == "HP")
            {
                lblCompName.Visible = true;
                txtCompName.Visible = true;

                lblModelName.Visible = true;
                txtModelName.Visible = true;

                //lblrentalsystem.Visible = true;
                //txtrentalsystem.Visible = true;
            }
            else if (lblAssetsType.Text == "CN")
            {
                lblCompName.Visible = true;
                txtCompName.Visible = true;
                lblModelName.Visible = true;
                txtModelName.Visible = true;
                lblWarrantyType.Visible = true;
                ddlWarrantyType.Visible = true;

                lblTotalRacks.Visible = true;
                txtTotalRacks.Visible = true;
                lblLockerAvil.Visible = true;
                ddlLockerAvil.Visible = true;
            }
            else if (lblAssetsType.Text == "CM")
            {
                lblCompName.Visible = true;
                txtCompName.Visible = true;
                lblModelName.Visible = true;
                txtModelName.Visible = true;
                lblWarrantyType.Visible = true;
                ddlWarrantyType.Visible = true;

                lblSensorResu.Visible = true;
                txtSensorResu.Visible = true;
                lblSensorType.Visible = true;
                txtSensorType.Visible = true;
                lblManualFocus.Visible = true;
                txtManualFocus.Visible = true;
                lblScreenSize.Visible = true;
                txtScreenSize.Visible = true;
                lblConnectivity.Visible = true;
                ddlConnectivity.Visible = true;
                lblTotalBatt.Visible = true;
                txtBatteryLife.Visible = true;
                lblRechargeBett.Visible = true;
                txtBatteryType.Visible = true;

            }
            else if (lblAssetsType.Text == "CH")
            {
                lblCompName.Visible = true;
                txtCompName.Visible = true;
                lblModelName.Visible = true;
                txtModelName.Visible = true;
                lblWarrantyType.Visible = true;
                ddlWarrantyType.Visible = true;

                lblFoldingChair.Visible = true;
                txtFoldingChair.Visible = true;

                lblPushBack.Visible = true;
                txtPushBack.Visible = true;
            }
            else if (lblAssetsType.Text == "EM")
            {
                lblCompName.Visible = true;
                txtCompName.Visible = true;
                lblModelName.Visible = true;
                txtModelName.Visible = true;
                lblWarrantyType.Visible = true;
                ddlWarrantyType.Visible = true;
            }
            else if (lblAssetsType.Text == "FN")
            {
                lblCompName.Visible = true;
                txtCompName.Visible = true;
                lblModelName.Visible = true;
                txtModelName.Visible = true;
                lblWarrantyType.Visible = true;
                ddlWarrantyType.Visible = true;
            }
            else if (lblAssetsType.Text == "FX")
            {
                lblCompName.Visible = true;
                txtCompName.Visible = true;
                lblModelName.Visible = true;
                txtModelName.Visible = true;
                lblWarrantyType.Visible = true;
                ddlWarrantyType.Visible = true;

                lblPlainPaper.Visible = true;
                txtPlainPaper.Visible = true;
                lblCompPrintCap.Visible = true;
                txtCompPrintCap.Visible = true;
                lblPrintCartg.Visible = true;
                txtPrintCartg.Visible = true;
                lblPrintCapacity.Visible = true;
                txtPrintCapacity.Visible = true;
                lblAlarmIndi.Visible = true;
                txtAlarmIndi.Visible = true;
                lblPowerOffDial.Visible = true;
                txtPowerOffDial.Visible = true;
                lblSpeakerPH.Visible = true;
                txtSpeakerPH.Visible = true;
                lblInbuiltAnsMach.Visible = true;
                txtInbuiltAnsMach.Visible = true;
                lblPassUserRestric.Visible = true;
                txtPassUserRestric.Visible = true;

            }
            else if (lblAssetsType.Text == "FW")
            {
                lblCompName.Visible = true;
                txtCompName.Visible = true;
                lblModelName.Visible = true;
                txtModelName.Visible = true;
                lblWarrantyType.Visible = true;
                ddlWarrantyType.Visible = true;

                lblRouter.Visible = true;
                txtRouter.Visible = true;
                lblValidity.Visible = true;
                txtValidity.Visible = true;
            }
            else if (lblAssetsType.Text == "LT")
            {
                lblCompName.Visible = true;
                txtCompName.Visible = true;
                lblModelName.Visible = true;
                txtModelName.Visible = true;
                lblWarrantyType.Visible = true;
                ddlWarrantyType.Visible = true;

                lblUsbPortAvil.Visible = true;
                ddlUsbPortAvil.Visible = true;
                lblProcessorName.Visible = true;
                txtProcessorName.Visible = true;
                lblProcessorSpeed.Visible = true;
                txtProcessorSpeed.Visible = true;
                lblStandardRam.Visible = true;
                txtStandardRam.Visible = true;
                lblUpgradeRam.Visible = true;
                txtUpgradeRam.Visible = true;
                lblHardDiskDriveCap.Visible = true;
                txtHardDiskDriveCap.Visible = true;
                lblBatteryLife.Visible = true;
                txtBatteryLife.Visible = true;
                lblBatteryType.Visible = true;
                txtBatteryType.Visible = true;
                lblCameraBuilt.Visible = true;
                txtCameraBuilt.Visible = true;
                lblSpeaker.Visible = true;
                txtSpeaker.Visible = true;
                lblUsbPortAvil.Visible = true;
                ddlUsbPortAvil.Visible = true;
                lblBluetooth.Visible = true;
                txtBluetooth.Visible = true;

            }
            else if (lblAssetsType.Text == "IPAD")
            {
                lblCompName.Visible = true;
                txtCompName.Visible = true;
                lblModelName.Visible = true;
                txtModelName.Visible = true;
                lblWarrantyType.Visible = true;
                ddlWarrantyType.Visible = true;

                lblUsbPortAvil.Visible = true;
                ddlUsbPortAvil.Visible = true;
                lblProcessorName.Visible = true;
                txtProcessorName.Visible = true;
                lblProcessorSpeed.Visible = true;
                txtProcessorSpeed.Visible = true;
                lblStandardRam.Visible = true;
                txtStandardRam.Visible = true;
                lblUpgradeRam.Visible = true;
                txtUpgradeRam.Visible = true;
                lblHardDiskDriveCap.Visible = true;
                txtHardDiskDriveCap.Visible = true;
                lblBatteryLife.Visible = true;
                txtBatteryLife.Visible = true;
                lblBatteryType.Visible = true;
                txtBatteryType.Visible = true;
                lblCameraBuilt.Visible = true;
                txtCameraBuilt.Visible = true;
                lblSpeaker.Visible = true;
                txtSpeaker.Visible = true;
                lblUsbPortAvil.Visible = true;
                ddlUsbPortAvil.Visible = true;
                lblBluetooth.Visible = true;
                txtBluetooth.Visible = true;

            }

            else if (lblAssetsType.Text == "MB")
            {
                lblCompName.Visible = true;
                txtCompName.Visible = true;
                lblModelName.Visible = true;
                txtModelName.Visible = true;
                lblWarrantyType.Visible = true;
                ddlWarrantyType.Visible = true;

                lblBatteryLife.Visible = true;
                txtBatteryLife.Visible = true;
                lblCameraBuilt.Visible = true;
                txtCameraBuilt.Visible = true;
                lblSmartPh.Visible = true;
                txtSmartPh.Visible = true;
                lblConnectivity.Visible = true;
                ddlConnectivity.Visible = true;
                lblTouchScreen.Visible = true;
                txtTouchScreen.Visible = true;
                lblConfCall.Visible = true;
                txtConfCall.Visible = true;
                lblMemCard.Visible = true;
                txtMemCard.Visible = true;
                lblMemCardSize.Visible = true;
                txtMemCardSize.Visible = true;


            }
            else if (lblAssetsType.Text == "MD")
            {
                lblCompName.Visible = true;
                txtCompName.Visible = true;
                lblModelName.Visible = true;
                txtModelName.Visible = true;
                lblWarrantyType.Visible = true;
                ddlWarrantyType.Visible = true;

                lblModelType.Visible = true;
                ddlModelType.Visible = true;


            }
            else if (lblAssetsType.Text == "RT")
            {
                lblCompName.Visible = true;
                txtCompName.Visible = true;
                lblModelName.Visible = true;
                txtModelName.Visible = true;
                lblWarrantyType.Visible = true;
                ddlWarrantyType.Visible = true;

                lblRouter.Visible = true;
                txtRouter.Visible = true;

                lblRouterSpeed.Visible = true;
                txtRouterSpeed.Visible = true;

                lblTotalPort.Visible = true;
                txtTotalPort.Visible = true;
            }
            else if (lblAssetsType.Text == "SC")
            {
                lblCompName.Visible = true;
                txtCompName.Visible = true;
                lblModelName.Visible = true;
                txtModelName.Visible = true;
                lblWarrantyType.Visible = true;
                ddlWarrantyType.Visible = true;

                lblUsbPortAvil.Visible = true;
                ddlUsbPortAvil.Visible = true;
                lblPrintCapacity.Visible = true;
                txtPrintCapacity.Visible = true;
                lblAutomaticDocu.Visible = true;
                txtAutomaticDocu.Visible = true;
                lblOpticalCharReco.Visible = true;
                txtOpticalCharReco.Visible = true;
                lblTextEnhanTech.Visible = true;
                txtTextEnhanTech.Visible = true;

            }
            else if (lblAssetsType.Text == "SV")
            {
                lblCompName.Visible = true;
                txtCompName.Visible = true;

                lblModelName.Visible = true;
                txtModelName.Visible = true;

                lblWarrantyType.Visible = true;
                ddlWarrantyType.Visible = true;


                lblProcessor.Visible = true;
                ddlProcessor.Visible = true;

                lblProcessorName.Visible = true;
                txtProcessorName.Visible = true;

                lblKeyBoard.Visible = true;
                ddlKeyboard.Visible = true;

                lblMouse.Visible = true;
                ddlMouse.Visible = true;

                lblRamType.Visible = true;
                ddlRam.Visible = true;

                lblHddGb.Visible = true;
                ddlHdd.Visible = true;

                lblMotherBoardMake.Visible = true;
                txtMotherBoardMake.Visible = true;
                //lblCompName.Visible = true;
                //txtCompName.Visible = true;
                //lblModelName.Visible = true;
                //txtModelName.Visible = true;

                //lblWarrantyType.Visible = true;
                //ddlWarrantyType.Visible = true;
            }
            else if (lblAssetsType.Text == "SP")
            {
                lblCompName.Visible = true;
                txtCompName.Visible = true;
                lblModelName.Visible = true;
                txtModelName.Visible = true;
                lblWarrantyType.Visible = true;
                ddlWarrantyType.Visible = true;

                lblSpeakerType.Visible = true;
                txtSpeakerType.Visible = true;
                lblSpeakerPorts.Visible = true;
                txtSpeakerPorts.Visible = true;

            }
            else if (lblAssetsType.Text == "SW")
            {
                lblCompName.Visible = true;
                txtCompName.Visible = true;
                lblModelName.Visible = true;
                txtModelName.Visible = true;
                lblWarrantyType.Visible = true;
                ddlWarrantyType.Visible = true;
            }
            else if (lblAssetsType.Text == "TB")
            {
                lblCompName.Visible = true;
                txtCompName.Visible = true;
                lblModelName.Visible = true;
                txtModelName.Visible = true;
                lblWarrantyType.Visible = true;
                ddlWarrantyType.Visible = true;
            }
            else if (lblAssetsType.Text == "TP")
            {
                lblCompName.Visible = true;
                txtCompName.Visible = true;
                lblModelName.Visible = true;
                txtModelName.Visible = true;
                lblWarrantyType.Visible = true;
                ddlWarrantyType.Visible = true;

                lblTelephone.Visible = true;
                txtTelephone.Visible = true;

                lblCallerID.Visible = true;
                txtCallerID.Visible = true;

                lblStd.Visible = true;
                txtStd.Visible = true;
            }
            else if (lblAssetsType.Text == "TL")
            {
                lblCompName.Visible = true;
                txtCompName.Visible = true;
                lblModelName.Visible = true;
                txtModelName.Visible = true;
                lblWarrantyType.Visible = true;
                ddlWarrantyType.Visible = true;

                lblWatt.Visible = true;
                txtWatt.Visible = true;
            }
            else if (lblAssetsType.Text == "CK")
            {
                lblCompName.Visible = true;
                txtCompName.Visible = true;
                lblModelName.Visible = true;
                txtModelName.Visible = true;
                lblWarrantyType.Visible = true;
                ddlWarrantyType.Visible = true;
            }
            else if (lblAssetsType.Text == "OT")
            {
                lblCompName.Visible = true;
                txtCompName.Visible = true;
                lblModelName.Visible = true;
                txtModelName.Visible = true;
                lblWarrantyType.Visible = true;
                ddlWarrantyType.Visible = true;
            }
            else if (lblAssetsType.Text == "AC")
            {
                lblCompName.Visible = true;
                txtCompName.Visible = true;
                lblModelName.Visible = true;
                txtModelName.Visible = true;
                lblWarrantyType.Visible = true;
                ddlWarrantyType.Visible = true;

                lblTonn.Visible = true;
                txtTonn.Visible = true;
            }
            else if (lblAssetsType.Text == "BB")
            {
                lblCompName.Visible = true;
                txtCompName.Visible = true;
                lblModelName.Visible = true;
                txtModelName.Visible = true;
                lblWarrantyType.Visible = true;
                ddlWarrantyType.Visible = true;
            }
            else if (lblAssetsType.Text == "WB")
            {
                lblCompName.Visible = true;
                txtCompName.Visible = true;
                lblModelName.Visible = true;
                txtModelName.Visible = true;
                lblWarrantyType.Visible = true;
                ddlWarrantyType.Visible = true;
            }
            else if (lblAssetsType.Text == "KBT")
            {
                lblCompName.Visible = true;
                txtCompName.Visible = true;
                lblModelName.Visible = true;
                txtModelName.Visible = true;
                lblWarrantyType.Visible = true;
                ddlWarrantyType.Visible = true;
            }
            else if (lblAssetsType.Text == "TF")
            {
                lblCompName.Visible = true;
                txtCompName.Visible = true;
                lblModelName.Visible = true;
                txtModelName.Visible = true;
                lblWarrantyType.Visible = true;
                ddlWarrantyType.Visible = true;
            }
            else if (lblAssetsType.Text == "PT")
            {
                lblCompName.Visible = true;
                txtCompName.Visible = true;
                lblModelName.Visible = true;
                txtModelName.Visible = true;
                lblWarrantyType.Visible = true;
                ddlWarrantyType.Visible = true;

                lblTotalRacks.Visible = true;
                txtTotalRacks.Visible = true;
                lblLockerAvil.Visible = true;
                ddlLockerAvil.Visible = true;
                lblPrintCapacity.Visible = true;
                txtPrintCapacity.Visible = true;
                lblPrintCartg.Visible = true;
                txtPrintCartg.Visible = true;
            }
            else if (lblAssetsType.Text == "WTK")
            {
                lblCompName.Visible = true;
                txtCompName.Visible = true;
                lblModelName.Visible = true;
                txtModelName.Visible = true;
                lblWarrantyType.Visible = true;
                ddlWarrantyType.Visible = true;
            }
            else if (lblAssetsType.Text == "PCT")
            {
                lblCompName.Visible = true;
                txtCompName.Visible = true;
                lblModelName.Visible = true;
                txtModelName.Visible = true;
                lblWarrantyType.Visible = true;
                ddlWarrantyType.Visible = true;
            }
            else if (lblAssetsType.Text == "LOC")
            {
                lblCompName.Visible = true;
                txtCompName.Visible = true;
                lblModelName.Visible = true;
                txtModelName.Visible = true;
                lblWarrantyType.Visible = true;
                ddlWarrantyType.Visible = true;
            }
            else if (lblAssetsType.Text == "FEX")
            {
                lblCompName.Visible = true;
                txtCompName.Visible = true;
                lblModelName.Visible = true;
                txtModelName.Visible = true;
                lblWarrantyType.Visible = true;
                ddlWarrantyType.Visible = true;
            }
            else if (lblAssetsType.Text == "RAC")
            {
                lblCompName.Visible = true;
                txtCompName.Visible = true;
                lblModelName.Visible = true;
                txtModelName.Visible = true;
                lblWarrantyType.Visible = true;
                ddlWarrantyType.Visible = true;


            }
            else if (lblAssetsType.Text == "FAB")
            {
                lblCompName.Visible = true;
                txtCompName.Visible = true;
                lblModelName.Visible = true;
                txtModelName.Visible = true;
                lblWarrantyType.Visible = true;
                ddlWarrantyType.Visible = true;
            }
            else if (lblAssetsType.Text == "UPS")
            {
                lblCompName.Visible = true;
                txtCompName.Visible = true;
                lblModelName.Visible = true;
                txtModelName.Visible = true;
                lblWarrantyType.Visible = true;
                ddlWarrantyType.Visible = true;
                lblBackupTime.Visible = true;
                txtBackupTime.Visible = true;

                lblbatteryCount.Visible = true;
                ddlbatteryCount.Visible = true;

            }
            else if (lblAssetsType.Text == "INV")
            {
                lblCompName.Visible = true;
                txtCompName.Visible = true;
                lblModelName.Visible = true;
                txtModelName.Visible = true;
                lblWarrantyType.Visible = true;
                ddlWarrantyType.Visible = true;
                lblBackupTime.Visible = true;
                txtBackupTime.Visible = true;

                lblbatteryCount.Visible = true;
                ddlbatteryCount.Visible = true;

            }

            else if (lblAssetsType.Text == "RACK")
            {
                lblCompName.Visible = true;
                txtCompName.Visible = true;
                lblModelName.Visible = true;
                txtModelName.Visible = true;
                lblWarrantyType.Visible = true;
                ddlWarrantyType.Visible = true;

                lblTotalRacks.Visible = true;
                txtTotalRacks.Visible = true;
                lblLockerAvil.Visible = true;
                ddlLockerAvil.Visible = true;

            }

            else if (lblAssetsType.Text == "WC")
            {
                lblCompName.Visible = true;
                txtCompName.Visible = true;
                lblModelName.Visible = true;
                txtModelName.Visible = true;
                lblWarrantyType.Visible = true;
                ddlWarrantyType.Visible = true;
            }
            else if (lblAssetsType.Text == "CPUTR")
            {
                lblCompName.Visible = true;
                txtCompName.Visible = true;
                lblModelName.Visible = true;
                txtModelName.Visible = true;
                lblWarrantyType.Visible = true;
                ddlWarrantyType.Visible = true;
            }
            else if (lblAssetsType.Text == "ALM")
            {
                lblCompName.Visible = true;
                txtCompName.Visible = true;
                lblModelName.Visible = true;
                txtModelName.Visible = true;
                lblWarrantyType.Visible = true;
                ddlWarrantyType.Visible = true;
            }
            else if (lblAssetsType.Text == "BTR")
            {
                lblCompName.Visible = true;
                txtCompName.Visible = true;
                lblModelName.Visible = true;
                txtModelName.Visible = true;
                lblWarrantyType.Visible = true;
                ddlWarrantyType.Visible = true;
            }
            else if (lblAssetsType.Text == "STL")
            {
                lblCompName.Visible = true;
                txtCompName.Visible = true;
                lblModelName.Visible = true;
                txtModelName.Visible = true;
                lblWarrantyType.Visible = true;
                ddlWarrantyType.Visible = true;
            }
            else if (lblAssetsType.Text == "CL")
            {
                lblCompName.Visible = true;
                txtCompName.Visible = true;
                lblModelName.Visible = true;
                txtModelName.Visible = true;
                lblWarrantyType.Visible = true;
                ddlWarrantyType.Visible = true;
            }
            else if (lblAssetsType.Text == "NB")
            {
                lblCompName.Visible = true;
                txtCompName.Visible = true;
                //lblModelName.Visible = true;
                //txtModelName.Visible = true;
                //lblWarrantyType.Visible = true;
                //ddlWarrantyType.Visible = true;
            }
            else if (lblAssetsType.Text == "GENSET")
            {
                lblCompName.Visible = true;
                txtCompName.Visible = true;
                lblModelName.Visible = true;
                txtModelName.Visible = true;
                lblWarrantyType.Visible = true;
                ddlWarrantyType.Visible = true;
            }
            else if (lblAssetsType.Text == "WD")
            {
                lblCompName.Visible = true;
                txtCompName.Visible = true;
                lblModelName.Visible = true;
                txtModelName.Visible = true;
                labtable.Visible = true;
                ddltable.Visible = true;
            }
            else if (lblAssetsType.Text == "PSHM")
            {
                lblCompName.Visible = true;
                txtCompName.Visible = true;
                Lblcapacity.Visible = true;
                txtcapacity.Visible = true;
            }

            else if (lblAssetsType.Text == "ELB")
            {
                lblCompName.Visible = true;
                txtCompName.Visible = true;
                Lblcapacity.Visible = true;
                txtcapacity.Visible = true;
            }

            //else if (lblAssetsType.Text == "NB")
            //{
            //    lblCompName.Visible = true;
            //    txtCompName.Visible = true;
            //}
        }
    }
    /// <summary>
    /// NIKHIL
    /// </summary>
    private void Get_SubAssets()
    {
        CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Get_SubAssets12_new";
        sqlcmd.CommandTimeout = 0;

        //SqlParameter TransRefNo = new SqlParameter();
        //TransRefNo.SqlDbType = SqlDbType.VarChar;
        //TransRefNo.Value = hdnTranRefNo.Value;
        //TransRefNo.ParameterName = "@TransRefNo";
        //sqlcmd.Parameters.Add(TransRefNo);

        SqlParameter SubType = new SqlParameter();
        SubType.SqlDbType = SqlDbType.VarChar;
        SubType.Value = lblAssetsType.Text.Trim();
        SubType.ParameterName = "@SubType";
        sqlcmd.Parameters.Add(SubType);

        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;
        DataTable dt = new DataTable();
        sqlda.Fill(dt);
        sqlcon.Close();
        if (dt.Rows.Count > 0)
        {

            ddlAssetsSubType.DataTextField = "Sub_type";
            //ddlAssetsSubType.DataValueField = "Asset_code";

            ddlAssetsSubType.DataSource = dt;
            ddlAssetsSubType.DataBind();

            ddlAssetsSubType.Items.Insert(0, "--Select--");
            ddlAssetsSubType.SelectedIndex = 0;

            Lblassetssubtype.Visible = false;
        }
        else
        {
            //ddlAssetsSubType.SelectedValue = lblAssetsType.Text.Trim();

            ddlAssetsSubType.Visible = false;
            Lblassetssubtype.Text = lblAssetsType.Text.Trim();
            GetSubAssetsData();

        }


    }

    private void GetSubAssetsData()
    {
        CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Get_SubAssetsData";
        sqlcmd.CommandTimeout = 0;

        SqlParameter SubType = new SqlParameter();
        SubType.SqlDbType = SqlDbType.VarChar;
        SubType.Value = lblAssetsType.Text.Trim();
        SubType.ParameterName = "@SubType";
        sqlcmd.Parameters.Add(SubType);

        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;
        DataTable dt = new DataTable();
        sqlda.Fill(dt);
        sqlcon.Close();

        if (dt.Rows.Count > 0)
        {

            ddlAssetsSubType.DataTextField = "Sub_type";
            //ddlAssetsSubType.DataValueField = "Asset_code";

            ddlAssetsSubType.DataSource = dt;
            ddlAssetsSubType.DataBind();


            ddlAssetsSubType.Items.Insert(0, "--Select--");
            ddlAssetsSubType.SelectedIndex = 0;

            Lblassetssubtype.Visible = false;
        }
        else
        {
            //ddlAssetsSubType.SelectedValue = lblAssetsType.Text.Trim();

            ddlAssetsSubType.Visible = false;
            Lblassetssubtype.Text = lblAssetsType.Text.Trim();

        }
    }

    //protected void ddlAssetsSubType_SelectedIndexChanged(object sender, EventArgs e)
    //{

    //    lblCompName.Visible = false;
    //    txtCompName.Visible = false;
    //    lblModelName.Visible = false;
    //    txtModelName.Visible = false;
    //    lblWarrantyType.Visible = false;
    //    ddlWarrantyType.Visible = false;
    //    lblSensorResu.Visible = false;
    //    txtSensorResu.Visible = false;
    //    lblSensorType.Visible = false;
    //    txtSensorType.Visible = false;
    //    lblManualFocus.Visible = false;
    //    txtManualFocus.Visible = false;
    //    lblScreenSize.Visible = false;
    //    txtScreenSize.Visible = false;
    //    lblConnectivity.Visible = false;
    //    ddlConnectivity.Visible = false;
    //    lblTotalBatt.Visible = false;
    //    txtTotalBatt.Visible = false;
    //    lblRechargeBett.Visible = false;
    //    ddlRechargeBett.Visible = false;
    //    lblPlainPaper.Visible = false;
    //    txtPlainPaper.Visible = false;


    //    if (ddlAssetsSubType.Text == "UPS With Battery-Yes" )
    //    {
    //        lblBatteryType.Visible = true;
    //        txtBatteryType.Visible = true;

    //        lblBatteryLife.Visible = true;
    //        txtBatteryLife.Visible = true;

    //    }


    //    if (ddlAssetsSubType.Text == "Encoding Machine")
    //    {
    //        lblCompName.Visible = true;
    //        txtCompName.Visible = true;

    //        lblModelName.Visible = true;
    //        txtModelName.Visible = true;

    //        lblEncodingType.Visible = true;
    //        ddlEncodingType.Visible = true;

    //        lblCartridge.Visible = true;
    //        txtCartridge.Visible = true; 
    //    }

    //    if (ddlAssetsSubType.Text == "Audio" || ddlAssetsSubType.Text == "Vedio" && lblAssetsType.Text == "Recorder")
    //    {
    //        lblCompName.Visible = true;
    //        txtCompName.Visible = true;
    //        lblModelName.Visible = true;
    //        txtModelName.Visible = true;
    //        lblWarrantyType.Visible = true;
    //        ddlWarrantyType.Visible = true;
    //        lblCassetteCD.Visible = true;
    //        txtCassetteCD.Visible = true;
    //        lblUsbPortAvil.Visible = true;
    //        ddlUsbPortAvil.Visible = true; 

    //    }
    //    else if (ddlAssetsSubType.Text == "Metal" || ddlAssetsSubType.Text == "Wooden" && lblAssetsType.Text == "CupBoard")
    //    {
    //        lblCompName.Visible = true;
    //        txtCompName.Visible = true;
    //        lblModelName.Visible = true;
    //        txtModelName.Visible = true;
    //        lblWarrantyType.Visible = true;
    //        ddlWarrantyType.Visible = true;
    //        lblTotalRacks.Visible = true;
    //        txtTotalRacks.Visible = true;
    //        lblLockerAvil.Visible = true;
    //        ddlLockerAvil.Visible = true; 
    //    }
    //    else if (ddlAssetsSubType.Text == "Dot Matrix" || ddlAssetsSubType.Text == "Laser Ject" && lblAssetsType.Text == "Printer")
    //    {
    //        lblCompName.Visible = true;
    //        txtCompName.Visible = true;
    //        lblModelName.Visible = true;
    //        txtModelName.Visible = true;
    //        lblWarrantyType.Visible = true;
    //        ddlWarrantyType.Visible = true;
    //        lblTotalRacks.Visible = true;
    //        txtTotalRacks.Visible = true;
    //        lblPrintCapacity.Visible = true;
    //        txtPrintCapacity.Visible = true;
    //        lblOthFeature.Visible = true;
    //        txtOthFeature.Visible = true; 
    //    }
    //    else if (ddlAssetsSubType.Text == "Metal" || ddlAssetsSubType.Text == "Wooden" && lblAssetsType.Text == "Cabinate")
    //    {
    //        lblCompName.Visible = true;
    //        txtCompName.Visible = true;
    //        lblModelName.Visible = true;
    //        txtModelName.Visible = true;
    //        lblWarrantyType.Visible = true;
    //        ddlWarrantyType.Visible = true;
    //        lblCountDraw.Visible = true;
    //        txtCountDraw.Visible = true;
    //        lblBlockingLock.Visible = true;
    //        txtBlockingLock.Visible = true;            
    //    }
    //    else if (ddlAssetsSubType.Text == "Digital" || ddlAssetsSubType.Text == "Normal" && lblAssetsType.Text == "Camera")
    //    {
    //        lblCompName.Visible = true;
    //        txtCompName.Visible = true;
    //        lblModelName.Visible = true;
    //        txtModelName.Visible = true;
    //        lblWarrantyType.Visible = true;
    //        ddlWarrantyType.Visible = true;
    //        lblSensorResu.Visible = true;
    //        txtSensorResu.Visible = true;
    //        lblSensorType.Visible = true;
    //        txtSensorType.Visible = true;
    //        lblManualFocus.Visible = true;
    //        txtManualFocus.Visible = true;
    //        lblScreenSize.Visible = true;
    //        txtScreenSize.Visible = true;
    //        lblConnectivity.Visible = true;
    //        ddlConnectivity.Visible = true;
    //        lblTotalBatt.Visible = true;
    //        txtTotalBatt.Visible = true;
    //        lblRechargeBett.Visible = true;
    //        ddlRechargeBett.Visible = true; 
    //    }
    //    else if (ddlAssetsSubType.Text == "Plastic Chair" || ddlAssetsSubType.Text == "Metal" || ddlAssetsSubType.Text == "Cushion Chair" && lblAssetsType.Text == "Chair")
    //    {
    //        lblCompName.Visible = true;
    //        txtCompName.Visible = true;
    //        lblModelName.Visible = true;
    //        txtModelName.Visible = true;
    //        lblWarrantyType.Visible = true;
    //        ddlWarrantyType.Visible = true;
    //        lblFoldingChair.Visible = true;
    //        txtFoldingChair.Visible = true;
    //        lblPushBack.Visible = true;
    //        txtPushBack.Visible = true;             
    //    }
    //    else if (ddlAssetsSubType.Text == "Table Fan" || ddlAssetsSubType.Text == "Wall Fan" || ddlAssetsSubType.Text == "Ceiling Fan" && lblAssetsType.Text == "Fan")
    //    {
    //        lblCompName.Visible = true;
    //        txtCompName.Visible = true;
    //        lblModelName.Visible = true;
    //        txtModelName.Visible = true;
    //        lblWarrantyType.Visible = true;
    //        ddlWarrantyType.Visible = true;          
    //    }
    //    else if (ddlAssetsSubType.Text == "Normal" || ddlAssetsSubType.Text == "With Telephone Handset" && lblAssetsType.Text == "Fax")
    //    {
    //        lblCompName.Visible = true;
    //        txtCompName.Visible = true;
    //        lblModelName.Visible = true;
    //        txtModelName.Visible = true;
    //        lblWarrantyType.Visible = true;
    //        ddlWarrantyType.Visible = true;
    //        lblTelephone.Visible = true;
    //        txtTelephone.Visible = true;
    //        lblStd.Visible = true;
    //        txtStd.Visible = true;
    //        lblCallerID.Visible = true;
    //        txtCallerID.Visible = true;

    //    }
    //    else if (lblAssetsType.Text == "Fax")
    //    {
    //        lblCompName.Visible = true;
    //        txtCompName.Visible = true;
    //        lblModelName.Visible = true;
    //        txtModelName.Visible = true;
    //        lblWarrantyType.Visible = true;
    //        ddlWarrantyType.Visible = true;
    //        lblPlainPaper.Visible = true;
    //        txtPlainPaper.Visible = true;
    //        lblColour.Visible = true;
    //        txtColour.Visible = true;
    //        lblFaxPrintSpeed.Visible = true;
    //        txtFaxPrintSpeed.Visible = true;
    //        lblCompPrintCap.Visible = true;
    //        txtCompPrintCap.Visible = true;
    //        lblPrintCartg.Visible = true;
    //        txtPrintCartg.Visible = true;
    //        lblMaxPaperCap.Visible = true;
    //        txtMaxPaperCap.Visible = true;
    //        lblAlarmIndi.Visible = true;
    //        txtAlarmIndi.Visible = true;
    //        lblPowerOffDial.Visible = true;
    //        txtPowerOffDial.Visible = true;
    //        lblSpeakerPH.Visible = true;
    //        txtSpeakerPH.Visible = true;
    //        lblInbuiltAnsMach.Visible = true;
    //        txtInbuiltAnsMach.Visible = true;
    //        lblPassUserRestric.Visible = true;
    //        txtPassUserRestric.Visible = true;
    //    }

    //    else if (ddlAssetsSubType.Text == "Normal" || ddlAssetsSubType.Text == "Jambo" && lblAssetsType.Text == "Scanner")
    //    {
    //        lblCompName.Visible = true;
    //        txtCompName.Visible = true;
    //        lblModelName.Visible = true;
    //        txtModelName.Visible = true;
    //        lblWarrantyType.Visible = true;
    //        ddlWarrantyType.Visible = true;
    //        lblUsbPortAvil.Visible = true;
    //        ddlUsbPortAvil.Visible = true;
    //        lblPrintCapacity.Visible = true;
    //        txtPrintCapacity.Visible = true;
    //        txtAutomaticDocu.Visible = true;
    //        lblAutomaticDocu.Visible = true;
    //        lblOpticalCharReco.Visible = true;
    //        txtOpticalCharReco.Visible = true;
    //        lblTextEnhanTech.Visible = true;
    //        txtTextEnhanTech.Visible = true; 
    //    }
    //    else if (ddlAssetsSubType.Text == "Codeless" || ddlAssetsSubType.Text == "Normal" && lblAssetsType.Text == "Speaker")
    //    {
    //        lblCompName.Visible = true;
    //        txtCompName.Visible = true;
    //        lblModelName.Visible = true;
    //        txtModelName.Visible = true;
    //        lblWarrantyType.Visible = true;
    //        ddlWarrantyType.Visible = true;
    //        lblSpeakerType.Visible = true;
    //        txtSpeakerType.Visible = true;
    //        lblSpeakerPorts.Visible = true;
    //        txtSpeakerPorts.Visible = true; 
    //    }
    //    else if (ddlAssetsSubType.Text == "Running Table" || ddlAssetsSubType.Text == "Plastic Table" || ddlAssetsSubType.Text == "Wooden Table" && lblAssetsType.Text == "Table")
    //    {
    //        lblCompName.Visible = true;
    //        txtCompName.Visible = true;
    //        lblModelName.Visible = true;
    //        txtModelName.Visible = true;
    //        lblWarrantyType.Visible = true;
    //        ddlWarrantyType.Visible = true;
    //    }
    //    else if (ddlAssetsSubType.Text == "Codeless" || ddlAssetsSubType.Text == "Normal" && lblAssetsType.Text == "Telephone")
    //    {
    //        lblCompName.Visible = true;
    //        txtCompName.Visible = true;
    //        lblModelName.Visible = true;
    //        txtModelName.Visible = true;
    //        lblWarrantyType.Visible = true;
    //        ddlWarrantyType.Visible = true;
    //        lblTelephone.Visible = true;
    //        txtTelephone.Visible = true;
    //        lblCallerID.Visible = true;
    //        txtCallerID.Visible = true;
    //        lblStd.Visible = true;
    //        txtStd.Visible = true; 
    //    }
    //    else if (ddlAssetsSubType.Text == "CFL" || ddlAssetsSubType.Text == "Tubelight" && lblAssetsType.Text == "Tubelight")
    //    {
    //        lblCompName.Visible = true;
    //        txtCompName.Visible = true;
    //        lblModelName.Visible = true;
    //        txtModelName.Visible = true;
    //        lblWarrantyType.Visible = true;
    //        ddlWarrantyType.Visible = true;
    //        lblWatt.Visible = true;
    //        txtWatt.Visible = true; 
    //    }
    //    else if (ddlAssetsSubType.Text == "Table Watch" || ddlAssetsSubType.Text == "Wall Watch" && lblAssetsType.Text == "Watch")
    //    {
    //        lblCompName.Visible = true;
    //        txtCompName.Visible = true;
    //        lblModelName.Visible = true;
    //        txtModelName.Visible = true;
    //        lblWarrantyType.Visible = true;
    //        ddlWarrantyType.Visible = true;            
    //    }
    //    else if (ddlAssetsSubType.Text == "Split" || ddlAssetsSubType.Text == "Window" && lblAssetsType.Text == "AC")
    //    {
    //        lblCompName.Visible = true;
    //        txtCompName.Visible = true;
    //        lblModelName.Visible = true;
    //        txtModelName.Visible = true;
    //        lblWarrantyType.Visible = true;
    //        ddlWarrantyType.Visible = true;
    //        lblTonn.Visible = true;
    //        txtTonn.Visible = true;
    //    }
    //    else if (ddlAssetsSubType.Text == "TFT" || ddlAssetsSubType.Text == "CRT" || ddlAssetsSubType.Text == "LCD" && lblAssetsType.Text == "PC")
    //    {
    //        lblProcessorName.Visible = true;
    //        txtProcessorName.Visible = true;
    //        lblProcessorSpeed.Visible = true;
    //        txtProcessorSpeed.Visible = true;
    //        lblModelType.Visible = true;
    //        ddlModelType.Visible = true;
    //        lblProcessor.Visible = true;
    //        ddlProcessor.Visible = true;
    //        lblRamType.Visible = true;
    //        ddlRam.Visible = true;
    //        lblHddGb.Visible = true;
    //        ddlHdd.Visible = true;
    //        lblMotherBoardMake.Visible = true;
    //        txtMotherBoardMake.Visible = true; 
    //    }

    //    GetAssetsDespSub();
    //}
    /// <summary>
    /// NIKHIL
    /// </summary>

    private void Get_DescriptionData2()
    {
        CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Get_DescriptionData12";
        sqlcmd.CommandTimeout = 0;

        SqlParameter TransRefNo = new SqlParameter();
        TransRefNo.SqlDbType = SqlDbType.VarChar;
        TransRefNo.Value = hdnTranRefNo.Value;
        TransRefNo.ParameterName = "@TransRefNo";
        sqlcmd.Parameters.Add(TransRefNo);

        //SqlParameter Assets_SubType = new SqlParameter();
        //Assets_SubType.SqlDbType = SqlDbType.VarChar;
        //Assets_SubType.Value = ddlAssetsSubType.Text.Trim();
        //Assets_SubType.ParameterName = "@Assets_SubType";
        //sqlcmd.Parameters.Add(Assets_SubType);

        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;
        DataTable dt = new DataTable();
        sqlda.Fill(dt);
        sqlcon.Close();

        if (dt.Rows.Count > 0)
        {
            txtCompName.Text = dt.Rows[0]["CompName"].ToString().Trim();
            txtModelName.Text = dt.Rows[0]["ModelName"].ToString().Trim();
            ddlWarrantyType.SelectedValue = dt.Rows[0]["WarrantyType"].ToString().Trim();
            txtCassetteCD.Text = dt.Rows[0]["CassetteCD"].ToString().Trim();
            ddlUsbPortAvil.SelectedValue = dt.Rows[0]["UsbPortAvil"].ToString().Trim();
            txtTotalRacks.Text = dt.Rows[0]["TotalRacks"].ToString().Trim();
            ddlLockerAvil.SelectedValue = dt.Rows[0]["LockerAvil"].ToString().Trim();
            txtPrintCapacity.Text = dt.Rows[0]["PrintCapacity"].ToString().Trim();
            txtOthFeature.Text = dt.Rows[0]["OthFeature"].ToString().Trim();
            txtCountDraw.Text = dt.Rows[0]["CountDraw"].ToString().Trim();
            txtBlockingLock.Text = dt.Rows[0]["BlockingLock"].ToString().Trim();
            txtSensorResu.Text = dt.Rows[0]["SensorResu"].ToString().Trim();
            txtSensorType.Text = dt.Rows[0]["SensorType"].ToString().Trim();
            txtManualFocus.Text = dt.Rows[0]["ManualFocus"].ToString().Trim();
            txtScreenSize.Text = dt.Rows[0]["ScreenSize"].ToString().Trim();
            ddlRechargeBett.SelectedValue = dt.Rows[0]["RechargeBett"].ToString().Trim();
            ddlConnectivity.SelectedValue = dt.Rows[0]["Connectivity"].ToString().Trim();
            txtTotalBatt.Text = dt.Rows[0]["TotalBatt"].ToString().Trim();
            txtPushBack.Text = dt.Rows[0]["PushBack"].ToString().Trim();
            txtFoldingChair.Text = dt.Rows[0]["FoldingChair"].ToString().Trim();
            txtPlainPaper.Text = dt.Rows[0]["PlainPaper"].ToString().Trim();
            txtColour.Text = dt.Rows[0]["Colour"].ToString().Trim();
            txtPowerOffDial.Text = dt.Rows[0]["PowerOffDial"].ToString().Trim();
            txtFaxPrintSpeed.Text = dt.Rows[0]["FaxPrintSpeed"].ToString().Trim();
            txtCompPrintCap.Text = dt.Rows[0]["CompPrintCap"].ToString().Trim();
            txtPrintCartg.Text = dt.Rows[0]["PrintCartg"].ToString().Trim();
            txtSpeakerPH.Text = dt.Rows[0]["SpeakerPH"].ToString().Trim();
            txtMaxPaperCap.Text = dt.Rows[0]["MaxPaperCap"].ToString().Trim();
            txtAlarmIndi.Text = dt.Rows[0]["AlarmIndi"].ToString().Trim();
            txtInbuiltAnsMach.Text = dt.Rows[0]["InbuiltAnsMach"].ToString().Trim();
            txtProcessorName.Text = dt.Rows[0]["ProcessorName"].ToString().Trim();
            txtPassUserRestric.Text = dt.Rows[0]["PassUserRestric"].ToString().Trim();
            txtProcessorSpeed.Text = dt.Rows[0]["ProcessorSpeed"].ToString().Trim();
            txtStandardRam.Text = dt.Rows[0]["StandardRam"].ToString().Trim();
            txtUpgradeRam.Text = dt.Rows[0]["UpgradeRam"].ToString().Trim();
            txtHardDiskDriveCap.Text = dt.Rows[0]["HardDiskDriveCap"].ToString().Trim();
            txtBatteryType.Text = dt.Rows[0]["BatteryType"].ToString().Trim();
            txtBatteryLife.Text = dt.Rows[0]["BatteryLife"].ToString().Trim();
            txtCameraBuilt.Text = dt.Rows[0]["CameraBuilt"].ToString().Trim();
            txtSpeaker.Text = dt.Rows[0]["Speaker"].ToString().Trim();
            txtBluetooth.Text = dt.Rows[0]["Bluetooth"].ToString().Trim();
            txtSmartPh.Text = dt.Rows[0]["SmartPh"].ToString().Trim();
            txtTouchScreen.Text = dt.Rows[0]["TouchScreen"].ToString().Trim();
            txtConfCall.Text = dt.Rows[0]["ConfCall"].ToString().Trim();
            txtMemCard.Text = dt.Rows[0]["MemCard"].ToString().Trim();
            txtMemCardSize.Text = dt.Rows[0]["MemCardSize"].ToString().Trim();
            txtRouterSpeed.Text = dt.Rows[0]["RouterSpeed"].ToString().Trim();
            ddlProcessor.SelectedValue = dt.Rows[0]["Processor"].ToString().Trim();
            ddlRam.SelectedValue = dt.Rows[0]["Ram"].ToString().Trim();
            ddlHdd.SelectedValue = dt.Rows[0]["Hdd"].ToString().Trim();
            txtMotherBoardMake.Text = dt.Rows[0]["MotherBoardMake"].ToString().Trim();
            txtAutomaticDocu.Text = dt.Rows[0]["AutomaticDocu"].ToString().Trim();
            txtTotalPort.Text = dt.Rows[0]["TotalPort"].ToString().Trim();
            ddlModelType.SelectedValue = dt.Rows[0]["ModelType"].ToString().Trim();
            txtSpeakerType.Text = dt.Rows[0]["SpeakerType"].ToString().Trim();
            txtOpticalCharReco.Text = dt.Rows[0]["OpticalCharReco"].ToString().Trim();
            txtSpeakerPorts.Text = dt.Rows[0]["SpeakerPorts"].ToString().Trim();
            txtWatt.Text = dt.Rows[0]["Watt"].ToString().Trim();
            txtTonn.Text = dt.Rows[0]["Tonn"].ToString().Trim();
            txtTextEnhanTech.Text = dt.Rows[0]["TextEnhanTech"].ToString().Trim();
            txtTelephone.Text = dt.Rows[0]["Telephone"].ToString().Trim();
            txtCallerID.Text = dt.Rows[0]["CallerID"].ToString().Trim();
            txtStd.Text = dt.Rows[0]["Std"].ToString().Trim();
            txtRouter.Text = dt.Rows[0]["Router"].ToString().Trim();
            txtValidity.Text = dt.Rows[0]["Validity"].ToString().Trim();
            ddlbatteryCount.SelectedValue = dt.Rows[0]["NoOfBatteries"].ToString().Trim();
            ddltable.SelectedValue = dt.Rows[0]["W_table"].ToString().Trim();
            txtcapacity.Text = dt.Rows[0]["UserCapacity"].ToString().Trim();

        }
    }

    //private void GetAssetsDespSub()
    //{ 
    //  CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
    //    sqlcon.Open();

    //    SqlCommand sqlcmd = new SqlCommand();
    //    sqlcmd.Connection = sqlcon;
    //    sqlcmd.CommandType = CommandType.StoredProcedure;
    //    sqlcmd.CommandText = "Get_AssetsSubTypeDetail";
    //    sqlcmd.CommandTimeout = 0;

    //    SqlParameter TransRefNo = new SqlParameter();
    //    TransRefNo.SqlDbType = SqlDbType.VarChar;
    //    TransRefNo.Value = hdnEmpId.Value;
    //    TransRefNo.ParameterName = "@TransRefNo";
    //    sqlcmd.Parameters.Add(TransRefNo);

    //    SqlParameter Assets_SubType = new SqlParameter();
    //    Assets_SubType.SqlDbType = SqlDbType.VarChar;
    //    Assets_SubType.Value = ddlAssetsSubType.Text.Trim();
    //    Assets_SubType.ParameterName = "@Assets_SubType";
    //    sqlcmd.Parameters.Add(Assets_SubType);

    //    SqlDataAdapter sqlda = new SqlDataAdapter();
    //    sqlda.SelectCommand = sqlcmd;
    //    DataTable dt = new DataTable();
    //    sqlda.Fill(dt);
    //    sqlcon.Close();

    //    if (dt.Rows.Count > 0)
    //    {
    //        txtCompName.Text = dt.Rows[0]["CompName"].ToString().Trim();
    //        txtModelName.Text = dt.Rows[0]["ModelName"].ToString().Trim();
    //        ddlWarrantyType.SelectedValue = dt.Rows[0]["WarrantyType"].ToString().Trim();
    //        txtCassetteCD.Text = dt.Rows[0]["CassetteCD"].ToString().Trim();
    //        ddlUsbPortAvil.SelectedValue = dt.Rows[0]["UsbPortAvil"].ToString().Trim();
    //        txtTotalRacks.Text = dt.Rows[0]["TotalRacks"].ToString().Trim();
    //        ddlLockerAvil.SelectedValue = dt.Rows[0]["LockerAvil"].ToString().Trim();
    //        txtPrintCapacity.Text = dt.Rows[0]["PrintCapacity"].ToString().Trim();
    //        txtOthFeature.Text = dt.Rows[0]["OthFeature"].ToString().Trim();
    //        txtCountDraw.Text = dt.Rows[0]["CountDraw"].ToString().Trim();
    //        txtBlockingLock.Text = dt.Rows[0]["BlockingLock"].ToString().Trim();
    //        txtSensorResu.Text = dt.Rows[0]["SensorResu"].ToString().Trim();
    //        txtSensorType.Text = dt.Rows[0]["SensorType"].ToString().Trim();
    //        txtManualFocus.Text = dt.Rows[0]["ManualFocus"].ToString().Trim();
    //        txtScreenSize.Text = dt.Rows[0]["ScreenSize"].ToString().Trim();
    //        ddlRechargeBett.SelectedValue = dt.Rows[0]["RechargeBett"].ToString().Trim();
    //        ddlConnectivity.SelectedValue = dt.Rows[0]["Connectivity"].ToString().Trim();
    //        txtTotalBatt.Text = dt.Rows[0]["TotalBatt"].ToString().Trim();
    //        txtPushBack.Text = dt.Rows[0]["PushBack"].ToString().Trim();
    //        txtFoldingChair.Text = dt.Rows[0]["FoldingChair"].ToString().Trim();
    //        txtPlainPaper.Text = dt.Rows[0]["PlainPaper"].ToString().Trim();
    //        txtColour.Text = dt.Rows[0]["Colour"].ToString().Trim();
    //        txtPowerOffDial.Text = dt.Rows[0]["PowerOffDial"].ToString().Trim();
    //        txtFaxPrintSpeed.Text = dt.Rows[0]["FaxPrintSpeed"].ToString().Trim();
    //        txtCompPrintCap.Text = dt.Rows[0]["CompPrintCap"].ToString().Trim();
    //        txtPrintCartg.Text = dt.Rows[0]["PrintCartg"].ToString().Trim();
    //        txtSpeakerPH.Text = dt.Rows[0]["SpeakerPH"].ToString().Trim();
    //        txtMaxPaperCap.Text = dt.Rows[0]["MaxPaperCap"].ToString().Trim();
    //        txtAlarmIndi.Text = dt.Rows[0]["AlarmIndi"].ToString().Trim();
    //        txtInbuiltAnsMach.Text = dt.Rows[0]["InbuiltAnsMach"].ToString().Trim();
    //        txtProcessorName.Text = dt.Rows[0]["ProcessorName"].ToString().Trim();
    //        txtPassUserRestric.Text = dt.Rows[0]["PassUserRestric"].ToString().Trim();
    //        txtProcessorSpeed.Text = dt.Rows[0]["ProcessorSpeed"].ToString().Trim();
    //        txtStandardRam.Text = dt.Rows[0]["StandardRam"].ToString().Trim();
    //        txtUpgradeRam.Text = dt.Rows[0]["UpgradeRam"].ToString().Trim();
    //        txtHardDiskDriveCap.Text = dt.Rows[0]["HardDiskDriveCap"].ToString().Trim();
    //        txtBatteryType.Text = dt.Rows[0]["BatteryType"].ToString().Trim();
    //        txtBatteryLife.Text = dt.Rows[0]["BatteryLife"].ToString().Trim();
    //        txtCameraBuilt.Text = dt.Rows[0]["CameraBuilt"].ToString().Trim();
    //        txtSpeaker.Text = dt.Rows[0]["Speaker"].ToString().Trim();
    //        txtBluetooth.Text = dt.Rows[0]["Bluetooth"].ToString().Trim();
    //        txtSmartPh.Text = dt.Rows[0]["SmartPh"].ToString().Trim();
    //        txtTouchScreen.Text = dt.Rows[0]["TouchScreen"].ToString().Trim();
    //        txtConfCall.Text = dt.Rows[0]["ConfCall"].ToString().Trim();
    //        txtMemCard.Text = dt.Rows[0]["MemCard"].ToString().Trim();
    //        txtMemCardSize.Text = dt.Rows[0]["MemCardSize"].ToString().Trim();
    //        txtRouterSpeed.Text = dt.Rows[0]["RouterSpeed"].ToString().Trim();
    //        ddlProcessor.SelectedValue = dt.Rows[0]["Processor"].ToString().Trim();
    //        ddlRam.SelectedValue = dt.Rows[0]["Ram"].ToString().Trim();
    //        ddlHdd.SelectedValue = dt.Rows[0]["Hdd"].ToString().Trim();
    //        txtMotherBoardMake.Text = dt.Rows[0]["MotherBoardMake"].ToString().Trim();
    //        txtAutomaticDocu.Text = dt.Rows[0]["AutomaticDocu"].ToString().Trim();
    //        txtTotalPort.Text = dt.Rows[0]["TotalPort"].ToString().Trim();
    //        ddlModelType.SelectedValue = dt.Rows[0]["ModelType"].ToString().Trim();
    //        txtSpeakerType.Text = dt.Rows[0]["SpeakerType"].ToString().Trim();
    //        txtOpticalCharReco.Text = dt.Rows[0]["OpticalCharReco"].ToString().Trim();
    //        txtSpeakerPorts.Text = dt.Rows[0]["SpeakerPorts"].ToString().Trim();
    //        txtWatt.Text = dt.Rows[0]["Watt"].ToString().Trim();
    //        txtTonn.Text = dt.Rows[0]["Tonn"].ToString().Trim();
    //        txtTextEnhanTech.Text = dt.Rows[0]["TextEnhanTech"].ToString().Trim();
    //        txtTelephone.Text = dt.Rows[0]["Telephone"].ToString().Trim();
    //        txtCallerID.Text = dt.Rows[0]["CallerID"].ToString().Trim();
    //        txtStd.Text = dt.Rows[0]["Std"].ToString().Trim();
    //        txtRouter.Text = dt.Rows[0]["Router"].ToString().Trim();
    //        txtValidity.Text = dt.Rows[0]["Validity"].ToString().Trim();            
    //    }
    //}

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            bool result = Validation();

            if (result)
            {
                CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
                sqlcon.Open();

                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "Insert_AssetsDiscriptionDetailsMod1";
                sqlcmd.CommandTimeout = 0;

                SqlParameter TransRefNo = new SqlParameter();
                TransRefNo.SqlDbType = SqlDbType.VarChar;
                TransRefNo.Value = hdnTranRefNo.Value;
                TransRefNo.ParameterName = "@TransRefNo";
                sqlcmd.Parameters.Add(TransRefNo);

                SqlParameter Assets_Type = new SqlParameter();
                Assets_Type.SqlDbType = SqlDbType.VarChar;
                Assets_Type.Value = lblAssetsType.Text.Trim();
                Assets_Type.ParameterName = "@Assets_Type";
                sqlcmd.Parameters.Add(Assets_Type);

                //if (ddlAssetsSubType.SelectedValue == "")
                //{
                //    SqlParameter Assets_SubType = new SqlParameter();
                //    Assets_SubType.SqlDbType = SqlDbType.VarChar;
                //    Assets_SubType.Value = Lblassetssubtype.Text.Trim();
                //    Assets_SubType.ParameterName = "@Assets_SubType";
                //    sqlcmd.Parameters.Add(Assets_SubType);
                //}
                //else
                //{

                SqlParameter Assets_SubType = new SqlParameter();
                Assets_SubType.SqlDbType = SqlDbType.VarChar;
                Assets_SubType.Value = ddlAssetsSubType.SelectedValue.ToString();
                Assets_SubType.ParameterName = "@Assets_SubType";
                sqlcmd.Parameters.Add(Assets_SubType);
                //}


                SqlParameter CompName = new SqlParameter();
                CompName.SqlDbType = SqlDbType.VarChar;
                CompName.Value = txtCompName.Text.Trim();
                CompName.ParameterName = "@CompName";
                sqlcmd.Parameters.Add(CompName);

                SqlParameter ModelName = new SqlParameter();
                ModelName.SqlDbType = SqlDbType.VarChar;
                ModelName.Value = txtModelName.Text.Trim();
                ModelName.ParameterName = "@ModelName";
                sqlcmd.Parameters.Add(ModelName);

                SqlParameter WarrantyType = new SqlParameter();
                WarrantyType.SqlDbType = SqlDbType.VarChar;
                WarrantyType.Value = ddlWarrantyType.SelectedValue.ToString();
                WarrantyType.ParameterName = "@WarrantyType";
                sqlcmd.Parameters.Add(WarrantyType);

                SqlParameter CassetteCD = new SqlParameter();
                CassetteCD.SqlDbType = SqlDbType.VarChar;
                CassetteCD.Value = txtCassetteCD.Text.Trim();
                CassetteCD.ParameterName = "@CassetteCD";
                sqlcmd.Parameters.Add(CassetteCD);

                SqlParameter UsbPortAvil = new SqlParameter();
                UsbPortAvil.SqlDbType = SqlDbType.VarChar;
                UsbPortAvil.Value = ddlUsbPortAvil.SelectedValue.ToString();
                UsbPortAvil.ParameterName = "@UsbPortAvil";
                sqlcmd.Parameters.Add(UsbPortAvil);

                SqlParameter TotalRacks = new SqlParameter();
                TotalRacks.SqlDbType = SqlDbType.VarChar;
                TotalRacks.Value = txtTotalRacks.Text.Trim();
                TotalRacks.ParameterName = "@TotalRacks";
                sqlcmd.Parameters.Add(TotalRacks);

                SqlParameter LockerAvil = new SqlParameter();
                LockerAvil.SqlDbType = SqlDbType.VarChar;
                LockerAvil.Value = ddlLockerAvil.SelectedValue.ToString();
                LockerAvil.ParameterName = "@LockerAvil";
                sqlcmd.Parameters.Add(LockerAvil);

                SqlParameter PrintCapacity = new SqlParameter();
                PrintCapacity.SqlDbType = SqlDbType.VarChar;
                PrintCapacity.Value = txtPrintCapacity.Text.Trim();
                PrintCapacity.ParameterName = "@PrintCapacity";
                sqlcmd.Parameters.Add(PrintCapacity);

                SqlParameter OthFeature = new SqlParameter();
                OthFeature.SqlDbType = SqlDbType.VarChar;
                OthFeature.Value = txtOthFeature.Text.Trim();
                OthFeature.ParameterName = "@OthFeature";
                sqlcmd.Parameters.Add(OthFeature);

                SqlParameter CountDraw = new SqlParameter();
                CountDraw.SqlDbType = SqlDbType.VarChar;
                CountDraw.Value = txtCountDraw.Text.Trim();
                CountDraw.ParameterName = "@CountDraw";
                sqlcmd.Parameters.Add(CountDraw);

                SqlParameter BlockingLock = new SqlParameter();
                BlockingLock.SqlDbType = SqlDbType.VarChar;
                BlockingLock.Value = txtBlockingLock.Text.Trim();
                BlockingLock.ParameterName = "@BlockingLock";
                sqlcmd.Parameters.Add(BlockingLock);

                SqlParameter SensorResu = new SqlParameter();
                SensorResu.SqlDbType = SqlDbType.VarChar;
                SensorResu.Value = txtSensorResu.Text.Trim();
                SensorResu.ParameterName = "@SensorResu";
                sqlcmd.Parameters.Add(SensorResu);

                SqlParameter SensorType = new SqlParameter();
                SensorType.SqlDbType = SqlDbType.VarChar;
                SensorType.Value = txtSensorType.Text.Trim();
                SensorType.ParameterName = "@SensorType";
                sqlcmd.Parameters.Add(SensorType);

                SqlParameter ManualFocus = new SqlParameter();
                ManualFocus.SqlDbType = SqlDbType.VarChar;
                ManualFocus.Value = txtManualFocus.Text.Trim();
                ManualFocus.ParameterName = "@ManualFocus";
                sqlcmd.Parameters.Add(ManualFocus);

                SqlParameter ScreenSize = new SqlParameter();
                ScreenSize.SqlDbType = SqlDbType.VarChar;
                ScreenSize.Value = txtScreenSize.Text.Trim();
                ScreenSize.ParameterName = "@ScreenSize";
                sqlcmd.Parameters.Add(ScreenSize);

                SqlParameter RechargeBett = new SqlParameter();
                RechargeBett.SqlDbType = SqlDbType.VarChar;
                RechargeBett.Value = ddlRechargeBett.SelectedValue.ToString();
                RechargeBett.ParameterName = "@RechargeBett";
                sqlcmd.Parameters.Add(RechargeBett);

                SqlParameter Connectivity = new SqlParameter();
                Connectivity.SqlDbType = SqlDbType.VarChar;
                Connectivity.Value = ddlConnectivity.SelectedValue.ToString();
                Connectivity.ParameterName = "@Connectivity";
                sqlcmd.Parameters.Add(Connectivity);

                SqlParameter TotalBatt = new SqlParameter();
                TotalBatt.SqlDbType = SqlDbType.VarChar;
                TotalBatt.Value = txtTotalBatt.Text.Trim();
                TotalBatt.ParameterName = "@TotalBatt";
                sqlcmd.Parameters.Add(TotalBatt);

                SqlParameter PushBack = new SqlParameter();
                PushBack.SqlDbType = SqlDbType.VarChar;
                PushBack.Value = txtPushBack.Text.Trim();
                PushBack.ParameterName = "@PushBack";
                sqlcmd.Parameters.Add(PushBack);

                SqlParameter FoldingChair = new SqlParameter();
                FoldingChair.SqlDbType = SqlDbType.VarChar;
                FoldingChair.Value = txtFoldingChair.Text.Trim();
                FoldingChair.ParameterName = "@FoldingChair";
                sqlcmd.Parameters.Add(FoldingChair);

                SqlParameter PlainPaper = new SqlParameter();
                PlainPaper.SqlDbType = SqlDbType.VarChar;
                PlainPaper.Value = txtPlainPaper.Text.Trim();
                PlainPaper.ParameterName = "@PlainPaper";
                sqlcmd.Parameters.Add(PlainPaper);

                SqlParameter Colour = new SqlParameter();
                Colour.SqlDbType = SqlDbType.VarChar;
                Colour.Value = txtColour.Text.Trim();
                Colour.ParameterName = "@Colour";
                sqlcmd.Parameters.Add(Colour);

                SqlParameter PowerOffDial = new SqlParameter();
                PowerOffDial.SqlDbType = SqlDbType.VarChar;
                PowerOffDial.Value = txtPowerOffDial.Text.Trim();
                PowerOffDial.ParameterName = "@PowerOffDial";
                sqlcmd.Parameters.Add(PowerOffDial);

                SqlParameter FaxPrintSpeed = new SqlParameter();
                FaxPrintSpeed.SqlDbType = SqlDbType.VarChar;
                FaxPrintSpeed.Value = txtFaxPrintSpeed.Text.Trim();
                FaxPrintSpeed.ParameterName = "@FaxPrintSpeed";
                sqlcmd.Parameters.Add(FaxPrintSpeed);

                SqlParameter CompPrintCap = new SqlParameter();
                CompPrintCap.SqlDbType = SqlDbType.VarChar;
                CompPrintCap.Value = txtCompPrintCap.Text.Trim();
                CompPrintCap.ParameterName = "@CompPrintCap";
                sqlcmd.Parameters.Add(CompPrintCap);

                SqlParameter PrintCartg = new SqlParameter();
                PrintCartg.SqlDbType = SqlDbType.VarChar;
                PrintCartg.Value = txtPrintCartg.Text.Trim();
                PrintCartg.ParameterName = "@PrintCartg";
                sqlcmd.Parameters.Add(PrintCartg);

                SqlParameter SpeakerPH = new SqlParameter();
                SpeakerPH.SqlDbType = SqlDbType.VarChar;
                SpeakerPH.Value = txtSpeakerPH.Text.Trim();
                SpeakerPH.ParameterName = "@SpeakerPH";
                sqlcmd.Parameters.Add(SpeakerPH);

                SqlParameter MaxPaperCap = new SqlParameter();
                MaxPaperCap.SqlDbType = SqlDbType.VarChar;
                MaxPaperCap.Value = txtMaxPaperCap.Text.Trim();
                MaxPaperCap.ParameterName = "@MaxPaperCap";
                sqlcmd.Parameters.Add(MaxPaperCap);

                SqlParameter AlarmIndi = new SqlParameter();
                AlarmIndi.SqlDbType = SqlDbType.VarChar;
                AlarmIndi.Value = txtAlarmIndi.Text.Trim();
                AlarmIndi.ParameterName = "@AlarmIndi";
                sqlcmd.Parameters.Add(AlarmIndi);

                SqlParameter InbuiltAnsMach = new SqlParameter();
                InbuiltAnsMach.SqlDbType = SqlDbType.VarChar;
                InbuiltAnsMach.Value = txtInbuiltAnsMach.Text.Trim();
                InbuiltAnsMach.ParameterName = "@InbuiltAnsMach";
                sqlcmd.Parameters.Add(InbuiltAnsMach);

                SqlParameter ProcessorName = new SqlParameter();
                ProcessorName.SqlDbType = SqlDbType.VarChar;
                ProcessorName.Value = txtProcessorName.Text.Trim();
                ProcessorName.ParameterName = "@ProcessorName";
                sqlcmd.Parameters.Add(ProcessorName);

                SqlParameter PassUserRestric = new SqlParameter();
                PassUserRestric.SqlDbType = SqlDbType.VarChar;
                PassUserRestric.Value = txtPassUserRestric.Text.Trim();
                PassUserRestric.ParameterName = "@PassUserRestric";
                sqlcmd.Parameters.Add(PassUserRestric);

                SqlParameter ProcessorSpeed = new SqlParameter();
                ProcessorSpeed.SqlDbType = SqlDbType.VarChar;
                ProcessorSpeed.Value = txtProcessorSpeed.Text.Trim();
                ProcessorSpeed.ParameterName = "@ProcessorSpeed";
                sqlcmd.Parameters.Add(ProcessorSpeed);

                SqlParameter StandardRam = new SqlParameter();
                StandardRam.SqlDbType = SqlDbType.VarChar;
                StandardRam.Value = txtStandardRam.Text.Trim();
                StandardRam.ParameterName = "@StandardRam";
                sqlcmd.Parameters.Add(StandardRam);

                SqlParameter UpgradeRam = new SqlParameter();
                UpgradeRam.SqlDbType = SqlDbType.VarChar;
                UpgradeRam.Value = txtUpgradeRam.Text.Trim();
                UpgradeRam.ParameterName = "@UpgradeRam";
                sqlcmd.Parameters.Add(UpgradeRam);

                SqlParameter HardDiskDriveCap = new SqlParameter();
                HardDiskDriveCap.SqlDbType = SqlDbType.VarChar;
                HardDiskDriveCap.Value = txtHardDiskDriveCap.Text.Trim();
                HardDiskDriveCap.ParameterName = "@HardDiskDriveCap";
                sqlcmd.Parameters.Add(HardDiskDriveCap);

                SqlParameter BatteryType = new SqlParameter();
                BatteryType.SqlDbType = SqlDbType.VarChar;
                BatteryType.Value = txtBatteryType.Text.Trim();
                BatteryType.ParameterName = "@BatteryType";
                sqlcmd.Parameters.Add(BatteryType);

                SqlParameter BatteryLife = new SqlParameter();
                BatteryLife.SqlDbType = SqlDbType.VarChar;
                BatteryLife.Value = txtBatteryLife.Text.Trim();
                BatteryLife.ParameterName = "@BatteryLife";
                sqlcmd.Parameters.Add(BatteryLife);

                SqlParameter CameraBuilt = new SqlParameter();
                CameraBuilt.SqlDbType = SqlDbType.VarChar;
                CameraBuilt.Value = txtCameraBuilt.Text.Trim();
                CameraBuilt.ParameterName = "@CameraBuilt";
                sqlcmd.Parameters.Add(CameraBuilt);

                SqlParameter Speaker = new SqlParameter();
                Speaker.SqlDbType = SqlDbType.VarChar;
                Speaker.Value = txtSpeaker.Text.Trim();
                Speaker.ParameterName = "@Speaker";
                sqlcmd.Parameters.Add(Speaker);

                SqlParameter Bluetooth = new SqlParameter();
                Bluetooth.SqlDbType = SqlDbType.VarChar;
                Bluetooth.Value = txtBluetooth.Text.Trim();
                Bluetooth.ParameterName = "@Bluetooth";
                sqlcmd.Parameters.Add(Bluetooth);

                SqlParameter SmartPh = new SqlParameter();
                SmartPh.SqlDbType = SqlDbType.VarChar;
                SmartPh.Value = txtSmartPh.Text.Trim();
                SmartPh.ParameterName = "@SmartPh";
                sqlcmd.Parameters.Add(SmartPh);

                SqlParameter TouchScreen = new SqlParameter();
                TouchScreen.SqlDbType = SqlDbType.VarChar;
                TouchScreen.Value = txtTouchScreen.Text.Trim();
                TouchScreen.ParameterName = "@TouchScreen";
                sqlcmd.Parameters.Add(TouchScreen);

                SqlParameter ConfCall = new SqlParameter();
                ConfCall.SqlDbType = SqlDbType.VarChar;
                ConfCall.Value = txtConfCall.Text.Trim();
                ConfCall.ParameterName = "@ConfCall";
                sqlcmd.Parameters.Add(ConfCall);

                SqlParameter MemCard = new SqlParameter();
                MemCard.SqlDbType = SqlDbType.VarChar;
                MemCard.Value = txtMemCard.Text.Trim();
                MemCard.ParameterName = "@MemCard";
                sqlcmd.Parameters.Add(MemCard);

                SqlParameter MemCardSize = new SqlParameter();
                MemCardSize.SqlDbType = SqlDbType.VarChar;
                MemCardSize.Value = txtMemCardSize.Text.Trim();
                MemCardSize.ParameterName = "@MemCardSize";
                sqlcmd.Parameters.Add(MemCardSize);

                SqlParameter RouterSpeed = new SqlParameter();
                RouterSpeed.SqlDbType = SqlDbType.VarChar;
                RouterSpeed.Value = txtRouterSpeed.Text.Trim();
                RouterSpeed.ParameterName = "@RouterSpeed";
                sqlcmd.Parameters.Add(RouterSpeed);

                SqlParameter Processor = new SqlParameter();
                Processor.SqlDbType = SqlDbType.VarChar;
                Processor.Value = ddlProcessor.SelectedValue.ToString();
                Processor.ParameterName = "@Processor";
                sqlcmd.Parameters.Add(Processor);

                SqlParameter Ram = new SqlParameter();
                Ram.SqlDbType = SqlDbType.VarChar;
                Ram.Value = ddlRam.SelectedValue.ToString();
                Ram.ParameterName = "@Ram";
                sqlcmd.Parameters.Add(Ram);

                SqlParameter Hdd = new SqlParameter();
                Hdd.SqlDbType = SqlDbType.VarChar;
                Hdd.Value = ddlHdd.SelectedValue.ToString();
                Hdd.ParameterName = "@Hdd";
                sqlcmd.Parameters.Add(Hdd);

                SqlParameter MotherBoardMake = new SqlParameter();
                MotherBoardMake.SqlDbType = SqlDbType.VarChar;
                MotherBoardMake.Value = txtMotherBoardMake.Text.Trim();
                MotherBoardMake.ParameterName = "@MotherBoardMake";
                sqlcmd.Parameters.Add(MotherBoardMake);

                SqlParameter AutomaticDocu = new SqlParameter();
                AutomaticDocu.SqlDbType = SqlDbType.VarChar;
                AutomaticDocu.Value = txtAutomaticDocu.Text.Trim();
                AutomaticDocu.ParameterName = "@AutomaticDocu";
                sqlcmd.Parameters.Add(AutomaticDocu);

                SqlParameter TotalPort = new SqlParameter();
                TotalPort.SqlDbType = SqlDbType.VarChar;
                TotalPort.Value = txtTotalPort.Text.Trim();
                TotalPort.ParameterName = "@TotalPort";
                sqlcmd.Parameters.Add(TotalPort);

                SqlParameter ModelType = new SqlParameter();
                ModelType.SqlDbType = SqlDbType.VarChar;
                ModelType.Value = ddlModelType.SelectedValue.ToString();
                ModelType.ParameterName = "@ModelType";
                sqlcmd.Parameters.Add(ModelType);

                SqlParameter SpeakerType = new SqlParameter();
                SpeakerType.SqlDbType = SqlDbType.VarChar;
                SpeakerType.Value = txtSpeakerType.Text.Trim();
                SpeakerType.ParameterName = "@SpeakerType";
                sqlcmd.Parameters.Add(SpeakerType);

                SqlParameter OpticalCharReco = new SqlParameter();
                OpticalCharReco.SqlDbType = SqlDbType.VarChar;
                OpticalCharReco.Value = txtOpticalCharReco.Text.Trim();
                OpticalCharReco.ParameterName = "@OpticalCharReco";
                sqlcmd.Parameters.Add(OpticalCharReco);

                SqlParameter SpeakerPorts = new SqlParameter();
                SpeakerPorts.SqlDbType = SqlDbType.VarChar;
                SpeakerPorts.Value = txtSpeakerPorts.Text.Trim();
                SpeakerPorts.ParameterName = "@SpeakerPorts";
                sqlcmd.Parameters.Add(SpeakerPorts);

                SqlParameter Watt = new SqlParameter();
                Watt.SqlDbType = SqlDbType.VarChar;
                Watt.Value = txtWatt.Text.Trim();
                Watt.ParameterName = "@Watt";
                sqlcmd.Parameters.Add(Watt);

                SqlParameter Tonn = new SqlParameter();
                Tonn.SqlDbType = SqlDbType.VarChar;
                Tonn.Value = txtTonn.Text.Trim();
                Tonn.ParameterName = "@Tonn";
                sqlcmd.Parameters.Add(Tonn);

                SqlParameter TextEnhanTech = new SqlParameter();
                TextEnhanTech.SqlDbType = SqlDbType.VarChar;
                TextEnhanTech.Value = txtTextEnhanTech.Text.Trim();
                TextEnhanTech.ParameterName = "@TextEnhanTech";
                sqlcmd.Parameters.Add(TextEnhanTech);

                SqlParameter Telephone = new SqlParameter();
                Telephone.SqlDbType = SqlDbType.VarChar;
                Telephone.Value = txtTelephone.Text.Trim();
                Telephone.ParameterName = "@Telephone";
                sqlcmd.Parameters.Add(Telephone);

                SqlParameter CallerID = new SqlParameter();
                CallerID.SqlDbType = SqlDbType.VarChar;
                CallerID.Value = txtCallerID.Text.Trim();
                CallerID.ParameterName = "@CallerID";
                sqlcmd.Parameters.Add(CallerID);

                SqlParameter Std = new SqlParameter();
                Std.SqlDbType = SqlDbType.VarChar;
                Std.Value = txtStd.Text.Trim();
                Std.ParameterName = "@Std";
                sqlcmd.Parameters.Add(Std);

                SqlParameter Router = new SqlParameter();
                Router.SqlDbType = SqlDbType.VarChar;
                Router.Value = txtRouter.Text.Trim();
                Router.ParameterName = "@Router";
                sqlcmd.Parameters.Add(Router);

                SqlParameter Validity = new SqlParameter();
                Validity.SqlDbType = SqlDbType.VarChar;
                Validity.Value = txtValidity.Text.Trim();
                Validity.ParameterName = "@Validity";
                sqlcmd.Parameters.Add(Validity);

                SqlParameter Encodingtype = new SqlParameter();
                Encodingtype.SqlDbType = SqlDbType.VarChar;
                Encodingtype.Value = ddlEncodingType.SelectedValue.ToString();
                Encodingtype.ParameterName = "@Encodingtype";
                sqlcmd.Parameters.Add(Encodingtype);

                SqlParameter Cartridge = new SqlParameter();
                Cartridge.SqlDbType = SqlDbType.VarChar;
                Cartridge.Value = txtCartridge.Text.Trim();
                Cartridge.ParameterName = "@Cartridge";
                sqlcmd.Parameters.Add(Cartridge);

                SqlParameter KeyBoard = new SqlParameter();
                KeyBoard.SqlDbType = SqlDbType.VarChar;
                KeyBoard.Value = ddlKeyboard.SelectedValue.ToString();
                KeyBoard.ParameterName = "@KeyBoard";
                sqlcmd.Parameters.Add(KeyBoard);

                SqlParameter Mouse = new SqlParameter();
                Mouse.SqlDbType = SqlDbType.VarChar;
                Mouse.Value = ddlMouse.SelectedValue.ToString();
                Mouse.ParameterName = "@Mouse";
                sqlcmd.Parameters.Add(Mouse);

                SqlParameter BackupTime = new SqlParameter();
                BackupTime.SqlDbType = SqlDbType.VarChar;
                BackupTime.Value = txtBackupTime.Text.Trim();
                BackupTime.ParameterName = "@BackupTime";
                sqlcmd.Parameters.Add(BackupTime);

                SqlParameter NoOfBatteries = new SqlParameter();
                NoOfBatteries.SqlDbType = SqlDbType.VarChar;
                NoOfBatteries.Value = ddlbatteryCount.SelectedValue.ToString();
                NoOfBatteries.ParameterName = "@NoOfBatteries";
                sqlcmd.Parameters.Add(NoOfBatteries);

                SqlParameter W_table = new SqlParameter();
                W_table.SqlDbType = SqlDbType.VarChar;
                W_table.Value = ddltable.SelectedValue.ToString();
                W_table.ParameterName = "@W_table";
                sqlcmd.Parameters.Add(W_table);

                SqlParameter capacity = new SqlParameter();
                capacity.SqlDbType = SqlDbType.VarChar;
                capacity.Value = txtcapacity.Text.ToString().Trim();
                capacity.ParameterName = "@UserCapacity";
                sqlcmd.Parameters.Add(capacity);

                SqlParameter UserId = new SqlParameter();
                UserId.SqlDbType = SqlDbType.VarChar;
                UserId.Value = Session["UserId"].ToString();
                UserId.ParameterName = "@UserId";
                sqlcmd.Parameters.Add(UserId);

                int i = sqlcmd.ExecuteNonQuery();
                sqlcon.Close();
                if (i > 0)
                {
                    lblMessage.Text = "Record Saved Sucessfully. Transaction ID : " + hdnTranRefNo.Value;
                }
                else
                {

                }
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }

    protected void btnCan_Click(object sender, EventArgs e)
    {

        Response.Redirect("Assets_InventoryView.aspx?CentreID=" + hdnCentre.Value + "&SubCentreID=" + hdnSubcentre.Value + "&TranRefNo=" + hdnTranRefNo.Value + "&AssetType=" + hdnAssetType.Value + "&EmpCode=" + hdnEmpCode.Value);
    }
    protected bool Validation()
    {
        bool validationResult = true;
        string msg = string.Empty;

        if (lblAssetsType.Text == "PC")
        {
            if (ddlAssetsSubType.SelectedValue == "--Select--")
            {
                msg = msg + "Please Select Assets Sub Type";
            }
            if (txtCompName.Text.Trim() == "")
            {
                msg = msg + "Please Enter CompName";
            }
            if (txtModelName.Text.Trim() == "")
            {
                msg = msg + "Please Enter ModelName";
            }
            if (ddlWarrantyType.SelectedValue == "NA")
            {
                msg = msg + "Please Select WarrantyType";
            }
            if (txtProcessorName.Text == "")
            {
                msg = msg + "Please Enter ProcessorName";
            }
            if (ddlRam.SelectedValue == "NA")
            {
                msg = msg + "Please Select RAM Type";
            }
            if (ddlHdd.SelectedValue == "NA")
            {
                msg = msg + "Please Select HDD In GB";
            }
            if (txtMotherBoardMake.Text == "")
            {
                msg = msg + "Please Enter Mother Board Make By";
            }
            if (ddlKeyboard.SelectedValue == "NA")
            {
                msg = msg + "Please Select KeyBoard";
            }
            if (ddlMouse.SelectedValue == "NA")
            {
                msg = msg + "Please Select Mouse";
            }
            if (ddlProcessor.SelectedValue == "NA")
            {
                msg = msg + "Please Select Processesor/Model Speed";
            }
        }
        else if (lblAssetsType.Text == "LT")
        {
            if (txtCompName.Text == "")
            {
                msg = msg + "Please Enter Company Name";
            }
            if (txtModelName.Text == "")
            {
                msg = msg + "Please Enter Model Name";
            }
            if (ddlWarrantyType.SelectedValue == "NA")
            {
                msg = msg + "Please Select Warranty Type";
            }
            if (ddlUsbPortAvil.SelectedValue == "NA")
            {
                msg = msg + "Please Select USB Port Available";
            }
            if (txtProcessorName.Text == "")
            {
                msg = msg + "Please Enter Processor Name ";
            }
            if (txtProcessorSpeed.Text == "")
            {
                msg = msg + "Please Enter Processor Speed (MHz)";
            }
            if (txtStandardRam.Text == "")
            {
                msg = msg + "Please Enter Standard RAM (MB)";
            }
            if (txtUpgradeRam.Text == "")
            {
                msg = msg + "Please Enter Upgradeable RAM (MB)";
            }
            if (txtHardDiskDriveCap.Text == "")
            {
                msg = msg + "Please Enter Inbuilt Hard Disk Drive Capacity (GB)";
            }
            if (txtBatteryType.Text == "")
            {
                msg = msg + "Please Enter Battery (Type)";
            }
            if (txtBatteryLife.Text == "")
            {
                msg = msg + "Please Enter Battery Life (Hours)";
            }
            if (txtCameraBuilt.Text == "")
            {
                msg = msg + "Please Enter Built in Camera ";
            }
            if (txtSpeaker.Text == "")
            {
                msg = msg + "Please Enter Speaker";
            }
            if (txtBluetooth.Text == "")
            {
                msg = msg + "Please Enter Bluetooth";
            }
        }
        else if (lblAssetsType.Text == "CH")
        {
            if (ddlAssetsSubType.SelectedValue == "--Select--")
            {
                msg = msg + "Please Select Assets Sub Type";
            }
            if (txtCompName.Text == "")
            {
                msg = msg + "Please Enter Company Name";
            }
            if (txtModelName.Text == "")
            {
                msg = msg + "Please Enter Model Name";
            }
            if (ddlWarrantyType.SelectedValue == "NA")
            {
                msg = msg + "Please Select Warranty Type";
            }
            if (txtPushBack.Text == "")
            {
                msg = msg + "Please Enter Push Back";
            }
            if (txtFoldingChair.Text == "")
            {
                msg = msg + "Please Enter Folding Chair / Weel Chai";
            }
        }
        else if (lblAssetsType.Text == "AC")
        {
            if (ddlAssetsSubType.SelectedValue == "--Select--")
            {
                msg = msg + "Please Select Assets Sub Type";
            }
            if (txtCompName.Text == "")
            {
                msg = msg + "Please Enter Company Name";
            }
            if (txtModelName.Text == "")
            {
                msg = msg + "Please Enter Model Name";
            }
            if (ddlWarrantyType.SelectedValue == "NA")
            {
                msg = msg + "Please Select Warranty Type";
            }
            if (txtTonn.Text == "")
            {
                msg = msg + "Please Enter Tonn";
            }
        }
        else if (lblAssetsType.Text == "CM")
        {
            if (ddlAssetsSubType.SelectedValue == "--Select--")
            {
                msg = msg + "Please Select Assets Sub Type";
            }
            if (txtCompName.Text == "")
            {
                msg = msg + "Please Enter Company Name";
            }
            if (txtModelName.Text == "")
            {
                msg = msg + "Please Enter Model Name";
            }
            if (ddlWarrantyType.SelectedValue == "NA")
            {
                msg = msg + "Please Select Warranty Type";
            }
            if (txtSensorResu.Text == "")
            {
                msg = msg + "Please Enter Sensor resulation";
            }
            if (txtSensorType.Text == "")
            {
                msg = msg + "Please Enter Seonsor Type";
            }
            if (txtManualFocus.Text == "")
            {
                msg = msg + "Please Enter Manual Focus";
            }
            if (txtScreenSize.Text == "")
            {
                msg = msg + "Please Enter Screen Size";
            }
            if (ddlConnectivity.SelectedValue == "NA")
            {
                msg = msg + "Please Select Connectivity";
            }
            if (txtBatteryType.Text == "")
            {
                msg = msg + "Please Enter Recharegeable Battaries";
            }
            if (txtBatteryLife.Text == "")
            {
                msg = msg + "Please Enter Total Battaries";
            }
        }
        else if (lblAssetsType.Text == "TP")
        {
            if (ddlAssetsSubType.SelectedValue == "--Select--")
            {
                msg = msg + "Please Select Assets Sub Type";
            }
            if (txtCompName.Text == "")
            {
                msg = msg + "Please Enter Company Name";
            }
            if (txtModelName.Text == "")
            {
                msg = msg + "Please Enter Model Name";
            }
            if (ddlWarrantyType.SelectedValue == "NA")
            {
                msg = msg + "Please Select Warranty Type";
            }
            if (txtTelephone.Text == "")
            {
                msg = msg + "Please Enter Telephone";
            }
            if (txtCallerID.Text == "")
            {
                msg = msg + "Please Enter Caller ID";
            }
            if (txtStd.Text == "")
            {
                msg = msg + "Please Enter STD";
            }
        }
        else if (lblAssetsType.Text == "SC")
        {
            if (ddlAssetsSubType.SelectedValue == "--Select--")
            {
                msg = msg + "Please Select Assets Sub Type";
            }
            if (txtCompName.Text == "")
            {
                msg = msg + "Please Enter Company Name";
            }
            if (txtModelName.Text == "")
            {
                msg = msg + "Please Enter Model Name";
            }
            if (ddlWarrantyType.SelectedValue == "NA")
            {
                msg = msg + "Please Select Warranty Type";
            }
            if (ddlUsbPortAvil.SelectedValue == "NA")
            {
                msg = msg + "Please Select USB Port Available";
            }
            if (txtPrintCapacity.Text == "")
            {
                msg = msg + "Please Enter Print Capacity - Pages per min";
            }
            if (txtAutomaticDocu.Text == "")
            {
                msg = msg + "Please Enter Automatic Document Feeder";
            }
            if (txtOpticalCharReco.Text == "")
            {
                msg = msg + "Please Enter Optical Character Recongnition";
            }
            if (txtTextEnhanTech.Text == "")
            {
                msg = msg + "Please Enter Text Enhanced Technology";
            }
        }
        else if (lblAssetsType.Text == "SW")
        {
            if (txtCompName.Text == "")
            {
                msg = msg + "Please Enter Company Name";
            }
            if (txtModelName.Text == "")
            {
                msg = msg + "Please Enter Model Name";
            }
            if (ddlWarrantyType.SelectedValue == "NA")
            {
                msg = msg + "Please Select Warranty Type";
            }
        }
        else if (lblAssetsType.Text == "WB")
        {
            if (txtCompName.Text == "")
            {
                msg = msg + "Please Enter Company Name";
            }
            if (txtModelName.Text == "")
            {
                msg = msg + "Please Enter Model Name";
            }
            if (ddlWarrantyType.SelectedValue == "NA")
            {
                msg = msg + "Please Select Warranty Type";
            }
        }
        else if (lblAssetsType.Text == "RT")
        {
            if (txtCompName.Text == "")
            {
                msg = msg + "Please Enter Company Name";
            }
            if (txtModelName.Text == "")
            {
                msg = msg + "Please Enter Model Name";
            }
            if (ddlWarrantyType.SelectedValue == "NA")
            {
                msg = msg + "Please Select Warranty Type";
            }
            if (txtRouterSpeed.Text == "")
            {
                msg = msg + "Please Enter Speed of the Router";
            }
            if (txtTotalPort.Text == "")
            {
                msg = msg + "Please Enter Total Port";
            }
            if (txtRouter.Text == "")
            {
                msg = msg + "Please Enter Router";
            }
        }
        else if (lblAssetsType.Text == "FEX")
        {
            if (txtCompName.Text == "")
            {
                msg = msg + "Please Enter Company Name";
            }
            if (txtModelName.Text == "")
            {
                msg = msg + "Please Enter Model Name";
            }
            if (ddlWarrantyType.SelectedValue == "NA")
            {
                msg = msg + "Please Select Warranty Type";
            }
        }
        else if (lblAssetsType.Text == "NB")
        {
            if (ddlAssetsSubType.SelectedValue == "--Select--")
            {
                msg = msg + "Please Select Assets Sub Type";
            }
            if (txtCompName.Text == "")
            {
                msg = msg + "Please Enter Company Name";
            }
        }
        else if (lblAssetsType.Text == "PSHM")
        {
            if (ddlAssetsSubType.SelectedValue == "--Select--")
            {
                msg = msg + "Please Select Assets Sub Type";
            }
            if (txtCompName.Text == "")
            {
                msg = msg + "Please Enter Company Name";
            }
        }
        else if (lblAssetsType.Text == "BIOM")
        {
            if (ddlAssetsSubType.SelectedValue == "--Select--")
            {
                msg = msg + "Please Select Assets Sub Type";
            }
        }
        else if (lblAssetsType.Text == "FN")
        {
            if (ddlAssetsSubType.SelectedValue == "--Select--")
            {
                msg = msg + "Please Select Assets Sub Type";
            }
            if (txtCompName.Text == "")
            {
                msg = msg + "Please Enter Company Name";
            }
            if (txtModelName.Text == "")
            {
                msg = msg + "Please Enter Model Name";
            }
            if (ddlWarrantyType.SelectedValue == "NA")
            {
                msg = msg + "Please Select Warranty Type";
            }
            
        }

        if (msg != "")
        {
            validationResult = false;
            ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "alert('" + msg + "');", true);
            return validationResult;
        }

        return validationResult;
    }
}
