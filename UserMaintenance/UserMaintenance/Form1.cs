using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserMaintenance.Entities;

namespace UserMaintenance
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;

        BindingList<User> users = new BindingList<User>();

        public Form1()
        {
            InitializeComponent();
            label1.Text = Resource.FullName; // label1
            button1.Text = Resource.Add; // button1
            button2.Text = Resource.WriteToFile;

            listBox1.DataSource = users;
            listBox1.ValueMember = "ID";
            listBox1.DisplayMember = "FullName";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var u = new User()
            {
                FullName = textBox1.Text,
            };
            users.Add(u);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog1.FileName.Length != 0)
                {
                    StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);
                    foreach (object o in users)
                        sw.WriteLine(o.ToString());
                    sw.Close();
                }
            }
        }
    }
}
