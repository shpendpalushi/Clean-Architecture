using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Hahn.ApplicationProcess.February2021.Tests.ValidatorTests
{
    public class DateValidatorTests
    {
        [Theory, ClassData(typeof(DataGeneratorDate))]
        public void DateComparerShouldWork(DateTime currentDate, DateTime oldDate, bool isValid)
        {
            //action
            bool differenceIsBiggerThan0 = (currentDate - oldDate).TotalDays / 365 < 1 && (currentDate - oldDate).TotalDays / 365 > 0;

            //assert
            Assert.Equal(differenceIsBiggerThan0, isValid);
            
        }

    }

    public class DataGeneratorDate : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[]{DateTime.UtcNow, DateTime.UtcNow.AddYears(-1).AddMonths(-1), false },
            new object[]{DateTime.UtcNow, DateTime.UtcNow.AddMonths(-1), true},
            new object[]{DateTime.UtcNow, DateTime.UtcNow.AddDays(-12), true},
            new object[]{ DateTime.UtcNow, DateTime.UtcNow.AddYears(-1).AddDays(-1), false}
        };

        public IEnumerator<object[]> GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}
