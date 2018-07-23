namespace SeminarAPI.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SeminarContexDb : DbContext
    {
        public SeminarContexDb()
            : base("name=SeminarDB")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Predbiljezba> Predbiljezbas { get; set; }
        public virtual DbSet<Seminar> Seminars { get; set; }
        public virtual DbSet<Zaposlenik> Zaposleniks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
