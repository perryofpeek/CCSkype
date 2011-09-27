using System;
using NUnit.Framework;

namespace CCSkype.UnitTests.sleep
{
    // ReSharper disable InconsistentNaming
    [TestFixture]
    public class With_sleep
    {
        [Test]
        public void Should_sleep_for_a_one_second_period()
        {
            var time = 1;
            ISleeper sleeper = new Sleeper(time);
            var start = DateTime.Now;
            var rtn = sleeper.Sleep();
            var end = DateTime.Now;
            Assert.That(end.Subtract(start).Seconds, Is.EqualTo(1));
            Assert.That(rtn, Is.EqualTo(true));
        }        
    }
}