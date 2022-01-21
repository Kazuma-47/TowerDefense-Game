using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataStorageBox : MonoBehaviour
{
    public GameObject interact_msg;
    private bool InRange;
    public GameObject UI;
    public GameObject PlayerUI;
    public bool tutorial = true;

    public bool active = false;
    public void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            interact_msg.SetActive(true);
            InRange = true;
        }
    }

    private void Update()
    {

        if (Input.GetKeyDown("e") && InRange == true && active == false && tutorial == true)
        {
            UI.SetActive(true);
            interact_msg.SetActive(false);
            PlayerUI.SetActive(false);
            active = true;
            FindObjectOfType<MissionManager>().Mission_4();
            tutorial = false;
        }
        else if (Input.GetKeyDown("e") && InRange == true && active == false && tutorial == false)
        {
            UI.SetActive(true);
            interact_msg.SetActive(false);
            PlayerUI.SetActive(false);
            active = true;
        }
        
        else if(InRange == false)
        {
            interact_msg.SetActive(false);
            UI.SetActive(false);
            PlayerUI.SetActive(true);
            InRange = false;
            active = false;
        }
        else if(Input.GetKeyDown("e") && active == true && InRange == true )
        {
            interact_msg.SetActive(true);
            UI.SetActive(false);
            PlayerUI.SetActive(true);
            active = false;

        }

    }

    public void OnTriggerExit(Collider other)
    {
    
            interact_msg.SetActive(false);
            InRange = false;
            active = false;

    }
}
