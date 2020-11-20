using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject player;
    public Character weaponOwner;
    private Vector2 lookdirection;
    private float lookAngle;

    void Start()
    {
        if (weaponOwner.GetType() == typeof(Enemy) || weaponOwner.GetType() == typeof(WallTrap))
        {
            StartCoroutine(ShootAllTheTime());
        }
    } 

    void Update()
    {

        if (weaponOwner.GetType() == typeof(Enemy) && player != null)
        {
            lookdirection = new Vector2(player.transform.position.x - firePoint.transform.position.x,
            player.transform.position.y - firePoint.transform.position.y);
            lookAngle = Mathf.Atan2(lookdirection.y, lookdirection.x) * Mathf.Rad2Deg;
            firePoint.transform.rotation = Quaternion.Euler(0f, 0f, lookAngle);
        }


        if (weaponOwner.GetType() == typeof(Player))
        {
            lookdirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - firePoint.transform.position;
            lookAngle = Mathf.Atan2(lookdirection.y, lookdirection.x) * Mathf.Rad2Deg;
            firePoint.transform.rotation = Quaternion.Euler(0f, 0f, lookAngle);
            
        }
        

        if (Input.GetButtonDown("Fire1") && weaponOwner.GetType() == typeof(Player))
        {
            Shoot();
        }
    }


    IEnumerator ShootAllTheTime()
    {
        while (true) {
            if (weaponOwner.GetType() == typeof(Enemy))
            {
                yield return new WaitForSeconds(((Enemy)weaponOwner).shootDelay);
            }
            else
            {
                yield return new WaitForSeconds(((WallTrap)weaponOwner).shootDelay);
            }
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
