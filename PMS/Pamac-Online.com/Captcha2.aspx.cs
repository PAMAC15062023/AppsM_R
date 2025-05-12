using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Captcha2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Defining brush color
        Color brushColor = System.Drawing.Color.Red;

        // Creating object for bitmap
        Bitmap objBitmap = new System.Drawing.Bitmap(100, 30);

        // Creating object for Graphics class
        Graphics objGraphics = System.Drawing.Graphics.FromImage(objBitmap);
        objGraphics.Clear(Color.Transparent);

        // Creating object for Font class
        Font objFont = new Font("Times New Roman", 14, FontStyle.Regular);

        string inputNumberString = "";

        Random r = new Random();

        int a = r.Next(1, 50);
        int b = r.Next(1, 50);

        int c = a + b;

        inputNumberString = a.ToString() + " + " + b.ToString() + " = ";

        //Storing the captcha value in the session
        Session["CaptchaValue"] = c.ToString();

        SolidBrush myBrush = new SolidBrush(brushColor);

        objGraphics.DrawString(inputNumberString, objFont, myBrush, 3, 3);

        //Adding the content type
        Response.ContentType = "image/png";

        System.IO.MemoryStream mem = new MemoryStream();

        //Saving the bitmap image
        objBitmap.Save(mem, ImageFormat.Png);

        //Writing the image to output screen
        mem.WriteTo(Response.OutputStream);

        // Disposing Font Object
        objFont.Dispose();

        // Disposing Graphics Object
        objGraphics.Dispose();

        // Disposing Bitmap Object
        objBitmap.Dispose();
    }
}