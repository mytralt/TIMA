﻿using System;
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
    public partial class ThatBai : Form
    {
        public ThatBai()
        {
            InitializeComponent();
        }
        public ThatBai(string text)
        {
            InitializeComponent();
            ThongBao.Text = text;
        }
    }
}
