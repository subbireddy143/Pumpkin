using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Rigidbody2D player;
    //Vector2 Force;
    Animation anim;
    public static bool isalive;
    /*
    Vector3 new_pos;
    Vector3 pos;
    Transform trans;
    */

    Play_Button_Manager PBM;

    // Start is called before the first frame update
    void Start()
    {
        
        //trans = GetComponent<Transform>();   
        Isalive(true);
        player = GetComponent<Rigidbody2D>();
        player.gravityScale = 0;
        //Force.x = 0;
        //Force.y = 5;
        anim = GetComponent<Animation>();

        PBM = gameObject.AddComponent<Play_Button_Manager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (isalive && !PBM.Ispaused())
        {
            if (Input.touchCount > 0)
            {
                transform.Translate(0,(2f*Time.deltaTime),0);
                /*
                pos = GetComponent<Transform>().position;
                new_pos = pos;
                new_pos.y = pos.y + (3f * Time.deltaTime);
                trans.GetComponent<Transform>().position = new_pos;
                */
                /*Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Ended)
                    player.AddForce(-2*Force);
                else
                    player.AddForce(Force);
                */
            }

            else
            {
                transform.Translate(0,(-2f*Time.deltaTime), 0);
                /*
                pos = GetComponent<Transform>().position;
                new_pos = pos;
                new_pos.y = pos.y + (-3f * Time.deltaTime);
                trans.GetComponent<Transform>().position = new_pos;
                */
            }
        }
        if (!isalive)
            player.gravityScale = 1;
    }

    public void Isalive(bool status)
    {
        isalive = status;
    }

    public bool Isalive()
    {
        return isalive;
    }
}
