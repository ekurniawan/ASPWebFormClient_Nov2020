using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPWebFormClient
{
    public partial class TampilBarang : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            odsBarang.InsertParameters["kodebarang"].DefaultValue = txtKodeBarang.Text;
            odsBarang.InsertParameters["namabarang"].DefaultValue = txtNamaBarang.Text;
            odsBarang.InsertParameters["stok"].DefaultValue = txtStok.Text;
            odsBarang.InsertParameters["hargabeli"].DefaultValue = txtHargaBeli.Text;
            odsBarang.InsertParameters["hargajual"].DefaultValue = txtHargaJual.Text;
            try
            {
                odsBarang.Insert();
                ltKeterangan.Text = $"Data Barang {txtKodeBarang.Text} berhasil ditambah";
            }
            catch (Exception ex)
            {
                ltKeterangan.Text = $"Error: {ex.Message}";
            }
        }
    }
}