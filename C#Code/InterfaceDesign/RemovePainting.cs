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
    public partial class RemovePainting : Form
    {
        private OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.15.0;Data Source=C:\\Users\\Malik\\Desktop\\SEF31.accdb;Persist Security Info=False;");
        private OleDbCommand cmd;
        OleDbDataReader dr;
        public RemovePainting()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new OleDbCommand("select * from Painting where PaintingID=" + textBox7.Text + " ", con);
                con.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                textBox1.Text = dr["PaintingID"].ToString();
                textBox2.Text = dr["PName"].ToString();
                textBox3.Text = dr["CreationDate"].ToString();
                textBox4.Text = dr["PainterName"].ToString();
                textBox5.Text = dr["DateofArrival"].ToString();
                textBox6.Text = dr["RegistrarID"].ToString();
                dr.Close();
                MessageBox.Show("If the displayed information is correct please click the delete button");
            }catch(OleDbException xx)
            {
                MessageBox.Show("There is a problem" + xx.Message);
            }
            finally
            {
                con.Close();
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new OleDbCommand("delete from Painting where PaintingID=" + textBox7.Text + " ", con);
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record "+textBox7.Text + " has been deleted.");
            }
            catch (OleDbException xx)
            {
                MessageBox.Show("There is a problem" + xx.Message);
            }
            finally
            {
                con.Close();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Registrar myForm = new Registrar();
            this.Hide();
            myForm.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainMenu myForm = new MainMenu();
            this.Hide();
            myForm.ShowDialog();
            this.Close();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void RemovePainting_Load(object sender, EventArgs e)
        {

        }
    }
}
