using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tips : MonoBehaviour
{
    public string tip;
    public Text tipDisplay;

    void OnTriggerEnter(Collider collider)
    {
        if(collider.CompareTag("Player"))
        {
            tipDisplay.text = tip;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if(collider.CompareTag("Player"))
        {
            tipDisplay.text = " ";
             Destroy(this.gameObject);
        }
    }
}
