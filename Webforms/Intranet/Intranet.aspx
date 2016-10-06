<%@ Page Title="" Language="C#" MasterPageFile="~/Intranet/IntranetMasterPage.master" AutoEventWireup="true" CodeFile="Intranet.aspx.cs" Inherits="Intranet" %>

<%-- Add content controls here --%>
<asp:Content ID="Content1" ContentPlaceHolderID="NestedContentTitle" Runat="Server">
    Intranet
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="NestedContentBody" Runat="Server">
    <!-- Vul met variable content   -->
    <div class="centeredtext">
        <h2>Welkom op het intranet van HHS</h2>
        <p>Hier kan u aanpassingen maken op de schooldatabase.</p>
    </div>
    
</asp:Content>

