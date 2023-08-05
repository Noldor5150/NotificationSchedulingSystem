using Core.Entities;
using Core.Interfaces;
using Core.Services;
using Moq;
using Shared.DTOs;
using Shared.Enums;

namespace UnitTests
{
    public class CompnayServiceShould
    {
        [Fact]
        public async Task CreateCompanyAsync_Should_Create_Company_With_Schedule()
        {
            var company = new AddCompanyDTO
            {
                Id = Guid.NewGuid(),
                CompanyNumber = "0123456789",
                CompanyType = CompanyType.Small,
                Market = Market.Denmark
            };

            var scheduleServiceMock = new Mock<IScheduleService>();
            var repositoryMock = new Mock<ICompanyRepository>();

            var service = new CompanyService(repositoryMock.Object, scheduleServiceMock.Object);

            var schedule = new Schedule
            {
                Id = 1,
                CompanyId = company.Id,
                Notifications = new List<Notification>
                {
                   new Notification { Id = 1, SendingDate = DateTime.Now.AddDays(1)  },
                   new Notification { Id = 2, SendingDate = DateTime.Now.AddDays(5)  },
                   new Notification { Id = 2, SendingDate = DateTime.Now.AddDays(10) },
                   new Notification { Id = 2, SendingDate = DateTime.Now.AddDays(15) },
                   new Notification { Id = 2, SendingDate = DateTime.Now.AddDays(20) },
                }
            };

            
            scheduleServiceMock.Setup(s => s.CreateSchedule(It.IsAny<AddCompanyDTO>())).Returns(schedule);

            var result = await service.CreateCompanyAsync(company);

            Assert.NotNull(result);
            Assert.Equal(company.Id, result.CompanyId);
            Assert.NotEmpty(result.Notifications);
        }

        [Fact]
        public async Task GetCompanyNotificationsByIdAsync_Should_Return_Company_With_Notifications()
        {
            var companyId = Guid.NewGuid();

            var companyWithSchedule = new Company
            {
                Id = companyId,
                CompanyNumber = "0123456789",
                CompanyType = CompanyType.Small,
                Market = Market.Denmark,
                Schedule = new Schedule
                {
                    Id = 1,
                    CompanyId = companyId,
                    Notifications = new List<Notification>
                    {
                        new Notification { Id = 1, SendingDate = DateTime.Now.AddDays(1) },
                        new Notification { Id = 2, SendingDate = DateTime.Now.AddDays(5) },
                        new Notification { Id = 2, SendingDate = DateTime.Now.AddDays(10) },
                        new Notification { Id = 2, SendingDate = DateTime.Now.AddDays(15) },
                        new Notification { Id = 2, SendingDate = DateTime.Now.AddDays(20) },
                    }
                }
            };

            var repositoryMock = new Mock<ICompanyRepository>();
            repositoryMock.Setup(r => r.GetCompanyNotificationsByIdAsync(companyId)).ReturnsAsync(companyWithSchedule);

            var service = new CompanyService(repositoryMock.Object, Mock.Of<IScheduleService>());

            var result = await service.GetCompanyNotificationsByIdAsync(companyId);

            Assert.NotNull(result);
            Assert.Equal(companyId, result.CompanyId);
            Assert.NotEmpty(result.Notifications);
        }

        [Fact]
        public async Task GetCompanyNotificationsByIdAsync_Should_Return_Null_For_Non_Existent_Company()
        {
            var companyId = Guid.NewGuid();

            var repositoryMock = new Mock<ICompanyRepository>();
            repositoryMock.Setup(r => r.GetCompanyNotificationsByIdAsync(companyId)).ReturnsAsync((Company)null);

            var service = new CompanyService(repositoryMock.Object, Mock.Of<IScheduleService>());

            var result = await service.GetCompanyNotificationsByIdAsync(companyId);

            Assert.Null(result);
        }
    }
}
