using System;

namespace DAL.DTO
{
    public class InvoiceDTO
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public DateTime Date { get; set; }
        public int ContractId { get; set; }
        public string FileName { get; set; }
        public float Total { get; set; }
                              
        public ContractDTO Contract { get; set; }

        public override string ToString()
        {
            return "Счёт-фактура №" + Number.ToString() + " от " + Date.ToLongDateString();
        }
    }
}