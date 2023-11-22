using UnityEngine;

public class Weapon
{
    private string weaponName;
    private float damage;

    private WeaponType weaponType = WeaponType.AssaultRifle;
    public Weapon(string _weaponName, float _damage)
    {
        weaponName = _weaponName;
        damage = _damage;
    }

    public Weapon() { }

    public void Shoot() 
    {
        Debug.Log($"Shooting from weapon");
    }

    public enum WeaponType
    {
        None,
        Bazooka,
        Bomb,
        AssaultRifle,
        TripleRocket,
        Shortgun

    }
}
