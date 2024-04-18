using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NhaKhoaCuoiKy.dbs;

namespace NhaKhoaCuoiKy.Helpers
{
    internal class AppointmentHelper
    {
        public static DataTable getAllDoctors()
        {
            Database db = new Database();
            DataTable dt = new DataTable();
            try
            {
                db.openConnection();
                using(SqlCommand cmd = new SqlCommand("getAllDoctors", db.getConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();
                    dt.Load(sqlDataReader);
                    sqlDataReader.Close();
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

        public static DataTable getAllDoctorsByID(int id)
        {
            Database db = new Database();
            DataTable dt = new DataTable();
            try
            {
                db.openConnection();
                using (SqlCommand cmd = new SqlCommand("getAllDoctorsByID", db.getConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaBacSi", id);
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();
                    dt.Load(sqlDataReader);
                    sqlDataReader.Close();
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

        public static DataTable getAllDoctorsByName(string name)
        {
            Database db = new Database();
            DataTable dt = new DataTable();
            try
            {
                db.openConnection();
                using (SqlCommand cmd = new SqlCommand("getAllDoctorsByName", db.getConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Ten", name);
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();
                    dt.Load(sqlDataReader);
                    sqlDataReader.Close();
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

        public static DataTable getAllServiceByDoctor(int doctor_id, DateOnly date)
        {
            Database db = new Database();
            DataTable dt = new DataTable();
            DateTime datet = DateTime.Parse(date.ToShortDateString());
            try
            {
                db.openConnection();
                using(SqlCommand cmd = new SqlCommand("getAllServiceByDoctor", db.getConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaBacSi", doctor_id);
                    cmd.Parameters.AddWithValue("@Ngay", datet);
                    SqlDataReader dr = cmd.ExecuteReader();
                    dt.Load(dr);
                    dr.Close();
                }
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

        public static DataTable getAllAppointmentByDoctor(int doctor_id, DateOnly date)
        {
            Database db = new Database();
            DataTable dt = new DataTable();
            DateTime datet = DateTime.Parse(date.ToShortDateString());
            try
            {
                db.openConnection();
                using (SqlCommand cmd = new SqlCommand("getAllAppointmentByDoctor", db.getConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaBacSi", doctor_id);
                    cmd.Parameters.AddWithValue("@Ngay", datet);
                    SqlDataReader dr = cmd.ExecuteReader();
                    dt.Load(dr);
                    dr.Close();
                }
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

        public static bool createAppointment(int doctor_id, string name, string phone, string address, DateTime start, int time, string detail)
        {
            Database db = new Database();
            bool check = false;
            try
            {
                db.openConnection();
                using(SqlCommand cmd = new SqlCommand("createAppointment", db.getConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaLichHen", 0);
                    cmd.Parameters.AddWithValue("@MaNhanVien", doctor_id);
                    cmd.Parameters.AddWithValue("@TenKhachHang", name);
                    cmd.Parameters.AddWithValue("@SoDienThoaiKhachHang", phone);
                    cmd.Parameters.AddWithValue("@DiaChi", address);
                    cmd.Parameters.AddWithValue("@BatDau", start);
                    cmd.Parameters.AddWithValue("@ThoiGian", time);
                    cmd.Parameters.AddWithValue("@NoiDung", detail);
                    if (cmd.ExecuteNonQuery() > 0) check = true;
                }
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
    }
}
