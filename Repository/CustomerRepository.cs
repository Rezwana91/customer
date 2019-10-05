using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  System.Data;
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

            string commandString = @"SELECT * FROM Customer WHERE Code = '"+customerA.Code+ "'";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open
            sqlConnection.Open();

           

            //With DataReader
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            List<Customer> customers = new List<Customer>();

            while (sqlDataReader.Read())
            {
                Customer customerB = new Customer();
                customerB.Code = sqlDataReader["code"].ToString();
                customerB.Name = sqlDataReader["Name"].ToString();
                customerB.Address = sqlDataReader["Address"].ToString();
                customerB.Contact = sqlDataReader["Contact"].ToString();

                customers.Add(customerB);
                
            }

           
            //Close
            sqlConnection.Close();

            //return dataTable;
            return customers;
            
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
            string commandString = @"SELECT * FROM Items WHERE Name='" + customerA.Code + "'";
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


    }
}
