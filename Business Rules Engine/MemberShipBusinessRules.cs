using Business_Rules_Engine.AbstractFactory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Rules_Engine
{
    class NewMembShipBusinessRule : IPaymanentOrderProcessing
    {
        object _inputs;
        public NewMembShipBusinessRule(object inputs)
        {
            _inputs = inputs;
        }
        public object Run()
        {
            var result = Activate();
            Notification();
            return result;
        }

        private object Activate()
        {
            //add the business logic here
            return "Membership Activated";
        }
        private void Notification()
        {
            EmailNotifications emailNotifications = new EmailNotifications();
            emailNotifications.Send(_inputs);
        }
    }

    class UpgradeMembBusinessRule : IPaymanentOrderProcessing
    {
        object _inputs;
        public UpgradeMembBusinessRule(object inputs)
        {
            _inputs = inputs;
        }
        public object Run()
        {
            var result = Upgrade();
            Notification();
            return result;
        }

        private object Upgrade()
        {
            //add the business logic here
            return "Membership Upgraded";
        }

        private void Notification()
        {
            EmailNotifications emailNotifications = new EmailNotifications();
            emailNotifications.Send(_inputs);
        }
    }
}
