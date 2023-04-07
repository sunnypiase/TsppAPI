namespace TsppAPI.Repository.Abstract
{
    public interface IProductAmountRepository
    {
        public Task<int> GetProductsAmount();
    }
}
