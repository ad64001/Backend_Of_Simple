using SqlSugar;


namespace Backend.Model
{
    // Entities/User.cs
    [SugarTable("Users")]
    public class User
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        [SugarColumn(Length = 50, IsNullable = false)]
        public string Name { get; set; }

        [SugarColumn(ColumnDataType = "datetime", IsNullable = false)]
        public DateTime CreateTime { get; set; }
    }
}
