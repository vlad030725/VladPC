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

        public int? IdUser { get; set; }

        public int? IdStatus { get; set; }

        public int? IdPromoCode { get; set; }

        public DateTime? CreatedDate { get; set; }
        
        public int? Sum {  get; set; }

        public virtual ICollection<CustomRow> CustomRow { get; set; }

        public virtual User User { get; set; }

        public virtual Status Status { get; set; }

        public virtual PromoCode PromoCode { get; set; }
    }
}
