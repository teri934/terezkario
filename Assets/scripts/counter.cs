using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class counter : MonoBehaviour
{
    // Start is called before the first frame update
    public Text coins_counter;
    public Text kills_counter;
    private princessmovement princess;
    void Start()
    {
        princess = FindObjectOfType<princessmovement>();
    }

    // Update is called once per frame
    void Update()
    {
        coins_counter.text = ("" + princess.coins);
        kills_counter.text = ("" + princess.kills);
    }
}
