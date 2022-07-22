using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowtrapController : MonoBehaviour
{
    public Transform firePoint;
    public GameObject arrow;
    public float timeBetween;
    public float startTimeBetween;
    void Start()
    {
        timeBetween = startTimeBetween;
    }

    
    void Update()
    {
        if(timeBetween <=0){
            Instantiate(arrow, firePoint.position, firePoint.rotation);
            timeBetween = startTimeBetween;
        } else{
            timeBetween -= Time.deltaTime;
        }
    }
}
