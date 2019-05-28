using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(FireBullets());
    }



    private IEnumerator FireBullets()
    {
        yield return new WaitForSeconds(1.0F);
        this.gameObject.SetActive(false);
    }

}


