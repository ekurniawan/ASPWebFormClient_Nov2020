<%@ Page Title="Tampil Barang" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TampilBarang.aspx.cs" Inherits="ASPWebFormClient.TampilBarang" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:ObjectDataSource runat="server" ID="odsBarang" TypeName="ASPWebFormClient.Services.BarangServices"
        SelectMethod="GetAll">
    </asp:ObjectDataSource>

    <asp:GridView ID="gvBarang" CssClass="table table-striped" 
        runat="server" AutoGenerateColumns="False" DataSourceID="odsBarang">
        <Columns>
            <asp:BoundField DataField="kodebarang" HeaderText="Kode Barang" SortExpression="kodebarang" />
            <asp:BoundField DataField="namabarang" HeaderText="Nama Barang" SortExpression="namabarang" />
            <asp:BoundField DataField="stok" HeaderText="stok" SortExpression="stok" />
            <asp:BoundField DataField="hargabeli" HeaderText="Harga Beli" SortExpression="hargabeli" />
            <asp:BoundField DataField="hargajual" HeaderText="Harga Jual" SortExpression="hargajual" />
        </Columns>
    </asp:GridView>

</asp:Content>
