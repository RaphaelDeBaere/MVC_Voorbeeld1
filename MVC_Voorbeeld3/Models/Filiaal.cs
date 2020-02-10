using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Voorbeeld3.Models
{
    public class Filiaal
    {
        public int ID { get; set; }
        public string Naam { get; set; }
        [UIHint("sterretjes")]
        public DateTime Gebouwd { get; set; }
        public decimal Waarde { get; set; }
        public Eigenaar Eigenaar { get; set; }
    }
}