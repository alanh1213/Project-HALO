using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorpionHatch : MonoBehaviour
{
    Animator animator;
    ScorpionController referenciaScorpion;
    void Awake()
    {
        animator = GetComponent<Animator>();
        referenciaScorpion = GameObject.Find("Scorpion").GetComponent<ScorpionController>();
    }

    void Start()
    {
        animator.Play("ScorpionHatch");
    }

    // Update is called once per frame
    void Update()
    {
        if(referenciaScorpion.playerInside)
        {
            animator.Play("ScorpionHatchClosing");
        } else 
        {
            animator.Play("ScorpionHatch");
        }
    }
}
