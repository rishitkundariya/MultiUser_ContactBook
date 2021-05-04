using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using AddressBook.DAL;
using AddressBook.ENT;

/// <summary>
/// Summary description for ContactBAL
/// </summary>
/// 
namespace AddressBook.BAL
{

    public class ContactBAL
    {
        #region Constructor
        public ContactBAL()
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

        public Boolean Insert(ContactENT entContact)
        {
            ContactDAL dalContact = new ContactDAL();
            if (dalContact.Insert(entContact))
            {
                return true;
            }
            else
            {
                Message = dalContact.Message;
                return false;
            }
        }
        #endregion

        #region update operation
        public Boolean Update(ContactENT entContact)
        {
            ContactDAL dalContact = new ContactDAL();
            if (dalContact.Update(entContact))
            {
                return true;
            }
            else
            {
                Message = dalContact.Message;
                return false;
            }
        }
        #endregion

        #region delete operation
        public Boolean Delete(SqlInt32 ContactID)
        {
            ContactDAL dalContact = new ContactDAL();
            if (dalContact.Delete(ContactID))
            {
                return true;
            }
            else
            {
                Message = dalContact.Message;
                return false;
            }
        }
        #endregion

        #region Select Operation 

        #region selectall operation
        public DataTable SelectAll()
        {
            ContactDAL dalContact = new ContactDAL();
            return dalContact.SelectAll();
        }
        #endregion

        #region selectPK operation
        public ContactENT SelectByPK(SqlInt32 ContactID)
        {
            ContactDAL dalContact = new ContactDAL();
            return dalContact.SelectByPK(ContactID);
        }
        #endregion

       

        #endregion

    }

}