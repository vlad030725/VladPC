namespace VladPC.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_nameProcurement : DbMigration
    {
        public override void Up()
        {
            AddColumn("public.Procurement", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("public.Procurement", "Name");
        }
    }
}
