namespace E5
{
    class Teacher
    {
        public Teacher()
        {
            Students = new List<Student>();
        }
        public string? Name { get; set; }
        public DateTime? BirthDate { get; set; }
        public List<Student> Students { get; private set; }
    }
    // public - névtéren kívül is elérhető
    // internal - adott névt
    class Student
    {
        #region Konstruktorok
        public Student(string name, DateTime birthDate)
        {
            this.name = name;
            this.birthDate = birthDate;
        }
        public Student()
        {
            this.name = "";
        }
        #endregion
        #region Mezők
        private string name;
        private DateTime? birthDate;
        #endregion
        #region Tulajdonságok

        //C# bevezette a get set kulcsszót rövidítésre
        // Full property
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        //On the fly property
        public int? Age { get => birthDate.HasValue ? new DateTime(DateTime.Now.Ticks - birthDate.Value.Ticks).Year - 1 : null; }

        //Auto property
        public string? ID { get; set; }

        //C# 2017-től default szintaxis. (ez is full property)
        public string NameWithLambda { get => name; set => name = value; }
        #endregion
        #region Metódusok
        //Java-ban így néz ki a tulajdonságok definiálása.
        public string GetName()
        {
            return name;
        }
        public Student SetName(string value)
        {
            name = value.ToUpper();
            return this;
        }
        #endregion

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new DateTime());
            Console.WriteLine(DateTime.Now.ToString("yyMMdd (dddd)"));
            Student s = new Student("Józsi", new DateTime(1995, 5, 5));
            Console.WriteLine(s.Age);
            s.Name = "Ákos";
            Console.WriteLine(s.Name);
            s.SetName("Asd").SetName("asdasdasd");

            Teacher t = new Teacher()
            {
                Name = "Asd",
                BirthDate = new DateTime(1995, 1, 1)
            };
            t.Students.Add(s);

        }
    }
}