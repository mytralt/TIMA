using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SE104.L23
{
    public partial class ThanhCong : Form
    {
        public ThanhCong()
        {
            InitializeComponent();
        }
        public ThanhCong(string text)
        {
            InitializeComponent();
            ThongBao.Text = text;
        }
    }
}
