using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;

public class GUIMANAGER : MonoBehaviour
{
    public static GUIMANAGER instance { get; private set; }
    //[SerializeField]
    private string healthTextName = "Salute";
    private string manaTextName = "Mana";
    private string energyTextName = "Energia";
    private string dayNightTextName = "DayNight";
    private string playerCoinsTextName = "PlayerCoinsText";

    private Text healthText, manaText, energyText, playerCoinsText;
    private Slider healthSlider, manaSlider, energySlider;

    private int startDayNightValue;


    // dayNight logic ------------
    public Text dayNightText;
    public SpriteRenderer backgroundSpriteRenderer;
    public float maxAlpha = 1f;
    public float minAlpha = 0.35f;

    private float timer;
    // ----------------

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
    }

    private void Start()
    {
        startDayNightValue= (int)GameObject.Find("GAME_MANAGER").gameObject.GetComponent<GameManager>().dayNightDuration;
        //backgroundSpriteRenderer = GameObject.Find("GAME_MANAGER").gameObject.GetComponent<GameManager>().bkgImg;
        //dayNightText = GameObject.Find("GAME_MANAGER").gameObject.GetComponent<GameManager>().dayNightText;
        
        if (FindAndInitializeText())
        {
            UpdateText();
        }
        else
        {
            Debug.LogError("Health text object not found: " + healthTextName);
        }
    }

    private void Update()
    {
        startDayNightValue = (int)GameObject.Find("GAME_MANAGER").gameObject.GetComponent<GameManager>().dayNightDuration;
        //UpdateDayNightCycle(startDayNightValue);
        if (healthText != null && manaText != null && energyText != null)
        {
            UpdateText();
        }
        
    }

    public bool FindAndInitializeText()
    {
        try
        {
            GameObject textObject = GameObject.Find(healthTextName);
            GameObject textObject2 = GameObject.Find(manaTextName);
            GameObject textObject3 = GameObject.Find(energyTextName);
            GameObject textObject4 = GameObject.Find(dayNightTextName);
            GameObject textObject5 = GameObject.Find(playerCoinsTextName);

            healthText = textObject.GetComponent<Text>();
            manaText = textObject2.GetComponent<Text>();
            energyText = textObject3.GetComponent<Text>();
            dayNightText = textObject4.GetComponent<Text>();
            playerCoinsText = textObject5.GetComponent<Text>();


            healthSlider = GameObject.Find("HealthSlider").GetComponent<Slider>();
            manaSlider = GameObject.Find("ManaSlider").GetComponent<Slider>();
            energySlider = GameObject.Find("EnergySlider").GetComponent<Slider>();


            return true;

        } catch (Exception e)
        {
            return false;
        }

    }

    public void UpdateText() { 
           healthText.text = "Health: " + GameObject.Find("GAME_MANAGER").gameObject.GetComponent<GameManager>().playerHealth;
           manaText.text = "Mana: " + GameObject.Find("GAME_MANAGER").gameObject.GetComponent<GameManager>().playerMana;
           energyText.text = "Energy: " + GameObject.Find("GAME_MANAGER").gameObject.GetComponent<GameManager>().playerEnergy;
           playerCoinsText.text = "Coins: " + GameObject.Find("GAME_MANAGER").gameObject.GetComponent<GameManager>().playerCoins;

           healthSlider.value = GameObject.Find("GAME_MANAGER").gameObject.GetComponent<GameManager>().playerHealth;
           manaSlider.value = GameObject.Find("GAME_MANAGER").gameObject.GetComponent<GameManager>().playerMana;
           energySlider.value = GameObject.Find("GAME_MANAGER").gameObject.GetComponent<GameManager>().playerEnergy;

    }

    //public float GetDayNightDurationValue()
    //{
    //    try
    //    {
    //        float dayDuration = GameObject.Find("GAME_MANAGER").gameObject.GetComponent<GameManager>().dayNightDuration;
    //        return dayDuration;

    //    } catch (Exception e)
    //    {
    //        Debug.LogError(e);
    //        return 0.0f;
    //    }
        
    //}

    //public void DayNightCycleUpdateText()
    //{
    //    if(GetDayNightDurationValue() > 0f)
    //    {
    //        dayNightText.text = "Night In: " + GameObject.Find("GAME_MANAGER").gameObject.GetComponent<GameManager>().dayNightDuration;
            
    //    }
    //    if(GetDayNightDurationValue() == 0f)
    //    {
    //        dayNightText.text = "Day In: " + GameObject.Find("GAME_MANAGER").gameObject.GetComponent<GameManager>().dayNightDuration;
    //        GameObject.Find("GAME_MANAGER").gameObject.GetComponent<GameManager>().dayNightDuration = startDayNightValue;
    //    }

    //}

}
