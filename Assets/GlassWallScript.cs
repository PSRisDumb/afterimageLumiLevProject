using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassWallScript : MonoBehaviour
{
    public CameraMoveAround playerCameraMoveAroundScript;
    public AudioClip GlassShattering;
    private void Start()
    {
        playerCameraMoveAroundScript = GameObject.Find("Player").GetComponent<CameraMoveAround>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("bottleCap"))
        {
            if (!playerCameraMoveAroundScript.HoldingObjectBool)
            {
                playerCameraMoveAroundScript.SFXAudioSource.PlayOneShot(GlassShattering);
                Destroy(gameObject);
            }
        }
    }
}
