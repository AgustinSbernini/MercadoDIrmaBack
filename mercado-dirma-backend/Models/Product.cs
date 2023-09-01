namespace mercado_dirma_backend.Models
{
    public class Product
    {
        public int IdProduct { get; set; }
        public string ProductName { get; set; }
        public ProductBrand ProductBrand { get; set; }
        public ProductStatus ProductStatus { get; set; }
        public ProductType ProductType { get; set; }
        public User UserOwner { get; set; }
        public decimal Price { get; set; }
        public int Size { get; set; }
        public string? Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? DeletionDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool Active { get; set; }
    }
}
