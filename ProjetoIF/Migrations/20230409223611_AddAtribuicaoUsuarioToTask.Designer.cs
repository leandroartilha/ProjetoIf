﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetoIF.Context;

#nullable disable

namespace ProjetoIF.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230409223611_AddAtribuicaoUsuarioToTask")]
    partial class AddAtribuicaoUsuarioToTask
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProjetoIF.Models.AtribuicaoUserProject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NomeUsuarioAtribuido")
                        .HasColumnType("varchar(100)");

                    b.Property<int?>("ProjetoId")
                        .HasColumnType("int");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProjetoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("AtribuicaoUserProject");
                });

            modelBuilder.Entity("ProjetoIF.Models.AtribuicaoUserTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NomeUsuarioAtribuido")
                        .HasColumnType("varchar(100)");

                    b.Property<int?>("TarefaId")
                        .HasColumnType("int");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TarefaId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("AtribuicaoUserTask");
                });

            modelBuilder.Entity("ProjetoIF.Models.Login", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("EmailLogin")
                        .IsRequired()
                        .HasColumnType("varchar(40)");

                    b.Property<string>("SenhaLogin")
                        .IsRequired()
                        .HasColumnType("varchar(40)");

                    b.HasKey("Id");

                    b.ToTable("Login");
                });

            modelBuilder.Entity("ProjetoIF.Models.Projeto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NomeTarefa")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Projeto");
                });

            modelBuilder.Entity("ProjetoIF.Models.Tarefa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DescricaoTarefa")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("NomeTarefa")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("ProjetoId")
                        .HasColumnType("int");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProjetoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Tarefa");
                });

            modelBuilder.Entity("ProjetoIF.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("EmailUsuario")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("NomeUsuario")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("SenhaUsuario")
                        .IsRequired()
                        .HasColumnType("varchar(40)");

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("ProjetoIF.Models.AtribuicaoUserProject", b =>
                {
                    b.HasOne("ProjetoIF.Models.Projeto", "Projeto")
                        .WithMany("AtribuicaoUserProject")
                        .HasForeignKey("ProjetoId");

                    b.HasOne("ProjetoIF.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId");

                    b.Navigation("Projeto");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("ProjetoIF.Models.AtribuicaoUserTask", b =>
                {
                    b.HasOne("ProjetoIF.Models.Tarefa", "Tarefa")
                        .WithMany("AtribuicaoUserTask")
                        .HasForeignKey("TarefaId");

                    b.HasOne("ProjetoIF.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId");

                    b.Navigation("Tarefa");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("ProjetoIF.Models.Tarefa", b =>
                {
                    b.HasOne("ProjetoIF.Models.Projeto", "Projeto")
                        .WithMany("Tarefa")
                        .HasForeignKey("ProjetoId");

                    b.HasOne("ProjetoIF.Models.Usuario", "Usuario")
                        .WithMany("Tarefa")
                        .HasForeignKey("UsuarioId");

                    b.Navigation("Projeto");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("ProjetoIF.Models.Projeto", b =>
                {
                    b.Navigation("AtribuicaoUserProject");

                    b.Navigation("Tarefa");
                });

            modelBuilder.Entity("ProjetoIF.Models.Tarefa", b =>
                {
                    b.Navigation("AtribuicaoUserTask");
                });

            modelBuilder.Entity("ProjetoIF.Models.Usuario", b =>
                {
                    b.Navigation("Tarefa");
                });
#pragma warning restore 612, 618
        }
    }
}
