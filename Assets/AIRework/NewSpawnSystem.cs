using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSpawnSystem : MonoBehaviour
{
    //Classes Made
    public Waves[] Wave;
    public Waves CurrentWave;

    //EnemyGO
    public GameObject BaseEnemy;
    public GameObject FastEnemy;
    public GameObject SlowEnemy;

    //Location Spawned
    public Transform[] SpawnPoints;
    private Vector3 SpawnArea;

    //Difficuly Multipler
    public  int WaveMultipler;

    //Current Wave Stats
    public int ZombiesCounter;
    public int ZombiesLeftAlive;
    public int CurrentWaveNumber;
    private float NextSpawnTime;
    public float SpeedOfSpawn = 5;
    
    //End Of Wave
    public float TimeBetweenWaves;
    private bool CanSpawn;
    public float SpawnTimer;

    [System.Serializable]
    public class Waves
    {
        public int LevelScore;
    }

    private void Start()
    {
        NextWave();
    }
    void NextWave()
    {
        CurrentWaveNumber++; //Sets Wave Number
        Wave[CurrentWaveNumber - 1].LevelScore = CurrentWaveNumber * WaveMultipler; //Makes The Level Score that can be spent on spawn
        SpeedOfSpawn = SpeedOfSpawn / 2; //Speed of Spawn is half every round to make them spawn in Quickly
        SpawnTimer = SpeedOfSpawn;
        CurrentWave = Wave[CurrentWaveNumber - 1];
        CanSpawn = true;
    }
    private void Update()
    {
        if(CanSpawn == true) //Starts Time if spawning is allowed
        {
            SpawnTimer -= Time.deltaTime;
            if (CurrentWave.LevelScore > 0 && SpawnTimer <= 0)  //If Current Level still has score to spend and has looped Timer
            {
                int spawnLocationNumber = Random.Range(0, SpawnPoints.Length);
                SpawnArea = new Vector3(SpawnPoints[spawnLocationNumber].position.x + Random.Range(-5f, 5f), SpawnPoints[spawnLocationNumber].position.y + 0, SpawnPoints[spawnLocationNumber].position.z + Random.Range(-5f, 5f));

                GameObject SpawnedEnemy = Instantiate(SpawnZombieSelector(), SpawnArea, Quaternion.identity); //Signs the spawnedobject to the OnEnemyDeath Function
                SpawnedEnemy.GetComponentInChildren<Health>().OnDeath += WhenEnemyDie;
                CurrentWave.LevelScore--;
                ZombiesCounter++;
                SpawnTimer = SpeedOfSpawn;
            }
            else if(CurrentWave.LevelScore <= 0) //Turns Timer off if no spawns left
            {
                CanSpawn = false;
            }
        }
    }
    void WhenEnemyDie() //On the death of an enemy it takes away from the total, when all dead starts the next wave
    {
        ZombiesCounter--;
        if(ZombiesCounter == 0)
        {
            StartCoroutine(NextWaveWait());
            Debug.Log("End Of Round");
        }
    }
    IEnumerator NextWaveWait() //Added 5 Wave Break System TODO UI For Drops
    {
        if (CurrentWaveNumber % 5 == 0)
        {
            TimeBetweenWaves = 30f;
        }
        else
        {
            TimeBetweenWaves = 10f;
        }
        yield return new WaitForSeconds(TimeBetweenWaves);
        NextWave();
    }

    GameObject SpawnZombieSelector() //(x >= 1 && x <= 100) //Works out the odds of which spawns
    {
        float SpawnValue = Random.value;
        if (SpawnValue < 0.5)
        {
            return BaseEnemy;
        }
        else if(SpawnValue >= 0.5 && SpawnValue <= 0.7)
        {
            return FastEnemy;
        }
        else if(SpawnValue > 0.7 && SpawnValue <= 1)
        {
            return SlowEnemy;
        }
        else
        {
            return BaseEnemy;
        }
    }



}
