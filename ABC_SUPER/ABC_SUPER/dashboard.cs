using System;
using System.Windows.Forms;

namespace ABC_SUPER
{
    public partial class dashboard : Form
    {
        public dashboard()
        {
            InitializeComponent();
        }

        private void dashboard_Load(object sender, EventArgs e)
        {
            string timeString = DateTime.Now.ToString("h:mm tt");
            txttime.Text = timeString;
            txtdate.Text = DateTime.Today.ToString("dd/MM/yyyy");
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Panel1.Controls.Clear();
            this.Refresh();
            frmstok myForm = new frmstok();
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            Panel1.Controls.Add(myForm);
            myForm.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Panel1.Controls.Clear();
            this.Refresh();
            frmsell myForm1 = new frmsell();
            myForm1.TopLevel = false;
            myForm1.AutoScroll = true;
            Panel1.Controls.Add(myForm1);
            myForm1.Show();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Panel1.Controls.Clear();
            this.Refresh();
            frmcustomer myForm2 = new frmcustomer();
            myForm2.TopLevel = false;
            myForm2.AutoScroll = true;
            Panel1.Controls.Add(myForm2);
            myForm2.Show();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            Panel1.Controls.Clear();
            this.Refresh();
            frmemployee myForm3 = new frmemployee();
            myForm3.TopLevel = false;
            myForm3.AutoScroll = true;
            Panel1.Controls.Add(myForm3);
            myForm3.Show();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            Panel1.Controls.Clear();
            this.Refresh();
            frmsupplier myForm4 = new frmsupplier();
            myForm4.TopLevel = false;
            myForm4.AutoScroll = true;
            Panel1.Controls.Add(myForm4);
            myForm4.Show();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            Panel1.Controls.Clear();
            this.Refresh();
            frmloyaltyinfo myForm5 = new frmloyaltyinfo();
            myForm5.TopLevel = false;
            myForm5.AutoScroll = true;
            Panel1.Controls.Add(myForm5);
            myForm5.Show();
        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            frmlogin fl = new frmlogin();
            this.Hide();
            fl.Show();
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
