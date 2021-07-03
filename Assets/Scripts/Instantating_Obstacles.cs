using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantating_Obstacles : MonoBehaviour
{
    public GameObject Obj_Inst;
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Instantiating_Objects", 7f,1f);
        //player = GetComponent<Player>();
    }

    void Instantiating_Objects()
    {
        if(player.Isalive())
            Instantiate(Obj_Inst,GetComponent<Transform>().position,GetComponent<Transform>().rotation);
    }
}
