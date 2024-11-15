using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [Header("Camera Movements and Limits")]
    public float mouseSensibility;
    public float limitVisionUp;
    public float limitVisionDown;

    public Transform camera;
    float rotationX;
    public UIControl UIcontrol;

    void Start()
    {
        
    }

    void Update()
    {
        if(UIcontrol.paused)
            return;
            
        float rotationY;

        rotationY = Input.GetAxis("Mouse X") * mouseSensibility;
        transform.Rotate(0, rotationY, 0);

        rotationX -= Input.GetAxis("Mouse Y") * mouseSensibility;
        rotationX = Mathf.Clamp(rotationX, limitVisionDown, limitVisionUp);

        camera.localEulerAngles = new Vector3(rotationX, 0, 0);
    }
}
