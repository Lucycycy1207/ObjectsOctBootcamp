using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploder : Enemy
{
    private float explodeRadius = 1f;
    protected override void Start()
    {
        base.Start();
        health = new Health(1, 1, 0);
    }

    protected override void Update()
    {
        base.Update();
        if (target == null)
        {
            return;
        }
        //Debug.Log("transform.position:" +transform.position);
        //Debug.Log("target.position:" + target.position);
        Debug.Log("explodeRadius:" + explodeRadius);
        if (Vector2.Distance(transform.position, target.position) <= explodeRadius)
        {
            Explode(explodeRadius);
        }
    }

    public void Explode(float radius)
    {
        Debug.Log($"explode with radius {radius}");
        
        target.GetComponent<IDamageable>().GetDamage(40f);
        Destroy(gameObject);
    }
    public override void GetDamage(float damage)
    {
        base.GetDamage(damage);
    }





}
