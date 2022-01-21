using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeBenchDefault : MonoBehaviour
{
    private bool InRange;
    public GameObject Interact_msg;
    public GameObject Gun;
    public GameObject GunUI;
    public TextMeshProUGUI Text;
    public bool Owned;

    private void Start()
    {
        Owned = false;
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player"&& Owned== false)
        {
            Interact_msg.SetActive(true);
            Text.text = "Press E to buy turret 25 Scraps";
            InRange = true;
        }
        else if(other.name == "Player" && Owned == true)
        {
            Interact_msg.SetActive(true);
            Text.text = "Press E to Upgrade turret";
            InRange = true;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown("e") && InRange == true && Owned == false)
        {
            
            //  ADD A TURRET IF YOU HAVE MONEY
            Text.text = "Press E to Upgrade turret";
            FindObjectOfType<MissionManager>().Mission_3();
            Owned = true;
            Gun.SetActive(true);
            GunUI.SetActive(true);
        }
        else if (Input.GetKeyDown("e") && InRange == true && Owned == true)
        {


            FindObjectOfType<MissionManager>().Mission_3();
            Owned = true;
            Gun.SetActive(true);
            GunUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Interact_msg.SetActive(false);
        InRange = false;
    }

    
}
