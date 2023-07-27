<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="UserRegistration.aspx.cs" Inherits="MarvelDBProject.UserRegistration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 
    <div class="account-login">
        <div class="rowT">
            <div class="col-2T">
                <img src="\Images\imgProductosNew.png" alt="Alternate Text" />
            </div>
            <div class="col-2T">
                <div class="form-container">
                    <h2>Registro</h2>
                    <hr id="indicator"/>

                    <div class="container-types">
                        <div class="container-row">
                            <asp:Label runat="server" ID="lblFullName" Text="Full Name:" CssClass="lbls"></asp:Label>
                            <asp:TextBox runat="server" ID="txtFullName" AutoPostBack="true" AutoComplete="off" PlaceHolder="FullName" CssClass="inputs"></asp:TextBox>
                        </div>
                      <asp:Label ID="lblWrongFullName" runat="server" Text="Nombre no puede tener numeros" CssClass="lblWrong"></asp:Label>                 
                    </div>

                    <div class="container-types">
                        <div class="container-row">
                            <asp:Label runat="server" ID="lblDNI" Text="Ingrese su DNI:" CssClass="lbls"></asp:Label>
                            <asp:TextBox runat="server" ID="txtDNI" AutoPostBack="true" AutoComplete="off" PlaceHolder="DNI" CssClass="inputs"></asp:TextBox>
                        </div>
                            <asp:Label ID="lblWrongDNI" runat="server" Text="Debes ingresar un DNI" CssClass="lblWrong"></asp:Label>
                    </div>

                    <div class="container-types">
                        <div class="container-row">
                            <asp:Label runat="server" ID="lblMail" Text="Ingrese sus mail:" CssClass="lbls"></asp:Label>
                            <asp:TextBox runat="server" ID="txtMail" AutoPostBack="true" AutoComplete="off" PlaceHolder="Mail" TextMode="Email" CssClass="inputs"></asp:TextBox>
                        </div>
                            <asp:Label ID="lblWrongMail" runat="server" Text="Mail incorrecto" CssClass="lblWrong"></asp:Label>
                    </div>

                    <div class="container-types">
                        <div class="container-row">
                            <asp:Label runat="server" ID="lblUsername" Text="Ingrese un nombre de usuario:" CssClass="lbls"></asp:Label>
                            <asp:TextBox runat="server" ID="txtUsername" AutoPostBack="true" AutoComplete="off" PlaceHolder="Nombre de usuario" CssClass="inputs"></asp:TextBox>
                       </div>
                            <asp:Label ID="lblWrongUser" runat="server" Text="Este usuario ya existe" CssClass="lblWrong"></asp:Label>
                  </div>

                    <div class="container-types">
                        <div class="container-row">
                            <asp:Label runat="server" ID="lblPassword" Text="Ingrese una contraseña:" CssClass="lbls"></asp:Label>
                            <asp:TextBox runat="server" ID="txtPassword" AutoPostBack="true" AutoComplete="off" PlaceHolder="Contraseña" CssClass="inputs"></asp:TextBox>
                       </div>
                   </div>

                    <div class="container-types">
                        <div class="container-row">
                            <asp:Label runat="server" ID="Label1" Text="Ingrese contraseña nuevamente:" CssClass="lbls"></asp:Label>
                            <asp:TextBox runat="server" ID="TextBox1" AutoPostBack="true" AutoComplete="off" PlaceHolder="Contraseña" CssClass="inputs"></asp:TextBox>
                       </div>   
                            <asp:Label ID="lblWrongPass2" runat="server" Text="Contraseña mal copiada" CssClass="lblWrong"></asp:Label>
                    </div>

                        <div class="buttons">
                        <asp:Button runat="server" ID="btnEnter" OnClick="btnEnter_Click" Text="Ingresar"></asp:Button>
                        <asp:Button ID="BtnReturn" runat="server" OnClick="BtnReturn_Click" Text="Regresar" />
                        </div>
                        <asp:Label ID="lblIsUserCreated" runat="server" Text="" CssClass="lblWrongUs"></asp:Label>
                        <asp:Label ID="lblMissing" runat="server" Text="Faltan datos" CssClass="lblWrongUs"></asp:Label>
                </div>
            </div>
        </div>
    </div>

    <style>
        .account-login{
            padding:50px 0;
            background: linear-gradient(to bottom, var(--newBg) 5%, #ffffff 95%);
            height:100vh;
        }
        .form-container{
            background:var(--textColorWhite);
            width:500px;
            height:700px;
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

        .inputs{
            width: 250px;
            padding: 6px;
            margin-bottom: 15px;
            border: 1px solid #ccc;
            border-radius: 5px;
        }

        .lblForm{
            color: var(--textColorBlack);
        }

        .inputs:focus{
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
            margin-left: 20px;
            margin-right: 20px;
        }

        .container-types {
            display:grid;
            align-items:self-end;
        }

        .container-types .lbls{
            width:40%;
            color:var(--textColorBlack);
        }

        .buttons{
            display:flex;
            justify-content:space-between;
            padding-top:5px;
        }

        .wrongInput {
            width: 250px;
            padding: 6px;
            border-radius: 5px;
            color: red;
            border: 2px solid red;
        }

        .lblWrong{
            text-align: right;
            padding-right: 10px;
            color:red;        
            margin-bottom: 10px;
            font-size:10px;
            font-weight:300;
        }

        .container-row {
            display: flex;
            align-items: center;
            justify-content: space-between;
            margin-bottom: 10px;
        }
    </style>

</asp:Content>
