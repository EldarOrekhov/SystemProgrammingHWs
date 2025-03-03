using System;
using System.Net;
using System.Numerics;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            productsList.Items.Clear();
            Thread thread = new Thread(() =>
            {
                var products = LoadProducts();

                Invoke((Action)(() =>
                {
                    foreach (var product in products)
                    {
                        productsList.Items.Add(product.Name);
                    }
                }));
            });
            thread.Start();
        }
        private List<Product> LoadProducts()
        {
            using (var db = new ApplicationContext())
            {
                return db.Products.ToList();
            }
        }
    }
}

