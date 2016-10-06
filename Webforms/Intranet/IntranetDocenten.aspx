<%@ Page Title="" Language="C#" MasterPageFile="~/Intranet/IntranetMasterPage.master" AutoEventWireup="true" CodeFile="IntranetDocenten.aspx.cs" Inherits="IntranetDocenten" %>

<asp:Content ID="Content1" ContentPlaceHolderID="NestedContentTitle" Runat="Server">
    Intranet - Docenten
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="NestedContentBody" Runat="Server">
    <h1>Voeg docenten toe</h1>

    <div class="formcontainer" id="docententabel">
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
                    <td><label>Email</label></td>
                    <td><asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="requiredFieldValidatorEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Verplicht veld!" ForeColor="Maroon"></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
            <asp:Button ID="insertDocent" runat="server" Text="Voeg toe" OnClick="insertLeerling_Click" />
        </form>
    </div>

    <h1>Bewerk lijst met docenten</h1>
    <asp:Label ID="lblError" runat="server" Text="" CssClass="errormessage" Visible="false"></asp:Label>
    <table class="table">
        <thead>
            <tr>
                <th>Voornaam <a class="arrow" href="\Intranet/IntranetDocenten.aspx?sort=voornaam">&#9660</a></th>
                <th>Achternaam <a class="arrow" href="\Intranet/IntranetDocenten.aspx?sort=achternaam">&#9660</a></th>
                <th>Email <a class="arrow" href="\Intranet/IntranetDocenten.aspx?sort=email">&#9660</a></th>
                <th class="centeredvalue">Bewerken</th>
                <th class="centeredvalue">Verwijderen</th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="docentRepeater" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%#Eval("voornaam")%></td>
                        <td><%#Eval("achternaam")%></td>
                        <td><%#Eval("email")%></td>
                        <td class="centeredvalue"><a href="\Intranet/Update/UpdateDocent.aspx?idToEdit=<%#Eval("docent_id") %>">Bewerken</a></td>
                        <td class="centeredvalue"><a href="\Intranet/IntranetDocenten.aspx?idToDelete=<%#Eval("docent_id") %>">Verwijderen</a></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
</asp:Content>

