using Library;

namespace OOPSample
{
    class App
    {
        public App()
        {
            persons = new List<Person>();
            if (File.Exists(dbFileName))
            {

                string[] lines = File.ReadAllLines(dbFileName);
                foreach (string line in lines)
                {
                    persons.Add(Person.Parse(line));
                }
            }
            else
            {
                File.Create(dbFileName);
            }
        }
        private const string dbFileName = "personapp.db";
        private List<Person> persons;
        public void Start()
        {
            MainMenu();
        }
        private void MainMenu()
        {
            char key = ' ';
            while (key != 'Q')
            {
                Console.Clear();
                Console.WriteLine("C - Új személy felvétele");
                Console.WriteLine("L - Személyek listázása");
                Console.WriteLine("D - Személy törlése");
                Console.WriteLine("Q - Kilépés");

                key = char.ToUpper(Console.ReadKey(true).KeyChar);
                switch (key)
                {
                    case 'C':
                    case 'L':
                        Console.WriteLine("\nListázás...");
                        foreach (var item in persons)
                        {
                            Console.WriteLine(item);
                        }
                        break;
                    case 'D':
                        Console.WriteLine("Nemsokára...");
                        break;
                    case 'Q':
                        Console.WriteLine("Kilépés...");
                        break;
                    default:
                        Console.WriteLine("Nincs ilyen opció!");
                        break;
                }
                if ('Q' != key)
                {
                    Console.WriteLine();
                    Console.WriteLine("Enter: Vissza a főmenübe");
                    while (Console.ReadKey(true).Key != ConsoleKey.Enter) ;
                }
            }


        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            App app = new App();
            app.Start();
            return;
            List<Person> persons = new List<Person>();
            Teacher headMaster = new Teacher("Szegedi Barnabás", new DateTime(1965, 1, 1));
            persons.Add(new Student("Ákos", new DateTime(1995, 1, 1), headMaster));
            persons.Add(headMaster);
            persons.Add(new Student("Dani", new DateTime(1998, 11, 1)));

            foreach (Person person in persons)
            {
                Console.WriteLine(person.Greetings());
                //if(person is Student)
                //{
                //    Console.WriteLine(((Student)person).HeadMaster);
                //}
                Console.WriteLine(person);
            }

            Console.WriteLine(Person.InstanceCount);
        }
    }
}