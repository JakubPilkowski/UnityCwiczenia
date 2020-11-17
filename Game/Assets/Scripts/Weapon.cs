using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Update is called once per frame
    public Transform firePoint;
    public GameObject bulletPrefab;
    public Character weaponOwner;
    float yRotation = 0;
    void Start()
    {
        if (weaponOwner.GetType() == typeof(Enemy))
        {
            Debug.Log("enemy zaczyna strzelać");
            StartCoroutine(ShootAllTheTime());
        }
    } 

    void Update()
    {
        /*
        if(weaponOwner.GetType() == typeof(Player))
        {
            float x = Input.GetAxis("Mouse X")* 400 * Time.deltaTime;
            float y = Input.GetAxis("Mouse Y") * 400 * Time.deltaTime;
            
            //Debug.Log(x);
            //Debug.Log(y);
            //transform.rota
            yRotation += (y-x);

            yRotation = Mathf.Clamp(yRotation, 0, 180f);
            Debug.Log("Rotacja" +yRotation);
            firePoint.localRotation = Quaternion.Euler(0f, 0f, yRotation);
            
        }
        */

        if (Input.GetButtonDown("Fire1") && weaponOwner.GetType() == typeof(Player))
        {
            Shoot();
        }
    }


    IEnumerator ShootAllTheTime()
    {
        while (true) {
            yield return new WaitForSeconds(((Enemy)weaponOwner).shootDelay);
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Bullet>().Owner = weaponOwner;
        StartCoroutine(ShootExistanceTime(bullet));
    }

    IEnumerator ShootExistanceTime(GameObject bullet)
    {
        yield return new WaitForSeconds(7f);
        if (bullet != null)
        {
            Destroy(bullet);
        }
        StopCoroutine(ShootExistanceTime(bullet));
    }
}
