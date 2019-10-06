using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using customer.Model;


namespace customer.Repository
{
    public class CustomerRepository
    {

        public List<Customer> Search(Customer customerA)
        {

            //Connection
            string connectionString = @"Server=DESKTOP-55FHBO2; Database=CustomerA; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 
            //INSERT INTO Items (Name, Price) Values ('Black', 120)

            string commandString = @"SELECT * FROM Customer WHERE Code = '" + customerA.Code + "'";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open
            sqlConnection.Open();



            //With DataReader
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            List<Customer> customerss = new List<Customer>();

            while (sqlDataReader.Read())
            {
                //customerA.Code = sqlDataReader["Code"].ToString();
                customerA.Name = sqlDataReader["Name"].ToString();
                customerA.Address = sqlDataReader["Address"].ToString();
                customerA.Contact = sqlDataReader["Contact"].ToString();

                customerss.Add(customerA);

            }


            //Close
            sqlConnection.Close();

            //return dataTable;
            return customerss;

        }

        public bool Save(Customer customerA)
        {

            bool isAdded = false;
            //Connection
            string connectionString = @"Server=DESKTOP-55FHBO2; DataBase=CustomerA; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command
            //INSERT INTO Customer (Code,Name, Address,Contact) Values (0001,'Arafat', 'Mirpur-13','01625420852')
            string commandString = @"INSERT INTO Customer (Code,Name, Address,Contact,DistrictId) Values ('" + customerA.Code + "', '" + customerA.Name + "', '" + customerA.Address + "', '" + customerA.Contact + "', '" + customerA.DistrictId + "')";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open
            sqlConnection.Open();

            //Execute
            int isExecuted = sqlCommand.ExecuteNonQuery();

            if (isExecuted > 0)
            {
                isAdded = true;
            }


            //Close
            sqlConnection.Close();
            return isAdded;

        }

        public bool IsCodeExists(Customer customerA)
        {
            bool exists = false;

            //Connection
            string connectionString =
                @"Server=DESKTOP-55FHBO2; Database=CustomerA; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 
            //INSERT INTO Items (Name, Price) Values ('Black', 120)
            string commandString = @"SELECT * FROM Customer WHERE Code='" + customerA.Code + "'";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open
            sqlConnection.Open();
            //Show
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);


            if (dataTable.Rows.Count > 0)
            {
                exists = true;
            }

            //Close
            sqlConnection.Close();
            return exists;
        }

        public bool IsContactExists(Customer customerA)
        {
            bool exists = false;

            //Connection
            string connectionString =
                @"Server=DESKTOP-55FHBO2; Database=CustomerA; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 
            //INSERT INTO Items (Name, Price) Values ('Black', 120)
            string commandString = @"SELECT * FROM Customer WHERE Contact='" + customerA.Contact + "'";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open
            sqlConnection.Open();
            //Show
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);


            if (dataTable.Rows.Count > 0)
            {
                exists = true;
            }

            //Close
            sqlConnection.Close();
            return exists;
        }

       public List<DistrictModel> DistrictComboBox()
        {
            //Connection
            string connectionString = @"Server=DESKTOP-55FHBO2; Database=CustomerA; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 
            //INSERT INTO Items (Name, Price) Values ('Black', 120)

            string commandString = @"SELECT Id,Name FROM District";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open
            sqlConnection.Open();



            //With DataReader
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            List<DistrictModel> customerss = new List<DistrictModel>();

            while (sqlDataReader.Read())
            {
                DistrictModel districtModelA = new DistrictModel();
                districtModelA.Id = sqlDataReader["Id"].ToString();
                districtModelA.Name = sqlDataReader["Name"].ToString();
               

                customerss.Add(districtModelA);

            }


            //Close
            sqlConnection.Close();

            //return dataTable;
            return customerss;

        }
    }
}
