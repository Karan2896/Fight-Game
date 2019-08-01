using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   
    private Rigidbody myBody;
    public float walk_speed = 3f;
    public float z_speed = 1.5f;
    public float rotation_y = -90f;
    public float rotation_speed = 15f;
    private CharacterAnimation Player_anim;

    void /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
     Awake()
    {
        myBody = GetComponent<Rigidbody>();
        Player_anim = GetComponentInChildren<CharacterAnimation>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate() {
        DetectMovement();
    }

    void DetectMovement(){
        myBody.velocity = new Vector3(Input.GetAxisRaw(Axis.HORIZONTAL_AXIS)* 
        (-walk_speed),myBody.velocity.y,Input.GetAxisRaw(Axis.VERTICAL_AXIS)* (-z_speed));

    }

    void PlayerRotate(){

        if (Input.GetAxis(Axis.HORIZONTAL_AXIS)>0){
            transform.rotation = Quaternion.Euler(0f,-Mathf.Abs(rotation_y),0);
        }
        else if (Input.GetAxis(Axis.HORIZONTAL_AXIS) < 0){
            transform.rotation = Quaternion.Euler(0f,Mathf.Abs(rotation_y),0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        PlayerRotate();
        AnimatePlayerWalk();
    }

    void AnimatePlayerWalk(){
        if(Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) != 0 || Input.GetAxisRaw(Axis.VERTICAL_AXIS) != 0 ){
            Player_anim.Walk(true);
        }
            else{
                Player_anim.Walk(false);
            }
        
    }
}
