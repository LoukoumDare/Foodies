using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beat : MonoBehaviour
{
    private GameFlowState GameFlowState;
    private AudioSource AudioSource;
    private Animator Animator;
    public enum eInput
    {
        NONE,
        BEAT1,
        BEAT2,
        BEAT3,
        BEAT4
    }

    //TODO Dirty
    public string[] InputString = new string[] {"?", "A", "Z", "E", "R" };

    public eInput AssociatedInput = eInput.NONE;
    private TextMesh TextInput;
    private bool IsActive = false;
    public float time = 0;

    public float PermissiveWindow = 0.4f;
    public float AnnimationStartingTime = 0.05f; //TODO only for proto, get sth cleaner

    void Awake()
    {
        AudioSource = GetComponent<AudioSource>();
        Animator = GetComponent<Animator>();
        TextInput = GetComponentInChildren<TextMesh>();
    }

    // Start is called before the first frame updatea
    void Start()
    {
        GameFlowState = GameObject.Find("GameFlow").GetComponent<GameFlowState>();
    }

    public void Activate()
    {
        IsActive = true;
        time = 0;

        AudioSource.Play();
        Animator.Play("Base Layer.Expand", 0);
    }

    public void Update()
    {
        if (IsActive)
        {
            time += Time.deltaTime;

            if (time > PermissiveWindow)
            {
                IsActive = false;
            }
        }
    }


    void OnBeat(eInput input)
    {
        if (GameFlowState.currentGameState == GameFlowState.eGameState.PHASE1)
        {
            if (IsActive)
            {
                AssociatedInput = input;
                TextInput.text = InputString[(int)input];
            }
        }
        else if (GameFlowState.currentGameState == GameFlowState.eGameState.PHASE2)
        {
            if (IsActive)
            {
                if (AssociatedInput == input)
                {
                    Debug.Log($"Good {input}");
                }
                else
                {
                    Debug.Log($"Bad {input}");
                }
            }
        }
    }
    void OnBeat1()
    {
        OnBeat(eInput.BEAT1);
    }
    void OnBeat2()
    {
        OnBeat(eInput.BEAT2);
    }
    void OnBeat3()
    {
        OnBeat(eInput.BEAT3);
    }
    void OnBeat4()
    {
        OnBeat(eInput.BEAT4);
    }
}
