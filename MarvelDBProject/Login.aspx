<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MarvelDBProject.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="account-login">
        <div class="rowT">
            <div class="centered">
                <div class="col-2T">
                    <div class="form-container">
                        <h2>Inicio de Sesión</h2>
                        <hr id="indicator" />
                        <asp:Label runat="server" ID="lblUsername" Text="Usuario:" CssClass="lblForm"></asp:Label>
                        <asp:TextBox runat="server" ID="txtUsername" AutoComplete="off" PlaceHolder="Nombre de usuario" Text=""></asp:TextBox>

                        <asp:Label runat="server" ID="lblPassword" Text="Contraseña:" CssClass="lblForm"></asp:Label>
                        <asp:TextBox runat="server" ID="txtPassword" AutoComplete="off" TextMode="Password" PlaceHolder="Ingrese su contraseña" Text="1234"></asp:TextBox>

                        <asp:Button runat="server" ID="btnEnter" Text="Ingresar" OnClick="btnEnter_Click"></asp:Button>
                        <label>No tenes cuenta? </label>
                        <a href="UserRegistration.aspx" class="customLink">Registrate</a>
                        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <style>
        .account-login {
            padding: 50px 0;
            height: 90vh;
        }

        .form-container {
            background: rgba(220, 32, 32, 0.31);
            border-radius: 16px;
            box-shadow: 0 4px 30px rgba(0, 0, 0, 0.1);
            backdrop-filter: blur(8.5px);
            -webkit-backdrop-filter: blur(8.5px);
            width: 400px;
            height: 500px;
            position: relative;
            text-align: center;
            padding: 20px 0;
            margin: auto;
            box-shadow: 0 0 20px 0 rgba(0,0,0,0.1);
            border-radius: 10px;
            display: inline-grid;
            justify-content: center;
            align-items: center;
        }

            .form-container h2 {
                font-weight: bold;
                padding: 0 10px;
                color: goldenrod;
                text-shadow: 1px 1px 2px red;
                cursor: pointer;
            }

        .rowT {
            display: flex;
            flex-wrap: wrap;
            justify-content: space-around;
        }

        .col-centered {
            display: flex;
            justify-content: center;
        }

        .col-2T {
            color: goldenrod;
            flex-basis: 50%;
            padding: 100px;
        }


            .col-2T h1 {
                font-size: 70px;
                line-height: 60px;
                margin: 25px 0;
            }

            .col-2T p {
                font-size: 20px;
            }

        #indicator {
            border: none;
            background-color: silver;
            height: 3px;
            margin-top: 8px;
            width: 250px;
        }

        input[type="text"],
        input[type="password"] {
            width: 100%;
            padding: 8px;
            margin-bottom: 15px;
            border: 1px solid #ccc;
            border-radius: 5px;
        }

        .lblForm {
            color: ghostwhite;
        }

        .form-container input[type="text"]:focus,
        .form-container input[type="password"]:focus {
            border-color: green;
        }

        .form-container input[type="submit"] {
            width: 100%;
            padding: 10px;
            background-color: blue;
            color: #fff;
            border: none;
            border-radius: 5px;
            cursor: pointer;
        }

        .customLink {
            color: ghostWhite;
            text-decoration: none;
            border-bottom: 1px solid transparent; 
            transition: all 0.3s; 
        }

            .customLink:hover {
                transform: scale(1.2);
                color: mediumblue;
            }
    </style>
</asp:Content>
