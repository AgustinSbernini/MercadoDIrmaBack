namespace mercado_dirma_backend.Models.ProductDTOs
{
    public class ProductGetDTO
    {
        public int IdProduct { get; set; }
        public string ProductName { get; set; }
        public int IdProductBrand { get; set; }
        public string ProductBrandName { get; set; }        
        public int IdProductStatus { get; set; }
        public string ProductStatusName { get; set; }
        public int IdProductType { get; set; }
        public string ProductTypeName { get; set; }
        public int IdUserOwner { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public decimal Price { get; set; }
        public int Size { get; set; }
        public string? Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? DeletionDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool Active { get; set; }
    }
}
