namespace SeminarAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Predbiljezba")]
    public partial class Predbiljezba
    {
        [Key]
        public int IdPredbiljezba { get; set; }

        public DateTime Datum { get; set; }

        [Required]
        [StringLength(50)]
        public string Ime { get; set; }

        [Required]
        [StringLength(50)]
        public string Prezime { get; set; }

        [Required]
        [StringLength(100)]
        public string Adresa { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(30)]
        public string Telefon { get; set; }

        public bool Active { get; set; }

        public int? IdSeminar { get; set; }

        public virtual Seminar Seminar { get; set; }
    }
}
