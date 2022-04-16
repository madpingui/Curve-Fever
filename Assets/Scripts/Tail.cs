using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(EdgeCollider2D))]
public class Tail : MonoBehaviour
{
    public float pointSpacing = 0.1f;
    public Transform snake;

    List<Vector2> points;

    LineRenderer line;
    EdgeCollider2D col;

    void Start()
    {
        line = GetComponent<LineRenderer>();
        col = GetComponent<EdgeCollider2D>();

        points = new List<Vector2>();

        SetPoint();
    }

    void Update()
    {
        if(Vector3.Distance(points.Last(), snake.position) > pointSpacing)
        SetPoint();
    }

    void SetPoint()
    {
        if (points.Count > 1)
            col.points = points.ToArray<Vector2>();

        points.Add(snake.position);

        line.positionCount = points.Count;
        line.SetPosition(points.Count - 1, snake.position);
    }
}
