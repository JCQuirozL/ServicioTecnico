<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaEquipos.aspx.cs" Inherits="ServicioTecnico.Catalogos.Equipos.ListaEquipos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-10">
                <h3>Lista de equipos</h3>
                <%if (GVEquipos.Rows.Count== 0)
                    {  %>
                        <h4>No hay regsitros ingresados aún</h4><hr /> <br />
                        <a href="AltaEquipo.aspx"><h4>Clic aquí</h4></a><h4>para empezar</h4>

                <%} %>
                <asp:GridView ID="GVEquipos" runat="server" CssClass="table table-bordered table-striped table-condensed" AutoGenerateColumns="false" OnRowEditing="GVEquipos_RowEditing" OnRowCancelingEdit="GVEquipos_RowCancelingEdit" OnRowUpdating="GVEquipos_RowUpdating" OnRowDeleting="GVEquipos_RowDeleting" DataKeyNames="Id" OnRowCommand="GVEquipos_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True">
                            <ItemStyle Width="50px" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Marca">
                            <ControlStyle Width="150px" />
                            <ItemStyle Width="150px" />
                            <ItemTemplate>
                                <asp:Label ID="lblMarca" runat="server" Text='<%#Eval("Marca") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList ID="DDLMarca" CssClass="form-control" runat="server"></asp:DropDownList>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Color" ControlStyle-Width="80px" ItemStyle-Width="100px" DataField="Color" />
                        <asp:BoundField HeaderText="Descripción" ControlStyle-Width="80px" ItemStyle-Width="100px" DataField="Descripcion" />
                        <asp:BoundField HeaderText="Especificaciones" ControlStyle-Width="80px" ItemStyle-Width="100px" DataField="Especificaciones" />
                        <asp:BoundField HeaderText="Serie" ControlStyle-Width="100px" ItemStyle-Width="100px" DataField="Serie" />
                        <asp:ImageField DataImageUrlField="Foto" HeaderText="Foto" ReadOnly="True">
                            <ControlStyle Height="50px" Width="60px" />
                            <ItemStyle Width="120px" />
                        </asp:ImageField>
                        <asp:CheckBoxField DataField="EnReparacion" Text="Está en reparación?" ReadOnly="true">
                            <ItemStyle Width="70px" />
                        </asp:CheckBoxField>

                        <asp:CommandField ShowDeleteButton="true" ButtonType="Button" ControlStyle-CssClass="btn btn-danger" ControlStyle-Width="80px" ItemStyle-Width="80px" />
                        <asp:CommandField ShowEditButton="true" ButtonType="Button" ControlStyle-CssClass="btn btn-info" ControlStyle-Width="70px" ItemStyle-Width="70px" />
                        <asp:ButtonField Text="Seleccionar" CommandName="Select" ButtonType="Button" ControlStyle-CssClass="btn btn-success" />
                    </Columns>
                </asp:GridView>
            </div>

        </div>
    </div>
</asp:Content>
