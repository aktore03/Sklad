using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Sklad.Models
{
    public class Write_offs
    {
        public int Id { get; set; }
        [DisplayName("Товар аты")]
        public string NameProduct { get; set; }
        [DisplayName("Товар ID")]
        public int ProductId { get; set; }
        [DisplayName("Жоюшы факультет")]
        public string Fakultet { get; set; }
        [DisplayName("Жоюшы кафедра")]
        public string Kafedra { get; set; }
        [DisplayName("Жоюшы адам")]
        public string Writer { get; set; }

        [DisplayName("Саны")]
        [Range(1, 100, ErrorMessage = "1 ден коп болу керек")]
        public int Quantity { get; set; }
        [DisplayName("Сипаттама")]
        public string Desk { get; set; }
        [DisplayName("Жою уақыты")]
        public DateTime Data { get; set; }
    }
}
