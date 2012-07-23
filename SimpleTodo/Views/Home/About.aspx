<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="aboutTitle" ContentPlaceHolderID="TitleContent" runat="server">
    What is SimpleTodo?
</asp:Content>

<asp:Content ID="aboutContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>About SimpleTodo</h2>
    <p>Quite simply, SimpleTodo is a simple todo list manager written in ASP.NET MVC3.</p>
    <p>The goal of SimpleTodo is to demonstrate the fundamentals of ASP.NET MVC3, as well as to serve as a simple way of reminding its users to do things.</p>
    <p>Come on in! Have a look around! Enjoy yourself!</p>
</asp:Content>
