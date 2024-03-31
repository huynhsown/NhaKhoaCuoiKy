using Dapper;
using NhaKhoaCuoiKy.dbs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
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
                p.Add("@TenLoaiDichVu", category);

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

        public static int countCategoryItems(int id)
        {
            Database db = new Database();
            int count = 0;
            try
            {
                db.openConnection();
                using(SqlCommand cmd = new SqlCommand("countCategoryItems", db.getConnection))
                {
                    cmd.Parameters.AddWithValue("@MaLoaiDichVu", id);
                    cmd.CommandType = CommandType.StoredProcedure;
                    count = (int)cmd.ExecuteScalar();
                }
                db.closeConnection();
            }
            catch
            {
                throw;
            }
            finally
            {
                db.closeConnection();
            }
            return count;
        }

        public static bool removeCategory(int id)
        {
            Database db = new Database();
            bool check = false;
            try
            {
                db.openConnection();
                using (SqlCommand cmd = new SqlCommand("removeCategory", db.getConnection))
                {
                    cmd.Parameters.AddWithValue("@MaLoaiDichVu", id);
                    cmd.CommandType = CommandType.StoredProcedure;
                    if(cmd.ExecuteNonQuery() >= 1)
                    {
                        check = true;
                    }
                }
                db.closeConnection();
                return check;
            }
            catch
            {
                throw;
            }
            finally
            {
                db.closeConnection();
            }
        }

        public static int addNewService(int category_id ,string title, int price, int discount , int warranty, int unit, int time, string detail)
        {
            Database db = new Database();
            int id = -1;
            try
            {
                int check;
                var p = new DynamicParameters();
                p.Add("@MaDichVu", 0, DbType.Int32, direction: ParameterDirection.Output);
                p.Add("@MaLoaiDichVu", category_id);
                p.Add("@TenDichVu", title);
                p.Add("@GiaDichVu", price);
                p.Add("@GiamGia", discount);
                p.Add("@DonVi", unit);
                p.Add("@BaoHanh", warranty);
                p.Add("@ThoiGianThucHien", time);
                p.Add("@ChiTiet", detail);
                using(IDbConnection connection = db.getConnection)
                {
                    check = connection.Execute("addService", p, commandType: CommandType.StoredProcedure);
                }
                if (check == 1) id = p.Get<int>("@MaDichVu");                
            }
            catch
            {
                throw;
            }
            finally
            {

            }
            return id;
        }

        public static DataTable getAllService()
        {
            DataTable dt = new DataTable();
            Database db = new Database();
            try
            {
                db.openConnection();
                using(SqlCommand cmd = new SqlCommand("getAllService", db.getConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();
                    dt.Load(reader);
                    reader.Close();
                }
                db.closeConnection();
            }
            catch
            {
                throw;
            }
            finally
            {
                db.closeConnection();
            }
            return dt;
        }

        public static DataTable getServiceByID(int id)
        {
            Database db = new Database();
            DataTable dt = new DataTable();
            try
            {
                db.openConnection();
                using(SqlCommand cmd = new SqlCommand("getServiceByID", db.getConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaDichVu", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    dt.Load(reader);
                    reader.Close();
                }
                db.closeConnection();
            }
            catch
            {
                throw;
            }
            finally
            {
                db.closeConnection();
            }
            return dt;
        }

        public static bool removeService(int id)
        {
            Database db = new Database();
            bool check = false;
            try
            {
                db.openConnection();
                using (SqlCommand cmd = new SqlCommand("removeService", db.getConnection))
                {
                    cmd.Parameters.AddWithValue("@MaDichVu", id);
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (cmd.ExecuteNonQuery() >= 1)
                    {
                        check = true;
                    }
                }
                db.closeConnection();
            }
            catch
            {
                throw;
            }
            finally
            {
                db.closeConnection();
            }
            return check;
        }

        public static DataTable getServiceByCategoryID(int id)
        {
            Database db = new Database();
            DataTable dt = new DataTable();
            try
            {
                db.openConnection();
                using (SqlCommand cmd = new SqlCommand("getServiceByCategoryID", db.getConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaLoaiDichVu", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    dt.Load(reader);
                    reader.Close();
                }
                db.closeConnection();
            }
            catch
            {
                throw;
            }
            finally
            {
                db.closeConnection();
            }
            return dt;
        }

/*        public static bool updateCategory(int id, string text)
        {
            Database db = new Database();
            try
            {
                db.openConnection();
                using (SqlCommand cmd = new SqlCommand("getServiceByCategoryID", db.getConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaLoaiDichVu", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    dt.Load(reader);
                    reader.Close();
                }
                db.closeConnection();
            }
            catch
            {
                throw;
            }
            finally
            {
                db.closeConnection();
            }
            return dt;
        }*/
    }
}
