using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlowState : MonoBehaviour
{

    public enum eGameState
    {
        PHASE1,
        PHASE2
    }

    public eGameState currentGameState;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnDebugMoveToPhase1()
    {
        Debug.Log("Phase1");
        currentGameState = eGameState.PHASE1;
    }

    void OnDebugMoveToPhase2()
    {
        Debug.Log("Phase2");
        currentGameState = eGameState.PHASE2;
    }
}
