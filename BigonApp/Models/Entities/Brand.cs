namespace BigonApp.Models.Entities
{
    public class Brand:BaseEntity<int>
    {
        public string BrandName { get; set; }
        public string? Description { get; set; }
    }
}
