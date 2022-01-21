using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    private bool InRange;

    public GameObject Interact_msg;
    public GameObject Button_red;
    public GameObject Button_Green;
    public void OnTriggerEnter(Collider other)
    {
      if(other.name== "Player")
        {
            Interact_msg.SetActive(true);
            InRange = true;
           
        } 
    }
    private void Update()
    {
        if (Input.GetKeyDown("e")&& InRange == true)
        {
            Monitor[] myItems = FindObjectsOfType(typeof(Monitor)) as Monitor[];
            foreach (Monitor item in myItems)
            {
                item.GetComponent<Monitor>().on = true;
            }
            FindObjectOfType<UpgradeBenchDefault>().enabled = true;
            Button_red.GetComponent<ButtonLamp>().on= false;
            Button_Green.GetComponent<ButtonLamp>().on= true;
            FindObjectOfType<MissionManager>().Mission_2();
            Interact_msg.SetActive(false);
            gameObject.GetComponent<Generator>().enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Interact_msg.SetActive(false);
        InRange = false;
    }
}
