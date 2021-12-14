using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    //Aşamaları enum olarak yazıyoruz. Hangi aşamada hangi tepkiyi alacağımızı belirliyeceğiz ilerde
    public enum SpawnState { SPAWNING, WAITING, COUNTING};

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float rate;
    }

    public Wave[] waves;
    //Belirlediğim noktalardan oluşturmak istiyorum.
    public Transform[] spawnPoints;
    public float timeBetweenWaves = 5f;

    private float _waveCountdown;
    private float _searchCountdown;

    private int _nextWave = 0;

    public SpawnState state = SpawnState.COUNTING;


    void Start()
    {
        if (spawnPoints.Length == 0)
        {
            Debug.LogError("No Spawn Points Referenced");
        }

        _waveCountdown = timeBetweenWaves;
    }

    void Update()
    {
        if (state == SpawnState.WAITING)
        {
            //Followers tagina sahip bir obje kalmadıysa sahnede dalgamız tamamlanmış ve bir sonraki state'e hazırız.
            if (!is_Follower_Alive())
            {
                //Tamamlanmıştır.
                WaveCompleted();
                return;
            }

            else
            {
                return;
            }
        }

        if (_waveCountdown <= 0)
        {
            if (state != SpawnState.SPAWNING)
            {
                //Spawn başlıyor.
                StartCoroutine(SpawnWave(waves[_nextWave]));
            }
            
        }
        else
        {
            _waveCountdown -= Time.deltaTime;
        }
    }

    void WaveCompleted()
    {
        //Debug.Log("Wave IS COMPLETED");
        state = SpawnState.COUNTING;
        _waveCountdown = timeBetweenWaves;

        //Sonuncu arrayimdeki son aşamaya eşitse tekrar başa dönüyoruz
        if (_nextWave + 1 > waves.Length - 1)
        {
            _nextWave = 0;
            //Debug.Log("All waves complete LOOPING");
        }

        else
        {
            _nextWave++;
        }
    }

    bool is_Follower_Alive()
    {
        _searchCountdown -= Time.deltaTime;
        if (_searchCountdown <= 0f)
        {
            _searchCountdown = 1f;
            if (GameObject.FindGameObjectsWithTag("follower").Length == 0)
            {
                return false;
            }
        }

        return true;
    }

    void SpawnEnemy(Transform _enemy)
    {
        //Debug.Log("SPAWNING ENEMY : " + _enemy.name);

        if (spawnPoints.Length == 0)
        {
            Debug.Log("No spawn points referenced");
        }

        Transform _spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(_enemy, _spawnPoint.position, _spawnPoint.rotation);
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        //Debug.Log("SPAWNING WAVE : " + _wave.name);
        state = SpawnState.SPAWNING;

        for(int i=0; i<_wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f * _wave.rate);
        }

        state = SpawnState.WAITING;
        yield break;
    }
}
