using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Shoot", 2.0f, 5.0f);
    }


    void Shoot()
    {            
        StartCoroutine(FireBullets());         
    }


    private float distanceAway = 5.0F;
    private float forceToThrow = 200.0F;
    private IEnumerator FireBullets()
    {
        

        yield return FireBulletFxn(new Vector3(0.0F, -distanceAway, 0), new Vector2(-forceToThrow, -forceToThrow));
        yield return FireBulletFxn(new Vector3(-distanceAway, -distanceAway, 0), new Vector2(-forceToThrow, -forceToThrow));
        yield return FireBulletFxn(new Vector3(-distanceAway, 0.0F, 0), new Vector2(-forceToThrow, -forceToThrow));


        yield return new WaitForSeconds(1.0F);
    }


    private IEnumerator FireBulletFxn(Vector3 offset, Vector2 force)
    {

        GameObject bullet = ObjectPool.SharedInstance.GetPooledObject("Bullet");
        if (bullet != null)
        {
            bullet.SetActive(true);
            bullet.GetComponent<BulletScript>().running = false;

            bullet.transform.position = gameObject.transform.position + offset;
            yield return new WaitForSeconds(0.1F);
            bullet.GetComponent<Rigidbody2D>().AddForce(force);
            yield return new WaitForSeconds(0.5F);

        }

    
    }


}
