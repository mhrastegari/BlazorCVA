namespace BlazorCVA;

public class VariantCondition<TVariant>
{
    public required TVariant Key { get; init; }
    public required Predicate<object> Predicate { get; init; }

    public static implicit operator VariantCondition<TVariant>((TVariant vairant, object value) condition)
    {
        return new VariantCondition<TVariant>
        {
            Key = condition.vairant,
            Predicate = v => v.Equals(condition.value)
        };
    }

    public static implicit operator VariantCondition<TVariant>((TVariant vairant, Predicate<object> predicate) condition)
    {
        return new VariantCondition<TVariant>
        {
            Key = condition.vairant,
            Predicate = condition.predicate
        };
    }
}

public class CompoundVariant<TVariant>
    where TVariant : Enum
{
    public required string Class { get; init; }
    public List<VariantCondition<TVariant>> Conditions { get; init; } = [];

    public bool Matches(Dictionary<TVariant, object> props)
    {
        return Conditions.All(c => props.TryGetValue(c.Key, out var value) && c.Predicate(value));
    }
}
