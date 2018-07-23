using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;


namespace SeminarMVC.Models
{
    public partial class Seminar
    {
        public Seminar()
        {
            Predbiljezbas = new HashSet<Predbiljezba>();
        }

        public int IdSeminar { get; set; }

        [Required(ErrorMessage = "Unesite Naziv")]
        public string Naziv { get; set; }

        [Required(ErrorMessage = "Unesite Opis")]
        public string Opis { get; set; }

        [Required(ErrorMessage = "Unesite Datum")]
        public DateTime Datum { get; set; }

        public bool Popunjen { get; set; }

        public virtual ICollection<Predbiljezba> Predbiljezbas { get; set; }
    }
}



