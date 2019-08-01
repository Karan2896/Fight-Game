using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCamera : MonoBehaviour
{
    public float power = 0.2f;
    public float duration = 0.2f;
    public float slowDownAmount= 1f;
    public bool shoulShake;
    private float InitialDuration;
    

    private Vector3 startPosition;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        startPosition = transform.localPosition;
        InitialDuration = duration;
        
    }

    // Update is called once per frame
    void Update()
    {
        Shake();
    }

    void Shake(){
        if(shoulShake){
            if(duration > 0f){
                transform.localPosition = startPosition + Random.insideUnitSphere * power;
                duration -= Time.deltaTime * slowDownAmount;
                
                
            }
            else
            {
                shoulShake = false;
                duration = InitialDuration;
                transform.localPosition = startPosition;
                
            }
        }
    }

   
}
