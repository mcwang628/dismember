using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float rootMovementSpeed = 1f;
    public float animationSpeed = 1f;
    //public float rootTurnSpeed = 1f;
    public GameObject leftArm;
    public GameObject hands;
    public AudioManager audioManager;
    public BGMManager BGMManager;

    [SerializeField]
    public AudioClip[] walkSteps;
    [SerializeField]
    public AudioClip[] runSteps;

    private Animator anim;
    private float inputV;
    private float inputH;
    private bool hasArm;
    private SphereCollider weaponCollider;
    private AudioSource audioSource;

    void Start()
    {
        anim = GetComponent<Animator>();
        hasArm = true;
        weaponCollider = hands.GetComponent<SphereCollider>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        inputV = Input.GetAxis("Vertical");
        inputH = Input.GetAxis("Horizontal");
        if (inputV != 0 || inputH != 0) 
        {
            anim.SetBool("isMoving", true);
            anim.speed = animationSpeed;
            anim.SetFloat("vely", Mathf.Sqrt(inputH * inputH + inputV * inputV));

        }
        else
        {
            anim.SetBool("isMoving", false);
            anim.SetFloat("vely", 0);
        }
        if (Input.GetKeyDown(KeyCode.R) && !anim.GetBool("Detaching") && !anim.GetBool("Attaching"))
        {
            StartCoroutine(DetachCO());
        }
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(AttackCO());
        }

    }

    void OnAnimatorMove()
    {

        Vector3 newRootPosition;

        newRootPosition = anim.rootPosition;

        transform.position = Vector3.LerpUnclamped(transform.position, newRootPosition, rootMovementSpeed);

    }

    //IEnumerator JumpCO()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        anim.SetFloat("velx", 1.1f);
    //    }

    //    yield return new WaitForSeconds(5);

    //    anim.SetFloat("velx", 0);
    //}

    IEnumerator DetachCO()
    {
        if (hasArm)
        {
            anim.SetBool("Detaching", true);
            yield return new WaitForSeconds(1.24f);
            anim.SetBool("Detaching", false);
        }
        else
        {
            anim.SetBool("Attaching", true);
            yield return new WaitForSeconds(1.24f);
            anim.SetBool("Attaching", false);
        }
        hasArm = !hasArm;
    }

    IEnumerator AttackCO()
    {
        anim.SetBool("Attacking", true);
        yield return new WaitForSeconds(0.25f);
        anim.SetBool("Attacking", false);
    }

    void ArmAppearOrDisappear()
    {
        if (hasArm)
        {
            leftArm.transform.localScale = new Vector3(0, 0, 0);
        }else
        {
            leftArm.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    IEnumerator Attack()
    {
        weaponCollider.enabled = true;
        yield return new WaitForSeconds(0.15f);
        weaponCollider.enabled = false;
    }

    void WalkStep()
    {
        AudioClip clip = GetRandomSoundFromList(walkSteps);
        audioSource.PlayOneShot(clip);
    }

    void RunStep()
    {
        AudioClip clip = GetRandomSoundFromList(runSteps);
        audioSource.PlayOneShot(clip);
    }

    AudioClip GetRandomSoundFromList(AudioClip[] audioList)
    {
        return audioList[Random.Range(0, audioList.Length)];
    }
    
}
