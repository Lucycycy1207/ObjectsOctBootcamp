using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploder : Enemy
{
    private float explodeRadius;


    public void Explode(float radius)
    {
        Debug.Log($"explode with radius {radius}");
    }

}
