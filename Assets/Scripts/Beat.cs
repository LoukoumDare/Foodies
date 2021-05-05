using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beat : MonoBehaviour
{
    private AudioSource AudioSource;
    private Animator Animator;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
        Animator = GetComponent<Animator>();
    }

    public void Activate()
    {
        AudioSource.Play();
        Animator.Play("Base Layer.Expand",0);
    }
}
