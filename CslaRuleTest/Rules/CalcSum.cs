using Csla.Core;
using Csla.Rules;

namespace CslaRuleTest.Rules;

public class CalcSum : PropertyRule
{
    public CalcSum(IPropertyInfo primaryProperty, params IPropertyInfo[] inputProperties) : base(primaryProperty)
    {
        InputProperties = new List<IPropertyInfo>(inputProperties);

        RuleUri.AddQueryParameter("input", string.Join(",", inputProperties.Select(p => p.Name).ToArray()));
        CanRunOnServer = false;
    }

    protected override void Execute(IRuleContext context)
    {
        var sum = context.InputPropertyValues.Sum(property => (dynamic)property.Value);
        context.AddOutValue(PrimaryProperty, sum);
    }
}