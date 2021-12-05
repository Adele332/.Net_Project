using CatApp.DataProvider;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CatApp
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            var provider = new RestApi();
            var listViewItem = provider.GetCategories();
            foreach (var i in listViewItem)
            {
                var item = new ListViewItem(new[] { i.id, i.name });
                listView1.Items.Add(item);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                var provider = new RestApi();
                var SelectedItem = listView1.SelectedItems[0].Text;
                var image = provider.GetImage(SelectedItem);

                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                foreach (var i in image)
                {
                    pictureBox1.ImageLocation = i.url;
                }
                
            }
            else MessageBox.Show("Please, select category from the list");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 main = new Form1();
            main.ShowDialog();
            this.Close();
        }
    }
}
