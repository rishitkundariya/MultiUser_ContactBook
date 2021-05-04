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

public partial class Content_AdminPanel_ContactCategory_ContactCategoryAddEdit : System.Web.UI.Page
{
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["ContactCategoryID"] == null)
            {
                lblPageHeader.Text = "ContactCategory Add";
            }
            else
            {
                lblPageHeader.Text = "ContactCategory Edit";
                FillContactCategoryForm(Convert.ToInt32(Request.QueryString["ContactCategoryID"].ToString().Trim()));
            }
        }
    }
    #endregion

    #region Fill ContactCategory Form
    private void FillContactCategoryForm(SqlInt32 ContactCategoryID)
    {

        ContactCategoryBAL balContactCategory = new ContactCategoryBAL();
        ContactCategoryENT entContactCategory = new ContactCategoryENT();
        entContactCategory = balContactCategory.SelectByPK(ContactCategoryID);
        if (!entContactCategory.ContactCategoryName.IsNull)
            txtContactCategoryName.Text = entContactCategory.ContactCategoryName.ToString();
    }
    #endregion

    #region Button: Cancel ContactCategory
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Content/AdminPanel/ContactCategory/ContactCategoryList.aspx");
    }
    #endregion

    #region Button: Ssave ContactCategory
    protected void btnSave_Click(object sender, EventArgs e)
    {


        #region Server Validation
        string strError = "";
        if (txtContactCategoryName.Text.Trim() == "")
            strError += "Enter ContactCategory Name+</br>";

        if (strError.Trim() != "")
        {
            lblErrorMessage.Text = strError;
            return;
        }
        #endregion

        #region Assign Value
        ContactCategoryENT entContactCategory = new ContactCategoryENT();
        if (txtContactCategoryName.Text.Trim() != "")
            entContactCategory.ContactCategoryName = txtContactCategoryName.Text.Trim();
        #endregion

        #region Save OR Edit 
        ContactCategoryBAL balContactCategory = new ContactCategoryBAL();
        if (Request.QueryString["ContactCategoryID"] == null)
        {
            if (balContactCategory.Insert(entContactCategory))
            {
                lblSuccess.Text = "Data Insert Successfully";
                txtContactCategoryName.Text = "";
                txtContactCategoryName.Focus();
            }
            else
            {
                lblErrorMessage.Text = balContactCategory.Message;
            }
        }
        else
        {
            entContactCategory.ContactCategoryID = Convert.ToInt32(Request.QueryString["ContactCategoryID"]);
            if (balContactCategory.Update(entContactCategory))
            {

                Response.Redirect("~/Content/AdminPanel/ContactCategory/ContactCategoryList.aspx");
            }
            else
            {
                lblErrorMessage.Text = balContactCategory.Message;
            }
        }
        #endregion






    }
    #endregion
}