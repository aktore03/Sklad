using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Sklad.Models
{
    public class Recipients
    {
        public int Id { get; set; }
        [DisplayName("Товар аты")]
        public string NameProduct { get; set; }
        [DisplayName("Алушы факультет")]
        public string Fakultet { get; set; }
        [DisplayName("Алушы кафедра")]
        public string Kafedra { get; set; }
        [DisplayName("Алушы адам")]
        public string Recipienter { get; set; }
        [DisplayName("Алған саны")]
        [Range(1, 100, ErrorMessage = "1 ден коп болу керек")]
        public int Quantity { get; set; }
        [DisplayName("Қысқаша сипаттама")]
        public string Desk { get; set; }
        [DisplayName("Алған ауақыты")]
        public DateTime Data { get; set; }

        [DisplayName("Жою Уақыты")]
        public DateTime DeleteData { get; set; }
        public int StorageId { get; set; }
        public Storage Storage { get; set; }
    }
}
