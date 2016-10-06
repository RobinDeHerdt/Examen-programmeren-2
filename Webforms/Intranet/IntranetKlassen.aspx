<%@ Page Title="" Language="C#" MasterPageFile="~/Intranet/IntranetMasterPage.master" AutoEventWireup="true" CodeFile="IntranetKlassen.aspx.cs" Inherits="IntranetKlassen" %>

<asp:Content ID="Content1" ContentPlaceHolderID="NestedContentTitle" Runat="Server">
    Intranet - Klassen
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="NestedContentBody" Runat="Server">
    <h1>Voeg klassen toe</h1>
     <div class="formcontainer">
        <form runat="server">
            <table class="formtable">
                <tr>
                    <td><label>Volledige klasnaam</label></td>
                    <td><asp:TextBox ID="txtVolledigeKlasNaam" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="requiredFieldValidatorKlasnaam" runat="server" ControlToValidate="txtVolledigeKlasNaam" ErrorMessage="Verplicht veld!" ForeColor="Maroon"></asp:RequiredFieldValidator>
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
                    <td><label>Titularis</label></td>
                    <td>
                        <asp:DropDownList ID="dropDownDocenten" runat="server" CssClass="dropDownMenu"></asp:DropDownList>
                    </td>
                </tr>
            </table>
            <asp:Button ID="insertKlas" runat="server" Text="Voeg toe" OnClick="insertKlas_Click"/>
        </form>
        </div>
    <h1>Bewerk lijst met klassen</h1>
    <asp:Label ID="lblError" runat="server" Text="" CssClass="errormessage" Visible="false"></asp:Label>
    <table class="table">
        <thead>
            <tr>
                <th>Klascode <a class="arrow" href="\Intranet/IntranetKlassen.aspx?sort=klascode#jumptotable">&#9660</a></th>
                <th>Volledige naam <a class="arrow" href="\Intranet/IntranetKlassen.aspx?sort=naam#jumptotable">&#9660</a></th>
                <th>Richting <a class="arrow" href="\Intranet/IntranetKlassen.aspx?sort=richting#jumptotable">&#9660</a></th>
                <th class="centeredvalue">Bewerken</th>
                <th class="centeredvalue">Verwijderen</th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="klasgroepgRepeater" runat="server">
                <ItemTemplate>

                    <tr>
                        <td><%#Eval("klascode")%></td>
                        <td><%#Eval("naam")%></td>
                        <td><%#Eval("richtingnaam")%></td>
                        <td class="centeredvalue"><a href="\Intranet/Update/UpdateKlasgroep.aspx?idToEdit=<%#Eval("klasgroep_id") %>">Bewerken</a></td>
                        <td class="centeredvalue"><a href="\Intranet/IntranetKlassen.aspx?idToDelete=<%#Eval("klasgroep_id") %>#jumptotable">Verwijderen</a></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
</asp:Content>

