namespace CBRadioOOP
{
    class TaxiDriver
    {
        public static readonly List<TaxiDriver> Drivers = new List<TaxiDriver>();
        public TaxiDriver(string name)
        {
            Name = name;
            Logs = new List<BroadcastLog>();
            Drivers.Add(this);
        }
        public string Name { get; private set; }
        public List<BroadcastLog> Logs { get; private set; }
        public void SetName(string value)
        {
            Name = value;
        }
    }
    class BroadcastLog
    {
        public BroadcastLog(int hour, int minute, int count)
        {
            Hour = hour;
            Minute = minute;
            Count = count;
        }

        public int Hour { get; private set; }
        public int Minute { get; private set; }
        public int Count { get; private set; }
    }

    internal class Program
    {
        static int AtszamolPercre(int hour, int minute)
        {
            return hour * 60 + minute;
        }
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("cb.txt");
            var drivers = new Dictionary<string, TaxiDriver>();
            for (int i = 1; i < lines.Length; i++)
            {
                var splits = lines[i].Split(';');
                var hour = int.Parse(splits[0]);
                var minute = int.Parse(splits[1]);
                var count = int.Parse(splits[2]);
                var name = splits[3];

                TaxiDriver driver;
                if(!drivers.TryGetValue(name, out driver))
                {
                    driver = new TaxiDriver(name);
                    drivers.Add(name, driver);
                }
                driver.Logs.Add(new BroadcastLog(hour, minute, count));

                //if (!drivers.ContainsKey(name))
                //{
                //    drivers.Add(name, new TaxiDriver(name));
                //}
                //drivers[name].Logs.Add(new BroadcastLog(hour, minute, count));
            }
        }
    }
}