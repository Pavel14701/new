using System.Threading.Tasks;

namespace SalesApp
{
    public class Client
    {
        private readonly IService _service;
        private readonly ILogger _logger;
        private readonly INotifier _notifier;
        private readonly IDatabaseService _databaseService;
        private readonly IEmailService _emailService;
        private readonly IExternalService _externalService;

        public Client(IService service, ILogger logger, INotifier notifier, IDatabaseService databaseService, IEmailService emailService, IExternalService externalService)
        {
            _service = service;
            _logger = logger;
            _notifier = notifier;
            _databaseService = databaseService;
            _emailService = emailService;
            _externalService = externalService;
        }

        public async Task PerformActionAsync()
        {
            _logger.Log("PerformAction вызван");
            _service.DoSomething();
            _logger.Log("PerformAction завершен");

            var saleData = _externalService.GetSaleData();
            _databaseService.SaveData(saleData);
            var allData = _databaseService.GetAllData();
            string report = $"Всего продаж: {allData.Count}, Последняя продажа: {saleData.Product}, {saleData.Quantity} шт., {saleData.Price} руб.";

            await _emailService.SendEmailAsync("report@example.com", "Отчет о продажах", report);
            _notifier.Notify("Действие выполнено, отчет отправлен");
        }
    }
}
