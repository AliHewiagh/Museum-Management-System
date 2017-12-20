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
    public partial class AddPainting : Form

    {
        private OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.15.0;Data Source=C:\\Users\\Malik\\Desktop\\SEF31.accdb;Persist Security Info=False;");
        private OleDbCommand cmd;
        public AddPainting()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "")
                {
                    cmd = new OleDbCommand("insert into Painting(PaintingID,PName,CreationDate,PainterName,DateofArrival,RegistrarID)values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "')", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Added Successfully");
                }
                else
                {
                    MessageBox.Show("Cannot be added. Please try again.");
                }

            }
            catch
            {
                MessageBox.Show("Cannot be added. Please try again.");
            }finally
            {
                con.Close();
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AddPainting_Load(object sender, EventArgs e)
        {

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
    }
}
