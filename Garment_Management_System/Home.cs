using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Garment_Management_System
{
    public partial class Home : Form
    {
        public string whoLoggedIn;

        DataClasses1DataContext db = new DataClasses1DataContext();
        CreateAccount crDb = new CreateAccount();

        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            label6.Text = whoLoggedIn;
            CreateAccount chkUser = db.CreateAccounts.SingleOrDefault(x => x.Id == whoLoggedIn);
            pictureBox4.ImageLocation = chkUser.image;
            pictureBox4.Show();


            if (whoLoggedIn == "chairman")
            {
                panel1.Visible = true;
                panel3.Visible = false;

            }
            else
            {
                panel1.Visible = false;
                panel3.Visible = true;

            }


        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            ClientClass clObj = new ClientClass();
            clObj.whoLoggedIn = this.whoLoggedIn;
            clObj.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Hide();
            InventoryClass newObj = new InventoryClass();
            newObj.whoLoggedIn = this.whoLoggedIn;
            newObj.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Hide();
            YearlyIncomeClass newObj = new YearlyIncomeClass();
            newObj.whoLoggedIn = this.whoLoggedIn;
            newObj.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            Hide();
            Login newObj = new Login();
            newObj.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Hide();
            NoticeClass newObj = new NoticeClass();
            newObj.whoLoggedIn = this.whoLoggedIn;
            newObj.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Hide();
            CurrentOrderClass newObj = new CurrentOrderClass();
            newObj.whoLoggedIn = this.whoLoggedIn;
            newObj.Show();
        }

        

        private void label7_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://orbidapparels.com/");
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            Hide();
            Monthlt_Activity_Class newObj = new Monthlt_Activity_Class();
            newObj.whoLoggedIn = this.whoLoggedIn;
            newObj.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            Hide();
            EmployeeClass employeeObj = new EmployeeClass();
            employeeObj.whoLoggedIn = this.whoLoggedIn;
            employeeObj.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Hide();
            InventoryClass newObj = new InventoryClass();
            newObj.whoLoggedIn = this.whoLoggedIn;
            newObj.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Hide();
            CurrentOrderClass newObj = new CurrentOrderClass();
            newObj.whoLoggedIn = this.whoLoggedIn;
            newObj.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Hide();
            NoticeClass newObj = new NoticeClass();
            newObj.whoLoggedIn = this.whoLoggedIn;
            newObj.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }
    }
}
