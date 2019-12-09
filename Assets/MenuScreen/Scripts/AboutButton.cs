using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboutButton : MonoBehaviour
{
    public GameObject aboutPanel;
    private void Start()
    {
        aboutPanel.SetActive(false);
    }
    public void ShowAbout()
    {
        aboutPanel.SetActive(true);
    }

    public void ExitAbout()
    {
        aboutPanel.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
