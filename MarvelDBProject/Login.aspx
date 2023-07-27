<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MarvelDBProject.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <div class="account-login">
        <div class="rowT">
            <div class="col-2T">
               <%-- <img src="\Images\imgProductosNew.png" alt="Alternate Text" />--%>
            </div>
            <div class="col-2T">
                <div class="form-container">
                    <h2>Inicio de Sesión</h2>
                     <hr id="indicator"/>
                     <asp:Label runat="server" ID="lblUsername" Text="Usuario:" CssClass="lblForm"></asp:Label>
                     <asp:TextBox runat="server" ID="txtUsername" AutoComplete="off" PlaceHolder="Nombre de usuario" Text=""></asp:TextBox>                  
                     
                     <asp:Label runat="server" ID="lblPassword" Text="Contraseña:" CssClass="lblForm"></asp:Label>
                     <asp:TextBox runat="server" ID="txtPassword" AutoComplete="off" TextMode="Password" PlaceHolder="Ingrese su contraseña" Text="1234"></asp:TextBox>

                     <asp:Button runat="server" ID="btnEnter" Text="Ingresar" OnClick="btnEnter_Click"></asp:Button>
                     <label>No tenes cuenta? </label><a href="UserRegistration.aspx">Registrate</a>
                     <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </div>
    </div>

    <style>
        .account-login{
            padding:50px 0;
            background: linear-gradient(to bottom, var(--newBg) 5%, #ffffff 95%);
            height:90vh;
        }

        .form-container{
            background:var(--textColorWhite);
            width:400px;
            height:500px;
            position:relative;
            text-align:center;
            padding:20px 0; 
            margin:auto;
            box-shadow: 0 0 20px 0 rgba(0,0,0,0.1);
            border-radius: 10px;
            display:inline-grid;
            justify-content:center;
            align-items:center;
        }

        .form-container h2{
            font-weight:bold;
            padding: 0 10px;
            color:var(--textColorBlack);
            cursor:pointer;
        }

        .rowT{
            display:flex;
            flex-wrap: wrap;
            justify-content:space-around;
        }

        .col-2T {
            color:var(--textColorWhite);
            text-shadow: 1px 1px 1px var(--textColorBlack);
            flex-basis: 50%;
            min-width: 300px;
            padding: 100px;
        }

        .col-2T img{
            max-width:100%;
            padding: 50px 0;
        }

        .col-2T h1{
            font-size:70px;
            line-height: 60px;
            margin: 25px 0;
        }

        .col-2T p{
            font-size:20px;
        }

        #indicator{
            border:none;
            background:var(--bgColor);
            height: 3px;
            margin-top: 8px;
            width:250px;
        }

        input[type="text"],
        input[type="password"] {
            width: 100%;
            padding: 8px;
            margin-bottom: 15px;
            border: 1px solid #ccc;
            border-radius: 5px;
        }

        .lblForm{
            color: var(--textColorBlack);
        }

        .form-container input[type="text"]:focus,
        .form-container input[type="password"]:focus {
            border-color: green;
        }

        .form-container input[type="submit"] {
            width: 100%;
            padding: 10px;
            background-color:var(--otherColor);
            color: #fff;
            border: none;
            border-radius: 5px;
            cursor: pointer;
        }

    </style>
</asp:Content>
