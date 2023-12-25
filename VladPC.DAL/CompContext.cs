using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace VladPC.DAL
{
    public partial class CompContext : DbContext
    {
        public CompContext()
            : base("CompContext")
        {
            Database.SetInitializer(new DbInitializer());
        }

        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Custom> Custom { get; set; }
        public virtual DbSet<CustomRow> CustomRow { get; set; }
        public virtual DbSet<FormFactor> FormFactor { get; set; }
        public virtual DbSet<Procurement> Procurement { get; set; }
        public virtual DbSet<ProcurementRow> ProcurementRow { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Socket> Socket { get; set; }
        public virtual DbSet<TypeMemory> TypeMemory { get; set; }
        public virtual DbSet<TypeProduct> TypeProduct { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<PromoCode> PromoCode { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>()
                .HasMany(e => e.Product)
                .WithOptional(e => e.Company)
                .HasForeignKey(e => e.IdCompany);

            modelBuilder.Entity<Custom>()
                .HasMany(e => e.CustomRow)
                .WithOptional(e => e.Custom)
                .HasForeignKey(e => e.IdCustom);

            modelBuilder.Entity<FormFactor>()
                .HasMany(e => e.Product)
                .WithOptional(e => e.FormFactor)
                .HasForeignKey(e => e.IdFormFactor);

            modelBuilder.Entity<Procurement>()
                .HasMany(e => e.ProcurementRow)
                .WithOptional(e => e.Procurement)
                .HasForeignKey(e => e.IdProcurement);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.CustomRow)
                .WithOptional(e => e.Product)
                .HasForeignKey(e => e.IdProduct);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.ProcurementRow)
                .WithOptional(e => e.Product)
                .HasForeignKey(e => e.IdProduct);

            modelBuilder.Entity<Socket>()
                .HasMany(e => e.Product)
                .WithOptional(e => e.Socket)
                .HasForeignKey(e => e.IdSocket);

            modelBuilder.Entity<TypeMemory>()
                .HasMany(e => e.Product)
                .WithOptional(e => e.TypeMemory)
                .HasForeignKey(e => e.IdTypeMemory);

            modelBuilder.Entity<TypeProduct>()
                .HasMany(e => e.Product)
                .WithOptional(e => e.TypeProduct)
                .HasForeignKey(e => e.IdTypeProduct);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Custom)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.IdUser);

            modelBuilder.Entity<Status>()
                .HasMany(e => e.Custom)
                .WithOptional(e => e.Status)
                .HasForeignKey(e => e.IdStatus);

            modelBuilder.Entity<PromoCode>()
                .HasMany(e => e.Custom)
                .WithOptional(e => e.PromoCode)
                .HasForeignKey(e => e.IdPromoCode);
        }
    }
}
