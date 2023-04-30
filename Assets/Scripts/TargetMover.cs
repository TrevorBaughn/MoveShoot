using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MovingTarget))]
public class TargetMover : Mover
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    public void MoveForward(float speed)
    {
        //move position of rigidbody rank forward at speed
        rigidbodyComponent.MovePosition(rigidbodyComponent.transform.position += (rigidbodyComponent.transform.right * (speed * Time.deltaTime)));
    }
}
