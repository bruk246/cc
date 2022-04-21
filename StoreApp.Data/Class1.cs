using Microsoft.Data.SqlClient;
using StoreApp.Logic;
//using System.Data.SqlClient;
//using Microsoft.Extensions.Logging;
using StoreApp;



namespace StoreApp.Data
{

    public class SqlRepository
    {
        // will hold all of the communication to and from the database

        // Fields
        private readonly string _connectionString;
        private SqlConnection conn;

        // Constructor
        public SqlRepository(string connectionString)
        {
            this._connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));

        }

        // Methods
        public bool CreatConnection()

        {

            this.conn = new SqlConnection(this._connectionString);

            try
            {
                Console.WriteLine("Openning Connection ...");

                //open connection
                conn.Open();

                Console.WriteLine("Connection successful!");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                return false;
            }

            Console.Read();
        }


        public List<Customers> GetAllCustomer()
        {
            List<Customers> result = new();
            string sqlQuery = "Select * from Store.Customer";


            using (var _connection = new SqlConnection(_connectionString))
            {
                _connection.Open();
                using (var command = new SqlCommand(sqlQuery, _connection))
                {
                    var reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var customer = new Customers();

                            customer.customerId = Convert.ToInt32(reader["customerID"]);
                            customer.firstName = reader["firstName"].ToString();
                            customer.lastName = reader["lastName"].ToString();
                            result.Add(customer);
                        }
                    }
                    reader.Close();
                }
                _connection.Close();
            }
            //  command.ExecuteNonQuery();

            return result;
        }


    }

}


