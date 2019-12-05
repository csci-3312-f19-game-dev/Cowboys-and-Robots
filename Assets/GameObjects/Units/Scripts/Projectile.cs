using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Transform from;
    public Transform to;
    private float ticker;
    // Update is called once per frame

    private void Start()
    {
        ticker = 1f;
    }
    void FixedUpdate()
    {
        if(to == null || from == null)
        {
            Destroy(gameObject);
        }
        //gameObject.transform.position = (1 - ticker) * to.position + ticker * from.position;
        if((ticker -= 4 * Time.fixedDeltaTime) < 0)
        {
            Destroy(gameObject);
        }
    }
}
