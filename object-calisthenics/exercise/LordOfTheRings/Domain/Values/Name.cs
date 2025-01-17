using System;

namespace LordOfTheRings.Domain.Values;

public class Name : IEquatable<Name>
{
    private readonly string _name;
    private Name(string name)
    {
        _name = name;
    }

    public bool Equals(Name? other) => other is not null && _name.Equals(other._name, StringComparison.InvariantCultureIgnoreCase);

    public static Name Parse(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) {
            throw new ArgumentException("Character must have a name.");
        }
        return new Name(name);
    }

    public override string ToString() => _name;

    public static bool operator ==(Name? left, Name? right) => Equals(left, right);
    public static bool operator !=(Name? left, Name? right) => !Equals(left, right);
    public override bool Equals(object? obj) => Equals((Name?)obj);
    public override int GetHashCode() => _name.GetHashCode();
}