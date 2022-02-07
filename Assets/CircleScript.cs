using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleScript : MonoBehaviour
{
    float speed = 5;
    Vector3 origin = new Vector3(0,0,1);
    public bool doSquish;
    public bool doTrail;
    TrailRenderer trail;
    Animator animator;
    void Awake()
    {
        trail = gameObject.GetComponent<TrailRenderer>();
        animator = gameObject.GetComponent<Animator>();
        doSquish = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, origin) < 1.0f)
            animator.SetBool("doSquish", false);

        if (doTrail)
        {
            trail.enabled = true;
        }
        else {
            trail.enabled = false;
        }

        transform.Translate(Vector3.left* speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (doSquish) {
            animator.SetBool("doSquish", true);
        }
        speed *= -1;

        //Bounce off the wall
    }
}
