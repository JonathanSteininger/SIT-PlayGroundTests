using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebAPILibrary;

namespace FormHttpApi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            APIComms.InitialiseClient();
            Shown += Form1_Shown;
        }

        private async void Form1_Shown(object sender, EventArgs e)
        {
            await UpdateData();
        }

        //ImageBox
        //ImageLabel
        YesNoModel _YesOrNO { get; set; }
        private void Form1_Load(object sender, EventArgs e)
        {
            ImageLabel.Text = "Waiting";
            ImageLabel.Dock = DockStyle.Bottom;
            ImageLabel.TextAlign = ContentAlignment.MiddleCenter;
            //ImageBox.BorderStyle = BorderStyle.FixedSingle;
            ImageBox.Dock = DockStyle.Fill;
            ImageBox.DoubleClick += ImageBox_DoubleClick;

        }

        private async void ImageBox_DoubleClick(object sender, EventArgs e)
        {
            await UpdateData();
        }

        private async Task UpdateData()
        {
            this.Cursor = Cursors.WaitCursor;
            _YesOrNO = await APIComms.LoadYesNo();
            ImageBox.ImageLocation = _YesOrNO.Image;
            ImageBox.Refresh();
            ImageLabel.Text = _YesOrNO.Answre;
            this.Cursor = Cursors.Arrow;
        }

        private void ImageBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (_YesOrNO == null)
            {
                Font font = new Font("Arial", 30f);
                string text = "Waiting";
                float x = ImageBox.Width / 2 - (g.MeasureString(text, font).Width/2);
                float y = ImageBox.Height / 2 - (font.GetHeight(g) / 2);

                g.DrawString(text + "...", font, new SolidBrush(Color.Black), x, y);
            }
            else
            {
            }
        }
    }
}
