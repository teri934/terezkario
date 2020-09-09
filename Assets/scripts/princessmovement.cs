using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class princessmovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public bool ground;
    public int coins;
    public int kills;
    public Sprite dead;
    private gamehandler bar;
    private hearts heart;
    private panelcontroller game;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bar = FindObjectOfType<gamehandler>();
        heart = FindObjectOfType<hearts>();
        game = FindObjectOfType<panelcontroller>();
    }

    // Update is called once per frame
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "block")
        {
            ground = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "floor" || collision.gameObject.tag == "block")
        {
            ground = true;
        }
        if (collision.gameObject.tag == "mushroom")
        {
            Vector2 difference = transform.position - collision.gameObject.transform.position;
            if (Mathf.Abs(difference.y) > Mathf.Abs(difference.x))
            {
                rb.AddForce(Vector2.up * 50, ForceMode2D.Impulse);
            }
        }
        if (collision.gameObject.tag == "enemy")
        {
            Vector2 difference = transform.position - collision.gameObject.transform.position;
            if (Mathf.Abs(2 * difference.y) > Mathf.Abs(difference.x))
            {
                collision.gameObject.transform.GetComponent<enemymovement>().movement.Set(0, 0);
                Destroy(collision.gameObject.GetComponent<BoxCollider2D>());
                collision.gameObject.GetComponent<SpriteRenderer>().sprite = dead;
                kills += 1;
            }
            else
            {
                float state = bar.Life();
                if (state == 0)
                {
                    transform.localRotation = Quaternion.Euler(0, 0, 90);
                    Destroy(GetComponent<BoxCollider2D>());
                    Destroy(rb); 
                    StartCoroutine(ExecuteAfterTime(false));
                }
                else
                {
                    Vector2 hit = transform.position - collision.gameObject.transform.position;
                    rb.AddForce(new Vector2(hit.x, hit.y * 4) * 8, ForceMode2D.Impulse);
                }
                heart.health -= 1;    //pre health typu hearts
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "coin")
        {
            coins += 1;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "gemstone")
        {
            coins += 5;
            Destroy(other.gameObject);
        }
    }

    IEnumerator ExecuteAfterTime(bool win)
    {
        yield return new WaitForSeconds(1f);
        if (win)
        {
            game.Win();
        }
        else
        {
            game.GameOver();
        }
        Destroy(this);
    }
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(Vector2.right * Time.deltaTime * 60, ForceMode2D.Impulse);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(Vector2.left * Time.deltaTime * 60, ForceMode2D.Impulse);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            if (ground)
            {
                rb.AddForce(Vector2.up * Time.deltaTime * 1600, ForceMode2D.Impulse);
                ground = false;
            }
        }

        if (kills >= 3 && coins >= 50)
        {
            Destroy(GetComponent<BoxCollider2D>());
            Destroy(rb);
            StartCoroutine(ExecuteAfterTime(true));
        }
    }
}
