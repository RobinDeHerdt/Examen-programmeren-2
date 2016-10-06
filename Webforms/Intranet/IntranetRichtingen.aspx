<%@ Page Title="" Language="C#" MasterPageFile="~/Intranet/IntranetMasterPage.master" AutoEventWireup="true" CodeFile="IntranetRichtingen.aspx.cs" Inherits="IntranetRichtingen" %>

<asp:Content ID="Content1" ContentPlaceHolderID="NestedContentTitle" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="NestedContentBody" Runat="Server">
    <h1>Voeg richting toe</h1>
    <div class="formcontainer">
        <form runat="server">
            <table class="formtable">
                <tr>
                    <td><label>Naam</label></td>
                    <td><asp:TextBox ID="txtRichtingNaam" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="requiredFieldValidatorRichtingNaam" runat="server" ControlToValidate="txtRichtingNaam" ErrorMessage="Verplicht veld!" ForeColor="Maroon"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="height: 31px"><label>Omschrijving</label></td>
                    <td style="height: 31px"><asp:TextBox ID="txtRichtingOmschrijving" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="requiredFieldValidatorRichtingOmschrijving" runat="server" ControlToValidate="txtRichtingOmschrijving" ErrorMessage="Verplicht veld!" ForeColor="Maroon"></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
            <asp:Button ID="insertRichtingen" runat="server" Text="Voeg toe" OnClick="insertRichtingen_Click" />
        </form>
    </div>
    <h1>Bewerk lijst met richtingen </h1>

    <asp:Label ID="lblError" runat="server" Text="" CssClass="errormessage" Visible="false"></asp:Label>

    <table class="table">
        <thead>
            <tr>
                <th>Naam</th>
                <th>Omschrijving</th>
                <th class="centeredvalue">Bewerken</th>
                <th class="centeredvalue">Verwijderen</th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="richtingRepeater" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%#Eval("naam")%></td>
                        <td><%#Eval("omschrijving")%></td>
                        <td class="centeredvalue"><a href="\Intranet/Update/UpdateRichting.aspx?idToEdit=<%#Eval("richting_id") %>">Bewerken</a></td>
                        <td class="centeredvalue"><a href="\Intranet/IntranetRichtingen.aspx?idToDelete=<%#Eval("richting_id") %>">Verwijderen</a></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
</asp:Content>

