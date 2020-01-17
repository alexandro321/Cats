using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore.Examples.HelloAR;
using System;

public class Run : MonoBehaviour
{
    public HelloARController helloARController;
    public float speed = 1;
    public float timeOver;
    public float time = 0;
    public bool hasInter = false;
    private Vector3 lastPoint;
    private Vector3 lastPosition;
    // Start is called before the first frame update
    void Start()
    {
        GameObject controller = GameObject.Find("Example Controller");
        helloARController = controller.GetComponent<HelloARController>();
        UpdateDirection();
    }

    // Update is called once per frame
    void Update()
    {
        if (hasInter)
        {
            transform.position += speed * Time.deltaTime * transform.forward;
            time += Time.deltaTime;
        }
        if (!hasInter || time >= timeOver)
        {
            hasInter = false;
            UpdateDirection();
            time = 0;
        }
    }

    private void UpdateDirection()
    {
        Vector3 point;
        if (GetIntersection(out point))
        {
            point = Vector3.Lerp(transform.position, point, UnityEngine.Random.RandomRange(0.7f, 0.8f));
            timeOver = 0.9f * Vector3.Distance(point, transform.position) / speed;
            Debug.DrawLine(point, transform.position, Color.green, timeOver);
            time = 0;
            if (timeOver >= 0.1f)
            {
                //Debug.Log("Traval time " + timeOver.ToString());
                hasInter = true;
                transform.LookAt(point, Vector3.up);
            }
        }
    }

    private bool GetIntersection(out Vector3 point)
    {
        List<Vector3> boundaryPolygonPoints = new List<Vector3>();
        helloARController.detectedPlane.GetBoundaryPolygon(boundaryPolygonPoints);
        int index = (int)((UnityEngine.Random.value - 0.001f) * boundaryPolygonPoints.Count);
        Vector3 start = boundaryPolygonPoints[index];
        Vector3 end = boundaryPolygonPoints[(index + 1) % boundaryPolygonPoints.Count];
        point = Vector3.Lerp(start, end, UnityEngine.Random.value);
        return true;
    }
    //{
    //    List<Vector3> boundaryPolygonPoints = new List<Vector3>();
    //    helloARController.detectedPlane.GetBoundaryPolygon(boundaryPolygonPoints);
    //    Vector3 CenterPolygon = helloARController.detectedPlane.CenterPose.position;
    //    for (int i = 0; i < boundaryPolygonPoints.Count; i++)
    //    {
    //        Vector3 A = boundaryPolygonPoints[i];
    //        Vector3 B = boundaryPolygonPoints[(i + 1) % boundaryPolygonPoints.Count];
    //        Vector3 C = HelloARController.cat.transform.position;
    //        Vector3 D = HelloARController.cat.transform.position + forward;

    //        Vector3 IX = Intersection(A, B, C, D);

    //        //Debug.Log(Mathf.Abs((B - A).magnitude - (Vector3.Distance(A, IX) + Vector3.Distance(B, IX)) / 2));

    //        if (Mathf.Abs((B - A).magnitude - (Vector3.Distance(A, IX) + Vector3.Distance(B, IX)) / 2) < 0.17f)
    //        {

    //            // принадлежит отрезку AB
    //            Debug.Log("Intersection " + IX.ToString());
    //            point = IX;
    //            return true;
    //        }
    //    }
    //    point = Vector3.zero;
    //    return false;
    //}

    private static Vector3 Intersection(Vector3 a, Vector3 b, Vector3 c, Vector3 d)
    {
        bool xi = a.x == b.x && b.x == c.x;
        bool yi = a.y == b.y && b.y == c.y;
        bool zi = a.z == b.z && b.z == c.z;

        double xo = a.x, yo = a.y, zo = a.z;
        double p = b.x - a.x, q = b.y - a.y, r = b.z - a.z;

        double x1 = c.x, y1 = c.y, z1 = c.z;
        double p1 = xi ? 1 : d.x - c.x, q1 = yi ? 1 : d.y - c.y, r1 = zi ? 1 : d.z - c.z;

        double x = (xo * q * p1 - x1 * q1 * p - yo * p * p1 + y1 * p * p1) / (q * p1 - q1 * p);
        double y = (yo * p * q1 - y1 * p1 * q - xo * q * q1 + x1 * q * q1) / (p * q1 - p1 * q);
        double z = (zo * q * r1 - z1 * q1 * r - yo * r * r1 + y1 * r * r1) / (q * r1 - q1 * r);

        return new Vector3((float)x, (float)y, (float)z);
    }
}
