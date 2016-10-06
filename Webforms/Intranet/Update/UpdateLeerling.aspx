<%@ Page Title="" Language="C#" MasterPageFile="~/Intranet/IntranetMasterPage.master" AutoEventWireup="true" CodeFile="UpdateLeerling.aspx.cs" Inherits="Rapport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="NestedContentTitle" Runat="Server">
    Update leerling
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="NestedContentBody" Runat="Server">
    <asp:Label ID="lblError" runat="server" Text="" CssClass="errormessage"></asp:Label>
    <h1><asp:Label ID="lblStudentNaam" runat="server" Text=""></asp:Label></h1>

    <div class="formcontainer">
        <form runat="server">
            <table class="formtable">
                <tr>
                    <td><label>Achternaam</label></td>
                    <td><asp:TextBox ID="txtAchternaam" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="requiredFieldValidatorAchternaam" runat="server" ControlToValidate="txtAchternaam" ErrorMessage="Verplicht veld!" ForeColor="Maroon"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td><label>Voornaam</label></td>
                    <td><asp:TextBox ID="txtVoornaam" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="requiredFieldValidatorVoornaam" runat="server" ControlToValidate="txtVoornaam" ErrorMessage="Verplicht veld!" ForeColor="Maroon"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                 <tr>
                    <td><label>Email ouder</label></td>
                    <td><asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="requiredFieldValidatorEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Verplicht veld!" ForeColor="Maroon"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td><label>Klasgroep</label></td>
                    <td>
                        <asp:DropDownList ID="dropDownKlasgroepen" runat="server" CssClass="dropDownMenu"></asp:DropDownList>
                    </td>
                </tr>
            </table>
            <asp:Button ID="updateLeerling" runat="server" Text="Update student" OnClick="insertLeerling_Click"/>
        </form>
    </div>
</asp:Content>

