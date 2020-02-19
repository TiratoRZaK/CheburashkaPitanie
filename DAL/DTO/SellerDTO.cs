using System;

namespace DAL.DTO
{
    [Serializable]
    public class SellerDTO
    {
        public int Id { get; set; }
        public string NameCompany { get; set; }
        public string FullNameCompany { get; set; }
        public string AddressCompany { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string INN { get; set; }
        public string KPP { get; set; }
        public string BIK { get; set; }

        public string OGRN { get; set; }
        public string Bank { get; set; }
        public string PersonalAccount { get; set; }
        public string BankAccount { get; set; }
        public string CorrespondentAccount { get; set; }
        public string NameSeller { get; set; }
        public string NameSellerSpec { get; set; }
        public string RangSeller { get; set; }

        public override string ToString()
        {
            return NameCompany;
        }
    }
}
