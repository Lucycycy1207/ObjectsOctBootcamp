using UnityEngine;

public class Enemy: PlayableObject
{
    private string enemyName;
    private float speed;
    private EnemyType enemyType;

    private void Start()
    {
        Debug.Log(Utilities.DEVICE_ID);
        Utilities.ShowDeviceID("RICO");
        Debug.Log(Utilities.DEVICE_ID);
        //Move(transform);
        //Shoot(Vector3.zero, 2.0f);
        //Die();
        //Attack(2.0f);
    }
    

    public override void Shoot(Vector3 direction, float speed)
    {
        Debug.Log($"Shooting a bullet towards {direction} with a speed of {speed}");
    }

    public override void Die()
    {
        Debug.Log("Enemy Died");
    }

    public override void Attack(float interval)
    {
        Debug.Log($"Enemy attacking with a {interval} interval");
    }


    public void SetEnemyType(EnemyType _enemyType)
    {
        enemyType = _enemyType;
    }

    public override void Move(Vector2 direction, Vector2 target)
    {
    }

    public override void GetDamage(float damage)
    {
    }
}
