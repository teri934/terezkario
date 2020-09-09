using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createfloor : MonoBehaviour
{
    public GameObject floor;
    public GameObject coin;
    public GameObject gemstone;
    public GameObject enemy;
    private int enemy_number;
    private System.Random rnd = new System.Random();
                                                             //vytvara podlahu plus nejake mince a diamanty a nepriatela
    // Start is called before the first frame update
    void Start()
    {
        enemy_number = rnd.Next(1, 4);
    }

    void CreateFloor()
    {
        GameObject generate = Instantiate(floor, new Vector3(transform.position.x + 45, 0), Quaternion.identity);  //dlzka podlahy je 45
        int number_coins = rnd.Next(0, 5);
        int y_position_coin = rnd.Next(2, 4);
        int x_position_coin = rnd.Next(-6, 3);
        for (int i = 0; i < number_coins; i++)
        {
            Instantiate(coin, new Vector3 (generate.transform.position.x + x_position_coin + i * 0.2f * 4 * 2, generate.transform.position.y + y_position_coin, 2), Quaternion.identity);
        }
        int number_gemstone = rnd.Next(0, 2);
        int y_position_gemstone = rnd.Next(4, 6);
        int x_position_gemstone = rnd.Next(-4, 4);
        if (number_gemstone == 1)
        {
            Instantiate(gemstone, new Vector3(generate.transform.position.x + x_position_gemstone, generate.transform.position.y + y_position_gemstone, 2), Quaternion.identity);
        }
        if (enemy_number == 1)
        {
            Instantiate(enemy, new Vector3(generate.transform.position.x + rnd.Next(-5, 5), generate.transform.position.y + 1.3f, 3), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "princess")
        {
            CreateFloor();
            Destroy(gameObject);
        }
    }
}
