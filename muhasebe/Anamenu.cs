using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace muhasebe
{
    public partial class Anamenu : Form
    {
        public Anamenu()
        {
            InitializeComponent();
        }

        private void firmalarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 yeni = new Form1();
            yeni.MdiParent= this;   
            yeni.Show();

        }

        private void kategorilerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Urunler urn = new Urunler();
            urn.MdiParent = this;
            urn.Show();
        }
    }
}
