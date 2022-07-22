using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPoint : MonoBehaviour
{
    public MapPoint up, right, down, left;
    public bool isLevel, isLocked;
    public string levelToLoad, levelToCheck, levelName;
    public int coinsCollected, totalCoins;
    public float bestTime, targetTime;
    void Start()
    {

        if(isLevel && levelToLoad !=null){

            if(PlayerPrefs.HasKey(levelToLoad+ "_coins")){
                coinsCollected = PlayerPrefs.GetInt(levelToLoad + "_coins");
            }

            if(PlayerPrefs.HasKey(levelToLoad + "_time")){
                bestTime = PlayerPrefs.GetFloat(levelToLoad + "_time");
            }

            isLocked = true;


            if(levelToCheck != null){
                if(PlayerPrefs.HasKey(levelToCheck + "_unlocked")){
                    if(PlayerPrefs.GetInt(levelToCheck + "_unlocked") == 1){
                        isLocked = false;
                    } 
                } 
            }
            if(levelToLoad == levelToCheck){
                isLocked = false;
            }
        }
    }

    
    void Update()
    {
        
    }
}
