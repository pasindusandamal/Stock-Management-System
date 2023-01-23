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
    public partial class frmsell : Form
    {
        public frmsell()
        {
            InitializeComponent();
        }

        private void guna2Panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-QO7PCJU;Initial Catalog=ABC_SUPER;Integrated Security=True");
        private void guna2TextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            try {
                String PCode = txtsearch.Text;

                //Create the command
                string query = "SELECT * FROM Product WHERE Pro_Code = '" + PCode + "'";
                SqlCommand cmd = new SqlCommand(query, con);



                //Add value to parameter
                //cmd.Parameters.AddWithValue("@itemName", "PCode");

                //Open the connection
                con.Open();

                //Execute the command
                SqlDataReader reader = cmd.ExecuteReader();

                //Read data from the database
                if (reader.Read())
                {
                    txtbarcode.Text = reader["Pro_Code"].ToString();
                    txtpname.Text = reader["Pro_Name"].ToString();
                    txtdescription.Text = reader["Pro_Description"].ToString();
                    txtunitp.Text = reader["Price"].ToString();
                    txtqty.Text = reader["Quentity"].ToString();

                    //etc
                }

                //Close the connection
                con.Close();
            }
            catch(Exception ex)

            {

                
            }

        }

        private void txtdescription_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnadd_Click(object sender, EventArgs e)
        {

            try
            {
                //Create a DataTable object to store the values
                DataTable dt = new DataTable();

                

                string Pcode = txtbarcode.Text;
                string Pname= txtpname.Text;
                string Pdescription = txtdescription.Text;
                int Pprice= int.Parse(txtunitp.Text);
                int Pquentity = int.Parse(txtqty.Text);
                int Total = Pprice * Pquentity;


                dgvaddpr.Rows.Add(Pcode, Pname, Pdescription, Pprice, Pquentity,Total);     
                int sum = 0;
                for(int i = 0; i <= dgvaddpr.Rows.Count - 1; i++)
                {
                    sum += Convert.ToInt32(dgvaddpr.Rows[i].Cells[5].Value);
                }

                txtsubtotal.Text = sum.ToString();

                txtbarcode.Text = "";
                txtpname.Text = "";
                txtdescription.Text = "";
                txtunitp.Text = "";
                txtqty.Text = "";




           


              

               



            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvaddpr_AllowUserToAddRowsChanged(object sender, EventArgs e)
        {

        }

        private void dgvaddpr_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
           
          
        }

        private void guna2TextBox1_KeyUp_1(object sender, KeyEventArgs e)
        {
            try
            {
                string subtotal = txtsubtotal.Text;
                int payment = int.Parse(txtpayment.Text);
                int npayment = payment - int.Parse(subtotal);
                txtbalance.Text = npayment.ToString();
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
                dgvslinfo.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            con.Close();
        }

        private void frmsell_Load(object sender, EventArgs e)
        {
            Get_Stock_Info();
        }
    }
}
