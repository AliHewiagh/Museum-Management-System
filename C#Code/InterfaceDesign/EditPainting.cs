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
    public partial class EditPainting : Form
    {
        OleDbConnection con = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.15.0; Data Source = C:\\Users\\Malik\\Desktop\\SEF31.accdb;Persist Security Info=False;" );
        OleDbCommand cmd;
        OleDbDataReader dr;
        public EditPainting()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new OleDbCommand("update Painting set PaintingID = " + textBox1.Text + ", PName='" + textBox2.Text + "',CreationDate = '" + textBox3.Text + "', PainterName = '" + textBox4.Text + "', DateofArrival = '" + textBox5.Text + "',RegistrarID= " + textBox6.Text + " where PaintingID = " + textBox7.Text + "", con);
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("done");

            }catch(OleDbException ff)
            {
                MessageBox.Show("somthing Wrong" + ff.Message);

            }
            finally
            {
                con.Close();

            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void EditPainting_Load(object sender, EventArgs e)
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

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
