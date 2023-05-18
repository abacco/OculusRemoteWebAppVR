using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pickup()
    {
        // Handle the coin pickup behavior
        // For example, increment player's coin count, play a sound effect, etc.
        //GameManager.instance.playerCoins++;
        // Destroy the coin game object
        try
        {
            //Destroy(gameObject);
            GameManager.instance.playerCoins++;
            gameObject.SetActive(false);
            Destroy(gameObject);
        } 
        catch(Exception e)
        {
            gameObject.SetActive(false);
        } finally { gameObject.SetActive(false); }
        
    }
}
