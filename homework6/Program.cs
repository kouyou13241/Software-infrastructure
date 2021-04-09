using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Xml.Serialization;
using System.Text;
using System.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderService orderService = new OrderService();
            Customer customer = new Customer("test");
            Goods goods = new Goods(120, "goods");
            orderService.createOrder(customer, goods, 10);
            List<Order> orders = orderService.orderByCondition((orders) =>
            {
                var orderList = from o in orders
                                orderby o.getOrderDetail().getMoney()
                                select o;
                return orderList.ToList();
            });
        }

        [Serializable]
        class Order
        {
            private int id;

            private OrderDetail orderDetail;

            public override string ToString()
            {
                return this.id + this.orderDetail.ToString();
            }
            public void setId(int id)
            {
                this.id = id;
            }

            public int getId()
            {
                return this.id;
            }

            public void setOrderDetail(OrderDetail orderDetail)
            {
                this.orderDetail = orderDetail;
            }

            public OrderDetail getOrderDetail()
            {
                return this.orderDetail;
            }

            public override bool Equals(object obj)
            {
                Order order = obj as Order;
                return order.getId() == this.id && order.getOrderDetail().Equals(this.orderDetail);
            }
        }

        [Serializable]
        class OrderDetail
        {
            private string name;
            private Customer customer;
            private Goods goods;
            private int money;

            public override bool Equals(object obj)
            {
                OrderDetail orderDetail = obj as OrderDetail;
                return orderDetail.getName().Equals(this.name) && this.getCustomer().Equals(this.customer) && orderDetail.getGoods().Equals(this.goods) && orderDetail.getMoney() == money;
            }

            public override string ToString()
            {
                return this.name + this.customer.ToString() + this.goods.ToString() + this.money;
            }
            public void setMoney(int money)
            {
                this.money = money;
            }

            public int getMoney()
            {
                return this.money;
            }

            public void setName(string name)
            {
                this.name = name;
            }

            public string getName()
            {
                return this.name;
            }

            public void setCustomer(Customer customer)
            {
                this.customer = customer;
            }

            public Customer getCustomer()
            {
                return this.customer;
            }

            public void setGoods(Goods goods)
            {
                this.goods = goods;
            }

            public Goods getGoods()
            {
                return this.goods;
            }
        }

        [Serializable]
        class Customer
        {
            private string name;

            public override bool Equals(object obj)
            {
                Customer customer = obj as Customer;
                return customer.getName().Equals(this.name);
            }

            public override string ToString()
            {
                return this.name;
            }

            public void setName(string name)
            {
                this.name = name;
            }

            public string getName()
            {
                return this.name;
            }

            public Customer(string name)
            {
                this.name = name;
            }

            public Customer()
            {

            }
        }

        [Serializable]
        class Goods
        {
            private int price;
            private string name;

            public Goods()
            {

            }

            public Goods(int price, string name)
            {
                this.price = price;
                this.name = name;
            }

            public override bool Equals(object obj)
            {
                Goods goods = obj as Goods;
                return goods.getPrice() == this.price && goods.getName().Equals(this.name);
            }

            public override string ToString()
            {
                return this.price + this.name;
            }

            public void setPrice(int price)
            {
                this.price = price;
            }

            public int getPrice()
            {
                return this.price;
            }

            public string getName()
            {
                return this.name;
            }

            public void setName(string name)
            {
                this.name = name;
            }
        }

        class OrderService
        {
            public List<Order> orders = new List<Order>();

            public static int orderNum = 0;

            public void createOrder(Customer customer, Goods goods, int sum)
            {
                OrderDetail orderDetail = new OrderDetail();
                orderDetail.setCustomer(customer);
                orderDetail.setGoods(goods);
                orderDetail.setName(customer.getName() + goods.getName() + orderNum);
                orderDetail.setMoney(goods.getPrice() * sum);
                Order order = new Order();
                order.setId(++orderNum);
                order.setOrderDetail(orderDetail);
                foreach (Order orderExist in orders)
                {
                    if (order.Equals(orderExist))
                    {
                        throw new Exception("订单重复");
                    }
                }
                orders.Add(order);
            }

            public List<Order> selectByCustomer(Customer customer)
            {
                var selectedOrders = from o in orders
                                     where o.getOrderDetail().getCustomer().Equals(customer)
                                     orderby o.getOrderDetail().getMoney()
                                     select o;
                return selectedOrders.ToList();
            }

            public List<Order> selectById(int id)
            {
                var order = from o in orders
                            where o.getId().Equals(id)
                            select o;
                return order.ToList();
            }

            public List<Order> orderById()
            {
                var order = from o in orders
                            orderby o.getId()
                            select o;
                return order.ToList();
            }

            public List<Order> orderByCondition(Func<List<Order>, List<Order>> func)
            {
                return func(this.orders);
            }

            public Order updateOrder(int id, int sum)
            {
                foreach (Order order in orders)
                {
                    if (order.getId().Equals(id))
                    {
                        OrderDetail orderDetail = order.getOrderDetail();
                        orderDetail.setMoney(orderDetail.getGoods().getPrice() * sum);
                        order.setOrderDetail(orderDetail);
                        return order;
                    }

                }
                throw new Exception("未找到相应订单");

            }

            public void delectOrderById(int id)
            {
                foreach (Order order in orders)
                {
                    if (order.getId().Equals(id))
                    {
                        orders.Remove(order);
                    }
                }
                throw new Exception("未找到相应订单");
            }

            public void export()
            {
                try
                {
                    using (StringWriter stringWriter = new StringWriter(new StringBuilder()))
                    {
                        XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));
                        xmlSerializer.Serialize(stringWriter, orders);

                        FileStream fs = new FileStream("list_order.xml", FileMode.OpenOrCreate);
                        StreamWriter sw = new StreamWriter(fs);
                        sw.Write(stringWriter.ToString());
                        sw.Close();
                        fs.Close();
                    }
                }
                catch (System.Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                    System.Console.WriteLine(ex.StackTrace);
                }
            }

            public void import()
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("list_order.xml");
                XmlNode root = xmlDoc.SelectSingleNode("orders");
                XmlNodeList nodeList = root.ChildNodes;
                foreach (XmlNode xn in nodeList)
                {
                    XmlElement xe = (XmlElement)xn;
                    XmlNodeList subList = xe.ChildNodes;
                    List<Order> orderList = new List<Order>();
                    foreach (XmlNode xmlNode in subList)
                    {
                        Order order = new Order();
                        if ("id".Equals(xmlNode.Name))
                        {
                            order.setId(Int32.Parse(xmlNode.InnerText));
                        }
                        else if ("orderDetail".Equals(xmlNode.Name))
                        {
                            XmlNodeList orderDetailList = xmlNode.ChildNodes;
                            OrderDetail detail = new OrderDetail();
                            foreach (XmlNode orderDetail in orderDetailList)
                            {
                                if ("name".Equals(orderDetail.Name))
                                {
                                    detail.setName(orderDetail.InnerText);
                                }
                                if ("money".Equals(orderDetail.Name))
                                {
                                    detail.setMoney(Int32.Parse(orderDetail.InnerText));
                                }
                                if ("customer".Equals(orderDetail.Name))
                                {
                                    XmlNodeList customerList = orderDetail.ChildNodes;
                                    Customer customer = new Customer();
                                    foreach (XmlNode customerNode in customerList)
                                    {
                                        if ("name".Equals(customerNode.Name))
                                        {
                                            customer.setName(customerNode.InnerText);
                                        }
                                    }
                                    detail.setCustomer(customer);
                                }
                                if ("goods".Equals(orderDetail.Name))
                                {
                                    XmlNodeList goodsList = orderDetail.ChildNodes;
                                    Goods goods = new Goods();
                                    foreach (XmlNode goodsNode in goodsList)
                                    {
                                        if ("name".Equals(goodsNode.Name))
                                        {
                                            goods.setName(goodsNode.InnerText);
                                        }
                                        if ("price".Equals(goodsNode.Name))
                                        {
                                            goods.setPrice(Int32.Parse(goodsNode.InnerText));
                                        }
                                    }
                                    detail.setGoods(goods);
                                }
                            }
                            order.setOrderDetail(detail);
                        }
                        orders.Add(order);
                    }
                    this.orders = orderList;
                }

            }

        }

        [TestClass]
        class OrderTest
        {
            OrderService orderService = new OrderService();

            [TestMethod]
            public void testCreateOrder()
            {
                Customer customer = new Customer("test");
                Goods goods = new Goods(120, "goods");
                orderService.createOrder(customer, goods, 2);
                OrderDetail orderDetail = new OrderDetail();
                orderDetail.setCustomer(customer);
                orderDetail.setGoods(goods);
                orderDetail.setName(customer.getName() + goods.getName() + OrderService.orderNum);
                orderDetail.setMoney(goods.getPrice() * 2);
                Order order = new Order();
                order.setId(OrderService.orderNum);
                order.setOrderDetail(orderDetail);
                Assert.AreEqual(order, orderService.selectByCustomer(customer));
            }

            [TestMethod]
            public void testSelectByCustomer()
            {
                Customer customer = new Customer("test");
                List<Order> orders = orderService.selectByCustomer(customer);
                Assert.IsNotNull(orders);
            }

            [TestMethod]
            public void testSelectById()
            {
                List<Order> orders = orderService.selectById(1);
                Assert.IsTrue(orders.Count == 1);
            }

            [TestMethod]
            public void testOrderByCondition()
            {
                List<Order> orders = orderService.orderByCondition((orders) =>
                {
                    var orderList = from o in orders
                                    orderby o.getOrderDetail().getMoney()
                                    select o;
                    return orderList.ToList();
                });

                if (orders.Count == 1)
                {
                    return;
                }

                for (int i = 0; i < orders.Count - 1; i++)
                {
                    Assert.IsTrue(orders[i].getOrderDetail().getMoney() <= orders[i + 1].getOrderDetail().getMoney());
                }
            }

            [TestMethod]
            public void testUpdateOrder()
            {
                orderService.updateOrder(1, 3);
                List<Order> orders = orderService.selectById(1);
                Assert.IsTrue(orders[0].getOrderDetail().getMoney() == orders[0].getOrderDetail().getGoods().getPrice() * 3);
            }

            [TestMethod]
            public void testDelectOrderById()
            {
                orderService.delectOrderById(1);
                List<Order> orders = orderService.selectById(1);
                Assert.IsTrue(orders.Count == 0);
            }
        }
    }
}