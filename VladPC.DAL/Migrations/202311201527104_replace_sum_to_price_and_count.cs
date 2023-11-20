namespace VladPC.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class replace_sum_to_price_and_count : DbMigration
    {
        public override void Up()
        {
            AddColumn("public.CustomRow", "Price", c => c.Int());
            AddColumn("public.CustomRow", "Count", c => c.Int());
            AddColumn("public.ProcurementRow", "Price", c => c.Int());
            AddColumn("public.ProcurementRow", "Count", c => c.Int());
            DropColumn("public.CustomRow", "Sum");
            DropColumn("public.ProcurementRow", "Sum");
        }
        
        public override void Down()
        {
            AddColumn("public.ProcurementRow", "Sum", c => c.Int());
            AddColumn("public.CustomRow", "Sum", c => c.Int());
            DropColumn("public.ProcurementRow", "Count");
            DropColumn("public.ProcurementRow", "Price");
            DropColumn("public.CustomRow", "Count");
            DropColumn("public.CustomRow", "Price");
        }
    }
}
