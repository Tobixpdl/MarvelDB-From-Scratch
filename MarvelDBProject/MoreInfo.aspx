<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="MoreInfo.aspx.cs" Inherits="MarvelDBProject.MoreInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%if (Character != null)
        { %>
    <div class="infoContainer">
        <article>
            <img src='<%:Character.Images[0].Url%>' alt="">
            <img src='<%:Character.Images[2].Url%>' alt="">
        </article>
        <div class="info-card" style="background-color: <%:Character.color%>50;">
            <div class="info-card-content">
                <h2><%:Character.Name%></h2>
                <p><%:Character.Description%></p>
                <p>The first movie where this character appears on is: "<%:Character.MovieFA%>"</p>
                <p>This character is a <%:Character.Type.Name %></p>
                <p>And a <%:Character.Alingment.Name%></p>
            </div>
        </div>
    </div>

    <%     }

    %>

    <%else if (Movie != null)
        { %>
    <div class="infoMovieContainer">
        <div class="info-card">
            <div class="info-card-content">
                <h2><%:Movie.Name%></h2>
                <p><%:Movie.Description%></p>
                <p>This movie's phase is: "<%:Movie.Phase%>"</p>
                <p>The duration of this movie is <%:Movie.Duration %> minutes</p>
                <p>This movie was released the <%:Movie.ReleaseDate.ToString()%></p>
                <img src="~/Images/cSharpIcon.png" alt="">
            </div>
        </div>
        <div class="MovieImages">
            <asp:Repeater ID="rprMovieImages" runat="server">
                <ItemTemplate>
                    <div class="card">
                        <img src='<%# Eval("Url") %>' alt="">
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>


    <%      } %>
     <%else
        { %>
    <div class="infoMovieContainer">
        <div class="info-card">
            <div class="info-card-content">
                <h2><%:Serie.Name%></h2>
                <p><%:Serie.Description%></p>
                <p>This series' phase is: "<%:Serie.Phase%>"</p>
                <p>The duration of this serie is <%:Serie.FullDuration %> minutes</p>
                <p>This movie was released the <%:Serie.ReleaseDate.ToString()%></p>
                <img src="~/Images/cSharpIcon.png" alt="">
            </div>
        </div>
        <div class="MovieImages">
            <asp:Repeater ID="rprSerieImages" runat="server">
                <ItemTemplate>
                    <div class="card">
                        <img src='<%# Eval("Url") %>' alt="">
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
    <%      } %>

    <style>
        .infoContainer {
            display:flex;
            gap: 100px;
            margin: 200px 50px;
        }
        .infoMovieContainer{
             gap: 100px;
            margin: 200px 50px;
        }

        article {
            position: relative;
            padding: 20px;
            width: 350px;
            transition: all .3s ease;
            margin: auto;
        }

            article img:first-child {
                box-shadow: 0 60px 60px -60px rgba(0,30,255,0.5);
                border-radius: 4px;
                object-fit: cover;
                width: 100%;
            }

            article img:last-child {
                position: absolute;
                width: 350px;
                bottom: 0;
                left: 0;
                right: 0;
                margin: auto;
                transform: translateY(25%);
                transition: .3s ease;
                opacity: 0;
            }

            article:hover {
                transform: perspective(250px) rotateX(10deg) translateY(-5%) translateZ(0);
            }

            article::before {
                content: '';
                position: absolute;
                bottom: 0;
                height: 100%;
                width: 100%;
                background-image: linear-gradient(to bottom, transparent 10%, rgba(0,0,0,0.5) 50%,rgba(0,0,0)95%);
                opacity: 0;
                transition: all 0.3s ease;
            }

            article:hover::before {
                opacity: 1;
            }

            article:hover img:last-child {
                opacity: 1;
                transform: translateX(10%);
            }

        .info-card {
            display: flex; /* Use flexbox to create a flex container */
            align-items: center; /* Align items vertically in the center */
            width: 100%;
            height: auto;
            background: rgba(0, 0, 0, 0.53);
            border-radius: 16px;
            box-shadow: 0 4px 30px rgba(0, 0, 0, 0.1);
            backdrop-filter: blur(5px);
            border: 1px solid rgba(0, 0, 0, 0.3);
            padding: 20px;
        }

            .info-card img {
                object-fit: cover;
                width: 10%;
                height: auto;
                transition: opacity .2s ease-out;
                margin-left: 20px; /* Add some space between the image and the text */
            }

        .info-card-content {
            color: ghostwhite;
            flex: 1; /* Allow the text content to expand and take up remaining space */
            margin-right: 20px; /* Add some space between the text and the image */
        }

        .MovieImages {
            display: flex;
            justify-content: space-around;
            padding: 20px;
        }

        .card {
            width: 20rem;
            border-radius: 10px;
            cursor: pointer;
            position: relative;
            color: rgb(240, 240, 240);
            background-color: black;
            box-shadow: 0 10px 30px 5px rgba(0, 0, 0, 0.2);
        }

            .card img {
                width: 100%;
                top: 0;
                left: 0;
                transition: opacity .2s ease-out
            }

            .card:hover img {
                transition: opacity .3s ease-in;
                opacity: 0.5;
            }
    </style>

</asp:Content>
