using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    public Vector2 Force;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        Force.x = 100;
        Force.y = 100;//Random.Range(-100,100);
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(Force);
    }

    
}
