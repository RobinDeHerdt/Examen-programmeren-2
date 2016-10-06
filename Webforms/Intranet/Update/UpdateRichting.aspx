<%@ Page Title="" Language="C#" MasterPageFile="~/Intranet/IntranetMasterPage.master" AutoEventWireup="true" CodeFile="UpdateRichting.aspx.cs" Inherits="Intranet_Update_UpdateRichting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="NestedContentTitle" Runat="Server">
    Update Richting
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="NestedContentBody" Runat="Server">
    <asp:Label ID="lblError" runat="server" Text="" CssClass="errormessage"></asp:Label>
    <h1><asp:Label ID="lblStudentNaam" runat="server" Text=""></asp:Label></h1>

    <div class="formcontainer">
        <form runat="server">
            <table class="formtable">
                <tr>
                    <td><label>Richting</label></td>
                    <td><asp:TextBox ID="txtRichting" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="requiredFieldValidatorRichting" runat="server" ControlToValidate="txtRichting" ErrorMessage="Verplicht veld!" ForeColor="Maroon"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                 <tr>
                    <td><label>Omschrijving</label></td>
                    <td>
                        <asp:TextBox ID="txtOmschrijving" runat="server" Width="600"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="requiredFieldValidatorRichtingOmschrijving" runat="server" ControlToValidate="txtOmschrijving" ErrorMessage="Verplicht veld!" ForeColor="Maroon"></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
            <asp:Button ID="updateRichting" runat="server" Text="Update richting" OnClick="updateRichting_Click"/>
        </form>
    </div>
</asp:Content>

