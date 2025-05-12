using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Collections;
using System.IO;
using System.Text;
using OfficeOpenXml;
using Ionic.Zip;
using iTextSharp.text;
using iTextSharp.text.pdf;
//using OfficeOpenXml.Core.ExcelPackage;
using iTextSharp.tool.xml;

namespace RESDOT
{
    public partial class caseentrybase : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            //  bool isPageRefreshed = false;
            if (!IsPostBack)
            {
                //lblMessage.Text = "auto page load  is happening";
                //ViewState["ViewStateId"] = System.Guid.NewGuid().ToString();
                //Session["SessionId"] = ViewState["ViewStateId"].ToString();
                //  Session["sesfieldlist"] = "1";
                Session["iterations"] = 0;
                Session["sesfieldlist"] = "1";
                string menuname = Request.QueryString["menuname"];
                hdnMenuId.Value = Convert.ToString(Request.QueryString["menuid"]);
                int activityid = Convert.ToInt32(Request.QueryString["Activityid"]);
                string userid = Session["UserId"].ToString();
                int roleid = Convert.ToInt32(Session["Roleid"].ToString());


            }

            int sesit = Convert.ToInt32(Session["iterations"]);


            if (sesit == 0)
            {
                topfields(2);
            }
        }
        protected void topfields(int field_show_in)
        {
            string menuname = Request.QueryString["menuname"];
            int menuid = Convert.ToInt32(Request.QueryString["menuid"]);
            int activityid = Convert.ToInt32(Session["ActivityId"].ToString());
            //  Convert.ToInt32(Request.QueryString["Activityid"]);



            PlaceholderControls.Controls.Add(new LiteralControl("<div class='box'>" +
                    "<div class='box-header with-border'>" + "<h2 class='box-title'>" + menuname + "<br>" +
                    "</div>" + "</div>"));

            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            DataTable dt = new DataTable();

            FieldData fielddata = new FieldData();

            dt = fielddata.GetFieldData(menuid, activityid, field_show_in);

            string inputtype = "";
            String labelnames = "";
            String fieldids = "";
            int num = 20;

            string tblName = "";
            String fieldName = "";
            String fieldtype = "";
            String postback = "";
            string validation_req = "";
            string dependentval = "";
            string dependentfield = "";
            string dependentcheckfield = "";
            string WhereIfAny = "";
            string where = "";
            int tno = 0;
            string fieldval = "";

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    int reccnt = 0;
                    PlaceholderControls.Controls.Add(new LiteralControl("<tr>"));
                    foreach (DataRow dr in dt.Rows) // do something for each field
                    {
                        reccnt = reccnt + 1;
                        if (reccnt % 2 == 0)    //> 1
                        {
                            PlaceholderControls.Controls.Add(new LiteralControl("</tr><tr>"));
                        }

                        inputtype = dr["input_type"].ToString().ToUpper();
                        labelnames = dr["label_name"].ToString();
                        labelnames = labelnames.Replace(" ", "");

                        fieldids = dr["fields_id"].ToString();

                        string maxlength = dr["input_maxLength"].ToString();
                        num = Int32.Parse(dr["input_maxLength"].ToString());
                        tblName = dr["select_table"].ToString();
                        fieldName = dr["field_Name"].ToString();
                        fieldtype = dr["field_type"].ToString();
                        validation_req = dr["validation_req"].ToString();


                        postback = dr["Postback"].ToString();
                        dependentval = dr["dependent"].ToString();
                        dependentfield = dr["dependent_field"].ToString();
                        dependentcheckfield = dr["dependent_checkfield"].ToString();


                        WhereIfAny = dr["WhereIfAny"].ToString();

                        {
                            if (inputtype == "INPUTBOX")
                            {


                                PlaceholderControls.Controls.Add(new LiteralControl("<td class='TableTitle' style='width: 100px'>" + labelnames));

                                TextBox fieldidT = new TextBox();
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                                PlaceholderControls.Controls.Add(new LiteralControl("<td style = 'width: 100px' >"));
                                fieldidT.ID = "txt" + fieldName;

                                string fldt = fieldidT.ID;

                                fieldval = fieldidT.Text;

                                PlaceholderControls.Controls.Add(fieldidT);
                                fieldval = fieldidT.Text;
                                fieldidT.Attributes.Add("runat", "server");

                                //   fieldidT.Attributes.Add("onfocusout", "__doPostBack('','');");
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));


                                if (validation_req == "1")
                                {
                                    RequiredFieldValidator req = new RequiredFieldValidator();
                                    req.ID = "rfvDynamic" + fieldidT.ID;
                                    req.Font.Bold = true;
                                    req.SetFocusOnError = true;
                                    req.ErrorMessage = "Required";
                                    req.ControlToValidate = fieldidT.ID;
                                    PlaceholderControls.Controls.Add(req);

                                }

                                tno = tno + 1;
                            }
                            if (inputtype == "SELECT")
                            {

                                if (fieldName == "fe-id") { fieldName = "empid"; }
                                PlaceholderControls.Controls.Add(new LiteralControl("<td class='TableTitle' style='width: 100px'>"));
                                PlaceholderControls.Controls.Add(new LiteralControl(labelnames));
                                DropDownList ddArea = new DropDownList();
                                ddArea.ID = "ddl" + fieldName;

                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                                PlaceholderControls.Controls.Add(new LiteralControl("<td style = 'width: 100px' >"));
                                ddArea.Attributes.Add("runat", "server");
                                ddArea.Attributes.Add("AutoPostBack", "true"); //this is the problem
                                                                               //      ddArea.Attributes.Add("onblur", "__doPostBack('','');");
                                if (postback == "Y")
                                //  if (fieldName=="zone_id"  || fieldName=="centre_id")
                                {
                                    //  ddArea.Attributes.Add("onblur", "__doPostBack('','');");
                                    ddArea.Attributes.Add("onfocusout", "__doPostBack('','');");
                                    ddArea.SelectedIndexChanged += new System.EventHandler(ddArea_SelectedIndexChanged);

                                }

                                ddArea.Attributes.Add("SelectedIndex", "0");
                                if (WhereIfAny == "" || WhereIfAny == null)
                                {
                                    where = "ALL";
                                }
                                else
                                {
                                    where = WhereIfAny;
                                }
                                if (validation_req == "1")
                                {
                                    RequiredFieldValidator req = new RequiredFieldValidator();
                                    req.ID = "rfvDynamic" + ddArea.ID;
                                    req.Font.Bold = true;
                                    req.SetFocusOnError = true;
                                    req.ErrorMessage = "Required";
                                    req.ControlToValidate = ddArea.ID;
                                    PlaceholderControls.Controls.Add(req);

                                }
                                if (dependentval == "Y")
                                //  if (fieldName == "centre_id" || fieldName == "subcentre_id")
                                {  // dependent on field = "zone_id"
                                    // check with field = "centre_cluster_id"
                                    ddArea.Attributes.Add("fldnam", fieldName);
                                    ddArea.Attributes.Add("tabnam", tblName);
                                    ddArea.Attributes.Add("labnam", labelnames);

                                    ddArea.Attributes.Add("dependency", dependentval);
                                    ddArea.Attributes.Add("depfield", dependentfield);
                                    ddArea.Attributes.Add("checkfld", dependentcheckfield);


                                }
                                else
                                {
                                    Binddata(tblName, ddArea, fieldName, labelnames, where);
                                }

                                PlaceholderControls.Controls.Add(ddArea);
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));

                            }
                            if (inputtype == "LISTBOX")
                            {
                                if (fieldName == "fe-id") { fieldName = "empid"; }
                                PlaceholderControls.Controls.Add(new LiteralControl("<td class='TableTitle' style='width: 100px'>"));
                                PlaceholderControls.Controls.Add(new LiteralControl(labelnames));
                                ListBox lstArea = new ListBox();
                                lstArea.ID = "lst" + fieldName;
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                                PlaceholderControls.Controls.Add(new LiteralControl("<td style = 'width: 100px' >"));
                                PlaceholderControls.Controls.Add(lstArea);


                                lstArea.SelectionMode = ListSelectionMode.Multiple;


                                Binddata1(tblName, lstArea, fieldName, labelnames);

                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));

                            }



                            if (inputtype == "DATETIME")
                            {
                                PlaceholderControls.Controls.Add(new LiteralControl("<td class='TableTitle' style='width: 100px'>"));
                                PlaceholderControls.Controls.Add(new LiteralControl(labelnames));
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                                PlaceholderControls.Controls.Add(new LiteralControl("<td style = 'width: 100px' >"));
                                TextBox fieldidT = new TextBox();
                                fieldidT.ID = "dat" + fieldName;
                                PlaceholderControls.Controls.Add(fieldidT);
                                fieldidT.Attributes.Add("class", "datepicker");

                                PlaceholderControls.Controls.Add(fieldidT);
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                            }
                            if (inputtype == "TEXTAREA")
                            {
                                PlaceholderControls.Controls.Add(new LiteralControl("<td class='TableTitle' style='width: 100px'>"));
                                PlaceholderControls.Controls.Add(new LiteralControl(labelnames));
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                                PlaceholderControls.Controls.Add(new LiteralControl("<td style = 'width: 100px' >"));
                                TextBox textArea = new TextBox();
                                textArea.TextMode = TextBoxMode.MultiLine;
                                textArea.ID = "txA" + fieldName;
                                PlaceholderControls.Controls.Add(textArea);
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                            }
                            if (inputtype == "CHECKBOX")
                            {
                                PlaceholderControls.Controls.Add(new LiteralControl("<td class='TableTitle' style='width: 100px'>"));
                                PlaceholderControls.Controls.Add(new LiteralControl(labelnames));
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                                PlaceholderControls.Controls.Add(new LiteralControl("<td style = 'width: 100px' >"));
                                CheckBox cbArea = new CheckBox();
                                //  textArea.TextMode = TextBoxMode.MultiLine;
                                cbArea.ID = "chk" + fieldName;
                                PlaceholderControls.Controls.Add(cbArea);
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                            }
                            if (inputtype == "RADIO")
                            {
                                PlaceholderControls.Controls.Add(new LiteralControl("<tr><td class='TableTitle' style='width: 100px'>"));
                                PlaceholderControls.Controls.Add(new LiteralControl(labelnames));
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                                PlaceholderControls.Controls.Add(new LiteralControl("<td style = 'width: 100px' >"));

                                string[] values = tblName.Split(',');
                                for (int i = 0; i < values.Length; i++)
                                {
                                    values[i] = values[i].Trim();
                                }

                                for (int i = 1; i <= num; i++)
                                {

                                    RadioButton rbitem = new RadioButton();
                                    rbitem.ID = values[i - 1].Trim(); //"rb" + i + fieldName;
                                                                      //rbitem.ID = "rb"+i + labelnames;
                                    rbitem.Text = rbitem.ID;
                                    PlaceholderControls.Controls.Add(rbitem);

                                }
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                            }
                            if (inputtype == "FILE")
                            {
                                PlaceholderControls.Controls.Add(new LiteralControl("<td class='TableTitle' style='width: 100px' font_size=10>"));
                                PlaceholderControls.Controls.Add(new LiteralControl(labelnames));
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                                PlaceholderControls.Controls.Add(new LiteralControl("<td style = 'width: 100px' >"));
                                FileUpload fileArea = new FileUpload();
                                //  textArea.TextMode = TextBoxMode.MultiLine;
                                fileArea.ID = "fil" + labelnames;
                                PlaceholderControls.Controls.Add(fileArea);
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                            }

                            if (inputtype == "BUTTON")
                            {
                                PlaceholderControls.Controls.Add(new LiteralControl("<td>"));
                                Button button = new Button();
                                button.ID = "btn" + fieldName;
                                button.Text = labelnames;
                                button.BackColor = Color.Blue;
                                button.ForeColor = Color.White; //add on 26/12/23
                                if (fieldName == "Save")
                                {
                                    button.Visible = false;
                                }



                                button.Click += new EventHandler(ButtonClickCommonEvent);


                                PlaceholderControls.Controls.Add(button); // here

                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));

                                PlaceholderControls.Controls.Add(new LiteralControl("<td>"));
                            }

                        }
                    }


                }

                //string fieldlist = Session["sesfieldlist"].ToString();
                //getgridview_search(fieldlist);

            }
        }
        protected void ButtonClickCommonEvent(object sender, EventArgs e) // general
        {
            int MenuId = Convert.ToInt32(hdnMenuId.Value);

            string actres = "";

            Button btn = (Button)sender;
            actres = btn.Text;

            switch (actres)
            {
                case "Search":
                    //   searchevent();
                    break;


                case "NEXT":

                    NextEvent();


                    break;


                case "Cancel":
                    string menuname = Request.QueryString["menuname"];
                    int menuid = Convert.ToInt32(Request.QueryString["menuid"]);
                    int activityid = Convert.ToInt32(Request.QueryString["Activityid"]);
                    Response.Redirect("Mysample.aspx?menuid=" + menuid + "&menuname= " + menuname + "&Activityid=13", false);
                    break;


                default:

                    lblMessage.Text = actres + "  button clicked";
                    break;
            }
            return;



        }
        void Binddata1(String tblName1, ListBox ddl, String fieldname, String labelname)
        {
            try
            {
                SqlConnection sqlCon1 = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon1;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "SP_binddata";
                SqlDataAdapter da = new SqlDataAdapter(sqlCom);

                SqlParameter tbl = new SqlParameter();
                tbl.SqlDbType = SqlDbType.VarChar;
                tbl.Value = tblName1;
                tbl.ParameterName = "@tblname";
                sqlCom.Parameters.Add(tbl);

                SqlParameter fldname = new SqlParameter();
                fldname.SqlDbType = SqlDbType.VarChar;
                fldname.Value = fieldname;
                fldname.ParameterName = "@fldname";
                sqlCom.Parameters.Add(fldname);

                SqlParameter lblname = new SqlParameter();
                lblname.SqlDbType = SqlDbType.VarChar;
                lblname.Value = labelname;
                lblname.ParameterName = "@lblname";
                sqlCom.Parameters.Add(lblname);

                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds != null && ds.Tables.Count > 0)
                {


                    ddl.DataTextField = "DTF";
                    ddl.DataValueField = "DTV";
                    ddl.DataSource = ds.Tables[0];
                    ddl.DataBind();
                    ddl.Items.Insert(0, "--Select--");
                    ddl.SelectedIndex = 0;

                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        private void ddArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMessage.Text = "selected index change";
            DropDownList ddl1 = (DropDownList)sender;
            string ddl_name = ddl1.ID;

            // ddArea.Attributes.Add("onfocusout", "__doPostBack('','');");
            if (ddl_name == "ddlTemplate_id")
            {
                String templ_id = ddl1.SelectedValue;
                Session["templ_id"] = templ_id;
                //      lblMessage.Text = ddl1.SelectedValue;
                foreach (Button btn in PlaceholderControls.Controls.OfType<Button>())
                {
                    btn.Visible = true;

                }
                // ddl1.Focus();

                return;
            }

            foreach (DropDownList ddl in PlaceholderControls.Controls.OfType<DropDownList>())
            {
                string depend = ddl.Attributes["dependency"];
                string ddlattr = ddl.Attributes["onfocusout"];                   // ["onblur"];
                string depfield = ddl.Attributes["depfield"];
                string checkfld = ddl.Attributes["checkfld"];
                string fldnam = ddl.Attributes["fldnam"];
                string tabnam = ddl.Attributes["tabnam"];
                string labnam = ddl.Attributes["labnam"];
                string ddlname = "ddl" + depfield;
                string ddlnam = ddl.ID;
                if (ddlattr != null)
                {
                    ddlnam = ddl.ID;
                    Session[ddlnam] = ddl.SelectedValue;

                }

                Session[ddlnam] = ddl.SelectedValue;
                if (ddlnam == "ddlclient_id")
                {
                    Session["clientid"] = ddl.SelectedValue; ;
                }
                int menuid = Convert.ToInt32(Request.QueryString["menuid"]);
                //if (ddlname == "importtemplatedesign_name" && menuid == 2)  //(for imports)
                //{
                //    lblMessage.Text = "Now create template fields";
                //}
                if (depend == "Y")
                {
                    string tblName = tabnam; // "tbl_mst_centre";
                    string fieldName = fldnam;
                    string labelnames = labnam; // "Centre_name";
                    ddlname = "ddl" + depfield;
                    String where = checkfld + " = " + Session[ddlname].ToString();

                    if (ddlname == "ddlproduct_id" && (menuid == 2 || menuid == 3 || menuid == 4
                         || menuid == 8))  //(for imports and exports)
                    {
                        string client_id = Session["clientid"].ToString();
                        where = where + " and client_id = " + client_id;
                        //        where = where + " and importtemplateassign_client_id = 41";
                    }

                    if (ddl.SelectedValue == "")
                    {
                        Binddata(tblName, ddl, fieldName, labelnames, where);
                    }
                    // lblMessage.Text = "selected is " + Session["ddlzone_id"].ToString();

                }


            }
        }
        void Binddata(String tblName1, DropDownList ddl, String fieldname, String labelname, string where)
        {
            try
            {
                //if (where!="ALL")
                //{
                //    //lblMessage.Text = "where value not all";
                //}

                labelname = labelname.Replace("Verification_type", "veriftype_name");

                SqlConnection sqlCon1 = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon1;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "SP_binddata";
                SqlDataAdapter da = new SqlDataAdapter(sqlCom);

                SqlParameter tbl = new SqlParameter();
                tbl.SqlDbType = SqlDbType.VarChar;
                tbl.Value = tblName1;
                tbl.ParameterName = "@tblname";
                sqlCom.Parameters.Add(tbl);

                SqlParameter fldname = new SqlParameter();
                fldname.SqlDbType = SqlDbType.VarChar;
                fldname.Value = fieldname;
                fldname.ParameterName = "@fldname";
                sqlCom.Parameters.Add(fldname);

                SqlParameter lblname = new SqlParameter();
                lblname.SqlDbType = SqlDbType.VarChar;
                lblname.Value = labelname;
                lblname.ParameterName = "@lblname";
                sqlCom.Parameters.Add(lblname);

                SqlParameter wherei = new SqlParameter();
                wherei.SqlDbType = SqlDbType.VarChar;
                wherei.Value = where;
                wherei.ParameterName = "@where";
                sqlCom.Parameters.Add(wherei);

                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds != null && ds.Tables.Count > 0)
                {


                    ddl.DataTextField = "DTF";
                    ddl.DataValueField = "DTV";
                    ddl.DataSource = ds.Tables[0];
                    ddl.DataBind();
                    ddl.Items.Insert(0, "--Select--");
                    ddl.SelectedIndex = 0;

                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void NextEvent()
        {
            int sesit = Convert.ToInt32(Session["iterations"]);
            //  NEXTevent();
            //topfields_4(5);
            string message = "";
            lblMessage.Text = "";
            string updatevalue = "";


            foreach (TextBox textBox in PlaceholderControls.Controls.OfType<TextBox>())
            {
                lblMessage.Text += textBox.ID.Substring(3) + ",";
                message += "'" + textBox.Text + "'" + ",";

                updatevalue += textBox.ID.Substring(3) + "=" + "''" + textBox.Text + "''" + ",";

            }


            foreach (DropDownList ddl in PlaceholderControls.Controls.OfType<DropDownList>())
            {
                if (ddl.SelectedItem.Text.Trim() != "" && ddl.SelectedItem.Text.Trim() != null)
                {
                    lblMessage.Text += ddl.ID.Substring(3) + ",";
                    message += "'" + ddl.SelectedValue + "'" + ",";
                    message += "'" + ddl.SelectedItem.Text + "'" + ",";
                    updatevalue += ddl.ID.Substring(3) + "=" + "''" + ddl.SelectedValue + "''" + ","
                        + ddl.ID.Substring(3) + "=" + "''" + ddl.SelectedItem.Text + "''" + ",";
                }

            }

            foreach (CheckBox chk in PlaceholderControls.Controls.OfType<CheckBox>())
            {
                lblMessage.Text += chk.ID.Substring(3) + ",";
                message += "'" + chk.Checked + "'" + ",";
                updatevalue += chk.ID.Substring(3) + "=" + "''" + chk.Checked + "''" + ",";
            }
            foreach (FileUpload fup in PlaceholderControls.Controls.OfType<FileUpload>())
            {
                lblMessage.Text += fup.ID.Substring(3) + ",";
                message += "'" + fup.FileName + "'" + ",";
                updatevalue += fup.ID.Substring(3) + "," + "''" + fup.FileName + "''" + ",";
            }
            int ClientId = 0;
            int ProductId = 0;
            int VeriftypeId = 0;

            //List<string> frontendvaluelist = new List<string>();
            //frontendvaluelist = updatevalue.Split(',').ToList();

            //for (int k = 0; k < frontendvaluelist.Count - 1; k++)
            //{
            //    List<string> value = frontendvaluelist[k].Split('=').ToList();

            //    if (value[0] == "client_id")
            //    {
            //        ClientId = Convert.ToInt32(value[1].Replace("'", ""));
            //    }
            //    if (value[0] == "product_id")
            //    {
            //        ProductId = Convert.ToInt32(value[1].Replace("'", ""));
            //    }
            //    if (value[0] == "veriftype_id")
            //    {
            //        VeriftypeId = Convert.ToInt32(value[1].Replace("'", ""));
            //    }
            //}

            Response.Redirect("Mysample.aspx?menuid=" + 25 + "&menuname= " + "CaseEntry " + "&caseentry=Y"
                + "&updatevalue=" + updatevalue, false);

        }
    }
}