using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseMotor : MonoBehaviour
{
    protected CharacterController controller;
    protected Transform thisTransform;
    protected BaseState state;

    private float baseSpeed = 5.0f;
    private float baseGravity = 25.0f;

    public float Speed { get { return baseSpeed; } }
    public float Gravity { get { return baseGravity; } }
    public Vector3 MoveVector { set; get; }

    protected abstract void UpdateMotor();

    protected virtual void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
        thisTransform = transform;

        state = gameObject.AddComponent<WalkingState>();
        state.Construct();
    }

    private void Update()
    {
        UpdateMotor();
    }

    protected virtual void Move()
    {
        controller.Move(MoveVector * Time.deltaTime);
    }
}
