using System;

namespace DAL.DTO
{
    [Serializable]
    public class CustomerDTO
    {
        public int Id { get; set; }
        public string NameCompany { get; set; }
        public string FullNameCompany { get; set; }
        public string AddressCompany { get; set; }
        public string INN { get; set; }
        public string KPP { get; set; }
        public string BIK { get; set; }
        public string Bank { get; set; }
        public string PersonalAccount { get; set; }
        public string BankAccount { get; set; }
        public string NameCustomer { get; set; }
        public string NameCustomerSpec { get; set; }

        public override string ToString()
        {
            return NameCompany;
        }
    }
}
