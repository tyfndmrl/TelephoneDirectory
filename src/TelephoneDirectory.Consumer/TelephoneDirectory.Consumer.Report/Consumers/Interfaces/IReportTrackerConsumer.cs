﻿using TelephoneDirectory.Consumer.Report.Models.Report;

namespace TelephoneDirectory.Consumer.Report.Consumers.Interfaces
{
    public interface IReportTrackerConsumer
    {
        Task DirectoryLocationReport(DirectoryLocationReportConsumerModel model);
    }
}
