using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pumpkin_Manager : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Player2;
    public GameObject Player3;
    public GameObject Player4;
    public GameObject Player5;
    public GameObject Player6;
    public GameObject Player_Default;
    // Start is called before the first frame update
    void Start()
    {
        Player1.SetActive(false);
        Player2.SetActive(false);
        Player3.SetActive(false);
        Player4.SetActive(false);
        Player5.SetActive(false);
        Player6.SetActive(false);
        Set_Player();
    }

    void Set_Player()
    {
        int id = PlayerPrefs.GetInt("Player_Id", 0);
        Player_Default.SetActive(false);
        Debug.Log(id);
        switch (id)
        {
            
            case 1:
                Player1.SetActive(true);
                break;
            case 2:
                Player2.SetActive(true);
                break;
            case 3:
                Player3.SetActive(true);
                break;
            case 4:
                Player4.SetActive(true);
                break;
            case 5:
                Player5.SetActive(true);
                break;
            case 6:
                Player6.SetActive(true);
                break;
            default:
                Player_Default.SetActive(true);
                break;

        }
        PlayerPrefs.SetInt("Player_Id", 0);
    }
}
