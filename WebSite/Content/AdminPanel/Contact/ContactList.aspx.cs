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

public partial class Content_AdminPanel_Contact_ContactList : System.Web.UI.Page
{
    #region Load Page
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillGridViewContact();
        }
    }
    #endregion

    #region Fill Contact Grid View
    private void FillGridViewContact()
    {
        ContactBAL balContact = new ContactBAL();
        gvContact.DataSource = balContact.SelectAll();
        gvContact.DataBind();
    }
    #endregion

    #region Button: Add Contact
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Content/AdminPanel/Contact/ContactAddEdit.aspx");
    }
    #endregion

    #region Button: Delete Contact 
    private void DeleteCity(SqlInt32 ContactID)
    {
        ContactBAL balContact = new ContactBAL();
        if (balContact.Delete(ContactID))
        {
            FillGridViewContact();
        }
        else
        {
            lblErrorMessage.Text = balContact.Message;
        }

    }
    #endregion

    #region Button: Delete Edit Record
    protected void gvContact_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument != null)
            {
                DeleteCity(Convert.ToInt32(e.CommandArgument.ToString().Trim()));
                FillGridViewContact();
            }
        }
        else if (e.CommandName == "EditRecord")
        {
            if (e.CommandArgument != null)
                Response.Redirect(e.CommandArgument.ToString().Trim());
        }
    }
    #endregion
}