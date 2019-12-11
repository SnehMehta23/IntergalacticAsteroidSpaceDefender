using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Interaction : MonoBehaviour
{
    [SerializeField] float yRestriction = 31f;
    Canva_Manager cm;
    SpawnAsteroids sa;
    public static int spaceshipHealth = 100;
    public static int asteroidDeadCount;
    [SerializeField] int AsteroidKilledGoal;
    [SerializeField] float TimeGoal;

    // Start is called before the first frame update
    void Start()
    {
        cm = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canva_Manager>();
        sa = GameObject.FindGameObjectWithTag("Spawner").GetComponent<SpawnAsteroids>();
    }

    // Update is called once per frame
    void Update()
    {
        cm.showCounter();
        cm.showHealth();
        cm.showAsteroidsDestroyed();

        if (cm.time > TimeGoal && asteroidDeadCount > AsteroidKilledGoal)
        {
            cm.WinMessage();
        }

        if (spaceshipHealth <= 0)
        {
            cm.LoseMessage();
        }

        if (transform.position.y > yRestriction)
        {
            Vector3 v = new Vector3(transform.position.x, yRestriction, 0f);
            transform.position = v;
        }
        else if (transform.position.y < -yRestriction)
        {
            Vector3 v = new Vector3(transform.position.x, -yRestriction, 0f);
            transform.position = v;
        }

        //dont think this is the right place... only place I could implement and have it working
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene("IntergalacticAsteroidDefender");
            spaceshipHealth = 100;
            asteroidDeadCount = 0;
        }

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            spaceshipHealth = spaceshipHealth - collision.GetComponent<Enemy>().dealDamage;
            Destroy(collision.gameObject);
        }
    }
}
