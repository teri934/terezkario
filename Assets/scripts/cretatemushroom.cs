using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cretatemushroom : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject mushroom;
    bool counter;
    float size;
    void Start()
    {
        size = GetComponent<SpriteRenderer>().size.x / 0.2f;
        if (transform.position.y > 5)
        {
            CreateMushroom();
        }
    }

    // Update is called once per frame
    void CreateMushroom()
    {
        Instantiate(mushroom, new Vector3(transform.position.x - ((size / 2) * 0.2f * 10) - 3, 1.3f), Quaternion.identity);
    }      //zaciatocna pozicia bloku a vo vzdialenosti 3 od toho sa vytvori muchotravka

    void Update()
    {
        
    }
}
