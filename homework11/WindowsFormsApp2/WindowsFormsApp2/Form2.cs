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
    public partial class Form2 : Form
    {
        Order order;

        OrderService orderService;

        List<OrderItem> orderItems;


        public Form2(ref OrderService orderService)
        {
            InitializeComponent();
            this.orderService = orderService;
            orderItems = new List<OrderItem>();
            order = new Order();
            bindingSource1.DataSource = orderItems;
            order.OrderId = orderService.CreateId();
            order.GoodsList = orderItems;
            bindingSource1.ResetBindings(false);
        }


        private void createButton_Click(object sender, EventArgs e)
        {
            String name = inputBox.Text;
            order.Customer = name;
            order.GoodsList = orderItems;
            orderService.AddOrder(order);
            this.Close();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            bindingSource1.DataSource = orderItems;
            OrderItem orderItem = new OrderItem("请输入", 0, 0, order.OrderId);
            orderItems.Add(orderItem);
            order.GoodsList = orderItems;
            bindingSource1.ResetBindings(false);
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
