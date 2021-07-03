using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star_Count
{
    static int count;
    public void Increment()
    {
        count = PlayerPrefs.GetInt("Star",0);
        count++;
        PlayerPrefs.SetInt("Star",count);
    }
    public void Increment(int num)
    {
        count = PlayerPrefs.GetInt("Star", 0);
        count+=num;
        PlayerPrefs.SetInt("Star", count);
    }
    public void Decrement()
    {
        count = PlayerPrefs.GetInt("Star", 0);
        count--;
        PlayerPrefs.SetInt("Star", count);
    }
    public void Decrement(int num)
    {
        count = PlayerPrefs.GetInt("Star", 0);
        count-=num;
        PlayerPrefs.SetInt("Star", count);
    }
}
