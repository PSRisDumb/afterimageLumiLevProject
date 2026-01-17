using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handsScript : MonoBehaviour
{
    public float speed;
    public RectTransform rectTransform;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {

        rectTransform.anchoredPosition += Vector2.left * speed * Time.deltaTime;
    }
}
