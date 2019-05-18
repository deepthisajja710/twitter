namespace DataAccess
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TweetContext : DbContext
    {
        public TweetContext()
            : base("name=TweetContext")
        {
        }

        public virtual DbSet<Follow> Follows { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Tweet> Tweets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Follow>()
                .Property(e => e.user_id)
                .IsUnicode(false);

            modelBuilder.Entity<Follow>()
                .Property(e => e.Follow_id)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.user_id)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.fullname)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.FOLLOWINGs1)
                .WithRequired(e => e.PERSON)
                .HasForeignKey(e => e.user_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.FOLLOWINGs1)
                .WithRequired(e => e.PERSON1)
                .HasForeignKey(e => e.Follow_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.FOLLOWINGs1)
                .WithRequired(e => e.PERSON1)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tweet>()
                .Property(e => e.user_id)
                .IsUnicode(false);

            modelBuilder.Entity<Tweet>()
                .Property(e => e.message)
                .IsUnicode(false);
        }
    }
}
