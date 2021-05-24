using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Order
{
    public class Order
    {
        [Key]
        public int OrderId { set; get; }

        public String Customer { set; get; }

        public List<OrderItem> GoodsList { set; get; }

        public int Total
        {
            get
            {
                int total = 0;
                foreach (OrderItem g in GoodsList)
                {
                    total += g.GoodsPrice * g.GoodsNumber;
                }
                return total;
            }
            set { }
        }

        public Order()
        {
            GoodsList = new List<OrderItem>();
            OrderId = 0;
            Customer = "";

        }

        public Order(int orderID, String name)
        {
            OrderId = orderID;
            Customer = name;
            GoodsList = new List<OrderItem>();
        }

        public void AddOrderItem(OrderItem o)
        {
            GoodsList.Add(o);
        }

        public bool SearchGoods(String name)
        {
            foreach (OrderItem g in GoodsList)
            {
                if (g.GoodsName == name)
                    return true;
            }
            return false;
        }


    }
}
