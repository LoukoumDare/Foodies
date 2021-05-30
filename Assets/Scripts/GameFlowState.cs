using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameFlowState : MonoBehaviour
{
    PlayerInput PlayerInput;
    TextMesh TextPhase;

    public enum eGameState
    {
        PHASE1,
        PHASE2
    }

    public eGameState currentGameState { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        PlayerInput = GameObject.Find("MainObject").GetComponent<PlayerInput>();
        TextPhase = GameObject.Find("TextPhase").GetComponent<TextMesh>();
        SwitchToPhase1();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnDebugMoveToPhase1()
    {
        SwitchToPhase1();
    }

    void OnDebugMoveToPhase2()
    {
        SwitchToPhase2();
    }

    public void SwitchToPhase1()
    {
        Debug.Log("Phase1");
        currentGameState = eGameState.PHASE1;
        PlayerInput.SwitchCurrentActionMap("Phase1");
        TextPhase.text = "Phase1";
    }

    public void SwitchToPhase2()
    {
        Debug.Log("Phase2");
        currentGameState = eGameState.PHASE2;
        PlayerInput.SwitchCurrentActionMap("Phase2");
        TextPhase.text = "Phase2";
    }
}
