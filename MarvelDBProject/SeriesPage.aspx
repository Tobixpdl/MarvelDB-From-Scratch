<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="SeriesPage.aspx.cs" Inherits="MarvelDBProject.SeriesPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="dx">
         <div class="card-row">
            <asp:Repeater ID="rprSeries" runat="server">
                <ItemTemplate>
                      <div class = "card">
                        <img src='<%# Eval("ImageUrl") %>' alt="" loading="lazy">
                        <div class="card-content">
                          <h2><%#Eval("Name")%></h2>
                          <p>
                            <%#Eval("Description")%>
                          </p>
                          <a href="MoreInfo.aspx?serie_Id=<%#Eval("id") %>" class="button">
                            Find out more 
                          </a>
                        </div>
                      </div>
                </ItemTemplate>
            </asp:Repeater>
         </div>
      </div>

    <style>
        .dx {
            display: flex;
            flex-direction: column;
            justify-content: center;
            align-items: center;
            padding: 50px;
            z-index: 20;
            margin-top: 100px;
        }

        .card-row {
            display: flex;
            flex-wrap: wrap;
            gap: 20px;
            justify-content: center;
            max-width: 1200px;
        }

        .card {
            width: 24rem;
            height: 36rem;
            border-radius: 10px;
            overflow: hidden;
            cursor: pointer;
            position: relative;
            color: rgb(240, 240, 240);
            background-color: black;
            box-shadow: 0 10px 30px 5px rgba(0, 0, 0, 0.2);
        }

            .card img {
                position: absolute;
                /*object-fit: cover;*/ /*Puede ser necesario dependiendo de la imagen*/
                width: 100%;
                height: 100%;
                top: 0;
                left: 0;
                transition: opacity .2s ease-out;
            }

            .card h2 {
                position: absolute;
                inset: auto auto 30px 30px;
                margin: 0;
                transition: inset .3s .3s ease-out;
                font-family: 'Roboto Condensed', sans-serif;
                font-weight: normal;
                text-transform: uppercase;
            }

            .card p, .card a {
                position: absolute;
                opacity: 0;
                max-width: 80%;
                transition: opacity .3s ease-out;
            }

            .card p {
                inset: auto auto 80px 30px;
            }

            .card a {
                inset: auto auto 40px 30px;
                color: inherit;
                text-decoration: none;
            }

            .card:hover h2 {
                inset: auto auto 220px 30px;
                transition: inset .3s ease-out;
            }

            .card:hover p, .card:hover a {
                opacity: 1;
                transition: opacity .5s .1s ease-in;
            }

            .card:hover img {
                transition: opacity .3s ease-in;
                opacity: 0.5;
            }

    </style>

</asp:Content>
