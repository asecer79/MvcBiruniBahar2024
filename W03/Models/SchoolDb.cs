using Bogus;

namespace W03.Models
{
    public static class SchoolDb
    {
        public static List<Student>? Students =new List<Student>();
        
        static bool _isDbInitialized = false;
        public static void InitializeDb(int n)
        {
            if (!_isDbInitialized)
            {
                for (int i = 1; i <= n; i++)
                {
                    var student = new Faker<Student>()
                        .RuleFor(s => s.Id, r => i)
                        .RuleFor(s => s.Name, r => r.Name.FullName())
                        .RuleFor(s => s.Email, (r, s) => r.Internet.Email(s.Name))
                        .RuleFor(s => s.Age, r => r.Random.Int(17, 30));

                    Students.Add(student);


                }

                _isDbInitialized = true;
            }

        }


    }
}
