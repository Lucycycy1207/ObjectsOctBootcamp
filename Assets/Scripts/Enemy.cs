using UnityEngine;

public class Enemy: PlayableObject
{
    private string enemyName;
    [SerializeField] private float speed;
    private EnemyType enemyType;

    /// <summary>
    /// The transform of the object that enemy will attack to.
    /// </summary>
    protected Transform target;

    protected virtual void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        Debug.Log("target: " + target.position);
        //Debug.Log(Utilities.DEVICE_ID);
        //Utilities.ShowDeviceID("RICO");
        //Debug.Log(Utilities.DEVICE_ID);
        //Move(transform);
        //Shoot(Vector3.zero, 2.0f);
        //Die();
        //Attack(2.0f);
    }

    protected virtual void Update()
    {
        if (target != null)
        {
            Move(target.position);
        }
        else
        {
            Move(speed);
        }
    }

    public override void Shoot()
    {
        Debug.Log($"Shooting a bullet towards");
        //Debug.Log($"Shooting a bullet towards {direction} with a speed of {speed}");
    }

    public override void Die()
    {
        Debug.Log("Enemy Died");
        Destroy(gameObject);
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

    /// <summary>
    /// Currently move to right only.
    /// </summary>
    /// <param name="speed">Moving speed</param>
    public override void Move(float speed) // only move to right?
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    /// <summary>
    /// Rotate Enemy and move to right.
    /// </summary>
    /// <param name="direction">Enemy Moving direction.</param>
    public override void Move(Vector2 direction)
    {
        direction.x -= transform.position.x;
        direction.y -= transform.position.y;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    
    //public override void GetDamage(float damage)
    //{
    //}
}
