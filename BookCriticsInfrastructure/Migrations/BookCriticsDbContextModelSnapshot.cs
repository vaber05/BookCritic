﻿// <auto-generated />
using System;
using BookCriticsInfrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookCriticsInfrastructure.Migrations
{
    [DbContext(typeof(BookCriticsDbContext))]
    partial class BookCriticsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BookCriticsDomain.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateAdded")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfPages")
                        .HasColumnType("int");

                    b.Property<int>("ReleaseYear")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("BookCriticsDomain.Models.BookInGenre", b =>
                {
                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.HasKey("GenreId", "BookId");

                    b.HasIndex("BookId");

                    b.ToTable("BookInGenres");
                });

            modelBuilder.Entity("BookCriticsDomain.Models.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GenreId"));

                    b.Property<string>("GenreName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GenreId");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            GenreId = 1,
                            GenreName = "Poetry"
                        },
                        new
                        {
                            GenreId = 2,
                            GenreName = "Fiction"
                        },
                        new
                        {
                            GenreId = 3,
                            GenreName = "Nonfiction"
                        },
                        new
                        {
                            GenreId = 4,
                            GenreName = "Drama"
                        },
                        new
                        {
                            GenreId = 5,
                            GenreName = "Prose"
                        },
                        new
                        {
                            GenreId = 6,
                            GenreName = "ShortStory"
                        },
                        new
                        {
                            GenreId = 7,
                            GenreName = "Romanticism"
                        },
                        new
                        {
                            GenreId = 8,
                            GenreName = "Biography"
                        },
                        new
                        {
                            GenreId = 9,
                            GenreName = "Novel"
                        },
                        new
                        {
                            GenreId = 10,
                            GenreName = "Fantasy"
                        },
                        new
                        {
                            GenreId = 11,
                            GenreName = "ScienceFiction"
                        },
                        new
                        {
                            GenreId = 12,
                            GenreName = "HistoricalFiction"
                        },
                        new
                        {
                            GenreId = 13,
                            GenreName = "Autobiography"
                        },
                        new
                        {
                            GenreId = 14,
                            GenreName = "Mystery"
                        },
                        new
                        {
                            GenreId = 15,
                            GenreName = "FairyTale"
                        },
                        new
                        {
                            GenreId = 16,
                            GenreName = "Horror"
                        },
                        new
                        {
                            GenreId = 17,
                            GenreName = "Comedy"
                        },
                        new
                        {
                            GenreId = 18,
                            GenreName = "Fable"
                        },
                        new
                        {
                            GenreId = 19,
                            GenreName = "NarrativeNonfiction"
                        },
                        new
                        {
                            GenreId = 20,
                            GenreName = "MagicalRealism"
                        },
                        new
                        {
                            GenreId = 21,
                            GenreName = "LiteraryFiction"
                        },
                        new
                        {
                            GenreId = 22,
                            GenreName = "Narrative"
                        },
                        new
                        {
                            GenreId = 23,
                            GenreName = "Novella"
                        },
                        new
                        {
                            GenreId = 24,
                            GenreName = "Satire"
                        });
                });

            modelBuilder.Entity("BookCriticsDomain.Models.Rating", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<float>("RatingValue")
                        .HasColumnType("real");

                    b.HasKey("UserId", "BookId");

                    b.HasIndex("BookId");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("BookCriticsDomain.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsPositive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<int>("NumberOfLikes")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("BookCriticsDomain.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            RoleName = "Default"
                        },
                        new
                        {
                            Id = 2,
                            RoleName = "Admin"
                        });
                });

            modelBuilder.Entity("BookCriticsDomain.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastLoggin")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BookCriticsDomain.Models.UserInRole", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.ToTable("UserInRoles");
                });

            modelBuilder.Entity("BookCriticsDomain.Models.UserLikedBook", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "BookId");

                    b.HasIndex("BookId");

                    b.ToTable("UserLikedBooks");
                });

            modelBuilder.Entity("BookCriticsDomain.Models.UserLikedReview", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("ReviewId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "ReviewId");

                    b.ToTable("UserLikedReviews");
                });

            modelBuilder.Entity("BookCriticsDomain.Models.BookInGenre", b =>
                {
                    b.HasOne("BookCriticsDomain.Models.Book", null)
                        .WithMany("Genres")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookCriticsDomain.Models.Rating", b =>
                {
                    b.HasOne("BookCriticsDomain.Models.Book", null)
                        .WithMany("Ratings")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookCriticsDomain.Models.User", null)
                        .WithMany("RatingsMade")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookCriticsDomain.Models.Review", b =>
                {
                    b.HasOne("BookCriticsDomain.Models.Book", null)
                        .WithMany("Reviews")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookCriticsDomain.Models.User", null)
                        .WithMany("WrittenReviews")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookCriticsDomain.Models.UserInRole", b =>
                {
                    b.HasOne("BookCriticsDomain.Models.User", null)
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookCriticsDomain.Models.UserLikedBook", b =>
                {
                    b.HasOne("BookCriticsDomain.Models.Book", null)
                        .WithMany("LikedByUsers")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookCriticsDomain.Models.User", null)
                        .WithMany("LikedBooks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookCriticsDomain.Models.UserLikedReview", b =>
                {
                    b.HasOne("BookCriticsDomain.Models.User", null)
                        .WithMany("LikedReviews")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookCriticsDomain.Models.Book", b =>
                {
                    b.Navigation("Genres");

                    b.Navigation("LikedByUsers");

                    b.Navigation("Ratings");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("BookCriticsDomain.Models.User", b =>
                {
                    b.Navigation("LikedBooks");

                    b.Navigation("LikedReviews");

                    b.Navigation("RatingsMade");

                    b.Navigation("Roles");

                    b.Navigation("WrittenReviews");
                });
#pragma warning restore 612, 618
        }
    }
}
