using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform firePoint;
    public Transform firePoint2;
    public GameObject bulletPrefab;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            Shoot2();
        }
    }

    void Shoot()
    {
        //shooting logic
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        GetComponent<AudioSource>().Play();
    }

    void Shoot2()
    {
        Instantiate(bulletPrefab, firePoint2.position, firePoint2.rotation);
        GetComponent<AudioSource>().Play();
    }
}
