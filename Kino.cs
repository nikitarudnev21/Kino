using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KinoRudnev
{
    public partial class Kino : Form
    {
        int rowsCount = 10;
        string imgfolder = Application.StartupPath.Remove(Application.StartupPath.IndexOf("bin")).Replace(@"\", "/") + "Properties/img/";
        List<string> picInfo = new List<string>();
        int nameCounter = 0;
        public Kino()
        {
            PictureBox[,] pictures = new PictureBox[rowsCount, rowsCount];
            Label[] rows = new Label[rowsCount];
            Label[] columns = new Label[rowsCount*2];
            InitializeComponent();
            Load += (s, e) =>
            {
                for (int c = 0; c < rowsCount*2; c++)
                {
                    columns[c] = new Label();
                    columns[c].Text = Convert.ToString(c + 1);
                    columns[c].Size = new Size(50, 50);
                    columns[c].Font = new Font("Consolas", 20);
                    columns[c].Location = new Point(80 + c*50, 15);
                    if (c<9)
                    {
                        columns[c].Padding = new Padding(5,0,0,0);
                    }
                    Controls.Add(columns[c]);
                    columns[c].MouseEnter += (se, ee) =>
                    {
                        Label lbl = (Label)se;
                        foreach (var pbx in Controls.OfType<PictureBox>())
                        {
                            int result = lbl.Location.X - pbx.Location.X;
                            if (result == 10 || result == 8)
                            {
                                pbx.BackColor = Color.LightGray;
                                lbl.ForeColor = Color.Goldenrod;
                            }
                        }
                    };
                    columns[c].MouseLeave += (se, ee) =>
                    {
                        Label lbl = (Label)se;
                        foreach (var pbx in Controls.OfType<PictureBox>())
                        {
                            int result = lbl.Location.X - pbx.Location.X;
                            if (result == 10 || result == 8)
                            {
                                pbx.BackColor = Color.Transparent;
                                lbl.ForeColor = Color.Black;//
                            }
                        }
                    };
                }
                for (int i = 0; i < rowsCount; i++)
                {
                    rows[i] = new Label();
                    rows[i].Text = Convert.ToString(i + 1);
                    rows[i].Size = new Size(50, 50);
                    rows[i].Font = new Font("Consolas", 20);
                    rows[i].Location = new Point(10, i * 52+70);
                    Controls.Add(rows[i]);
                    rows[i].MouseEnter += (se, ee) =>
                    {
                         Label lbl = (Label)se;
                         foreach (var pbx in Controls.OfType<PictureBox>())
                         {
                             if (lbl.Location.Y-pbx.Location.Y==10)
                             {
                                 pbx.BackColor = Color.LightGray;
                                lbl.ForeColor = Color.Goldenrod;
                             }
                         }
                    };
                    rows[i].MouseLeave += (se, ee) => {
                        Label lbl = (Label)se;
                        foreach (var pbx in Controls.OfType<PictureBox>())
                        {
                            if (lbl.Location.Y - pbx.Location.Y == 10)
                            {
                                pbx.BackColor = Color.Transparent;
                                lbl.ForeColor = Color.Black;
                            }
                        }
                    };
                    for (int q = 70; q <= 576; q+=502)
                    {
                        for (int j = 0; j < rowsCount; j++)
                        {
                            PictureBox pb = new PictureBox();
                            pb.Size = new Size(50, 50);
                            pb.Location = new Point(j * 50 + q, i * 52 + 60);
                            pb.Padding = new Padding(7, 7, 0, 0);
                            pb.SizeMode = PictureBoxSizeMode.StretchImage;
                            pb.Image = Image.FromFile(imgfolder + "chairgreen.png");
                            pb.Name = $"PBox-{++nameCounter}";
                            Controls.Add(pb);
                            picInfo.Add($"false/{pb.Name}/");
                                pb.Click += (se, ee) =>
                                {
                                    string currentpic = picInfo.Find(p => p.Substring(p.IndexOf("/") + 1,
                                        p.LastIndexOf('/') - p.IndexOf('/') - 1) == pb.Name);
                                    if (currentpic.StartsWith("false"))
                                    {
                                        currentpic = currentpic.Replace("false", "true");
                                        pb.Image = Image.FromFile(imgfolder + "chairyellow.png");
                                    }
                                    else
                                    {
                                        currentpic = currentpic.Replace("true", "false");
                                        pb.Image = Image.FromFile(imgfolder + "chairgreen.png");
                                    }
                                    picInfo[picInfo.FindIndex(p => p.Substring(p.IndexOf("/") + 1,
                                        p.LastIndexOf('/') - p.IndexOf('/') - 1) == pb.Name)] = currentpic;
                                };
                            pb.MouseEnter += (se, ee) =>
                            {
                                pb.Cursor = Cursors.Hand;
                            };
                            pb.MouseLeave += (se, ee) =>
                            {
                                pb.Cursor = Cursors.Default;
                            };
                        }
                    }
                }
            };
        }
    }
}
