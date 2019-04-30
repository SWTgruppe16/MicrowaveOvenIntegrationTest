using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;
using MicrowaveOvenClasses.Boundary;
using MicrowaveOvenClasses.Controllers;
using MicrowaveOvenClasses.Interfaces;
using NUnit;
using NSubstitute;

namespace MicrowaveTestIntegration
{
    [TestFixture]
    public class Iteration3
    {
        //Fakes
        private ITimer fakeTimer; //Lavet som fake, fordi det ellers ville tage for lang tid at køre testprogrammet
        private IOutput fakeOutput;
        private IDoor fakeDoor;
        private CookController cookController;


        //System under test
        private IDisplay display;
        private IPowerTube powerTube;
        
        private IUserInterface sut;
        private ILight light;

        //buttons
        private IButton powerButton;
        private IButton timerButton;
        private IButton startCancelButton;
    }
}
