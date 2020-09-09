using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hearts : MonoBehaviour
{
    public Image[] heart;
    public Sprite fullheart;
    public Sprite emptyheart;
    public int health;
    // Start is called before the first frame update
    void Start()
    {
        health = 3;
        for (int i = 0; i < heart.Length; i++)
        {
            heart[i].enabled = false;     //na zaciatku tam srdcia nie su
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = heart.Length - 1; i > health - 1; i--)
        {
            heart[i].GetComponent<Image>().sprite = emptyheart;
        }
    }
}
