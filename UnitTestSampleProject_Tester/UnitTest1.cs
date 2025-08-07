using Moq;
using static UnitTestSampleProject.LegacyService;

namespace UnitTestSampleProject_Tester
{
    public class UnitTest1
    {
        [Fact]
        public void AddNumbers_ShouldReturnSum()
        {
            var service = new UnitTestSampleProject.LegacyService();
            var result = service.AddNumbers(2, 3);
            Assert.Equal(5, result);
        }

        [Fact]
        public void PushMessageToCloudQueue_ShouldReturnSuccess()
        {
            var mock = new Mock<UnitTestSampleProject.LegacyService>();
            mock.Setup(x => x.PushMessageToCloudQueue(It.IsAny<string>())).Returns("Success");
            var result = mock.Object.PushMessageToCloudQueue("test");
            Assert.Equal("Success", result);
        }

        [Fact]
        public void SetRedisCache_ShouldReturnSameValue()
        {
            var mock = new Mock<UnitTestSampleProject.LegacyService>();
            mock.Setup(x => x.SetRedisCache("key", "val")).Returns("val");
            var result = mock.Object.SetRedisCache("key", "val");
            Assert.Equal("val", result);
        }

        [Fact]
        public async Task GetWeatherFromApi_ShouldReturnStubResponse()
        {
            var mock = new Mock<UnitTestSampleProject.LegacyService>();
            mock.Setup(x => x.GetWeatherFromApi(It.IsAny<string>())).ReturnsAsync("sunny");
            var result = await mock.Object.GetWeatherFromApi("Pune");
            Assert.Equal("sunny", result);
        }

        [Fact]
        public void IntegrationTest_ProcessUserData()
        {
            var mock = new Mock<UnitTestSampleProject.LegacyService>();
            mock.Setup(x => x.GetUserFromDatabase(It.IsAny<int>())).Returns("Prajwal");
            mock.Setup(x => x.GetWeatherFromApi(It.IsAny<string>())).ReturnsAsync("cloudy");
            mock.Setup(x => x.PushMessageToCloudQueue(It.IsAny<string>())).Returns("Success");
            mock.Setup(x => x.SetRedisCache(It.IsAny<string>(), It.IsAny<string>())).Returns("Prajwal");

            var result = mock.Object.ProcessUserData(1);
            Assert.Contains("User=Prajwal", result);
            Assert.Contains("Weather=cloudy", result);
            Assert.Contains("Push=Success", result);
            Assert.Contains("Redis=Prajwal", result);
        }

        [Fact]
        public void GetCriticalUser_ShouldThrowException_WhenInvalidUserId()
        {
            var mock = new Mock<UnitTestSampleProject.LegacyService>();
            mock.Setup(x => x.GetCriticalUser(It.IsAny<int>())).Throws(new Exception("DB error"));
            var ex = Assert.Throws<Exception>(() => mock.Object.GetCriticalUser(-1));
            Assert.Equal("DB error", ex.Message);
        }
        [Fact]
        public void SaveStudentToDb_ShouldReturnSaved()
        {
            var mock = new Mock<UnitTestSampleProject.LegacyService>();
            var student = new UnitTestSampleProject.Student { Id = 1, Name = "Prajwal", Email = "test@email.com" };
            mock.Setup(x => x.SaveStudentToDb(It.IsAny<UnitTestSampleProject.Student>())).Returns("Saved");

            var result = mock.Object.SaveStudentToDb(student);
            Assert.Equal("Saved", result);
        }

        [Fact]
        public void SaveStudentFromApiJson_ShouldReturnSaved()
        {
            var mock = new Mock<UnitTestSampleProject.LegacyService>();
            var json = "{\"Id\":1,\"Name\":\"Prajwal\",\"Email\":\"test@email.com\"}";
            mock.Setup(x => x.SaveStudentToDb(It.IsAny<UnitTestSampleProject.Student>())).Returns("Saved");
            var result = mock.Object.SaveStudentFromApiJson(json);
            Assert.Equal("Saved", result);
        }
        [Fact]
        public void ProcessUserFromQueuesAndSave_ShouldReturnCombinedData()
        {
            var mock = new Mock<UnitTestSampleProject.LegacyService>();

            // Setup all internal calls
            mock.Setup(x => x.ReadFromSqs()).Returns("123");
            mock.Setup(x => x.ReadFromKafka()).Returns("secure-token-xyz");
            mock.Setup(x => x.GetUserFromDatabase(It.IsAny<int>())).Returns("Prajwal");
            mock.Setup(x => x.GetWeatherFromApi(It.IsAny<string>())).ReturnsAsync("CloudyData");
            mock.Setup(x => x.SetRedisCache(It.IsAny<string>(), It.IsAny<string>())).Returns("OK");
            mock.Setup(x => x.SaveStudentToDb(It.IsAny<UnitTestSampleProject.Student>())).Returns("Saved");
            // Call the method
            var result = mock.Object.ProcessUserFromQueuesAndSave();
            // Assertions
            Assert.Equal("123", result.UserId);
            Assert.Equal("Prajwal", result.UserDetails);
            Assert.Equal("CloudyData", result.ApiData);
            Assert.Equal("OK", result.RedisUpdateStatus);
            Assert.Equal("Saved", result.DbSaveStatus);
        }

    }
    public class NotificationServiceTests
    {
        [Fact]
        public void Notify_ShouldCallSend()
        {
            var mockSender = new Mock<IMessageSender>();
            mockSender.Setup(s => s.Send(It.IsAny<string>())).Returns("Sent");

            var service = new NotificationService(mockSender.Object);
            var result = service.Notify("Hello");

            Assert.Equal("Sent", result);
        }
    }
}