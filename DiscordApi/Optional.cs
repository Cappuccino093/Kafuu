// Original source code: https://stackoverflow.com/questions/63418549/custom-json-serializer-for-optional-property-with-system-text-json

using System.Collections.Generic;

namespace DiscordApi;

public static class Optional
{
    public static int Compare<T>(Optional<T> type1, Optional<T> type2) => Comparer<T>.Default.Compare(type1.Value, type2.Value);
    public static bool Equals<T>(Optional<T> type1, Optional<T> type2) => Equals(type1.Value, type2.Value);
}

[JsonConverter(typeof(OptionalConverter))]
public struct Optional<T> : IComparable<Optional<T>>, IEquatable<Optional<T>>, IComparable<T>, IEquatable<T>
{
    private readonly T _value;

    public bool HasValue { get; }
    public T Value
    {
        get
        {
            if (!HasValue)
                throw new InvalidOperationException("Value has not been set.");

            return _value;
        }
    }

    public Optional(T value) =>
        (HasValue, _value) = (true, value);

    public static implicit operator Optional<T>(T value) => new(value);
    public static explicit operator T(Optional<T> optional) => optional.Value;
    public static bool operator ==(Optional<T> optional1, Optional<T> optional2) => optional1.Equals(optional2);
    public static bool operator !=(Optional<T> optional1, Optional<T> optional2) => !optional1.Equals(optional2);
    public static bool operator ==(Optional<T> optional, T type) => optional.Equals(type);
    public static bool operator !=(Optional<T> optional, T type) => !optional.Equals(type);

    public override string ToString() => HasValue ? Value.ToString() : string.Empty;
    public override int GetHashCode() => HasValue ? Value.GetHashCode() : 0;
    public bool Equals(Optional<T> other) => !HasValue && !other.HasValue || HasValue == other.HasValue && Value.Equals(other.Value);
    public bool Equals(T other) => HasValue && Value.Equals(other);
    public override bool Equals(object @object) =>
        @object switch
        {
            T type => Equals(type),
            Optional<T> optional => Equals(optional),
            _ => false
        };
    public int CompareTo(Optional<T> other) => HasValue ? Comparer<T>.Default.Compare(Value, other.Value) : -1;
    public int CompareTo(T other) => HasValue ? Comparer<T>.Default.Compare(Value, other) : -1;
}
