using UnityEngine;

public class CameraFollow : MonoBehaviour

{

    public Transform target; // The object the camera will follow

    public Vector3 offset = new Vector3(0, 5, -10); // Initial offset position

    public float rotationSpeed = 6f; // Camera rotation speed when dragging with the mouse

    public float verticalSpeed = 2f; // Vertical movement speed (up/down)

    public Camera mainCamera; // Main camera that follows the target

    public Camera secondaryCamera; // Secondary camera that you can switch to

    private void Start()

    {

        // Ensure only the main camera is active at the start

        mainCamera.gameObject.SetActive(true);

        secondaryCamera.gameObject.SetActive(false);

    }

    private void Update()

    {

        // Check for camera switch inputs

        if (Input.GetKeyDown(KeyCode.Alpha1))

        {

            SwitchCamera(mainCamera);

        }

        if (Input.GetKeyDown(KeyCode.Alpha2))

        {

            SwitchCamera(secondaryCamera);

        }

        // If the main camera is active, move it and follow the target

        if (mainCamera.gameObject.activeInHierarchy)

        {

            HandleCameraMovement();

        }

    }

    // Method to switch between cameras

    private void SwitchCamera(Camera cameraToActivate)

    {

        // Disable both cameras first

        mainCamera.gameObject.SetActive(false);

        secondaryCamera.gameObject.SetActive(false);

        // Activate the selected camera

        cameraToActivate.gameObject.SetActive(true);

    }

    // Handle camera movement when the main camera is active

    private void HandleCameraMovement()

    {

        // Check if the right mouse button (RMB) is held down

        if (Input.GetMouseButton(1)) // Right mouse button to rotate and move vertically

        {

            // Camera rotation based on mouse X movement (left/right)

            float horizontal = Input.GetAxis("Mouse X");

            offset = Quaternion.Euler(0, horizontal * rotationSpeed, 0) * offset;

            // Vertical movement based on mouse Y movement (up/down)

            float verticalMovement = Input.GetAxis("Mouse Y");

            offset.y -= verticalMovement * verticalSpeed;

        }

        // Set the camera's position to the target position plus the offset

        transform.position = target.position + offset;

        // Ensure the camera always looks at the target

        transform.LookAt(target);

    }

}

