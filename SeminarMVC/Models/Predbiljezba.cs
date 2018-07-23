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

        public DateTime Datum { get; set; }

        public string Ime { get; set; }


        public string Prezime { get; set; }


        public string Adresa { get; set; }


        public string Email { get; set; }

        public string Telefon { get; set; }

        public bool Active { get; set; }

        public int? IdSeminar { get; set; }

        public virtual Seminar Seminar { get; set; }
    }
}


