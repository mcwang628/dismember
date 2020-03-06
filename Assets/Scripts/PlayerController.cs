using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;
    public float rootMovementSpeed = 1f;
    public float animationSpeed = 1f;
    public float rootTurnSpeed = 1f;
    private float inputV;
    private float inputH;


    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        inputV = Input.GetAxis("Vertical");
        inputH = Input.GetAxis("Horizontal");
        if (inputV != 0 || inputH != 0 || anim.GetFloat("velx") != 0) 
        {
            anim.SetBool("isMoving", true);
            anim.speed = animationSpeed;
            anim.SetFloat("vely", Mathf.Abs(inputV));
        }else
        {
            anim.SetBool("isMoving", false);
            anim.SetFloat("vely", 0);
        }
        if (anim.GetFloat("velx") == 0)
            StartCoroutine(JumpCO());

    }

    void OnAnimatorMove()
    {

        Vector3 newRootPosition;
        Quaternion newRootRotation;

        newRootPosition = anim.rootPosition;

        newRootRotation = anim.rootRotation;

        this.transform.position = Vector3.LerpUnclamped(this.transform.position, newRootPosition, rootMovementSpeed);
        this.transform.rotation = Quaternion.LerpUnclamped(this.transform.rotation, newRootRotation, rootTurnSpeed);

    }

    IEnumerator JumpCO()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetFloat("velx", 1.1f);
        }

        yield return new WaitForSeconds(5);

        anim.SetFloat("velx", 0);
    }
}
