using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private CharacterAnimation enemyAnim;
    private Rigidbody myBody;
    public float speed = 5f;
    private Transform player_target;
    public float attack_distance = 1f;
    private float chase_player_after_attack = 1f;
    private float current_attack_time;
    private float default_attack_time=2f;
    private bool followPlayer, attackPlayer;
    // Start is called before the first frame update
    
    void /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    Awake()
    {
      enemyAnim = GetComponentInChildren<CharacterAnimation>();
      myBody = GetComponent<Rigidbody>();
      player_target = GameObject.FindWithTag(Tags.PLAYER_TAG).transform;  
    }
    void Start()
    {
        followPlayer = true;
        current_attack_time = default_attack_time;
    }

    private void FixedUpdate() {
        FollowTarget();
    }
    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    void FollowTarget(){
        if(!followPlayer){
            return;
        }

        if(Vector3.Distance(transform.position,player_target.position)> attack_distance){
            transform.LookAt(player_target);
            myBody.velocity = transform.forward * speed;

            if(myBody.velocity.sqrMagnitude != 0){
                enemyAnim.Walk(true);
            }

        }
        else if (Vector3.Distance(transform.position,player_target.position) <= attack_distance){
            myBody.velocity = Vector3.zero;
            enemyAnim.Walk(false);

            followPlayer = false;
            attackPlayer = true;
        }
    } // followtarget

    void Attack(){
        if(!attackPlayer){
            return;
        }

        current_attack_time +=Time.deltaTime;

        if(current_attack_time > default_attack_time){
            enemyAnim.EnemyAttack(Random.Range(0,3));
            current_attack_time = 0f;
        }

        if(Vector3.Distance(transform.position,player_target.position) > attack_distance + chase_player_after_attack){
            attackPlayer=false;
            followPlayer=true;
        }
    }
}//class
