using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterfaceDesign
{
    public partial class ViewPainting : Form
    {
        private OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.15.0;Data Source=C:\\Users\\Malik\\Desktop\\SEF31.accdb;Persist Security Info=False;");
        private OleDbCommand cmd;
        OleDbDataReader dr;
        public ViewPainting()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new OleDbCommand("select * from Painting where PaintingID=" + textBox1.Text + " ", con);
                con.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                textBox2.Text = dr["PName"].ToString();
                textBox3.Text = dr["CreationDate"].ToString();
                textBox4.Text = dr["PainterName"].ToString();
                textBox5.Text = dr["DateofArrival"].ToString();
                dr.Close();
            }
            catch 
            {
                MessageBox.Show("Cannot be viewed. Try again.");
            }
            finally
            {
                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TourGuide myForm = new TourGuide();
            this.Hide();
            myForm.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MainMenu myForm = new MainMenu();
            this.Hide();
            myForm.ShowDialog();
            this.Close();
        }
    }
}
