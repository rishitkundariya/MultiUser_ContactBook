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

public partial class Content_AdminPanel_ContactCategory_ContactCategoryList : System.Web.UI.Page
{
    #region Load Page
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillGridViewContactCategory();
        }
    }
    #endregion

    #region Fill ContactCategory Grid View
    private void FillGridViewContactCategory()
    {
        ContactCategoryBAL balContactCategory = new ContactCategoryBAL();
        gvContactCategory.DataSource = balContactCategory.SelectAll();
        gvContactCategory.DataBind();
    }
    #endregion

    #region Button: Add ContactCategory
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Content/AdminPanel/ContactCategory/ContactCategoryAddEdit.aspx");
    }
    #endregion

    #region Button: Delete Contact Category 
    private void DeleteContactCategory(SqlInt32 ContactCategoryID)
    {
        ContactCategoryBAL balContactCategory = new ContactCategoryBAL();
        if (balContactCategory.Delete(ContactCategoryID))
        {
            FillGridViewContactCategory();
        }
        else
        {
            lblErrorMessage.Text = balContactCategory.Message;
        }

    }
    #endregion

    #region Button: Delete Edit Record
    protected void gvContactCategory_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument != null)
            {
                DeleteContactCategory(Convert.ToInt32(e.CommandArgument.ToString().Trim()));
                FillGridViewContactCategory();
            }
        }
        else if (e.CommandName == "EditRecord")
        {
            if (e.CommandArgument != null)
            {
                Response.Redirect(e.CommandArgument.ToString().Trim());
            }
        }
    }
    #endregion
}