﻿using System;
using System.Globalization;
using System.Linq;
using Xunit;

using Utils = GovDelivery.Library.Utils.GovDeliveryUtils;

namespace GovDelivery.Tests
{
    public class UtilsTests
    {
        public UtilsTests()
        {
        }

        [Theory(DisplayName = "Timezones in date strings become UTC offsets")]
        [InlineData("10/22/2015 03:49 PM CDT")]
        public void TimeZoneBecomesUtcOffset(string data)
        {
            Assert.Equal(Utils.ReplaceTimeZoneWithUtcOffset(data), "10/22/2015 03:49 PM -5");
        }

        [Theory(DisplayName = "Fixed date string becomes DateTime With Expected Values")]
        [InlineData("10/22/2015 03:49 PM CDT")]
        public void FixedDateStringParsesToDateTime(string date)
        {
            var dateParts = Utils.ReplaceTimeZoneWithUtcOffset(date).Split(' ').ToList();
            var dateDay = dateParts.ElementAt(0);
            var dateTime = dateParts
                .GetRange(1, dateParts.Count - 1)
                .Aggregate((memo, next) => $"{memo} {next}");

            Assert.Equal("10/22/2015", dateDay);
            Assert.Equal("03:49 PM -5", dateTime);

            var parsedDay = DateTime.ParseExact(dateDay, Utils.DATE_FORMAT, CultureInfo.CurrentCulture).ToUniversalTime();
            Assert.Equal(parsedDay.Year, 2015);
            Assert.Equal(parsedDay.Month, 10);
            Assert.Equal(parsedDay.Day, 22);

            var parsedTime = DateTime.ParseExact(dateTime, Utils.TIME_FORMAT, CultureInfo.CurrentCulture).ToUniversalTime();
            Assert.Equal(20, parsedTime.Hour);
            Assert.Equal(49, parsedTime.Minute);

            var parsedDate = Utils.DateStringToDateTimeUtc(date);
            Assert.True(parsedDate.GetType() == typeof(DateTime));
        }
    }
}