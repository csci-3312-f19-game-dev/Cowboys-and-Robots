using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TowerDragHandler : MonoBehaviour
{

    public GameObject tower;
    //public Image img;
    public static bool holdingTower;
    public void Start()
    {
        Button towerButton = gameObject.GetComponent<Button>();
        holdingTower = false;
        //img.enabled = false;
        towerButton.onClick.AddListener(GrabTower);
    }

    public void Update()
    {
        //img.transform.position = Input.mousePosition;

        if(holdingTower)
        {
            //onGUI();
            if(Input.GetMouseButtonDown(0))
            {
                Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousepos = new Vector3(mousepos.x, mousepos.y, 1);
                Instantiate(tower, mousepos/*Camera.main.ScreenToWorldPoint(Input.mousePosition)*/, Quaternion.identity);             
                holdingTower = false;
                Debug.Log("placing tower");
                
            }
        }
    }

    private void GrabTower()
    {
        if (!holdingTower)
        {
            holdingTower = true;
        }
        
    }

    void onGUI()
    {
        GUI.skin.settings.cursorColor = Color.green;
    }

}
