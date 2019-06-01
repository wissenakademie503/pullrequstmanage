using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UrolojiApp.Fonksiyonlar;

namespace UrolojiApp.Model
{
    public partial class frmHastaGiris : Form
    {
        UrolojiDbDataContext db = new UrolojiDbDataContext();
        Mesajlar m = new Mesajlar();
        private bool _edit = false;

        public frmHastaGiris()
        {
            InitializeComponent();
        }

        private void btnCollapse_Click(object sender, EventArgs e)
        {
            if(splitContainer1.Panel2Collapsed)
            {
                splitContainer1.Panel2Collapsed = false;
                btnCollapse.Text = "GİZLE";
            }
            else
            {
                splitContainer1.Panel2Collapsed = true;
                btnCollapse.Text = "GÖSTER";
            }
        }

        private void frmHastaGiris_Load(object sender, EventArgs e)
        {

        }
        void Temizle()
        {
            foreach (Control ct in tabPage1.Controls)
                if (ct is TextBox || ct is ComboBox) ct.Text = "";
        }
        void YeniKaydet()
        {
            bHastaBilgileri hb = new bHastaBilgileri();
            {
                hb.Hadi = txtHastaAdi.Text;
                hb.Hsoyadi = txtHastaSoyadi.Text;
                hb.OpTarihi = DateTime.Parse(dtpOpTarih.Text);
                hb.OpTuru = txtOpTuru.Text;
                hb.ProtokolNo = txtProtokolNo.Text;
                hb.Takip = int.Parse(txtTakip.Text);
                hb.Anah = int.Parse(txtAnah.Text);
            }
            db.bHastaBilgileris.InsertOnSubmit(hb);
            db.SubmitChanges();
            m.YeniKayit("Kayıt işlemi yapıldı");
            Temizle();
        }

        protected override void OnLoad(EventArgs e)
        {
            var btnoptur = new Button();
            btnoptur.Size = new Size(25, txtOpTuru.ClientSize.Height + 2);
            btnoptur.Location = new Point(txtOpTuru.ClientSize.Width - btnoptur.Width, -1);
            btnoptur.Cursor = Cursors.Default;
            txtOpTuru.Controls.Add(btnoptur);
            SendMessage(txtOpTuru.Handle, 0xd3, (IntPtr)2,(IntPtr)(btnoptur.Width << 16));
            btnoptur.Anchor = (AnchorStyles.Top | AnchorStyles.Right);

            base.OnLoad(e);

            btnoptur.Click += btnoptur_Click;
        }

        private void btnoptur_Click(object sender, EventArgs e)
        {
            frmOpTuru frm = new frmOpTuru();
            frm.ShowDialog();
        }

        [DllImport("user32.dll")]

        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            YeniKaydet();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
