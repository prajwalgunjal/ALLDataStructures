using System.Data;

namespace Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("====== LINQ Examples in One Main ======\n");

            var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 2, 3, 7, 8, 9 };
            var people = new List<Person>
            {
                new Person("Alice", 25, "HR"),
                new Person("Bob", 32, "IT"),
                new Person("Charlie", 28, "IT"),
                new Person("David", 40, "Finance"),
                new Person("Eve", 22, "HR")
            };

            // 1️⃣ Filtering
            var evens = numbers.Where(n => n % 2 == 0);
            Console.WriteLine("Even Numbers: " + string.Join(", ", evens));

            // 2️⃣ Projection
            var names = people.Select(p => p.Name);
            Console.WriteLine("\nNames: " + string.Join(", ", names));

            // 3️⃣ SelectMany (flattening)
            var words = new[] { "one", "two", "three" };
            var allChars = words.SelectMany(w => w.ToCharArray());
            Console.WriteLine("\nAll characters: " + string.Join(", ", allChars));

            // 4️⃣ Sorting
            var sorted = numbers.OrderBy(n => n);
            Console.WriteLine("\nSorted: " + string.Join(", ", sorted));

            // 5️⃣ Sorting Descending
            var desc = numbers.OrderByDescending(n => n);
            Console.WriteLine("Descending: " + string.Join(", ", desc));

            // 6️⃣ Grouping
            var groupByDept = people.GroupBy(p => p.Department);
            Console.WriteLine("\nGrouped by Department:");
            foreach (var group in groupByDept)
            {
                Console.WriteLine($"Department: {group.Key}");
                foreach (var p in group)
                {
                    Console.WriteLine($" - {p.Name}");
                }
            }

            // 7️⃣ Aggregation
            Console.WriteLine($"\nCount: {numbers.Count()}");
            Console.WriteLine($"Sum: {numbers.Sum()}");
            Console.WriteLine($"Average: {numbers.Average()}");
            Console.WriteLine($"Min: {numbers.Min()}");
            Console.WriteLine($"Max: {numbers.Max()}");

            // 8️⃣ Quantifiers
            Console.WriteLine($"\nAny > 5: {numbers.Any(n => n > 5)}");
            Console.WriteLine($"All even: {numbers.All(n => n % 2 == 0)}");
            Console.WriteLine($"Contains 3: {numbers.Contains(3)}");

            // 9️⃣ Set operations
            Console.WriteLine("\nDistinct: " + string.Join(", ", numbers.Distinct()));
            var moreNums = new List<int> { 5, 6, 10 };
            Console.WriteLine("Union: " + string.Join(", ", numbers.Union(moreNums)));
            Console.WriteLine("Intersect: " + string.Join(", ", numbers.Intersect(moreNums)));
            Console.WriteLine("Except: " + string.Join(", ", numbers.Except(moreNums)));

            // 🔟 Element operators
            Console.WriteLine($"\nFirst: {numbers.First()}");
            Console.WriteLine($"First > 4: {numbers.First(n => n > 4)}");
            Console.WriteLine($"FirstOrDefault > 100: {numbers.FirstOrDefault(n => n > 100)}"); // null-safe
            Console.WriteLine($"Single (only 7): {numbers.Single(n => n == 7)}");
            Console.WriteLine($"ElementAt(3): {numbers.ElementAt(3)}");

            // 1️⃣1️⃣ Generation
            var range = Enumerable.Range(1, 5);
            Console.WriteLine("\nRange: " + string.Join(", ", range));
            var repeated = Enumerable.Repeat("Hi", 3);
            Console.WriteLine("Repeat: " + string.Join(", ", repeated));

            // 1️⃣2️⃣ Joining
            var departments = new List<Department>
            {
                new Department("HR"),
                new Department("IT"),
                new Department("Finance")
            };

            var joined = people.Join(
                departments,
                p => p.Department,
                d => d.Name,
                (p, d) => new { PersonName = p.Name, DepartmentName = d.Name }
            );

            Console.WriteLine("\nJoin Example:");
            foreach (var item in joined)
                Console.WriteLine($"Person: {item.PersonName}, Dept: {item.DepartmentName}");

            // 1️⃣3️⃣ Partitioning
            var first3 = numbers.Take(3);
            var skip3 = numbers.Skip(3);
            Console.WriteLine("\nTake 3: " + string.Join(", ", first3));
            Console.WriteLine("Skip 3: " + string.Join(", ", skip3));
            
            LinqToSqlDemo();
            LinqToEntitiesDemo();
            LinqToDataSetDemo();
            PLINQDemo();

            Console.WriteLine("\n====== END ======");
        }
        static void PLINQDemo()
        {
            Console.WriteLine("\n=== PLINQ Demo ===");

            int[] numbers = Enumerable.Range(1, 20).ToArray();

            // Parallel query to square numbers and print with thread info
            var squaredNumbers = numbers
                .AsParallel()
                .Select(n =>
                {
                    Console.WriteLine($"Processing number {n} on thread {Thread.CurrentThread.ManagedThreadId}");
                    Thread.Sleep(100); // simulate work
                    return n * n;
                });

            // Force execution and print results
            foreach (var sq in squaredNumbers)
            {
                Console.WriteLine($"Square: {sq}");
            }
        }
        static void LinqToDataSetDemo()
        {
            Console.WriteLine("\n=== LINQ to DataSet Demo ===");
            // Create DataTable with columns
            DataTable table = new DataTable("Employees");
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Department", typeof(string));

            // Add some rows
            table.Rows.Add(1, "Alice", "HR");
            table.Rows.Add(2, "Bob", "IT");
            table.Rows.Add(3, "Charlie", "IT");
            table.Rows.Add(4, "David", "Finance");

            // Query DataTable rows using LINQ
            var itEmployees = table.AsEnumerable()
                                   .Where(row => row.Field<string>("Department") == "IT")
                                   .Select(row => new
                                   {
                                       Id = row.Field<int>("Id"),
                                       Name = row.Field<string>("Name"),
                                       Department = row.Field<string>("Department")
                                   });

            foreach (var emp in itEmployees)
            {
                Console.WriteLine($"Employee: {emp.Name}, Dept: {emp.Department}");
            }
        }
        static void LinqToEntitiesDemo()
        {
            Console.WriteLine("\n=== LINQ to Entities Demo (Mock DbContext) ===");

            var context = new MyDbContext();

            var itEmployees = context.Employees.Where(e => e.Department == "IT").ToList();

            foreach (var e in itEmployees)
            {
                Console.WriteLine($"Employee: {e.Name}, Dept: {e.Department}");
            }
        }

        class MyDbContext
        {
            public IQueryable<Employee> Employees { get; }

            public MyDbContext()
            {
                Employees = new List<Employee>
        {
            new Employee { Id=1, Name="Alice", Department="HR"},
            new Employee { Id=2, Name="Bob", Department="IT"},
            new Employee { Id=3, Name="Charlie", Department="IT"},
            new Employee { Id=4, Name="David", Department="Finance"},
        }.AsQueryable();
            }
        }
        class Employee
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Department { get; set; }
        }

        static void LinqToSqlDemo()
        {
            Console.WriteLine("\n=== LINQ to SQL Demo (Mocked) ===");

            IQueryable<Customer> customers = new List<Customer>
    {
        new Customer{ Id=1, Name="Alice", City="London" },
        new Customer{ Id=2, Name="Bob", City="Paris" },
        new Customer{ Id=3, Name="Charlie", City="London" }
    }.AsQueryable();

            // LINQ to SQL typically uses query syntax
            var londonCustomers = from c in customers
                                  where c.City == "London"
                                  select c;

            foreach (var c in londonCustomers)
            {
                Console.WriteLine($"Customer: {c.Name}, City: {c.City}");
            }
        }

        class Customer
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string City { get; set; }
        }
        class Person
        {
            public string Name;
            public int Age;
            public string Department;

            public Person(string name, int age, string dept)
            {
                Name = name;
                Age = age;
                Department = dept;
            }
        }

        class Department
        {
            public string Name;
            public Department(string name) => Name = name;
        }
    }
}
