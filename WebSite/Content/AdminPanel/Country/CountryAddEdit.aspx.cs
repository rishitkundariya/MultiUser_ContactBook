using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AddressBook.BAL;
using AddressBook.ENT;

public partial class Content_AdminPanel_Country_CountryAddEdit : System.Web.UI.Page
{
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["CountryID"] == null)
            {
                lblPageHeader.Text = "Country Add";
            }
            else
            {
                lblPageHeader.Text = "Country Edit";
                FillCountryForm(Convert.ToInt32(Request.QueryString["CountryID"].ToString().Trim()));
            }
        }
    }
    #endregion

    #region Fill Country Form
    private void FillCountryForm(SqlInt32 CountryID)
    {

        CountryBAL balCountry = new CountryBAL();
        CountryENT entCountry = new CountryENT();
        entCountry = balCountry.SelectByPK(CountryID);
        if (!entCountry.CountryName.IsNull)
            txtCountryName.Text = entCountry.CountryName.ToString();
        if (!entCountry.CountryCode.IsNull)
            txtCountryCode.Text = entCountry.CountryCode.ToString();
    }
    #endregion

    #region Button: Cancel Country
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Content/AdminPanel/Country/CountryList.aspx");
    }
    #endregion

    #region Button: Save Country
    protected void btnSave_Click(object sender, EventArgs e)
    {


        #region Server Validation
        string strError = "";
        if (txtCountryName.Text.Trim() == "")
            strError += "Enter Country Name+</br>";

        if (txtCountryCode.Text.Trim() == "")
            strError += "Enter Country Code";

        if (strError.Trim() != "")
        {
            lblErrorMessage.Text = strError;
            return;
        }
        #endregion

        #region Assign Value
        CountryENT entCountry = new CountryENT();
        if (txtCountryName.Text.Trim() != "")
            entCountry.CountryName = txtCountryName.Text.Trim();

        if (txtCountryCode.Text.Trim() != "")
            entCountry.CountryCode = Convert.ToInt32(txtCountryCode.Text.Trim());
        #endregion

        #region Save OR Edit 
        CountryBAL balCountry = new CountryBAL();
        if (Request.QueryString["CountryID"] == null)
        {
            if (balCountry.Insert(entCountry))
            {
                ClearControl();
            }
            else
            {
                lblErrorMessage.Text = balCountry.Message;
            }
        }
        else
        {
            entCountry.CountryID = Convert.ToInt32(Request.QueryString["CountryID"]);
            if (balCountry.Update(entCountry))
            {
                ClearControl();
                Response.Redirect("~/Content/AdminPanel/Country/CountryList.aspx");
            }
            else
            {
                lblErrorMessage.Text = balCountry.Message;
            }
        }
        #endregion
    }

    #endregion

    #region Clear Control
    public void ClearControl()
    {
        txtCountryCode.Text = "";
        txtCountryName.Text = "";
    }
    #endregion
}