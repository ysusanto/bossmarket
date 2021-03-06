// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using bossmarket.Helpers;

#nullable disable

namespace bossmarket.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("bossmarket.Entities.Brands", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PathImage")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("bossmarket.Entities.Categori", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("bossmarket.Entities.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("BrandsId")
                        .HasColumnType("int");

                    b.Property<int?>("CategoriId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<sbyte>("IsActive")
                        .HasColumnType("tinyint");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PathImage")
                        .HasColumnType("longtext");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int?>("SatuanId")
                        .HasColumnType("int");

                    b.Property<string>("Sku")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BrandsId");

                    b.HasIndex("CategoriId");

                    b.HasIndex("SatuanId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("bossmarket.Entities.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CodePayment")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PathImage")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("bossmarket.Entities.Satuan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Satuans");
                });

            modelBuilder.Entity("bossmarket.Entities.StatusOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("StatusOrders");
                });

            modelBuilder.Entity("bossmarket.Entities.StatusPayment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("StatusPayments");
                });

            modelBuilder.Entity("bossmarket.Entities.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CodeTransaction")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Customers")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("Disc")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("GrandTotal")
                        .HasColumnType("decimal(65,30)");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("PPN")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int?>("PaymentId")
                        .HasColumnType("int");

                    b.Property<int?>("StatusOrderId")
                        .HasColumnType("int");

                    b.Property<int?>("StatusPaymentId")
                        .HasColumnType("int");

                    b.Property<decimal>("SubTotal")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int?>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PaymentId");

                    b.HasIndex("StatusOrderId");

                    b.HasIndex("StatusPaymentId");

                    b.HasIndex("UsersId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("bossmarket.Entities.TransactionDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("LotCode")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("Qty")
                        .HasColumnType("int");

                    b.Property<int?>("TransactionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TransactionId");

                    b.ToTable("TransactionDetails");
                });

            modelBuilder.Entity("bossmarket.Entities.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ItemTransactionDetail", b =>
                {
                    b.Property<int>("ItemsId")
                        .HasColumnType("int");

                    b.Property<int>("TransactionDetailsId")
                        .HasColumnType("int");

                    b.HasKey("ItemsId", "TransactionDetailsId");

                    b.HasIndex("TransactionDetailsId");

                    b.ToTable("ItemTransactionDetail");
                });

            modelBuilder.Entity("bossmarket.Entities.Item", b =>
                {
                    b.HasOne("bossmarket.Entities.Brands", null)
                        .WithMany("Items")
                        .HasForeignKey("BrandsId");

                    b.HasOne("bossmarket.Entities.Categori", null)
                        .WithMany("Items")
                        .HasForeignKey("CategoriId");

                    b.HasOne("bossmarket.Entities.Satuan", null)
                        .WithMany("Items")
                        .HasForeignKey("SatuanId");
                });

            modelBuilder.Entity("bossmarket.Entities.Transaction", b =>
                {
                    b.HasOne("bossmarket.Entities.Payment", null)
                        .WithMany("Transactions")
                        .HasForeignKey("PaymentId");

                    b.HasOne("bossmarket.Entities.StatusOrder", null)
                        .WithMany("Transactions")
                        .HasForeignKey("StatusOrderId");

                    b.HasOne("bossmarket.Entities.StatusPayment", null)
                        .WithMany("Transactions")
                        .HasForeignKey("StatusPaymentId");

                    b.HasOne("bossmarket.Entities.Users", null)
                        .WithMany("Transactions")
                        .HasForeignKey("UsersId");
                });

            modelBuilder.Entity("bossmarket.Entities.TransactionDetail", b =>
                {
                    b.HasOne("bossmarket.Entities.Transaction", null)
                        .WithMany("TransactionDetails")
                        .HasForeignKey("TransactionId");
                });

            modelBuilder.Entity("bossmarket.Entities.Users", b =>
                {
                    b.OwnsMany("bossmarket.Entities.RefreshToken", "RefreshTokens", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            b1.Property<DateTime>("Created")
                                .HasColumnType("datetime(6)");

                            b1.Property<string>("CreatedByIp")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.Property<DateTime>("Expires")
                                .HasColumnType("datetime(6)");

                            b1.Property<string>("ReasonRevoked")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.Property<string>("ReplacedByToken")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.Property<DateTime?>("Revoked")
                                .HasColumnType("datetime(6)");

                            b1.Property<string>("RevokedByIp")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.Property<string>("Token")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.Property<int>("UsersId")
                                .HasColumnType("int");

                            b1.HasKey("Id");

                            b1.HasIndex("UsersId");

                            b1.ToTable("RefreshToken");

                            b1.WithOwner()
                                .HasForeignKey("UsersId");
                        });

                    b.Navigation("RefreshTokens");
                });

            modelBuilder.Entity("ItemTransactionDetail", b =>
                {
                    b.HasOne("bossmarket.Entities.Item", null)
                        .WithMany()
                        .HasForeignKey("ItemsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("bossmarket.Entities.TransactionDetail", null)
                        .WithMany()
                        .HasForeignKey("TransactionDetailsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("bossmarket.Entities.Brands", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("bossmarket.Entities.Categori", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("bossmarket.Entities.Payment", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("bossmarket.Entities.Satuan", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("bossmarket.Entities.StatusOrder", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("bossmarket.Entities.StatusPayment", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("bossmarket.Entities.Transaction", b =>
                {
                    b.Navigation("TransactionDetails");
                });

            modelBuilder.Entity("bossmarket.Entities.Users", b =>
                {
                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
