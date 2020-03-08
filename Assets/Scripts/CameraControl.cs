using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject Player;
    Vector3 rotation = new Vector3(0, 0, 0);
    public float cameraRotSpeed;
    Vector3 TempV3 = new Vector3();



    void Update()
    {   
        rotation.y += Input.GetAxis("Mouse X");
        rotation.z += Input.GetAxis("Mouse Y");
        transform.eulerAngles = rotation * cameraRotSpeed;
            if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
            {
                if (Input.GetAxis("Vertical") >= Mathf.Abs(Input.GetAxis("Horizontal")))
                    TempV3 = new Vector3(0, transform.eulerAngles.y + 45 * Input.GetAxis("Horizontal"), 0);
                else if (Input.GetAxis("Horizontal") > 0)
                    TempV3 = new Vector3(0, transform.eulerAngles.y + 90 - 45 * Input.GetAxis("Vertical"), 0);
                else
                    TempV3 = new Vector3(0, transform.eulerAngles.y - 90 + 45 * Input.GetAxis("Vertical"), 0);
                Player.transform.eulerAngles = TempV3;
            }
            else if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W))
            {
                if (-Input.GetAxis("Vertical") >= Mathf.Abs(Input.GetAxis("Horizontal")))
                    TempV3 = new Vector3(0, transform.eulerAngles.y + 180 - 45 * Input.GetAxis("Horizontal"), 0);
                else if (Input.GetAxis("Horizontal") > 0)
                    TempV3 = new Vector3(0, transform.eulerAngles.y + 90 - 45 * Input.GetAxis("Vertical"), 0);
                else
                    TempV3 = new Vector3(0, transform.eulerAngles.y - 90 + 45 * Input.GetAxis("Vertical"), 0);
                Player.transform.eulerAngles = TempV3;
            }
            else if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
            {
                TempV3 = new Vector3(0, transform.eulerAngles.y + 90 - 45 * Input.GetAxis("Vertical"), 0);
                Player.transform.eulerAngles = TempV3;
            }
            else if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            {
                TempV3 = new Vector3(0, transform.eulerAngles.y - 90 + 45 * Input.GetAxis("Vertical"), 0);
                Player.transform.eulerAngles = TempV3;
            }
        }
        
    
}
