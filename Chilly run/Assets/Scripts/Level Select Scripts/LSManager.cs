using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LSManager : MonoBehaviour
{
    public LSPlayer player;

    private MapPoint[] allPoints;

    void Start(){
        allPoints = FindObjectsOfType<MapPoint>();

        if(PlayerPrefs.HasKey("Currentlevel")){
            foreach(MapPoint point in allPoints){
                if(point.levelToLoad == PlayerPrefs.GetString("Currentlevel")){
                    player.transform.position = point.transform.position;
                    player.currentPoint = point;
                }
            }
        }
    }
    
    public void LoadLevel(){
        StartCoroutine(LoadLevelCo());
    }

    public IEnumerator LoadLevelCo(){
        AudioManager.instance.PlaySFX(8);

        LSUIController.instance.FadeToBlack();

        yield return new WaitForSeconds((1f / LSUIController.instance.fadeSpeed) + .25f);;

        SceneManager.LoadScene(player.currentPoint.levelToLoad);
    }


}
