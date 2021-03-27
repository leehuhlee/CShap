using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;

namespace MMO_EFCore
{
    class DbCommands
    {
        public static void InitializeDB(bool forceReset = false)
        {
            using (AppDbContext db = new AppDbContext())
            {
                if (!forceReset && (db.GetService<IDatabaseCreator>() as RelationalDatabaseCreator).Exists())
                    return;

                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                string command =
                    @" CREATE FUNCTION GetAverageReviewScore (@itemId INT) RETURNS FLOAT
                       AS
                       BEGIN

                       DECLARE @result AS FLOAT

                       SELECT @result = AVG(CAST([Score] AS FLOAT))
                       FROM ItemReview AS r
                       WHERE @itemId = r.ItemId

                       RETURN @result

                       END";

                db.Database.ExecuteSqlRaw(command);

                CreateTestData(db);
                Console.WriteLine("DB Initialized");

            }
        }

        public static void CreateTestData(AppDbContext db)
        {
            var hanna = new Player() { Name = "Hanna" };
            //var hanna = new Player() { };
            var faker = new Player() { Name = "Faker" };
            var deft = new Player() { Name = "Deft" };


            // Console.WriteLine(db.Entry(hanna).State);

            List<Item> items = new List<Item>()
            {
                new Item()
                {
                    TemplateId = 101,
                    //CreateDate = DateTime.Now,
                    Owner = hanna
                },
                //new EventItem()
                new Item()
                {
                    TemplateId = 102,
                    //CreateDate = DateTime.Now,
                    Owner = faker,
                    //DestroyDate =  DateTime.Now
                },
                new Item()
                {
                    TemplateId = 103,
                    //CreateDate = DateTime.Now,
                    Owner = deft
                }
            };

            //db.Entry(items[2]).Property("RecoveredDate").CurrentValue = DateTime.Now;

            //items[1].SetOption(new ItemOption() { dex = 1, hp = 2, str = 3 });

            //items[1].Option = new ItemOption() { Dex = 1, Hp = 2, Str = 3 };

            //items[2].Detail = new ItemDetail()
            //{
            //    Description = "This is a good item."
            //};

            //items[0].AddReview(new ItemReview() { Score = 5 });
            //items[0].AddReview(new ItemReview() { Score = 4 });
            //items[0].AddReview(new ItemReview() { Score = 1 });
            //items[0].AddReview(new ItemReview() { Score = 5 });

            //items[0].Reviews = new List<ItemReview>()
            //{
            //    new ItemReview(){Score = 5},
            //    new ItemReview(){Score = 3},
            //    new ItemReview(){Score = 2},
            //};

            //items[1].Reviews = new List<ItemReview>()
            //{
            //    new ItemReview(){Score = 1},
            //    new ItemReview(){Score = 1},
            //    new ItemReview(){Score = 0},
            //};

            Guild guild = new Guild()
            {
                GuildName = "T1",
                Members = new List<Player>() { hanna, faker, deft }
            };

            // db.Players.Add(hanna);
            db.Items.AddRange(items);
            db.Guilds.Add(guild);

            //Console.WriteLine("1.)" + db.Entry(hanna).State);

            //db.SaveChanges();

            //{
            //    Item item = new Item()
            //    {
            //        TemplateId = 500,
            //        Owner = hanna
            //    };
            //    db.Items.Add(item);

            //    Console.WriteLine("2.)" + db.Entry(hanna).State);
            //}

            //// Delete Test
            //{
            //    Player p = db.Players.First();
            //    p.Guild = new Guild() { GuildName = "This will be deleted Soon" };
            //    p.OwnedItem = items[0];

            //    db.Players.Remove(p);

            //    // remove Player directly
            //    Console.WriteLine("3.)" + db.Entry(p).State); // Deleted
            //    Console.WriteLine("4.)" + db.Entry(p.Guild).State); // Added
            //    Console.WriteLine("5.)" + db.Entry(p.OwnedItem).State); // Deleted
            //}

            //Console.WriteLine(db.Entry(hanna).State);
            //Console.WriteLine(hanna.PlayerId);

            db.SaveChanges();

            //{
            //    var owner = db.Players.Where(p => p.Name == "Hanna").First();

            //    Item item = new Item()
            //    {
            //        TemplateId = 300,
            //        CreateDate = DateTime.Now,
            //        Owner = owner
            //    };
            //    db.Items.Add(item);
            //    db.SaveChanges();
            //}

            //Console.WriteLine(db.Entry(hanna).State);
            //Console.WriteLine(hanna.PlayerId);

        }

