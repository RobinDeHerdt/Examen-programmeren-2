<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Docenten.aspx.cs" Inherits="Docenten" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentTitle" Runat="Server">
        Docenten
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" Runat="Server">
    <h1>Wie is wie?</h1>
    <table class="table">
        <thead>
            <tr>
                <th>Voornaam <a class="arrow" href="Docenten.aspx?sort=voornaam">&#9660</a></th>
                <th>Achternaam <a class="arrow" href="Docenten.aspx?sort=achternaam">&#9660</a></th>
                <th>Klastitularis van <a class="arrow" href="Docenten.aspx?sort=klascode">&#9660</a></th>
                <th>E-mail <a class="arrow" href="Docenten.aspx?sort=email">&#9660</a></th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="docentRepeater" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%#Eval("voornaam")%></td>
                        <td><%#Eval("achternaam")%></td>
                        <td><%#Eval("klascode") %></td>
                        <td><%#Eval("email")%></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
</asp:Content>

