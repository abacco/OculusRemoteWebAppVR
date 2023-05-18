using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    public int playerHealth { get; set; }
    public int playerMana { get; set; }
    public int playerEnergy { get; set; }
    public float dayNightDuration { get; set; }

    public int playerCoins { get; set; }

    //public SpriteRenderer bkgImg { get; set; }
    //public Text dayNightText { get; set; }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        playerHealth = 100;
        playerMana = 100;
        playerEnergy = 100;
        dayNightDuration = 5;

        playerCoins = 0;
    }

    private void Update()
    {
        //PotentialCleaner();
    }

    public void SetDayNightDuration(float dayNightDurationNew)
    {
        this.dayNightDuration = dayNightDurationNew;
    }

    public void PotentialCleaner()
    {
        try
        {
            Coin c = GameObject.Find("Coin(Clone)").GetComponent<Coin>();
            if (c != null && c.isActiveAndEnabled)
            {
                Destroy(c.gameObject);
            }
        }
        catch { }
    }
}
