using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
namespace manage
{
    public partial class code : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
               createimage(getmixture(4));
            
        }
        private String getmixture(int n)
        {
            String s = "";
            int cal = 0;
            String[] num = new String[62];

            for (int i = 65; i <= 122; i++)
            {
                if (i > 90 && i < 97)
                    continue;
                System.Text.ASCIIEncoding asciiEncoding = new System.Text.ASCIIEncoding();
                byte[] btNumber = new byte[] { (byte)i };
                num[cal] = asciiEncoding.GetString(btNumber);
                cal += 1;
            }
            for (int j = 0; j <= 9; j++)
            {
                num[cal] = Convert.ToString(j);
                cal++;
            }
            Random ran = new Random();
            for (int i = 0; i < n; i++)
            {
                int t = ran.Next(num.Length);//产生一个小于num.Length的数字
                s += num[t];
            }
            Session["code"] = s.ToLower();
            return s;
        }
        //创建图片
        private void createimage(String vaild)//参数为生成的随机数字之类的字符串
        {
            if (vaild == null || vaild.Trim() == String.Empty)
                return;
            //源图像  
            //System.Drawing.Bitmap oldBmp = new System.Drawing.Bitmap(imgUrl);

            //新图像,并设置新图像的宽高  
            Bitmap image = new Bitmap(vaild.Length * 15, 25);//图像,并设置图像的宽高 
            Graphics g = Graphics.FromImage(image);////从图像获取对应的Graphics  
            try
            {
                Random random = new Random();
                g.Clear(Color.White);//清空图片背景色
                for (int i = 0; i < 25; i++)
                {
                    int x1 = random.Next(image.Width);
                    int x2 = random.Next(image.Width);
                    int y1 = random.Next(image.Height);
                    int y2 = random.Next(image.Height);
                    g.DrawLine(new Pen(Color.Coral), x1, y1, x2, y2);//使用Coral颜色在点 (x1, y1) 和 (x2, y2) 之间画一条线  
                }
                Font font = new Font("黑体", 15, FontStyle.Italic);//设置字体;
                LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), Color.Blue, Color.DarkRed, 1.2f, true);//设置渐变画刷 
                g.DrawString(vaild, font, brush, 2, 2);//在指定位置并且用指定的 Brush 和 Font 对象绘制指定的文本字符串。
                for (int i = 0; i < 100; i++)
                {
                    int x = random.Next(image.Width);
                    int y = random.Next(image.Height);
                    image.SetPixel(x, y, Color.FromArgb(random.Next()));
                }
                g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);
                MemoryStream ms = new MemoryStream();
                image.Save(ms, ImageFormat.Gif);
                Response.ClearContent();
                Response.ContentType = "image/Gif";
                Response.BinaryWrite(ms.ToArray());
            }
            finally
            {
                g.Dispose();
                image.Dispose();
            }
        }
    }
}