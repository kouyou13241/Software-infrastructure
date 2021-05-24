using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Order
{
    class OrderContext : DbContext
    {
        public OrderContext() : base("OrderDatebase")
        {
            //解决团队开发中，多人迁移数据库造成的修改覆盖问题。
            Database.SetInitializer<OrderContext>(null);
            //base.Configuration.AutoDetectChangesEnabled = false;
            ////关闭EF6.x 默认自动生成null判断语句
            //base.Configuration.UseDatabaseNullSemantics = true;        
        }


        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }
    }
}