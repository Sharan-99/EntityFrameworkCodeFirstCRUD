using System;
using System.Data.Entity;
using System.Linq;

namespace EntityFrameworkCodeFirstCRUD
{
    public class Model1 : DbContext
    {
        
        public Model1(): base("name=Model1")
        {
        }

       public virtual DbSet<Product> Products { get; set; }
    }

    
}