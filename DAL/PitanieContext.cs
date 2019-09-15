using System.Data.Entity;
using DAL.DTO;

namespace DAL
{
    public class PitanieContext : DbContext
    {
        public PitanieContext()
            : base("name=PitanieContext")
        {
        }

        public PitanieContext(string PitanieContext) : base(PitanieContext)
        {
        }

        public virtual DbSet<DishDTO> Dishes { get; set; }
        public virtual DbSet<ProductDTO> Products { get; set; }
        public virtual DbSet<ProductDishDTO> ProductDishes { get; set; }
        public virtual DbSet<UnitDTO> Units { get; set; }
        public virtual DbSet<TypeDTO> Types { get; set; }
        public virtual DbSet<SellerDTO> Sellers { get; set; }
        public virtual DbSet<CustomerDTO> Customers { get; set; }
        public virtual DbSet<MenuDTO> Menus { get; set; }
        public virtual DbSet<ContractDTO> Contracts { get; set; }
        public virtual DbSet<InvoiceDTO> Invoices { get; set; }
        public virtual DbSet<DeliveryNoteDTO> DeliveryNotes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DishDTO>().ToTable("Dishes");
            modelBuilder.Entity<DeliveryNoteDTO>().ToTable("DeliveryNotes");
            modelBuilder.Entity<ProductDTO>().ToTable("Products");
            modelBuilder.Entity<ProductDishDTO>().ToTable("ProductDishes");
            modelBuilder.Entity<UnitDTO>().ToTable("Units");
            modelBuilder.Entity<TypeDTO>().ToTable("Types");
            modelBuilder.Entity<SellerDTO>().ToTable("Sellers");
            modelBuilder.Entity<CustomerDTO>().ToTable("Customers");
            modelBuilder.Entity<MenuDTO>().ToTable("Menus");
            modelBuilder.Entity<InvoiceDTO>().ToTable("Invoices");
            modelBuilder.Entity<ContractDTO>().ToTable("Contracts");
        }
    }
}