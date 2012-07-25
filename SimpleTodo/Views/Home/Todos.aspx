<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SimpleTodo.Models.TodoList>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Todos
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Todo Lists</h2>

<% using (Html.BeginForm()) {%>
    <div>
        <fieldset>
            <legend>Note 0</legend>
                
            <div class="editor-field">
                <%: Html.TextBoxFor(m => m.Title) %>
                <%: Html.ValidationMessageFor(m => m.Title) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(m => m.List) %>
            </div>
            <div class="editor-field">
                <%: Html.TextAreaFor(m => m.List) %>
            </div>
                
            <p>
                <input type="submit" value="Submit" />
            </p>
        </fieldset>
    </div>
<% } %>

</asp:Content>
