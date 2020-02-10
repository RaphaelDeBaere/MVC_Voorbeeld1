using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EindtestASPMVC.Models
{
    public class WinkelmandItem
    {
        public WinkelmandItem(string titel, decimal prijs, int filmNr)
        {
            Titel = titel;
            Prijs = prijs;
            FilmNr = filmNr;
        }
        public string Titel { get; set; }
        [DisplayFormat(DataFormatString = "{0:€ #,##0.00}")]
        public decimal Prijs { get; set; }
        public int FilmNr { get; set; }
        public int InVoorraad { get; set; }
    }
}