using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthbar : MonoBehaviour
{
    public Transform bar;
    // Start is called before the first frame update
    void Awake()
    {
        bar = transform.Find("bar");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSize(float normalized_size)
    {
        bar.localScale = new Vector3(normalized_size, 1f);
    }

    public void SetColor(Color color)
    {
        bar.Find("barsprite").GetComponent<SpriteRenderer>().color = color;
    }
}
