using DotNet6API_.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNet6API_.Context
{
    public class ApplicationDbContext:DbContext
    {
        //configuracion con sqlserver
        //public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        
        //configuracion con sqlite
        //public ApplicationDbContext(DbContextOptions options):base(options)


        public ApplicationDbContext(DbContextOptions options):base(options)
        {
            
        }
       

        public DbSet<Post> Posts { get; set;}
    }
}