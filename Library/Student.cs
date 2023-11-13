namespace Library
{
    public class Student : Person
    {
        public Student(string name, DateTime birthDate, Teacher? headMaster = null) : base(name, birthDate)
        {
            HeadMaster = headMaster;
        }

        public override string Greetings()
        {
            return "Jónapot kívánok!";
        }

        public Teacher? HeadMaster { get; set; }
        public override string ToString()
        {
            return $"Diák: {Name} ({BirthDate.ToShortDateString()})";
        }

        public override string ToCsv()
        {
            return nameof(Student) + "|" + BaseCsv;
        }
    }
}