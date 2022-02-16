using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace InterTaskWebService
{
    /// <summary>
    /// Summary description for InterTaskWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class InterTaskWebService : System.Web.Services.WebService
    {

        [WebMethod]
        public string VerifyLogin(string usernmae, string password)
        {
            DataSet ds = new DataSet();
            try
            {

                string consString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                using (SqlConnection con = new SqlConnection(consString))
                {
                    using (SqlCommand cmd = new SqlCommand("spVerifyAccount"))

                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@Username", usernmae);
                        cmd.Parameters.AddWithValue("@Password", password);
                        con.Open();
                        using (SqlDataAdapter adapter = new SqlDataAdapter())
                        {
                            adapter.SelectCommand = cmd;
                            adapter.Fill(ds);
                        }
                        con.Close();
                    }
                }
            }
            catch
            {
                throw;
            }

            return ds.Tables[0].Rows[0]["username"].ToString();
        }


        [WebMethod]
        public int SaveSearchResult(string h, string tmax, string tmin, string username, string city)
        {
            try
            {

                string consString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                using (SqlConnection con = new SqlConnection(consString))
                {
                    using (SqlCommand cmd = new SqlCommand("spSaveSearchResult"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@Humidity", h);
                        cmd.Parameters.AddWithValue("@TempMax", tmax);
                        cmd.Parameters.AddWithValue("@TempMin", tmin);
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@City", city);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            catch
            {
                throw;
            }

            return 1;
        }

        [WebMethod]
        public DataSet GetSearchResults(string usernmae)
        {
            DataSet ds = new DataSet();
            try
            {

                string consString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                using (SqlConnection con = new SqlConnection(consString))
                {
                    using (SqlCommand cmd = new SqlCommand("spGetSearchResultByUsername"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@Username", usernmae);
                        con.Open();
                        using (SqlDataAdapter adapter = new SqlDataAdapter())
                        {
                            adapter.SelectCommand = cmd;
                            adapter.Fill(ds);
                        }
                        con.Close();
                    }
                }
            }
            catch
            {
                throw;
            }

            return ds;
        }

        [WebMethod]
        public int DeleteRecords(List<string> ids)
        {
            // to do
            // soft delete of ids 

            return 1;
        }

    }
}
