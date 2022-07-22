using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LSUIController : MonoBehaviour
{
    public static LSUIController instance;
    public Image fadeScreen;
    public float fadeSpeed;
    private bool shouldFadeToBlack, shouldFadeFromBlack;
    public GameObject levelInfoPanel;
    public Text levelName, coinsFound, coinsTarget, bestTime, timeTarget;
    void Awake(){
        instance = this;
    }
    void Start()
    {
        FadeFromBlack();
    }

    
    void Update()
    {
        if(shouldFadeToBlack){
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 1f, fadeSpeed * Time.deltaTime));
            if(fadeScreen.color.a == 1f){
                shouldFadeToBlack = false;
            }
        }

        if(shouldFadeFromBlack){
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 0, fadeSpeed * Time.deltaTime));
            if(fadeScreen.color.a == 0){
                shouldFadeFromBlack = false;
            }
        }
    }

    public void FadeToBlack(){
        shouldFadeToBlack = true;
        shouldFadeFromBlack = false;
    }

    public void FadeFromBlack(){
        shouldFadeFromBlack = true;
        shouldFadeToBlack = false;
    
    }

    public void ShowInfo(MapPoint levelInfo){
        levelName.text = levelInfo.levelName;

        coinsFound.text = "FOUND:" + levelInfo.coinsCollected;
        coinsTarget.text = "IN LEVEL:" + levelInfo.totalCoins;

        timeTarget.text = "TARGET:" + levelInfo.targetTime + "s";

        if(levelInfo.bestTime == 0){
            bestTime.text = "BEST:-";
        } else{
            bestTime.text = "BEST:" + levelInfo.bestTime.ToString("F1") + "s";
        }

        levelInfoPanel.SetActive(true);
    }

    public void HideInfo(){
        levelInfoPanel.SetActive(false);
    }
}
