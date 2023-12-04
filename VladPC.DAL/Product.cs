namespace VladPC.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product
    {
        public Product()
        {
            CustomRow = new HashSet<CustomRow>();
            ProcurementRow = new HashSet<ProcurementRow>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public int? Count { get; set; }

        public int? IdCompany { get; set; }

        public int? IdTypeProduct { get; set; }

        public int? CountCores { get; set; }

        public int? CountStreams { get; set; }

        public int? Frequency { get; set; }

        public int? IdSocket { get; set; }

        public int? CountMemory { get; set; }

        public int? IdTypeMemory { get; set; }

        public int? IdFormFactor { get; set; }

        public virtual Company Company { get; set; }

        public virtual ICollection<CustomRow> CustomRow { get; set; }

        public virtual FormFactor FormFactor { get; set; }

        public virtual ICollection<ProcurementRow> ProcurementRow { get; set; }

        public virtual Socket Socket { get; set; }

        public virtual TypeMemory TypeMemory { get; set; }

        public virtual TypeProduct TypeProduct { get; set; }
    }
}
