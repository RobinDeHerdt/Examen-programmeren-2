<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentTitle" Runat="Server">
    Contact
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" Runat="Server">
    <h1>Contactinfo</h1>
    <div class="artikel">
        <p>Campus Biekorfstraat</p>
        <p>015 / 24 16 74</p>
        <p>middenschool@heilig-hartcollege.be</p>
    </div>
    <div class="artikel">
        <p>Campus Kloosterstraat</p>
        <p>015 / 24 16 36</p>
        <p>bovenbouw@heilig-hartcollege.be</p>
    </div>
    <h1>Contacteer ons via email</h1>
    <div class="artikel">
        <form>
            <h3>Mijn contactgegevens</h3>
            <label>Naam</label>
            <br />
            <input type="text" name="naam" size="49"/>
            <br /><br />
            <label>Achternaam</label>
            <br />
            <input type="text" name="achternaam" size="49"/>
            <br /><br />
            <label>Email</label>
            <br />
            <input type="text" name="email" size="49"/>
            <br /><br />
            <h3>Bericht</h3>
            <textarea name="bericht" rows="8" cols="50"></textarea>
            <br />
            <input type="submit" value="Verzenden" />
        </form>
    </div>
</asp:Content>

