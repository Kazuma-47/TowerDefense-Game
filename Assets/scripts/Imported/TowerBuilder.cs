using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private GameObject buildUI;
    [SerializeField] private LayerMask layer;
    public GameObject DT;
    public GameObject BAC;
    public GameObject EMP;
    private Tile selectedTile= null;
    public ScrapError error;



    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && selectedTile== null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, Mathf.Infinity, layer))
            {
                Tile tile = hit.transform.GetComponent<Tile>();
                if (!tile.hastower && tile.GetIsBuildable() == true) 
                {
                    selectedTile = tile;
                    buildUI.SetActive(true);

                    print("selected");
                }
                else
                {
                    //how upgrade menu
                }

            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && selectedTile != null)
        {
            selectedTile = null;
            buildUI.SetActive(false);
            Cursor.lockState = CursorLockMode.Confined;

            ScrapError se = gameObject.GetComponent<ScrapError>();
            se.Timer = 0;
        }
    }
    
    public void BuildButtonDT()
    {
        if(PlayerPrefs.GetFloat("Money") >= 50f)
        {
            PlayerPrefs.SetFloat("Money", PlayerPrefs.GetFloat("Money") -50f);
            BuildTower(DT);
        }
        else
        {
            ScrapError se = gameObject.GetComponent<ScrapError>();
            se.Timer = 3;
        }
       
    }
    public void BuildButtonBAC()
    {
        if (PlayerPrefs.GetFloat("Money") >= 100f)
        {
            PlayerPrefs.SetFloat("Money", PlayerPrefs.GetFloat("Money") - 100f);
            BuildTower(BAC);
        }
        else
        {
            ScrapError se = gameObject.GetComponent<ScrapError>();
            se.Timer = 3;
        }
    }
    public void BuildButtonEMP()
    {
        if (PlayerPrefs.GetFloat("Money") >= 50f)
        {
            PlayerPrefs.SetFloat("Money", PlayerPrefs.GetFloat("Money") - 50f);
            BuildTower(EMP);
        }
        else
        {
            ScrapError se = gameObject.GetComponent<ScrapError>();
            se.Timer = 3;
        }
    }

    public void BuildTower(GameObject tower)
    {
        if (selectedTile.hastower)
        {
            print("already has a turret");
            return;
        }
        Vector3 spawn= new Vector3(selectedTile.transform.position.x, selectedTile.transform.position.y +0.6f, selectedTile.transform.position.z);
        Instantiate(tower, spawn, Quaternion.identity, transform);
        selectedTile.hastower = true;

       

    }
}
