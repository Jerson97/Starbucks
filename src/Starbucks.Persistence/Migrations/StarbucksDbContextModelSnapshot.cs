﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Starbucks.Persistence;

#nullable disable

namespace Starbucks.Persistence.Migrations
{
    [DbContext(typeof(StarbucksDbContext))]
    partial class StarbucksDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.2");

            modelBuilder.Entity("Starbucks.Domain.Cafe", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("CategoriaId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<string>("Imagen")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Precio")
                        .HasPrecision(10, 2)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Cafes");
                });

            modelBuilder.Entity("Starbucks.Domain.CafeIngrediente", b =>
                {
                    b.Property<Guid>("CafeId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("IngredienteId")
                        .HasColumnType("TEXT");

                    b.HasKey("CafeId", "IngredienteId");

                    b.HasIndex("IngredienteId");

                    b.ToTable("CafeIngrediente");
                });

            modelBuilder.Entity("Starbucks.Domain.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Categorias");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nombre = "CafeHelado"
                        },
                        new
                        {
                            Id = 2,
                            Nombre = "CafeCaliente"
                        });
                });

            modelBuilder.Entity("Starbucks.Domain.Ingrediente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Ingredientes");
                });

            modelBuilder.Entity("Starbucks.Domain.Cafe", b =>
                {
                    b.HasOne("Starbucks.Domain.Categoria", "Categoria")
                        .WithMany("Cafes")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("Starbucks.Domain.CafeIngrediente", b =>
                {
                    b.HasOne("Starbucks.Domain.Cafe", "Cafe")
                        .WithMany("CafeIngredientes")
                        .HasForeignKey("CafeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Starbucks.Domain.Ingrediente", "Ingrediente")
                        .WithMany("CafeIngredientes")
                        .HasForeignKey("IngredienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cafe");

                    b.Navigation("Ingrediente");
                });

            modelBuilder.Entity("Starbucks.Domain.Cafe", b =>
                {
                    b.Navigation("CafeIngredientes");
                });

            modelBuilder.Entity("Starbucks.Domain.Categoria", b =>
                {
                    b.Navigation("Cafes");
                });

            modelBuilder.Entity("Starbucks.Domain.Ingrediente", b =>
                {
                    b.Navigation("CafeIngredientes");
                });
#pragma warning restore 612, 618
        }
    }
}
