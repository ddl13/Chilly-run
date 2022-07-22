using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrap : MonoBehaviour
{
    [Header("Firetrap Timers")]
    [SerializeField] private float activationDelay;
    [SerializeField] private float activeTime;
    private Animator anim;
    private SpriteRenderer sr;
    

    private bool triggered;
    private bool active;
    void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

   
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            if(!triggered)
                StartCoroutine(ActivateFiretrap());
            
            if(active)
                PlayerHealthController.instance.DealDamage();
            
        }
    }
    private IEnumerator ActivateFiretrap(){
        triggered = true;
        sr.color = Color.red;

        yield return new WaitForSeconds(activationDelay);
        sr.color = Color.white;
        active = true;
        anim.SetBool("activated", true);
        

        yield return new WaitForSeconds(activeTime);
        active = false;
        triggered = false;
        anim.SetBool("activated", false);
        
    }
}
