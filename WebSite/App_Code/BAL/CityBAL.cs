using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using AddressBook.DAL;
using AddressBook.ENT;

/// <summary>
/// Summary description for CityBAL
/// </summary>
/// 
namespace AddressBook.BAL
{

    public class CityBAL
    {
        #region Constructor
        public CityBAL()
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
            CityDAL dalCity = new CityDAL();
            if (dalCity.Insert(entCity))
            {
                return true;
            }
            else
            {
                Message = dalCity.Message;
                return false;
            }
        }
        #endregion
           
        #region Update Operation
        public Boolean Update(CityEnt entCity)
        {

            CityDAL dalCity = new CityDAL();
            if (dalCity.UpdateByPK(entCity))
            {
                return true;
            }
            else
            {
                Message = dalCity.Message;
                return false;
            }
        }
        #endregion

        #region Delete Operation
        public Boolean Delete(SqlInt32 CityID)
        {
            CityDAL dalCity = new CityDAL();
            if (dalCity.DeleteByPK(CityID))
            {
                return true;
            }
            else
            {
                Message = dalCity.Message;
                return false;
            }
        }
        #endregion

        #region Select Operation

        #region SelectAll Operation

        public DataTable SelectAll()
        {
            CityDAL dalCity = new CityDAL();
            if (dalCity.SelectAll() == null)
            {
                Message = dalCity.Message;
                
            }
             return dalCity.SelectAll();
        }
        #endregion

        #region SelectByPK Operation
        public CityEnt SelectByPK(SqlInt32 CityID)
        {
            CityDAL dalCity = new CityDAL();
            
            if (dalCity.SelectByPK(CityID) == null)
            {
                Message = dalCity.Message;

            }
            return dalCity.SelectByPK(CityID);
        }
        #endregion

        #region SelectForDropDown Operation
        public DataTable SelectForDropDown()
        {
            CityDAL dalCity = new CityDAL();
            if (dalCity.SelectForDropDown() == null)
            {
                Message = dalCity.Message;

            }
            return dalCity.SelectForDropDown();

        }
        #endregion

        #region SelectForDropDown BY StateID Operation
        public DataTable SelectForDropDownCityByStateID(SqlInt32 StateID)
        {
            CityDAL dalCity = new CityDAL();
            if (dalCity.SelectForDropDownCityByStateID(StateID) == null)
            {
                Message = dalCity.Message;

            }
            return dalCity.SelectForDropDownCityByStateID(StateID);

        }
        #endregion

        #endregion
    }
}