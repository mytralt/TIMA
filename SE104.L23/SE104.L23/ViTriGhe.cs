using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SE104.L23
{
    public partial class ViTriGhe : UserControl
    {
        public ViTriGhe()
        {
            InitializeComponent();
            
        }
        public void HienThi(List <string> temp)
        {
            if (temp.Contains("A01")) label1.BackColor = Color.FromArgb(78, 204, 163);
            if (temp.Contains("A02")) label2.BackColor = Color.FromArgb(78, 204, 163);
            if (temp.Contains("A03")) label3.BackColor = Color.FromArgb(78, 204, 163);
            if (temp.Contains("A04")) label4.BackColor = Color.FromArgb(78, 204, 163);
            if (temp.Contains("A05")) label5.BackColor = Color.FromArgb(78, 204, 163);
            if (temp.Contains("A06")) label6.BackColor = Color.FromArgb(78, 204, 163);
            if (temp.Contains("A07")) label7.BackColor = Color.FromArgb(78, 204, 163);
            if (temp.Contains("A08")) label8.BackColor = Color.FromArgb(78, 204, 163);
            if (temp.Contains("A09")) label9.BackColor = Color.FromArgb(78, 204, 163);
            if (temp.Contains("A10")) label10.BackColor = Color.FromArgb(78, 204, 163);
            if (temp.Contains("A11")) label11.BackColor = Color.FromArgb(78, 204, 163);
            if (temp.Contains("A12")) label12.BackColor = Color.FromArgb(78, 204, 163);
            if (temp.Contains("A13")) label13.BackColor = Color.FromArgb(78, 204, 163);
            if (temp.Contains("A14")) label14.BackColor = Color.FromArgb(78, 204, 163);
            if (temp.Contains("A15")) label15.BackColor = Color.FromArgb(78, 204, 163);
            if (temp.Contains("A16")) label16.BackColor = Color.FromArgb(78, 204, 163);
            if (temp.Contains("A17")) label17.BackColor = Color.FromArgb(78, 204, 163);
            if (temp.Contains("A18")) label18.BackColor = Color.FromArgb(78, 204, 163);
            if (temp.Contains("A19")) label19.BackColor = Color.FromArgb(78, 204, 163);
            if (temp.Contains("A20")) label20.BackColor = Color.FromArgb(78, 204, 163);
            if (temp.Contains("A21")) label21.BackColor = Color.FromArgb(78, 204, 163);
            if (temp.Contains("A22")) label22.BackColor = Color.FromArgb(78, 204, 163);
            if (temp.Contains("A23")) label23.BackColor = Color.FromArgb(78, 204, 163);
            if (temp.Contains("A24")) label24.BackColor = Color.FromArgb(78, 204, 163);
            if (temp.Contains("A25")) label25.BackColor = Color.FromArgb(78, 204, 163);
            if (temp.Contains("A26")) label26.BackColor = Color.FromArgb(78, 204, 163);
            if (temp.Contains("A27")) label27.BackColor = Color.FromArgb(78, 204, 163);
            if (temp.Contains("A28")) label28.BackColor = Color.FromArgb(78, 204, 163);
            if (temp.Contains("A29")) label29.BackColor = Color.FromArgb(78, 204, 163);
            if (temp.Contains("A30")) label30.BackColor = Color.FromArgb(78, 204, 163);
            if (temp.Contains("A31")) label31.BackColor = Color.FromArgb(78, 204, 163);
            if (temp.Contains("A32")) label32.BackColor = Color.FromArgb(78, 204, 163);
            if (temp.Contains("A33")) label33.BackColor = Color.FromArgb(78, 204, 163);
            if (temp.Contains("A34")) label34.BackColor = Color.FromArgb(78, 204, 163);
            if (temp.Contains("A35")) label35.BackColor = Color.FromArgb(78, 204, 163);
            if (temp.Contains("A36")) label36.BackColor = Color.FromArgb(78, 204, 163);
            if (temp.Contains("A37")) label37.BackColor = Color.FromArgb(78, 204, 163);
            if (temp.Contains("A38")) label38.BackColor = Color.FromArgb(78, 204, 163);
            if (temp.Contains("A39")) label39.BackColor = Color.FromArgb(78, 204, 163);
            if (temp.Contains("A40")) label40.BackColor = Color.FromArgb(78, 204, 163);
            if (temp.Contains("A41")) label41.BackColor = Color.FromArgb(78, 204, 163);
            if (temp.Contains("A42")) label42.BackColor = Color.FromArgb(78, 204, 163);
            if (temp.Contains("A43")) label43.BackColor = Color.FromArgb(78, 204, 163);
            if (temp.Contains("A44")) label44.BackColor = Color.FromArgb(78, 204, 163);
            if (temp.Contains("A45")) label45.BackColor = Color.FromArgb(78, 204, 163);
        }
        public void Xoa()
        {
            label1.BackColor = Color.FromArgb(57, 62, 70);
            label2.BackColor = Color.FromArgb(57, 62, 70);
            label3.BackColor = Color.FromArgb(57, 62, 70);
            label4.BackColor = Color.FromArgb(57, 62, 70);
            label5.BackColor = Color.FromArgb(57, 62, 70);
            label6.BackColor = Color.FromArgb(57, 62, 70);
            label7.BackColor = Color.FromArgb(57, 62, 70);
            label8.BackColor = Color.FromArgb(57, 62, 70);
            label9.BackColor = Color.FromArgb(57, 62, 70);
            label10.BackColor = Color.FromArgb(57, 62, 70);
            label11.BackColor = Color.FromArgb(57, 62, 70);
            label12.BackColor = Color.FromArgb(57, 62, 70);
            label13.BackColor = Color.FromArgb(57, 62, 70);
            label14.BackColor = Color.FromArgb(57, 62, 70);
            label15.BackColor = Color.FromArgb(57, 62, 70);
            label16.BackColor = Color.FromArgb(57, 62, 70);
            label17.BackColor = Color.FromArgb(57, 62, 70);
            label18.BackColor = Color.FromArgb(57, 62, 70);
            label19.BackColor = Color.FromArgb(57, 62, 70);
            label20.BackColor = Color.FromArgb(57, 62, 70);
            label21.BackColor = Color.FromArgb(57, 62, 70);
            label22.BackColor = Color.FromArgb(57, 62, 70);
            label23.BackColor = Color.FromArgb(57, 62, 70);
            label24.BackColor = Color.FromArgb(57, 62, 70);
            label25.BackColor = Color.FromArgb(57, 62, 70);
            label26.BackColor = Color.FromArgb(57, 62, 70);
            label27.BackColor = Color.FromArgb(57, 62, 70);
            label28.BackColor = Color.FromArgb(57, 62, 70);
            label29.BackColor = Color.FromArgb(57, 62, 70);
            label30.BackColor = Color.FromArgb(57, 62, 70);
            label31.BackColor = Color.FromArgb(57, 62, 70);
            label32.BackColor = Color.FromArgb(57, 62, 70);
            label33.BackColor = Color.FromArgb(57, 62, 70);
            label34.BackColor = Color.FromArgb(57, 62, 70);
            label35.BackColor = Color.FromArgb(57, 62, 70);
            label36.BackColor = Color.FromArgb(57, 62, 70);
            label37.BackColor = Color.FromArgb(57, 62, 70);
            label38.BackColor = Color.FromArgb(57, 62, 70);
            label39.BackColor = Color.FromArgb(57, 62, 70);
            label40.BackColor = Color.FromArgb(57, 62, 70);
            label41.BackColor = Color.FromArgb(57, 62, 70);
            label42.BackColor = Color.FromArgb(57, 62, 70);
            label43.BackColor = Color.FromArgb(57, 62, 70);
            label44.BackColor = Color.FromArgb(57, 62, 70);
            label45.BackColor = Color.FromArgb(57, 62, 70);

        }
        private void label15__Click(object sender, EventArgs e)
        {

        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void ViTriGhe_Load(object sender, EventArgs e)
        {

        }
    }
}
