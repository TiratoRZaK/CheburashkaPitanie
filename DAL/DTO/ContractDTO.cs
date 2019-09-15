using System;

namespace DAL.DTO
{
    [Serializable]
    public class ContractDTO
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int SellerId { get; set; }
        public int CustomerId { get; set; }
        public string ResponsiblePerson { get; set; }
        public DateTime ConclusionDate { get; set; }
        public int PeriodInMonths { get; set; }
        public string FileName { get; set; }
        public float Total { get; set; }

        public SellerDTO Seller { get; set; }
        public CustomerDTO Customer { get; set; }

        public override string ToString()
        {
            return "Контракт №" + Number.ToString() + " от " + ConclusionDate.ToLongDateString();
        }
    }
}