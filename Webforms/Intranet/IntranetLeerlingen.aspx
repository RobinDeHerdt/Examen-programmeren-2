<%@ Page Title="" Language="C#" MasterPageFile="~/Intranet/IntranetMasterPage.master" AutoEventWireup="true" CodeFile="IntranetLeerlingen.aspx.cs" Inherits="IntranetLeerlingen" %>

<asp:Content ID="Content1" ContentPlaceHolderID="NestedContentTitle" Runat="Server">
    Leerlingen
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="NestedContentBody" Runat="Server">
    <h1>Voeg leerling toe</h1>

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
            <asp:Button ID="insertLeerling" runat="server" Text="Voeg toe" OnClick="insertLeerling_Click"/>
        </form>
    </div>
    
    <h1>Bewerk lijst met leerlingen</h1>
    
    <asp:Label ID="lblError" runat="server" Text="" CssClass="errormessage" Visible="false"></asp:Label>
    <table class="table">
        <thead>
            <tr>
                <th>Achternaam <a class="arrow" href="\Intranet/IntranetLeerlingen.aspx?sort=achternaam">&#9660</a></th>
                <th>Voornaam <a class="arrow" href="\Intranet/IntranetLeerlingen.aspx?sort=voornaam">&#9660</a></th>
                <th>Klasgroep <a class="arrow" href="\Intranet/IntranetLeerlingen.aspx?sort=klasgroep">&#9660</a></th>
                <th>Email ouder <a class="arrow" href="\Intranet/IntranetLeerlingen.aspx?sort=email">&#9660</a></th>
                <th class="centeredvalue">Rapport</th>
                <th class="centeredvalue">Bewerken</th>
                <th class="centeredvalue">Verwijderen</th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="leerlingenRepeater" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%#Eval("achternaam")%></td>
                        <td><%#Eval("voornaam")%></td>
                        <td><%#Eval("klascode")%></td>
                        <td><%#Eval("email_ouder")%></td>
                        <td  class="centeredvalue"><a href="\Intranet/Rapport.aspx?student_id=<%#Eval("student_id") %>">Rapport</a></td>
                        <td  class="centeredvalue"><a href="\Intranet/Update/UpdateLeerling.aspx?idToEdit=<%#Eval("student_id") %>">Bewerken</a></td>
                        <td  class="centeredvalue"><a href="\Intranet/IntranetLeerlingen.aspx?idToDelete=<%#Eval("student_id") %>">Verwijderen</a></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
</asp:Content>

