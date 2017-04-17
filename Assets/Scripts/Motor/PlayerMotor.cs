﻿using UnityEngine;

public class PlayerMotor : BaseMotor
{
    protected override void UpdateMotor()
    {
        // Gets the input
        MoveVector = InputDirection();

        // Send input to a filter
        MoveVector = state.ProcessMotion(MoveVector);

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