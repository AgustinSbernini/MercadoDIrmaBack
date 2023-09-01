namespace mercado_dirma_backend.Models.ProductDTOs
{
    public class ProductInsertDTO
    {
        
        public string ProductName { get; set; }
        public int IdProductBrand { get; set; }
        public int IdProductStatus { get; set; }
        public int IdProductType { get; set; }
        public int IdUserOwner { get; set; }
        public decimal Price { get; set; }
        public int Size { get; set; }
        public string? Description { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; }  
    }
}
