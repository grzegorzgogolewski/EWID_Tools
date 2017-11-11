using System;
using System.IO;
using System.Windows.Forms;
using DZEtoGML.Properties;

namespace DZEtoGML
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            this.Text = Application.ProductName;

            groupBoxLogin.Text = @"DANE LOGOWANIA:";
            textBoxHost.Text = @"192.168.110.6";
            textBoxSid.Text = @"EWID";
            textBoxLogin.Text = @"ewid4";
            textBoxPassword.Text = @"2015geo";

            groupBoxParcel.Text = @"Lista działek";

            using (StreamReader sr = new StreamReader("listaDLK.txt"))
            {
                while (sr.Peek() >= 0)
                {
                    string linia = sr.ReadLine();

                    if (linia != null && linia.Length >= 15) listBox1.Items.Add(linia);

                }
            }

        }


    }
}
