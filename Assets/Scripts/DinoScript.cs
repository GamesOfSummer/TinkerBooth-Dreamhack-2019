using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoScript : MonoBehaviour
{
    public float waitTime = 0.1F;
    // Start is called before the first frame update

    private Animator animator;
    private bool isDead = false;

    void Start()
    {
        StartCoroutine(FireBullets());
        animator = GetComponent<Animator>();
    }


  


    private float distanceAway = 5.0F;
    private float forceToThrow = 300.0F;
    private IEnumerator FireBullets()
    {        
        while(true)
            {
            yield return FireBulletFxn(new Vector3(-distanceAway, 0, 0), new Vector2(-forceToThrow, 0));
            yield return FireBulletFxn(new Vector3(-distanceAway, 0, 0), new Vector2(-forceToThrow, -forceToThrow));
            yield return FireBulletFxn(new Vector3(-distanceAway, 0, 0), new Vector2(0, -forceToThrow));
            yield return FireBulletFxn(new Vector3(-distanceAway, 0, 0), new Vector2(-forceToThrow, forceToThrow));
            yield return FireBulletFxn(new Vector3(-distanceAway, 0, 0), new Vector2(0, forceToThrow ));




            yield return new WaitForSeconds(waitTime);
        }
       
    }


    private IEnumerator FireBulletFxn(Vector3 offset, Vector2 force)
    {

        GameObject bullet = ObjectPool.SharedInstance.GetPooledObject("Bullet");
        if (bullet != null && isDead == false)
        {
            bullet.SetActive(true);
            bullet.GetComponent<BulletScript>().running = false;

            bullet.transform.position = gameObject.transform.position + offset;
            bullet.GetComponent<Rigidbody2D>().AddForce(force);
            yield return new WaitForSeconds(0.1F);

        }

    
    }



    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("--" + other.name);

        if (other.tag == "Player")
        {
            animator.SetBool("Dead", true);
            isDead = true;
        }

    }


    public void ChangeWaitTime(float newSpeed)
    {
        waitTime = newSpeed;
    }

    public void Reset()
    {
        animator.SetBool("Dead", false);
        isDead = false;
    }


}
