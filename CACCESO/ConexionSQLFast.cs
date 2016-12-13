using System;
using System.Collections.Generic;
using System.Data;
//using System.Data.SQLite;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;


namespace CACCESO
{
    class ConexionSQLFast
    {


//        public string ConnectionString { get; private set; }
//        public string DatabaseFilename { get; private set; }

//        public ConexionSQLFast(string filename)
//        {
//            this.DatabaseFilename = filename;
//            this.ConnectionString = String.Format(@"Data Source={0};Version=3;", this.DatabaseFilename);
//        }

//        public int ExecuteNonQueryNonTransactional(Func<SQLiteCommand, int> func)
//        {
//            int resultado;

//            using (var connection = new SQLiteConnection(this.ConnectionString))
//            {
//                connection.Open();

//                using (var command = new SQLiteCommand(connection))
//                {
//                    resultado = func.Invoke(command);
//                }

//                connection.Close();
//            }

//            return resultado;
//        }

//        public int ExecuteNonQuery(Func<SQLiteCommand, int> func)
//        {
//            int resultado;

//            using (var connection = new SQLiteConnection(this.ConnectionString))
//            {
//                connection.Open();

//                using (var command = new SQLiteCommand(connection))
//                using (var transaction = connection.BeginTransaction())
//                {
//                        resultado = func.Invoke(command);
//                        transaction.Commit();
//                }
//            }

//            return resultado;
//        }

//        public List<T> ExecuteQueryReader<T>(string sql, SQLiteParameter[] sqlParams, Func<SQLiteDataReader, List<T>> func)
//        {
//            var resultado = new List<T>();

//            using (var connection = new SQLiteConnection(this.ConnectionString))
//            {
//                connection.Open();

//                using (var command = new SQLiteCommand(connection))
//                {
//                    command.CommandText = sql;
//                    if (sqlParams != null) { command.Parameters.AddRange(sqlParams); }

//                    using (var transaction = connection.BeginTransaction())
//                    using (var reader = command.ExecuteReader())
//                    {
//                        resultado = func.Invoke(reader);
//                        transaction.Commit();
//                    }
//                }
//                connection.Close();
//            }

//            return resultado;
//        }

//        public LinkedList<T> ExecuteQueryReaderLinkedList<T>(string sql, SQLiteParameter[] sqlParams, Func<SQLiteDataReader, LinkedList<T>> func)
//        {
//            var resultado = new LinkedList<T>();

//            using (var connection = new SQLiteConnection(this.ConnectionString))
//            {
//                connection.Open();

//                using (var command = new SQLiteCommand(connection))
//                {
//                    command.CommandText = sql;
//                    if (sqlParams != null) { command.Parameters.AddRange(sqlParams); }

//                    using (var transaction = connection.BeginTransaction())
//                    using (var reader = command.ExecuteReader())
//                    {
//                        resultado = func.Invoke(reader);
//                        transaction.Commit();
//                    }
//                }
//                connection.Close();
//            }

//            return resultado;
//        }

//        public DataTable ExecuteQueryAdapter(string sql, SQLiteParameter[] sqlParams, Func<SQLiteDataAdapter, DataTable> func)
//        {
//            var resultado = new DataTable();

//            using (var connection = new SQLiteConnection(this.ConnectionString))
//            {
//                connection.Open();

//                using (var transaction = connection.BeginTransaction())
//                using (var adapter = new SQLiteDataAdapter(sql, connection))
//                using (var builder = new SQLiteCommandBuilder(adapter))
//                {
//                    var command = adapter.SelectCommand;
//                    if (sqlParams != null) { command.Parameters.AddRange(sqlParams); }

//                    resultado = func.Invoke(adapter);
//                    transaction.Commit();
//                }

//                connection.Close();
//            }

//            return resultado;
//        }
    }

}
