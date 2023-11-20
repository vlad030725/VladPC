namespace VladPC.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.ProcurementRow")]
    public partial class ProcurementRow
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int? IdProduct { get; set; }

        public int? IdProcurement { get; set; }

        public int? Sum { get; set; }

        public virtual Procurement Procurement { get; set; }

        public virtual Product Product { get; set; }
    }
}
