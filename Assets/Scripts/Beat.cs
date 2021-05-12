using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beat : MonoBehaviour
{
    private AudioSource AudioSource;
    private Animator Animator;
    public enum eInput
    {
        NONE,
        A,
        Z,
        E,
        R
    }

    public eInput Input;
    private bool IsActive = false;
    public float time = 0;

    public float PermissiveWindow = 0.2f;
    public float AnnimationStartingTime = 0.05f; //TODO only for proto, get sth cleaner

    // Start is called before the first frame update
    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
        Animator = GetComponent<Animator>();
    }

    public void Activate()
    {
        IsActive = true;
        AudioSource.Play();
        Animator.Play("Base Layer.Expand",0);
    }

    public void Update()
    {
        if (IsActive)
        {
            time += Time.deltaTime;

            //read input
            //Input.
        }
    }
}
