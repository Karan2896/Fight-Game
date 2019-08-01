using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationDelegate : MonoBehaviour
{
   public GameObject left_arm_attack_point, left_leg_attack_point, right_arm_attack_point, right_leg_attack_point;

    public float StandUptimer = 2f;
    private CharacterAnimation animationScript;

    private AudioSource audioSource;

    [SerializeField]
    private AudioClip whoosh_sound,fall_sound, ground_hit_sound, dead_sound;

    private EnemyMovement enemy_movement;
    private ShakeCamera shakeCamera;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        animationScript = GetComponent<CharacterAnimation>();

        audioSource = GetComponent<AudioSource>();
        if(gameObject.CompareTag(Tags.ENEMY_TAG)){
            enemy_movement = GetComponentInParent<EnemyMovement>();
        }

        shakeCamera = GameObject.FindWithTag(Tags.MAIN_CAMERA_TAG).GetComponent<ShakeCamera>();
    }
   void left_arm_attack_On(){
        left_arm_attack_point.SetActive(true);
   }

   void left_arm_attack_Off(){
       if(left_arm_attack_point.activeInHierarchy){
           left_arm_attack_point.SetActive(false);
       }
   }

   void right_arm_attack_On(){
        right_arm_attack_point.SetActive(true);
   }

   void right_arm_attack_Off(){
       if(right_arm_attack_point.activeInHierarchy){
           right_arm_attack_point.SetActive(false);
       }
   }

   void right_leg_attack_On(){
        right_leg_attack_point.SetActive(true);
   }

   void right_leg_attack_Off(){
       if(right_leg_attack_point.activeInHierarchy){
           right_leg_attack_point.SetActive(false);
       }
   }

   void left_leg_attack_On(){
        left_leg_attack_point.SetActive(true);
   }

   void left_leg_attack_Off(){
       if(left_leg_attack_point.activeInHierarchy){
           left_leg_attack_point.SetActive(false);
       }
   }

   void tag_left_arm(){
       left_arm_attack_point.tag = Tags.LEFT_ARM_TAG;
   }

   void untag_left_arm(){
       left_arm_attack_point.tag = Tags.UNTAGGED_TAG;
   }

   void tag_left_leg(){
       left_leg_attack_point.tag = Tags.LEFT_LEG_TAG;
   }
   void untag_left_leg(){
       left_leg_attack_point.tag = Tags.UNTAGGED_TAG;
   }

    void Enmemy_StandUp(){
        StartCoroutine(standUp_time());
    }

    IEnumerator standUp_time(){
        yield return new WaitForSeconds(StandUptimer);
        animationScript.StandUp();
    }

    public void Attack_sound(){
        audioSource.volume = 0.2f;
        audioSource.clip = whoosh_sound;
        audioSource.Play();
    }

    void Enemy_knockdown_sound(){
         audioSource.clip = fall_sound;
        audioSource.Play();
    }

    void ground_hitsound(){
         audioSource.clip = ground_hit_sound;
        audioSource.Play();
    }

    void Disable_movement(){
        enemy_movement.enabled = false;
        transform.parent.gameObject.layer = 0;
    }

    void Enable_movement(){
        enemy_movement.enabled = true;
        transform.parent.gameObject.layer = 9;
    }

    void Shake_Camera_onfall(){
            shakeCamera.shoulShake = true;
    }

    void CharacterDied(){
        Invoke("DeactivateGameObject",2f);
    }

    void DeactivateGameObject(){
        EnemyManager.instance.SpawnEnemy();
        gameObject.SetActive(false);
    }
}
