using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KinoRudnev
{
    public partial class FilmInfo : Form
    {
        public FilmInfo(string filmName, int rowsCount)
        {
            string imgfolder = Application.StartupPath.Remove(Application.StartupPath.IndexOf("bin")).Replace(@"\", "/") + "Properties/img/";
            InitializeComponent();
            CinemaActions cinema = new CinemaActions(imgfolder);
            PictureBox pbm = new PictureBox();
            pbm.Location = new Point(0, 0);
            pbm.Size = new Size(Size.Width, Size.Height);
            pbm.Image = Image.FromFile(imgfolder+"curtains2.png");
            pbm.SizeMode = PictureBoxSizeMode.StretchImage;
            pbm.Enabled = false;
            pbm.Name = "pbmain";
            pbm.SendToBack();
            Controls.Add(pbm);
            switch (filmName)
            {
                case "tenet":
                    filmName = "TENET";
                    break;
                case "FastFur":
                    filmName = "Fast And Furiuos";
                    break;
                case "terminator5":
                    filmName = "Terminator Gynesis";
                    break;
                case "deadpool2":
                    filmName = "Deadpool 2";
                    break;
            }
            lblFilm.Text = "Фильм:" + filmName;
            lblPlacesCount.Text = "Количество мест:" + (rowsCount * 20);
        }
    }
}
