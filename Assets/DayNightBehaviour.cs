using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class DayNightBehaviour : MonoBehaviour
{
    public UnityEngine.UI.Text dayNightText;
    public SpriteRenderer backgroundSpriteRenderer;

    private float maxAlpha = 1f;
    private float minAlpha = 0.35f;

    private float timer;
    private bool isDay;

    private void Start()
    {
        float dayNightDuration = GameManager.instance.dayNightDuration;
        timer = dayNightDuration;
        isDay = true;
        UpdateText();
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            isDay = !isDay;
            
            
            float dayNightDuration = GameManager.instance.dayNightDuration;
            timer = dayNightDuration;
        }

        UpdateBackgroundAlpha();
    }

    private void UpdateBackgroundAlpha()
    {
        dayNightText.text = isDay ? "Day in: " + (int)timer : "Night in: " + (int)timer;
        float t = Mathf.Clamp01(timer / GameManager.instance.dayNightDuration);
        float alpha;

        if (isDay)
            alpha = Mathf.Lerp(maxAlpha, minAlpha, t); // Decrease alpha during daytime
        else
            alpha = Mathf.Lerp(minAlpha, maxAlpha, t); // Increase alpha during nighttime

        Color spriteColor = backgroundSpriteRenderer.color;
        spriteColor.a = alpha;
        backgroundSpriteRenderer.color = spriteColor;
    }


    //public UnityEngine.UI.Text dayNightText;
    //public SpriteRenderer backgroundSpriteRenderer;
    //public float maxAlpha = 1f;
    //public float minAlpha = 0.35f;

    //private float timer;
    //private bool isDay;

    //int dayNightDuration, initialDayNightDuration;
    //private void Start()
    //{
    //    initialDayNightDuration = (int)GameManager.instance.dayNightDuration;

    //    dayNightDuration = (int)GameManager.instance.dayNightDuration;
    //    timer = dayNightDuration;
    //    isDay = true;
    //    //UpdateTextDay();
    //}

    //// t0 = tempo > 0 and day
    //private void Update()
    //{
    //    timer -= Time.deltaTime;

    //    if(dayNightDuration > 0 && isDay)
    //    {
    //        // all'inizio è giorno
    //        isDay = true;
    //        //UpdateTextNight(timer);
    //        int minutes = Mathf.FloorToInt(timer / 60);
    //        int seconds = Mathf.FloorToInt(timer % 60);
    //        string formattedTime = string.Format("Night in: " + "{0:00}:{1:00}", minutes, seconds);
    //        dayNightText.text = formattedTime;
    //    }
    //    if(dayNightDuration == 0 && !isDay)
    //    {
    //        isDay = !isDay;
    //        //UpdateTextDay(timer);
    //        int minutes = Mathf.FloorToInt(timer / 60);
    //        int seconds = Mathf.FloorToInt(timer % 60);
    //        string formattedTime = string.Format("Day in: " + "{0:00}:{1:00}", minutes, seconds);

    //        GameManager.instance.SetDayNightDuration(initialDayNightDuration);
    //        dayNightText.text = formattedTime;

    //        //int dayNightDuration = (int)GameManager.instance.dayNightDuration;
    //        //timer = dayNightDuration;
    //    }

    //    UpdateBackgroundAlpha();
    //}

    //private void UpdateTextDay(float timer)
    //{
    //    int minutes = Mathf.FloorToInt(timer / 60);
    //    int seconds = Mathf.FloorToInt(timer % 60);
    //    string formattedTime = string.Format("Day in: "+"{0:00}:{1:00}", minutes, seconds);
    //    dayNightText.text = formattedTime;
    //}    
    //private void UpdateTextNight(float timer)
    //{
    //    int minutes = Mathf.FloorToInt(timer / 60);
    //    int seconds = Mathf.FloorToInt(timer % 60);
    //    string formattedTime = string.Format("Night In: "+"{0:00}:{1:00}", minutes, seconds);
    //    dayNightText.text = formattedTime;
    //}

    //private void UpdateBackgroundAlpha()
    //{
    //    float t = Mathf.Clamp01(timer / (int)GameManager.instance.dayNightDuration);
    //    float alpha = Mathf.Lerp(minAlpha, maxAlpha, t);

    //    Color spriteColor = backgroundSpriteRenderer.color;
    //    spriteColor.a = alpha;
    //    backgroundSpriteRenderer.color = spriteColor;
    //}


    //public static DayNightBehaviour Instance { get; private set; }

    //public SpriteRenderer skySprite;
    //public int dayDuration; // = 10f; // Duration of a day in seconds
    //public Color dayColor;
    //public Color nightColor;

    //private float currentLerpTime = 0f;
    //private bool isDay = true;

    //[SerializeField]
    //private UnityEngine.UI.Text dayNightText;
    //public int startValue; //GameManager.gmInstance.dayDuration;
    //private int currentValue;

    //private void Awake()
    //{
    //    dayDuration = (int)GameManager.instance.dayNightDuration;
    //    startValue = (int)GameManager.instance.dayNightDuration;
    //    currentValue = startValue;
    //}

    //void Start()
    //{
    //    //dayDuration = GameManager.gmInstance.DayDuration; // non funziona
    //    //startValue = GameManager.gmInstance.DayDuration;

    //    currentValue = startValue;//GameManager.gmInstance.DayDuration;//startValue;

    //    InvokeRepeating("DecreaseValue", 1f, 1f);
    //    UpdateSkyColor();
    //}

    //void Update()
    //{

    //    // Update the current lerp time based on the elapsed time
    //    currentLerpTime += Time.deltaTime;

    //    Debug.Log("current value: " + currentValue);
    //    GameManager.instance.dayNightDuration = currentValue;

    //    Debug.Log("Singleton value: " + GameManager.instance.dayNightDuration);


    //    if (currentLerpTime > startValue)//dayDuration)
    //    {
    //        // Reverse the day-night cycle
    //        currentLerpTime = 0f;
    //        isDay = !isDay;
    //    }

    //    if (isDay)
    //    {
    //        dayNightText.text = "Night In: " + currentValue.ToString();
    //    }
    //    else
    //    {
    //        dayNightText.text = "Day In: " + currentValue.ToString();
    //    }
    //    UpdateSkyColor();
    //}

    //void UpdateSkyColor()
    //{
    //    // Calculate the interpolation value based on the current lerp time and day duration
    //    float t = currentLerpTime / startValue;//dayDuration;

    //    // Interpolate between day and night colors
    //    Color targetColor = isDay ? dayColor : nightColor;
    //    Color currentColor = Color.Lerp(isDay ? nightColor : dayColor, targetColor, t);

    //    // Apply the color to the sky sprite
    //    skySprite.color = currentColor;
    //}

    //void DecreaseValue()
    //{
    //    currentValue -= 1;
    //    GameManager.instance.dayNightDuration -= 1;
    //    if (currentValue == 0)
    //    {
    //        currentValue = startValue;
    //        GameManager.instance.dayNightDuration = startValue;
    //    }
    //    //else
    //    //{
    //    //    currentValue -= 1;
    //    //    Debug.Log("ok");
    //    //}
    //}
}
