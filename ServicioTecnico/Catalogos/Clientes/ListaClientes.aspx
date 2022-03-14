<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaClientes.aspx.cs" Inherits="ServicioTecnico.Catalogos.Clientes.ListaClientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-10">
                <h3>Lista de Clientes</h3>
                <%if (GVClientes.Rows.Count == 0){ %>
                     <h4>No hay registros ingresados aún</h4><hr /> <br />
                        <a href="AltaCliente.aspx"><h4>Clic aquí</h4></a><h4>para empezar</h4>
                
                <%} %>
                <asp:GridView ID="GVClientes" runat="server" CssClass="table table-bordered table-striped table-condensed" AutoGenerateColumns="false" OnRowEditing="GVClientes_RowEditing" OnRowCancelingEdit="GVClientes_RowCancelingEdit" OnRowUpdating="GVClientes_RowUpdating" OnRowDeleting="GVClientes_RowDeleting" DataKeyNames="Id" OnRowCommand="GVClientes_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True">
                            <ItemStyle Width="50px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Nombre" ControlStyle-Width="80px" ItemStyle-Width="100px" DataField="Nombre" />
                        <asp:BoundField HeaderText="Apellido Paterno" ControlStyle-Width="80px" ItemStyle-Width="100px" DataField="ApPaterno" />
                        <asp:BoundField HeaderText="Apellido Materno" ControlStyle-Width="80px" ItemStyle-Width="100px" DataField="ApMaterno" />
                        <asp:BoundField HeaderText="Email" ControlStyle-Width="100px" ItemStyle-Width="100px" DataField="Email" ReadOnly="true"/>
                        <asp:BoundField HeaderText="Teléfono" ControlStyle-Width="100px" ItemStyle-Width="100px" DataField="Telefono" ReadOnly="true" />
                        <asp:CommandField ShowDeleteButton="true" ButtonType="Button" ControlStyle-CssClass="btn btn-danger" ControlStyle-Width="80px" ItemStyle-Width="80px" />
                        <asp:CommandField ShowEditButton="true" ButtonType="Button" ControlStyle-CssClass="btn btn-info" ControlStyle-Width="70px" ItemStyle-Width="70px" />
                        <asp:ButtonField Text="Seleccionar" CommandName="Select" ButtonType="Button" ControlStyle-CssClass="btn btn-info" />
                    </Columns>
                </asp:GridView>
            </div>

        </div>
    </div>
</asp:Content>
