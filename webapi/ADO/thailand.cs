namespace webapi.ADO
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class thailand : DbContext
    {
        public thailand()
            : base("name=thailand")
        {
        }

        public virtual DbSet<amphur> amphurs { get; set; }
        public virtual DbSet<district> districts { get; set; }
        public virtual DbSet<geography> geographies { get; set; }
        public virtual DbSet<person> people { get; set; }
        public virtual DbSet<person_th> person_th { get; set; }
        public virtual DbSet<province> provinces { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<amphur>()
                .Property(e => e.AMPHUR_CODE)
                .IsUnicode(false);

            modelBuilder.Entity<amphur>()
                .Property(e => e.AMPHUR_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<amphur>()
                .Property(e => e.AMPHUR_NAME_ENG)
                .IsUnicode(false);

            modelBuilder.Entity<amphur>()
                .Property(e => e.POSTCODE)
                .IsUnicode(false);

            modelBuilder.Entity<district>()
                .Property(e => e.DISTRICT_CODE)
                .IsUnicode(false);

            modelBuilder.Entity<district>()
                .Property(e => e.DISTRICT_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<geography>()
                .Property(e => e.GEO_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<person>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<person>()
                .Property(e => e.lastname)
                .IsUnicode(false);

            modelBuilder.Entity<person>()
                .Property(e => e.nick_name)
                .IsUnicode(false);

            modelBuilder.Entity<person>()
                .Property(e => e.gender)
                .IsUnicode(false);

            modelBuilder.Entity<person>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<person>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<person>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<person>()
                .Property(e => e.education)
                .IsUnicode(false);

            modelBuilder.Entity<person>()
                .Property(e => e.career)
                .IsUnicode(false);

            modelBuilder.Entity<province>()
                .Property(e => e.PROVINCE_CODE)
                .IsUnicode(false);

            modelBuilder.Entity<province>()
                .Property(e => e.PROVINCE_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<province>()
                .Property(e => e.PROVINCE_NAME_ENG)
                .IsUnicode(false);
        }
    }
}
