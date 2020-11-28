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
    public partial class EmployeeClass : Form
    {
        public string whoLoggedIn;

        DataClasses1DataContext db = new DataClasses1DataContext();
        Employee employeeDb = new Employee();
        public EmployeeClass()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            
            Application.Exit();
        }

        

        private void button1_Click_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Employees;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ///searching
            string name = comboBox1.Text;
            employeeDb = db.Employees.SingleOrDefault(x => x.full_name == name);
            if (employeeDb != null)
            {

                textBox5.Text = employeeDb.full_name;
                textBox1.Text = employeeDb.position;
                textBox2.Text = employeeDb.dob;
                textBox3.Text = employeeDb.mobile_no.ToString();
                textBox4.Text = employeeDb.address;
                textBox6.Text = employeeDb.sallery.ToString();

                pictureBox1.ImageLocation = employeeDb.image.ToString();
                pictureBox1.Show();
                
            }

            //else { MessageBox.Show("Data Not Found"); }
        }

        private void EmployeeClass_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = db.Employees;
            comboBox1.DisplayMember = "full_name";
            comboBox1.ValueMember = "id";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            Add_Employee addEmObj = new Add_Employee();
            addEmObj.whoLoggedIn = this.whoLoggedIn;
            addEmObj.Show();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        
        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ///delete employee
            string fullName = textBox5.Text;
            Employee dltEmployee = db.Employees.SingleOrDefault(x => x.full_name == fullName);
            db.Employees.DeleteOnSubmit(dltEmployee);
            db.SubmitChanges();
            MessageBox.Show("Employee Deleted");

            //opening this window by refershing again
            Hide();
            EmployeeClass emObj = new EmployeeClass();
            emObj.whoLoggedIn = this.whoLoggedIn;
            emObj.Show();
           

        }

        private void label12_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ///Update Employee

            try
            {
                string fullName = textBox5.Text;
                Employee upEmployee = db.Employees.SingleOrDefault(x => x.full_name == fullName);

                upEmployee.full_name = textBox5.Text;
                upEmployee.position = textBox1.Text;
                upEmployee.dob = textBox2.Text;
                upEmployee.mobile_no = int.Parse(textBox3.Text);
                upEmployee.address = textBox4.Text;
                upEmployee.sallery = int.Parse(textBox6.Text);

                db.SubmitChanges();
                MessageBox.Show("Data Updated");

                //opening this window by refershing again
                Hide();
                EmployeeClass emObj = new EmployeeClass();
                emObj.whoLoggedIn = this.whoLoggedIn;
                emObj.Show();
            }

            catch
            {
                MessageBox.Show("Name can not be updated");
            }
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Hide();
            Home homeObj = new Home();
            homeObj.whoLoggedIn = this.whoLoggedIn;
            homeObj.Show();
        }
    }
}
