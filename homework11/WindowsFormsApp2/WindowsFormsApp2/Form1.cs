using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Order
{
    public partial class Form1 : Form
    {
        OrderService orderService;

        List<Order> showList;
        public Form1()
        {


            orderService = new OrderService();
            InitializeComponent();
            this.bindingSource1.ResetBindings(false);
            showList = new List<Order>();
            this.bindingSource1.DataSource = showList;
            bindingSource1.ResetBindings(false);
        }


        private void createButton_Click(object sender, EventArgs e)
        {
            Order order = new Order();
            new Form2(ref orderService).ShowDialog();
            bindingSource1.ResetBindings(false);
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            int number = Int32.Parse(orderView.CurrentRow.Cells[0].Value.ToString());
            if (MessageBox.Show("你确定要删除" + number + "号订单吗？", "删除确认", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                orderService.DeleteOrder(number);
                bindingSource1.ResetBindings(false);
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            int choice = searchComboBox.SelectedIndex;
            String input = searchTextBox.Text;
            switch (choice)
            {
                case 0:
                    showList = orderService.SearchByID(Int32.Parse(input));
                    this.bindingSource1.DataSource = showList;
                    bindingSource1.ResetBindings(false);
                    break;
                case 1:
                    showList = orderService.SearchByCustomer(input);
                    this.bindingSource1.DataSource = showList;
                    bindingSource1.ResetBindings(false);
                    break;
                case 2:
                    showList = orderService.SearchByGoods(input);
                    this.bindingSource1.DataSource = showList;
                    bindingSource1.ResetBindings(false);
                    break;
            }
        }

        private void ShowAllButton_Click(object sender, EventArgs e)
        {
            showList = orderService.SearchAll();
            this.bindingSource1.DataSource = showList;
            bindingSource1.ResetBindings(false);
        }

        private void inputButton_Click(object sender, EventArgs e)
        {
            int number = Int32.Parse(orderView.CurrentRow.Cells[0].Value.ToString());

            bindingSource2.DataSource = orderService.SearchByID(number)[0].GoodsList;
            bindingSource1.ResetBindings(false);


        }

        private void outpuButton_Click(object sender, EventArgs e)
        {
            String path = null;
            saveFileDialog1.InitialDirectory = "E:\\";
            saveFileDialog1.RestoreDirectory = false;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = System.IO.Path.GetFullPath(saveFileDialog1.FileName);
            }/*
            orderService.Export(path);
            showList = orderService.orderList;*/
            this.bindingSource1.DataSource = showList;


        }

        private void orderView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void orderView_SelectionChanged(object sender, EventArgs e)
        {

        }
    }
}