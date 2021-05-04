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

public partial class Content_AdminPanel_State_StateAddEdit : System.Web.UI.Page
{
    #region Load Page
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillCountryDropDownList();
            if (Request.QueryString["StateID"] == null)
            {
                lblPageHeader.Text = "State Add";
            }
            else
            {
                lblPageHeader.Text = "State Edit";
                FillStateForm(Convert.ToInt32(Request.QueryString["StateID"].ToString().Trim()));
            }
        }
    }
    #endregion

    #region Fill Country Drop Down List
    private void FillCountryDropDownList()
    {
        CommanFillMethod.FillStateDropDownListCountry(ddlCountry);
    }
    #endregion

    #region Fill State Form
    private void FillStateForm(SqlInt32 StateID)
    {
        StateBAL balState = new StateBAL();
        StateENT entState = new StateENT();
        entState = balState.SelectByPK(StateID);
        if (!entState.StateName.IsNull)
            txtStateName.Text = entState.StateName.ToString();
        if (Convert.ToInt32(entState.StateID.Value) > 0)
            ddlCountry.SelectedValue = entState.CountryID.ToString();
    }
    #endregion

    #region Button: Cancel State
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Content/AdminPanel/State/StateList.aspx");
    }
    #endregion

    #region Button: Save State
    protected void btnSave_Click(object sender, EventArgs e)
    {


        #region Server Validation
        string strError = "";
        if (txtStateName.Text.Trim() == "")
            strError += "Enter State +</br>";

        if (ddlCountry.SelectedIndex == 0)
            strError += "Select Country";

        if (strError.Trim() != "")
        {
            lblErrorMessage.Text = strError;
            return;
        }
        #endregion

        #region Assign Value
        StateENT entState = new StateENT();
        if (txtStateName.Text.Trim() != "")
            entState.StateName = txtStateName.Text.Trim();

        if (ddlCountry.SelectedIndex > 0)
            entState.CountryID = Convert.ToInt32(ddlCountry.SelectedValue);
        #endregion

        #region Save OR Edit 
        StateBAL balState = new StateBAL();
        if (Request.QueryString["StateID"] == null)
        {
            if (balState.Insert(entState))
            {
                ClearControl();
            }
            else
            {
                lblErrorMessage.Text = balState.Message;
            }
        }
        else
        {
            entState.StateID = Convert.ToInt32(Request.QueryString["StateID"]);
            if (balState.Update(entState))
            {
                ClearControl();
                Response.Redirect("~/Content/AdminPanel/State/StateList.aspx");
            }
            else
            {
                lblErrorMessage.Text = balState.Message;
            }
        }
        #endregion
    }
    #endregion

    #region Clear Control
    public void ClearControl()
    {
        txtStateName.Text = "";
        ddlCountry.SelectedIndex = 0;
    }
    #endregion
}



