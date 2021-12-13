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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var Search = textBox1.Text;
            if (Search.Length != 0)
            {
                var provider = new RestApi();
                var info = provider.GetAboutBreed(Search);
                var repository = new Repository(provider);
                listView1.Items.Clear();

                if (info.Count != 0)
                {
                    foreach (var i in info)
                    {
                        var item = new ListViewItem(new[] { i.name });
                        listView1.Items.Add(item);
                    }
                    label9.Text = repository.CountResults(Search).ToString() + " results found:";
                }
                else MessageBox.Show("There's no cat breed with specified letters!");
            }
            else
            {
                label9.Text = "No results";
                listView1.Items.Clear();
                MessageBox.Show("Please enter something.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 main = new Form2();
            main.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                var provider = new RestApi();
                var SelectedItem = listView1.SelectedItems[0].Text;
                var info = provider.GetAboutBreed(SelectedItem);

                foreach (var i in info)
                {
                    textBox2.Text = i.name;
                    textBox3.Text = i.alt_names;
                    textBox4.Text = i.origin;
                    textBox5.Text = i.temperament;
                    textBox6.Text = i.description;
                }
            }
            else MessageBox.Show("Please, select full name of breed from the list.");
        }
    }
}
