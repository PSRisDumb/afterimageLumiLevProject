using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    [Header("GameState Manager")]
    public GameObject tempPhaseOneParentObject;
    public GameObject tempPhaseTwoParentObject;
    public GameObject tempPhaseThreeParentObject;

    public EnemyManager enemyManager;
    public PhonePuzzleManager phonePuzzleManager;
    public sanityManager sanityManager;

    public int currStateInt = 1;

    public GameObject ExitDoor;
    public GameObject ExitLight;

    // STATE MANAGER STUFF -----------------------
    public void ProgressState()
    {
        currStateInt++;
        //1 is tutorial
        switch (currStateInt)
        {
            case 2:
                Destroy(tempPhaseOneParentObject);
                enemyManager.activateH = true;
                enemyManager.activateF = true;
                enemyManager.activateP = true;
                sanityManager.sanityOn = true;
                tempPhaseTwoParentObject.SetActive(true);
                //+ Enable HeartBeatMonitor
                break;
            case 3:
                Destroy(tempPhaseTwoParentObject);
                phonePuzzleManager.enabled = true;
                tempPhaseThreeParentObject.SetActive(true);
                break;
            case 4:
                Destroy(tempPhaseThreeParentObject);
                Destroy(ExitDoor);
                ExitLight.SetActive(true);
                break;
            //State 5&6 r in different scenes so no need to do that now
            default:
                break;
        }
    }
    /* Game State Manager
     * 1. Tutorial
     * 2. Player reaches safe room and comes out - Fence is deleted, Jerry sign appears pointing towards the Heart beat moniter room
     * 3. Monitor Completed, Phone puzzle enables
     * 4. Player completes phone puzzle and exits building
     * 5. Final Boss Fight
     * 6. Ending.
     */
}
