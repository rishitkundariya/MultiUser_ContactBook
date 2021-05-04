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

public partial class Content_AdminPanel_City_CityAddEdit : System.Web.UI.Page
{
    #region Load Page
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillStateDropDownList();
            if (Request.QueryString["CityID"] == null)
            {
                lblPageHeader.Text = "City Add";
            }
            else
            {
                lblPageHeader.Text = "City Edit";
                FillCityForm(Convert.ToInt32(Request.QueryString["CityID"].ToString().Trim()));
            }
        }
    }
    #endregion

    #region Fill State Drop Down List
    private void FillStateDropDownList()
    {
        CommanFillMethod.FillStateDropDownListState(ddlState);
    }
    #endregion

    #region Fill City Form
    private void FillCityForm(SqlInt32 CityID)
    {
        CityBAL balCity = new CityBAL();
        CityEnt entCity = new CityEnt();
        entCity = balCity.SelectByPK(CityID);
        if (!entCity.CityName.IsNull)
            txtCityName.Text = entCity.CityName.ToString();
        if (!entCity.PinCode.IsNull)
            txtPincode.Text = entCity.PinCode.ToString();
        if (!entCity.STDCode.IsNull)
            txtSTDCode.Text = entCity.STDCode.ToString();
        if (Convert.ToInt32(entCity.StateID.Value) > 0)
            ddlState.SelectedValue = entCity.StateID.ToString();

    }
    #endregion

    #region Button: Cancel City
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Content/AdminPanel/City/CityList.aspx");
    }
    #endregion

    #region Button: Save City
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Server Validation
        string strError="";
        if (txtCityName.Text.Trim() == "")
            strError += "Enter City +</br>";

        if (ddlState.SelectedIndex == 0)
            strError += "Select State";

        if (strError.Trim() != "")
        {
            lblErrorMessage.Text = strError;
            return;
        }
        #endregion

        #region Assign Value
        CityEnt entCity = new CityEnt();     
        if (txtCityName.Text.Trim() != "")
            entCity.CityName = txtCityName.Text.Trim();

        if (ddlState.SelectedIndex > 0)
            entCity.StateID = Convert.ToInt32(ddlState.SelectedValue);

        if (txtPincode.Text.Trim() != "")
            entCity.PinCode = Convert.ToInt32(txtPincode.Text.Trim());

        if (txtSTDCode.Text.Trim()!= "")
            entCity.STDCode = Convert.ToInt32(txtSTDCode.Text.Trim());
        #endregion

        #region Save OR Edit 
        CityBAL balCity = new CityBAL();
        if (Request.QueryString["CityID"] == null)
        {
            if (balCity.Insert(entCity))
            {
                ClearControl();
            }
            else
            {
                lblErrorMessage.Text = balCity.Message;
            }
        }
        else
        {
            entCity.CityID = Convert.ToInt32(Request.QueryString["CityID"]);
            if (balCity.Update(entCity))
            {
                ClearControl();
                Response.Redirect("~/Content/AdminPanel/City/CityList.aspx");
            }
            else
            {
                lblErrorMessage.Text = balCity.Message;
            }
        }
        #endregion
    }
    #endregion

    #region Clear Control
    public  void ClearControl()
    {
        txtCityName.Text = "";
        txtPincode.Text = "";
        txtSTDCode.Text = "";
        ddlState.SelectedIndex = 0;
    }
    #endregion

}



