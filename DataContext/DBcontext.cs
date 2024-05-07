using Microsoft.EntityFrameworkCore;
using warhammer.Entities;
namespace warhammer.DataContext
{
    public class DBcontext : DbContext
    {

        public DBcontext(DbContextOptions<DBcontext> options) : base(options)
        {

        }


        //name "models" should be the same as the table name in db
        public DbSet<Model> models { get; set; }
    }
}
