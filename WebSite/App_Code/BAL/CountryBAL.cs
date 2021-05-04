using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using AddressBook.DAL;
using AddressBook.ENT;

/// <summary>
/// Summary description for CountryBAL
/// </summary>
/// 
namespace AddressBook.BAL
{

    public class CountryBAL
    {
        #region Constructor
        public CountryBAL()
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

        public Boolean Insert(CountryENT entCountry)
        {
            CountryDAL dalCountry = new CountryDAL();
            if (dalCountry.Insert(entCountry))
            {
                return true;
            }
            else
            {
                Message = dalCountry.Message;
                return false;
            }
        }
        #endregion

        #region update operation
        public Boolean Update(CountryENT entCountry)
        {
            CountryDAL dalCountry = new CountryDAL();
            if (dalCountry.Update(entCountry))
            {
                return true;
            }
            else
            {
                Message = dalCountry.Message;

                return false;
            }
        }
        #endregion

        #region delete operation
        public Boolean Delete(SqlInt32 CountryID)
        {
            CountryDAL dalCountry = new CountryDAL();
            if (dalCountry.Delete(CountryID))
            {
                return true;
            }
            else
            {
                Message = dalCountry.Message;
                return false;
            }
        }
        #endregion

        #region Select operation

        #region selectall operation
        public DataTable SelectAll()
        {
            CountryDAL dalCountry = new CountryDAL();
            return dalCountry.SelectAll();

        }
        #endregion

        #region selectPK operation
        public CountryENT SelectByPK(SqlInt32 CountryID)
        {
            CountryDAL dalCountry = new CountryDAL();
            return dalCountry.SelectByPK(CountryID);
        }
        #endregion

        #region SelectForDopDown operation
        public DataTable SelectForDropDownList()
        {
            CountryDAL dalCountry = new CountryDAL();
            return dalCountry.SelectForDropDownList();
        }
        #endregion

        #endregion
    }
}
