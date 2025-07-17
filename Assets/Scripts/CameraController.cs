using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform followTarget;
    [SerializeField] private float distance = 5f;
    [SerializeField] private float rotationSpeed = 2f;

    [SerializeField] private float minVerticalAngle = -45f;
    [SerializeField] private float maxVerticalAngle = 45f;

    [SerializeField] private Vector2 framingOffset;

    [SerializeField] private bool invertX;
    [SerializeField] private bool invertY;

    private float rotationX;
    private float rotationY;

    float invertXVal;
    float invertYVal;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        invertXVal = (invertX) ? -1 : 1;
        invertYVal = (invertY) ? -1 : 1;

        rotationX += Input.GetAxis("Mouse Y") * invertXVal * rotationSpeed;
        rotationX = Mathf.Clamp(rotationX, minVerticalAngle, maxVerticalAngle);
        rotationY += Input.GetAxis("Mouse X") * invertYVal * rotationSpeed;

        var targetRotation = Quaternion.Euler(rotationX, rotationY, 0f);
        var focusPosition = followTarget.position + new Vector3(framingOffset.x, framingOffset.y);

        transform.position = focusPosition - targetRotation * new Vector3(0f, 0f, distance);
        transform.rotation = targetRotation;
    }
}