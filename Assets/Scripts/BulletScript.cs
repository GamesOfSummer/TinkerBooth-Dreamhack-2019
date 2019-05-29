using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public bool running = false;

    void Update()
    {
        if(running == false)
        {
            running = true;
            StartCoroutine(FireBullets());
        }      
    }



    private IEnumerator FireBullets()
    {
        yield return new WaitForSeconds(1.0F);
        running = true;
        this.gameObject.SetActive(false);
    }

}


