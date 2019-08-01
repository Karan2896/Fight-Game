using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    private Image Health_UI;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        Health_UI = GameObject.FindWithTag(Tags.HEALTH_UI).GetComponent<Image>();
    }
    // Start is called before the first frame update
   
   public void DisplayHealth(float value){
       value /= 100f;
       if(value<0f){
           value=0f;
       }
       Health_UI.fillAmount = value;
   }
}
