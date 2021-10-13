using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 20f;

    private Rigidbody2D rbs;

    private Vector2 screenBounds;

    void Start()
    {
        rbs = this.GetComponent<Rigidbody2D>();
        rbs.velocity = new Vector2(-speed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < -30)
        {
            Destroy(this.gameObject);
        }
    }
}
