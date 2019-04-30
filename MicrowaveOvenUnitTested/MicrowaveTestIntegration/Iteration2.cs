using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;
using NSubstitute;
using MicrowaveOvenClasses.Boundary;
using MicrowaveOvenClasses.Controllers;
using MicrowaveOvenClasses.Interfaces;
using Timer = MicrowaveOvenClasses.Boundary.Timer;
using TimeSpan = System.TimeSpan;

namespace MicrowaveTestIntegration
{
    [TestFixture]
    class Iteration2
    {
        private IUserInterface fakeUserInterface;
        private IDisplay fakeDisplay;
        private ITimer timer;
        private IPowerTube powerTube;
        private IOutput fakeOutput;
        private ICookController sut;

        [SetUp]
        public void SetUp()
        {
            fakeUserInterface = Substitute.For<IUserInterface>();
            fakeDisplay = Substitute.For<IDisplay>();
            fakeOutput = Substitute.For<IOutput>();

            timer = new Timer();
            powerTube = new PowerTube(fakeOutput);

            sut = new CookController(timer, fakeDisplay, powerTube, fakeUserInterface);
        }

        #region timer/cookController

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(10)]
        public void cookController_startCooking_displayTime_Test(int time)
        {
            var t = TimeSpan.FromSeconds(time);
            sut.StartCooking(50, t);

            var delay = t + TimeSpan.FromSeconds(1);
            Thread.Sleep(Convert.ToInt32(delay.TotalMilliseconds));

            fakeDisplay.Received(1).ShowTime(t - TimeSpan.FromSeconds(1));
        }

        [TestCase(1)]
        public void cookController_startCooking_displayTime_zero_Test(int time)
        {
            var t = TimeSpan.FromSeconds(time);
            sut.StartCooking(50, t);

            var delay = t + TimeSpan.FromSeconds(1);
            Thread.Sleep(Convert.ToInt32(delay.TotalMilliseconds));

            fakeDisplay.Received(1).ShowTime(TimeSpan.Zero);
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(10)]
        public void cookController_startCooking_StartTimer_RemainingTime(int time)
        {
            var t = TimeSpan.FromSeconds(time);
            sut.StartCooking(50, t);


            Assert.That(timer.TimeRemaining.TotalSeconds, Is.EqualTo(time));
        }

        #endregion





    }
}
