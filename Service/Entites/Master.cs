using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Service.Entites
{
    public class Master
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public Record record { get; set; }
    }
}
