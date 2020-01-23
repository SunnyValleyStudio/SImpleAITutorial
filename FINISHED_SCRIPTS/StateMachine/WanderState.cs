using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WanderState : State
{
    public float angleModifier = 1;
    public bool isWandering = false;
    public float wanderingSpeed = 0.5f;
    public float rotationSpeed = 0.01f;
    private float movementSpeed = 0;
    Vector3? direction = null;

    public override void Update()
    {
        base.Update();
        if (isWandering)
        {
            if (direction.HasValue)
            {
                movementController.Move(direction.Value.normalized * movementSpeed);
            }
            return;
        }
        isWandering = true;
        StartCoroutine(WanderAround());
    }

    IEnumerator WanderAround()
    {
        Vector3 rotationDirection = RotateAgent();
        direction = rotationDirection;
        movementSpeed = wanderingSpeed;
        yield return new WaitForSeconds(2);
        StartCoroutine(LookAround());
    }

    private Vector3 RotateAgent()
    {
        float wanderOrientation = Random.Range(-30f, 30f) * angleModifier;
        var newRotation = Quaternion.AngleAxis(wanderOrientation, Vector3.up);
        var rotationDirection = newRotation * Vector3.forward;
        movementController.Rotate(rotationDirection);
        return rotationDirection;
    }

    IEnumerator LookAround()
    {
        direction = null;
        movementController.Move(Vector3.zero);
        Vector3 rotationDirection = RotateAgent();
        movementSpeed = rotationSpeed;
        direction = rotationDirection;
        yield return new WaitForSeconds(3);
        isWandering = false;
    }
}
