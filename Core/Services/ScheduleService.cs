using Core.Entities;
using Core.Interfaces;
using Shared.DTOs;
using Shared.Enums;

namespace Core.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly int[] denmarkNotificationDays = { 1, 5, 10, 15, 20 };
        private readonly int[] norwayNotificationDays = { 1, 5, 10, 20 };
        private readonly int[] swedenNotificationDays = { 1, 7, 14, 28 };
        private readonly int[] finlandNotificationDays = { 1, 5, 10, 15, 20 };
        public Schedule CreateSchedule(AddCompanyDTO company)
        {
            if (company == null)
            {
                throw new ArgumentNullException(nameof(company));
            }

            var notificationDays = GetNotificationDaysByMarketAndCompanyType(company.Market, company.CompanyType);

            if (notificationDays == null)
            {
                return null; // Company type or market not supported, no schedule will be created.
            }

            var schedule = new Schedule
            {
                Notifications = GenerateNotifications(notificationDays)
            };

            return schedule;
        }
        private int[] GetNotificationDaysByMarketAndCompanyType(Market market, CompanyType companyType)
        {
            switch (market)
            {
                case Market.Denmark:
                    return denmarkNotificationDays;
                case Market.Norway:
                    return norwayNotificationDays;
                case Market.Sweden:
                    return companyType == CompanyType.Large ? null : swedenNotificationDays;
                case Market.Finland:
                    return companyType == CompanyType.Large ? finlandNotificationDays : null;
                default:
                    return null; // Market not supported, no schedule will be created.
            }
        }

        private List<Notification> GenerateNotifications(int[] notificationDays)
        {
            var currentDate = DateTime.Now.Date;
            var notifications = new List<Notification>();

            for (int i = 0; i < notificationDays.Length; i++)
            {
                var sendingDate = currentDate.AddDays(notificationDays[i]);
                notifications.Add(new Notification { SendingDate = sendingDate });
            }

            return notifications;
        }
    }
}
