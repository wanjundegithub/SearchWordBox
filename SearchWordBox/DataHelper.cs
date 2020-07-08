using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace SearchWordBox
{
    public static class DataHelper
    {
        private  static string _connectStr = @"server=127.0.0.1;port=3306;user=root;password=waju1010; database=test;";

        private static MySqlConnection _sqlConnection = new MySqlConnection(_connectStr);
        private static void ConnectDB()
        {
           try
            {
                _sqlConnection.Open();
            }
            catch(Exception e)
            {
                //DialogUtil.ShowMessageWindowAsync("链接数据库错误", e.Message);
            }
        }

        private static void CloseConnectDB()
        {
            if (_sqlConnection.State == ConnectionState.Open)
                _sqlConnection.Close();
        }
        public static DataTable GetRelativeResults(string searchField)
        {
            DataTable dt = new DataTable();
            ConnectDB();
            string sqlStr = @"SELECT * FROM TEST.RelationWord WHERE  RelationWord Like  '" +"%"+
                 searchField +"%"+ "';";
            var cmd = new MySqlCommand(sqlStr, _sqlConnection);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            CloseConnectDB();
            return dt;
        }
    }
}
