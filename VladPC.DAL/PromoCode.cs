namespace VladPC.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PromoCode
    {
        public PromoCode()
        {
            Custom = new HashSet<Custom>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Code { get; set; }

        public double Discount { get; set; }

        public virtual ICollection<Custom> Custom { get; set; }
    }
}
