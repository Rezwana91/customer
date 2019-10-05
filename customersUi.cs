using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using customer.Manager;
using customer.Model;

namespace customer
{
    public partial class customersUi : Form
    {
        CustomerManager _customerManager = new CustomerManager();
        
        public customersUi()
        {
            InitializeComponent();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {

            Customer customerA = new Customer();

            if (String.IsNullOrEmpty(codeTextBox.Text))
            {
                MessageBox.Show("Code Can not be Empty!!!");
                return;
            }

            customerA.Code = codeTextBox.Text;

            showDataGridView.DataSource = _customerManager.Search(customerA);


        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Customer customerA = new Customer();

            if (String.IsNullOrEmpty(codeTextBox.Text))
            {
                MessageBox.Show("Code Can not be Empty!!!");
                return;
            }

            if (String.IsNullOrEmpty(nameTextBox.Text))
            {
                MessageBox.Show("Name Can not be Empty!!!");
                return;
            }

            if (String.IsNullOrEmpty(addressTextBox.Text))
            {
                MessageBox.Show("Address Can not be Empty!!!");
                return;
            }

            if (String.IsNullOrEmpty(contactTextBox.Text))
            {
                MessageBox.Show("Contact Can not be Empty!!!");
                return;
            }

            if (String.IsNullOrEmpty(districtComboBox.Text))
            {
                MessageBox.Show("Contact Can not be Empty!!!");
                return;
            }

            customerA.Name = nameTextBox.Text;
            customerA.Code = codeTextBox.Text;
            customerA.Address = addressTextBox.Text;
            customerA.Contact = contactTextBox.Text;

            //Check UNIQUE

            if (_customerManager.IsCodeExists(customerA))
            {
                MessageBox.Show(codeTextBox.Text + " Already Exists!");
                return;
            }


            bool isAdded = _customerManager.Save(customerA);

            if (isAdded)
            {
                MessageBox.Show("Saved");
            }
            else

            {
                MessageBox.Show("Not Saved");
            }




        }



        private void customers_Load(object sender, EventArgs e)
        {

        }
    }
}
