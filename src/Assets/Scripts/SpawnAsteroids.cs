using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAsteroids : MonoBehaviour
{
    public GameObject Asteroid;

    float time;
    float spawnTime;
    float nextSpawn;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        spawnTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time > nextSpawn)
        {
            nextSpawn = Time.deltaTime + generateRandomTime();
            spawnAsteroid();
            time = 0f;
        }
    }

    void spawnAsteroid()
    {
        Asteroid.GetComponent<Asteroid_Movement>().OriginSpawner = this.gameObject;
        Instantiate(Asteroid, this.gameObject.transform.position, new Quaternion());
    }

    float generateRandomTime()
    {
        spawnTime = Random.Range(3, 7);
        return spawnTime;
    }
}