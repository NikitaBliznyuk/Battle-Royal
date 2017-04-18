using UnityEngine;

public class PlayerMotor : BaseMotor
{
    private CameraMotor cameraMotor;

    protected override void Start()
    {
        base.Start();

        cameraMotor = gameObject.AddComponent<CameraMotor>();
        cameraMotor.Init();
    }

    protected override void UpdateMotor()
    {
        // Gets the input
        MoveVector = InputDirection();

        // Send input to a filter
        MoveVector = state.ProcessMotion(MoveVector);

        // Check if we need to change current state
        state.Transition();

        // Move
        Move();
    }

    private Vector3 InputDirection()
    {
        Vector3 direction = Vector3.zero;

        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");

        direction = direction.magnitude > 1 ? direction.normalized : direction;

        return direction;
    }
}
