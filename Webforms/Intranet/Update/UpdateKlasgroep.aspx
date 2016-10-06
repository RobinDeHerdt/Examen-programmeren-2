<%@ Page Title="" Language="C#" MasterPageFile="~/Intranet/IntranetMasterPage.master" AutoEventWireup="true" CodeFile="UpdateKlasgroep.aspx.cs" Inherits="Intranet_Update_UpdateKlasgroep" %>

<asp:Content ID="Content1" ContentPlaceHolderID="NestedContentTitle" Runat="Server">
    Update klasgroep
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="NestedContentBody" Runat="Server">
    <asp:Label ID="lblError" runat="server" Text="" CssClass="errormessage"></asp:Label>
    <h1><asp:Label ID="lblStudentNaam" runat="server" Text=""></asp:Label></h1>

    <div class="formcontainer">
        <form runat="server">
            <table class="formtable">
                <tr>
                    <td><label>Volledige klasnaam</label></td>
                    <td><asp:TextBox ID="txtVolledigeKlasnaam" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="requiredFieldValidatorKlasnaam" runat="server" ControlToValidate="txtVolledigeKlasnaam" ErrorMessage="Verplicht veld!" ForeColor="Maroon"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td><label>Klascode</label></td>
                    <td><asp:TextBox ID="txtKlascode" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="requiredFieldValidatorKlascode" runat="server" ControlToValidate="txtKlascode" ErrorMessage="Verplicht veld!" ForeColor="Maroon"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td><label>Richting</label></td>
                    <td>
                        <asp:DropDownList ID="dropDownRichtingen" runat="server" CssClass="dropDownMenu"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td><label>Klasgroep</label></td>
                    <td>
                        <asp:DropDownList ID="dropDownDocenten" runat="server" CssClass="dropDownMenu"></asp:DropDownList>
                    </td>
                </tr>
            </table>
            <asp:Button ID="updateKlasgroep" runat="server" Text="Update klas" OnClick="updateKlasgroep_Click"/>
        </form>
    </div>
</asp:Content>

