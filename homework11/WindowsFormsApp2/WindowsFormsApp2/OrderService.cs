using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Order
{
    public class OrderService
    {

        public List<Order> SearchByID(int input)
        {
            try
            {
                using (var db = new OrderContext())
                {
                    var order = db.Orders.
                        Where(o => o.OrderId == input)
                        .OrderBy(o => o.Total);
                    return order.ToList<Order>();
                }
            }
            catch (FormatException e)
            {
                throw e;
            }
        }

        public int CreateId()
        {
            int id = 1;
            try
            {

                using (var db = new OrderContext())
                {
                    while (true)
                    {
                        var order = db.Orders.FirstOrDefault(o => o.OrderId == id);

                        if (order == null)
                        {
                            return id;
                        }
                        else
                        {
                            id++;
                        }
                    }

                }
            }
            catch (FormatException e)
            {
                throw e;
            }
        }

        public List<Order> SearchAll()
        {
            try
            {
                using (var db = new OrderContext())
                {
                    var order = db.Orders;
                    return order.ToList<Order>();
                }
            }
            catch (FormatException e)
            {
                throw e;
            }
        }

        public void AddOrderItem(Order torder, OrderItem item)
        {
            try
            {
                using (var db = new OrderContext())
                {
                    var post = db.Orders.FirstOrDefault(o => o.OrderId == torder.OrderId);

                }
            }
            catch (FormatException e)
            {
                throw e;
            }
        }

        public List<Order> SearchByCustomer(String input)
        {
            try
            {
                using (var db = new OrderContext())
                {
                    var order = db.Orders.
                           Where(o => o.Customer == input)
                           .OrderBy(o => o.Total);
                    return order.ToList<Order>();
                }
            }
            catch (FormatException e)
            {
                throw e;
            }
        }

        public List<Order> SearchByGoods(String input)
        {
            try
            {
                using (var db = new OrderContext())
                {
                    var order = db.Orders.
                           Where(o => o.SearchGoods(input))
                           .OrderBy(o => o.Total);
                    return order.ToList<Order>();
                }
            }
            catch (FormatException e)
            {
                throw e;
            }
        }

        public void AddOrder(Order order)
        {
            using (var db = new OrderContext())
            {
                db.Orders.Add(order);
                db.SaveChanges();
            }
        }

        public void DeleteOrder(int ID)
        {
            try
            {
                using (var db = new OrderContext())
                {
                    var post = db.Orders.Include("GoodsList").FirstOrDefault(o => o.OrderId == ID);
                    if (post != null)
                    {


                        db.Orders.Remove(post);

                        db.SaveChanges();


                    }

                }

            }
            catch (InvalidCastException e)
            {
                throw e;
            }
            catch (ArgumentOutOfRangeException e)
            {
                throw e;
            }
        }

        public void ModiftyOrder(int ID, Order order)
        {
            DeleteOrder(ID);
            AddOrder(order);

        }



    }
}
