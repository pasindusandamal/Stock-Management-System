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
    public partial class frmloyaltyinfo : Form
    {
        public frmloyaltyinfo()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-QO7PCJU;Initial Catalog=ABC_SUPER;Integrated Security=True");
        private void btnadd_Click(object sender, EventArgs e)
        {
            try
            {
                String prcode = txtprcode.Text;
                String prname = txtprnamae.Text;
                String discount = txtdiscount.Text;
                String cnic = txtcnic.Text;
                

                con.Open();
                SqlCommand cmd = new SqlCommand("EXEC Insert_Loyalty_Info'" + prcode + "','" + prname + "','" + discount + "','" + cnic + "'");
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Inserted");
                Get_Loyalty_Info();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
        }

        void Get_Loyalty_Info()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("EXEC Get_Loyalty_Info", con);
                SqlDataAdapter sd = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sd.Fill(dt);
                dgvsinfo.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            con.Close();

        }

        private void frmloyaltyinfo_Load(object sender, EventArgs e)
        {
            Get_Loyalty_Info();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
          

                 try
            {
                String nic = txtprcode.Text;
                con.Open();
                SqlCommand cmd = new SqlCommand("DeleteDataloyalty_Info", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", nic);

                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
