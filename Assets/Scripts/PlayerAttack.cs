using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ComboState
{
        NONE,
        PUNCH_1,
        PUNCH_2,
        PUNCH_3,
        KICK_1,
        KICK_2
    
}

public class PlayerAttack : MonoBehaviour
{
    // Start is called before the first frame update
    private CharacterAnimation player_anim;
    private bool activateTimertoAttack;
    private float defaul_Combo_timer = 0.4f;
    private float current_Combo_timer = 0;

    private ComboState current_Combo_state;
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        player_anim = GetComponent<CharacterAnimation>();
    }
    void Start()
    {
        current_Combo_timer = defaul_Combo_timer;
        current_Combo_state = ComboState.NONE;
    }

    // Update is called once per frame
    void Update()
    {
        ComboAttack();
        resetCombostate();
    }

    void ComboAttack(){
        if(Input.GetKeyDown(KeyCode.Z)){
                
                if(current_Combo_state == ComboState.PUNCH_3 || current_Combo_state == ComboState.KICK_1 ||
                    current_Combo_state == ComboState.KICK_2)
                    return;

                current_Combo_state++;
                activateTimertoAttack = true;
                current_Combo_timer = defaul_Combo_timer;

                if(current_Combo_state == ComboState.PUNCH_1){
                    player_anim.Punch_1();
                }
                if(current_Combo_state == ComboState.PUNCH_2){
                    player_anim.Punch_2();
                }
                if(current_Combo_state == ComboState.PUNCH_3){
                    player_anim.Punch_3();
                }
        }
        if(Input.GetKeyDown(KeyCode.X)){
                if(current_Combo_state == ComboState.PUNCH_3 ||
                    current_Combo_state == ComboState.KICK_2)
                    return;

                    if(current_Combo_state == ComboState.NONE ||
                    current_Combo_state == ComboState.PUNCH_1 ||
                    current_Combo_state == ComboState.PUNCH_2){
                        current_Combo_state = ComboState.KICK_1;
                    }
                    else if(current_Combo_state == ComboState.KICK_1){
                        current_Combo_state++;
                    }

                    activateTimertoAttack =true;
                    current_Combo_timer = defaul_Combo_timer;

                    if(current_Combo_state == ComboState.KICK_1){
                        player_anim.Kick_1();
                    }
                    if(current_Combo_state == ComboState.KICK_2){
                        player_anim.Kick_2();
                    }
        }

    }

    void resetCombostate(){
        if(activateTimertoAttack){
            current_Combo_timer -= Time.deltaTime;
            if(current_Combo_timer <=0){
                current_Combo_state = ComboState.NONE;
            }
        }
    }
}
