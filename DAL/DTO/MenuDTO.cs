using System;

namespace DAL.DTO
{
    public class MenuDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Kids { get; set; }
        public int KidsB { get; set; }
        public string FileName { get; set; }
        public string Vrach { get; set; }
        public string Povar { get; set; }
        public string Klad { get; set; }
        public string Rukowoditel { get; set; }
        public int ProductBId { get; set; }

        public override string ToString()
        {
            return "Меню на " + Date.ToLongDateString();
        }
    }
}
