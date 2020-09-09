using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamehandler : MonoBehaviour
{
    public healthbar health;
    float life;
    // Start is called before the first frame update
    void Start()
    {
        life = 1;
        health.SetSize(life);
        health.SetColor(Color.red);
    }

    public float Life()
    {
        life -= 0.33f;
        if (life < 0.1)   //len nejaka hodnota aby sa po troch kontaktoch nastavila hodnota presne na nulu
        {
            life = 0;
        }
        health.SetSize(life);
        return life;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
