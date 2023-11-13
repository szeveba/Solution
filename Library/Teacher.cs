namespace Library
{
    public class Teacher : Person
    {
        public Teacher(string name, DateTime birthDate) : base(name, birthDate)
        {
            Students = new List<Student>();
        }

        public override string Greetings()
        {
            return "Sziasztok!";
        }

        public new string Introduce()
        {
            return $"Üdvözlöm! A nevem {Name}.";
        }

        public override string ToCsv()
        {
            return nameof(Teacher) + "|" + BaseCsv;
        }
        public override string ToString()
        {
            return $"Tanár: {Name} ({BirthDate.ToShortDateString()})";
        }
        public List<Student> Students { get; private set; }
    }
}