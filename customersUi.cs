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
        string id;

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

            if (codeTextBox.TextLength == 4)
            {
                MessageBox.Show("Code must be 4 digit!!!");
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

            if (contactTextBox.TextLength == 11)
            {
                MessageBox.Show("Contact must be 11 digit!!!");
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



            //Check UNIQUE

            if (_customerManager.IsContactExists(customerA))
            {
                MessageBox.Show(contactTextBox.Text + " Already Exists!");
                return;
            }

            //add check

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
            districtComboBox.DataSource = _customerManager.DistrictComboBox();
        }

        private void showDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.showDataGridView.Rows[e.RowIndex];
                id = row.Cells[0].Value.ToString();
                codeTextBox.Text = row.Cells[1].Value.ToString();
                nameTextBox.Text = row.Cells[2].Value.ToString();
                addressTextBox.Text = row.Cells[3].Value.ToString();
                contactTextBox.Text = row.Cells[4].Value.ToString();
                districtComboBox.Text = row.Cells[5].Value.ToString();

            }
        }
        private void gridStateZone_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            LoadSerial(gridStateZone);
        }

        private void LoadSerial(object gridStateZone)
        {
            throw new NotImplementedException();
        }

        private void LoadSerial(DataGridView grid)
        {
            foreach (DataGridViewRow row in grid.Rows)
            {
                grid.Rows[row.Index].HeaderCell.Value = string.Format("{0}  ", row.Index + 1).ToString();
                row.Height = 25;
            }
        }

       
    }
}
