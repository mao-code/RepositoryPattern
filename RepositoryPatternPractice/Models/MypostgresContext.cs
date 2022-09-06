using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RepositoryPatternPractice.Models
{
    public partial class MypostgresContext : DbContext
    {
        public MypostgresContext()
        {
        }

        public MypostgresContext(DbContextOptions<MypostgresContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; } = null!;
        public virtual DbSet<Book> Books { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Database=Mypostgres;Username=postgres;Password=root");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(entity =>
            {
                entity.ToTable("Author");

                entity.Property(e => e.AuthorId)
                    .HasColumnName("author_id")
                    .HasDefaultValueSql("nextval('author_author_id_seq'::regclass)");

                entity.Property(e => e.AuthorName)
                    .HasColumnType("character varying")
                    .HasColumnName("author_name");
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("Book");

                entity.Property(e => e.BookId)
                    .HasColumnName("book_id")
                    .HasDefaultValueSql("nextval('book_bookid_seq'::regclass)");

                entity.Property(e => e.AuthorId).HasColumnName("author_id");

                entity.Property(e => e.BookName)
                    .HasColumnType("character varying")
                    .HasColumnName("book_name");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("book_fk");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
