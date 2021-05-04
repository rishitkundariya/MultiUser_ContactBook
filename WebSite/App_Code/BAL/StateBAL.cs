using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using AddressBook.DAL;
using AddressBook.ENT;

/// <summary>
/// Summary description for StateBAL
/// </summary>
/// 
namespace AddressBook.BAL
{

    public class StateBAL
    {
        #region Constructor
        public StateBAL()
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
            StateDAL dalState = new StateDAL();
            if (dalState.Insert(entState))
            {
                return true;
            }
            else
            {
                Message = dalState.Message;
                return false;
            }
        }
        #endregion

        #region Update Operation

        public Boolean Update(StateENT entState)
        {
            StateDAL dalState = new StateDAL();
            if (dalState.UpdateByPK(entState))
            {
                return true;
            }
            else
            {
                Message = dalState.Message;
                return false;
            }
        }
        #endregion

        #region Delete Operation
        public Boolean Delete(SqlInt32 StateID)
        {
            StateDAL dalState = new StateDAL();
            if (dalState.DeleteByPK(StateID))
            {
                return true;
            }
            else
            {
                Message = dalState.Message;
                return false;
            }
        }
        #endregion

        #region Select Operation

        #region SelectAll Operation

        public DataTable SelectAll()
        {
            StateDAL dalState = new StateDAL();
            return dalState.SelectAll();
        }
        #endregion

        #region SelectByPK Operation
        public StateENT SelectByPK(SqlInt32 StateID)
        {
            StateDAL dalState = new StateDAL();
            return dalState.SelectByPK(StateID);

        }
        #endregion

        #region SelectForDropDown Operation
        public DataTable SelectForDropDown()
        {
            StateDAL dalState = new StateDAL();
            return dalState.SelectForDropDown();
        }
        #endregion

        #region SelectForDropDown by Country Operation
        public DataTable SelectForDropDownStateByCountryID(SqlInt32 CountryID)
        {
            StateDAL dalState = new StateDAL();
            return dalState.SelectForDropDownStateByCountryID(CountryID);
        }
        #endregion

        #endregion
    }
}
