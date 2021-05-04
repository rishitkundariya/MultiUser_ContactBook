using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using AddressBook.ENT;

/// <summary>
/// Summary description for CountryDAL
/// </summary>
/// 
namespace AddressBook.DAL
{

    public class CountryDAL : DatabaseConfig
    {
        #region constructor
        public CountryDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region Local Variable
        protected string _Message;

        public string Message
        {
            get
            {
                return _Message;
            }
            set
            {
                _Message = value;
            }
        }
        #endregion

        #region inserst operation

        public Boolean Insert(CountryENT entCountry)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                try
                {
                    if (objConn.State != ConnectionState.Open)
                        objConn.Open();

                    using (SqlCommand objCmd = objConn.CreateCommand())
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Country_Insert";
                        objCmd.Parameters.Add("@CountryID", SqlDbType.Int).Direction = ParameterDirection.Output;
                        objCmd.Parameters.Add("@CountryName", SqlDbType.VarChar).Value = entCountry.CountryName;
                        objCmd.Parameters.Add("@CountryCode", SqlDbType.Int).Value = entCountry.CountryCode;
                     
                        #endregion

                        objCmd.ExecuteNonQuery();

                        entCountry.CountryID =Convert.ToInt32(objCmd.Parameters["@CountryID"].Value);
                        return true;


                    }
                }
                catch (SqlException sqlex)
                {
                    Message += sqlex.InnerException.Message;
                    return false;
                }
                catch (Exception ex)
                {
                    Message += ex.Message;
                    return false;

                }
                finally
                {
                    if (objConn.State == ConnectionState.Open)
                        objConn.Close();
                }
            }
        }

        #endregion

        #region update operation
        public Boolean Update(CountryENT entCountry)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                try
                {
                    if (objConn.State != ConnectionState.Open)
                        objConn.Open();

                    using (SqlCommand objCmd = objConn.CreateCommand())
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Country_UpdateByPK";
                        objCmd.Parameters.Add("@CountryID", SqlDbType.Int).Value = entCountry.CountryID;
                        objCmd.Parameters.Add("@CountryName", SqlDbType.VarChar).Value = entCountry.CountryName;
                        objCmd.Parameters.Add("@CountryCode", SqlDbType.Int).Value = entCountry.CountryCode;

                        #endregion

                        objCmd.ExecuteNonQuery();
                        return true;


                    }
                }
                catch (SqlException sqlex)
                {
                    Message += sqlex.InnerException.Message;
                    return false;
                }
                catch (Exception ex)
                {
                    Message += ex.InnerException.Message;
                    return false;

                }
                finally
                {
                    if (objConn.State == ConnectionState.Open)
                        objConn.Close();
                }
            }
        }
        #endregion

        #region delete operation
        public Boolean Delete(SqlInt32 CountryID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                try
                {
                    if (objConn.State != ConnectionState.Open)
                        objConn.Open();

                    using (SqlCommand objCmd = objConn.CreateCommand())
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Country_DeleteByPK";
                        objCmd.Parameters.Add("@CountryID", SqlDbType.Int).Value = CountryID;
                     

                        #endregion

                        objCmd.ExecuteNonQuery();
                        return true;


                    }
                }
                catch (SqlException sqlex)
                {
                    Message += sqlex.Message;
                    return false;
                }
                catch (Exception ex)
                {
                    Message += ex.InnerException.Message;
                    return false;

                }
                finally
                {
                    if (objConn.State == ConnectionState.Open)
                        objConn.Close();
                }
            }
        }
        #endregion

        #region select operation

        #region selectall operation
        public DataTable SelectAll()
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                try
                {
                    if (objConn.State != ConnectionState.Open)
                        objConn.Open();

                    using (SqlCommand objCmd = objConn.CreateCommand())
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Country_SelectAll";
                        #endregion

                        #region read  data 
                        DataTable dt = new DataTable();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            
                                dt.Load(objSDR);
                                
                           
                            return dt;
                        }
                        #endregion

                    }
                }
                catch (SqlException sqlex)
                {
                    Message += sqlex.InnerException.Message;
                    return null;
                }
                catch (Exception ex)
                {
                    Message += ex.InnerException.Message;
                    return null;

                }
                finally
                {
                    if (objConn.State == ConnectionState.Open)
                        objConn.Close();
                }
            }
        }
        #endregion

        #region selectPK operation
        public CountryENT SelectByPK(SqlInt32 CountryID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                try
                {
                    if (objConn.State != ConnectionState.Open)
                        objConn.Open();

                    using (SqlCommand objCmd = objConn.CreateCommand())
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Country_SelectByPK";
                        objCmd.Parameters.AddWithValue("@CountryID", CountryID);
                        #endregion

                        #region read  data 
                        CountryENT entCountry = new CountryENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["CountryID"].Equals(DBNull.Value))
                                    entCountry.CountryID = Convert.ToInt32(objSDR["CountryID"].ToString());
                                if (!objSDR["CountryName"].Equals(DBNull.Value))
                                    entCountry.CountryName = objSDR["CountryName"].ToString();
                                if (!objSDR["CountryCode"].Equals(DBNull.Value))
                                    entCountry.CountryCode = Convert.ToInt32(objSDR["CountryCode"]);

                            }
                            return entCountry;
                        }
                        #endregion

                    }
                }
                catch (SqlException sqlex)
                {
                    Message += sqlex.InnerException.Message;
                    return null;
                }
                catch (Exception ex)
                {
                    Message += ex.InnerException.Message;
                    return null;

                }
                finally
                {
                    if (objConn.State == ConnectionState.Open)
                        objConn.Close();
                }
            }
        }
        #endregion

        #region SelectForDopDown operation
        public DataTable SelectForDropDownList()
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                try
                {
                    if (objConn.State != ConnectionState.Open)
                        objConn.Open();

                    using (SqlCommand objCmd = objConn.CreateCommand())
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Country_SelectForDropDownList";
                        #endregion

                        #region read  data 
                        DataTable dt = new DataTable();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                          
                             dt.Load(objSDR);
                        
                            return dt;
                        }
                        #endregion

                    }
                }
                catch (SqlException sqlex)
                {
                    Message += sqlex.InnerException.Message;
                    return null;
                }
                catch (Exception ex)
                {
                    Message += ex.InnerException.Message;
                    return null;

                }
                finally
                {
                    if (objConn.State == ConnectionState.Open)
                        objConn.Close();
                }
            }
        }
        #endregion

        #endregion

    }
}