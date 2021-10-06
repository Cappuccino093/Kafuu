namespace Kafuu.Core.Models.Discord;

public static class Optional
{
	public static int Compare<T>(Optional<T> type1, Optional<T> type2) => type1.CompareTo(type2);
	public static bool Equals<T>(Optional<T> type1, Optional<T> type2) => type1.Equals(type2);
}

[JsonConverter(typeof(OptionalConverter))]
public struct Optional<T> : IComparable<Optional<T>>, IEquatable<Optional<T>>, IComparable<T>, IEquatable<T>
{
	public static implicit operator Optional<T>(T value) => new(value);
	public static explicit operator T(Optional<T> optional) => optional.Value;
	public static bool operator ==(Optional<T> optional1, Optional<T> optional2) => optional1.Equals(optional2);
	public static bool operator !=(Optional<T> optional1, Optional<T> optional2) => !optional1.Equals(optional2);
	public static bool operator ==(Optional<T> optional, T type) => optional.Equals(type);
	public static bool operator !=(Optional<T> optional, T type) => !optional.Equals(type);

	public bool HasValue { get; private init; }
	public T Value { get; set; }

	public Optional(T value) =>
		(this.HasValue, this.Value) = (true, value);

	public override string ToString() => this.HasValue ? this.Value.ToString() : "unspecified";
	public override int GetHashCode() => this.HasValue ? this.Value.GetHashCode() : 0;
	public bool Equals(Optional<T> other) => this.HasValue && other.HasValue
		? this.Value.Equals(other.Value)
		: !this.HasValue && !other.HasValue ? true : false;
	public bool Equals(T other) => this.HasValue ? this.Value.Equals(other) : false;
	public override bool Equals(object @object) =>
		@object switch
		{
			T type => this.Equals(type),
			Optional<T> optional => this.Equals(optional),
			_ => false
		};
	public int CompareTo(Optional<T> other) => this.HasValue && other.HasValue
		? Comparer<T>.Default.Compare(this.Value, other.Value)
		: this.HasValue
			? 1
			: other.HasValue
				? -1
				: 0; 
	public int CompareTo(T other) => this.HasValue ? Comparer<T>.Default.Compare(this.Value, other) : -1;
}
