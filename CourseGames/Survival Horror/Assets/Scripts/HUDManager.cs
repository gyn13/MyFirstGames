using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public static HUDManager Instance {get; private set;}
    
    public Slider staminaSlider;
    public Image staminaColor;

    public GameObject pressEObj;

    public TMP_Text paperCount;
    public int papers;

    public GameObject monsterObj;
    
    public GameObject victoryObj;

    public void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PaperCounter();
    }

    public void AddPaper()
    {
        papers++;
        PaperCounter();
        
        monsterObj.SetActive(true);

        if (papers == 5)
        {
            monsterObj.SetActive(false);
            victoryObj.SetActive(true);
        }
    }

    void PaperCounter()
    {
        paperCount.text = papers.ToString() + "/" + 5;
    }
}
