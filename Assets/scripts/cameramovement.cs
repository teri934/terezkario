using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramovement : MonoBehaviour
{
    public GameObject princess;
    private Vector3 last;
    public GameObject wall;
    // Start is called before the first frame update
    void Start()
    {
        //last = princess.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float difference = Mathf.Abs(wall.transform.position.x - princess.transform.position.x);
        if (difference >= 12)
        {
            transform.position = new Vector3(princess.transform.position.x, transform.position.y, -10);
        }
        else
        {
            //transform.Translate(new Vector3(princess.transform.position.x - last.x, 0));
            //last = princess.transform.position;
        }

    }
}
