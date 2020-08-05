using Business_Rules_Engine.AbstractFactory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Rules_Engine
{ // Concrete Products are created by corresponding Concrete Factories.
    class LearningToSkiBusinessRule : IPaymanentOrderProcessing
    {
        object _inputs;
        public LearningToSkiBusinessRule(object inputs)
        {
            _inputs = inputs;
        }

        public object Run()
        {
            return AddFreeFirstAid();
        }

        private object AddFreeFirstAid()
        {
            //add the logic to generate the shipment number
            return "Added free First Aid video to the packing slip";
        }
    }
}
