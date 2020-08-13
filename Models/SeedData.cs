using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using MoviesManager.Data;

using System;
using System.Linq;

namespace MoviesManager.Models
{
    public class SeedData
    {
        // Initializer for the class
        public static void Initialize(IServiceProvider serviceProvider) {

                using (
                    var context = new MovieDbContext(
                        serviceProvider.GetRequiredService<DbContextOptions<MovieDbContext>>())) 
                        {
                            // Look for any movies.
                            if (context.Movie.Any())
                            {
                                return;   // DB has been seeded
                            }

                            // Add Range of new context data to seed the Movies Database<Project Sdk="Microsoft.NET.Sdk">
                            // If there is any, the initializer is returned and the process of seeding finish
                            // without including any new data.
                             context.Movie.AddRange(
                                new Movie
                                {
                                    Title = "When Harry Met Sally",
                                    ReleaseDate = DateTime.Parse("1989-2-12"),
                                    Genre = "Comedia Romantica",
                                    Price = 7.99M
                                },
                                new Movie
                                {
                                    Title = "Cazafantasmas",
                                    ReleaseDate = DateTime.Parse("1984-3-13"),
                                    Genre = "Comedia",
                                    Price = 8.99M
                                },
                                new Movie
                                {
                                    Title = "Cazafantasmas 2",
                                    ReleaseDate = DateTime.Parse("1986-2-23"),
                                    Genre = "Comedia",
                                    Price = 9.99M
                                }
                             );

                             // Save the context with the new range of data added
                             context.SaveChanges();
                        }
        }
    }
}