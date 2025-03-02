﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TabletopConnect.Persistence.Database;

#nullable disable

namespace TabletopConnect.Persistence.Migrations
{
    [DbContext(typeof(TabletopDbContext))]
    [Migration("20250302125824_UpdateMechanicsColumnName")]
    partial class UpdateMechanicsColumnName
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate.BoardGame", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ExpansionForId")
                        .HasColumnType("int");

                    b.Property<int?>("FamilyId")
                        .HasColumnType("int");

                    b.Property<double>("GameComplexity")
                        .HasPrecision(18, 2)
                        .HasColumnType("float(18)");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsReimplementation")
                        .HasColumnType("bit");

                    b.Property<int>("LanguageDependence")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("YearPublished")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FamilyId");

                    b.ToTable("BoardGames", (string)null);
                });

            modelBuilder.Entity("TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate.BoardGameCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BggPosition")
                        .HasColumnType("int");

                    b.Property<int>("BoardGameId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BoardGameId");

                    b.HasIndex("CategoryId");

                    b.ToTable("BoardGameCategories", (string)null);
                });

            modelBuilder.Entity("TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate.BoardGameDesigner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BoardGameId")
                        .HasColumnType("int");

                    b.Property<int>("DesignerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BoardGameId");

                    b.HasIndex("DesignerId");

                    b.ToTable("BoardGameDesigners", (string)null);
                });

            modelBuilder.Entity("TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate.BoardGameMechanics", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BoardGameId")
                        .HasColumnType("int");

                    b.Property<int>("MechanicsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BoardGameId");

                    b.HasIndex("MechanicsId");

                    b.ToTable("BoardGameMechanics", (string)null);
                });

            modelBuilder.Entity("TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate.BoardGamePublisher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BoardGameId")
                        .HasColumnType("int");

                    b.Property<int>("PublisherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BoardGameId");

                    b.HasIndex("PublisherId");

                    b.ToTable("BoardGamePublishers", (string)null);
                });

            modelBuilder.Entity("TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate.BoardGameSubcategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BoardGameId")
                        .HasColumnType("int");

                    b.Property<int>("SubcategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BoardGameId");

                    b.HasIndex("SubcategoryId");

                    b.ToTable("BoardGameSubcategories", (string)null);
                });

            modelBuilder.Entity("TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate.BoardGameTheme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BoardGameId")
                        .HasColumnType("int");

                    b.Property<int>("ThemeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BoardGameId");

                    b.HasIndex("ThemeId");

                    b.ToTable("BoardGameThemes", (string)null);
                });

            modelBuilder.Entity("TabletopConnect.Domain.Entities.Aggregates.PlayerProfile.PlayerProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AvatarUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Bio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nickname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("PlayerProfiles", (string)null);
                });

            modelBuilder.Entity("TabletopConnect.Domain.Entities.Classifiers.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories", (string)null);
                });

            modelBuilder.Entity("TabletopConnect.Domain.Entities.Classifiers.Designer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Designers", (string)null);
                });

            modelBuilder.Entity("TabletopConnect.Domain.Entities.Classifiers.Family", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Families", (string)null);
                });

            modelBuilder.Entity("TabletopConnect.Domain.Entities.Classifiers.Mechanics", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Mechanics", (string)null);
                });

            modelBuilder.Entity("TabletopConnect.Domain.Entities.Classifiers.Publisher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Publishers", (string)null);
                });

            modelBuilder.Entity("TabletopConnect.Domain.Entities.Classifiers.Subcategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Subcategories", (string)null);
                });

            modelBuilder.Entity("TabletopConnect.Domain.Entities.Classifiers.Theme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Themes", (string)null);
                });

            modelBuilder.Entity("TabletopConnect.Domain.Entities.IAM.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("GoogleId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsEmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("GoogleId")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate.BoardGame", b =>
                {
                    b.HasOne("TabletopConnect.Domain.Entities.Classifiers.Family", null)
                        .WithMany()
                        .HasForeignKey("FamilyId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.OwnsOne("TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate.BggData", "BggData", b1 =>
                        {
                            b1.Property<int>("BoardGameId")
                                .HasColumnType("int");

                            b1.Property<double>("AverageRating")
                                .HasPrecision(18, 2)
                                .HasColumnType("float(18)");

                            b1.Property<int>("BggId")
                                .HasColumnType("int");

                            b1.Property<double>("BggScore")
                                .HasPrecision(18, 2)
                                .HasColumnType("float(18)");

                            b1.Property<int>("NumberOwned")
                                .HasColumnType("int");

                            b1.Property<int>("NumberWanted")
                                .HasColumnType("int");

                            b1.Property<int>("NumberWeightVotes")
                                .HasColumnType("int");

                            b1.Property<int>("NumberWished")
                                .HasColumnType("int");

                            b1.Property<int>("RankOverall")
                                .HasColumnType("int");

                            b1.HasKey("BoardGameId");

                            b1.ToTable("BoardGames");

                            b1.WithOwner()
                                .HasForeignKey("BoardGameId");
                        });

                    b.OwnsOne("TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate.PlayTime", "PlayTime", b1 =>
                        {
                            b1.Property<int>("BoardGameId")
                                .HasColumnType("int");

                            b1.Property<int?>("CommunityMaxPlayTime")
                                .HasColumnType("int");

                            b1.Property<int?>("CommunityMinPlayTime")
                                .HasColumnType("int");

                            b1.Property<int>("ManufacturerStatedPlayTime")
                                .HasColumnType("int");

                            b1.HasKey("BoardGameId");

                            b1.ToTable("BoardGames");

                            b1.WithOwner()
                                .HasForeignKey("BoardGameId");
                        });

                    b.OwnsOne("TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate.Players", "Players", b1 =>
                        {
                            b1.Property<int>("BoardGameId")
                                .HasColumnType("int");

                            b1.Property<int?>("BestPlayers")
                                .HasColumnType("int");

                            b1.Property<int>("MaxPlayers")
                                .HasColumnType("int");

                            b1.Property<int>("MinPlayers")
                                .HasColumnType("int");

                            b1.Property<string>("_goodPlayers")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("BoardGameId");

                            b1.ToTable("BoardGames");

                            b1.WithOwner()
                                .HasForeignKey("BoardGameId");
                        });

                    b.OwnsOne("TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate.RecommendedAge", "RecommendedAge", b1 =>
                        {
                            b1.Property<int>("BoardGameId")
                                .HasColumnType("int");

                            b1.Property<int?>("CommunityRecomended")
                                .HasColumnType("int");

                            b1.Property<int>("ManufacturerRecomended")
                                .HasColumnType("int");

                            b1.HasKey("BoardGameId");

                            b1.ToTable("BoardGames");

                            b1.WithOwner()
                                .HasForeignKey("BoardGameId");
                        });

                    b.Navigation("BggData");

                    b.Navigation("PlayTime")
                        .IsRequired();

                    b.Navigation("Players")
                        .IsRequired();

                    b.Navigation("RecommendedAge")
                        .IsRequired();
                });

            modelBuilder.Entity("TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate.BoardGameCategory", b =>
                {
                    b.HasOne("TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate.BoardGame", null)
                        .WithMany("BoardGameCategories")
                        .HasForeignKey("BoardGameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TabletopConnect.Domain.Entities.Classifiers.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate.BoardGameDesigner", b =>
                {
                    b.HasOne("TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate.BoardGame", null)
                        .WithMany("BoardGameDesigners")
                        .HasForeignKey("BoardGameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TabletopConnect.Domain.Entities.Classifiers.Designer", null)
                        .WithMany()
                        .HasForeignKey("DesignerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate.BoardGameMechanics", b =>
                {
                    b.HasOne("TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate.BoardGame", null)
                        .WithMany("BoardGameMechanics")
                        .HasForeignKey("BoardGameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TabletopConnect.Domain.Entities.Classifiers.Mechanics", null)
                        .WithMany()
                        .HasForeignKey("MechanicsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate.BoardGamePublisher", b =>
                {
                    b.HasOne("TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate.BoardGame", null)
                        .WithMany("BoardGamePublishers")
                        .HasForeignKey("BoardGameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TabletopConnect.Domain.Entities.Classifiers.Publisher", null)
                        .WithMany()
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate.BoardGameSubcategory", b =>
                {
                    b.HasOne("TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate.BoardGame", null)
                        .WithMany("BoardGameSubcategories")
                        .HasForeignKey("BoardGameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TabletopConnect.Domain.Entities.Classifiers.Subcategory", null)
                        .WithMany()
                        .HasForeignKey("SubcategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate.BoardGameTheme", b =>
                {
                    b.HasOne("TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate.BoardGame", null)
                        .WithMany("BoardGameThemes")
                        .HasForeignKey("BoardGameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TabletopConnect.Domain.Entities.Classifiers.Theme", null)
                        .WithMany()
                        .HasForeignKey("ThemeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TabletopConnect.Domain.Entities.Aggregates.PlayerProfile.PlayerProfile", b =>
                {
                    b.HasOne("TabletopConnect.Domain.Entities.IAM.User", null)
                        .WithOne()
                        .HasForeignKey("TabletopConnect.Domain.Entities.Aggregates.PlayerProfile.PlayerProfile", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TabletopConnect.Domain.Entities.Aggregates.BoardGameAggregate.BoardGame", b =>
                {
                    b.Navigation("BoardGameCategories");

                    b.Navigation("BoardGameDesigners");

                    b.Navigation("BoardGameMechanics");

                    b.Navigation("BoardGamePublishers");

                    b.Navigation("BoardGameSubcategories");

                    b.Navigation("BoardGameThemes");
                });
#pragma warning restore 612, 618
        }
    }
}
