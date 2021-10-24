using Microsoft.EntityFrameworkCore;

namespace SEDC.MovieWorkshop.DataModels
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<User> Users { get; set; }
        public void Seed(ModelBuilder builder)
        {
            builder.Entity<User>().HasData(new User
            {
                Id = 3,
                FullName = "John Smith",
                UserName = "JohnS",
                Password = "111222333",
                Subscription = Subscription.Default
            });

            builder.Entity<Movie>().HasData(new Movie
            {
                Id = 7,
                Title = "Gone in 60 seconds",
                Description = "Test description",
                Genre = Genre.Action,
                Year = 2000,
                UserId = 1
            });
            builder.Entity<Movie>().HasData(new Movie
            {
                Id = 8,
                Title = "Rambo 1",
                Description = "Test description",
                Genre = Genre.Action,
                Year = 1982,
                UserId = 1
            });
            builder.Entity<Movie>().HasData(new Movie
            {
                Id = 9,
                Title = "Rambo 2",
                Description = "Test description",
                Genre = Genre.Action,
                Year = 1985,
                UserId = 1
            });
            builder.Entity<Movie>().HasData(new Movie
            {
                Id = 10,
                Title = "Rambo 3",
                Description = "Test description",
                Genre = Genre.Action,
                Year = 1988,
                UserId = 1
            });
            builder.Entity<Movie>().HasData(new Movie
            {
                Id = 11,
                Title = "Harry Potter and the Philosopher's Stone",
                Description = "Test description",
                Genre = Genre.SciFi,
                Year = 2001,
                UserId = 1
            });
            builder.Entity<Movie>().HasData(new Movie
            {
                Id = 12,
                Title = "Grown Ups",
                Description = "Test description",
                Genre = Genre.Action,
                Year = 2010,
                UserId = 1
            });
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
                        .HasOne(x => x.User)
                        .WithMany(x => x.Movies)
                        .HasForeignKey(x => x.UserId);
            Seed(modelBuilder);
        }
    }
}
