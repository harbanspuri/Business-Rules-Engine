using Business_Rules_Engine.AbstractFactory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Rules_Engine
{

    // Concrete Products are created by corresponding Concrete Factories.
    class PackSlipBusinessRule : IPaymanentOrderProcessing
    {
        object _inputs;
        public PackSlipBusinessRule(object inputs)
        {
            _inputs = inputs;
        }

        public object Run()
        {
            AgentCommisionPayment commisionPayment = new AgentCommisionPayment(_inputs);
            commisionPayment.GenerateCommission();

            return GeneratePackShip();
        }

        private object GeneratePackShip()
        {
            //add the logic to generate the shipment number
            return "Packing Slip for Shipping is ";
        }
    }
    class DuplicatePackSlipBusinessRule : IPaymanentOrderProcessing
    {
        object _inputs;
        public DuplicatePackSlipBusinessRule(object inputs)
        {
            _inputs = inputs;
        }
        public object Run()
        {
            AgentCommisionPayment commisionPayment = new AgentCommisionPayment(_inputs);
            commisionPayment.GenerateCommission();

            return GenerateDupPackShip();
        }

        private object GenerateDupPackShip()
        {
            //add the logic to generate the shipment number
            return "Duplicate Packing Slip for Shipping is ";
        }
    }

    class AgentCommisionPayment
    {
        object _inputs;

        public AgentCommisionPayment(object inputs)
        {
            _inputs = inputs;
        }

        public object GenerateCommission()
        {
            return "Commission Generated";
        }
    }
}