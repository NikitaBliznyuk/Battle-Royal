using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingState : BaseState
{
    public override Vector3 ProcessMotion(Vector3 input)
    {
        ApplySpeed(ref input, motor.Speed);

        return input;
    }

    public override Quaternion ProcessRotation(Vector3 input)
    {
        return Quaternion.FromToRotation(Vector3.forward, input);
    }

    public override void Construct()
    {
        base.Construct();

        motor.VerticalVelocity = 0.0f;
    }

    public override void Transition()
    {
        if (!motor.Grounded())
            motor.ChangeState("FallingState");

        if (Input.GetButton("Jump"))
            motor.ChangeState("JumpingState");
    }
}
