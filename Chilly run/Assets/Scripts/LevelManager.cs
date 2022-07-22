using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public float waitTorespawn;
    public int coinsCollected;
    public string levelToLoad;

    public float timeInLevel;

    private void Awake(){
        instance = this;
    }
    void Start()
    {
        timeInLevel = 0f;
    }

    
    void Update()
    {
        timeInLevel += Time.deltaTime;
    }

    public void RespawnPlayer(){
         StartCoroutine(RespawnCo());
    }

    private IEnumerator RespawnCo(){
    
        PlayerController.instance.gameObject.SetActive(false);

        AudioManager.instance.PlaySFX(4);

        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    //PlayerController.instance.gameObject.SetActive(true);

    //PlayerController.instance.transform.position = SpawnPointController.instance.spawnPoint;

    //PlayerHealthController.instance.currentHealth = PlayerHealthController.instance.maxHealth;

    //UIController.instance.UpdateHealthDisplay();

    //LevelManager.instance.coinsCollected = 0;

    //UIController.instance.UpdateCoinCount();

    

    

    

    

    

    

    }

    public void EndLevel(){
    StartCoroutine(EndLevelCo());
    }

    public IEnumerator EndLevelCo(){
        PlayerController.instance.stopInput = true;

        AudioManager.instance.PlaySFX(6);

        UIController.instance.levelCompleteText.SetActive(true);

        yield return new WaitForSeconds(1.25f);

        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_unlocked", 1);

        PlayerPrefs.SetString("Currentlevel", SceneManager.GetActiveScene().name);

        if(PlayerPrefs.HasKey(SceneManager.GetActiveScene().name + "_coins")){

            if(coinsCollected > PlayerPrefs.GetInt(SceneManager.GetActiveScene().name + "_coins")){
                PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_coins", coinsCollected);
            }
        }
        else{
            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_coins", coinsCollected);
        }

        if(PlayerPrefs.HasKey(SceneManager.GetActiveScene().name + "_time")){
            if(timeInLevel < PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name + "_time")){
                PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name + "_time", timeInLevel); 
            }
        }
        else{
        PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name + "_time", timeInLevel); 
        }

        SceneManager.LoadScene(levelToLoad);
    }
}
