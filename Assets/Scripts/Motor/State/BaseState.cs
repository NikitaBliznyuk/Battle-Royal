using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState : MonoBehaviour
{
    protected BaseMotor motor;

    #region baseState implementation

    public virtual void Construct()
    {
        motor = GetComponent<BaseMotor>();
    }

    public virtual void Destruct()
    {
        Destroy(this);
    }

    public virtual void Transition()
    {

    }

    #endregion

    public abstract Vector3 ProcessMotion(Vector3 input);

    public virtual Quaternion ProcessRotation(Vector3 input)
    {
        return transform.rotation;
    }
}
