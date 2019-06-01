using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrolojiApp.Fonksiyonlar
{
    class Formlar
    {
        public void HastaGiris()
        {
            Model.frmHastaGiris frm = new Model.frmHastaGiris();
            frm.MdiParent = Form.ActiveForm;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }
    }
}
