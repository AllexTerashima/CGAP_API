using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CGAP_API;

namespace CGAP_API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20170627205718_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CGAP_API.Models.Departamento", b =>
                {
                    b.Property<int>("DepartamentoID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Cidade")
                        .IsRequired();

                    b.Property<string>("Estado")
                        .IsRequired();

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<string>("Pais")
                        .IsRequired();

                    b.HasKey("DepartamentoID");

                    b.ToTable("Departamentos");
                });

            modelBuilder.Entity("CGAP_API.Models.Perfil", b =>
                {
                    b.Property<int>("PerfilID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Auditorar");

                    b.Property<bool>("Emitir");

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<bool>("Receber");

                    b.HasKey("PerfilID");

                    b.ToTable("Perfis");
                });

            modelBuilder.Entity("CGAP_API.Models.Produto", b =>
                {
                    b.Property<int>("ProdutoID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Marca")
                        .IsRequired();

                    b.Property<int>("SalaID");

                    b.Property<string>("Tag")
                        .IsRequired();

                    b.Property<string>("Tipo")
                        .IsRequired();

                    b.Property<float>("Valor");

                    b.HasKey("ProdutoID");

                    b.HasIndex("SalaID");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("CGAP_API.Models.Sala", b =>
                {
                    b.Property<int>("SalaID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DepartamentoID");

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<string>("Tag")
                        .IsRequired();

                    b.HasKey("SalaID");

                    b.HasIndex("DepartamentoID");

                    b.ToTable("Salas");
                });

            modelBuilder.Entity("CGAP_API.Models.Usuario", b =>
                {
                    b.Property<int>("UsuarioID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Cpf")
                        .IsRequired();

                    b.Property<int>("DepartamentoID");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<DateTime>("Nascimento");

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<int>("PerfilID");

                    b.Property<string>("Rg")
                        .IsRequired();

                    b.Property<string>("Senha")
                        .IsRequired();

                    b.Property<string>("Telefone")
                        .IsRequired();

                    b.HasKey("UsuarioID");

                    b.HasIndex("DepartamentoID");

                    b.HasIndex("PerfilID");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("CGAP_API.Models.Produto", b =>
                {
                    b.HasOne("CGAP_API.Models.Sala", "Sala")
                        .WithMany("SalaProdutos")
                        .HasForeignKey("SalaID")
                        .HasConstraintName("ForeignKey_Produto_Sala");
                });

            modelBuilder.Entity("CGAP_API.Models.Sala", b =>
                {
                    b.HasOne("CGAP_API.Models.Departamento", "Departamento")
                        .WithMany("DepartamentoSalas")
                        .HasForeignKey("DepartamentoID")
                        .HasConstraintName("ForeignKey_Sala_Departamento");
                });

            modelBuilder.Entity("CGAP_API.Models.Usuario", b =>
                {
                    b.HasOne("CGAP_API.Models.Departamento", "Departamento")
                        .WithMany("DepartamentoUsuarios")
                        .HasForeignKey("DepartamentoID")
                        .HasConstraintName("ForeignKey_Usuario_Departamento");

                    b.HasOne("CGAP_API.Models.Perfil", "Perfil")
                        .WithMany("PerfilUsuarios")
                        .HasForeignKey("PerfilID")
                        .HasConstraintName("ForeignKey_Usuario_Perfil");
                });
        }
    }
}
