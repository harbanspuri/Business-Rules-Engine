using Business_Rules_Engine;
using Business_Rules_Engine.AbstractFactory;
using NUnit.Framework;
using System.Reflection.Metadata.Ecma335;

namespace NUnitTestProject
{
    public class Tests
    {
        
        [Test]
        public void TestGeneratePackSlip()
        {
            object inputs = string.Empty;
            IPaymanentOrderProcessing orderProcessing = Helper(PaymentProductType.PhysicalProduct, RuleEngineType.GeneratePackSlip, inputs);
            object actual = orderProcessing.Run();
            object expected = "Packing Slip for Shipping is ";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestGenerateDuplicatePackSlip()
        {
            object inputs = string.Empty;
            IPaymanentOrderProcessing orderProcessing = Helper(PaymentProductType.PhysicalProduct, RuleEngineType.GenerateDuplicatePackSlip, inputs);
            object actual = orderProcessing.Run();
            object expected = "Duplicate Packing Slip for Shipping is ";
            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void TestNewMembership()
        {
            object inputs = string.Empty;
            IPaymanentOrderProcessing orderProcessing = Helper(PaymentProductType.MembershipNew, RuleEngineType.NewMembership, inputs);
            object actual = orderProcessing.Run();
            object expected = "Membership Activated";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestUpgradeMembership()
        {
            object inputs = string.Empty;
            IPaymanentOrderProcessing orderProcessing = Helper(PaymentProductType.MembershipUpgrade, RuleEngineType.UpgradeMembership, inputs);
            object actual = orderProcessing.Run();
            object expected = "Membership Upgraded";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestLearningSki()
        {
            object inputs = string.Empty;
            IPaymanentOrderProcessing orderProcessing = Helper(PaymentProductType.VideoLearning, RuleEngineType.LearningToSki, inputs);
            object actual = orderProcessing.Run();
            object expected = "Added free First Aid video to the packing slip";
            Assert.AreEqual(expected, actual);
        }


        public IPaymanentOrderProcessing Helper(PaymentProductType productType, RuleEngineType ruleEngineType, object inputs)
        {
            IPaymanentOrderProcessing paymanentOrderProcessing;
            OrderFactory factoryObj;
            factoryObj = PackSlipFactory.CreateProductFactory(productType);
            paymanentOrderProcessing = factoryObj.GetBusinessProcessingRule(ruleEngineType, inputs);
            return paymanentOrderProcessing;
        }
    }
}