namespace SalesApp
{
    public interface IExternalService
    {
        Sale GetSaleData();
    }

    public class ExternalService : IExternalService
    {
        public Sale GetSaleData()
        {
            // Имитация получения данных от внешнего сервиса
            return new Sale
            {
                Product = "ProductA",
                Quantity = 10,
                Price = 99.99m,
                Date = DateTime.Now
            };
        }
    }
}
