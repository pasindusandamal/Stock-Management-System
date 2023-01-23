using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ABC_SUPER
{
    public partial class frmemployee : Form
    {
        public frmemployee()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-QO7PCJU;Initial Catalog=ABC_SUPER;Integrated Security=True");

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                String ecode = txtecode.Text;
                String ename = txtename.Text;
                String eaddress = txteaddress.Text;
                String eemail = txteemail.Text;
                String emobile= txtemobile.Text;
                String erole = txterole.Text;
                String esalary = txtesalary.Text;
                con.Open();
                SqlCommand cmd = new SqlCommand("EXEC INSERT_Employee_Info '"+ecode+"''" + ename + "','" + eaddress + "','" + eemail + "','" + emobile + "','"+ erole + "','"+ esalary + "'");
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Inserted");
                Get_Employee_Info();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
        }

        void Get_Employee_Info()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("EXEC GetEmployeeInfo", con);
                SqlDataAdapter sd = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sd.Fill(dt);
                dgveinfo.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            con.Close();
        }

        private void frmemployee_Load(object sender, EventArgs e)
        {
            Get_Employee_Info();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }
    }
}
