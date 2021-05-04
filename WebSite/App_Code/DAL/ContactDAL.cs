using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using AddressBook.ENT;

/// <summary>
/// Summary description for ContactDAL
/// </summary>
/// 
namespace AddressBook.DAL 
{
  
    public class ContactDAL :DatabaseConfig
    {
        #region Constructor
        public ContactDAL()
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

        public Boolean Insert(ContactENT entContact)
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
                        objCmd.CommandText = "PR_Contact_Insert";
                        objCmd.Parameters.Add("@ContactID", SqlDbType.Int).Direction = ParameterDirection.Output;
                        objCmd.Parameters.Add("@ContactName", SqlDbType.VarChar).Value = entContact.ContactName;
                        objCmd.Parameters.Add("@Age", SqlDbType.Int).Value = entContact.Age;
                        objCmd.Parameters.Add("@StateID", SqlDbType.Int).Value = entContact.StateID;
                        objCmd.Parameters.Add("@ContactCategoryID", SqlDbType.Int).Value = entContact.ContactCategoryID;
                        objCmd.Parameters.Add("@BloodGroupID", SqlDbType.Int).Value = entContact.BloodGroupID;
                        objCmd.Parameters.Add("@CityID", SqlDbType.Int).Value = entContact.CityID;
                        objCmd.Parameters.Add("@CountryID", SqlDbType.Int).Value = entContact.CountryID;
                        objCmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = entContact.Address;
                        objCmd.Parameters.Add("@MobileNo", SqlDbType.VarChar).Value = entContact.MobileNo;
                        objCmd.Parameters.Add("@PhoneNo", SqlDbType.VarChar).Value = entContact.PhoneNo;
                        objCmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = entContact.Email;
                        objCmd.Parameters.Add("@Gender", SqlDbType.VarChar).Value = entContact.Gender;
                        objCmd.Parameters.Add("@Profession", SqlDbType.VarChar).Value = entContact.Profession;

                        #endregion

                        objCmd.ExecuteNonQuery();
                        entContact.ContactID = Convert.ToInt32(objCmd.Parameters["@ContactID"].Value);
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

        public Boolean Update(ContactENT entContact)
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
                        objCmd.CommandText = "PR_Contact_UpdateByPK";
                        objCmd.Parameters.Add("@ContactID", SqlDbType.Int).Value = entContact.ContactID;
                        objCmd.Parameters.Add("@ContactName", SqlDbType.VarChar).Value = entContact.ContactName;  
                        objCmd.Parameters.Add("@Age", SqlDbType.Int).Value = entContact.Age;
                        objCmd.Parameters.Add("@StateID", SqlDbType.Int).Value = entContact.StateID;
                        objCmd.Parameters.Add("@ContactCategoryID", SqlDbType.Int).Value = entContact.ContactCategoryID;
                        objCmd.Parameters.Add("@BloodGroupID", SqlDbType.Int).Value = entContact.BloodGroupID;
                        objCmd.Parameters.Add("@CityID", SqlDbType.Int).Value = entContact.CityID;
                        objCmd.Parameters.Add("@CountryID", SqlDbType.Int).Value = entContact.CountryID;
                        objCmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = entContact.Address;
                        objCmd.Parameters.Add("@MobileNo", SqlDbType.VarChar).Value = entContact.MobileNo;
                        objCmd.Parameters.Add("@PhoneNo", SqlDbType.VarChar).Value = entContact.PhoneNo;
                        objCmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = entContact.Email;
                        objCmd.Parameters.Add("@Gender", SqlDbType.VarChar).Value = entContact.Gender;
                        objCmd.Parameters.Add("@Profession", SqlDbType.VarChar).Value = entContact.Profession;




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

        public Boolean Delete(SqlInt32 ContactID)
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
                        objCmd.CommandText = "PR_Contact_DeleteByPK";
                        objCmd.Parameters.AddWithValue("@ContactID", ContactID);
                        
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
                        objCmd.CommandText = "PR_Contact_SelectAll";
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
        public ContactENT SelectByPK(SqlInt32 ContactID)
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
                        objCmd.CommandText = "PR_Contact_SelectByPK";
                        objCmd.Parameters.AddWithValue("@ContactID", ContactID);
                        #endregion

                        #region read  data 
                        ContactENT entContact = new ContactENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["ContactID"].Equals(DBNull.Value))
                                    entContact.ContactID = Convert.ToInt32(objSDR["ContactID"].ToString());
                                if (!objSDR["ContactName"].Equals(DBNull.Value))
                                    entContact.ContactName = objSDR["ContactName"].ToString();
                                if (!objSDR["Address"].Equals(DBNull.Value))
                                    entContact.Address = objSDR["Address"].ToString();
                                if (!objSDR["MobileNo"].Equals(DBNull.Value))
                                    entContact.MobileNo = objSDR["MobileNo"].ToString();
                                if (!objSDR["PhoneNo"].Equals(DBNull.Value))
                                    entContact.PhoneNo = objSDR["PhoneNo"].ToString();
                                if (!objSDR["Email"].Equals(DBNull.Value))
                                    entContact.Email = objSDR["Email"].ToString();
                                if (!objSDR["Gender"].Equals(DBNull.Value))
                                    entContact.Gender = objSDR["Gender"].ToString();
                                if (!objSDR["Profession"].Equals(DBNull.Value))
                                    entContact.Profession = objSDR["Profession"].ToString();
                                if (!objSDR["CityID"].Equals(DBNull.Value))
                                    entContact.CityID = Convert.ToInt32(objSDR["CityID"].ToString());
                                if (!objSDR["StateID"].Equals(DBNull.Value))
                                    entContact.StateID = Convert.ToInt32(objSDR["StateID"].ToString());
                                if (!objSDR["CountryID"].Equals(DBNull.Value))
                                    entContact.CountryID = Convert.ToInt32(objSDR["CountryID"].ToString());
                               
                                if (!objSDR["Age"].Equals(DBNull.Value))
                                    entContact.Age = Convert.ToInt32(objSDR["Age"].ToString());
                                if (!objSDR["BloodGroupID"].Equals(DBNull.Value))
                                    entContact.BloodGroupID = Convert.ToInt32(objSDR["BloodGroupID"].ToString());
                                if (!objSDR["ContactCategoryID"].Equals(DBNull.Value))
                                    entContact.ContactCategoryID = Convert.ToInt32(objSDR["ContactCategoryID"].ToString());
                              


                            }
                            return entContact;
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

       

        #endregion


    }
}
