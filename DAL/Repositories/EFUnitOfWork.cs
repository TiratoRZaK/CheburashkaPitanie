using DAL.DTO;
using DAL.Interfaces;
using System;
using System.Windows;

namespace DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private PitanieContext db;
        private ProductRepository productRepository;
        private DishRepository dishRepository;
        private ProductDishesRepository productDishesRepository;
        private UnitRepository unitRepository;
        private TypeRepository typeRepository;
        private SellerRepository sellerRepository;
        private CustomerRepository customerRepository;
        private ContractRepository contractRepository;
        private MenuRepository menuRepository;
        private InvoiceRepository invoiceRepository;
        private DeliveryNoteRepository deliveryNoteRepository; 
        public EFUnitOfWork()
        {
            db = new PitanieContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='"+ AppDomain.CurrentDomain.BaseDirectory + "CheburashkaDB.mdf';Integrated Security=True");
        }

        public EFUnitOfWork(string connectionString)
        {
            db = new PitanieContext(connectionString);
        }

        public IRepository<ContractDTO> Contracts
        {
            get
            {
                if (contractRepository == null)
                {
                    contractRepository = new ContractRepository(db);
                }
                return contractRepository;
            }
        }

        public IRepository<DeliveryNoteDTO> DeliveryNotes
        {
            get
            {
                if (deliveryNoteRepository == null)
                {
                    deliveryNoteRepository = new DeliveryNoteRepository(db);
                }
                return deliveryNoteRepository;
            }
        }

        public IRepository<MenuDTO> Menus
        {
            get
            {
                if (menuRepository == null)
                {
                    menuRepository = new MenuRepository(db);
                }
                return menuRepository;
            }
        }
        public IRepository<InvoiceDTO> Invoices
        {
            get
            {
                if (invoiceRepository == null)
                {
                    invoiceRepository = new InvoiceRepository(db);
                }
                return invoiceRepository;
            }
        }

        public IRepository<ProductDTO> Products
        {
            get
            {
                if (productRepository == null)
                {
                    productRepository = new ProductRepository(db);
                }
                return productRepository;
            }
        }

        public IRepository<SellerDTO> Sellers
        {
            get
            {
                if (sellerRepository == null)
                {
                    sellerRepository = new SellerRepository(db);
                }
                return sellerRepository;
            }
        }

        public IRepository<CustomerDTO> Customers
        {
            get
            {
                if (customerRepository == null)
                {
                    customerRepository = new CustomerRepository(db);
                }
                return customerRepository;
            }
        }

        public IRepository<DishDTO> Dishes
        {
            get
            {
                if (dishRepository == null)
                {
                    dishRepository = new DishRepository(db);
                }
                return dishRepository;
            }
        }

        public IRepository<TypeDTO> Types
        {
            get
            {
                if (typeRepository == null)
                {
                    typeRepository = new TypeRepository(db);
                }
                return typeRepository;
            }
        }

        public IRepository<ProductDishDTO> ProductDishes
        {
            get
            {
                if (productDishesRepository == null)
                {
                    productDishesRepository = new ProductDishesRepository(db);
                }
                return productDishesRepository;
            }
        }

        public IRepository<UnitDTO> Units
        {
            get
            {
                if (unitRepository == null)
                {
                    unitRepository = new UnitRepository(db);
                }
                return unitRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}