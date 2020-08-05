using Business_Rules_Engine.AbstractFactory;
using System;

namespace Business_Rules_Engine
{
    class Program
    {
        static void Main(string[] args)
        {
            object inputs = string.Empty;

            IPaymanentOrderProcessing paymanentOrderProcessing;
            OrderFactory factoryObj;
            factoryObj = PackSlipFactory.CreateProductFactory(PaymentProductType.VideoLearning);

            RuleEngineType ruleType = RuleEngineType.LearningToSki;

            paymanentOrderProcessing = factoryObj.GetBusinessProcessingRule(ruleType, inputs);
            
            var result = paymanentOrderProcessing.Run();

            Console.WriteLine(result.ToString());
            Console.ReadLine();
        }
    }
}
