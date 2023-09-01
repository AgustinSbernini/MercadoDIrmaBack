using mercado_dirma_backend.Commands;
using mercado_dirma_backend.Models;
using mercado_dirma_backend.Models.ProductDTOs;
using mercado_dirma_backend.Queries;

namespace mercado_dirma_backend.Business
{
    public class ProductBusiness
    {
        public async Task<IEnumerable<ProductGetDTO>> GetAll(bool isActive)
        {
            return await ProductQuery.GetAll(isActive);
        }

        public async Task<ProductGetDTO> GetById(int idProduct)
        {
            return await ProductQuery.GetById(idProduct);
        }


        public async Task<bool> Insert(ProductInsertDTO product)
        {
            return await ProductCommand.Insert(product);
        }
        public async Task<bool> Delete(int idProduct)
        {
            return await ProductCommand.Delete(idProduct);
        }

        public async Task<bool> Update(ProductUpdateDTO product)
        {
            return await ProductCommand.Update(product);
        }
    }
}
