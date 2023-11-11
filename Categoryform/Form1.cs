using dotNetLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Categoryform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            APIcomms.InitializeClient(APIcomms.TEMP_URL_BASE);
            Shown += Form1_Shown;
            Resize += (sender, args) => {
                listView1.Size = Size;
                listView1.TileSize = new Size(Size.Width, listView1.TileSize.Height);
                Populate();
            };
        }

        private async void Form1_Shown(object sender, EventArgs e)
        {
            await UpdateData();
        }

        private CategoryModelList _catagoryList;

        private async Task UpdateData()
        {
            Cursor = Cursors.WaitCursor;
            _catagoryList = await APIcomms.LoadCategories();
            Populate();
            Cursor = Cursors.Arrow;
        }
        private void Populate()
        {
            listView1.Items.Clear();
            listView1.Items.AddRange(_catagoryList.Categories.ConvertAll(item => new ListViewItem(item.ListString())).ToArray());

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.Dock = DockStyle.Fill;
            listView1.View = View.Tile;
            listView1.TileSize = new Size(listView1.Width, 70);
            
            //listView1.size
            listView1.Columns.Clear();
            listView1.Columns.Add("Catagory");
            listView1.Columns.Add("Description");
            
            
            BottomLabel.Dock = DockStyle.Bottom;
            BottomLabel.Text = "None";

        }
    }
    public static class CatagoryModelExtension
    {
        public static string[] ListString(this CategoryModel ct)
        {
            return new string[] {ct.strCategory.ToString(), ct.strCategoryDescription.ToString() };
        }
    }
}
