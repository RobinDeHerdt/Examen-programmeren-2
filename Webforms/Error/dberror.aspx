<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="dberror.aspx.cs" Inherits="dberror" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentTitle" Runat="Server">
    Database-Error
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" Runat="Server">
    <p class="error">Oops! Er ging iets fout bij het verbinding maken met de database. Probeer eens om de pagina te refreshen (F5).</p>
</asp:Content>

