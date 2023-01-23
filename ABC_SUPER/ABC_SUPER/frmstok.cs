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
    public partial class frmstok : Form
    {
        public frmstok()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-QO7PCJU;Initial Catalog=ABC_SUPER;Integrated Security=True");

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                String pcode = txtpcode.Text;
                String pname = txtpname.Text;
                String pdescription = txtpdesc.Text;
                String mdate = txtmdate.Text;
                String edate = txtedate.Text;
                String pprice = txtprice.Text;
                String pquentity = txtqquentity.Text;

                con.Open();
                SqlCommand cmd = new SqlCommand("EXEC Insert_Product_Info '" + pcode + "','" + pname + "','" + pdescription + "','" + mdate + "','" + edate + "','" + pprice + "','" + pquentity + "'");
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Inserted");
                con.Close();
                Get_Stock_Info();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        void Get_Stock_Info()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("EXEC Get_Product_Info", con);
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

       

        private void frmstok_Load(object sender, EventArgs e)
        {
            Get_Stock_Info();
        }
    }
}
