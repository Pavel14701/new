namespace SalesApp
{
    public interface INotifier
    {
        void Notify(string message);
    }

    public class Notifier : INotifier
    {
        public void Notify(string message)
        {
            Console.WriteLine($"[NOTIFY]: {message}");
        }
    }
}
