using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMovement : MonoBehaviour   // xử lý di chuyển
{
    [SerializeField] float moveSpeed = 3f;
    private Vector3 _targetPos;
    private bool isMoving = false;
    
    public void MoveTo(Vector3 pos)
    {
        _targetPos = pos;
        isMoving = true;
    }

    private void Update()
    {
        if (!isMoving) return;

        transform.position = Vector3.MoveTowards(transform.position, _targetPos, moveSpeed * Time.deltaTime);

        float distance = Vector3.Distance(transform.position, _targetPos);

        if (distance < 0.05f)
        {
            isMoving = false;
        }
    }
}
