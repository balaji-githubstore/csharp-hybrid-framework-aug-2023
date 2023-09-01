using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unisys.Base;

namespace RedBusAutomation
{
    public class LoginUITest : AutomationWrapper
    {
        [Test]
        public void ValidateTitleTest()
        {
            Assert.That(driver.Title,Is.EqualTo("Online Bus Ticket Booking at Low Price and Best Offers - redBus"));
        }
    }
}
