using UnityEngine;

public class followCam : MonoBehaviour
{
    [SerializeField] private Transform player;
    public float sensetivity = 1f;
    private float xRotation = 0;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensetivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensetivity;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -75f, 75f);
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        player.Rotate(Vector3.up * mouseX);
    }

}
