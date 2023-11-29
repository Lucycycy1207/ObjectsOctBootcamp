using UnityEngine;

public class Player: PlayableObject
{
    private string nickName;
    [SerializeField] private Camera cam;
    [SerializeField] private float speed;

    private Rigidbody2D playerRB;

    public override void Shoot()//Vector3 direction, float speed
    {
        Debug.Log("Player is shooting a bullet");
        //Debug.Log($"Shooting a bullet towards {direction} with a speed of {speed}");
    }

    public override void Die()
    {
        Debug.Log("Player Died");
    }

    private void Start()
    {
        health = new Health(100f, 100f, 0.5f);
        playerRB = GetComponent<Rigidbody2D>();

    }
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
    }


}
