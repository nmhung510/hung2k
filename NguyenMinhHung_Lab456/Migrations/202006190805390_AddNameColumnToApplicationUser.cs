namespace NguyenMinhHung_Lab456.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNameColumnToApplicationUser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "Category_ID", "dbo.Categories");
            DropIndex("dbo.Courses", new[] { "LecturerID" });
            DropIndex("dbo.Courses", new[] { "Category_ID" });
            RenameColumn(table: "dbo.Courses", name: "Category_ID", newName: "CategoryId");
            AddColumn("dbo.AspNetUsers", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Courses", "CategoryId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Courses", "LecturerId");
            CreateIndex("dbo.Courses", "CategoryId");
            AddForeignKey("dbo.Courses", "CategoryId", "dbo.Categories", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Courses", new[] { "CategoryId" });
            DropIndex("dbo.Courses", new[] { "LecturerId" });
            AlterColumn("dbo.Courses", "CategoryId", c => c.Byte());
            DropColumn("dbo.AspNetUsers", "Name");
            RenameColumn(table: "dbo.Courses", name: "CategoryId", newName: "Category_ID");
            CreateIndex("dbo.Courses", "Category_ID");
            CreateIndex("dbo.Courses", "LecturerID");
            AddForeignKey("dbo.Courses", "Category_ID", "dbo.Categories", "ID");
        }
    }
}
