using MySQLProject.Models;
using MySql.Data.Entity;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MySQLProject.DAL
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class MyDbContext : DbContext
    {

        public MyDbContext() : base("MyDbContextConnectionString")
        {
            DbConfiguration.SetConfiguration(new MySqlEFConfiguration());
            Database.SetInitializer<MyDbContext>(new MyDbInitializer());
        }
        /*
        static MyDbContext()
        {
            // static constructors are guaranteed to only fire once per application.
            // I do this here instead of App_Start so I can avoid including EF
            // in my MVC project (I use UnitOfWork/Repository pattern instead)
            DbConfiguration.SetConfiguration(new MySqlEFConfiguration());
        }
        */
        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}