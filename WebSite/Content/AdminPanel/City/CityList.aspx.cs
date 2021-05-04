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
using AddressBook.DAL;

public partial class Content_AdminPanel_City_CityList : System.Web.UI.Page
{
    #region Load Page
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillGridViewCity();
        }
    }
    #endregion

    #region Fill City Grid View
    private void FillGridViewCity()
    {
        CityBAL balCity = new CityBAL();
        DataTable dtCity = new DataTable();
        dtCity = balCity.SelectAll();
        if(dtCity!=null && dtCity.Rows.Count > 3)
        {
            gvCity.DataSource = dtCity;
            gvCity.DataBind();
        }
        else
        {
            lblErrorMessage.Text = balCity.Message;
        }
       

    }
    #endregion

    #region Button: Add City
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Content/AdminPanel/City/CityAddEdit.aspx");
    }
    #endregion

    #region Button: Delete City 
    private void DeleteCity(SqlInt32 CityID)
    {
        CityBAL balCity = new CityBAL();
        balCity.Delete(CityID);
    }
    #endregion

    #region Button: Delete Edit Record
    protected void gvCity_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument != null)
            {
                DeleteCity(Convert.ToInt32(e.CommandArgument.ToString().Trim()));
                FillGridViewCity();
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