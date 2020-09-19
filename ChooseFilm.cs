using Microsoft.VisualBasic;
using PdfSharp.Drawing;
using PdfSharp.Drawing.BarCodes;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
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
            bool filmChoosen = false;
            InitializeComponent();
            Load += (s, e) =>
            {
                /*   SqlConnection sqlCon = new SqlConnection($@"Data Source=(LocalDB)\MSSQLLocalDB;
                   AttachDbFilename={Paths.DB_PATH};
                   Integrated Security=True;Connect Timeout=30");
                   sqlCon.Open();
                   SqlCommand sqlCommand = new SqlCommand("SELECT film from Films", sqlCon);
                   SqlDataReader dataReader = sqlCommand.ExecuteReader();
                   string result = "";
                   while (dataReader.Read())
                   {
                       result += Convert.ToString(dataReader["film"]);
                       MessageBox.Show(Convert.ToString(dataReader["film"]));
                   }
                   sqlCon.Close();
                   MessageBox.Show(result);*/
                PDF.CheckFolders();
                void SwitchrowsCount(PictureBox pb)
                {
                    if (pb.Tag.ToString().ToLower().Contains("TENET".ToLower())) rowsCount = 10;
                    else if (pb.Tag.ToString().ToLower().Contains("Furious 7".ToLower())) rowsCount = 8;
                    else if (pb.Tag.ToString().ToLower().Contains("Deadpool 2".ToLower())) rowsCount = 9;
                    else if (pb.Tag.ToString().ToLower().Contains("Terminator Gynesis".ToLower())) rowsCount = 7;
                }
                PictureBox pbm = new PictureBox()
                {
                    Enabled = false,
                    Location = new Point(0, 0),
                    Size = new Size(Size.Width, Size.Height),
                    Image = Image.FromFile($"{Paths.IMG_FOLDER}cinemabg.jpg"),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Name = "pbmain"
                };
                pbm.SendToBack();
                Controls.Add(pbm);
                List<PictureBox> pictures = new List<PictureBox>();
                foreach (PictureBox pb in Controls.OfType<PictureBox>().Where(p => p.Name!="pbmain"))
                {
                    pictures.Add(pb);
                    pb.Click += (se, ee) =>
                    {
                        pictures.ForEach(p => {
                            p.BorderStyle = BorderStyle.None;
                            filmChoosen = false;
                        });
                        pb.BorderStyle = BorderStyle.FixedSingle;
                        SwitchrowsCount(pb);
                        filmChoosen = true;
                    };
                }
                btnChoosePlace.Click += (se, ee) =>
                {
                    if (filmChoosen)
                    {
                        new FilmInfo(pictures.Find(f => f.BorderStyle == BorderStyle.FixedSingle).Tag.ToString(), rowsCount).Show();
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
