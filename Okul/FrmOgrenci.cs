using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Okul
{
    public partial class FrmOgrenci : Form
    {
        public FrmOgrenci()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-3FED8I7\SQLEXPRESS;Initial Catalog=OkulProje;Integrated Security=True;");

        DataSet1TableAdapters.DataTable1TableAdapter ds = new DataSet1TableAdapters.DataTable1TableAdapter();

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void FrmOgrenci_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciListesi();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM Tbl_Kulupler", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CmbKulup.DisplayMember = "KulupAd";
            CmbKulup.ValueMember = "KulupID";
            CmbKulup.DataSource = dt;
            baglanti.Close();
        }

        string cinsiyet = "";

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            ds.OgrenciEkle(TxtOgrenciAdi.Text, TxtOgrenciSoyadi.Text, byte.Parse(CmbKulup.SelectedValue.ToString()), cinsiyet); // byte veri tip olduğundan dolayı böyle yapılmalı
            MessageBox.Show("Öğrenci Ekleme Yapıldı.");
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciListesi();
        }

        private void CmbKulup_SelectedIndexChanged(object sender, EventArgs e)
        {
            TxtID.Text = CmbKulup.SelectedValue.ToString();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            ds.OgrenciSil(int.Parse(TxtID.Text));
            MessageBox.Show("Öğrenci Silindi.", "Bilgi"); // Tablolar birbirine ilişkili olduğundan dolayı silme yapılmaz onun yarın aktif veya pasif kullanılmalı
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtOgrenciAdi.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            TxtOgrenciSoyadi.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            CmbKulup.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();

            if (dataGridView1.CurrentRow.Cells[4].Value.Equals("Kız"))
            {
                RdoKiz.Checked = true;
            }

            if (dataGridView1.CurrentRow.Cells[4].Value.Equals("Erkek"))
            {
                RdoErkek.Checked = true;
            }


        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            ds.OgrenciGuncelle(TxtOgrenciAdi.Text, TxtOgrenciSoyadi.Text, byte.Parse(CmbKulup.SelectedValue.ToString()), cinsiyet, int.Parse(TxtID.Text));
            MessageBox.Show("Öğrenci Biglileri Güncellendi");
        }

        private void RdoKiz_CheckedChanged(object sender, EventArgs e)
        {
            if (RdoKiz.Checked == true)
            {
                cinsiyet = "Kız";
            }
        }

        private void RdoErkek_CheckedChanged(object sender, EventArgs e)
        {
            if (RdoErkek.Checked == true)
            {
                cinsiyet = "Erkek";
            }
        }

        private void BtnAra_Click(object sender, EventArgs e)
        {
          dataGridView1.DataSource = ds.OgrenciGetir(TxtAra.Text);
        }
    }
}
