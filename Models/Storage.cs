using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Sklad.Models
{
    public class Storage
    {
        public int Id { get; set; }
        [DisplayName("Товар аты")]
        public string Name { get; set; }
        [DisplayName("Товар типі")]
        public string Type { get; set; }
        [DisplayName("Товар саны")]
        [Range(1, 100, ErrorMessage = "1 ден коп болу керек")]
        public int Quantity { get; set; }
        [DisplayName("Бағасы")]
        public int Price { get; set; }
        [DisplayName("Сипаттама")]
        public string Desk { get; set; }
        [DisplayName("Алынған Уақыты")]
        public DateTime Data { get; set; }
        [DisplayName("Жою Уақыты")]
        public DateTime DeleteData { get; set; }
        public List<Recipients> Recipients { get; set; }

    }
}
