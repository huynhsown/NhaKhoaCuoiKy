﻿using Dapper;
using NhaKhoaCuoiKy.dbs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NhaKhoaCuoiKy.Helpers
{
    internal class ServiceHelper
    {
        public static DataTable getAllServiceCategory()
        {
            DataTable dt = new DataTable();
            try
            {
                Database db = new Database();
                db.openConnection();
                string query = "SELECT * FROM LOAIDICHVU";
                using (SqlCommand cmd = new SqlCommand(query, db.getConnection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Thiết lập mã hóa UTF-8 cho đọc dữ liệu
                        dt.Load(reader);
                    }
                }
                db.closeConnection();
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ ở đây
                throw ex;
            }
            return dt;
        }


        public static DynamicParameters addNewCategory(string category)
        {
            Database db = new Database();
            try
            {
                var p = new DynamicParameters();
                p.Add("@MaLoaiDichVu", 0, DbType.Int32, direction: ParameterDirection.Output);
                p.Add("@LoaiDichVu", category);

                using (IDbConnection connection = db.getConnection)
                {
                    connection.Execute("addCategory", p, commandType: CommandType.StoredProcedure);
                }
                return p;
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
    }
}