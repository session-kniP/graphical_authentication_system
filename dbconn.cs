using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ESignature
{
    class dbconn
    {
        static string server = "";     //MySQL server (localhost:  127.0.0.1)
        static string database = "";    //name of database
        static string user = "";    //username
        static string pass = "";    //password
    
        static MySqlConnection conn;

        public static bool should_return = true;

        public static void Connect()
        {
            string conn_str = "server=" + server + ";database=" + database + ";user=" + user + ";password=" + pass + ";";

            conn = new MySqlConnection(conn_str);

            try
            {
                conn.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //==============================================
        public static void RegQuery(string username, List<bool> bitmap, bool is_on_submit)
        {
            string bit_str = "";

            for (int i = 0; i < bitmap.Count; i++)
            {
                bit_str += Convert.ToString(Convert.ToInt32(bitmap[i])) + " ";
            }

            if (!is_on_submit)
            {
                string query = "SELECT * FROM users WHERE username = '" + username + "'";

                using (MySqlCommand comm = new MySqlCommand(query, conn))
                {
                    try
                    {
                        MySqlDataReader reader = comm.ExecuteReader();
                        if (reader.Read())
                        {
                            MessageBox.Show("Такой пользователь уже существует");
                            should_return = true;
                            return;
                        }
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

                should_return = false;
                query = "INSERT INTO users(username) VALUES('" + username + "')";

                using (MySqlCommand comm = new MySqlCommand(query, conn))
                    try
                    {
                        comm.ExecuteNonQuery();
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                        return;
                    }
            }

            string query2 = "SELECT * FROM users WHERE username = '" + username + "' limit 1";
            int usr_id = 0;

            using (MySqlCommand comm = new MySqlCommand(query2, conn))
            {
                MySqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                    usr_id = Convert.ToInt32(reader[0]);
            }

            string query3 = "INSERT INTO `user_keys`(`id_user`, `key`) VALUES(" + usr_id + ", '" + bit_str + "')";

            using (MySqlCommand comm = new MySqlCommand(query3, conn))
            {
                try
                {
                    comm.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
        }


        //=============================================================
        public static bool Comparator(string name, List<bool> bitmap)
        {
            bool is_equal = false;
            string query = "SELECT `key` FROM `user_keys` INNER JOIN users ON users.id_user = `user_keys`.id_user WHERE users.username = '" + name + "'";

            MySqlCommand comm = new MySqlCommand(query, conn);

            using (MySqlDataReader reader = comm.ExecuteReader())
            {

                //int[] bit_int = bitmap.Select(x => int.Parse(Convert.ToString(Convert.ToInt32(x)))).ToArray();
                int[] bit_int = bitmap.Select(x => Convert.ToInt32(x)).ToArray();
                int cmp_len = 0;

                foreach (int x in bit_int)
                {
                    if (x == 1) cmp_len++;
                }

                List<int> max_comp_lengths = new List<int>();

                while (reader.Read())
                {
                    int[] comp_bit_int = Convert.ToString(reader[0]).TrimEnd().Split(' ').Select(int.Parse).ToArray();
                    int max_comp_length = 0;

                    for (int i = 0; i < comp_bit_int.Length; i++)
                    {
                        if ((bit_int[i] == 1) && (comp_bit_int[i] == 1))
                            max_comp_length++;
                    }
                    max_comp_lengths.Add(max_comp_length);
                }

                int max = 0;

                foreach (int l in max_comp_lengths)
                    if (l > max) max = l;

                if (max >= (cmp_len - cmp_len * 10 / 100))
                    is_equal = true;
            }

            return is_equal;
        }
    }
}
