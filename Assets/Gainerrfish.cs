using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gainerrfish : MonoBehaviour
{

    //public float speed;
    private Transform target;
    public float speed = 10.0f;
    private Rigidbody2D rb;
    private Vector2 screenBounds;

    bool isFollowFish; 

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed * 4 /5, 0);
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }


    // Update is called once per frame
    void Update()
    {
        if ((isFollowFish) && Vector2.Distance(transform.position, target.position) > 2)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        }

        else if (transform.position.x < Camera.main.transform.position.x - screenBounds.x * 2)
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isFollowFish = true;
        }
    }
}
