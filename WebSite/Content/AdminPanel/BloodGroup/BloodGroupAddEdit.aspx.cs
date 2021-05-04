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

public partial class Content_AdminPanel_BloodGroup_BloodGroupAddEdit : System.Web.UI.Page
{
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["BloodGroupID"] == null)
            {
                lblPageHeader.Text = "BloodGroup Add";
            }
            else
            {
                lblPageHeader.Text = "BloodGroup Edit";
                FillBloodGroupForm(Convert.ToInt32(Request.QueryString["BloodGroupID"].ToString().Trim()));
            }
        }
    }
    #endregion

    #region Fill BloodGroup Form
    private void FillBloodGroupForm(SqlInt32 BloodGroupID)
    {
         BloodGroupBAL balBloodGroup = new BloodGroupBAL();
        BloodGroupENT entBloodGroup = new BloodGroupENT();
        entBloodGroup = balBloodGroup.SelectByPK(BloodGroupID);
        if (!entBloodGroup.BloodGroupName.IsNull)
            txtBloodGroupName.Text = entBloodGroup.BloodGroupName.ToString();
        
       
    }
    #endregion

    #region Button: Cancel BloodGroup
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Content/AdminPanel/BloodGroup/BloodGroupList.aspx");
    }
    #endregion

    #region Button: Save BloodGroup
    protected void btnSave_Click(object sender, EventArgs e)
    {
        

        #region Server Validation
        string strError = "";
        if (txtBloodGroupName.Text.Trim() == "")
            strError += "Enter BloodGroup Name+</br>";

        if (strError.Trim() != "")
        {
            lblErrorMessage.Text = strError;
            return;
        }
        #endregion

        #region Assign Value
        BloodGroupENT entBloodGroup = new BloodGroupENT();
        if (txtBloodGroupName.Text.Trim() != "")
            entBloodGroup.BloodGroupName = txtBloodGroupName.Text.Trim();
        #endregion

        #region Save OR Edit 
        BloodGroupBAL balBloodGroup = new BloodGroupBAL();
        if (Request.QueryString["BloodGroupID"] == null)
        {
            if (balBloodGroup.Insert(entBloodGroup))
            {
                lblSuccess.Text = "Data Insert Successfully";
                txtBloodGroupName.Text = "";
                txtBloodGroupName.Focus();
            }
            else
            {
                lblErrorMessage.Text = balBloodGroup.Message;
            }
        }
        else
        {
            entBloodGroup.BloodGroupID = Convert.ToInt32(Request.QueryString["BloodGroupID"]);
            if (balBloodGroup.Update(entBloodGroup))
            {
                
                Response.Redirect("~/Content/AdminPanel/BloodGroup/BloodGroupList.aspx");
            }
            else
            {
                lblErrorMessage.Text = balBloodGroup.Message;
            }
        }
        #endregion
    }
    #endregion
}