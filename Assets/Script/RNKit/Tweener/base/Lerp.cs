// Copyright (c) 2012 Xilin Chen (RN)
// Please direct any bugs/comments/suggestions to http://rntween.blogspot.com/

using UnityEngine;
using System.Collections;

/// <summary>
/// Lerp each type data.
/// </summary>
public static class Lerp
{
    public static float Float(float v1, float v2, float t)
    {
        return v1 + (v2 - v1) * t;
    }

    public static double Double(double v1, double v2, float t)
    {
        return v1 + (v2 - v1) * t;
    }

    public static Vector2 Vector2(Vector2 v1, Vector2 v2, float t)
    {
        var x = v1.x + (v2.x - v1.x) * t;
        var y = v1.y + (v2.y - v1.y) * t;
        return new Vector2(x, y);
    }

    public static Vector3 Vector3(Vector3 v1, Vector3 v2, float t)
    {
        var x = v1.x + (v2.x - v1.x) * t;
        var y = v1.y + (v2.y - v1.y) * t;
        var z = v1.z + (v2.z - v1.z) * t;
        return new Vector3(x, y, z);
    }

    public static Vector4 Vector4(Vector4 v1, Vector4 v2, float t)
    {
        var x = v1.x + (v2.x - v1.x) * t;
        var y = v1.y + (v2.y - v1.y) * t;
        var z = v1.z + (v2.z - v1.z) * t;
        var w = v1.w + (v2.w - v1.w) * t;
        return new Vector4(x, y, z, w);
    }

    public static Color Color(Color v1, Color v2, float t)
    {
        var r = v1.r + (v2.r - v1.r) * t;
        var g = v1.g + (v2.g - v1.g) * t;
        var b = v1.b + (v2.b - v1.b) * t;
        var a = v1.a + (v2.a - v1.a) * t;
        return new Color(r, g, b, a);
    }

    public static Rect Rect(Rect v1, Rect v2, float t)
    {
        var x = v1.x + (v2.x - v1.x) * t;
        var y = v1.y + (v2.y - v1.y) * t;
        var width = v1.width + (v2.width - v1.width) * t;
        var height = v1.height + (v2.height - v1.height) * t;
        return new Rect(x, y, width, height);
    }
}
