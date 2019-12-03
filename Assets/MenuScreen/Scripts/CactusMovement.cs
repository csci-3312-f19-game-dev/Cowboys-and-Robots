using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusMovement : MonoBehaviour
{
    private GameObject[] cactusOne;
    private GameObject[] cactusTwo;
    private GameObject[] mountains;
    // Start is called before the first frame update
    void Start()
    {
        cactusOne = GameObject.FindGameObjectsWithTag("cactus");
        cactusTwo = GameObject.FindGameObjectsWithTag("cactus2");
        mountains = GameObject.FindGameObjectsWithTag("mountains");
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject i in cactusOne)
        {
            var tmp = i.transform.position;
            i.transform.position = new Vector3((float)(tmp.x - 0.003), tmp.y, tmp.z);
        }
        foreach (GameObject i in cactusTwo)
        {
            var tmp2 = i.transform.position;
            i.transform.position = new Vector3((float)(tmp2.x - 0.001), tmp2.y, tmp2.z);
        }
        foreach (GameObject i in mountains)
        {
            var tmp3 = i.transform.position;
            i.transform.position = new Vector3((float)(tmp3.x - 0.0007), tmp3.y, tmp3.z);
        }
    }

}
