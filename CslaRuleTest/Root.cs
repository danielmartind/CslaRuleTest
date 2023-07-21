using Csla;
using Csla.Rules.CommonRules;
using CslaRuleTest.Rules;

namespace CslaRuleTest;

[Serializable]
public class Root : BusinessBase<Root>
{
    public static readonly PropertyInfo<int> Num1Property = RegisterProperty<int>(nameof(Num1));

    public int Num1
    {
        get => GetProperty(Num1Property);
        set => SetProperty(Num1Property, value);
    }

    public static readonly PropertyInfo<int> Num2Property = RegisterProperty<int>(nameof(Num2));

    public int Num2
    {
        get => GetProperty(Num2Property);
        set => SetProperty(Num2Property, value);
    }

    public static readonly PropertyInfo<int> Num3Property = RegisterProperty<int>(nameof(Num3));

    public int Num3
    {
        get => GetProperty(Num3Property);
        set => SetProperty(Num3Property, value);
    }

    public static readonly PropertyInfo<int> TotalProperty = RegisterProperty<int>(nameof(Total), "Total Value", defaultValue: 0);

    public int Total
    {
        get => GetProperty(TotalProperty);
        private set => LoadProperty(TotalProperty, value);
    }

    public override string ToString()
    {
        return $"Num1: {Num1}\t Num2: {Num2}\t Num3: {Num3}\t Total: {Total}\t IsValid: {IsValid}";
    }

    protected override void AddBusinessRules()
    {
        base.AddBusinessRules();

        BusinessRules.AddRule(new MinValue<int>(Num1Property, 5));
        BusinessRules.AddRule(new MinValue<int>(Num2Property, 10));
        BusinessRules.AddRule(new MinValue<int>(Num3Property, 15));

        BusinessRules.AddRule(new StopIfNotValid(TotalProperty));
        BusinessRules.AddRule(new CalcSum(TotalProperty, Num1Property, Num2Property, Num3Property) { Priority = 10 });
    }

    [Create]
    private void Create()
    {
        BusinessRules.CheckRules();
    }
}