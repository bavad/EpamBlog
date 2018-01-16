using EpamPractice1.DAL.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamPractice1.DAL.EF
{
    public class BlogContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Appreciation> Appreciations { get; set; }
        public DbSet<Form> Forms { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TagArticle> TagArticles { get; set; }

        static BlogContext()
        {
            Database.SetInitializer<BlogContext>(new BlogInitializer());
        }

        public BlogContext() : base("BlogContext")
        {
        }

        public static BlogContext Create()
        {
            return new BlogContext();
        }

        public class BlogInitializer : CreateDatabaseIfNotExists<BlogContext>
        {
            protected override void Seed(BlogContext context)
            {
                var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                                
                var role1 = new IdentityRole { Name = "Admin" };
                var role2 = new IdentityRole { Name = "User" };
                
                roleManager.Create(role1);
                roleManager.Create(role2);
                
                var admin = new ApplicationUser { Email = "bavad25@gmail.com", UserName = "bavad25@gmail.com" };
                string password = "333BBBaa!";
                var result = userManager.Create(admin, password);

                
                if (result.Succeeded)
                {                    
                    userManager.AddToRole(admin.Id, role1.Name);
                    userManager.AddToRole(admin.Id, role2.Name);
                }

                var user = new ApplicationUser { Email = "john@gmail.com", UserName = "john@gmail.com" };
                password = "555CCCqq!";
                result = userManager.Create(user, password);


                if (result.Succeeded)
                {
                    userManager.AddToRole(user.Id, role2.Name);                    
                }


                context.Articles.Add(new Article { Name = "Some name", Date = new DateTime(2017, 12, 12, 18, 30, 59), Rating = 0, Body = "US stock markets opened at new highs on Thursday, with the blue chip Dow Jones Industrial Average crossing 25,000." + 
                    "The gains extended an eye - popping run for Wall Street, which has surged over the last 12 months amid growth in the US and global economies." + 
                    "On Thursday, markets got another boost after the ADP National Employment report estimated that employers added 250, 000 jobs in December." +
                    "The US is due to release official job figures on Friday." +
                    "In early trade the Dow Jones increased 146 points or 0.59 % to 25, 070.86." +
                    "Thursday's trading puts the index on track for its fastest 1,000-point gain in history." +
                    "The Dow already climbed about 25 % last year, adding nearly 5, 000 points and crossing the 24, 000 - mark at the end of November." +
                    "Greg McBride, chief financial analyst for Bankrate.com, said: \"Dow 25,000 is a mere 4.2% up from 24,000 at the end of November." + 
                    "With the positive fundamentals - an expanding economy, continued job growth, still low interest rates and tax reform that promises to boost corporate earnings - it's no surprise to see the market continuing to climb." +
                    "The S & P and Nasdaq have also hit milestones in recent days.\""});
                context.Articles.Add(new Article { Name = "Article one", Date = new DateTime(2017, 12, 15, 15, 30, 59), Rating = 0, Body = "Plans for the way farming subsidies will be dealt with after Brexit have been set out by Michael Gove." +
                    "Farmers will receive payments for \"public goods\", such as access to the countryside and planting meadows." +
                    "The environment secretary told farmers the government would guarantee subsidies at the current EU level until the 2022 election.There would then be a \"transitional period\" in England." +
                    "The National Farmers Union said it was time for \"a new deal\" for the UK." +
                    "Fergus Ewing, the Scottish rural economy secretary, said Mr Gove had left \"too many questions unanswered\"." +
                    "Meanwhile, a report warns Brexit trade deals could threaten UK food security." +
                    "MPs and peers in the All - Party Parliamentary Group on Agroecology(APPGA) say ministers must ensure farmers are not undermined by future trade deals which permit imports of food produced with lower welfare or environmental standards." });
                context.SaveChanges();

                context.Forms.Add(new Form { Name = "John", Gender = "male" });
                context.SaveChanges();

                context.Appreciations.Add(new Appreciation { ArticleID = 1, FormID = 1 });
                context.SaveChanges();

                context.Reviews.Add(new Review { AuthorName = "Bob", Date = new DateTime(2017, 10, 15, 12, 30, 59), Body = "This is my review" });
                context.SaveChanges();

                context.Tags.Add(new Tag { Name = "Business" });
                context.Tags.Add(new Tag { Name = "Dow Jones" });
                context.Tags.Add(new Tag { Name = "Brexit" });
                context.SaveChanges();

                context.TagArticles.Add(new TagArticle { ArticleID = 1, TagID = 1 });
                context.TagArticles.Add(new TagArticle { ArticleID = 1, TagID = 2 });
                context.TagArticles.Add(new TagArticle { ArticleID = 2, TagID = 1 });
                context.TagArticles.Add(new TagArticle { ArticleID = 2, TagID = 3 });
                context.SaveChanges();



            }
        }
    }
}
