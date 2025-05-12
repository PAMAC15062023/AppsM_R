using System;
using System.Data;
using System.Web;
using System.IO;
using System.Data.SqlClient;
using System.Drawing;
using ZXing;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Newtonsoft.Json;

public partial class Admin_Assets_Inventory_Assets_RenderReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		
        string CentreId = Request.QueryString["CentreId1"];
        string SubCentreId = Request.QueryString["SubCentreId1"];
        string Vertical_Name = Request.QueryString["Vertical_Name1"];
        string Emp_Code = Request.QueryString["Emp_Code1"];

        DataTable dtS = GetData(CentreId, SubCentreId, Vertical_Name, Emp_Code);


        if (dtS != null)
        {
            GenerateMyQCCode(dtS);
        }
    }



    private void GenerateMyQCCode(DataTable dt)
    {
        string VerticalName1 = string.Empty;
        string FullName1 = string.Empty;
        string Department1 = string.Empty;
        string TransRefNo1 = string.Empty;
        string OwnerName1 = string.Empty;

        string text3 = string.Empty;
        string s1 = string.Empty;
        string text4 = string.Empty;

        string path3 = string.Empty;

        int count = 1;
        int countimg = 0;
        string pdffilename = "QR" + GetTimestamp() + ".pdf";

        string CentreId = Request.QueryString["CentreId1"];
        string SubCentreId = Request.QueryString["SubCentreId1"];
        string Vertical_Name = Request.QueryString["Vertical_Name1"];
        string Emp_Code = Request.QueryString["Emp_Code1"];

        DataTable data = GetData(CentreId, SubCentreId, Vertical_Name, Emp_Code);

        Document pdfDoc = new Document(PageSize.A4, 28, 12, 28, 12);
        PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
        PdfWriter pdfWriter1 = PdfWriter.GetInstance(pdfDoc, memoryStream);

        pdfDoc.Open();

        foreach (DataRow row in dt.Rows)
        {
            string TransRefNo = row["TransRefNo"].ToString();
            string dtstring = JsonConvert.SerializeObject(TransRefNo);

            var QCwriter = new BarcodeWriter();
            QCwriter.Format = BarcodeFormat.QR_CODE;
            var result = QCwriter.Write(dtstring);
            string path = Server.MapPath("~/images/MyQRImage" + countimg + ".jpg");
            string path2 = Server.MapPath("~/images/");
            var barcodeBitmap = new Bitmap(result);

            using (MemoryStream memory = new MemoryStream())
            {
                using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
                {
                    barcodeBitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] bytes1 = memory.ToArray();
                    fs.Write(bytes1, 0, bytes1.Length);

                }
            }
            countimg++;
        }

        foreach (DataRow row in dt.Rows)
        {
            int dtcount = dt.Rows.Count;

            if (dtcount < count)
            {
                break;
            }

            try
            {
                string path = Server.MapPath("~/images/MyQRImage" + (count - 1) + ".jpg");
                string path1 = Server.MapPath("~/images/pamaclogo.jpg");

                string VerticalName = data.Rows[count - 1]["Vertical_Name"].ToString();
                string FullName = data.Rows[count - 1]["FullName"].ToString();
                string Department = data.Rows[count - 1]["Department"].ToString();
                string TransRefNo = data.Rows[count - 1]["TransRefNo"].ToString();
                string OwnerName = data.Rows[count - 1]["Owner_Name"].ToString();


                if (Department == "")
                {
                    Department = "--";
                }

                string text = "";
                text = VerticalName;
                string s = FullName;
                s = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(s.ToLower());

                string text1 = s + " " + Department + " " + OwnerName + "\r\n";

                //string text1 = s +  " " + OwnerName + "\r\n";

                if (dtcount != count)
                {
                    VerticalName1 = data.Rows[count]["Vertical_Name"].ToString();
                    FullName1 = data.Rows[count]["FullName"].ToString();
                    Department1 = data.Rows[count]["Department"].ToString();
                    TransRefNo1 = data.Rows[count]["TransRefNo"].ToString();
                    OwnerName1 = data.Rows[count]["Owner_Name"].ToString();

                    text3 = VerticalName1;
                    s1 = FullName1;
                    s1 = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(s1.ToLower());

                    if (Department1 == "")
                    {
                        Department1 = "--";
                    }

                    text4 = s1 + " " + Department1 + " " + OwnerName1 + "\r\n";

                    //text4 = s1 + " " + OwnerName1 + "\r\n";


                }

                byte[] file;

                PdfPTable resimtable = new PdfPTable(8); // two colmns create tabble
                resimtable.WidthPercentage = 100f;//table %100 width

                float[] widths = new float[] { 12f, 12f, 12f, 12f, 12f, 12f, 12f, 12f };
                resimtable.SetWidths(widths);
                resimtable.HorizontalAlignment = Element.ALIGN_LEFT;
                resimtable.DefaultCell.Border = 0;
                resimtable.DefaultCell.BorderWidthBottom = 0;
                resimtable.DefaultCell.BorderWidthTop = 0;
                resimtable.DefaultCell.BorderWidthLeft = 0;
                resimtable.DefaultCell.BorderWidthRight = 0;


                //resimtable.DefaultCell.Right = 1;
                file = System.IO.File.ReadAllBytes(path);
                iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(file);


                file = System.IO.File.ReadAllBytes(path1);
                iTextSharp.text.Image jpg1 = iTextSharp.text.Image.GetInstance(file);


                resimtable.AddCell(jpg);//Table One colmns added first image
                resimtable.AddCell(text); //Table two colmns added text
                resimtable.AddCell(text1);   //Table three colmns added text
                resimtable.AddCell(jpg1);//Table four colmns added second image


                if (dtcount != count)
                {
                    path3 = Server.MapPath("~/images/MyQRImage" + count + ".jpg");
                    file = System.IO.File.ReadAllBytes(path3);

                    iTextSharp.text.Image jpg3 = iTextSharp.text.Image.GetInstance(file);


                    resimtable.AddCell(jpg3);//Table One colmns added first image
                    resimtable.AddCell(text3); //Table two colmns added text
                    resimtable.AddCell(text4);   //Table three colmns added text
                    resimtable.AddCell(jpg1);//Table four colmns added second image
                }
                else
                {
                    resimtable.AddCell("");//Table One colmns added first image
                    resimtable.AddCell(""); //Table two colmns added text
                    resimtable.AddCell("");   //Table three colmns added text
                    resimtable.AddCell("");
                }

                pdfDoc.Add(resimtable);

                text = "PAMAC Finserve Pvt Ltd" + "  " + TransRefNo;

                PdfPTable resimtable1 = new PdfPTable(2); // two colmns create tabble
                resimtable1.WidthPercentage = 100f;//table %100 width
                resimtable1.DefaultCell.Border = 1;
                resimtable1.DefaultCell.BorderWidthBottom = 1;
                resimtable1.DefaultCell.BorderWidthTop = 0;
                resimtable1.DefaultCell.BorderWidthLeft = 0;
                resimtable1.DefaultCell.BorderWidthRight = 0;

                resimtable1.AddCell(text);

                if (dtcount != count)
                {

                    text1 = "PAMAC Finserve Pvt Ltd" + "  " + TransRefNo1;
                    resimtable1.AddCell(text1); //Table two colmns added text
                }
                else
                {
                    resimtable1.AddCell("");
                }
                pdfDoc.Add(resimtable1);

                PdfContentByte cb = pdfWriter.DirectContent;
                int x = 25;
                int x1 = 35;  // 730+90
                int y = 585;
                int y1 = 820; // 820+90

                var rect = new iTextSharp.text.Rectangle(x, x1, y, y1);
                //  rect.Border = iTextSharp.text.Rectangle.LEFT_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
                rect.Border = iTextSharp.text.Rectangle.BOX;
                rect.BorderWidth = 1;
                rect.BorderColor = new BaseColor(0, 0, 0);
                cb.Rectangle(rect);

                var rect1 = new iTextSharp.text.Rectangle(300, 35, 305, 820);
                //  rect.Border = iTextSharp.text.Rectangle.LEFT_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
                rect1.Border = iTextSharp.text.Rectangle.BOX;
                rect1.BorderWidth = 1;
                rect1.BorderColor = new BaseColor(0, 0, 0);
                cb.Rectangle(rect1);

                File.Delete(path);
                File.Delete(path3);

                int countx = (count + 1);
                int county = countx % 16;

                if (county == 0)
                { 
                    pdfDoc.NewPage();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

            count = count + 2;
        }
        pdfWriter.CloseStream = false;
        pdfWriter1.CloseStream = false;
        pdfDoc.Close();

        byte[] bytes = memoryStream.ToArray();
        System.IO.File.WriteAllBytes(Server.MapPath("~/QRPDFFile/") + pdffilename, bytes);

        Response.Buffer = true;

        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=" + pdffilename);
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Write(pdfDoc);
    }
  
    public static String GetTimestamp()
    {
        return DateTime.Now.ToString("yyyyMMddHHmmssfff");
    }
    public DataTable GetData(string CentreId, string SubCentreId, string Vertical_Name, string Emp_Code)
    {
        DataTable dtNew = new DataTable("Assets_Barcode");
        try
        {
            CCommon objConn = new CCommon();
            SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);

            sqlcon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlcon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Get_AssetsInventoryDetails";

            SqlParameter CentreID = new SqlParameter();
            CentreID.SqlDbType = SqlDbType.VarChar;
            CentreID.Value = CentreId;
            CentreID.ParameterName = "@CentreId";
            sqlCom.Parameters.Add(CentreID);

            SqlParameter SubCentreId1 = new SqlParameter();
            SubCentreId1.SqlDbType = SqlDbType.VarChar;
            SubCentreId1.Value = SubCentreId;
            SubCentreId1.ParameterName = "@SubCentreId";
            sqlCom.Parameters.Add(SubCentreId1);

            SqlParameter Vertical_Name1 = new SqlParameter();
            Vertical_Name1.SqlDbType = SqlDbType.VarChar;
            Vertical_Name1.Value = Vertical_Name;
            Vertical_Name1.ParameterName = "@Vertical_Name";
            sqlCom.Parameters.Add(Vertical_Name1);

            SqlParameter Emp_Code1 = new SqlParameter();
            Emp_Code1.SqlDbType = SqlDbType.VarChar;
            Emp_Code1.Value = Emp_Code;
            Emp_Code1.ParameterName = "@Emp_Code";
            sqlCom.Parameters.Add(Emp_Code1);

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;
            sqlDA.Fill(dtNew);

            sqlcon.Close();

        }
        catch (Exception ex)
        {
            dtNew = null;
            ex.ToString();
        }
        return dtNew;
    }

}
