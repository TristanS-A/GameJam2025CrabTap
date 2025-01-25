using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beanKounter : MonoBehaviour
{
    [SerializeField] private float startingMoney = 5.0f;
    private float playerMonee = 0;
    
    //Getters and setters
    public float getMonee()
    {
        return playerMonee;
    }
    public void setMonee(float monee)
    {
        playerMonee = monee;
    }
    public void addMonee(float monee)
    {
        playerMonee += monee;
    }
    public void subtractMonee(float monee)
    {
        playerMonee -= monee;
    }

}
