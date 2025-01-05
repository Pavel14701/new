namespace SalesApp
{
    public interface IService
    {
        void DoSomething();
    }

    public class Service : IService
    {
        public void DoSomething()
        {
            Console.WriteLine("Выполнение работы");
        }
    }
}
