using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NotEnoughGoldText : MonoBehaviour
{
    private float duration = 1.5f, speed = 1.5f, timer = 0;

    public TMP_Text txt;
    // Start is called before the first frame update
    void Start()
    {
       // txt = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        //destroy text after desired duration
        if(timer > duration)
        {
           Destroy(gameObject);
        }

        //move text upwards
        gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + speed);

        //make text fade out
        float ratio = timer / duration;
        Color col = txt.color;
        col.a = Mathf.Lerp(1, 0, ratio);
        txt.color = col;
    }
}
