namespace BlazorCVA;

public class Variants<TVariant> : Dictionary<TVariant, Dictionary<object, string>>
    where TVariant : Enum
{

}

public class CompoundVariants<TVariant> : List<CompoundVariant<TVariant>>
    where TVariant : Enum
{

}

public class DefaultVariants<TVariant> : Dictionary<TVariant, object>
    where TVariant : Enum
{

}

public class VariantManager<TVariant>
    where TVariant : Enum
{
    public string[] BaseClasses { get; init; } = [];
    public Variants<TVariant> Variants { get; init; } = [];
    public CompoundVariants<TVariant> CompoundVariants { get; init; } = [];
    public DefaultVariants<TVariant> DefaultVariants { get; init; } = [];

    public string GetClass(DefaultVariants<TVariant>? props = null)
    {
        props ??= [];

        var classes = BaseClasses.ToList();

        var mergedProps = DefaultVariants.ToDictionary(d => d.Key, d => props.ContainsKey(d.Key) ? props[d.Key] : d.Value);

        foreach (var variant in Variants)
        {
            if (mergedProps.TryGetValue(variant.Key, out var variantKey) &&
                variant.Value.TryGetValue(variantKey, out string? @class))
            {
                classes.Add(@class);
            }
        }

        foreach (var compoundVariant in CompoundVariants)
        {
            if (compoundVariant.Matches(mergedProps))
            {
                classes.Add(compoundVariant.Class);
            }
        }

        return string.Join(" ", classes);
    }
}