using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using AddressBook.DAL;
using AddressBook.ENT;

/// <summary>
/// Summary description for ContactCategoryBAL
/// </summary>
/// 
namespace AddressBook.BAL
{

    public class ContactCategoryBAL
    {
        #region Constructor
        public ContactCategoryBAL()
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

        public Boolean Insert(ContactCategoryENT entContactCategory)
        {
            ContactCategoryDAL dalContactCategory = new ContactCategoryDAL();
            if (dalContactCategory.Insert(entContactCategory))
            {
                return true;
            }
            else
            {
                Message = dalContactCategory.Message;
                return false;
            }
        }
        #endregion

        #region update operation
        public Boolean Update(ContactCategoryENT entContactCategory)
        {
            ContactCategoryDAL dalContactCategory = new ContactCategoryDAL();
            if (dalContactCategory.Update
(entContactCategory))
            {
                return true;
            }
            else
            {
                Message = dalContactCategory.Message;
                return false;
            }
        }
        #endregion

        #region delete operation
        public Boolean Delete(SqlInt32 ContactCategoryID)
        {
            ContactCategoryDAL dalContactCategory = new ContactCategoryDAL();
            if (dalContactCategory.Delete(ContactCategoryID))
            {
                return true;
            }
            else
            {
                Message = dalContactCategory.Message;
                return false;
            }
        }
        #endregion

        #region Select Operation

        #region selectall operation
        public DataTable SelectAll()
        {
            ContactCategoryDAL dalContactCategory = new ContactCategoryDAL();
            return dalContactCategory.SelectAll();
        }
        #endregion

        #region selectPK operation
        public ContactCategoryENT SelectByPK(SqlInt32 ContactCategoryID)
        {
            ContactCategoryDAL dalContactCategory = new ContactCategoryDAL();
            return dalContactCategory.SelectByPK(ContactCategoryID);
        }
        #endregion

        #region SelectForDopDown operation
        public DataTable SelectForDropDownList()
        {
            ContactCategoryDAL dalContactCategory = new ContactCategoryDAL();
            return dalContactCategory.SelectForDropDownList();
        }
        #endregion

        #endregion
    }
}