        public static void ReadAll()
        {
            using (var db = new AppDbContext())
            {
                foreach (Item item in db.Items.AsNoTracking().Include(i => i.Owner))
                {
                    Console.WriteLine($"TemplateId({item.TemplateId}) Owner({item.Owner.Name}) Created({item.CreateDate})");

                }
            }
        }

        //public static void UpdateDate()
        //{
        //    Console.WriteLine("Input Player Name");
        //    Console.Write("> ");
        //    string name = Console.ReadLine();

        //    using(var db = new AppDbContext())
        //    {
        //        var items = db.Items.Include(i => i.Owner)
        //            .Where(i => i.Owner.Name == name);

        //        foreach(Item item in items)
        //        {
        //            item.CreateDate = DateTime.Now;
        //        }

        //        db.SaveChanges();
        //    }

        //    ReadAll();
        //}

        public static void DeleteItem()
        {
            Console.WriteLine("Input Player Name");
            Console.Write("> ");
            string name = Console.ReadLine();

            using (var db = new AppDbContext())
            {
                var items = db.Items.Include(i => i.Owner)
                    .Where(i => i.Owner.Name == name);

                db.Items.RemoveRange(items);

                db.SaveChanges();
            }

            ReadAll();
        }

        public static void ShowItems()
        {
            Console.WriteLine("Input Player Name");
            Console.Write("> ");
            string name = Console.ReadLine();

            //using(var db = new AppDbContext())
            //{
            //    foreach(Player player in db.Players.AsNoTracking().Where(p => p.Name == name).Include(p => p.Items))
            //    {
            //        foreach(Item item in player.Items)
            //        {
            //            Console.WriteLine($"{item.TemplateId}");
            //        }
            //    }
            //}
        }

        //public static void EagerLoading()
        //{
        //    Console.WriteLine("Input Guild Name");
        //    Console.Write("> ");
        //    string name = Console.ReadLine();

        //    using(var db = new AppDbContext())
        //    {
        //        Guild guild = db.Guilds.AsNoTracking()
        //            .Where(g => g.GuildName == name)
        //            .Include(g => g.Members)
        //                .ThenInclude(p => p.Item)
        //            .First();

        //        foreach(Player player in guild.Members)
        //        {
        //            Console.WriteLine($"TemplateId({player.Item.TemplateId}) Owner({player.Name})");
        //        }
        //    }
        //}

        //public static void ExplicitLoading()
        //{
        //    Console.WriteLine("Input Guild Name");
        //    Console.Write("> ");
        //    string name = Console.ReadLine();

        //    using (var db = new AppDbContext())
        //    {
        //        Guild guild = db.Guilds
        //            .Where(g => g.GuildName == name)
        //            .First();

        //        // Explicitly
        //        db.Entry(guild).Collection(g => g.Members).Load();

        //        foreach(Player player in guild.Members)
        //        {
        //            db.Entry(player).Reference(p => p.Item).Load();
        //        }

        //        foreach (Player player in guild.Members)
        //        {
        //            Console.WriteLine($"TemplateId({player.Item.TemplateId}) Owner({player.Name})");
        //        }
        //    }
        //}

        public static void SelectLoading()
        {
            Console.WriteLine("Input Guild Name");
            Console.Write("> ");
            string name = Console.ReadLine();

            using (var db = new AppDbContext())
            {
                var info = db.Guilds
                    .Where(g => g.GuildName == name)
                    .MapGuildToDto()
                    .First();

                Console.WriteLine($"GuildName({info.Name}), MemberCount({info.MemberCount})");
            }
        }

        public static void UpdateTest()
        {
            using (AppDbContext db = new AppDbContext())
            {
                var guild = db.Guilds.Single(g => g.GuildName == "T1");

                guild.GuildName = "DWG";

                db.SaveChanges();
            }
        }

        public static void ShowGuilds()
        {
            using (AppDbContext db = new AppDbContext())
            {
                foreach (var guild in db.Guilds.MapGuildToDto().ToList())
                {
                    Console.WriteLine($"GuildID({guild.GuildId}) GuildName({guild.Name}) MemberCount({guild.MemberCount})");
                }

            }
        }


        public static void UpdateByReload()
        {
            ShowGuilds();

            Console.WriteLine("Input GuildId");
            Console.Write("> ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Input GuildNames");
            Console.Write("> ");
            string name = Console.ReadLine();

            using (AppDbContext db = new AppDbContext())
            {
                Guild guild = db.Find<Guild>(id);
                guild.GuildName = name;
                db.SaveChanges();
            }

            Console.WriteLine("----- Update Complete -----");
            ShowGuilds();
        }

