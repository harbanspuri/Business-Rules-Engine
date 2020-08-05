using System;
using System.Runtime.InteropServices.ComTypes;

namespace Business_Rules_Engine.AbstractFactory
{
    public abstract class OrderFactory
    {
        public abstract IPaymanentOrderProcessing GetBusinessProcessingRule(RuleEngineType ruleEngine, object inputs);
        public static OrderFactory CreateProductFactory(PaymentProductType productType, DepartType departType = DepartType.Other)
        {
            //create the factory object for physical and book 
            if (productType.Equals(PaymentProductType.PhysicalProduct) || ((productType.Equals(PaymentProductType.Book) && departType.Equals(DepartType.Royality))))
                return new PackSlipFactory();
            else if (productType.Equals(PaymentProductType.MembershipNew) || productType.Equals(PaymentProductType.MembershipUpgrade))
                return new MembershipFactory();
            else if (productType.Equals(PaymentProductType.VideoLearning))
                return new LearningFactory();

            else
                return null;
        }
    }

    // Each distinct product of a product family should have a base interface.
    // All variants of the product must implement this interface.
    public interface IPaymanentOrderProcessing
    {
        public Object Run();
    }


    //Shippment Slip Factory
    public class PackSlipFactory : OrderFactory
    {
        public override IPaymanentOrderProcessing GetBusinessProcessingRule(RuleEngineType ruleEngine, object inputs)
        {
            if (ruleEngine.Equals(RuleEngineType.GeneratePackSlip))
            {
                return new PackSlipBusinessRule(inputs);
            }
            else if (ruleEngine.Equals(RuleEngineType.GenerateDuplicatePackSlip))
            {
                return new DuplicatePackSlipBusinessRule(inputs);
            }
            else
                return null;
        }
    }

    //Membership Factory
    public class MembershipFactory : OrderFactory
    {
        public override IPaymanentOrderProcessing GetBusinessProcessingRule(RuleEngineType ruleEngine, object inputs)
        {
            if (ruleEngine.Equals(RuleEngineType.NewMembership))
            {
                return new NewMembShipBusinessRule(inputs);
            }
            else if (ruleEngine.Equals(RuleEngineType.UpgradeMembership))
            {
                return new UpgradeMembBusinessRule(inputs);
            }
            else
                return null;
        }
    }
        //Membership Factory
        public class LearningFactory : OrderFactory
        {
            public override IPaymanentOrderProcessing GetBusinessProcessingRule(RuleEngineType ruleEngine, object inputs)
            {
                if (ruleEngine.Equals(RuleEngineType.LearningToSki))
                {
                    return new LearningToSkiBusinessRule(inputs);
                }
                else
                    return null;
            }
        }

}
