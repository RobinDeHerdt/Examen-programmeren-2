<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Aanbod.aspx.cs" Inherits="Aanbod" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentTitle" Runat="Server">
    Aanbod
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">
    <h1>Overzicht van de richtingen</h1>
    <table class="table">
        <thead>
            <tr>
                <th>Naam</th>
                <th>Omschrijving</th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="aanbodRepeater" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%#Eval("naam")%></td>
                        <td><%#Eval("omschrijving")%></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
</asp:Content>

