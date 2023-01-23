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
    public partial class frmsupplier : Form
    {
        public frmsupplier()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-QO7PCJU;Initial Catalog=ABC_SUPER;Integrated Security=True");

        private void btnadd_Click(object sender, EventArgs e)
        {
            try
            {
                String scode = txtscode.Text;
                String sname = txtsname.Text;
                String smobile = txtsmobile.Text;
                String snnic = txtsnic.Text;

                con.Open();
                SqlCommand cmd = new SqlCommand("EXEC Insert_Product_Info'" + scode + "','" + sname + "','" + smobile + "','" + snnic + "'");
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Inserted");
                Get_Supplier_Info();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
        }

        void Get_Supplier_Info()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("EXEC Get_Supplier_Info", con);
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

        private void frmsupplier_Load(object sender, EventArgs e)
        {
            Get_Supplier_Info();
        }
    }
    }
