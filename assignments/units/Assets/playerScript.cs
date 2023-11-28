using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.EventSystems;

public class playerScript : MonoBehaviour
{
    public CharacterController controller;
    public Animator animator;
    float moveSpeed = 5;
    Vector3 target;
    bool hasTarget = false;
    public bool play = true;
    bool move;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnEnable()
    {
        UIManagerScript.killAnimation += stopAnimation;
    }

    private void OnDisable()
    {
        UIManagerScript.killAnimation -= stopAnimation;
    }


    // Update is called once per frame
    void Update()
    {
        if (play)
        {
            Vector3 amountToMove = Vector3.zero;
            move = false;

            if (hasTarget)
            {
                Vector3 vectorToTarget = (target - transform.position).normalized;

                float step = 5 * Time.deltaTime;
                Vector3 rotatedTowardsVector = Vector3.RotateTowards(transform.forward, vectorToTarget, step, 1);
                rotatedTowardsVector.y = 0;
                transform.forward = rotatedTowardsVector;

                amountToMove = vectorToTarget * moveSpeed * Time.deltaTime;
                controller.Move(amountToMove);
                move = true;

                if (Vector3.Distance(transform.position, target) < 0.1f)
                {
                    hasTarget = false;
                }
            }
            animator.SetBool("move", move);
        }
    }

    public void SetTarget(Vector3 t)
    {
        target = t;
        hasTarget = true;
    }

    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("FieldCollider"))
        {
            UIManagerScript.UISharedInstance.hurtPlayer(0.1f);
        }

        if(other.CompareTag("GoldCollider"))
        {
            UIManagerScript.UISharedInstance.increaseGold(0.1f);
        }

        if(other.CompareTag("QuotaCollider"))
        {
            if (UIManagerScript.UISharedInstance.currentGold > 0) {
                UIManagerScript.UISharedInstance.updateQuota(UIManagerScript.UISharedInstance.currentGold);
                UIManagerScript.UISharedInstance.decreaseGold(UIManagerScript.UISharedInstance.currentGold);
            }
        }

        if(other.CompareTag("HealthCollider"))
        {
            UIManagerScript.UISharedInstance.healPlayer(0.5f);
        }
    }

    void stopAnimation()
    {
        move = false;
        animator.SetBool("move", move);
    }
}
