using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Data
{
    /// <summary>
    /// Class accessing database
    /// </summary>
    public class DataAccess : IDataAccess
    {
        /// <summary>
        /// Method that loads data from database
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public async Task<List<T>> LoadData<T, U>(string sql, U parameters, string connectionString)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                var rows = await connection.QueryAsync<T>(sql, parameters);

                return rows.ToList();
            }
        }

        /// <summary>
        /// Method thad saves data to database
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public Task SaveData<T>(string sql, T parameters, string connectionString)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                return connection.ExecuteAsync(sql, parameters);
            }
        }
    }
}
