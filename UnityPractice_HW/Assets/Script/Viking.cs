using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]

public class Viking : MonoBehaviour
{
    //public GUIText elapseTimeGUIText;
    private float runSpeed;
    private int runDirection;
    bool jump = false;
    
    [SerializeField]float JumpingForce = 450f;
    [SerializeField] LayerMask GroundMask;
    Rigidbody rigidbody;
    Animator animator;

    // Use this for initialization
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        this.runSpeed = this.defaultRunSpeed;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        jump = false;
        this.processKeyInput();
        animator.SetBool("Jump", jump);
        this.move();
        this.speedUp();
        this.checkFail();
    }

    private float lastRotateTime;
    private float lastJumpTime;
    private bool arrowKeyPressed; //to prevent input two keys at the same time

    //keyborad
    private void processKeyInput() //it's in the update function, so arrowKeyPresses keeps updating to false if you don't press A, D and W
    {
        if (!arrowKeyPressed && Time.time - lastRotateTime > 0.1f)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                runDirection -= 90;
                lastRotateTime = Time.time;
                arrowKeyPressed = true;

            }
            else if (Input.GetKey(KeyCode.E))
            {
                runDirection += 90;
                lastRotateTime = Time.time;
                arrowKeyPressed = true;
            }

            if (Input.GetKey(KeyCode.A)) 
            {
                //move horizontally, 
                //so it has to be checked what direction you are facing now, to decide which direction you gonna move
                if (runDirection % 360 == 0)
                    this.transform.position += Vector3.left;
                else if (runDirection % 360 == 90 || runDirection % 360 == -270)
                    this.transform.position += Vector3.forward;
                else if (runDirection % 360 == 180 || runDirection % 360 == -180)
                    this.transform.position += Vector3.right;
                else if (runDirection % 360 == 270 || runDirection % 360 == -90)
                    this.transform.position += Vector3.back;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                //move horizontally, 
                //so it has to be checked what direction you are facing now, to decide which direction you gonna move
                if (runDirection % 360 == 0)
                    this.transform.position += Vector3.right;
                else if (runDirection % 360 == 90 || runDirection % 360 == -270)
                    this.transform.position += Vector3.back;
                else if (runDirection % 360 == 180 || runDirection % 360 == -180)
                    this.transform.position += Vector3.left;
                else if (runDirection % 360 == 270 || runDirection % 360 == -90)
                    this.transform.position += Vector3.forward;
            }
            
        }

        if (!arrowKeyPressed && Time.time - lastJumpTime > 1f)
        {
            if (Input.GetKey(KeyCode.W))
            {
                Jump();
                jump = true; //to prevent you jump again while you are jumping
                lastJumpTime = Time.time; //record the time you jump
                arrowKeyPressed = true;
            }
        }
       

        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.W))
        {
            arrowKeyPressed = false;
        }

    }

    public float defaultRunSpeed = 10.0f;
    public float speedUpRate = 2.0f;

    private void move()
    {
        this.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, runDirection, 0), 0.25f);

        Vector3 v = transform.forward * this.runSpeed;
        v.y = this.rigidbody.velocity.y;
        this.rigidbody.velocity = v;
    }
    void Jump()
    {
        //check whether we are currently grounded
        float height = GetComponent<Collider>().bounds.size.y;
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (height / 2) + 0.1f , GroundMask);
        //if yes, jump

        rigidbody.AddForce(Vector3.up * JumpingForce);
    }

    private void speedUp()
    {
        //speed up 0.1 per 10sec
        //calculate the new value everytime, it's not add the speedUpRate to the latest one
        this.runSpeed = defaultRunSpeed + Time.time / 10.0f * this.speedUpRate;
    }

    private void checkFail()
    {
        if (transform.position.y < -10) //if fail, initialize all variable
        {
            transform.position = new Vector3(0, 5, 0);
            transform.rotation = Quaternion.identity;
            this.runDirection = 0;
            this.runSpeed = this.defaultRunSpeed;

            SceneManager.LoadScene(2); //load the game over scene
        }
    }
}