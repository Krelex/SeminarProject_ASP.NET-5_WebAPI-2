using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace SeminarMVC.Models
{
    public class Predbiljezba
    {
        public int IdPredbiljezba { get; set; }

        [Required(ErrorMessage = "Unesite Datum")]
        public DateTime Datum { get; set; }

        [Required(ErrorMessage = "Unesite Ime")]
        public string Ime { get; set; }

        [Required(ErrorMessage = "Unesite Prezime")]
        public string Prezime { get; set; }

        [Required(ErrorMessage = "Unesite Adresa")]
        public string Adresa { get; set; }

        [Required(ErrorMessage = "Unesite Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Unesite Telefon")]
        public string Telefon { get; set; }

        public bool Active { get; set; }

        public int? IdSeminar { get; set; }

        public virtual Seminar Seminar { get; set; }
    }
}


