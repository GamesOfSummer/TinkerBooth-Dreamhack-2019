using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValueChanged : MonoBehaviour
{

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

            var knight = GameObject.Find("Knight");
            knight.GetComponent<KnightScript>().ChangeSpeed(newSpeed);
        }


    }
}
