using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using AddressBook.DAL;
using AddressBook.ENT;

/// <summary>
/// Summary description for BloodGroupBAL
/// </summary>
/// 
namespace AddressBook.BAL
{

    public class BloodGroupBAL
    {
        #region Constructor
        public BloodGroupBAL()
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
            BloodGroupDAL dalBloodGroup = new BloodGroupDAL();
            if (dalBloodGroup.Insert(entBloodGroup))
            {
                return true;
            }
            else
            {
                Message = dalBloodGroup.Message;
                return false;
            }
        }
        #endregion

        #region update operation
        public Boolean Update(BloodGroupENT entBloodGroup)
        {
            BloodGroupDAL dalBloodGroup = new BloodGroupDAL();
            if (dalBloodGroup.Update(entBloodGroup))
            {
                return true;
            }
            else
            {
                Message = dalBloodGroup.Message;
                return false;
            }
        }
        #endregion

        #region delete operation
        public Boolean Delete(SqlInt32 BloodGroupID)
        {
            BloodGroupDAL dalBloodGroup = new BloodGroupDAL();
            if (dalBloodGroup.Delete(BloodGroupID))
            {
                return true;
            }
            else
            {
                Message = dalBloodGroup.Message;
                return false;
            }
        }
        #endregion

        #region Select Operation 

        #region selectall operation
        public DataTable SelectAll()
        {
            BloodGroupDAL dalBloodGroup = new BloodGroupDAL();
            return dalBloodGroup.SelectAll();
        }
        #endregion

        #region selectPK operation
        public BloodGroupENT SelectByPK(SqlInt32 BloodGroupID)
        {
            BloodGroupDAL dalBloodGroup = new BloodGroupDAL();
            return dalBloodGroup.SelectByPK(BloodGroupID);
        }
        #endregion

        #region SelectForDopDown operation
        public DataTable SelectForDropDownList()
        {
            BloodGroupDAL dalBloodGroup = new BloodGroupDAL();
            return dalBloodGroup.SelectForDropDownList();
        }
        #endregion

        #endregion
    }
}
