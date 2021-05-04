using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using AddressBook;
using AddressBook.ENT;

/// <summary>
/// Summary description for CityDAL
/// </summary>
/// 
namespace AddressBook.DAL
{

    public class CityDAL : DatabaseConfig
    {
        #region Cnstructor
        public CityDAL()
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

        #region Insert Operation

        public Boolean Insert(CityEnt entCity)
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
                        objCmd.CommandText = "PR_City_Insert";
                        objCmd.Parameters.Add("@CityID", SqlDbType.Int).Direction = ParameterDirection.Output;
                        objCmd.Parameters.Add("@CityName", SqlDbType.VarChar).Value = entCity.CityName;
                        objCmd.Parameters.Add("@Pincode", SqlDbType.Int).Value = entCity.PinCode;
                        objCmd.Parameters.Add("@STDCode", SqlDbType.Int).Value = entCity.STDCode;
                        objCmd.Parameters.Add("@StateID", SqlDbType.Int).Value = entCity.StateID;
                        #endregion

                        objCmd.ExecuteNonQuery();

                        entCity.CityID = Convert.ToInt32(objCmd.Parameters["@CityID"].Value);
                        return true;

                        
                    }
                }
                catch(SqlException sqlex)
                {
                    Message += sqlex.Message;
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

        #region Update Operation
        public Boolean UpdateByPK(CityEnt entCity)
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
                        objCmd.CommandText = "PR_City_UpdateByPK";
                        objCmd.Parameters.Add("@CityID", SqlDbType.Int).Value = entCity.CityID;
                        objCmd.Parameters.Add("@CityName", SqlDbType.VarChar).Value = entCity.CityName;
                        objCmd.Parameters.Add("@Pincode", SqlDbType.Int).Value = entCity.PinCode;
                        objCmd.Parameters.Add("@STDCode", SqlDbType.Int).Value = entCity.STDCode;
                        objCmd.Parameters.Add("@StateID", SqlDbType.Int).Value = entCity.StateID;
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

        #region Delete Operation
        public Boolean DeleteByPK(SqlInt32 CityID)
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
                        objCmd.CommandText = "PR_City_DeleteByPK";
                        objCmd.Parameters.Add("@CityID", SqlDbType.Int).Value = CityID;
                       
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

        #region Select Operation

        #region SelectAll Operation
        
        public DataTable  SelectAll()
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
                        objCmd.CommandText = "PR_City_SelectAll"; 

                        #endregion

                        #region read and set data
                        DataTable dt = new DataTable();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                           
                                dt.Load(objSDR);
                        }
                        #endregion

                        return dt;

                    }
                }
                catch (SqlException sqlex)
                {
                    Message += sqlex.Message;
                    return null;
                }
                catch (Exception ex)
                {
                    Message += ex.Message;
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

        #region SelectByPK Operation
        public CityEnt SelectByPK(SqlInt32 CityID)
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
                        objCmd.CommandText = "PR_City_SelectByPK";
                        objCmd.Parameters.AddWithValue("@CityID", CityID);
                        #endregion

                        #region read and set data
                        CityEnt entCity = new CityEnt();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["CityID"].Equals(DBNull.Value))
                                    entCity.CityID =Convert.ToInt32(objSDR["CityID"].ToString());
                                if (!objSDR["CityName"].Equals(DBNull.Value))
                                    entCity.CityName = objSDR["CityName"].ToString();
                                if (!objSDR["PinCode"].Equals(DBNull.Value))
                                    entCity.PinCode = Convert.ToInt32(objSDR["PinCode"].ToString());
                                if (!objSDR["STDCode"].Equals(DBNull.Value))
                                    entCity.STDCode = Convert.ToInt32(objSDR["STDCode"].ToString());
                                if (!objSDR["StateID"].Equals(DBNull.Value))
                                    entCity.StateID = Convert.ToInt32(objSDR["StateID"].ToString());

                            }
                        }
                        #endregion

                        return entCity;

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

        #region SelectForDropDown Operation
        public DataTable SelectForDropDown()
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
                        objCmd.CommandText = "PR_City_SelectForDropDownList";

                        #endregion

                        #region read and set data
                        DataTable dt = new DataTable();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            
                                dt.Load(objSDR);
                        }
                        #endregion

                        return dt;

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

        #region SelectForDropDown BY StateID Operation
        public DataTable SelectForDropDownCityByStateID(SqlInt32 StateID)
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
                        objCmd.CommandText = "PR_City_FillDropDownByStateID";
                        objCmd.Parameters.Add("@StateID", SqlDbType.Int).Value= StateID;

                        #endregion

                        #region read and set data
                        DataTable dt = new DataTable();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {

                            dt.Load(objSDR);
                        }
                        #endregion

                        return dt;

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