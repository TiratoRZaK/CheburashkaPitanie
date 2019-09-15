using System;

namespace DAL.DTO
{
    public class DeliveryNoteDTO
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public DateTime Date { get; set; }
        public int InvoiceId { get; set; }
        public string FileName { get; set; }
        public string GruzName { get; set; }
        public string PriemName { get; set; }

        public InvoiceDTO Invoice { get; set; }

        public override string ToString()
        {
            return "Накладная №" + Number.ToString() + " от " + Date.ToLongDateString();
        }
    }
}
