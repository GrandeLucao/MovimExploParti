using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Speed Vars")]
    public float speed;
    private float lastY;

    [Header("Jump Vars")]
    public float jumpForce;
    public float jumpBufferTime;
    [SerializeField]
    private float jumpBuffer = 0f;
    [SerializeField]
    private float InputTime;
    private bool isJumping=false;
    public float jumpTime;

    [Header("Coyote & Ground")]
    private bool isGrounded = false;
    public float floorCheckDistance = 0.4f;
    public float floorCheckRadius = 0.5f;
    public float coyoteTime = 0.5f;    
    [SerializeField]
    public float coyoteTimeCounter = 0;
    

    private Rigidbody2D rig;

    public Transform hitbox;
    
    void Awake()
    {
        rig=GetComponent<Rigidbody2D>();     
        lastY=rig.position.y;   
    }

    void Update()
    {
            if(isGrounded)
                lastY=rig.position.y;
        if(Input.GetButtonDown("Jump")){
            jumpBuffer = jumpBufferTime;
            isJumping=true;
            InputTime=jumpTime;
        }     
        if(Input.GetButtonUp("Jump")){
            isJumping=false;
        }    
    }
    void FixedUpdate()
    {
        Move();
        CheckGround();
        Jump();
    }

    void Move()
    {
        float movement= Input.GetAxis("Horizontal");
        rig.velocity=new Vector2(movement*CheckSpeed(), rig.velocity.y);
        if(movement>0 && isGrounded){
            transform.eulerAngles=new Vector3(0,0,0);
        }
        if(movement<0 && isGrounded){
            transform.eulerAngles=new Vector3(0,180,0);
        }

    }

    void Jump()
    {
        float movement= Input.GetAxis("Horizontal");
        if(Input.GetButton("Jump") && isJumping){
            if(InputTime>0){
                rig.velocity=new Vector2(movement*CheckSpeed(), jumpForce);
                InputTime-=Time.deltaTime;
            }else{isJumping=false;}
            
        jumpBuffer = 0f;
        coyoteTimeCounter = 0;

        }
    }

    
    private void CheckGround()
    {
        int mask = ~LayerMask.GetMask("Player");//Projeção da esfera contra todas layers, exceto a do jogador (~)
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, floorCheckRadius, Vector2.down, floorCheckDistance, mask);

        if (rig.velocity.y <= 0f && hit.collider != null)
            coyoteTimeCounter = coyoteTime;

        isGrounded = false;
        if (coyoteTimeCounter > 0)
            isGrounded = true;
        else if (hit.collider != null)
            isGrounded = true;
    }

    private float CheckSpeed(){
        if(Input.GetButton("Run")){
            speed=6f;
        }else{speed=3f;}
        return speed;
    }

    public bool getIsGrouded{
        get { return isGrounded; }
    }

    public bool getIsJumping{
        get { return isJumping; }
    }

    public float getLastY{
        get { return lastY; }
    }


}
