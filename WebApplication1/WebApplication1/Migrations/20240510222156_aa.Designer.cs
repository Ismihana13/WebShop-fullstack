﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.Data;

#nullable disable

namespace WebApplication1.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240510222156_aa")]
    partial class aa
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApplication1.Data.Models.AdresaKorisnika", b =>
                {
                    b.Property<int>("AdresaKorisnikaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdresaKorisnikaId"));

                    b.Property<int>("GradId")
                        .HasColumnType("int");

                    b.Property<string>("NazivUlice")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AdresaKorisnikaId");

                    b.HasIndex("GradId");

                    b.ToTable("AdresaKorisnika");
                });

            modelBuilder.Entity("WebApplication1.Data.Models.AdresaZaDostavu", b =>
                {
                    b.Property<int>("AdresaZaDostavuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdresaZaDostavuId"));

                    b.Property<int>("GradId")
                        .HasColumnType("int");

                    b.Property<string>("NazivUlice")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AdresaZaDostavuId");

                    b.HasIndex("GradId");

                    b.ToTable("AdresaZaDostavu");
                });

            modelBuilder.Entity("WebApplication1.Data.Models.AutentifikacijaToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("IpAdresa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Is2FOtkljucano")
                        .HasColumnType("bit");

                    b.Property<int>("KorisnickiNalogId")
                        .HasColumnType("int");

                    b.Property<string>("TwoFKey")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Vrijednost")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("vrijemeEvidentiranja")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("KorisnickiNalogId");

                    b.ToTable("AutentifikacijaToken");
                });

            modelBuilder.Entity("WebApplication1.Data.Models.Drzava", b =>
                {
                    b.Property<int>("DrzavaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DrzavaId"));

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Restrikcije")
                        .HasColumnType("bit");

                    b.HasKey("DrzavaId");

                    b.ToTable("Drzava");
                });

            modelBuilder.Entity("WebApplication1.Data.Models.Grad", b =>
                {
                    b.Property<int>("GradId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GradId"));

                    b.Property<int>("DrzavaId")
                        .HasColumnType("int");

                    b.Property<string>("ImeGrada")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostanskiBroj")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GradId");

                    b.HasIndex("DrzavaId");

                    b.ToTable("Grad");
                });

            modelBuilder.Entity("WebApplication1.Data.Models.Izuzetak", b =>
                {
                    b.Property<int>("IzuzetakId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IzuzetakId"));

                    b.Property<int>("OzbiljnostId")
                        .HasColumnType("int");

                    b.Property<string>("Poruka")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StackTrace")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Tip")
                        .HasColumnType("int");

                    b.Property<DateTime>("Vrijeme")
                        .HasColumnType("datetime2");

                    b.HasKey("IzuzetakId");

                    b.HasIndex("OzbiljnostId");

                    b.ToTable("Izuzetak");
                });

            modelBuilder.Entity("WebApplication1.Data.Models.Kategorija", b =>
                {
                    b.Property<int>("KategorijaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KategorijaId"));

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KategorijaId");

                    b.ToTable("Kategorija");
                });

            modelBuilder.Entity("WebApplication1.Data.Models.KorisnickiNalog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BrojTelefona")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Is2FActive")
                        .HasColumnType("bit");

                    b.Property<string>("KorisnickoIme")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lozinka")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Slika")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isAdministrator")
                        .HasColumnType("bit");

                    b.Property<bool>("isKorisnik")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("KorisnickiNalog");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("WebApplication1.Data.Models.KorisnikObavijesti", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("KorisnikId")
                        .HasColumnType("int");

                    b.Property<int>("ObavijestiId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KorisnikId");

                    b.HasIndex("ObavijestiId");

                    b.ToTable("KorisnikObavijesti");
                });

            modelBuilder.Entity("WebApplication1.Data.Models.KorpaProdukt", b =>
                {
                    b.Property<int>("KorpaProduktId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KorpaProduktId"));

                    b.Property<int>("KorisnickiNalogId")
                        .HasColumnType("int");

                    b.Property<int?>("KorisnikId")
                        .HasColumnType("int");

                    b.Property<int>("ProduktId")
                        .HasColumnType("int");

                    b.HasKey("KorpaProduktId");

                    b.HasIndex("KorisnickiNalogId");

                    b.HasIndex("KorisnikId");

                    b.HasIndex("ProduktId");

                    b.ToTable("KorpaProdukt");
                });

            modelBuilder.Entity("WebApplication1.Data.Models.LogKretanjePoSistemu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ExceptionMessage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IpAdresa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostData")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QueryPath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Vrijeme")
                        .HasColumnType("datetime2");

                    b.Property<bool>("isException")
                        .HasColumnType("bit");

                    b.Property<int>("korisnikId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("korisnikId");

                    b.ToTable("LogKretanjePoSistemu");
                });

            modelBuilder.Entity("WebApplication1.Data.Models.Notifikacija", b =>
                {
                    b.Property<int>("NotifikacijaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NotifikacijaId"));

                    b.Property<DateTime>("DatumSlanja")
                        .HasColumnType("datetime2");

                    b.Property<int?>("KorisnikId")
                        .HasColumnType("int");

                    b.Property<string>("Sadrzaj")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipNotifikacijeId")
                        .HasColumnType("int");

                    b.HasKey("NotifikacijaId");

                    b.HasIndex("KorisnikId");

                    b.HasIndex("TipNotifikacijeId");

                    b.ToTable("Notifikacija");
                });

            modelBuilder.Entity("WebApplication1.Data.Models.Obavijesti", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime2");

                    b.Property<string>("Poruka")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Obavijesti");
                });

            modelBuilder.Entity("WebApplication1.Data.Models.Ozbiljnost", b =>
                {
                    b.Property<int>("OzbiljnostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OzbiljnostId"));

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OzbiljnostId");

                    b.ToTable("Ozbiljnost");
                });

            modelBuilder.Entity("WebApplication1.Data.Models.Produkt", b =>
                {
                    b.Property<int>("ProduktId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProduktId"));

                    b.Property<decimal>("Cijena")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<DateTime>("DatumObjave")
                        .HasColumnType("datetime2");

                    b.Property<bool>("JelObrisan")
                        .HasColumnType("bit");

                    b.Property<bool>("JelProdan")
                        .HasColumnType("bit");

                    b.Property<int>("KategorijaId")
                        .HasColumnType("int");

                    b.Property<int>("Kolicina")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Slika")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProduktId");

                    b.HasIndex("KategorijaId");

                    b.ToTable("Produkt");
                });

            modelBuilder.Entity("WebApplication1.Data.Models.TipNotifikacije", b =>
                {
                    b.Property<int>("TipNotifikacijeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TipNotifikacijeId"));

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PosaljiAdminu")
                        .HasColumnType("bit");

                    b.Property<string>("Sadrzaj")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TipNotifikacijeId");

                    b.ToTable("TipNotifikacije");
                });

            modelBuilder.Entity("WebApplication1.Data.Models.Transakcija", b =>
                {
                    b.Property<int>("TransakcijaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransakcijaId"));

                    b.Property<DateTime>("DatumTransakcije")
                        .HasColumnType("datetime2");

                    b.Property<int>("KorisnickiNalogId")
                        .HasColumnType("int");

                    b.Property<int?>("KorisnikId")
                        .HasColumnType("int");

                    b.Property<decimal>("UkupnaCijena")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("TransakcijaId");

                    b.HasIndex("KorisnickiNalogId");

                    b.HasIndex("KorisnikId");

                    b.ToTable("Transakcija");
                });

            modelBuilder.Entity("WebApplication1.Data.Models.TransakcijaProdukt", b =>
                {
                    b.Property<int>("TransakcijaProduktId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransakcijaProduktId"));

                    b.Property<int>("Kolicina")
                        .HasColumnType("int");

                    b.Property<int>("ProduktId")
                        .HasColumnType("int");

                    b.Property<int>("TransakcijaId")
                        .HasColumnType("int");

                    b.HasKey("TransakcijaProduktId");

                    b.HasIndex("ProduktId");

                    b.HasIndex("TransakcijaId");

                    b.ToTable("TransakcijaProdukt");
                });

            modelBuilder.Entity("WebApplication1.Data.Models.Administrator", b =>
                {
                    b.HasBaseType("WebApplication1.Data.Models.KorisnickiNalog");

                    b.Property<DateTime>("DatumKreiranja")
                        .HasColumnType("datetime2");

                    b.ToTable("Administrator");
                });

            modelBuilder.Entity("WebApplication1.Data.Models.Korisnik", b =>
                {
                    b.HasBaseType("WebApplication1.Data.Models.KorisnickiNalog");

                    b.Property<int?>("AdresaKorisnikaId")
                        .HasColumnType("int");

                    b.Property<int?>("AdresaZaDostavuId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DatumRodjenja")
                        .HasColumnType("datetime2");

                    b.Property<string>("Spol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("AdresaKorisnikaId");

                    b.HasIndex("AdresaZaDostavuId");

                    b.ToTable("Korisnik");
                });

            modelBuilder.Entity("WebApplication1.Data.Models.AdresaKorisnika", b =>
                {
                    b.HasOne("WebApplication1.Data.Models.Grad", "Grad")
                        .WithMany("AdreseKorisnika")
                        .HasForeignKey("GradId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Grad");
                });

            modelBuilder.Entity("WebApplication1.Data.Models.AdresaZaDostavu", b =>
                {
                    b.HasOne("WebApplication1.Data.Models.Grad", "Grad")
                        .WithMany("AdresaZaDostavu")
                        .HasForeignKey("GradId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Grad");
                });

            modelBuilder.Entity("WebApplication1.Data.Models.AutentifikacijaToken", b =>
                {
                    b.HasOne("WebApplication1.Data.Models.KorisnickiNalog", "KorisnickiNalog")
                        .WithMany()
                        .HasForeignKey("KorisnickiNalogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KorisnickiNalog");
                });

            modelBuilder.Entity("WebApplication1.Data.Models.Grad", b =>
                {
                    b.HasOne("WebApplication1.Data.Models.Drzava", "Drzava")
                        .WithMany("Gradovi")
                        .HasForeignKey("DrzavaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Drzava");
                });

            modelBuilder.Entity("WebApplication1.Data.Models.Izuzetak", b =>
                {
                    b.HasOne("WebApplication1.Data.Models.Ozbiljnost", "Ozbiljnost")
                        .WithMany("Izuzetci")
                        .HasForeignKey("OzbiljnostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ozbiljnost");
                });

            modelBuilder.Entity("WebApplication1.Data.Models.KorisnikObavijesti", b =>
                {
                    b.HasOne("WebApplication1.Data.Models.Korisnik", "Korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Data.Models.Obavijesti", "Obavijesti")
                        .WithMany("Uposlenik")
                        .HasForeignKey("ObavijestiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Korisnik");

                    b.Navigation("Obavijesti");
                });

            modelBuilder.Entity("WebApplication1.Data.Models.KorpaProdukt", b =>
                {
                    b.HasOne("WebApplication1.Data.Models.KorisnickiNalog", "KorisnickiNalog")
                        .WithMany()
                        .HasForeignKey("KorisnickiNalogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Data.Models.Korisnik", null)
                        .WithMany("KorpaProdukti")
                        .HasForeignKey("KorisnikId");

                    b.HasOne("WebApplication1.Data.Models.Produkt", "Produkt")
                        .WithMany("KorpaProdukti")
                        .HasForeignKey("ProduktId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KorisnickiNalog");

                    b.Navigation("Produkt");
                });

            modelBuilder.Entity("WebApplication1.Data.Models.LogKretanjePoSistemu", b =>
                {
                    b.HasOne("WebApplication1.Data.Models.KorisnickiNalog", "korisnik")
                        .WithMany()
                        .HasForeignKey("korisnikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("korisnik");
                });

            modelBuilder.Entity("WebApplication1.Data.Models.Notifikacija", b =>
                {
                    b.HasOne("WebApplication1.Data.Models.Korisnik", null)
                        .WithMany("Notifikacije")
                        .HasForeignKey("KorisnikId");

                    b.HasOne("WebApplication1.Data.Models.TipNotifikacije", "TipNotifikacije")
                        .WithMany("Notifikacije")
                        .HasForeignKey("TipNotifikacijeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipNotifikacije");
                });

            modelBuilder.Entity("WebApplication1.Data.Models.Produkt", b =>
                {
                    b.HasOne("WebApplication1.Data.Models.Kategorija", "Kategorija")
                        .WithMany("Produkti")
                        .HasForeignKey("KategorijaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kategorija");
                });

            modelBuilder.Entity("WebApplication1.Data.Models.Transakcija", b =>
                {
                    b.HasOne("WebApplication1.Data.Models.KorisnickiNalog", "KorisnickiNalog")
                        .WithMany()
                        .HasForeignKey("KorisnickiNalogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Data.Models.Korisnik", null)
                        .WithMany("Transakcije")
                        .HasForeignKey("KorisnikId");

                    b.Navigation("KorisnickiNalog");
                });

            modelBuilder.Entity("WebApplication1.Data.Models.TransakcijaProdukt", b =>
                {
                    b.HasOne("WebApplication1.Data.Models.Produkt", "Produkt")
                        .WithMany("TransakcijaProdukti")
                        .HasForeignKey("ProduktId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Data.Models.Transakcija", "Transakcija")
                        .WithMany("TransakcijaProdukti")
                        .HasForeignKey("TransakcijaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produkt");

                    b.Navigation("Transakcija");
                });

            modelBuilder.Entity("WebApplication1.Data.Models.Administrator", b =>
                {
                    b.HasOne("WebApplication1.Data.Models.KorisnickiNalog", null)
                        .WithOne()
                        .HasForeignKey("WebApplication1.Data.Models.Administrator", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApplication1.Data.Models.Korisnik", b =>
                {
                    b.HasOne("WebApplication1.Data.Models.AdresaKorisnika", "AdresaKorisnika")
                        .WithMany("Korisnici")
                        .HasForeignKey("AdresaKorisnikaId");

                    b.HasOne("WebApplication1.Data.Models.AdresaZaDostavu", "AdresaZaDostavu")
                        .WithMany("Korisnici")
                        .HasForeignKey("AdresaZaDostavuId");

                    b.HasOne("WebApplication1.Data.Models.KorisnickiNalog", null)
                        .WithOne()
                        .HasForeignKey("WebApplication1.Data.Models.Korisnik", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AdresaKorisnika");

                    b.Navigation("AdresaZaDostavu");
                });

            modelBuilder.Entity("WebApplication1.Data.Models.AdresaKorisnika", b =>
                {
                    b.Navigation("Korisnici");
                });

            modelBuilder.Entity("WebApplication1.Data.Models.AdresaZaDostavu", b =>
                {
                    b.Navigation("Korisnici");
                });

            modelBuilder.Entity("WebApplication1.Data.Models.Drzava", b =>
                {
                    b.Navigation("Gradovi");
                });

            modelBuilder.Entity("WebApplication1.Data.Models.Grad", b =>
                {
                    b.Navigation("AdresaZaDostavu");

                    b.Navigation("AdreseKorisnika");
                });

            modelBuilder.Entity("WebApplication1.Data.Models.Kategorija", b =>
                {
                    b.Navigation("Produkti");
                });

            modelBuilder.Entity("WebApplication1.Data.Models.Obavijesti", b =>
                {
                    b.Navigation("Uposlenik");
                });

            modelBuilder.Entity("WebApplication1.Data.Models.Ozbiljnost", b =>
                {
                    b.Navigation("Izuzetci");
                });

            modelBuilder.Entity("WebApplication1.Data.Models.Produkt", b =>
                {
                    b.Navigation("KorpaProdukti");

                    b.Navigation("TransakcijaProdukti");
                });

            modelBuilder.Entity("WebApplication1.Data.Models.TipNotifikacije", b =>
                {
                    b.Navigation("Notifikacije");
                });

            modelBuilder.Entity("WebApplication1.Data.Models.Transakcija", b =>
                {
                    b.Navigation("TransakcijaProdukti");
                });

            modelBuilder.Entity("WebApplication1.Data.Models.Korisnik", b =>
                {
                    b.Navigation("KorpaProdukti");

                    b.Navigation("Notifikacije");

                    b.Navigation("Transakcije");
                });
#pragma warning restore 612, 618
        }
    }
}
