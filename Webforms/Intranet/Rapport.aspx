<%@ Page Title="" Language="C#" MasterPageFile="~/Intranet/IntranetMasterPage.master" AutoEventWireup="true" CodeFile="Rapport.aspx.cs" Inherits="Rapport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="NestedContentTitle" Runat="Server">
    Rapport
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="NestedContentBody" Runat="Server">
        <h1><asp:Label ID="lblNaam" runat="server" Text=""></asp:Label></h1>
        <asp:Label ID="lblError" runat="server" Text="" CssClass="errormessage"></asp:Label>
        <table class="table">
        <thead>
            <tr>
                <th>Wiskunde</th>
                <th>Frans</th>
                <th>Engels</th>
                <th>Sport</th>
                <th>Biologie</th>
            </tr>
        </thead>
        <tbody>
                    <tr>
                        <td>
                            <asp:Label ID="lblWiskunde" runat="server" Text=""></asp:Label></td>
                        <td>
                            <asp:Label ID="lblFrans" runat="server" Text=""></asp:Label></td>
                        <td>
                            <asp:Label ID="lblEngels" runat="server" Text=""></asp:Label></td>
                        <td>
                            <asp:Label ID="lblSport" runat="server" Text=""></asp:Label></td>
                        <td>
                            <asp:Label ID="lblBiologie" runat="server" Text=""></asp:Label></td>
                    </tr>
        </tbody>
    </table>
        
    <h1>Update punten</h1>
        <div class="formcontainer">
        <form runat="server">
            <table class="formtable">
                <tr>
                    <td><label>Wiskunde</label></td>
                    <td><asp:TextBox ID="txtWiskunde" runat="server"></asp:TextBox>
                        <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Getal moet zich tussen 0 en 10 bevinden!" ControlToValidate="txtWiskunde" MaximumValue="10" MinimumValue="0" Type="Integer"></asp:RangeValidator><asp:RequiredFieldValidator ID="requiredFieldValidator1" runat="server" ControlToValidate="txtWiskunde" ErrorMessage="Verplicht veld!" ForeColor="Maroon"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td><label>Frans</label></td>
                    <td><asp:TextBox ID="txtFrans" runat="server"></asp:TextBox>
                        <asp:RangeValidator ID="RangeValidator2" runat="server" ErrorMessage="Getal moet zich tussen 0 en 10 bevinden!" ControlToValidate="txtFrans" MaximumValue="10" MinimumValue="0" Type="Integer"></asp:RangeValidator><asp:RequiredFieldValidator ID="requiredFieldValidatorRichtingNaam0" runat="server" ControlToValidate="txtFrans" ErrorMessage="Verplicht veld!" ForeColor="Maroon"></asp:RequiredFieldValidator>
                    </td>   
                </tr>
                 <tr>
                    <td><label>Engels</label></td>
                    <td><asp:TextBox ID="txtEngels" runat="server"></asp:TextBox>
                        <asp:RangeValidator ID="RangeValidator3" runat="server" ErrorMessage="Getal moet zich tussen 0 en 10 bevinden!" ControlToValidate="txtEngels" MaximumValue="10" MinimumValue="0" Type="Integer"></asp:RangeValidator><asp:RequiredFieldValidator ID="requiredFieldValidator2" runat="server" ControlToValidate="txtEngels" ErrorMessage="Verplicht veld!" ForeColor="Maroon"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                 <tr>
                    <td><label>Sport</label></td>
                    <td><asp:TextBox ID="txtSport" runat="server"></asp:TextBox>
                        <asp:RangeValidator ID="RangeValidator4" runat="server" ErrorMessage="Getal moet zich tussen 0 en 10 bevinden!" ControlToValidate="txtSport" MaximumValue="10" MinimumValue="0" Type="Integer"></asp:RangeValidator><asp:RequiredFieldValidator ID="requiredFieldValidator3" runat="server" ControlToValidate="txtSport" ErrorMessage="Verplicht veld!" ForeColor="Maroon"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td><label>Biologie</label></td>
                    <td><asp:TextBox ID="txtBiologie" runat="server"></asp:TextBox>
                        <asp:RangeValidator ID="RangeValidator5" runat="server" ErrorMessage="Getal moet zich tussen 0 en 10 bevinden!" ControlToValidate="txtBiologie" MaximumValue="10" MinimumValue="0" Type="Integer"></asp:RangeValidator><asp:RequiredFieldValidator ID="requiredFieldValidator4" runat="server" ControlToValidate="txtBiologie" ErrorMessage="Verplicht veld!" ForeColor="Maroon"></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
            <asp:Button ID="updateRapport" runat="server" Text="Update rapport" OnClick="updateRapport_Click" />
        </form>   
    </div>
    <a href="\Intranet/IntranetLeerlingen.aspx" class="goBack">Terug naar leerlingen</a>
</asp:Content>

