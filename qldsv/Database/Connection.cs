using System.Data.SqlClient;

namespace qldsv.Database
{
    class Connection
    {
        public string DataSource;
        public string InitialCatalog;
        public string UserId;
        public string Password;

        public Connection(string dataSource, string initialCatalog, string userId, string password)
        {
            DataSource = dataSource;
            InitialCatalog = initialCatalog;
            UserId = userId;
            Password = password;
        }

        public override string ToString()
        {
            return string.Format("Data Source={0};Initial Catalog={1};User Id={2};Password={3}",
                DataSource, InitialCatalog, UserId, Password);
        }

        public SqlConnection Connect(SqlConnection Conn)
        {
            Conn.ConnectionString = this.ToString();
            Conn.Open();
            return Conn;
        }
    }
}
