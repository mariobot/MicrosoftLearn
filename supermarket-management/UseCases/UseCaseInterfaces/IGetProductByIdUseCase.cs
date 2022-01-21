using CoreBusiness;

namespace UseCases
{
    public interface IGetProductByIdUseCase
    {
        public Product Execute(int productId);
    }
}