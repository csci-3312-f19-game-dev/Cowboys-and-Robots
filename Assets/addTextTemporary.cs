using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class addTextTemporary : MonoBehaviour
{
    public TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        Button button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(SpawnText);
    }

    void SpawnText()
    {
        TMP_Text clone = Instantiate(text, gameObject.transform) as TMP_Text;
        GameObject parent = GameObject.Find("GameMessages");
        clone.transform.parent = parent.transform;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
