using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : PickUp, IDamageable
{
    public void GetDamage(float damage)
    {
        //Increase Player Health
    }

    public override void OnPicked()
    {
        base.OnPicked();

        //Increase Player Health here!

    }
}
