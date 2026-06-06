using System.Collections;
using UnityEngine;

public class puzzlePieceScript : MonoBehaviour
{
    public int pieceId;

    public BoxCollider BC;

    public GMScript GMS;

    // Start is called before the first frame update
    void Start()
    {
        BC = GetComponent<BoxCollider>();
        GMS = GameObject.Find("gameManager").GetComponent<GMScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            GMS.updatePuzzle(pieceId);
            if (pieceId == 1)
                GMS.door.SetActive(false);
            Destroy(gameObject);
        }
    }
}
