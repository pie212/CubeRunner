using System;
using System.Collections.Generic;
using UnityEngine;

public class PathFollower : MonoBehaviour
{
    public TransformArray[] controlPoints;
    public float speed = 1;
    public float inputMultiplier = 3;
    
    private Rigidbody rb;
    private Vector3 startPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = controlPoints[0].transforms[0].position;
    }

    private void Update()
    {
        var rightVelocity = transform.right * (Input.GetAxisRaw("Horizontal") * inputMultiplier);
        var forwardVelocity = transform.forward * (Input.GetAxisRaw("Vertical") * inputMultiplier);
        
        var closestPoint = FindClosestPointOnPath(transform.position);
        transform.rotation = GetRotationOnBezierCurve(closestPoint);

        rb.velocity = rightVelocity + forwardVelocity;
    }
    
    private Vector3 FindClosestPositionOnPath(Vector3 targetPosition)
    {
        float minDistance = float.MaxValue;
        Vector3 closestPoint = Vector3.zero;

        for (float t = 0; t <= controlPoints.Length; t += 0.01f)
        {
            Vector3 pointOnPath = GetPointOnBezierCurve(t);
            float distance = Vector3.Distance(targetPosition, pointOnPath);

            if (distance < minDistance)
            {
                minDistance = distance;
                closestPoint = pointOnPath;
            }
        }

        return closestPoint;
    }
    
    private float FindClosestPointOnPath(Vector3 targetPosition)
    {
        float minDistance = float.MaxValue;
        float closestT = 0;

        for (float t = 0; t <= controlPoints.Length; t += 0.01f)
        {
            Vector3 pointOnPath = GetPointOnBezierCurve(t);
            float distance = Vector3.Distance(targetPosition, pointOnPath);

            if (distance < minDistance)
            {
                minDistance = distance;
                closestT = t;
            }
        }

        return closestT;
    }
    
    private Quaternion GetRotationOnBezierCurve(float time)
    {
        float epsilon = 0.01f;
        Vector3 currentPos = GetPointOnBezierCurve(time);
        Vector3 nextPos = GetPointOnBezierCurve(time + epsilon);
        Vector3 tangent = (nextPos - currentPos).normalized;

        return Quaternion.LookRotation(tangent);
    }

    private Vector3 CalculateVelocity(float time, Action onFinished)
    {
        float epsilon = 0.01f;
        Vector3 currentPos = GetPointOnBezierCurve(time, 0.05f, onFinished);
        Vector3 nextPos = GetPointOnBezierCurve(time + epsilon);
        Vector3 derivative = (nextPos - currentPos) / epsilon;

        return transform.forward * (speed * derivative.magnitude);
    }

    // 0 <= time <= controlPoints.Length
    private Vector3 GetPointOnBezierCurve(float time, float endEpsilon = 0.1f, Action onFinished = null)
    {
        time %= controlPoints.Length;

        var index = (int)Mathf.Floor(time);

        var lastPoints = index > 0 ? controlPoints[index - 1].transforms : null;

        var bezierPoints = new List<Transform>();

        var endPoint = lastPoints?[^1];
        
        if(endPoint is not null) bezierPoints.Add(endPoint);

        bezierPoints.AddRange(controlPoints[index].transforms);

        var t = time % 1;
        
        int degree = bezierPoints.Count - 1;

        Vector3 result = Vector3.zero;

        for (int i = 0; i <= degree; i++)
        {
            float coefficient = BinomialCoefficient(degree, i) * Mathf.Pow((1 - t), degree - i) * Mathf.Pow(t, i);
            result += coefficient * bezierPoints[i].position;
        }
        
        if (onFinished != null && time >= controlPoints.Length - endEpsilon)
        {
            onFinished.Invoke();
            return startPosition;
        }

        return result;
    }
    
    private int BinomialCoefficient(int n, int k)
    {
        if (k == 0 || k == n)
            return 1;

        return BinomialCoefficient(n - 1, k - 1) + BinomialCoefficient(n - 1, k);
    }
}

[Serializable]
public class TransformArray
{
    public Transform[] transforms;
}