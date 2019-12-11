using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Canva_Manager : MonoBehaviour
{
    [SerializeField] GameObject Ship;
    [SerializeField] GameObject Spawners;

    public Text textToPlayer;
    public Text counter;
    public Text spaceshipHealthText;
    public Text asteroidsDestroyedCounter;
    public Text restartShow;
    public float time;
    private bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        textToPlayer.text = "";
        counter.text = "";
        time = 0f;
        spaceshipHealthText.text = "";
        asteroidsDestroyedCounter.text = "";
        restartShow.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            time += Time.deltaTime;
        }
    }

    public void WinMessage()
    {
        textToPlayer.text = "You passed the asteroid field!";
        Ship.GetComponent<Player_Controller>().enabled = false;
        Spawners.SetActive(false);
        isDead = true;
        restartShow.text = "(Press [R] to restart)";
    }

    public void LoseMessage()
    {
        textToPlayer.text = $"Your ship has been destroyed!";
        Ship.GetComponent<Player_Controller>().enabled = false;
        Spawners.SetActive(false);
        isDead = true;
        restartShow.text = "(Press [R] to restart)";
    }

    public void showCounter()
    {
        counter.text = "Survival Time: " + time;
    }

    public void showHealth()
    {
        if (Player_Interaction.spaceshipHealth >= 0)
        {
            spaceshipHealthText.text = "Spaceship Health: " + Player_Interaction.spaceshipHealth;
        }
    }

    public void showAsteroidsDestroyed()
    {
        asteroidsDestroyedCounter.text = "Asteroids Destroyed: " + Player_Interaction.asteroidDeadCount;
    }
}
