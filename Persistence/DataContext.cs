using Domain;
using Microsoft.EntityFrameworkCore;
//Hover over names to know what it does. 

namespace Persistence
{
    //DbContext is used for EF (EntityFramework) and DataContext is the class used for L2S (LINQ To SQL).
    public class DataContext: DbContext
    {
        //The DbContextOptions instance carries configuration information such as: The database provider to use, typically selected by invoking a method such as UseSqlServer or UseSqlite . These extension methods require the corresponding provider package, such as Microsoft. EntityFrameworkCore
        //The base keyword is used to access members of the base class from within a derived class: Call a method on the base class that has been overridden by another method.
        //DbContextOptions is the options to be used by DbContext. base initializes a new instance of the DbContext class using the spcified options. 
        //DataContext is the name of the constructor 
        public DataContext(DbContextOptions options) : base(options)
        {     
        }

        // The DbSet class represents an entity set that can be used for create, read, update, and delete operations. The context class (derived from DbContext ) must include the DbSet type properties for the entities which map to database tables and views.
        //Value is the entity we created in Domain, and Values is the name of the table. 

        public DbSet<Value> Values { get; set; }

        public DbSet<Activity> Activities { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Value>()
                .HasData(
                    new Value {Id = 1, Name = "Value 101"},
                    new Value {Id = 2, Name = "Value 102"},
                    new Value {Id = 3, Name = "Value 103"}
                );
        }
    }
}
