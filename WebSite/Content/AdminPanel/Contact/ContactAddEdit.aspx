<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AdminPanel.master" AutoEventWireup="true" CodeFile="ContactAddEdit.aspx.cs" Inherits="Content_AdminPanel_Contact_ContactAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphHeadContent" Runat="Server">
    <asp:Label ID="lblPageHeader" runat="server"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPageContent" Runat="Server">
    <div class="container">
        <asp:Label ID="lblErrorMessage" runat="server" CssClass="text-danger" EnableViewState="false" />
        <div class="form-group row">
            <label class="col-md-2 col-form-label">Contact Name<span class="text-danger">*</span></label>
            <div class="col-md-4">
                <asp:TextBox ID="txtContactName" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="rfvContactName" runat="server"
                    ErrorMessage="Enter Contact Name"
                    CssClass="text-danger"
                    ControlToValidate="txtContactName"
                    SetFocusOnError="True"
                    Display="Dynamic" ValidationGroup="Save" />
            </div>
        </div>
        <div class="form-group row">
            <label class="col-md-2 col-form-label">Address<span class="text-danger">*</span></label>
            <div class="col-md-4">
                <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="rfvAddress" runat="server"
                    ErrorMessage="Enter Address Name"
                    CssClass="text-danger"
                    ControlToValidate="txtAddress"
                    SetFocusOnError="True"
                    Display="Dynamic" ValidationGroup="Save" />
            </div>
        </div>
         <div class="form-group row">
            <label class="col-md-2 col-form-label">Country Name</label>
            <div class="col-md-4">
                <asp:DropDownList ID="ddlCountryName" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlCountryName_SelectedIndexChanged"></asp:DropDownList>
            </div>
        </div>
        <div class="form-group row">
            <label class="col-md-2 col-form-label">State Name</label>
            <div class="col-md-4">
                <asp:DropDownList ID="ddlStateName" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlStateName_SelectedIndexChanged"></asp:DropDownList>
            </div>
        </div>
        <div class="form-group row">
            <label class="col-md-2 col-form-label">City Name</label>
            <div class="col-md-4">
                <asp:DropDownList ID="ddlCityName" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
        </div>
        
       
        <div class="form-group row">
            <label class="col-md-2 col-form-label">Moible No<span class="text-danger">*</span></label>
            <div class="col-md-4">
                <asp:TextBox ID="txtMobileNo" TextMode="Number" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="rfvMobileNo" runat="server"
                    ErrorMessage="Enter Mobile No"
                    CssClass="text-danger"
                    ControlToValidate="txtMobileNo"
                    SetFocusOnError="True"
                    Display="Dynamic" ValidationGroup="Save" />
            </div>
        </div>
        <div class="form-group row">
            <label class="col-md-2 col-form-label">Phone No</label>
            <div class="col-md-4">
                <asp:TextBox ID="txtPhoneNo" TextMode="Number" runat="server" CssClass="form-control" />
            </div>
        </div>
        <div class="form-group row">
            <label class="col-md-2 col-form-label">Email</label>
            <div class="col-md-4">
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" />
                <asp:RegularExpressionValidator ID="revEmail" runat="server"
                ErrorMessage="Enter Proper Email"
                CssClass="text-danger"
                Display="Dynamic"
                ControlToValidate="txtEmail"
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                SetFocusOnError="True" ValidationGroup="Save"/>
            </div>
        </div>
        <div class="form-group row">
            <label class="col-md-2 col-form-label">Gender<span class="text-danger">*</span></label>
            <div class="col-md-4">
                <asp:TextBox ID="txtGender" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="rfvtxtGender" runat="server"
                    ErrorMessage="Enter Gender Name"
                    CssClass="text-danger"
                    ControlToValidate="txtGender"
                    SetFocusOnError="True"
                    Display="Dynamic" ValidationGroup="Save" />
            </div>
        </div>
        <div class="form-group row">
            <label class="col-md-2 col-form-label">Age</label>
            <div class="col-md-4">
                <asp:TextBox ID="txtAge" runat="server" CssClass="form-control" TextMode="Number" />
            </div>
        </div>
        <div class="form-group row">
            <label class="col-md-2 col-form-label">Profession<span class="text-danger">*</span></label>
            <div class="col-md-4">
                <asp:TextBox ID="txtProfession" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="rfvProfession" runat="server"
                    ErrorMessage="Enter Profession Name"
                    CssClass="text-danger"
                    ControlToValidate="txtProfession"
                    SetFocusOnError="True"
                    Display="Dynamic" ValidationGroup="Save" />
            </div>
        </div>
        <div class="form-group row">
            <label class="col-md-2 col-form-label">ContactCategory Name</label>
            <div class="col-md-4">
                <asp:DropDownList ID="ddlContactCategoryName" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
        </div>
        <div class="form-group row">
            <label class="col-md-2 col-form-label">BloodGroup Name</label>
            <div class="col-md-4">
                <asp:DropDownList ID="ddlBloodGroupName" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
        </div>
        <div class="form-group row">
            <div class="col-md-5 offset-md-2">
                <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="Save" CssClass="btn btn-primary" OnClick="btnSave_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger" OnClick="btnCancel_Click" />
            </div>
            <div class="col-md-3">
                <asp:Label ID="lblSuccess" runat="server" CssClass="text-success" EnableViewState="false" />
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphScriptBlock" Runat="Server">
</asp:Content>

