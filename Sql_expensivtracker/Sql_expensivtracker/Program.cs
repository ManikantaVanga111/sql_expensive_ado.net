using System.Data.SqlClient;
namespace Sql_expensivtracker
{
    class Transaction
    {
        public static void addtransaction(SqlConnection conn)
        {

            SqlCommand cmd = new SqlCommand($"insert into Et values (@Title,@Description1,@amount,@Et_Date)", conn);
            Console.WriteLine("Enter the title");
            string Title = Console.ReadLine();
            Console.WriteLine("Enter the description");
            string Description = Console.ReadLine();
            Console.WriteLine("Enter the amount");
            int amount = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the date");
            DateTime date = Convert.ToDateTime(Console.ReadLine());
            cmd.Parameters.AddWithValue("@Title", Title);
            cmd.Parameters.AddWithValue("@Description1", Description);
            cmd.Parameters.AddWithValue("@amount", amount);
            cmd.Parameters.AddWithValue("@Et_Date", date);
            cmd.ExecuteNonQuery();
            Console.WriteLine("saved successfully");
        }
        public static void expensive(SqlConnection conn)
        {
            SqlCommand cmd = new SqlCommand($"select * from Et where amount <0", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    Console.WriteLine(dr[i]);
                }
            }
        }
        public static void income(SqlConnection conn)
        {
            SqlCommand cmd = new SqlCommand($"select * from Et where amount >0", conn);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                for (int i = 0; i < r.FieldCount; i++)
                {
                    Console.WriteLine(r[i]);
                }
            }
        }

        public static void Availablebalance(SqlConnection conn)
        {
            SqlCommand cmd = new SqlCommand($"select sum(amount) as AvailableBalance from Et", conn);
            int dr =Convert.ToInt32( cmd.ExecuteScalar());
            Console.WriteLine($"Available balance is {dr}");

        }
       
    }
        internal class Program
        {
            static void Main(string[] args)
            {
                while (true)
                {

                SqlConnection conn = new SqlConnection("Data source=US-1C4R8S3; database=expensivetracker;Integrated security=true");
                conn.Open();
                    Console.WriteLine("1 for Add Transaction");
                    Console.WriteLine("2 for View Expenses");
                    Console.WriteLine("3 for View Income");
                    Console.WriteLine("4 for AvailableBalance");
                    Console.WriteLine("Choose the option");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            {
                                Transaction.addtransaction(conn);
                                break;
                            }
                        case 2:
                            {
                                Transaction.expensive(conn);
                                break;
                            }
                        case 3:
                            {
                                Transaction.income(conn);
                                break;
                            }
                        case 4:
                            {
                                Transaction.Availablebalance(conn);
                                break;
                            }
                    default:
                        {
                            Console.WriteLine("Wrong choice entered");
                            break;
                        }
                        conn.Close();
                }
              
            }
        }
       
        }
    
}