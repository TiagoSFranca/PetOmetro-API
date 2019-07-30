﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PetOmetro.Persistence;

namespace PetOmetro.Persistence.Migrations
{
    [DbContext(typeof(PetOmetroContext))]
    partial class PetOmetroContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PetOmetro.Domain.Entities.GeneroPet", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(32);

                    b.HasKey("Id");

                    b.ToTable("GeneroPet");
                });

            modelBuilder.Entity("PetOmetro.Domain.Entities.Pet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comentário")
                        .HasMaxLength(512);

                    b.Property<DateTime?>("DtNascimento");

                    b.Property<string>("Especie")
                        .HasMaxLength(64);

                    b.Property<int>("IdGeneroPet");

                    b.Property<int>("IdUsuario");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<string>("Raca")
                        .HasMaxLength(64);

                    b.Property<string>("UrlImagem")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("IdGeneroPet");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Pet");
                });

            modelBuilder.Entity("PetOmetro.Domain.Entities.PetUsuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdPet");

                    b.Property<int>("IdUsuario");

                    b.HasKey("Id");

                    b.HasIndex("IdPet");

                    b.HasIndex("IdUsuario");

                    b.ToTable("PetUsuario");
                });

            modelBuilder.Entity("PetOmetro.Domain.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(32);

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("Sobrenome")
                        .HasMaxLength(64);

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("PetOmetro.Domain.Entities.Pet", b =>
                {
                    b.HasOne("PetOmetro.Domain.Entities.GeneroPet", "GeneroPet")
                        .WithMany("Pets")
                        .HasForeignKey("IdGeneroPet")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PetOmetro.Domain.Entities.Usuario", "Usuario")
                        .WithMany("Pets")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PetOmetro.Domain.Entities.PetUsuario", b =>
                {
                    b.HasOne("PetOmetro.Domain.Entities.Pet", "Pet")
                        .WithMany("PetUsuarios")
                        .HasForeignKey("IdPet")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("PetOmetro.Domain.Entities.Usuario", "Usuario")
                        .WithMany("PetUsuarios")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
