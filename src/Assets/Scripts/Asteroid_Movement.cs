using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid_Movement : MonoBehaviour
{
    public GameObject OriginSpawner;
    public GameObject Asteroid;
    Vector3 asteroid_location;
    Vector3 rotation;
   
    // Start is called before the first frame update
    void Start()
    {
        asteroid_location = Asteroid.transform.position;
        rotation = new Vector3();
    }

    // Update is called once per frame
    void Update()
    {
        addTrajectory();
        AsteroidRotation();
    }

    void addTrajectory()
    {
        
        if (OriginSpawner.name == "SpawnPoint1")
        {
            asteroid_location.x += -0.5f;
            asteroid_location.z = -1f;
        }

        if (OriginSpawner.name == "SpawnPoint2")
        {
            asteroid_location.x += -0.5f;
            asteroid_location.z = -1f;
        }

        if (OriginSpawner.name == "SpawnPoint3")
        {
            asteroid_location.x += -0.5f;
            asteroid_location.z = -1f;
        }

        if (OriginSpawner.name == "SpawnPoint4")
        {
            asteroid_location.x += -0.5f;
            asteroid_location.z = -1f;
            asteroid_location.y += -0.3f;
        }

        if (OriginSpawner.name == "SpawnPoint5")
        {
            asteroid_location.x += -0.5f;
            asteroid_location.z = -1f;
            asteroid_location.y += 0.3f;
        }

        if (OriginSpawner.name == "SpawnPoint6")
        {
            asteroid_location.x += -0.5f;
            asteroid_location.z = -1f;
            asteroid_location.y += -0.3f;
        }

        if (OriginSpawner.name == "SpawnPoint7")
        {
            asteroid_location.x += -0.5f;
            asteroid_location.z = -1f;
            asteroid_location.y += 0.3f;
        }

        Asteroid.transform.position = asteroid_location; 
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

    /// <summary>
    /// Credit to Jeff Meyers + Angello DeMello
    /// </summary>
    void AsteroidRotation()
    {
        rotation.z = 2f;
        Asteroid.transform.Rotate(new Vector3(0,0, rotation.z), 1f, Space.Self);
    }
}
