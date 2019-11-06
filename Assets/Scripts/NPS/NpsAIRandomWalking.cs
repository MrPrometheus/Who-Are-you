using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpsAIRandomWalking : MonoBehaviour
{
    public float moveSpeed;
    private Vector2 minWalkPoint;
    private Vector2 maxWalkPoint;
    private Animator animator;
    private Rigidbody2D myRigidbody;
    
    public float walkTime;

    public bool isWalking;
    public bool isWorking = true;
    public bool isGuardian = false;

    private float walkCounter;
    public float waitTime;
    private float waitCounter;

    private int WalkDirection;
    public bool isRunningAnim;
    

    public Collider2D walkZone;


    private bool hasWalkZone;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        waitCounter = waitTime;
        walkCounter = walkTime;
        
        ChooseDirection();

        if (walkZone != null)
        {
            minWalkPoint = walkZone.bounds.min;
            maxWalkPoint = walkZone.bounds.max;
            hasWalkZone = true;
        }
        
    }
    
    
    void Update()
    {
        if (isWorking)
        {
            if (isWalking)
            {
                if (animator && !isRunningAnim) {
                    if (isGuardian) animator.SetBool("IsRunningFire", true);
                    else animator.SetBool("IsRunning", true);
                    isRunningAnim = true;
                }
                walkCounter -= Time.deltaTime;
                transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
                switch (WalkDirection)
                {
                    
                    case 0:
                        myRigidbody.velocity = new Vector2(0, moveSpeed);
                        if (hasWalkZone && transform.position.y > maxWalkPoint.y)
                        {
                            isWalking = false;
                            waitCounter = waitTime;
                        }
                        if (transform.localScale.z < 0)
                            transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
                        break;
                    case 1:
                        myRigidbody.velocity = new Vector2(moveSpeed, 0);
                        if (hasWalkZone && transform.position.x > maxWalkPoint.x)
                        {
                            isWalking = false;
                            waitCounter = waitTime;
                        }
                        if (transform.localScale.z < 0)
                            transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
                        break;
                    case 2:
                        myRigidbody.velocity = new Vector2(0, -moveSpeed);
                        if (hasWalkZone && transform.position.y < minWalkPoint.y)
                        {
                            isWalking = false;
                            waitCounter = waitTime;
                        }
                        if (transform.localScale.z < 0)
                            transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
                        break;
                        
                    case 3:
                        myRigidbody.velocity = new Vector2(-moveSpeed, 0);
                        if (hasWalkZone && transform.position.x < minWalkPoint.x)
                        {
                            isWalking = false;
                            waitCounter = waitTime;
                        }
                        transform.localScale = new Vector2(-Mathf.Abs(transform.localScale.x), transform.localScale.y);
                        break;
                }

                if (walkCounter < 0)
                {
                    isWalking = false;
                    waitCounter = waitTime;
                }
            }
            else
            {
                if (animator && isRunningAnim) {
                    if (isGuardian) animator.SetBool("IsRunningFire", false);
                    else animator.SetBool("IsRunning", false);
                    isRunningAnim = false;
                }
                waitCounter -= Time.deltaTime;
                myRigidbody.velocity = Vector2.zero;
                if (waitCounter < 0)
                {
                    ChooseDirection();
                }
            }
        }
        else
        {
            myRigidbody.velocity = Vector2.zero;
        }

    }

    public void ChooseDirection()
    {
        WalkDirection = Random.Range(0, 4);
        isWalking = true;
        walkCounter = walkTime;
    }
}
