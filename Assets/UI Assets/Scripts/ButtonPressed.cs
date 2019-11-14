using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPressed : MonoBehaviour
{

    public GameObject infoPanel;
    // Start is called before the first frame update
    void Start()
    {
        Button button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(ExitTab);
    }

    void ExitTab()
    {
        Debug.Log("Exited");
        Destroy(infoPanel);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
