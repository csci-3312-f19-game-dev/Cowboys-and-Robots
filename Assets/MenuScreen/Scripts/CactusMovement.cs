using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusMovement : MonoBehaviour
{
    private GameObject cactusOne;
    private GameObject cactusTwo;
    private GameObject mountains;
    // Start is called before the first frame update
    void Start()
    {
        cactusOne = GameObject.FindWithTag("cactus");
        cactusTwo = GameObject.FindWithTag("cactus2");
        mountains = GameObject.FindWithTag("mountains");
    }

    // Update is called once per frame
    void Update()
    {
        var tmp = cactusOne.transform.position;
        cactusOne.transform.position = new Vector3((float)(tmp.x - 0.005), tmp.y, tmp.z);
        //if (cactusOne.transform.position.x < -150) {
        //    cactusOne.transform.position = new Vector3(0, tmp.y, tmp.z);
        //};
        var tmp2 = cactusTwo.transform.position;
        cactusTwo.transform.position = new Vector3((float)(tmp2.x - 0.003), tmp2.y, tmp2.z);
        var tmp3 = mountains.transform.position;
        mountains.transform.position = new Vector3((float)(tmp3.x - 0.002), tmp3.y, tmp3.z);
    }
}
