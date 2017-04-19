using UnityEngine;

public class ThirdPersonCamera : BaseCameraState
{
    private const float Y_ANGLE_MIN = -75.0f;
    private const float Y_ANGLE_MAX = 50.0f;

    private Transform lookAt;
    private Transform cameraContainer;

    private Vector3 offset = Vector3.up;
    private float distance = 5.0f;
    private float currentX = 0.0f;
    private float currentY = 0.0f;
    private float sensivityX = 7.0f;
    private float sensivityY = 4.0f;

    public override void Construct()
    {
        base.Construct();

        lookAt = transform;
        cameraContainer = motor.CameraContainer;
    }

    public override Vector3 ProcessMotion(Vector3 input)
    {
        currentX += input.x * sensivityX;
        currentY += input.z * sensivityY;

        // Clamp my current Y
        currentY = ClampAngle(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);

        return CalculatePosition();
    }

    public override Quaternion ProcessRotation(Vector3 input)
    {
        cameraContainer.LookAt(lookAt.position + offset);
        return cameraContainer.rotation;
    }

    private Vector3 CalculatePosition()
    {
        Vector3 direction = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);

        direction = lookAt.position + offset + rotation * direction;

        RaycastHit hit;
        if(Physics.Linecast(lookAt.position, direction - offset, out hit))
        {
            if(hit.collider.CompareTag("Terrain"))
            {
                direction = hit.point + hit.normal * 0.2f;
            }
        }

        direction = Vector3.Lerp(cameraContainer.position, direction, Time.deltaTime * 10);

        return direction;
    }
}
