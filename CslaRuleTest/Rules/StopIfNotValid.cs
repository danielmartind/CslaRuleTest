using Csla.Core;
using Csla.Rules;

namespace CslaRuleTest.Rules;

public class StopIfNotValid : PropertyRule
{
    public StopIfNotValid(IPropertyInfo primaryProperty) : base(primaryProperty)
    {
    }

    protected override void Execute(IRuleContext context)
    {
        if (!((BusinessBase)context.Target).IsValid)
        {
            context.AddSuccessResult(true);
        }
    }
}