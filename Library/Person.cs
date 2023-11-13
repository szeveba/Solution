namespace Library
{
    public abstract class Person
    {
        public static int InstanceCount { get => instanceCount; }
        private static int instanceCount = 0;
        public Person(string name, DateTime birthDate)
        {
            instanceCount++;
            Name = name;
            BirthDate = birthDate;
        }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public abstract string Greetings();
        public string Introduce()
        {
            return $"Szia! A nevem {Name}.";
        }
        protected string BaseCsv { get => $"{Name}|{BirthDate}"; }
        public abstract string ToCsv();

        public static Person Parse(string line)
        {
            string[] splits = line.Split('|');
            switch (splits[0])
            {
                case nameof(Student): return new Student(splits[1], DateTime.Parse(splits[2]));
                case nameof(Teacher): return new Teacher(splits[1], DateTime.Parse(splits[2]));
                default: throw new InvalidProgramException();
            }
        }
    }
}