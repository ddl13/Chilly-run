using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointController : MonoBehaviour
{
    public Vector3 spawnPoint;
    public static SpawnPointController instance;

    private void Awake(){
        instance = this;
    }
    void Start()
    {
        spawnPoint = PlayerController.instance.transform.position;
    }
}
