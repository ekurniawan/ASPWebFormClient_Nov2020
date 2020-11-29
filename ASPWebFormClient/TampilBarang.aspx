<%@ Page Title="Tampil Barang" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TampilBarang.aspx.cs" Inherits="ASPWebFormClient.TampilBarang" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:ObjectDataSource runat="server" ID="odsBarang" TypeName="ASPWebFormClient.Services.BarangServices"
        SelectMethod="GetAll" InsertMethod="InsertBarang" DeleteMethod="DeleteBarang" UpdateMethod="UpdateBarang">
        <DeleteParameters>
            <asp:Parameter Name="kodebarang" Type="String" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="kodebarang" Type="String" />
            <asp:Parameter Name="namabarang" Type="String" />
            <asp:Parameter Name="stok" Type="Int32" />
            <asp:Parameter Name="hargabeli" Type="Decimal" />
            <asp:Parameter Name="hargajual" Type="Decimal" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="namabarang" Type="String" />
            <asp:Parameter Name="stok" Type="Int32" />
            <asp:Parameter Name="hargabeli" Type="Decimal" />
            <asp:Parameter Name="hargajual" Type="Decimal" />
            <asp:Parameter Name="kodebarang" Type="String" />
        </UpdateParameters>
    </asp:ObjectDataSource>

    <div class="row">
        <h2>Tampil Barang</h2>
        <div class="col-md-8">
            <asp:GridView ID="gvBarang" CssClass="table table-striped" DataKeyNames="kodebarang"
                runat="server" AutoGenerateColumns="False" PageSize="5" DataSourceID="odsBarang" AllowPaging="True">
                <Columns>
                    <asp:BoundField DataField="kodebarang" HeaderText="Kode Barang" SortExpression="kodebarang" />
                    <asp:BoundField DataField="namabarang" HeaderText="Nama Barang" SortExpression="namabarang" />
                    <asp:BoundField DataField="stok" HeaderText="stok" SortExpression="stok" />
                    <asp:BoundField DataField="hargabeli" HeaderText="Harga Beli" SortExpression="hargabeli" />
                    <asp:BoundField DataField="hargajual" HeaderText="Harga Jual" SortExpression="hargajual" />
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                </Columns>
            </asp:GridView>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <label>Kode Barang :</label>
                <asp:TextBox runat="server" ID="txtKodeBarang" CssClass="form-control" />
            </div>
            <div class="form-group">
                <label>Nama Barang :</label>
                <asp:TextBox runat="server" ID="txtNamaBarang" CssClass="form-control" />
            </div>
            <div class="form-group">
                <label>Stok :</label>
                <asp:TextBox runat="server" ID="txtStok" TextMode="Number" CssClass="form-control" />
            </div>
            <div class="form-group">
                <label>Harga Beli :</label>
                <asp:TextBox runat="server" ID="txtHargaBeli" TextMode="Number" CssClass="form-control" />
            </div>
            <div class="form-group">
                <label>Harga Jual :</label>
                <asp:TextBox runat="server" ID="txtHargaJual" TextMode="Number" CssClass="form-control" />
            </div>
            <div class="form-group">
                <asp:Button Text="Insert" ID="btnInsert" OnClick="btnInsert_Click" CssClass="btn btn-primary" runat="server" />
            </div><br /><br />
            <asp:Literal ID="ltKeterangan" runat="server" />
        </div>
    </div>



</asp:Content>
