using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public int damage = 50;
    public int bulletDirection;
    
    // Start is called before the first frame update
    void Start()
    {
        BulletDirectionMethod();
    }

    void Update()
    {
        Debug.Log(bulletDirection);
        BulletDirectionMethod();
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null && hitInfo.CompareTag("Asteroid"))
        {
            enemy.Die();
            Destroy(this.gameObject);
            Player_Interaction.asteroidDeadCount++;
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

    /// <summary>
    /// Credit to Angelo DeMello
    /// </summary>
    public void BulletDirectionMethod()
    {
        rb.velocity = transform.right * speed * bulletDirection;
    }
}
