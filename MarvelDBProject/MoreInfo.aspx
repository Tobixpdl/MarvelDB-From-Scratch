<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MoreInfo.aspx.cs" Inherits="MarvelDBProject.MoreInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

       <div class = "card">
                    <img src='<%:Character.Images[0].Url%>' alt="">
                    <div class="card-content">
                      <h2>
                        <%:Character.Name%>
                      </h2>
                      <p>
                        <%:Character.Description%>
                      </p>               
                    </div>
               </div>


</asp:Content>
