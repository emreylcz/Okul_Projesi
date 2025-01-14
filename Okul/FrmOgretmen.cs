﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Okul
{
    public partial class FrmOgretmen : Form
    {
        public FrmOgretmen()
        {
            InitializeComponent();
        }

        private void BtnKulupIslemleri_Click(object sender, EventArgs e)
        {
            FrmKulup fr = new FrmKulup();
            fr.Show();
        }

        private void BtnDersIslemleri_Click(object sender, EventArgs e)
        {
            FrmDersler fr = new FrmDersler();
            fr.Show();
        }

        private void BtnOgrenciIslemleri_Click(object sender, EventArgs e)
        {
            FrmOgrenci fr = new FrmOgrenci();
            fr.Show();
        }

        private void BtnSinavNotlari_Click(object sender, EventArgs e)
        {
            FrmSinavNotlari fr = new FrmSinavNotlari();
            fr.Show();
        }
    }
}
