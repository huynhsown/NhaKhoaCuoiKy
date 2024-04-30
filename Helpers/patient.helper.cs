using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NhaKhoaCuoiKy.dbs;

namespace NhaKhoaCuoiKy.Helpers
{
    public class PatientHelper
    {
        public static DataTable getByID(int id)
        {
            DataTable dt = new DataTable();
            Database db = null;
            try
            {
                db = new Database();
                db.openConnection();
                using (SqlCommand cmd = new SqlCommand("getByID", db.getConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaBenhNhan", id);
                    SqlDataReader dr = cmd.ExecuteReader();
                    dt.Load(dr);
                    dr.Close();
                }
                db.closeConnection();
            }
            catch
            {
                throw;
            }
            finally
            {
                if (db != null) { db.closeConnection();}
            }
            return dt;
        }
    }
}