        public static string MakeUpdateJsonStr()
        {
            var jsonStr = "{\"GuildId\":1, \"GuildName\":\"Hello\", \"Members\":null}";
            return jsonStr;
        }

        public static void UpdateByFull()
        {
            ShowGuilds();

            string jsonStr = MakeUpdateJsonStr();
            Guild guild = JsonConvert.DeserializeObject<Guild>(jsonStr);

            //Guild guild = new Guild()
            //{
            //    GuildId = 1,
            //    GuildName = "TestGuild"
            //};

            using (AppDbContext db = new AppDbContext())
            {
                db.Guilds.Update(guild);
                db.SaveChanges();
            }

            Console.WriteLine("----- Update Complete -----");
            ShowGuilds();
        }

        public static void ShowItem()
        {
            using (AppDbContext db = new AppDbContext())
            {
                //foreach (var item in db.Items.Include(i => i.Owner).Include(i => i.Detail).IgnoreQueryFilters().ToList())
                foreach (var item in db.Items.Include(i => i.Owner).IgnoreQueryFilters().ToList())
                {
                    if (item.SoftDeleted)
                    {
                        Console.WriteLine($"DELETED - ItemId({item.ItemId}) TemplateId({item.TemplateId}) Owner(0)");
                    }
                    else
                    {
                        //if (item.Option != null)
                        //    Console.WriteLine("STR " + item.Option.Str);

                        //item.Type == ItemType.EventItem
                        //EventItem eventItem = item as EventItem;
                        //if (eventItem != null)
                        //    Console.WriteLine("DestroyDate: " + eventItem.DestroyDate);

                        //if (item.Detail != null)
                        //    Console.WriteLine(item.Detail.Description);

                        //if(item.AverageScore == null)
                        //    Console.WriteLine("Score(None)");
                        //else
                        //    Console.WriteLine($"Score({item.AverageScore})");

                        if (item.Owner == null)
                            Console.WriteLine($"ItemId({item.ItemId}) TemplateId({item.TemplateId}) Owner(0)");
                        else
                            Console.WriteLine($"ItemId({item.ItemId}) TemplateId({item.TemplateId}) Owner({item.Owner.Name})");
                    }
                }
            }
        }

        //public static void Test()
        //{
        //    ShowItem();

        //    Console.WriteLine("Input Delete PlayerId");
        //    Console.Write("> ");
        //    int id = int.Parse(Console.ReadLine());

        //    using (AppDbContext db = new AppDbContext())
        //    {
        //        Player player = db.Players
        //            .Include(p => p.Item)
        //            .Single(p => p.PlayerId == id);

        //        db.Players.Remove(player);
        //        db.SaveChanges();
        //    }

        //    Console.WriteLine("----- Test Complete -----");
        //    ShowItem();
        //}

        // Update Realtionship 1v1
        //public static void Update_1v1()
        //{
        //    ShowItem();

        //    Console.WriteLine("Input ItemSwitch PlayerId");
        //    Console.Write("> ");
        //    int id = int.Parse(Console.ReadLine());

        //    using (AppDbContext db = new AppDbContext())
        //    {
        //        Player player = db.Players
        //            .Include(p => p.Item)
        //            .Single(p => p.PlayerId == id);

        //        if (player.Item != null)
        //        {
        //            player.Item.TemplateId = 888;
        //            player.Item.CreateDate = DateTime.Now;
        //        }

        //        //player.Item = new Item()
        //        //{
        //        //    TemplateId = 777,
        //        //    CreateDate = DateTime.Now
        //        //};

        //        db.SaveChanges();
        //    }

        //    Console.WriteLine("----- Test Complete -----");
        //    ShowItem();
        //}

        public static void ShowGuild()
        {
            using (AppDbContext db = new AppDbContext())
            {
                foreach (var guild in db.Guilds.Include(g => g.Members).ToList())
                {
                    Console.WriteLine($"GuildId({guild.GuildId}) GuildName({guild.GuildName}) MemberCount({guild.Members.Count})");
                }
            }
        }

