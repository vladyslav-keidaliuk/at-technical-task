using Business.Models;
using System.Net;
using Business;

namespace Tests.API
{
    [TestFixture]
    public class Tests
    {
        private FailedLoginHistoryService _service;

        [SetUp]
        public void SetUp()
        {
            _service = new FailedLoginHistoryService("https://site.com");
        }

        [Test]
        [Order(1)]
        public async Task GetLoginFailTotal_WithoutParameters_ReturnsAllUsers()
        {
            // Arrange
            var parameters = new LoginFailTotalParams();

            // Act
            var result = await _service.GetLoginFailTotal(parameters);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result);
        }

        [TestCase("testuser1")]
        [TestCase("testuser2")]
        [TestCase("testuser3")]
        [Order(2)]
        public async Task GetLoginFailTotal_WithUserName_ReturnsSpecificUser(string userName)
        {
            var parameters = new LoginFailTotalParams
            {
                UserName = userName
            };

            var result = await _service.GetLoginFailTotal(parameters);

            Assert.IsNotNull(result);
            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result[0].UserName, Is.EqualTo(userName));
        }

        [Test]
        [Order(3)]
        public async Task GetLoginFailTotal_WithFailCount_ReturnsUsersWithFailCount()
        {
            var parameters = new LoginFailTotalParams
            {
                FailCount = 3
            };

            var result = await _service.GetLoginFailTotal(parameters);

            Assert.IsNotNull(result);
            foreach (var user in result)
            {
                Assert.That(user.FailCount, Is.EqualTo(3));
            }
        }

        [Test]
        [Order(4)]
        public async Task GetLoginFailTotal_WithFetchLimit_ReturnsLimitedResults()
        {
            var parameters = new LoginFailTotalParams
            {
                FetchLimit = 5
            };

            var result = await _service.GetLoginFailTotal(parameters);

            Assert.IsNotNull(result);
            Assert.LessOrEqual(result.Count, 5);
        }

        [TestCase("testuser")]
        [Order(6)]
        public async Task GetLoginFailTotal_ReturnsSpecificUser_FailCountIsZero(string userName)
        {
            var parameters = new LoginFailTotalParams
            {
                UserName = userName
            };

            var result = await _service.GetLoginFailTotal(parameters);

            Assert.IsNotNull(result);
            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result[0].FailCount, Is.EqualTo(0));
        }

        [TestCase("testuser")]
        [Order(5)]
        public async Task ResetLoginFailTotal_ValidUsername_SuccessfulReset(string username)
        {
            var statusCode = await _service.ResetLoginFailTotal(username);

            Assert.That(statusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [TestCase("nonexistentuser")]
        [Order(7)]
        public async Task ResetLoginFailTotal_InvalidUsername_ReturnsNotFound(string username)
        {
            var statusCode = await _service.ResetLoginFailTotal(username);

            Assert.That(statusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }
    }
}