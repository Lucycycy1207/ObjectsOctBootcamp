using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class MachineGun : Enemy
{
    [SerializeField] private float attackRange;
    [SerializeField] private float shootingRate = 0.02f;

    [SerializeField] private float weaponDamage = 1;
    [SerializeField] private float bulletSpeed = 10.0f;
    [SerializeField] private Bullet bulletPrefab;
    //[SerializeField] public float shootingTime;
    //[SerializeField]  public float shootingCoolDown;


    private float timer = 0;

    protected override void Start()
    {
        base.Start();
        health = new Health(1, 1, 0);
        weapon = new Weapon("MachineGun Weapon", weaponDamage, bulletSpeed);
    }

    protected override void Update()
    {
        

        if (target == null)
        {
            return;
        }
        Move(target.position);

        if (Vector2.Distance(transform.position, target.position) < attackRange)
        {
            Attack(shootingRate);

        }
    }

    public override void Move(Vector2 direction)
    {
        direction.x -= transform.position.x;
        direction.y -= transform.position.y;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        if (Vector2.Distance(transform.position, target.position) > attackRange)
        {
            transform.Translate(Vector2.right * 1 * Time.deltaTime);
        }
        
    }


    public override void Attack(float interval)
    {
        base.Attack(interval);
     
        if (timer <= interval)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0;
            Shoot();
            //target.GetComponent<IDamageable>().GetDamage(2);
        }

    }
    public override void Shoot()//Vector3 direction, float speed
    {
        weapon.Shoot(bulletPrefab, this, "Player");
    }

    public override void GetDamage(float damage)
    {
        base.GetDamage(damage);
    }

    public void SetMachineGun(float _attackRange, float _shootingRate)
    {
        this.attackRange = _attackRange;
        this.shootingRate = _shootingRate;
    }

}
