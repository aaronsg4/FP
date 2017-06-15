namespace FP.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(FP.Models.ApplicationDbContext context)
        {

            var roleManager = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(context));
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
            }

            var userManager = new UserManager<ApplicationUser>(
            new UserStore<ApplicationUser>(context));
            if (!context.Users.Any(u => u.Email == "aaronsg4@yahoo.com"))
            {
                userManager.Create(new ApplicationUser
                {

                    UserName = "aaronsg4@yahoo.com",
                    Email = "aaronsg4@yahoo.com",
                    FirstName = "Aaron",
                    LastName = "Gay",
                    DisplayName = "Aaron Gay",

                }, "somethingelse");
            }
            var userId = "";
            userId = userManager.FindByEmail("aaronsg4@yahoo.com").Id;
            userManager.AddToRole(userId, "Admin");






            if (!context.Households.Any())
            {
                context.Households.AddOrUpdate(x => x.Id, new Household()
                {
                    Name = "Cammie's Household",
                    Description = "Cammie Zoie's Household",
                    CreatedDate = DateTime.Now,
                    Accounts = new HashSet<FinancialAccount>(),
                    Budgets = new HashSet<Budget>(),
                    Users = new HashSet<ApplicationUser>()
                },
                new Household
                {
                    Name = "Bradley's Household",
                    Description = "Bradley Merle's Household",
                    CreatedDate = DateTime.Now,
                    Accounts = new HashSet<FinancialAccount>(),
                    Budgets = new HashSet<Budget>(),
                    Users = new HashSet<ApplicationUser>()


                },

                new Household
                {
                    Name = "Joy's Household",
                    Description = "Joy Delight's Household",
                    CreatedDate = DateTime.Now,
                    Accounts = new HashSet<FinancialAccount>(),
                    Budgets = new HashSet<Budget>(),
                    Users = new HashSet<ApplicationUser>()

                },
                new Household
                {
                    Name = "Brendan's Household",
                    Description = "Brendan Madisyn's Household",
                    CreatedDate = DateTime.Now,
                    Accounts = new HashSet<FinancialAccount>(),
                    Budgets = new HashSet<Budget>(),
                    Users = new HashSet<ApplicationUser>()



                });


            }





            if (!context.Users.Any(u => u.Email == "DonDelight@mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {

                    UserName = "DonDelight@mailinator.com",
                    Email = "DonDelight@mailinator.com",
                    FirstName = "Don",
                    LastName = "Delight",
                    DisplayName = "Don Delight",
                    //HouseholdId = context.Households.FirstOrDefault(h => h.Name == "Joy's Household").Id

                }, "somethingelse");
            }

            if (!context.Users.Any(u => u.Email == "TravisDelight@mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {

                    Email = "TravisDelight@mailinator.com",
                    FirstName = "Travis",
                    LastName = "Delight",
                    UserName = "TravisDelight@mailinator.com",
                    DisplayName = "Travis Delight",
                    HouseholdId = context.Households.FirstOrDefault(h => h.Name == "Joy's Household").Id

                }, "somethingelse");
            }

            if (!context.Users.Any(u => u.Email == "AloysiusZoie@mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {

                    UserName = "AloysiusZoie@mailinator.com",
                    Email = "AloysiusZoie@mailinator.com",
                    FirstName = "Aloysius",
                    LastName = "Zoie",
                    DisplayName = "Aloysius Zoie",
                    HouseholdId = context.Households.FirstOrDefault(h => h.Name == "Cammie's Household").Id

                }, "somethingelse");
            }

            if (!context.Users.Any(u => u.Email == "PalmerMerle@mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {

                    UserName = "PalmerMerle@mailinator.com",
                    Email = "PalmerMerle@mailinator.com",
                    FirstName = "Palmer",
                    LastName = "Merle",
                    DisplayName = "Palmer Merle",
                    HouseholdId = context.Households.FirstOrDefault(h => h.Name == "Bradley's Household").Id

                }, "somethingelse");
            }

            if (!context.Users.Any(u => u.Email == "BradleyMerle@mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {

                    UserName = "BradleyMerle@mailinator.com",
                    Email = "BradleyMerle@mailinator.com",
                    FirstName = "Bradley",
                    LastName = "Merle",
                    DisplayName = "Bradley Merle",
                    HouseholdId = context.Households.FirstOrDefault(h => h.Name == "Bradley's Household").Id

                }, "somethingelse");
            }

            if (!context.Users.Any(u => u.Email == "CammieZoie@mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {

                    UserName = "CammieZoie@mailinator.com",
                    Email = "CammieZoie@mailinator.com",
                    FirstName = "Cammie",
                    LastName = "Zoie",
                    DisplayName = "Cammie Zoie",
                    HouseholdId = context.Households.FirstOrDefault(h => h.Name == "Cammie's Household").Id

                }, "somethingelse");
            }

            if (!context.Users.Any(u => u.Email == "WillaZoie@mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {

                    UserName = "WillaZoie@mailinator.com",
                    Email = "WillaZoie@mailinator.com",
                    FirstName = "Willa",
                    LastName = "Zoie",
                    DisplayName = "Willa Zoie",
                    HouseholdId = context.Households.FirstOrDefault(h => h.Name == "Cammie's Household").Id

                }, "somethingelse");
            }

            if (!context.Users.Any(u => u.Email == "JoyDelight@mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {

                    UserName = "JoyDelight@mailinator.com",
                    Email = "JoyDelight@mailinator.com",
                    FirstName = "Joy",
                    LastName = "Delight",
                    DisplayName = "Joy Delight",
                    HouseholdId = context.Households.FirstOrDefault(h => h.Name == "Joy's Household").Id

                }, "somethingelse");
            }

            if (!context.Users.Any(u => u.Email == "CamillaDelight@mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {

                    UserName = "CamillaDelight@mailinator.com",
                    Email = "CamillaDelight@mailinator.com",
                    FirstName = "Camilla",
                    LastName = "Delight",
                    DisplayName = "Camilla Delight",
                    HouseholdId = context.Households.FirstOrDefault(h => h.Name == "Joy's Household").Id
                }, "somethingelse");
            }

            if (!context.Users.Any(u => u.Email == "VelmaMadisyn@mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {

                    UserName = "VelmaMadisyn@mailinator.com",
                    Email = "VelmaMadisyn@mailinator.com",
                    FirstName = "Velma",
                    LastName = "Madisyn",
                    DisplayName = "Velma Madisyn",
                    HouseholdId = context.Households.FirstOrDefault(h => h.Name == "Brendan's Household").Id

                }, "somethingelse");
            }

            if (!context.Users.Any(u => u.Email == "MaggieMadisyn@mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {

                    UserName = "MaggieMadisyn@mailinator.com",
                    Email = "MaggieMadisyn@mailinator.com",
                    FirstName = "Maggie",
                    LastName = "Madisyn",
                    DisplayName = "Maggie Madisyn",
                    HouseholdId = context.Households.FirstOrDefault(h => h.Name == "Brendan's Household").Id

                }, "somethingelse");
            }

            if (!context.Users.Any(u => u.Email == "TracieMadisyn@mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {

                    UserName = "TracieMadisyn@mailinator.com",
                    Email = "TracieMadisyn@mailinator.com",
                    FirstName = "Tracie",
                    LastName = "Madisyn",
                    DisplayName = "Tracie Madisyn",
                    HouseholdId = context.Households.FirstOrDefault(h => h.Name == "Brendan's Household").Id

                }, "somethingelse");
            }

            if (!context.Users.Any(u => u.Email == "RobynneMadisyn@mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {

                    UserName = "RobynneMadisyn@mailinator.com",
                    Email = "RobynneMadisyn@mailinator.com",
                    FirstName = "Robynne",
                    LastName = "Madisyn",
                    DisplayName = "Robynne Madisyn",
                    HouseholdId = context.Households.FirstOrDefault(h => h.Name == "Brendan's Household").Id

                }, "somethingelse");
            }

            if (!context.Users.Any(u => u.Email == "BrendanMadisyn@mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {

                    UserName = "BrendanMadisyn@mailinator.com",
                    Email = "BrendanMadisyn@mailinator.com",
                    FirstName = "Brendan",
                    LastName = "Madisyn",
                    DisplayName = "Brendan Madisyn",
                    HouseholdId = context.Households.FirstOrDefault(h => h.Name == "Brendan's Household").Id

                }, "somethingelse");
            }



            if (!context.AccountTypes.Any())
            {
                context.AccountTypes.AddOrUpdate(x => x.Id,
                    new FinancialAccountType()
                    {
                        Name = "Checking",
                        Description = "Checking Account",
                        Accounts = new HashSet<FinancialAccount>()
                    },

                new FinancialAccountType
                {
                    Name = "Savings",
                    Description = "Savings Account",
                    Accounts = new HashSet<FinancialAccount>()
                });
            }



            //if (!context.Accounts.Any())
            //{
            //    context.Accounts.Add(
            //        new Account
            //        {
            //            Name = "Joy's Checking",
            //            Description = "Joy Delight's Checking Account",
            //            ActualBalance = 5000,
            //            ReconciledBalance = 5000,
            //            CreatedDate = DateTime.Now,
            //            Include = true,
            //            HouseholdId = context.Households.FirstOrDefault(h => h.Name == "Joy's Household").Id,
            //            AccountTypeId = context.AccountTypes.FirstOrDefault(a => a.Name == "Checking").Id
            //        });

            //    context.Accounts.AddOrUpdate(x => x.Id,
            //      new Account
            //      {
            //          Name = "Joy's Savings",
            //          Description = "Joy Delight's Savings Account",
            //          ActualBalance = 5000,
            //          ReconciledBalance = 5000,
            //          CreatedDate = DateTime.Now,
            //          Include = true,
            //          HouseholdId = context.Households.FirstOrDefault(h => h.Name == "Joy's Household").Id,
            //          AccountTypeId = context.AccountTypes.FirstOrDefault(a => a.Name == "Savings").Id



            //      },

            //        new Account
            //        {
            //            Name = "Bradley's Checking",
            //            Description = "Bradley Merle's Checking Account",
            //            ActualBalance = 5000,
            //            ReconciledBalance = 5000,
            //            CreatedDate = DateTime.Now,
            //            Include = true,
            //            HouseholdId = context.Households.FirstOrDefault(h => h.Name == "Bradley's Household").Id,
            //            AccountTypeId = context.AccountTypes.FirstOrDefault(a => a.Name == "Checking").Id



            //        },

            //          new Account
            //          {
            //              Name = "Bradley's Savings",
            //              Description = "Bradley Merle's Savings Account",
            //              ActualBalance = 5000,
            //              ReconciledBalance = 5000,
            //              CreatedDate = DateTime.Now,
            //              Include = true,
            //              HouseholdId = context.Households.FirstOrDefault(h => h.Name == "Bradley's Household").Id,
            //              AccountTypeId = context.AccountTypes.FirstOrDefault(a => a.Name == "Savings").Id



            //          },

            //           new Account
            //           {
            //               Name = "Cammie's Checking",
            //               Description = "Cammie Zoie's Checking Account",
            //               ActualBalance = 5000,
            //               ReconciledBalance = 5000,
            //               CreatedDate = DateTime.Now,
            //               Include = true,
            //               HouseholdId = context.Households.FirstOrDefault(h => h.Name == "Cammie's Household").Id,
            //               AccountTypeId = context.AccountTypes.FirstOrDefault(a => a.Name == "Checking").Id



            //           },

            //            new Account
            //            {
            //                Name = "Cammie's Savings",
            //                Description = "Cammie Zoie's Savings Account",
            //                ActualBalance = 5000,
            //                ReconciledBalance = 5000,
            //                CreatedDate = DateTime.Now,
            //                Include = true,
            //                HouseholdId = context.Households.FirstOrDefault(h => h.Name == "Cammmie's Household").Id,
            //                AccountTypeId = context.AccountTypes.FirstOrDefault(a => a.Name == "Savings").Id

            //            });



            //}
        }
    }
}
