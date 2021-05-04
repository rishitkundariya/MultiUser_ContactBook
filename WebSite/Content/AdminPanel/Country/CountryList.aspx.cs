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

public partial class Content_AdminPanel_Country_CountryList : System.Web.UI.Page
{
    #region Load Page
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillGridViewCountry();
        }
    }
    #endregion

    #region Fill Country Grid View
    private void FillGridViewCountry()
    {
        CountryBAL balCountry = new CountryBAL();
        DataTable dtCountry = new DataTable();
        dtCountry = balCountry.SelectAll();
        if (dtCountry != null && dtCountry.Rows.Count > 0)
        {
            gvCountry.DataSource = dtCountry;
            gvCountry.DataBind();
        }
    }
    #endregion

    #region Button: Add Country
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Content/AdminPanel/Country/CountryAddEdit.aspx");
    }
    #endregion

    #region Button: Delete Contact Category 
    private void DeleteCountry(SqlInt32 CountryID)
    {
        CountryBAL balCountry = new CountryBAL();
        if (!balCountry.Delete(CountryID))
        {
            lblErrorMessage.Text = balCountry.Message;
        }
    }
    #endregion

    #region Button: Delete Edit Record
    protected void gvCountry_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument != null)
            {
                DeleteCountry(Convert.ToInt32(e.CommandArgument.ToString().Trim()));
                FillGridViewCountry();
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