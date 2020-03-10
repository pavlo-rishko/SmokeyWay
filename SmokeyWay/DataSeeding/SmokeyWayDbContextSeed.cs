using System;
using System.Linq;
using DAL.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace DataSeeding
{
    public static class SmokeyWayDbContextSeed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<SmokeyWayDbContext>();
            context.Database.EnsureCreated();

            // Tables which must be filled first.
            if (!context.DishTypes.Any())
            {
                try
                {
                    context.DishTypes.Add(new DishType() { Name = "Суп", CreateDateTime = DateTime.Now });
                    context.DishTypes.Add(new DishType() { Name = "Стейк", CreateDateTime = DateTime.Now });
                    context.SaveChanges();
                }
                catch
                {
                    throw new Exception($"Error when adding {nameof(context.DishTypes)}");
                }
            }

            if (!context.UserRoles.Any())
            {
                try
                {
                    context.UserRoles.Add(new UserRole() { Name = "System Administrator", CreateDateTime = DateTime.Now });
                    context.UserRoles.Add(new UserRole() { Name = "User", CreateDateTime = DateTime.Now });
                    context.SaveChanges();
                }
                catch
                {
                    throw new Exception($"Error when adding {nameof(context.UserRoles)}");
                }
            }

            if (!context.EmployeePositions.Any())
            {
                try
                {
                    context.EmployeePositions.Add(new EmployeePosition()
                    {
                        Name = "Waiter",
                        Description = "Зустрічає гостей та обслуговує гостей, слудкує за чистотою столів",
                        CreateDateTime = DateTime.Now
                    });

                    context.EmployeePositions.Add(new EmployeePosition()
                    {
                        Name = "Manager",
                        Description = "Слідкує заусіма процесами, робить замовлення товарів",
                        CreateDateTime = DateTime.Now
                    });

                    context.SaveChanges();
                }
                catch
                {
                    throw new Exception($"Error when adding {nameof(context.EmployeePositions)}");
                }
            }

            if (!context.GameConsoleTypes.Any())
            {
                try
                {
                    context.Add(new GameConsoleType() { Name = "PS4", CreateDateTime = DateTime.Now });
                    context.Add(new GameConsoleType() { Name = "Xbox One X", CreateDateTime = DateTime.Now });
                    context.SaveChanges();
                }
                catch
                {
                    throw new Exception($"Error when adding {nameof(context.GameConsoleTypes)}");
                }
            }

            if (!context.Genders.Any())
            {
                try
                {
                    context.Genders.Add(new Gender() { Name = "Male", Descriprion = string.Empty, CreateDateTime = DateTime.Now });
                    context.Genders.Add(new Gender() { Name = "Female", Descriprion = string.Empty, CreateDateTime = DateTime.Now });
                    context.SaveChanges();
                }
                catch
                {
                    throw new Exception($"Error when adding {nameof(context.Genders)}");
                }
            }

            // Tables which must be filled secondary.
            if (!context.Users.Any())
            {
                try
                {
                    context.Users.Add(new User()
                    {
                        Name = "Pavlo",
                        PhoneNumber = "380687331095",
                        PhoneNumberConfirmed = true,
                        Email = "rishkomail.ua@gmail.com",
                        EmailConfirmed = true,
                        BirthDate = new DateTime(1999, 04, 07),
                        GenderId = 1,
                        CommunicationLanguage = "Ukraine",
                        RoleId = 1
                    });

                    context.Users.Add(new User()
                    {
                        Name = "Ostap",
                        PhoneNumber = "380680719107",
                        Email = "ostap.ostap.@gmail.com",
                        EmailConfirmed = false,
                        BirthDate = new DateTime(2000, 08, 30),
                        GenderId = 2,
                        CommunicationLanguage = "English",
                        RoleId = 2
                    });

                    context.SaveChanges();
                }
                catch
                {
                    throw new Exception($"Error when adding {nameof(context.Users)}");
                }
            }

            if (!context.Departaments.Any())
            {
                try
                {
                    context.Departaments.Add(new Departament()
                    {
                        Name = "Departament1",
                        Country = "Ukraine",
                        City = "Lviv",
                        Street = "Horodotska",
                        HouseNumber = "321",
                        CreateDateTime = DateTime.Now
                    });

                    context.Departaments.Add(new Departament()
                    {
                        Name = "Departament2",
                        Country = "Ukraine",
                        City = "Kyiv",
                        Street = "Volodymyra Velykoho",
                        HouseNumber = "52",
                        CreateDateTime = DateTime.Now
                    });

                    context.SaveChanges();
                }
                catch
                {
                    throw new Exception($"Error when adding {nameof(context.Departaments)}");
                }
            }

            if (!context.Dishes.Any())
            {
                try
                {
                    context.Dishes.Add(new Dish()
                    {
                        Name = "Борщ",
                        Price = 80,
                        Description = "Традиційна українська страва",
                        TypeId = 1,
                        CreateDateTime = DateTime.Now,
                        IsAvailable = true
                    });

                    context.Dishes.Add(new Dish()
                    {
                        Name = "Стейк",
                        Price = 150,
                        Description = "Якісно приготований товстий шматок м'яса, вирізаний з туші тварини поперек волокон",
                        TypeId = 2,
                        CreateDateTime = DateTime.Now,
                        IsAvailable = true
                    });

                    context.SaveChanges();
                }
                catch
                {
                    throw new Exception($"Error when adding {nameof(context.Dishes)}");
                }
            }

            if (!context.Employees.Any())
            {
                try
                {
                    context.Employees.Add(new Employee()
                    {
                        FirstName = "Ivan",
                        LastName = "Gavrulyk",
                        DepartamentId = 1,
                        PhoneNumber = "380931170239",
                        CreateDateTime = DateTime.Now,
                        PositionId = 1,
                        GenderId = 1,
                        BirthDate = new DateTime(1978, 08, 05)
                    });

                    context.Employees.Add(new Employee()
                    {
                        FirstName = "Petro",
                        LastName = "Melnyk",
                        DepartamentId = 2,
                        PhoneNumber = "380682881038",
                        CreateDateTime = DateTime.Now,
                        PositionId = 2,
                        GenderId = 2,
                        BirthDate = new DateTime(1974, 02, 05),
                    });

                    context.SaveChanges();
                }
                catch
                {
                    throw new Exception($"Error when adding {nameof(context.Employees)}");
                }
            }

            if (!context.Games.Any())
            {
                try
                {
                    context.Games.Add(new Game()
                    {
                        Name = "GTA5",
                        Description =
                            "Grand Theft Auto V is a 2013 action-adventure game developed by " +
                            "Rockstar North and published by Rockstar Games. It is the first main" +
                            " entry in the Grand Theft Auto series since 2008's Grand Theft Auto IV." +
                            " Set within the fictional state of San Andreas, based on Southern " +
                            "California, the single-player story follows three criminals and their" +
                            " efforts to commit heists while under pressure from a government agency" +
                            " and powerful crime figures. The open world design lets players freely" +
                            " roam San Andreas' open countryside and the fictional city of " +
                            "Los Santos, based on Los Angeles.",
                        CreateDateTime = DateTime.Now,
                        LicenseBeginDate = new DateTime(2020, 04, 03),
                        LicenseEndDate = new DateTime(2020, 03, 04)
                    });

                    context.Games.Add(new Game()
                    {
                        Name = "The Witcher 3: Wild Hunt",
                        Description = "The Witcher 3: Wild Hunt[a] is a 2015 action role-playing " +
                                      "game developed and published by CD Projekt and based on The" +
                                      " Witcher series of fantasy novels by Andrzej Sapkowski.",
                        CreateDateTime = DateTime.Now,
                        LicenseBeginDate = new DateTime(2019, 05, 01),
                        LicenseEndDate = new DateTime(2020, 05, 01)
                    });

                    context.SaveChanges();
                }
                catch
                {
                    throw new Exception($"Error when adding {nameof(context.Games)}");
                }
            }

            if (!context.GameConsoles.Any())
            {
                try
                {
                    context.GameConsoles.Add(new GameConsole()
                    {
                        GameConsoleTypeId = 1
                    });

                    context.GameConsoles.Add(new GameConsole()
                    {
                        GameConsoleTypeId = 2
                    });

                    context.SaveChanges();
                }
                catch
                {
                    throw new Exception($"Error when adding {nameof(context.GameConsoles)}");
                }
            }

            if (!context.Tables.Any())
            {
                try
                {
                    context.Tables.Add(new Table()
                    {
                        Identifier = "Kubrik",
                        SeatingCapacity = 2,
                        DepartamentId = 1,
                        CreateDateTime = DateTime.Now,
                        GameConsoleId = 1
                    });

                    context.Tables.Add(new Table()
                    {
                        Identifier = "LV114",
                        SeatingCapacity = 4,
                        DepartamentId = 2,
                        CreateDateTime = DateTime.Now,
                        GameConsoleId = 2
                    });

                    context.SaveChanges();
                }
                catch
                {
                    throw new Exception($"Error when adding {nameof(context.Tables)}");
                }
            }

            if (!context.Orders.Any())
            {
                try
                {
                    context.Orders.Add(new Order()
                    {
                        TableId = 1,
                        EmployeeId = 1,
                        CreateDateTime = DateTime.Now
                    });

                    context.Orders.Add(new Order()
                    {
                        TableId = 2,
                        EmployeeId = 2,
                        CreateDateTime = DateTime.Now
                    });

                    context.SaveChanges();
                }
                catch
                {
                    throw new Exception($"Error when adding {nameof(context.Orders)}");
                }
            }

            if (!context.OnlineTableReservations.Any())
            {
                try
                {
                    context.OnlineTableReservations.Add(new OnlineTableReservation()
                    {
                        TableId = 1,
                        UserId = 1,
                        ReservationDateTime = new DateTime(2020, 03, 04, 18, 0, 0),
                        CreateDateTime = DateTime.Now
                    });

                    context.OnlineTableReservations.Add(new OnlineTableReservation()
                    {
                        TableId = 2,
                        UserId = 2,
                        ReservationDateTime = new DateTime(2016, 9, 3, 21, 15, 0, 0),
                        CreateDateTime = DateTime.Now
                    });

                    context.SaveChanges();
                }
                catch
                {
                    throw new Exception($"Error when adding {nameof(context.OnlineTableReservations)}");
                }
            }

            if (!context.OfflineTableReservations.Any())
            {
                try
                {
                    context.OfflineTableReservations.Add(new OfflineTableReservation()
                    {
                        TableId = 1,
                        ClientName = "Dima",
                        ClientPhoneNumber = "380635556451",
                        EmployeeId = 1,
                        ReservationDateTime = new DateTime(2016, 2, 7, 14, 0, 0),
                        CreateDateTime = DateTime.Now
                    });

                    context.OfflineTableReservations.Add(new OfflineTableReservation()
                    {
                        TableId = 2,
                        ClientName = "Arsen",
                        ClientPhoneNumber = "380395552129",
                        EmployeeId = 2,
                        ReservationDateTime = new DateTime(2020, 8, 2, 23, 0, 0),
                        CreateDateTime = DateTime.Now
                    });

                    context.SaveChanges();
                }
                catch
                {
                    throw new Exception($"Error when adding {nameof(context.OfflineTableReservations)}");
                }
            }
        }
    }
}
