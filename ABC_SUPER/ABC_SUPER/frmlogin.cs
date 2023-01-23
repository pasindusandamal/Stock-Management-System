using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ABC_SUPER
{
    public partial class frmlogin : Form
    {
        public frmlogin()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-QO7PCJU;Initial Catalog=ABC_SUPER;Integrated Security=True");

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string user = txtuser.Text;
            string password = txtpassword.Text;
            string a;

            String sql = "select * from Login where User_Name='" + txtuser.Text + "' AND Password='" + txtpassword.Text + "'";
            SqlDataAdapter sda = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            dashboard df = new dashboard();

            try
            {

                if (dt.Rows.Count > 0)
                {
                    user = txtuser.Text;
                    password = txtpassword.Text;

                    this.Hide();
                    df.Show();
                }

                else
                {
                    MessageBox.Show("Error");
                    txtuser.Clear();
                    txtpassword.Clear();
                    txtuser.Focus();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
