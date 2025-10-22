<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Empleados.aspx.cs" Inherits="proyectWeb.Empleados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Formulario Empleados </h1>
    <asp:Label ID="Lbl_codigo" runat="server" Text="Codigo" BackColor="Black" CssClass="badge" Font-Bold="True" Font-Size="Small" ForeColor="White" Height="17px"></asp:Label>
    <asp:TextBox ID="Txt_codigo" runat="server" CssClass="form-control" placeholder="Ej. E001"></asp:TextBox>
    <asp:Label ID="Lbl_nombre" runat="server" Text="Nombre" BackColor="Black" CssClass="badge" Font-Bold="True" Font-Size="Small" ForeColor="White"></asp:Label>
    <asp:TextBox ID="Txt_Nombres" runat="server" CssClass="form-control" placeholder="Ej. Nombre1 Nombre2"></asp:TextBox>
    <asp:Label ID="Lbl_apellido" runat="server" Text="Apellido" BackColor="Black" CssClass="badge" Font-Bold="True" Font-Size="Small" ForeColor="White"></asp:Label>
    <asp:TextBox ID="Txt_apellido" runat="server" CssClass="form-control" placeholder="Ej. Apelllido1 Apelllido2"></asp:TextBox>
    <asp:Label ID="Lbl_direccion" runat="server" Text="Dirección" BackColor="Black" CssClass="badge" Font-Bold="True" Font-Size="Small" ForeColor="White"></asp:Label>
    <asp:TextBox ID="Txt_direccion" runat="server" CssClass="form-control" placeholder="Ej. #Calle avenida lugar"></asp:TextBox>
    <asp:Label ID="Lbl_telefono" runat="server" Text="Telefono" BackColor="Black" CssClass="badge" Font-Bold="True" Font-Size="Small" ForeColor="White"></asp:Label>
    <asp:TextBox ID="Txt_telefono" runat="server" CssClass="form-control" placeholder="Ej. 5555 2222" TextMode="Number"></asp:TextBox>
    <asp:Label ID="Lbl_fechaN" runat="server" Text="Fecha Nacimiento" BackColor="Black" CssClass="badge" Font-Bold="True" Font-Size="Small" ForeColor="White"></asp:Label>
    <asp:TextBox ID="Txt_fechaN" runat="server" CssClass="form-control" placeholder="Ej. yyyy-mm-dd" TextMode="Date"></asp:TextBox>
    <asp:Label ID="Lbl_puesto" runat="server" Text="Puesto" BackColor="Black" CssClass="badge" Font-Bold="True" Font-Size="Small" ForeColor="White"></asp:Label>
    <asp:DropDownList ID="Drop_puesto" runat="server" CssClass="form-control"></asp:DropDownList>
    <asp:Button ID="Btn_crear" runat="server" Text="Crear" CssClass="btn btn-primary" OnClick="Btn_crear_Click" />
    <asp:Button ID="Btn_actualizar" runat="server" Text="Actualizar" CssClass="btn btn-success" OnClick="Btn_actualizar_Click" Visible="False" />
    <asp:Label ID="Lbl_Mensaje" runat="server" BackColor="Black" CssClass="badge" Font-Bold="True" Font-Size="Small" ForeColor="White" Height="20px" Width="150px"></asp:Label>
    <asp:GridView ID="Grid_Empleados" runat="server" AutoGenerateColumns="False" DataKeyNames="id,id_puesto" BorderStyle="Dotted" CellPadding="2" CellSpacing="1" OnRowDeleting="Grid_Empleados_RowDeleting" OnSelectedIndexChanged="Grid_Empleados_SelectedIndexChanged">
        <Columns>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:Button ID="Btn_Select" runat="server" CausesValidation="False" CommandName="Select" Text="Ver" CssClass="btn btn-info" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:Button ID="Btn_Borrar" runat="server" CausesValidation="False" CommandName="Delete" Text="Borrar" CssClass="btn btn-danger" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Codigo" HeaderText="Codigo" />
            <asp:BoundField DataField="nombres" HeaderText="Nombre" />
            <asp:BoundField DataField="apellidos" HeaderText="Apellido" />
            <asp:BoundField DataField="Direccion" HeaderText="Direccion" />
            <asp:BoundField DataField="Telefono" HeaderText="Telefono" />
            <asp:BoundField DataField="Fecha_nacimiento" HeaderText="Fecha Nacimiento" />
            <asp:BoundField DataField="Puesto" HeaderText="Puesto" />
        </Columns>
        <EmptyDataTemplate>
            Tabla vacia
        </EmptyDataTemplate>
    </asp:GridView>

</asp:Content>
