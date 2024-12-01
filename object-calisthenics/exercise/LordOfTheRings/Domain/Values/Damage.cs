namespace LordOfTheRings.Domain.Values;

public sealed class Damage : IEquatable<Damage>
{
    private readonly int _damage;
    private Damage(int damage)
    {
        _damage = damage;
    }

    public bool Equals(Damage? other)
    {
        if (other is null) {
            return false;
        }
        return _damage == other._damage;
    }

    public static Damage Parse(int damage)
    {
        if (damage <= 0) {
            throw new ArgumentException("A weapon must have a damage level.");
        }

        return new Damage(damage);
    }

    public static bool operator ==(Damage? left, Damage? right) => Equals(left, right);
    public static bool operator !=(Damage? left, Damage? right) => !Equals(left, right);
    public override bool Equals(object? obj) => Equals((Damage?)obj);
    public override int GetHashCode() => _damage;
}