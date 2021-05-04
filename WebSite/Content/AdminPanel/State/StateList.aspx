<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AdminPanel.master" AutoEventWireup="true" CodeFile="StateList.aspx.cs" Inherits="Content_AdminPanel_State_StateList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphHeadContent" Runat="Server">
    State List
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPageContent" Runat="Server">
    <div class="container">
          <div class="row" style="padding-bottom:3em">
        <div class="col-md-2 offset-md-10 text-right pull-righht">
            <asp:Button ID="btnAdd" runat="server" Text="Add State" CssClass="btn btn-primary" OnClick="btnAdd_Click" />
        </div>
    </div>
        <div class="row">
            <div class="col-md-12" style="padding-bottom:30px">
                <asp:Label ID="lblErrorMessage" runat="server" CssClass="text-danger" EnableViewState="false" />
                    <asp:GridView ID="gvState" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-striped" OnRowCommand="gvState_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="StateID" HeaderText="ID" ItemStyle-Width="100px"/>
                            <asp:BoundField DataField="StateName" HeaderText="State Name" ItemStyle-Width="150px"/>
                            <asp:BoundField DataField="CountryName" HeaderText="Country Name" ItemStyle-Width="100px"/>
                            <asp:TemplateField HeaderText="Oprations" ItemStyle-Width="100px">
                                <ItemTemplate>
                                    <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-sm btn-danger" CommandName="DeleteRecord" CommandArgument='<%# Eval("StateID") %>'/>
                                    <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="btn btn-sm btn-info" CommandName="EditRecord" CommandArgument='<%# "~/Content/AdminPanel/State/StateAddEdit.aspx?StateID=" + Eval("StateID").ToString() %>'/>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                     </asp:GridView>
            </div>
        </div>
    </div>
  
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphScriptBlock" Runat="Server">
</asp:Content>

