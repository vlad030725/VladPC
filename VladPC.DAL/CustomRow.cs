namespace VladPC.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CustomRow
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? IdCustom { get; set; }

        public int? IdProduct { get; set; }

        public int? Price { get; set; }
        public int? Count { get; set; }

        public virtual Custom Custom { get; set; }

        public virtual Product Product { get; set; }
    }
}
