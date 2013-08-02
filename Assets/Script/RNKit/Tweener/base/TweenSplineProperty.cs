// Copyright (c) 2012 Xilin Chen (RN)
// Please direct any bugs/comments/suggestions to http://rntween.blogspot.com/

using UnityEngine;
using System.Collections;
using System.Reflection;
using System.Collections.Generic;

public class TweenSplineProperty : TweenProperty
{
    public object _target;
    public PropertyInfo _property;
    List<Transform> _path;

    //
    public TweenSplineProperty(object target_, string property)
    {
        _target = target_;
        Property(property);
    }

    protected void Property(string property)
    {
        _property = _target.GetType().GetProperty(property, BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
        if (_property == null)
            Debug.LogError("can not find the property, property=" + property, _target as Object);
    }

    //
    public TweenSplineProperty Equation(Equations.Function e)
    {
        _equation = e;
        return this;
    }

    public TweenSplineProperty Path(List<Transform> path)
    {
        _path = path;
        setStartValueToTarget();
        return this;
    }

    //
    public Vector3 from
    {
        get { return _path[1].position; }
    }
    public Vector3 to
    {
        get { return _path[_path.Count - 2].position; }
    }
    public override float getTime(float velocity)
    {
        return (pathLength(_path)) / velocity;
    }
    public override void onLerp(float t)
    {
        var p = calculateCRSpline(_path, t);
        setValueToTarget(p);
    }

    //
    public override void setStartValueToTarget()
    {
        _property.SetValue(_target, from, null);
    }
    public override void setDestValueToTarget()
    {
        _property.SetValue(_target, to, null);
    }
    protected void setValueToTarget(Vector3 v)
    {
        _property.SetValue(_target, v, null);
    }

    //
    public static Vector3 calculateCRSpline(List<Transform> path, float t)
    {
        int numSections = path.Count - 3;
        int currPt = Mathf.Min(Mathf.FloorToInt(t * (float)numSections), numSections - 1);
        float u = t * (float)numSections - (float)currPt;

        Vector3 a = path[currPt].position;
        Vector3 b = path[currPt + 1].position;
        Vector3 c = path[currPt + 2].position;
        Vector3 d = path[currPt + 3].position;

        return calculateCRSpline(a, b, c, d, t, u);
    }

    public static Vector3 calculateCRSpline(Vector3[] path, float t)
    {
        int numSections = path.Length - 3;
        int currPt = Mathf.Min(Mathf.FloorToInt(t * (float)numSections), numSections - 1);
        float u = t * (float)numSections - (float)currPt;

        Vector3 a = path[currPt];
        Vector3 b = path[currPt + 1];
        Vector3 c = path[currPt + 2];
        Vector3 d = path[currPt + 3];

        return calculateCRSpline(a, b, c, d, t, u);
    }

    public static float pathLength(List<Transform> path)
    {
        float pathLength = 0;
        Vector3 prevPt = calculateCRSpline(path, 0);
        int SmoothAmount = path.Count * 20;
        for (int i = 1; i <= SmoothAmount; i++)
        {
            float pm = (float)i / SmoothAmount;
            Vector3 currPt = calculateCRSpline(path, pm);
            pathLength += Vector3.Distance(prevPt, currPt);
            prevPt = currPt;
        }

        return pathLength;
    }



    public static Vector3 calculateCRSpline(Vector3 a, Vector3 b, Vector3 c, Vector3 d, float t, float u)
    {
        return .5f *
            (
                (-a + 3f * b - 3f * c + d) * (u * u * u)
                + (2f * a - 5f * b + 4f * c - d) * (u * u)
                + (-a + c) * u
                + 2f * b
            );
    }
    /*
        Vector3 calculateBezierSpline(float t, Vector3 p0, Vector3 p1 ,Vector3 p2 , Vector3 p3)
        {
            var u : float = 1.0f - t;
            var tt : float = t * t;
            var uu : float = u * u;
            var uuu : float = uu * u;
            var ttt : float = tt * t;
 
            var p : Vector3 = uuu * p0; //first term
            p += 3 * uu * t * p1; //second term
            p += 3 * u * tt * p2; //third term
            p += ttt * p3; //fourth term

            return p;
        }
    */



}
