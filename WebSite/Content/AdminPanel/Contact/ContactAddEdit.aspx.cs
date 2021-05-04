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
using AddressBook;
using AddressBook.BAL;
using AddressBook.ENT;

public partial class Content_AdminPanel_Contact_ContactAddEdit : System.Web.UI.Page
{
    #region Load Page
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillDropDownList();

            if (Request.QueryString["ContactID"] == null)
            {
                lblPageHeader.Text = "Contact Add";
            }
            else
            {
                lblPageHeader.Text = "Contact Edit";
                FillContactForm(Convert.ToInt32(Request.QueryString["ContactID"].ToString().Trim()));
            }
        }
    }
    #endregion

    #region Fill Drop Down List
    private void FillDropDownList()
    {
        CommanFillMethod.FillStateDropDownListCountry(ddlCountryName);
       
        CommanFillMethod.FillStateDropDownListBloodGroup(ddlBloodGroupName);
        CommanFillMethod.FillStateDropDownListContactCategory(ddlContactCategoryName);
    }
    #endregion


    #region Fill Contact Form
    private void FillContactForm(SqlInt32 ContactID)
    {
        ContactBAL balContact = new ContactBAL();
        ContactENT entContact = new ContactENT();
        entContact = balContact.SelectByPK(ContactID);
        if (!entContact.ContactName.IsNull)
        {
            txtContactName.Text = entContact.ContactName.ToString();
        }
        if (!entContact.Address.IsNull)
        {
            txtAddress.Text = entContact.Address.ToString();
        }
        if (!entContact.Email.IsNull)
        {
            txtEmail.Text = entContact.Email.ToString();
        }
        if (!entContact.Profession.IsNull)
        {
            txtProfession.Text = entContact.Profession.ToString();
        }
        if (!entContact.MobileNo.IsNull)
        {
            txtMobileNo.Text = entContact.MobileNo.ToString();
        }
        if (!entContact.PhoneNo.IsNull)
        {
            txtPhoneNo.Text = entContact.PhoneNo.ToString();
        }
        if (!entContact.Gender.IsNull)
        {
            txtGender.Text = entContact.Gender.ToString();
        }
         if (!entContact.StateID.IsNull)
        {
            CommanFillMethod.FillStateDropDownListStateByCountryID(ddlStateName, Convert.ToInt32(entContact.CountryID.ToString()));
            ddlStateName.SelectedValue = entContact.StateID.ToString();
        }
        if (!entContact.CityID.IsNull)
        {
            CommanFillMethod.FillStateDropDownListCityByStateID(ddlCityName, Convert.ToInt32(entContact.StateID.ToString()));
            ddlCityName.SelectedValue = entContact.CityID.ToString();
        }
       
        if (!entContact.CountryID.IsNull)
        {
            ddlCountryName.SelectedValue = entContact.CountryID.ToString();
        }
        if (!entContact.BloodGroupID.IsNull)
        {
            ddlBloodGroupName.SelectedValue = entContact.BloodGroupID.ToString();
        }
        if (!entContact.ContactCategoryID.IsNull)
        {
            ddlContactCategoryName.SelectedValue = entContact.ContactCategoryID.ToString();
        }
        if (!entContact.PhoneNo.IsNull)
        {
            txtPhoneNo.Text = entContact.PhoneNo.ToString();
        }
        if (!entContact.MobileNo.IsNull)
        {
            txtMobileNo.Text =entContact.MobileNo.ToString();
        }
        if (!entContact.Age.IsNull)
        {
            txtAge.Text =entContact.Age.ToString();

        }

    }
    #endregion

    #region Button: Cancel Contact
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Content/AdminPanel/Contact/ContactList.aspx");
    }
    #endregion

    #region Button: Save Contact
    protected void btnSave_Click(object sender, EventArgs e)
    {
        

        #region Server Validation
        string strError = "";
        if (txtContactName.Text.Trim() == "")
            strError += "Enter Contact +</br>";

        if (txtAddress.Text.Trim() == "")
            strError += "Enter Address +</br>";

        if (txtMobileNo.Text.Trim() == "")
            strError += "Enter MobileNo +</br>";

        if (txtGender.Text.Trim() == "")
            strError += "Enter Gender +</br>";

        if (txtProfession.Text.Trim() == "")
            strError += "Enter Profession +</br>";
       
        if (strError.Trim() != "")
        {
            lblErrorMessage.Text = strError;
            return;
        }
        #endregion

        #region Assign Value
        ContactENT entContact = new ContactENT();
        if (txtContactName.Text.Trim() != "")
            entContact.ContactName = txtContactName.Text.Trim();

        if (txtAddress.Text.Trim() != "")
            entContact.Address = txtAddress.Text.Trim();

        if (txtMobileNo.Text.Trim() != "")
            entContact.MobileNo = txtMobileNo.Text.Trim();

        if (txtGender.Text.Trim() != "")
            entContact.Gender = txtGender.Text.Trim();

        if (txtProfession.Text.Trim() != "")
            entContact.Profession = txtProfession.Text.Trim();
        
        if (txtPhoneNo.Text.Trim() != "")
            entContact.PhoneNo = txtPhoneNo.Text.Trim();

        if (txtEmail.Text.Trim() != "")
            entContact.Email = txtEmail.Text.Trim();

        if (txtAge.Text.Trim() != "")
            entContact.Age = Convert.ToInt32(txtAge.Text.Trim());

      

        if (ddlCityName.SelectedIndex != 0)
            entContact.CityID = Convert.ToInt32(ddlCityName.SelectedValue);

        if (ddlStateName.SelectedIndex != 0)
            entContact.StateID = Convert.ToInt32(ddlStateName.SelectedValue);

        if (ddlCountryName.SelectedIndex != 0)
            entContact.CountryID = Convert.ToInt32(ddlCountryName.SelectedValue);

        if (ddlBloodGroupName.SelectedIndex != 0)
            entContact.BloodGroupID = Convert.ToInt32(ddlBloodGroupName.SelectedValue);

        if (ddlContactCategoryName.SelectedIndex != 0)
            entContact.ContactCategoryID = Convert.ToInt32(ddlContactCategoryName.SelectedValue);
        #endregion

        #region Save OR Edit 
        ContactBAL balContact = new ContactBAL();
        if (Request.QueryString["ContactID"] == null)
        {
            if (balContact.Insert(entContact))
            {
                ClearControl();
            }
            else
            {
                lblErrorMessage.Text = balContact.Message;
            }
        }
        else
        {
            entContact.ContactID = Convert.ToInt32(Request.QueryString["ContactID"]);
            if (balContact.Update(entContact))
            {
                ClearControl();
                Response.Redirect("~/Content/AdminPanel/Contact/ContactList.aspx");
            }
            else
            {
                lblErrorMessage.Text = balContact.Message;
            }
        }
        #endregion
    }
    #endregion

    #region Clear Control
    private void ClearControl()
    {

        lblSuccess.Text = "Data Insert Successfully";
        txtContactName.Text = "";
        txtMobileNo.Text = "";
        txtPhoneNo.Text = "";
        txtEmail.Text = "";
        ddlCityName.Items.Clear();
        ddlStateName.Items.Clear();
        ddlCountryName.SelectedIndex=0 ;
        ddlBloodGroupName.Items.Clear() ;
        ddlContactCategoryName.SelectedIndex = 0;
        txtAddress.Text = "";
        txtAge.Text = "";
        txtGender.Text = "";
        txtProfession.Text = "";
        txtContactName.Focus();
    }
    #endregion

    protected void ddlCountryName_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(ddlCountryName.SelectedIndex > 0)
        {
            CommanFillMethod.FillStateDropDownListStateByCountryID(ddlStateName,Convert.ToInt32(ddlCountryName.SelectedValue));
            ddlCityName.Items.Clear();
        }
        else
        {
            ddlCityName.Items.Clear();
            ddlStateName.Items.Clear();
            
        }

    }

    protected void ddlStateName_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlCityName.Items.Clear();
        if (ddlStateName.SelectedIndex > 0)
        {
           
            CommanFillMethod.FillStateDropDownListCityByStateID(ddlCityName, Convert.ToInt32(ddlStateName.SelectedValue));
        }
        else
        {
            ddlCityName.Items.Clear();
        }
    }
}



