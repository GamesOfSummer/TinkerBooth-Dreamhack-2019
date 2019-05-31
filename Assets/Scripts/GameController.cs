using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public KnightScript knight;
    public DinoScript dino;

    private void Awake()
    {
        if (instance)
        {
            Debug.Log("Destroying irrelevant GameController instance");
            Destroy(this);
        }

        instance = this;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void changeKnightSpeed(InputField input)
    {
        Debug.Log("aaaaa -" + input.text);
    }
}
