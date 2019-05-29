using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightScript : MonoBehaviour
{
    public float speed = 10;

    private Animator animator;

    private Vector3 startingLocation;

    void Start()
    {
        animator = GetComponent<Animator>();
        startingLocation = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        transform.position += move * speed * Time.deltaTime;

        if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            animator.SetBool("Running", true);
        }
        else
        {
            animator.SetBool("Running", false);
        }
    }




    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
        {
            Reset();
        }
        
    }



    public void Reset()
    {
        transform.position = startingLocation;
    }

    public void ChangeSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
}
