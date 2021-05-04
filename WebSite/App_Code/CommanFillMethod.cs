using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using AddressBook.BAL;

/// <summary>
/// Summary description for CommanFillMethod
/// </summary>
/// 
namespace AddressBook
{

    public class CommanFillMethod
    {
        #region Constructor
        public CommanFillMethod()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region FillDropDownList  State
        public static void FillStateDropDownListState(DropDownList ddlState)
        {
            StateBAL balState = new StateBAL();
            ddlState.DataSource=balState.SelectForDropDown();
            ddlState.DataTextField = "StateName";
            ddlState.DataValueField = "StateID";
            ddlState.DataBind();
            ddlState.Items.Insert(0, new ListItem("Select State", "-1"));
        }
        #endregion

        #region FillDropDownList  State By CountryID
        public static void FillStateDropDownListStateByCountryID(DropDownList ddlState,SqlInt32 CountryID)
        {
            StateBAL balState = new StateBAL();
            ddlState.DataSource = balState.SelectForDropDownStateByCountryID(CountryID);
            ddlState.DataTextField = "StateName";
            ddlState.DataValueField = "StateID";
            ddlState.DataBind();
            ddlState.Items.Insert(0, new ListItem("Select State", "-1"));
        }
        #endregion

        #region FillDropDownList  Country
        public static void FillStateDropDownListCountry(DropDownList ddlCountry)
        {
            CountryBAL balCountry = new CountryBAL();
            ddlCountry.DataSource = balCountry.SelectForDropDownList();
            ddlCountry.DataTextField = "CountryName";
            ddlCountry.DataValueField = "CountryID";
            ddlCountry.DataBind();
            ddlCountry.Items.Insert(0, new ListItem("Select Country", "-1"));
        }
        #endregion

        #region FillDropDownList  City
        public static void FillStateDropDownListCity(DropDownList ddlCity)
        {
            CityBAL balCity = new CityBAL();
            ddlCity.DataSource = balCity.SelectForDropDown();
            ddlCity.DataTextField = "CityName";
            ddlCity.DataValueField = "CityID";
            ddlCity.DataBind();
            ddlCity.Items.Insert(0, new ListItem("Select City", "-1"));

        }
        #endregion

        #region FillDropDownList  City by StateID
        public static void FillStateDropDownListCityByStateID(DropDownList ddlCity,SqlInt32 StateID)
        {
            CityBAL balCity = new CityBAL();
            ddlCity.DataSource = balCity.SelectForDropDownCityByStateID(StateID);
            ddlCity.DataTextField = "CityName";
            ddlCity.DataValueField = "CityID";
            ddlCity.DataBind();
            ddlCity.Items.Insert(0, new ListItem("Select City", "-1"));

        }
        #endregion

        #region FillDropDownList  BloodGroup
        public static void FillStateDropDownListBloodGroup(DropDownList ddlBloodGroup)
        {
            BloodGroupBAL balBloodGroup = new BloodGroupBAL();
            ddlBloodGroup.DataSource = balBloodGroup.SelectForDropDownList();
            ddlBloodGroup.DataTextField = "BloodGroupName";
            ddlBloodGroup.DataValueField = "BloodGroupID";
            ddlBloodGroup.DataBind();
            ddlBloodGroup.Items.Insert(0, new ListItem("Select BloodGroup", "-1"));

        }
        #endregion

        #region FillDropDownList  ContactCategory
        public static void FillStateDropDownListContactCategory(DropDownList ddlContactCategory)
        {
            ContactCategoryBAL balContactCategory = new ContactCategoryBAL();
            ddlContactCategory.DataSource = balContactCategory.SelectForDropDownList();
            ddlContactCategory.DataTextField = "ContactCategoryName";
            ddlContactCategory.DataValueField = "ContactCategoryID";
            ddlContactCategory.DataBind();
            ddlContactCategory.Items.Insert(0, new ListItem("Select ContactCategory", "-1"));

        }
        #endregion


    }
}
