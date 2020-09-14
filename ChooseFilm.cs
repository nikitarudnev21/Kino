using Microsoft.VisualBasic;
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
    public partial class numericPlaces : Form
    {
        public numericPlaces()
        {
            int rowsCount = 0;
            int placesCount = 0;
            bool filmChoosen = false;
            string imgfolder = Application.StartupPath.Remove(Application.StartupPath.IndexOf("bin")).Replace(@"\", "/") + "Properties/img/";
            InitializeComponent();
            Load += (s, e) =>
            {
                void SwitchrowsCount(PictureBox pb)
                {
                    if (pb.Name.ToLower().Contains("Tenet".ToLower()))
                    {
                        rowsCount = 10;
                    }
                    else if (pb.Name.ToLower().Contains("FastFur".ToLower()))
                    {
                        rowsCount = 8;
                    }
                    else if (pb.Name.ToLower().Contains("deadpool".ToLower()))
                    {
                        rowsCount = 9;
                    }
                    else if (pb.Name.ToLower().Contains("terminator5".ToLower()))
                    {
                        rowsCount = 7;
                    }
                }
                CinemaActions cinema = new CinemaActions(imgfolder);
                PictureBox pbm = new PictureBox();
                pbm.Location = new Point(0, 0);
                pbm.Size = new Size(Size.Width, Size.Height);
                cinema.SetBackImg(pbm);
                pbm.SizeMode = PictureBoxSizeMode.StretchImage;
                pbm.Enabled = false;
                pbm.Name = "pbmain";
                pbm.SendToBack();
                Controls.Add(pbm);
                List<Label> labels = new List<Label>();
                labels.AddRange(Controls.OfType<Label>());
                labels.ForEach(l => l.Visible = false);
                List<PictureBox> pictures = new List<PictureBox>();
                foreach (PictureBox pb in Controls.OfType<PictureBox>().Where(p =>p.Name!="pbmain"))
                {
                    pictures.Add(pb);
                      foreach (Label lbl in labels)
                      {
                              if (lbl.Tag.ToString().ToLower() == pb.Tag.ToString().ToLower())
                              {
                                  lbl.Visible = true;
                                  lbl.MouseEnter += (se, ee) =>
                                  {
                                      lbl.Cursor = Cursors.Hand;
                                  };
                                  lbl.MouseLeave += (se, ee) =>
                                  {
                                      lbl.Cursor = Cursors.Default;
                                  };
                                  lbl.Click += (se, ee) =>
                                  {
                                    SwitchrowsCount(pb);
                                    Hide();
                                    new FilmInfo(lbl.Tag.ToString(), rowsCount).Show();
                                  };
                              }
                      }
                   /* pb.MouseEnter += (se, ee) =>
                    {
                        labels.Find(l => pb.Tag.ToString().ToLower() == l.Tag.ToString().ToLower()).Visible = true;
                    };
                    pb.MouseLeave += (se, ee) =>
                    {
                        labels.Find(l => pb.Tag.ToString().ToLower() == l.Tag.ToString().ToLower()).Visible = false;
                    };*/
                    pb.Click += (se, ee) =>
                    {
                        pictures.ForEach(p => {
                            p.BorderStyle = BorderStyle.None;
                            filmChoosen = false;
                        });
                        pb.Focus();
                        pb.BorderStyle = BorderStyle.FixedSingle;
                        pb.Tag+= "choosenFilm";
                        SwitchrowsCount(pb);
                        filmChoosen = true;
                        PlacesNumeric.Maximum = rowsCount*20;
                    };
                }
                PlacesNumeric.KeyDown += (se, ee) =>
                {
                    ee.SuppressKeyPress = true;
                    return;
                };
                PlacesNumeric.ValueChanged += (se, ee) =>
                {
                    placesCount = (int)PlacesNumeric.Value;
                };
                btnChoosePlace.Click += (se, ee) =>
                {
                    if (filmChoosen)
                    {
                        new Kino(rowsCount, placesCount).Show();
                        Hide();
                    }
                    else
                    {
                        MessageBox.Show("Выберите фильм");
                    }
                };
            };
        }
    }
}
