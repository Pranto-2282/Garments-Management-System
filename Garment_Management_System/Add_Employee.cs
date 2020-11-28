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
    public partial class Add_Employee : Form
    {

        public string whoLoggedIn;

        DataClasses1DataContext db = new DataClasses1DataContext();
        Employee employeeDb = new Employee();


        public Add_Employee()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png|All Files(*.*)|*.*";
            dlg.Title = "Select an image";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string picLoc1 = dlg.FileName.ToString();
                pictureBox1.ImageLocation = picLoc1;
                employeeDb.image = picLoc1;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //add employee button
                employeeDb.full_name = textBox5.Text;
                employeeDb.position = textBox1.Text;
                employeeDb.email = textBox2.Text;
                employeeDb.dob = textBox3.Text;
                employeeDb.mobile_no = int.Parse(textBox4.Text);
                employeeDb.address = textBox6.Text;
                employeeDb.blood_group = textBox7.Text;
                employeeDb.sallery = int.Parse(textBox8.Text);

                db.Employees.InsertOnSubmit(employeeDb);
                db.SubmitChanges();
                


                MessageBox.Show("Data Inserted");
            }

            catch
            {
                MessageBox.Show("Invalid Input");
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Hide();
            EmployeeClass obj = new EmployeeClass();
            obj.whoLoggedIn = this.whoLoggedIn;
            obj.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            EmployeeClass emObj = new EmployeeClass();
            emObj.whoLoggedIn = this.whoLoggedIn;
            emObj.Show();
        }

        private void Add_Employee_Load(object sender, EventArgs e)
        {

        }
    }
}
