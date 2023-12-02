namespace VladPC.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Custom
    {
        public Custom()
        {
            CustomRow = new HashSet<CustomRow>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? Sum { get; set; }

        public int? IdUser { get; set; }

        public virtual ICollection<CustomRow> CustomRow { get; set; }

        public virtual User User { get; set; }
    }
}
