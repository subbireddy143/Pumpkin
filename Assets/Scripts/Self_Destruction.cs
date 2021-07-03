using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Self_Destruction : MonoBehaviour
{
    public int time;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,time);
    }
}
