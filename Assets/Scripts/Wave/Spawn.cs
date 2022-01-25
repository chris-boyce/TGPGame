using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Wave[] waves;
    public EnemyHealth Enemy;
    public Transform[] spawnPostion;
    private Vector3 spawnArea;
    private int spawnLocationNumber;
    private int waveMultiplier = 3;

    Wave currentWave;
    int currentWaveNumber;

    private int enemyLeftToSpawn;
    private int enemyLeftAlive;
    private float nextSpawnTime;

    [System.Serializable]
    public class Wave //Wave Class
    {
        public int enemyCount;
        public float timeBetweenSpawn;

    }

    private void Start()
    {
        NextWave(); //Starts First Wave
    }
    private void Update()
    {
        if(enemyLeftToSpawn > 0 && Time.time > nextSpawnTime) //Sets Time Between Spawning Each Enemy
        {
            nextSpawnTime = Time.time + currentWave.timeBetweenSpawn;
            enemyLeftToSpawn--; //Counts the Enemys
            spawnLocationNumber = Random.Range(0,spawnPostion.Length); //Selects which spawner to spawn the zombie at
            spawnArea = new Vector3(spawnPostion[spawnLocationNumber].position.x + Random.Range(-5f, 5f), spawnPostion[spawnLocationNumber].position.y+ 0, spawnPostion[spawnLocationNumber].position.z +  Random.Range(-5f, 5f)); //Set Location of the spawn of the zombie relative to the spawn Transform

            EnemyHealth spawnedEnemy = Instantiate(Enemy, spawnArea, Quaternion.identity); // Spawns Zombie
            spawnedEnemy.OnDeath += OnEnemyDeath; //Event system for when the zombie dies
        }

    }
    void OnEnemyDeath()
    {
        enemyLeftAlive--; //When Zombie Dies
        if(enemyLeftAlive == 0) //If no zombie alive
        {
            StartCoroutine(BetweenWaveTimer()); // Timer to start the Next Wave
        }
    }

    private void NextWave()
    {
        currentWaveNumber++;
        waves[currentWaveNumber - 1].enemyCount = currentWaveNumber * waveMultiplier;
        waves[currentWaveNumber -1 ].timeBetweenSpawn = 5 / currentWaveNumber;
            
        

        currentWave = waves[currentWaveNumber - 1]; //Set Wave number
        enemyLeftToSpawn = currentWave.enemyCount; //Set amount of spawn
        enemyLeftAlive = enemyLeftToSpawn; 
    }


    IEnumerator BetweenWaveTimer() //Waits 10 Seconds to start next wave
    {
        yield return new WaitForSeconds(10);
        NextWave();
    }
}
