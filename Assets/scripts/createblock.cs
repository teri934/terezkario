using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createblock : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject block;
    private bool counter;
    private System.Random rnd = new System.Random();
    private SpriteRenderer sprite;
    private BoxCollider2D box;
    private GameObject other;
    void Start()
    {
        counter = true;
    }

    // Update is called once per frame
    void CreateBlock()
    {
        int numberx = rnd.Next(18, 60);
        int numbery = rnd.Next(4, 7);
        other = Instantiate(block, new Vector3(transform.position.x + numberx, numbery,0), Quaternion.identity);
        sprite = other.gameObject.GetComponent<SpriteRenderer>();
        box = other.gameObject.GetComponent<BoxCollider2D>();
        sprite.size = new Vector2(0.2f * rnd.Next(1, 5), 0.2f);
        box.size = sprite.size;
    }

    private void OnBecameVisible()
    {
        if (counter)
        {
            CreateBlock();
            counter = false;
        }
    }
    void Update()
    {
        
    }
}
