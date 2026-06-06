using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraFollowCursor : MonoBehaviour
{
    public float speed;
    public Camera cam;
    public float minX, maxX, minY, maxY;
    // Start is called before the first frame update
    void Start()
    {
        cam = gameObject.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = cam.nearClipPlane;

        Vector3 Target = cam.ScreenToWorldPoint(mousePos);
        Vector3 direction = Target - transform.position;
        Quaternion targetRot = Quaternion.LookRotation(direction, Vector3.up);

        Vector3 euler = targetRot.eulerAngles;

        float pitch = Normalize(euler.x);
        float yaw = Normalize(euler.y);

        float NewX = Mathf.Clamp(pitch,minX,maxX);
        float NewY = Mathf.Clamp(yaw,minY,maxY);
         
        targetRot = Quaternion.Euler(NewX, NewY,0);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, speed * Time.deltaTime);

    } 

    private float Normalize(float angle)
    {
        angle %= 360;
        if (angle > 180f)
            angle -= 360;
        if (angle < -180f)
            angle += 360;
        return angle;
    }
    public void startGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {

    }
    public GameObject settingsPanel;
    public void SettingsButton()
    {
        settingsPanel.SetActive(true);
    }
    public void SettingsLeave()
    {
        settingsPanel.SetActive(false);
    }
}
