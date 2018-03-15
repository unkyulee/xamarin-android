using SQLite;

namespace App.Models
{
    [Table("TestTable")]
    public class TestTable
    {
        [Column("id"), PrimaryKey, AutoIncrement] public int id { get; set; }
        [Column("title")] public string title { get; set; }        
    }
}
