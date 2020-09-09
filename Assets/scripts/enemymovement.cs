using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemymovement : MonoBehaviour
{
    public Vector2 movement;
    Vector2 position;
    bool turn;
    // Start is called before the first frame update
    void Start()
    {
        movement.Set(3, 0);
        position = transform.position;
        turn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(transform.position.x - position.x) > 6)
        {
            transform.Translate(new Vector3(Mathf.Abs(transform.position.x - position.x) - 6, 0) * -movement.x);
            turn = !turn;
            movement = - movement;
            GetComponent<SpriteRenderer>().flipX = turn;
        }
        transform.Translate(movement * Time.deltaTime);
    }
}
