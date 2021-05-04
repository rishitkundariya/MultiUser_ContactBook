using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using AddressBook.ENT;

/// <summary>
/// Summary description for BloodGroupDAL
/// </summary>
/// 
namespace AddressBook.DAL
{

    public class BloodGroupDAL :DatabaseConfig
    {
        #region Constructor
        public BloodGroupDAL()
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

        public Boolean Insert(BloodGroupENT entBloodGroup)
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
                        objCmd.CommandText = "PR_BloodGroup_Insert";
                        objCmd.Parameters.Add("@BloodGroupID", SqlDbType.Int).Direction = ParameterDirection.Output;
                        objCmd.Parameters.Add("@BloodGroupName", SqlDbType.VarChar).Value = entBloodGroup.BloodGroupName;
                      

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

        #region update operation
        public Boolean Update(BloodGroupENT entBloodGroup)
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
                        objCmd.CommandText = "PR_BloodGroup_UpdateByPK";
                        objCmd.Parameters.Add("@BloodGroupID", SqlDbType.Int).Value = entBloodGroup.BloodGroupID;
                        objCmd.Parameters.Add("@BloodGroupName", SqlDbType.VarChar).Value = entBloodGroup.BloodGroupName;
                     

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

        #region delete operation
        public Boolean Delete(SqlInt32 BloodGroupID)
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
                        objCmd.CommandText = "PR_BloodGroup_DeleteByPK";
                        objCmd.Parameters.Add("@BloodGroupID", SqlDbType.Int).Value = BloodGroupID;
                       
                       
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
                        objCmd.CommandText = "PR_BloodGroup_SelectAll";
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

        #region selectPK operation
        public BloodGroupENT SelectByPK(SqlInt32 BloodGroupID)
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
                        objCmd.CommandText = "PR_BloodGroup_SelectByPK";
                        objCmd.Parameters.AddWithValue("@BloodGroupID", BloodGroupID);
                        #endregion

                        #region read  data 
                        BloodGroupENT entBloodGroup = new BloodGroupENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["BloodGroupID"].Equals(DBNull.Value))
                                    entBloodGroup.BloodGroupID = Convert.ToInt32(objSDR["BloodGroupID"].ToString());
                                if (!objSDR["BloodGroupName"].Equals(DBNull.Value))
                                    entBloodGroup.BloodGroupName = objSDR["BloodGroupName"].ToString();
                             }
                            return entBloodGroup;
                        }
                        #endregion

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
                        objCmd.CommandText = "PR_BloodGroup_SelectForDropDownList";
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
