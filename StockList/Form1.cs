using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTOShared.DTOs;
using StockList.Endpoints;

namespace StockList
{
    public partial class Form1 : Form
    {

        private CategoryEndpoint CategoryEndpoint { get; }
        private ProductEndpoint ProductEndpoint { get; }

        public Form1()
        {
            InitializeComponent();
            ProductEndpoint = new ProductEndpoint();
            CategoryEndpoint = new CategoryEndpoint();
            Categories = new Dictionary<string, int>();

            dgProducts.AutoGenerateColumns = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //This is the easiest way to get a task to run in a WinForm app, maybe not best practises, but this app is for demo purposes really.
            _ = LoadCategories();
            _ = LoadProducts(-1);
        }


        private IDictionary<string, int> Categories { get;}

        private async Task LoadCategories()
        {

            var cats = await CategoryEndpoint.GetAll();

            lbCategories.Items.Clear();
            Categories.Clear();

            Categories.Add("Featured", -1);
            lbCategories.Items.Add("Featured");

            foreach (var item in cats)
            {
                Categories.Add(item.Name, item.Id);
                lbCategories.Items.Add(item.Name);
            }

        }


        private void lbCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbCategories.SelectedItem == null)
            {
                _ = LoadProducts(-1);
                return;
            }


            var catName = lbCategories.SelectedItem.ToString();

            var catId = Categories[catName];

            _ = LoadProducts(catId);
        }

        private async Task LoadProducts(int catId)
        {
            IEnumerable<ProductDisplay> items;

            if (catId == -1)
                items = await ProductEndpoint.GetFeatured();
            else
                items = await ProductEndpoint.GetAll(catId);

            dgProducts.DataSource = items;
        }

    }
}
