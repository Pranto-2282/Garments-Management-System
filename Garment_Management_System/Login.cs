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
    public partial class Login : Form
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        CreateAccount crDb = new CreateAccount();


        public Login()
        {
            InitializeComponent();
            panel1.Visible = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            panel1.Visible = true; //signup panel will pop up
        }

        private void label5_Click(object sender, EventArgs e)
        {
            panel1.Visible = false; 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //login
            string userNm = textBox1.Text;
            string pass = textBox2.Text;

            CreateAccount chkUser = db.CreateAccounts.SingleOrDefault(x => x.Id == userNm);
            

            if (chkUser != null)
            {
                if (pass == chkUser.password)
                {
                    Hide();
                    Home objectHome = new Home();
                    objectHome.whoLoggedIn = userNm;
                    objectHome.Show();
                }

                else
                {
                    MessageBox.Show("Wrong Password");
                    Hide();
                    Login newLogin = new Login();
                    newLogin.Show();
                }


            }

            else
            {
                MessageBox.Show("Wrong User Name or Password");
                Hide();
                Login newLogin = new Login();
                newLogin.Show();
            }

            
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "User Name")
            {
                textBox1.Text = "";

                textBox1.ForeColor = Color.White;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "User Name";

                textBox1.ForeColor = Color.Silver;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Password")
            {
                textBox2.Text = "";

                textBox2.ForeColor = Color.White;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Password";

                textBox2.ForeColor = Color.Silver;
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "First Name")
            {
                textBox3.Text = "";

                textBox3.ForeColor = Color.White;
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = "First Name";

                textBox3.ForeColor = Color.Silver;
            }
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text == "Last Name")
            {
                textBox4.Text = "";

                textBox4.ForeColor = Color.White;
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                textBox4.Text = "Last Name";

                textBox4.ForeColor = Color.Silver;
            }
        }

        private void textBox8_Enter(object sender, EventArgs e)
        {
            if (textBox8.Text == "Username")
            {
                textBox8.Text = "";

                textBox8.ForeColor = Color.White;
            }
        }

        private void textBox8_Leave(object sender, EventArgs e)
        {
            if (textBox8.Text == "")
            {
                textBox8.Text = "Username";

                textBox8.ForeColor = Color.Silver;
            }
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            if (textBox5.Text == "Password")
            {
                textBox5.Text = "";

                textBox5.ForeColor = Color.White;
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                textBox5.Text = "Password";

                textBox5.ForeColor = Color.Silver;
            }
        }

        private void textBox6_Enter(object sender, EventArgs e)
        {
            if (textBox6.Text == "Someone@example.com")
            {
                textBox6.Text = "";

                textBox6.ForeColor = Color.White;
            }
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            if (textBox6.Text == "")
            {
                textBox6.Text = "Someone@example.com";

                textBox6.ForeColor = Color.Silver;
            }
        }

        private void textBox7_Enter(object sender, EventArgs e)
        {
            if (textBox7.Text == "Mobile No")
            {
                textBox7.Text = "";

                textBox7.ForeColor = Color.White;
            }
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            if (textBox7.Text == "")
            {
                textBox7.Text = "Mobile No";

                textBox7.ForeColor = Color.Silver;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ///signup
            if (checkBox1.CheckState == CheckState.Checked)
            {
                //adding into CreateAccount database

                crDb.first_name = textBox3.Text;
                crDb.last_name = textBox4.Text;
                crDb.Id = textBox8.Text;
                crDb.password = textBox5.Text;
                crDb.email = textBox6.Text;
                crDb.mobile_no = int.Parse(textBox7.Text);
                crDb.position = textBox9.Text;

                db.CreateAccounts.InsertOnSubmit(crDb);
                db.SubmitChanges();
                //db.ExecuteNonQuery();


                MessageBox.Show("Account Created");
            }

            else
            {
                MessageBox.Show("Please accept the terms and condition");
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png|All Files(*.*)|*.*";
            dlg.Title = "Select an image";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string picLoc1 = dlg.FileName.ToString();
                pictureBox5.ImageLocation = picLoc1;
                crDb.image = picLoc1;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
