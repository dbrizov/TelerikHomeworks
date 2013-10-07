namespace AspNetMvcExam.Data.Migrations
{
    using AspNetMvcExam.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public class DatabaseInitializer : DbMigrationsConfiguration<AspNetMvcExam.Data.ApplicationDbContext>
    {
        public DatabaseInitializer()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(AspNetMvcExam.Data.ApplicationDbContext context)
        {
            if (context.Categories.Count() > 0)
            {
                return;
            }

            Random rand = new Random();
            ApplicationUser user = new ApplicationUser() { UserName = "TestUser", Points = 10 };
            //var user = context.Users.FirstOrDefault(u => u.UserName == "TestUser");

            int categoriesCount = 5;
            for (int i = 0; i < categoriesCount; i++)
            {
                var category = new Category()
                {
                    Name = "Category<br>#" + i
                };

                int ticketsCount = 5;
                for (int j = 0; j < ticketsCount; j++)
                {
                    var ticket = new Ticket()
                    {
                        Author = user,
                        Priority = TicketPriority.Medium,
                        Category = category,
                        Title = "Ticket<br>#" + i + " " + j,
                        ScreenshotUrl = "http://xmlwriter.net/images/screenshot.gif",
                        Description = (j % 2 == 0) ? "Some description" : null
                    };

                    int commentsCount = rand.Next(10);
                    for (int k = 0; k < commentsCount; k++)
                    {
                        var comment = new Comment()
                        {
                            Content = "Comment<br>#" + i + " " + j + " " + k,
                            User = user
                        };

                        ticket.Comments.Add(comment);
                    }

                    category.Tickets.Add(ticket);
                }

                context.Categories.Add(category);
            }
        }
    }
}
