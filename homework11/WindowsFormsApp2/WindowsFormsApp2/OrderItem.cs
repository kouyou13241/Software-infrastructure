using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Order
{
    public class OrderItem
    {
        [Key]
        public int GooodId { get; set; }

        public String GoodsName { get; set; }

        public int GoodsPrice { get; set; }

        public int GoodsNumber { get; set; }

        public int OrderId;




        public OrderItem()
        {

        }

        public OrderItem(String name, int price, int number, int id)
        {
            GooodId = GetHashCode();
            GoodsName = name;
            GoodsPrice = price;
            GoodsNumber = number;
            OrderId = id;
        }

        public override int GetHashCode()
        {
            var hashCode = -2127770830;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(GoodsName);
            return hashCode;

        }
    }
}