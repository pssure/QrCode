using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Text;
using ThoughtWorks;
using ThoughtWorks.QRCode;
using ThoughtWorks.QRCode.Codec;
using ThoughtWorks.QRCode.Codec.Data;
using System.Drawing;

namespace 生成二维码
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            create_two(this.TextBox1.Text);
        }

        private void create_two(string nr)
        {
            Bitmap bt;
            string enCodeString = nr;
            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
            bt = qrCodeEncoder.Encode(enCodeString, Encoding.UTF8);
            string filename = DateTime.Now.ToString("yyyymmddhhmmss");
            string path = Server.MapPath("~/image/") + filename + ".jpg";
            Response.Write(path);
            bt.Save(path);
            this.Image1.ImageUrl = "~/image/" + filename + ".jpg";
        }
    }
}