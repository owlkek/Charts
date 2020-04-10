using Charts.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Charts.DAL
{
	public class Context : DbContext
	{
		public virtual DbSet<Track> Track { get; set; }
		public virtual DbSet<Genre> Genre { get; set; }
		public virtual DbSet<SingerTrack> SingerTrack { get; set; }
		public virtual DbSet<Singer> Singer { get; set; }
		public virtual DbSet<GenreTrack> GenreTrack { get; set; }

		//public Context(DbContextOptions<Context> options) : base(options)
		//{
		//    Database.EnsureCreated();
		//}

		public Context()
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<SingerTrack>()
				.HasOne(sc => sc.Singer)
				.WithMany(x => x.SingerTracks)
				.HasForeignKey(x => x.IDSinger);

			modelBuilder.Entity<SingerTrack>()
				.HasOne(sc => sc.Track)
				.WithMany(x => x.SingerTrack)
				.HasForeignKey(x => x.IDTrack);

			modelBuilder.Entity<GenreTrack>()
				.HasOne(sc => sc.Genre)
				.WithMany(x => x.GenreTracks)
				.HasForeignKey(x => x.IDGenre);

			modelBuilder.Entity<GenreTrack>()
				.HasOne(sc => sc.Track)
				.WithMany(x => x.GenreTrack)
				.HasForeignKey(x => x.IDTrack);

		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			//optionsBuilder.UseSqlServer("Data Source=(localhost)\\mssqllocaldb;Database=express-mvp-db;Trusted_Connection=True;");
			//optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=helloappdb;Trusted_Connection=True;");
			optionsBuilder.UseSqlServer("Data Source=DESKTOP-AMH7F81;Initial Catalog=MusicChart;User ID=newlogin2;Password=password;");
			//optionsBuilder.UseSqlServer("Data Source=(192.168.0.15)\\MSSQLLocalDB;Initial Catalog=MusicCharts;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
		}
		//Data Source = (localdb)\MSSQLLocalDB;Initial Catalog = Charts; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False
	}
}