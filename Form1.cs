using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HalconDotNet;
namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        private HTuple WindowID;
        private HObject Image;
        public Form1()
        {
            InitializeComponent();

            Image = new HObject();
            CreateHalconWindows();
            LoadImage();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        public void CreateHalconWindows()
        {
            HTuple FatherWindow = this.pictureBox1.Handle;
            //设置窗口的背景颜色
            HOperatorSet.SetWindowAttr("background_color", "green");
            HOperatorSet.OpenWindow(0,0,this.pictureBox1.Width, this.pictureBox1.Height,FatherWindow,"visible", "", out WindowID);
        }
        public void LoadImage()
        {
            //读取一张图像
            HOperatorSet.ReadImage(out Image, "1.bmp");

            HTuple width = null, height = null;

            //获取图像大小
            HOperatorSet.GetImageSize(Image, out width, out height);

            //设置对象显示的颜色
            HOperatorSet.SetColor(WindowID, "yellow");

            //通过改变图像的缩放来适应图像在窗口的正常显示
            HOperatorSet.SetPart(WindowID, 0, 0, height, width);

            //在窗口上显示图像
            HOperatorSet.DispObj(Image, WindowID);


        }
    }
    

}
