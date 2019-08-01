using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    public void Walk(bool move){
        anim.SetBool(AnimationTags.MOVEMENT,move);
    }

    public void Punch_1(){
        anim.SetTrigger(AnimationTags.PUNCH1_TRIGGER);
    }

    public void Punch_2(){
        anim.SetTrigger(AnimationTags.PUNCH2_TRIGGER);
    }
    public void Punch_3(){
        anim.SetTrigger(AnimationTags.PUNCH3_TRIGGER);
    }
    public void Kick_1(){
        anim.SetTrigger(AnimationTags.KICK1_TRIGGER);
    }
    public void Kick_2(){
        anim.SetTrigger(AnimationTags.KICK2_TRIGGER);
    }


    //Enemy Animations

    public void EnemyAttack(int attack){

        if(attack==0){
            anim.SetTrigger(AnimationTags.ATTACK1_TRIGGER);
        }
         if(attack==1){
            anim.SetTrigger(AnimationTags.ATTACK2_TRIGGER);
        }
         if(attack==2){
            anim.SetTrigger(AnimationTags.ATTACK3_TRIGGER);
        }
    }

    public void Play_IdleAnimation(){
        anim.Play(AnimationTags.IDLE_ANIMATION);
    }

    public void KnockDown(){
        anim.SetTrigger(AnimationTags.KNOCKDOWN_TRIGGER);
    }

    public void StandUp(){
        anim.SetTrigger(AnimationTags.STANDUP_TRIGGER);
    }

    public void Hit(){
        anim.SetTrigger(AnimationTags.HIT_TRIGGER);
    }

    public void Death(){
        anim.SetTrigger(AnimationTags.DEATH_TRIGGER);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
