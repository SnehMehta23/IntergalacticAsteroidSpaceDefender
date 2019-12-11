using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Controller : MonoBehaviour
{ 
    Bullet b;

    public GameObject Spaceship;
    private SpriteRenderer mySpriteRenderer;

    [SerializeField] float spaceshipSpeed = 10f;

    Vector2 position;
    private void Awake()
    {
        // get a reference to the SpriteRenderer component on this gameObject
        mySpriteRenderer = GameObject.FindGameObjectWithTag("SpaceShipSprite").GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        b = GetComponent<Weapon>().bulletPrefab.GetComponent<Bullet>();
        b.bulletDirection = 1;
        position = Spaceship.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position = transform.position + new Vector3(0, spaceshipSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position = transform.position + new Vector3(0, -spaceshipSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = transform.position + new Vector3(spaceshipSpeed * Time.deltaTime * -2, 0, 0);
            mySpriteRenderer.flipY = true;
            b.bulletDirection = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position = transform.position + new Vector3(spaceshipSpeed * Time.deltaTime, 0, 0);
            mySpriteRenderer.flipY = false;
            b.bulletDirection = 1;
        }
    }
}