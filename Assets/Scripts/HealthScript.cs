using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public float health = 100f;
    private CharacterAnimation animationScript;
    private EnemyMovement enemyMovement;

    private bool CharacterDied;
    public bool is_Player;

    private HealthUI health_ui;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        animationScript = GetComponentInChildren<CharacterAnimation>();
        if(is_Player)
            health_ui = GetComponent<HealthUI>();
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ApplyDamage(float damage, bool knockDown){
        if(CharacterDied){
            return;
        }
            
        
        health -= damage;
        if(is_Player)
            health_ui.DisplayHealth(health);

        if(health<=0f){
            animationScript.Death();
            CharacterDied = true;

            if(is_Player){
                GameObject.FindWithTag(Tags.ENEMY_TAG).GetComponent<EnemyMovement>().enabled = false;
            }

            return;

        }
        if(!is_Player){
             if(knockDown){
                 if(Random.Range(0,2)>0){
                     animationScript.KnockDown();
                 }
             }
             else{
                 if(Random.Range(0,3) > 1){
                     animationScript.Hit();
                 }
             }   
            }
    }
}
