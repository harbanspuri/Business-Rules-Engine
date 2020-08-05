using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Rules_Engine
{
    public enum DepartType
    {
        Royality,
        Other
    }

    public enum RuleEngineType
    {
        GeneratePackSlip,
        GenerateDuplicatePackSlip,
        NewMembership,
        UpgradeMembership,
        LearningToSki
    }

    public enum PaymentProductType
    {
        PhysicalProduct,
        Book,
        MembershipNew,
        MembershipUpgrade,
        VideoLearning
    }
}
