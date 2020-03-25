using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using CowboyCafe.Data;
using System.ComponentModel;

namespace CowboyCafe.DataTests
{
    public class TestPropertyChanges
    {

        [Theory]
        [InlineData(typeof(AngryChicken))]
        [InlineData(typeof(CowpokeChili))]
        public void AllImplementINotifyPropertyChanged(Type testType)
        {
            object testObject = Activator.CreateInstance(testType);
            Assert.IsAssignableFrom<INotifyPropertyChanged>(testObject);
        }
    }
}
