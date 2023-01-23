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
    public partial class frmcustomer : Form
    {
        public frmcustomer()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-QO7PCJU;Initial Catalog=ABC_SUPER;Integrated Security=True");
        private void btnadd_Click(object sender, EventArgs e)

        {
            try
            {
                String nic = txtcnic.Text;
                String cname = txtcname.Text;
                String caddress = txtcaddress.Text;
                String cmobile = txtcmobile.Text;
                con.Open();
                SqlCommand cmd = new SqlCommand("EXEC Insert_Cust_Info '"+nic+"','"+cname+"','"+caddress+"','"+cmobile+"'");
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Inserted");
                Get_Customer_Info();


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
        }

        void Get_Customer_Info()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("EXEC Get_Customer_Info",con);
                SqlDataAdapter sd = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sd.Fill(dt);
                dgvcinfo.DataSource = dt;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            con.Close();
        }

        private void frmcustomer_Load(object sender, EventArgs e)
        {
            Get_Customer_Info();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            try
            {
                String nic = txtcnic.Text;
                con.Open();
                SqlCommand cmd = new SqlCommand("DeleteData", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", nic);

                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
