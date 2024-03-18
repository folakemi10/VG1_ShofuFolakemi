using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class GameController : MonoBehaviour
    {
        public static GameController instance;

        //outlets
        public Transform[] spawnPoints;
        public GameObject[] asteroidPrefabs;
        public GameObject explosionPrefab;

        public float maxAsteroidDelay = 2f;
        public float minAsteroidDelay = 0.2f;


        public float timeElapsed;
        public float asteroidDelay;
        void Awake()
        {
            instance = this;
        }
        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine("AsteroidSpawnTimer");
        }

        // Update is called once per frame
        void Update()
        {
          timeElapsed += Time.deltaTime;

          float decreaseDelayOverTime = maxAsteroidDelay - ((maxAsteroidDelay-minAsteroidDelay)/30f *timeElapsed);
          asteroidDelay = Mathf.Clamp(decreaseDelayOverTime, minAsteroidDelay, maxAsteroidDelay);
        }

        void SpawnAsteroid() {
           int randomSpawnIndex = Random.Range(0, spawnPoints.Length);
           Transform randomSpawnPoint = spawnPoints[randomSpawnIndex];
           int randomASteroidIndex = Random.Range(0, asteroidPrefabs.Length);
           GameObject randomAsteroidPrefab = asteroidPrefabs[randomSpawnIndex];


          //spawn
          Instantiate(randomAsteroidPrefab, randomSpawnPoint.position, Quaternion.identity);

        }

        IEnumerator AsteroidSpawnTimer()
        {
            yield return new WaitForSeconds(asteroidDelay);

            SpawnAsteroid();

            StartCoroutine("AsteroidSpawnTimer");
        }
    }

}
