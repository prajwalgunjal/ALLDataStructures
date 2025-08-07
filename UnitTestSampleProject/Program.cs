using StackExchange.Redis;
using System.Text.Json;

namespace UnitTestSampleProject
{
    // One-liner cheat sheet for demo
    // Mock = Fake version of class used in tests to control behavior
    // Stub = A pre-programmed method return (subset of mocks)
    // Integration Test = Testing multiple real parts working together
    // Friction = Difficulty in testing due to tight coupling or poor structure
    // AutoMock = Auto creation of mocks using DI container (future DI-based test)

    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
    public class LegacyService
    {
        // 1. Arithmetic operation
        public int AddNumbers(int a, int b)
        {
            return a + b;
        }

        // 2. DB operation without DI
        public string GetUserFromDatabase(int userId)
        {
            // Simulate DB call
            using (var conn = new Microsoft.Data.SqlClient.SqlConnection("Data Source=.;Initial Catalog=TestDB;Integrated Security=True"))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = $"SELECT Name FROM Users WHERE Id = {userId}";
                    var result = cmd.ExecuteScalar();
                    return result?.ToString() ?? "User not found";
                }
            }
        }

        // 3. API call simulation
        public async Task<string> GetWeatherFromApi(string city)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"https://api.weather.com/{city}");
                return await response.Content.ReadAsStringAsync();
            }
        }

        // 4. Cloud Operation (e.g., SQS like push)
        public string PushMessageToCloudQueue(string message)
        {
            // Simulate cloud operation
            Console.WriteLine("Message pushed to SQS: " + message);
            return "Success";
        }

        // 5. Redis Operation
        public string SetRedisCache(string key, string value)
        {
            var redis = ConnectionMultiplexer.Connect("localhost");
            var db = redis.GetDatabase();
            db.StringSet(key, value);
            return db.StringGet(key);
        }

        // 6. Integration Method
        public string ProcessUserData(int userId)
        {
            var user = GetUserFromDatabase(userId);
            var weather = Task.Run(() => GetWeatherFromApi("Mumbai")).Result;
            var pushStatus = PushMessageToCloudQueue(user);
            var cacheStatus = SetRedisCache("lastUser", user);

            return $"User={user}, Weather={weather}, Push={pushStatus}, Redis={cacheStatus}";
        }

        // 7 raising exception 
        public string GetCriticalUser(int userId)
        {
            if (userId < 0)
                throw new Exception("Invalid userId");
            return "OK";
        }
        // 8 Save class object to DB (simulate runtime connection)
        public virtual string SaveStudentToDb(Student s)
        {
            using (var conn = new Microsoft.Data.SqlClient.SqlConnection("Data Source=.;Initial Catalog=TestDB;Integrated Security=True"))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = $"INSERT INTO Students (Id, Name, Email) VALUES ({s.Id}, '{s.Name}', '{s.Email}')";
                    cmd.ExecuteNonQuery();
                    return "Saved";
                }
            }
        }

        // 9 Simulate receiving JSON from API and saving it
        public virtual string SaveStudentFromApiJson(string json)
        {
            var student = JsonSerializer.Deserialize<Student>(json);
            return SaveStudentToDb(student);
        }
        // 10 Realtime data processing (e.g., gettting data from Kafka or SQS)
        public class CombinedUserData
        {
            public string UserId { get; set; }
            public string UserDetails { get; set; }
            public string ApiData { get; set; }
            public string RedisUpdateStatus { get; set; }
            public string DbSaveStatus { get; set; }
        }

        public virtual string ReadFromSqs()
        {
            // Simulate reading userId from SQS
            return "123";
        }

        public virtual string ReadFromKafka()
        {
            // Simulate reading token from Kafka
            return "secure-token-xyz";
        }

        public virtual CombinedUserData ProcessUserFromQueuesAndSave()
        {
            var userId = ReadFromSqs();
            var token = ReadFromKafka();
            var userDetails = GetUserFromDatabase(int.Parse(userId));
            var apiData = Task.Run(() => GetWeatherFromApi(userId + "-" + token)).Result;

            var combined = new CombinedUserData
            {
                UserId = userId,
                UserDetails = userDetails,
                ApiData = apiData
            };

            combined.RedisUpdateStatus = SetRedisCache("user_insight_" + userId, apiData);
            combined.DbSaveStatus = SaveStudentToDb(new Student
            {
                Id = int.Parse(userId),
                Name = userDetails,
                Email = $"{userDetails.ToLower()}@example.com"
            });

            return combined;
        }

        // Example of using AutoMock (DI-friendly scenario)
        public interface IMessageSender
        {
            string Send(string msg);
        }

        public class NotificationService
        {
            private readonly IMessageSender _sender;

            public NotificationService(IMessageSender sender)
            {
                _sender = sender;
            }

            public string Notify(string msg)
            {
                return _sender.Send(msg);
            }
        }

    }
}
