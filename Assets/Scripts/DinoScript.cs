using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Shoot", 2.0f, 10.0f);
    }

    // Update is called once per frame
    void Update()
    {


    }



    void Shoot()
    {
            
        StartCoroutine(FireBullets());
              
    }




    private float distanceAway = 0.6F;
    private float forceToThrow = 40.0F;
    private IEnumerator FireBullets()
    {

        yield return new WaitForSeconds(0.35F); //this is exact

        yield return FireBulletFxn(new Vector3(distanceAway, 0.0F, 0), new Vector2(forceToThrow, 0));
        yield return FireBulletFxn(new Vector3(distanceAway, -distanceAway, 0), new Vector2(forceToThrow, -forceToThrow));
        yield return FireBulletFxn(new Vector3(0.0F, -distanceAway, 0), new Vector2(0, -forceToThrow));
        yield return FireBulletFxn(new Vector3(-distanceAway, -distanceAway, 0), new Vector2(-forceToThrow, -forceToThrow));
        yield return FireBulletFxn(new Vector3(-distanceAway, 0.0F, 0), new Vector2(-forceToThrow, 0));


        yield return new WaitForSeconds(1.0F);

    }


    private IEnumerator FireBulletFxn(Vector3 offset, Vector2 force)
    {

        GameObject bullet = ObjectPool.SharedInstance.GetPooledObject("Bullet");
        if (bullet != null)
        {
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
            bullet.SetActive(true);

            //bulletObject.transform.position = gameObject.transform.position + offset;
            yield return new WaitForSeconds(0.25F);
            bullet.GetComponent<Rigidbody2D>().AddForce(force);
            yield return new WaitForSeconds(0.1F);

        }

    
    }


}
