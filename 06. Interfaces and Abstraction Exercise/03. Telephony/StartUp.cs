namespace _03.Telephony
{
    public class StartUp
    {
        static void Main()
        {
            string[] phoneNumbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] urls = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (string phoneNumber in phoneNumbers)
            {
                if (phoneNumber.Length == 10)
                {
                    ICallable smartphone = new Smartphone();
                    smartphone.Call(phoneNumber);
                }
                else
                {
                    ICallable stationaryPhone = new StationaryPhone();
                    stationaryPhone.Call(phoneNumber);
                }

            }

            foreach (string url in urls)
            {
                IBrowsable phone = new Smartphone();
                phone.Browse(url);
            }
        }
    }
}