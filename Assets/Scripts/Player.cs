using UnityEngine;
using UnityEngine.Events;

public class Player: PlayableObject
{

    private string nickName;
    [SerializeField] private Camera cam;
    [SerializeField] private float speed;

    [SerializeField] private float weaponDamage = 1;
    [SerializeField] private float bulletSpeed = 10.0f;
    [SerializeField] private Bullet bulletPrefab;
    private Health playerHealth = new Health(100f, 100f, 0.5f);

    [SerializeField] private UIManager uiManager;


    private Rigidbody2D playerRB;
    public float GetHealth()
    {
        return playerHealth.GetHealth();
    }

    public override void Shoot()//Vector3 direction, float speed
    {
        weapon.Shoot(bulletPrefab, this, "Enemy");
        Debug.Log("Player is shooting a bullet");
        //Debug.Log($"Shooting a bullet towards {direction} with a speed of {speed}");
    }

    public override void Die()
    {
        Debug.Log("Player Died");
        
        Destroy(gameObject);
    }

    private void Start()
    {
        uiManager.UpdateHealth();
        //health = new Health(100f, 100f, 0.5f);
        playerRB = GetComponent<Rigidbody2D>();

        //Set Player Weapon
        weapon = new Weapon("Player Weapon", weaponDamage, bulletSpeed);

    }

    private void Update()
    {
        
        playerHealth.RegenerateHealth();
        uiManager.UpdateHealth();
    }

    /// <summary>
    /// Control object movement.
    /// </summary>
    /// <param name="direction">Direction of the movement by player input</param>
    /// <param name="target">Current mouse position</param>
    public override void Move(Vector2 direction, Vector2 target)
    {
        //Debug.Log("player direction: " + direction);

        playerRB.velocity = direction * speed * Time.deltaTime;
        var playerScreenPos = cam.WorldToScreenPoint(transform.position);//convert pos of player to screen pos

        target.x -= playerScreenPos.x;
        target.y -= playerScreenPos.y;

        float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg; // radians to degrees

        transform.rotation = Quaternion.Euler(0, 0, angle);//degrees to quaternion

        //TODO: Target and Rotation
    }

    public override void Attack(float interval)
    {
    }

    public override void GetDamage(float damage)
    {
        Debug.Log("Player Damaged: " + damage);

        
        playerHealth.DeductHealth(damage);
        if (playerHealth.GetHealth() <= 0)
        {
            Die();
        }
    }


}
