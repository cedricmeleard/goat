namespace LordOfTheRings.Domain;

public sealed class WeaponName : IEquatable<WeaponName>
{
    private readonly string _name;
    private WeaponName(string name)
    {
        _name = name;
    }

    public bool Equals(WeaponName? other) => other is not null && string.Equals(_name, other._name, StringComparison.InvariantCultureIgnoreCase);

    public static WeaponName Parse(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) {
            throw new ArgumentException("A weapon must have a name.");
        }
        return new WeaponName(name);
    }

    public override string ToString() => _name;

    public static bool operator ==(WeaponName? left, WeaponName? right) => Equals(left, right);
    public static bool operator !=(WeaponName? left, WeaponName? right) => !Equals(left, right);

    public override bool Equals(object? obj) => Equals((WeaponName?)obj);
    public override int GetHashCode() => _name?.GetHashCode() ?? 0;
}