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
    public partial class InsertAttendance : Form
    {
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.15.0;Data Source=C:\\Users\\Malik\\Desktop\\SEF31.accdb;Persist Security Info=False;");
        OleDbCommandBuilder cmd1;
        OleDbDataReader dr;
        DataSet ds;
        OleDbDataAdapter cmd;
        DataSet c;
        public InsertAttendance()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           if(textBox1.Text == "")
            { 
                MessageBox.Show("Ya sharmoot");
            }
            else
            {
                try
                {
                    cmd = new OleDbDataAdapter("select RegistrarID,RName from Registrar'", con);
                    con.Open();
                    //dr = cmd.ExecuteReader();
                    //dr.Read();
                    ds = new System.Data.DataSet();
                    cmd.Fill(ds, "Registrar");
                    dataGridView1.DataSource = ds.Tables[0];
                    

                }
                catch (OleDbException xx)
                {
                    MessageBox.Show("Mistake" + xx.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private void InsertAttendance_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                cmd1 = new OleDbCommandBuilder(cmd);
              //  con.Open();
                c = ds.GetChanges();
                cmd.Update(ds,"AttendanceReport");
                ds.AcceptChanges();
                MessageBox.Show("Successful Update");


            }catch(OleDbException xxxx)
            {
                MessageBox.Show("fffffff" + xxxx.Message);
            }
          //  finally
          //  {
          //      con.Close();
          //  }

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Ya sharmoot");
            }
            else
            {
                try
                {
                    cmd = new OleDbDataAdapter("select SMID,STName from StaffManager'", con);
                    con.Open();
                    //dr = cmd.ExecuteReader();
                    //dr.Read();
                    ds = new System.Data.DataSet();
                    cmd.Fill(ds, "StaffManager");
                    dataGridView2.DataSource = ds.Tables[0];


                }
                catch (OleDbException xx)
                {
                    MessageBox.Show("Mistake" + xx.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void Back_Click(object sender, EventArgs e)
        {
            StaffManager myForm = new StaffManager();
            this.Hide();
            myForm.ShowDialog();
            this.Close();
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            MainMenu myForm = new MainMenu();
            this.Hide();
            myForm.ShowDialog();
            this.Close();
        }
    }
}
