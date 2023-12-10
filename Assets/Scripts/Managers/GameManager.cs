using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Singleton Implementation

    private static GameManager instance;

    [Header("Game Entities")]
    [SerializeField] private Transform[] spawnPositions;
    [SerializeField] private GameObject[] enemyPrefab;

    [Header("Game Variables")]
    [SerializeField] private float enemySpawnRate;

    [Header("Managers")]
    public ScoreManager scoreManager;
    public UIManager UIManager;

    private GameObject tempEnemy;
    
    private bool isEnemySpawning;

    private Weapon meleeWeapon = new Weapon("Melee", 1, 0);
    private Weapon ShooterWeapon = new Weapon("Shooter", 40, 10);
    private Weapon MachineGunWeapon = new Weapon("MachineGun", 2, 3);

    [SerializeField]
    private Player player;

    
    public float GetPlayerHealth()
    {
        return player.GetHealth();
    }

    public static GameManager GetInstance()
    {
        return instance;
    }
   

    private void SetSingleton()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }

        instance = this;
    }

    private void Awake()
    {
        SetSingleton();
    }

    // Start is called before the first frame update
    void Start()
    {
        isEnemySpawning = true;
        StartCoroutine(EnemySpawner());
    }

    // Update is called once per frame
    void Update()
    {
        GetEnemySpawn();
    }

    private void CreateEnemy()
    {
        int tempEnemyType = Random.Range(0, enemyPrefab.Length);
        tempEnemy = Instantiate(enemyPrefab[tempEnemyType]);
        tempEnemy.transform.position = spawnPositions[Random.Range(0, spawnPositions.Length)].position;
        Debug.Log("tempEnemyType: " + tempEnemyType);

        //

        //set enemy to meleeEnemy
        if (tempEnemyType == 0)
        {
            tempEnemy.GetComponent<MeleeEnemy>().SetMeleeEnemy(2, 0.2f);
            tempEnemy.GetComponent<MeleeEnemy>().weapon = meleeWeapon;
        }
        else if (tempEnemyType == 1)
        {
            tempEnemy.GetComponent<Exploder>().SetExploder(1f, 40f);
        }
        else if (tempEnemyType == 2)
        {
            tempEnemy.GetComponent<Shooter>().SetShooter(10f, 1f);
            tempEnemy.GetComponent<Shooter>().weapon = ShooterWeapon;
        }
        else if (tempEnemyType == 3)
        {
            tempEnemy.GetComponent<MachineGun>().SetMachineGun(6f, 0.5f);
            tempEnemy.GetComponent<MachineGun>().weapon = MachineGunWeapon;
        }
    }

    /// <summary>
    /// Press X to spawn new enemy.
    /// </summary>
    private void GetEnemySpawn()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            CreateEnemy();
        }
    }

    IEnumerator EnemySpawner()
    {
        while (isEnemySpawning)
        {
            yield return new WaitForSeconds(1.0f / enemySpawnRate);
            if (player != null)
                CreateEnemy();
        }
        
    }
}
