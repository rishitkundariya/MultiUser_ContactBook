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

public partial class Content_AdminPanel_State_StateList : System.Web.UI.Page
{
    #region Load Page
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillGridViewState();
        }
    }
    #endregion

    #region Fill State Grid View
    private void FillGridViewState()
    {
        StateBAL balState = new StateBAL();
        DataTable dtState = new DataTable();
        dtState =balState.SelectAll();
        if(dtState!=null && dtState.Rows.Count > 0)
        {
            gvState.DataSource=dtState;
            gvState.DataBind();
        }

    }
    #endregion

    #region Button: Add City
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Content/AdminPanel/State/StateAddEdit.aspx");
    }
    #endregion

    #region Button: Delete State 
    private void DeleteCity(SqlInt32 StateID)
    {
        StateBAL balState = new StateBAL();
        if (balState.Delete(StateID))
        {
            FillGridViewState();
        }
        else
        {
            lblErrorMessage.Text = balState.Message;
        }
    }
    #endregion

    #region Button: Delete Edit Record
    protected void gvState_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument != null)
            {
                DeleteCity(Convert.ToInt32(e.CommandArgument.ToString().Trim()));
                FillGridViewState();
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