using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createcoins : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject coin;
    void Start()
    {
        float size1 = GetComponent<SpriteRenderer>().size.x / 0.2f;
        int size2 = (int)size1;
        int counter = -(size2 / 2);
        if (size2 % 2 != 0)
        {
            for (int i = 0; i < size2; i++)
            {
                Instantiate(coin, new Vector3(transform.position.x + 0.2f * 10 * counter, transform.position.y + 1.2f), Quaternion.identity);   // 10 je scale a 0.2 je sirka mince
                counter += 1;
            }
        }
        else
        {
            float first_coin = transform.position.x - ((size2 / 2) * 0.2f * 10) + ((0.2f * 10) / 2); //odpocitam polovicu bloku a pripocitam polovicu jednotkoveho bloku
            for (int i = 0; i < size2; i++)
            {
                Instantiate(coin, new Vector3(first_coin + i * 0.2f * 10,transform.position.y + 1.2f), Quaternion.identity);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
