using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerGoalScript : MonoBehaviour
{
    public GMScript GMS;
    public GameStateManager State;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SoccerBall"))
        {
            Instantiate(GMS.picPiece2, new Vector3(-26f, 19f, 136f), Quaternion.identity);
        }
        State.ProgressState();
    }
}
