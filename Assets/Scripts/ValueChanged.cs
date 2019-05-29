using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValueChanged : MonoBehaviour
{

    public void ResetButton()
    {     
        Debug.Log("ResetButton()");


        actuallyChangeKnightSpeed(0.5F);
        ResetKnight();

        actuallyBossAttackSpeed(0.5F);
    }

    public void changeKnightSpeed(InputField input)
    {
        if (input.text.Length > 0)
        {
            Debug.Log("Text has been entered");
        }
        else if (input.text.Length == 0)
        {
            Debug.Log("Main Input Empty");
        }

        Debug.Log("!!! - " + input.text);
        int newSpeed;
        bool res = int.TryParse(input.text, out newSpeed);
        if (res == true)
        {
            var number = int.Parse(input.text);
            actuallyChangeKnightSpeed(number);
        }


    }

    private void actuallyChangeKnightSpeed(float speed)
    {
        var knight = GameObject.Find("Knight");
        knight.GetComponent<KnightScript>().ChangeSpeed(speed);
    }


    private void ResetKnight()
    {
        var knight = GameObject.Find("Knight");
        knight.GetComponent<KnightScript>().Reset();
    }

    public void changeBossAttackSpeed(InputField input)
    {
        if (input.text.Length > 0)
        {
            Debug.Log("Text has been entered");
        }
        else if (input.text.Length == 0)
        {
            Debug.Log("Main Input Empty");
        }

        Debug.Log("!!! - " + input.text);
        int newSpeed;
        bool res = int.TryParse(input.text, out newSpeed);
        if (res == true)
        {
            var number = int.Parse(input.text);
            actuallyBossAttackSpeed(number);
        }


    }


    private void actuallyBossAttackSpeed(float speed)
    {
        var knight = GameObject.Find("Dino");
        knight.GetComponent<DinoScript>().ChangeWaitTime(speed);
    }




}
