using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CityEnt
/// </summary>
/// 
namespace AddressBook.ENT
{

    public class CityEnt
    {
        #region Constructor
        public CityEnt()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region CityID
        protected SqlInt32 _CityID;

        public SqlInt32 CityID
        {
            get
            {
                return _CityID;
            }
            set
            {
                _CityID = value;
            }
        }
        #endregion

        #region CityName
        protected SqlString _CityName;

        public SqlString CityName
        {
            get
            {
                return _CityName;
            }
            set
            {
                _CityName = value;
            }
        }
        #endregion

        #region PinCode
        protected SqlInt32 _PinCode;

        public SqlInt32 PinCode
        {
            get
            {
                return _PinCode;
            }
            set
            {
                _PinCode = value;
            }
        }
        #endregion

        #region STDCode
        protected SqlInt32 _STDCode;

        public SqlInt32 STDCode
        {
            get
            {
                return _STDCode;
            }
            set
            {
                _STDCode = value;
            }
        }
        #endregion

        #region StateID
        protected SqlInt32 _StateID;

        public SqlInt32 StateID
        {
            get
            {
                return _StateID;
            }
            set
            {
                _StateID = value;
            }
        }
        #endregion

       

    }

}