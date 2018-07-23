using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace SeminarMVC.Models
{
    public partial class Zaposlenik
    {
        public int IdZaposlenik { get; set; }

        [Required(ErrorMessage = "Unesite Ime")]
        public string Ime { get; set; }

        [Required(ErrorMessage = "Unesite Prezime")]
        public string Prezime { get; set; }

        [Required(ErrorMessage = "Unesite KorisnickoIme")]
        public string KorisnickoIme { get; set; }

        [Required(ErrorMessage = "Unesite Loznika")]
        public string Lozinka { get; set; }
    }
}



