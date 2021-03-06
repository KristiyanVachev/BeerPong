﻿using System.Data.Entity;
using BeerPong.Data.Migrations;
using BeerPong.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BeerPong.Data
{
    public class BeerPongDbContext : IdentityDbContext<User>, IBeerPongDbContext
    {
        public BeerPongDbContext(): base("BeerPongDb")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<BeerPongDbContext, Configuration>());
        }

        public static BeerPongDbContext Create()
        {
            return new BeerPongDbContext();
        }

        public virtual IDbSet<Player> Players { get; set; }

        public virtual IDbSet<Team> Teams { get; set; }

        public virtual IDbSet<Game> Games { get; set; }

        public virtual IDbSet<Tourney> Tourneys { get; set; }
    }

    public interface IBeerPongDbContext
    {
        IDbSet<Player> Players { get; }

        IDbSet<Team> Teams { get; }

        IDbSet<Game> Games { get; }

        IDbSet<Tourney> Tourneys { get; }

        int SaveCanges();
    }
}
