using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareMovement : MonoBehaviour
{

    public float speed = 10f;
    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<CircleMovement>().transform;
        if(player.position.x < transform.position.x)
        {
            speed = speed * -1;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Bound"))
        {
            Destroy(this.gameObject);
        }
    }

}
