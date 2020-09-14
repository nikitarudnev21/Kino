using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace KinoRudnev
{
    public partial class Kino : Form
    {
        public Kino(int rowsCount, int placesCount)
        {
            InitializeComponent();
            Load += (s, e) =>
            {
                List<string> picInfo = new List<string>();
                Random rnd = new Random();
                List<PictureBox> boxes = new List<PictureBox>();
                int nameCounter = 0;
                PictureBox[,] pictures = new PictureBox[rowsCount, rowsCount];
                Label[] rows = new Label[rowsCount];
                Label[] columns = new Label[rowsCount * 2];
                CinemaActions cinema = new CinemaActions(Application.StartupPath.Remove(Application.StartupPath.IndexOf("bin")).Replace(@"\", "/") + "Properties/img/"
                , rowsCount, picInfo,
                Application.StartupPath.Remove(Application.StartupPath.IndexOf("bin")).Replace(@"\", "/") + "Properties/tickets/"
                );
                for (int c = 0; c < rowsCount * 2; c++)
                {
                        columns[c] = new Label();
                        columns[c].Text = Convert.ToString(c + 1);
                        columns[c].Size = new Size(50, 50);
                        columns[c].Font = new Font("Consolas", 20, FontStyle.Bold);
                        columns[c].Location = new Point(80 + c * 50, 15);
                        columns[c].Name = $"Column{c + 1}";
                        if (c < 9)
                        {
                            columns[c].Padding = new Padding(5, 0, 0, 0);
                        }
                        Controls.Add(columns[c]);
                        cinema.LabelEvents(this,columns[c], cinema);
                }
                for (int i = 0; i < rowsCount; i++)
                {
                        rows[i] = new Label();
                        rows[i].Text = Convert.ToString(i + 1);
                        rows[i].Size = new Size(50, 50);
                        rows[i].Font = new Font("Consolas", 20, FontStyle.Bold);
                        rows[i].Location = new Point(10, i * 52 + 70);
                        rows[i].Name = $"Row{i + 1}";
                        Controls.Add(rows[i]);
                        cinema.LabelEvents(this, rows[i], cinema, "row");
                    cinema.columns = columns;
                    cinema.rows = rows;
                    for (int j = 0; j < rowsCount *2; j++)
                    {
                            PictureBox pb = new PictureBox();
                            pb.Size = new Size(50, 50);
                            pb.Location = new Point(j * 50+70, i * 52 + 60);
                            pb.Padding = new Padding(7, 7, 0, 0);
                            pb.SizeMode = PictureBoxSizeMode.StretchImage;
                            cinema.SetImg(pb);
                            pb.Name = $"PBox-{++nameCounter}";
                            Controls.Add(pb);
                            picInfo.Add($"false/{pb.Name}/");
                            boxes.Add(pb);
                            pb.Click += (se, ee) =>
                            {
                               cinema.getPlaceStatus(cinema, pb);
                            };
                            pb.MouseEnter += (se, ee) =>
                            {
                                pb.Cursor = Cursors.Hand;
                                lblPlace.Visible = true;
                                string[] rightPlace = cinema.getPlace(pb);
                                string column = rightPlace[0].Remove(rightPlace[0].IndexOf("Column"), 6);
                                string row = rightPlace[1].Remove(rightPlace[1].IndexOf("Row"), 3);
                                lblPlace.Text = $"Ряд: { row }, Место: { column }";
                            };
                            pb.MouseLeave += (se, ee) =>
                            {
                                pb.Cursor = Cursors.Default;
                                lblPlace.Visible = false;
                                lblPlace.Text = "";
                            };
                    }
                }
                btnOrder.Click += (se, ee) =>
                {
                    List<string> allPlaces = picInfo.FindAll(f => f.Contains("Column") && f.Contains("Row"));
                    if (allPlaces.Count != 0)
                    {
                        File.AppendAllLines(cinema.ticketsfolder + "tickets.txt", allPlaces);
                        foreach (PictureBox pb in Controls.OfType<PictureBox>())
                        {
                            if (allPlaces.ToList().Any(t => cinema.rightPic(t, pb)))
                            {
                                string userMail = Interaction.InputBox("Email", "Введите email", "", 50, 50);
                                cinema.OrderPlace(pb);
                                MailMessage mail = new MailMessage();
                                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
                                mail.From = new MailAddress("styx1338@gmail.com");
                                mail.To.Add(userMail);
                                mail.Subject = "Билет";
                                mail.Body = "ряд место инфа";
                                smtpClient.Port = 587;
                                smtpClient.Send(mail);
                                string currentpic = picInfo.Find(p => cinema.rightPic(p, pb));
                                picInfo[picInfo.FindIndex(p => cinema.rightPic(p, pb))] = currentpic.Remove(currentpic.IndexOf("place="));
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Выберите места");
                    }
                };
                List<string> places = File.ReadAllLines(cinema.ticketsfolder + "tickets.txt", Encoding.UTF8).ToList();
                foreach (PictureBox pb in Controls.OfType<PictureBox>())
                {
                        if (places.Any(pl => pl.Contains("Column") && pl.Contains("Row") && cinema.rightPic(pl,pb)))
                        {
                            cinema.OrderPlace(pb);
                            boxes.Remove(pb);
                        }
                }
                for (int i = 0; i < placesCount; i++)
                {
                    cinema.getPlaceStatus(cinema, boxes[rnd.Next(boxes.Count)]);
                }
            };
        }
    }
}
