namespace mercado_dirma_backend.Models.ProductDTOs
{
    public class ProductUpdateDTO
    {
        public int IdProduct { get; set; }
        public string ProductName { get; set; }
        public int IdProductBrand { get; set; }
        public int IdProductStatus { get; set; }
        public int IdProductType { get; set; }
        public int IdUserOwner { get; set; }
        public decimal Price { get; set; }
        public int Size { get; set; }
        public string? Description { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
