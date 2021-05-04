using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using AddressBook.ENT;

/// <summary>
/// Summary description for StateDAL
/// </summary>
/// 
namespace AddressBook.DAL
{

    public class StateDAL:DatabaseConfig
    {
        #region Constructor
        public StateDAL()
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

        public Boolean Insert(StateENT entState)
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
                        objCmd.CommandText = "PR_State_Insert";
                        objCmd.Parameters.Add("@StateID", SqlDbType.Int).Direction = ParameterDirection.Output;
                        objCmd.Parameters.Add("@StateName", SqlDbType.VarChar).Value = entState.StateName;
                        objCmd.Parameters.Add("@CountryID", SqlDbType.Int).Value = entState.CountryID;
                       
                        #endregion

                        objCmd.ExecuteNonQuery();

                        entState.StateID = Convert.ToInt32(objCmd.Parameters["@StateID"].Value);
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

        #region Update Operation
        public Boolean UpdateByPK(StateENT entState)
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
                        objCmd.CommandText = "PR_State_UpdateByPK";
                        objCmd.Parameters.Add("@StateID", SqlDbType.Int).Value = entState.StateID;
                        objCmd.Parameters.Add("@StateName", SqlDbType.VarChar).Value = entState.StateName;
                        objCmd.Parameters.Add("@CountryID", SqlDbType.Int).Value = entState.CountryID;
                        
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
        public Boolean DeleteByPK(SqlInt32 StateID)
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
                        objCmd.CommandText = "PR_State_DeleteByPK";
                        objCmd.Parameters.Add("@StateID", SqlDbType.Int).Value = StateID;

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
                        objCmd.CommandText = "PR_State_SelectAll";

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
        public StateENT SelectByPK(SqlInt32 StateID)
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
                        objCmd.CommandText = "PR_State_SelectByPK";
                        objCmd.Parameters.AddWithValue("@StateID", StateID);
                        #endregion

                        #region read and set data
                        StateENT entState = new StateENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["StateID"].Equals(DBNull.Value))
                                    entState.StateID = Convert.ToInt32(objSDR["StateID"].ToString());
                                if (!objSDR["StateName"].Equals(DBNull.Value))
                                    entState.StateName = objSDR["StateName"].ToString();
                                if (!objSDR["CountryID"].Equals(DBNull.Value))
                                    entState.CountryID = Convert.ToInt32(objSDR["CountryID"].ToString());
                               

                            }
                        }
                        #endregion

                        return entState;

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
                        objCmd.CommandText = "PR_State_SelectForDropDownList";

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

        #region SelectForDropDown by Country Operation
        public DataTable SelectForDropDownStateByCountryID(SqlInt32 CountryID)
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
                        objCmd.CommandText = "PR_State_SelectByCountryID";
                        objCmd.Parameters.AddWithValue("@CountryID", CountryID);

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
