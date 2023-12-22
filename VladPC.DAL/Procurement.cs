namespace VladPC.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Procurement
    {
        public Procurement()
        {
            ProcurementRow = new HashSet<ProcurementRow>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? Sum { get; set; }

        public virtual ICollection<ProcurementRow> ProcurementRow { get; set; }
    }
}
