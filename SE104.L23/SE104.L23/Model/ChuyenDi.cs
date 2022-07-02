using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE104.L23.Model
{
    class ChuyenDi
    {
        private string benxeden;
        private string benxedi;
        private string ngaygio;
        private string thoigiandichuyen;
        private string benxetg;
        private string tgdung;
        private int giave;
        private int hangve;
        private int ghetrong;
        public string BenXeDen
        {
            get { return this.benxeden; }
            set { this.benxeden = value; }
        }
        public string BenXeDi
        {
            get { return this.benxedi; }
            set { this.benxedi = value; }
        }
        public string NgayGio
        {
            get { return this.ngaygio; }
            set { this.ngaygio = value; }
        }
        public string ThoiGianDiChuyen
        {
            get { return this.thoigiandichuyen; }
            set { this.thoigiandichuyen = value; }
        }
        public string BenXeTG
        {
            get { return this.benxetg; }
            set { this.benxetg = value; }
        }
        public string TGDung
        {
            get { return this.tgdung; }
            set { this.tgdung = value; }
        }
        public int GiaVe
        {
            get { return this.giave; }
            set { this.giave = value; }
        }
        public int HangVe
        {
            get { return this.hangve; }
            set { this.hangve = value; }
        }
        public int GheTrong
        {
            get { return this.ghetrong; }
            set { this.ghetrong = value; }
        }
    }
}