        public static void Update_1vN()
        {
            ShowGuild();

            Console.WriteLine("Input GuildId");
            Console.Write("> ");
            int id = int.Parse(Console.ReadLine());

            using (AppDbContext db = new AppDbContext())
            {
                Guild guild = db.Guilds
                    .Include(g => g.Members)
                    .Single(g => g.GuildId == id);

                guild.Members = new List<Player>()
                {
                    new Player() {Name = "Dopa" }
                };

                //guild.Members.Add(new Player() { Name = "Dopa" });
                //guild.Members.Add(new Player() { Name = "Keria" });
                //guild.Members.Add(new Player() { Name = "Pyosik" });

                db.SaveChanges();
            }

            Console.WriteLine("----- Test Complete -----");
            ShowGuild();
        }


        public static void TestDelete()
        {
            ShowItem();
            Console.WriteLine("Select Delete ItemId");
            Console.Write("> ");
            int id = int.Parse(Console.ReadLine());

            using (AppDbContext db = new AppDbContext())
            {
                Item item = db.Items.Find(id);
                //db.Items.Remove(item);
                item.SoftDeleted = true;
                db.SaveChanges();
            }

            Console.WriteLine("----- Test Complete -----");
            ShowItem();
        }

        public static void CalcAverage()
        {
            using (AppDbContext db = new AppDbContext())
            {
                foreach (double? average in db.Items.Select(i => Program.GetAverageReviewScore(i.ItemId)))
                {
                    if (average == null)
                        Console.WriteLine("No Review!");
                    else
                        Console.WriteLine($"Average: {average.Value}");
                }
            }
        }

        public static void TestUpdateAttach()
        {
            using (AppDbContext db = new AppDbContext())
            {
                {
                    Player p = new Player();
                    p.PlayerId = 2;
                    p.Name = "FakerLegend";

                    p.Guild = new Guild() { GuildName = "Update Guild" };

                    Console.WriteLine("6) " + db.Entry(p.Guild).State); // Detached
                    db.Players.Update(p);
                    Console.WriteLine("7) " + db.Entry(p.Guild).State); // Added
                }

                {
                    Player p = new Player();

                    p.PlayerId = 3;
                    //p.Name = "DeftHero";
                    p.Guild = new Guild() { GuildName = "Update Guild" };

                    Console.WriteLine("8) " + db.Entry(p.Guild).State); // Detached
                    db.Players.Attach(p);

                    p.Name = "DeftHero";
                    Console.WriteLine("9) " + db.Entry(p.Guild).State); // Added
                }

                db.SaveChanges();
            }
        }

        public static void StateControl()
        {
            using (AppDbContext db = new AppDbContext())
            {
                {
                    Player p = new Player { Name = "StateTest" };
                    db.Entry(p).State = EntityState.Added; // change Tracked
                    // db.Players.Add(p);
                    db.SaveChanges();
                }

                {
                    Player p = new Player()
                    {
                        PlayerId = 2,
                        Name = "Faker_New",
                    };

                    p.OwnedItem = new Item() { TemplateId = 777 }; // item data
                    p.Guild = new Guild() { GuildName = "TrackGraphGuild" }; // guild data

                    db.ChangeTracker.TrackGraph(p, e =>
                    {
                        if(e.Entry.Entity is Player)
                        {
                            e.Entry.State = EntityState.Unchanged;
                            e.Entry.Property("Name").IsModified = true;
                        }
                        else if(e.Entry.Entity is Guild)
                        {
                            e.Entry.State = EntityState.Unchanged;
                        }
                        else if(e.Entry.Entity is Item)
                        {
                            e.Entry.State = EntityState.Unchanged;
                        }
                    });
                    db.SaveChanges();
                }
            }
        }

        public static void CallSQL()
        {
            using(AppDbContext db = new AppDbContext())
            {
                {
                    string name = "Hanna";


                    var list = db.Players
                        .FromSqlRaw("SELECT * FROM dbo.Player WHERE Name = {0}", name)
                        .Include(p => p.OwnedItem)
                        .ToList();

                    foreach(var p in list)
                    {
                        Console.WriteLine($"{p.Name} {p.PlayerId}");
                    }
                    
                    var list2 = db.Players
                        .FromSqlInterpolated($"SELECT * FROM dbo.Player WHERE Name = {name}");

                    foreach (var p in list2)
                    {
                        Console.WriteLine($"{p.Name} {p.PlayerId}");
                    }
                }

                {
                    Player p = db.Players.Single(p => p.Name == "Faker");
                    string prevName = "Faker";
                    string afterName = "Faker_New";
                    db.Database.ExecuteSqlInterpolated($"UPDATE dbo.Player SET Name={afterName} WHERE Name={prevName}");

                    db.Entry(p).Reload();
                }
            }
        }
    }
}