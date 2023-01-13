using AnimalsWeb.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AnimalsWeb.Data
{
    public partial class AnimalContext : IdentityDbContext
    {
        public AnimalContext(DbContextOptions<AnimalContext> options) : base(options)
        { }

        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Animal> Animals { get; set; } = null!;
        public DbSet<Comment> Comments { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                 new { CategoryId = 1, Name = "Mamal" },
                 new { CategoryId = 2, Name = "Bird" },
                 new { CategoryId = 3, Name = "Fish" },
                 new { CategoryId = 4, Name = "Reptile" }
             );

            modelBuilder.Entity<Animal>().HasData(

                new
                {
                    AnimalId = 1,
                    Name = "Tiger",
                    Age = 3,
                    PictureName = "tiger.jpg",
                    Description = "tiger" +
                " (Felidae), rivaled only by" +
                " the lion (Panthera leo) in strength and ferocity. The tiger is endangered throughout its range, which stretches from" +
                " the Russian Far East through parts of North Korea, China, India, and Southeast",
                    CategoryId = 1
                },

                new
                {
                    AnimalId = 2,
                    Name = "Eagale",
                    Age = 4,
                    PictureName = "eagle.jpg",
                    Description = "eagle, any of many large, heavy-beaked, big-footed " +
                "birds of prey belonging to the family Accipitridae (order Accipitriformes)" +
                " may resemble a vulture in build and flight characteristics",
                    CategoryId = 2
                },

                new
                {
                    AnimalId = 3,
                    Name = "Aligator",
                    Age = 5,
                    PictureName = "aligator.jpg",
                    Description = "Alligators have a long, rounded snout that has upward" +
                " facing nostrils at the end; this allows breathing to occur while the rest of the body is underwater." +
                " have dark stripes on the tail. It's easy to distinguish an alligator from a crocodile by the teeth.",
                    CategoryId = 4
                },

                new
                {
                    AnimalId = 4,
                    Name = "Wolf",
                    Age = 5,
                    PictureName = "wolf.jpg",
                    Description = "Wolves vary in size depending on where they live. Wolves in the" +
                " north are usually larger than those in the south. The average size of a wolf." +
                " Females typically weigh 60 to 100 pounds, and males weigh 70 to 145 pounds.",
                    CategoryId = 1
                },

                new
                {
                    AnimalId = 5,
                    Name = "Condor",
                    Age = 2,
                    PictureName = "condor.jpg",
                    Description = "The male Andean condor is a black bird with grayish white wing" +
                " feathers, a white fringe of feathers around the neck, and a bare red or pinkish head, neck, and crop. Males have a large caruncle,",
                    CategoryId = 2
                }

                );

            modelBuilder.Entity<Comment>().HasData(

                    new { CommentId = 1, AnimalId = 1, Content = "the tiger color is beautiful" },
                    new { CommentId = 2, AnimalId = 2, Content = " is wings are higher then me" }
                );

            modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(i => i.UserId);
            modelBuilder.Entity<IdentityUserRole<string>>().HasKey(role => new { role.RoleId, role.UserId });
            modelBuilder.Entity<IdentityUserClaim<string>>().HasKey(c => c.UserId);
            modelBuilder.Entity<IdentityUserToken<string>>().HasKey(t => t.UserId);
            modelBuilder.Entity<IdentityUser<string>>().HasKey(u => u.Id);
          
        }

    }
}
