using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;


namespace 生成二维码
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        
        protected void Button1_Click(object sender, EventArgs e)
        {
            using (var ms = new MemoryStream())
            {
                string stringtest = "中国inghttp://www.baidu.com/mvc.test?&";
                GetQRCode(stringtest, ms);
                Response.ContentType = "image/Png";
                Response.OutputStream.Write(ms.GetBuffer(), 0, (int)ms.Length);

                Image img = Image.FromStream(ms);
                string filename = DateTime.Now.ToString("yyyymmddhhmmss");
                string path = Server.MapPath("~/image/") + filename + ".png";
                img.Save(path);

                Response.End();
            }  

        }

        /// <summary>
        /// 获取二维码
        /// </summary>
        /// <param name="strContent">待编码的字符</param>
        /// <param name="ms">输出流</param>
        ///<returns>True if the encoding succeeded, false if the content is empty or too large to fit in a QR code</returns>
        public static bool GetQRCode(string strContent, MemoryStream ms)
        {
            ErrorCorrectionLevel Ecl = ErrorCorrectionLevel.M; //误差校正水平 
            string Content = strContent;//待编码内容
            QuietZoneModules QuietZones = QuietZoneModules.Two;  //空白区域 
            int ModuleSize = 12;//大小
            var encoder = new QrEncoder(Ecl);
            QrCode qr;
            if (encoder.TryEncode(Content, out qr))//对内容进行编码，并保存生成的矩阵
            {
                var render = new GraphicsRenderer(new FixedModuleSize(ModuleSize, QuietZones));
                render.WriteToStream(qr.Matrix, ImageFormat.Png, ms);
            }
            else
            {
                return false;
            }
            return true;
        }

   
    }
}