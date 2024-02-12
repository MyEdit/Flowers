using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PriceManager;

namespace Flowers
{
    public partial class MainForm : Form
    {
        int UserID;
        public MainForm(int userID)
        {
            InitializeComponent();
            UserID = userID;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            loadDataGrids();
        }

        private void loadDataGrids()
        {
            dataGridView1.Rows.Clear();
            List<string[]> Response = DataBaseWorker.ExecuteQuery("SELECT ProductArticle, ProductName, ProductCategory, ProductManufacturer, ProductCost, ProductDiscount, ProductQuality, TheSupplier  FROM Products", 8);
            if (Response != null)
            {
                foreach (string[] ResponseItem in Response)
                {
                    dataGridView1.Rows.Add(ResponseItem[0], ResponseItem[1], ResponseItem[2], ResponseItem[3], ResponseItem[4], ResponseItem[5], ResponseItem[6], ResponseItem[7]);
                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            double price = Convert.ToDouble(dataGridView1.SelectedRows[0].Cells[4].Value);
            double discount = Convert.ToDouble(dataGridView1.SelectedRows[0].Cells[5].Value);
            double totalPrice = PriceCalculator.getPriceWithDiscount(price, discount); //Обращение к моей библиотеке

            MessageBox.Show("Цена товара с учетом скидки: " + totalPrice, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
