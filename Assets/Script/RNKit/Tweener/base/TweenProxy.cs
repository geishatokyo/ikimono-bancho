// Copyright (c) 2012 Xilin Chen (RN)
// Please direct any bugs/comments/suggestions to http://rntween.blogspot.com/

using UnityEngine;
using System.Collections.Generic;



/// <summary>
/// set the object propertys.
/// </summary>
public class ObjectTweenProxy<TTween> where TTween : Tween
{
    //
    public TTween tween;
    object target;

    public ObjectTweenProxy(TTween t)
    {
        tween = t;
        target = tween.target;
    }
    public ObjectTweenProxy(TTween t, object e)
    {
        tween = t;
        target = e;
    }

    /// <summary>
    /// tween to the specified float.
    /// it will be start from the current value.
    /// </summary>
    /// <param name="property">The property name of object(Tween.target).</param>
    /// <param name="v">to value.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween to(string property, float v)
    {
        tween.addProperty(new TweenFloatProperty(target, property).To(v));
        return tween;
    }
    public TTween to(string property, System.Func<float> v)
    {
        tween.addProperty(new TweenDynamicFloatProperty2(target, property).From().DynamicTo(v));
        return tween;
    }
    public TTween toFloat(string property, object v)
    {
        tween.addProperty(new TweenDynamicFloatProperty(target, property).From().DynamicTo(v));
        return tween;
    }
    /// <summary>
    /// tween to the specified double.
    /// it will be start from the current value.
    /// </summary>
    /// <param name="property">The property name of object(Tween.target).</param>
    /// <param name="v">to value.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween to(string property, double v)
    {
        tween.addProperty(new TweenDoubleProperty(target, property).To(v));
        return tween;
    }
    public TTween to(string property, System.Func<double> v)
    {
        tween.addProperty(new TweenDynamicDoubleProperty2(target, property).From().DynamicTo(v));
        return tween;
    }
    public TTween toDouble(string property, object v)
    {
        tween.addProperty(new TweenDynamicFloatProperty(target, property).From().DynamicTo(v));
        return tween;
    }
    /// <summary>
    /// tween to the specified vector2.
    /// it will be start from the current value.
    /// </summary>
    /// <param name="property">The property name of object(Tween.target).</param>
    /// <param name="v">to value.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween to(string property, Vector2 v)
    {
        tween.addProperty(new TweenVector2Property(target, property).To(v));
        return tween;
    }
    public TTween to(string property, System.Func<Vector2> v)
    {
        tween.addProperty(new TweenDynamicVector2Property2(target, property).From().DynamicTo(v));
        return tween;
    }
    public TTween toVector2(string property, object v)
    {
        tween.addProperty(new TweenDynamicVector2Property(target, property).From().DynamicTo(v));
        return tween;
    }
    /// <summary>
    /// tween to the specified vector3.
    /// it will be start from the current value.
    /// </summary>
    /// <param name="property">The property name of object(Tween.target).</param>
    /// <param name="v">to value.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween to(string property, Vector3 v)
    {
        tween.addProperty(new TweenVector3Property(target, property).To(v));
        return tween;
    }
    public TTween to(string property, System.Func<Vector3> v)
    {
        tween.addProperty(new TweenDynamicVector3Property2(target, property).From().DynamicTo(v));
        return tween;
    }
    public TTween toVector3(string property, object v)
    {
        tween.addProperty(new TweenDynamicVector3Property(target, property).From().DynamicTo(v));
        return tween;
    }
    /// <summary>
    /// tween to the specified vector4.
    /// it will be start from the current value.
    /// </summary>
    /// <param name="property">The property name of object(Tween.target).</param>
    /// <param name="v">to value.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween to(string property, Vector4 v)
    {
        tween.addProperty(new TweenVector4Property(target, property).To(v));
        return tween;
    }
    public TTween to(string property, System.Func<Vector4> v)
    {
        tween.addProperty(new TweenDynamicVector4Property2(target, property).From().DynamicTo(v));
        return tween;
    }
    public TTween toVector4(string property, object v)
    {
        tween.addProperty(new TweenDynamicVector4Property(target, property).From().DynamicTo(v));
        return tween;
    }
    /// <summary>
    /// tween to the specified quaternion.
    /// it will be start from the current value.
    /// </summary>
    /// <param name="property">The property name of object(Tween.target).</param>
    /// <param name="v">to value.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween to(string property, Quaternion v)
    {
        tween.addProperty(new TweenQuaternionProperty(target, property).To(v));
        return tween;
    }
    public TTween to(string property, System.Func<Quaternion> v)
    {
        tween.addProperty(new TweenDynamicQuaternionProperty2(target, property).From().DynamicTo(v));
        return tween;
    }
    public TTween toQuaternion(string property, object v)
    {
        tween.addProperty(new TweenDynamicQuaternionProperty(target, property).From().DynamicTo(v));
        return tween;
    }
    /// <summary>
    /// tween to the specified rect.
    /// it will be start from the current value.
    /// </summary>
    /// <param name="property">The property name of object(Tween.target).</param>
    /// <param name="v">to value.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween to(string property, Rect v)
    {
        tween.addProperty(new TweenRectProperty(target, property).To(v));
        return tween;
    }
    public TTween to(string property, System.Func<Rect> v)
    {
        tween.addProperty(new TweenDynamicRectProperty2(target, property).From().DynamicTo(v));
        return tween;
    }
    public TTween toRect(string property, object v)
    {
        tween.addProperty(new TweenDynamicRectProperty(target, property).From().DynamicTo(v));
        return tween;
    }
    /// <summary>
    /// tween to the specified color.
    /// it will be start from the current value.
    /// </summary>
    /// <param name="property">The property name of object(Tween.target).</param>
    /// <param name="v">to value.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween to(string property, Color v)
    {
        tween.addProperty(new TweenColorProperty(target, property).To(v));
        return tween;
    }
    public TTween to(string property, System.Func<Color> v)
    {
        tween.addProperty(new TweenDynamicColorProperty2(target, property).From().DynamicTo(v));
        return tween;
    }
    public TTween toColor(string property, object v)
    {
        tween.addProperty(new TweenDynamicColorProperty(target, property).From().DynamicTo(v));
        return tween;
    }
    /// <summary>
    /// tween to the specified vector3.
    /// it will be start from the current value.
    /// lerp by Vector3.Slerp
    /// </summary>
    /// <param name="property">The property name of object(Tween.target).</param>
    /// <param name="v">to value.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween to_bySlerp(string property, Vector3 v)
    {
        tween.addProperty(new TweenVector3SlerpProperty(target, property).To(v));
        return tween;
    }
    public TTween to_bySlerp(string property, System.Func<Vector3> v)
    {
        tween.addProperty(new TweenDynamicVector3SlerpProperty2(target, property).From().DynamicTo(v));
        return tween;
    }
    public TTween toVector3_bySlerp(string property, object v)
    {
        tween.addProperty(new TweenDynamicVector3SlerpProperty(target, property).From().DynamicTo(v));
        return tween;
    }
    /// <summary>
    /// tween to the specified quaternion.
    /// it will be start from the current value.
    /// lerp by Vector3.Slerp
    /// </summary>
    /// <param name="property">The property name of object(Tween.target).</param>
    /// <param name="v">to value.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween to_bySlerp(string property, Quaternion v)
    {
        tween.addProperty(new TweenQuaternionSlerpProperty(target, property).To(v));
        return tween;
    }
    public TTween to_bySlerp(string property, System.Func<Quaternion> v)
    {
        tween.addProperty(new TweenDynamicQuaternionSlerpProperty2(target, property).From().DynamicTo(v));
        return tween;
    }
    public TTween toQuaternion_bySlerp(string property, object v)
    {
        tween.addProperty(new TweenDynamicQuaternionSlerpProperty(target, property).From().DynamicTo(v));
        return tween;
    }

    //
    /// <summary>
    /// tween from the specified float.
    /// it will be end from the current value.
    /// </summary>
    /// <param name="property">The property name of object(Tween.target).</param>
    /// <param name="v">from value.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween from(string property, float v)
    {
        tween.addProperty(new TweenFloatProperty(target, property).From(v));
        return tween;
    }
    public TTween from(string property, System.Func<float> v)
    {
        tween.addProperty(new TweenDynamicFloatProperty2(target, property).DynamicFrom(v).To());
        return tween;
    }
    public TTween fromFloat(string property, object v)
    {
        tween.addProperty(new TweenDynamicFloatProperty(target, property).DynamicFrom(v).To());
        return tween;
    }
    /// <summary>
    /// tween from the specified double.
    /// it will be end from the current value.
    /// </summary>
    /// <param name="property">The property name of object(Tween.target).</param>
    /// <param name="v">from value.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween from(string property, double v)
    {
        tween.addProperty(new TweenDoubleProperty(target, property).From(v));
        return tween;
    }
    public TTween from(string property, System.Func<double> v)
    {
        tween.addProperty(new TweenDynamicDoubleProperty2(target, property).DynamicFrom(v).To());
        return tween;
    }
    public TTween fromDouble(string property, object v)
    {
        tween.addProperty(new TweenDynamicDoubleProperty(target, property).DynamicFrom(v).To());
        return tween;
    }
    /// <summary>
    /// tween from the specified vector2.
    /// it will be end from the current value.
    /// </summary>
    /// <param name="property">The property name of object(Tween.target).</param>
    /// <param name="v">from value.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween from(string property, Vector2 v)
    {
        tween.addProperty(new TweenVector2Property(target, property).From(v));
        return tween;
    }
    public TTween from(string property, System.Func<Vector2> v)
    {
        tween.addProperty(new TweenDynamicVector2Property2(target, property).DynamicFrom(v).To());
        return tween;
    }
    public TTween fromVector2(string property, object v)
    {
        tween.addProperty(new TweenDynamicVector2Property(target, property).DynamicFrom(v).To());
        return tween;
    }
    /// <summary>
    /// tween from the specified vector3.
    /// it will be end from the current value.
    /// </summary>
    /// <param name="property">The property name of object(Tween.target).</param>
    /// <param name="v">from value.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween from(string property, Vector3 v)
    {
        tween.addProperty(new TweenVector3Property(target, property).From(v));
        return tween;
    }
    public TTween from(string property, System.Func<Vector3> v)
    {
        tween.addProperty(new TweenDynamicVector3Property2(target, property).DynamicFrom(v).To());
        return tween;
    }
    public TTween fromVector3(string property, object v)
    {
        tween.addProperty(new TweenDynamicVector3Property(target, property).DynamicFrom(v).To());
        return tween;
    }
    /// <summary>
    /// tween from the specified vector4.
    /// it will be end from the current value.
    /// </summary>
    /// <param name="property">The property name of object(Tween.target).</param>
    /// <param name="v">from value.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween from(string property, Vector4 v)
    {
        tween.addProperty(new TweenVector4Property(target, property).From(v));
        return tween;
    }
    public TTween from(string property, System.Func<Vector4> v)
    {
        tween.addProperty(new TweenDynamicVector4Property2(target, property).DynamicFrom(v).To());
        return tween;
    }
    public TTween fromVector4(string property, object v)
    {
        tween.addProperty(new TweenDynamicVector4Property(target, property).DynamicFrom(v).To());
        return tween;
    }
    /// <summary>
    /// tween from the specified quaternion.
    /// it will be end from the current value.
    /// </summary>
    /// <param name="property">The property name of object(Tween.target).</param>
    /// <param name="v">from value.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween from(string property, Quaternion v)
    {
        tween.addProperty(new TweenQuaternionProperty(target, property).From(v));
        return tween;
    }
    public TTween from(string property, System.Func<Quaternion> v)
    {
        tween.addProperty(new TweenDynamicQuaternionProperty2(target, property).DynamicFrom(v).To());
        return tween;
    }
    public TTween fromQuaternion(string property, object v)
    {
        tween.addProperty(new TweenDynamicQuaternionProperty(target, property).DynamicFrom(v).To());
        return tween;
    }
    /// <summary>
    /// tween from the specified rect.
    /// it will be end from the current value.
    /// </summary>
    /// <param name="property">The property name of object(Tween.target).</param>
    /// <param name="v">from value.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween from(string property, Rect v)
    {
        tween.addProperty(new TweenRectProperty(target, property).From(v));
        return tween;
    }
    public TTween from(string property, System.Func<Rect> v)
    {
        tween.addProperty(new TweenDynamicRectProperty2(target, property).DynamicFrom(v).To());
        return tween;
    }
    public TTween fromRect(string property, object v)
    {
        tween.addProperty(new TweenDynamicRectProperty(target, property).DynamicFrom(v).To());
        return tween;
    }
    /// <summary>
    /// tween from the specified color.
    /// it will be end from the current value.
    /// </summary>
    /// <param name="property">The property name of object(Tween.target).</param>
    /// <param name="v">from value.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween from(string property, Color v)
    {
        tween.addProperty(new TweenColorProperty(target, property).From(v));
        return tween;
    }
    public TTween from(string property, System.Func<Color> v)
    {
        tween.addProperty(new TweenDynamicColorProperty2(target, property).DynamicFrom(v).To());
        return tween;
    }
    public TTween fromColor(string property, object v)
    {
        tween.addProperty(new TweenDynamicColorProperty(target, property).DynamicFrom(v).To());
        return tween;
    }
    /// <summary>
    /// tween from the specified vector3.
    /// it will be end from the current value.
    /// lerp by Vector3.Slerp
    /// </summary>
    /// <param name="property">The property name of object(Tween.target).</param>
    /// <param name="v">from value.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween from_bySlerp(string property, Vector3 v)
    {
        tween.addProperty(new TweenVector3SlerpProperty(target, property).From(v));
        return tween;
    }
    public TTween from_bySlerp(string property, System.Func<Vector3> v)
    {
        tween.addProperty(new TweenDynamicVector3SlerpProperty2(target, property).DynamicFrom(v).To());
        return tween;
    }
    public TTween fromVector3_bySlerp(string property, object v)
    {
        tween.addProperty(new TweenDynamicVector3SlerpProperty(target, property).DynamicFrom(v).To());
        return tween;
    }
    /// <summary>
    /// tween from the specified quaternion.
    /// it will be end from the current value.
    /// lerp by Quaternion.Slerp
    /// </summary>
    /// <param name="property">The property name of object(Tween.target).</param>
    /// <param name="v">from value.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween from_bySlerp(string property, Quaternion v)
    {
        tween.addProperty(new TweenQuaternionSlerpProperty(target, property).From(v));
        return tween;
    }
    public TTween from_bySlerp(string property, System.Func<Quaternion> v)
    {
        tween.addProperty(new TweenDynamicQuaternionSlerpProperty2(target, property).DynamicFrom(v).To());
        return tween;
    }
    public TTween fromQuaternion_bySlerp(string property, object v)
    {
        tween.addProperty(new TweenDynamicQuaternionSlerpProperty(target, property).DynamicFrom(v).To());
        return tween;
    }


    //
    /// <summary>
    /// tween from the specified float and to the specified float.
    /// </summary>
    /// <param name="property">The property name of object(Tween.target).</param>
    /// <param name="f">from value.</param>
    /// <param name="t">to value.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween fromTo(string property, float f, float t)
    {
        tween.addProperty(new TweenFloatProperty(target, property).FromTo(f, t));
        return tween;
    }
    public TTween fromTo(string property, System.Func<float> f, System.Func<float> t)
    {
        tween.addProperty(new TweenDynamicFloatProperty2(target, property).DynamicFrom(f).DynamicTo(t));
        return tween;
    }
    public TTween fromToFloat(string property, object f, object t)
    {
        tween.addProperty(new TweenDynamicFloatProperty(target, property).DynamicFrom(f).DynamicTo(t));
        return tween;
    }
    /// <summary>
    /// tween from the specified double and to the specified double.
    /// </summary>
    /// <param name="property">The property name of object(Tween.target).</param>
    /// <param name="f">from value.</param>
    /// <param name="t">to value.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween fromTo(string property, double f, double t)
    {
        tween.addProperty(new TweenDoubleProperty(target, property).FromTo(f, t));
        return tween;
    }
    public TTween fromTo(string property, System.Func<double> f, System.Func<double> t)
    {
        tween.addProperty(new TweenDynamicDoubleProperty2(target, property).DynamicFrom(f).DynamicTo(t));
        return tween;
    }
    public TTween fromToDouble(string property, object f, object t)
    {
        tween.addProperty(new TweenDynamicDoubleProperty(target, property).DynamicFrom(f).DynamicTo(t));
        return tween;
    }
    /// <summary>
    /// tween from the specified vector2 and to the specified vector2.
    /// </summary>
    /// <param name="property">The property name of object(Tween.target).</param>
    /// <param name="f">from value.</param>
    /// <param name="t">to value.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween fromTo(string property, Vector2 f, Vector2 t)
    {
        tween.addProperty(new TweenVector2Property(target, property).FromTo(f, t));
        return tween;
    }
    public TTween fromTo(string property, System.Func<Vector2> f, System.Func<Vector2> t)
    {
        tween.addProperty(new TweenDynamicVector2Property2(target, property).DynamicFrom(f).DynamicTo(t));
        return tween;
    }
    public TTween fromToVector2(string property, object f, object t)
    {
        tween.addProperty(new TweenDynamicVector2Property(target, property).DynamicFrom(f).DynamicTo(t));
        return tween;
    }
    /// <summary>
    /// tween from the specified vector3 and to the specified vector3.
    /// </summary>
    /// <param name="property">The property name of object(Tween.target).</param>
    /// <param name="f">from value.</param>
    /// <param name="t">to value.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween fromTo(string property, Vector3 f, Vector3 t)
    {
        tween.addProperty(new TweenVector3Property(target, property).FromTo(f, t));
        return tween;
    }
    public TTween fromTo(string property, System.Func<Vector3> f, System.Func<Vector3> t)
    {
        tween.addProperty(new TweenDynamicVector3Property2(target, property).DynamicFrom(f).DynamicTo(t));
        return tween;
    }
    public TTween fromToVector3(string property, object f, object t)
    {
        tween.addProperty(new TweenDynamicVector3Property(target, property).DynamicFrom(f).DynamicTo(t));
        return tween;
    }
    /// <summary>
    /// tween from the specified vector4 and to the specified vector4.
    /// </summary>
    /// <param name="property">The property name of object(Tween.target).</param>
    /// <param name="f">from value.</param>
    /// <param name="t">to value.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween fromTo(string property, Vector4 f, Vector4 t)
    {
        tween.addProperty(new TweenVector3Property(target, property).FromTo(f, t));
        return tween;
    }
    public TTween fromTo(string property, System.Func<Vector4> f, System.Func<Vector4> t)
    {
        tween.addProperty(new TweenDynamicVector4Property2(target, property).DynamicFrom(f).DynamicTo(t));
        return tween;
    }
    /// <summary>
    /// tween from the specified quaternion and to the specified quaternion.
    /// </summary>
    /// <param name="property">The property name of object(Tween.target).</param>
    /// <param name="f">from value.</param>
    /// <param name="t">to value.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween fromTo(string property, Quaternion f, Quaternion t)
    {
        tween.addProperty(new TweenQuaternionProperty(target, property).FromTo(f, t));
        return tween;
    }
    public TTween fromTo(string property, System.Func<Quaternion> f, System.Func<Quaternion> t)
    {
        tween.addProperty(new TweenDynamicQuaternionProperty2(target, property).DynamicFrom(f).DynamicTo(t));
        return tween;
    }
    public TTween fromToQuaternion(string property, object f, object t)
    {
        tween.addProperty(new TweenDynamicQuaternionProperty(target, property).DynamicFrom(f).DynamicTo(t));
        return tween;
    }
    /// <summary>
    /// tween from the specified rect and to the specified rect.
    /// </summary>
    /// <param name="property">The property name of object(Tween.target).</param>
    /// <param name="f">from value.</param>
    /// <param name="t">to value.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween fromTo(string property, Rect f, Rect t)
    {
        tween.addProperty(new TweenRectProperty(target, property).FromTo(f, t));
        return tween;
    }
    public TTween fromTo(string property, System.Func<Rect> f, System.Func<Rect> t)
    {
        tween.addProperty(new TweenDynamicRectProperty2(target, property).DynamicFrom(f).DynamicTo(t));
        return tween;
    }
    public TTween fromToRect(string property, object f, object t)
    {
        tween.addProperty(new TweenDynamicRectProperty(target, property).DynamicFrom(f).DynamicTo(t));
        return tween;
    }
    /// <summary>
    /// tween from the specified color and to the specified color.
    /// </summary>
    /// <param name="property">The property name of object(Tween.target).</param>
    /// <param name="f">from value.</param>
    /// <param name="t">to value.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween fromTo(string property, Color f, Color t)
    {
        tween.addProperty(new TweenColorProperty(target, property).FromTo(f, t));
        return tween;
    }
    public TTween fromTo(string property, System.Func<Color> f, System.Func<Color> t)
    {
        tween.addProperty(new TweenDynamicColorProperty2(target, property).DynamicFrom(f).DynamicTo(t));
        return tween;
    }
    public TTween fromToColor(string property, object f, object t)
    {
        tween.addProperty(new TweenDynamicColorProperty(target, property).DynamicFrom(f).DynamicTo(t));
        return tween;
    }
    /// <summary>
    /// tween from the specified vector3 and to the specified vector3.
    /// lerp by Vector3.Slerp
    /// </summary>
    /// <param name="property">The property name of object(Tween.target).</param>
    /// <param name="f">from value.</param>
    /// <param name="t">to value.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween fromTo_bySlerp(string property, Vector3 f, Vector3 t)
    {
        tween.addProperty(new TweenVector3SlerpProperty(target, property).FromTo(f, t));
        return tween;
    }
    public TTween fromTo_bySlerp(string property, System.Func<Vector3> f, System.Func<Vector3> t)
    {
        tween.addProperty(new TweenDynamicVector3SlerpProperty2(target, property).DynamicFrom(f).DynamicTo(t));
        return tween;
    }
    public TTween fromToVector3_bySlerp(string property, object f, object t)
    {
        tween.addProperty(new TweenDynamicVector3SlerpProperty(target, property).DynamicFrom(f).DynamicTo(t));
        return tween;
    }
    /// <summary>
    /// tween from the specified quaternion and to the specified quaternion.
    /// lerp by Quaternion.Slerp
    /// </summary>
    /// <param name="property">The property name of object(Tween.target).</param>
    /// <param name="f">from value.</param>
    /// <param name="t">to value.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween fromTo_bySlerp(string property, Quaternion f, Quaternion t)
    {
        tween.addProperty(new TweenQuaternionSlerpProperty(target, property).FromTo(f, t));
        return tween;
    }
    public TTween fromTo_bySlerp(string property, System.Func<Quaternion> f, System.Func<Quaternion> t)
    {
        tween.addProperty(new TweenDynamicQuaternionSlerpProperty2(target, property).DynamicFrom(f).DynamicTo(t));
        return tween;
    }
    public TTween fromToQuaternion_bySlerp(string property, object f, object t)
    {
        tween.addProperty(new TweenDynamicQuaternionSlerpProperty(target, property).DynamicFrom(f).DynamicTo(t));
        return tween;
    }

    //
    /// <summary>
    /// tween offset by the specified float.
    /// </summary>
    /// <param name="property">The property name of object(Tween.target).</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween by(string property, float v)
    {
        tween.addProperty(new TweenFloatProperty(target, property).By(v));
        return tween;
    }
    /// <summary>
    /// tween offset by the specified double.
    /// </summary>
    /// <param name="property">The property name of object(Tween.target).</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween by(string property, double v)
    {
        tween.addProperty(new TweenDoubleProperty(target, property).By(v));
        return tween;
    }
    /// <summary>
    /// tween offset by the specified vector2.
    /// </summary>
    /// <param name="property">The property name of object(Tween.target).</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween by(string property, Vector2 v)
    {
        tween.addProperty(new TweenVector2Property(target, property).By(v));
        return tween;
    }
    /// <summary>
    /// tween offset by the specified vector3.
    /// </summary>
    /// <param name="property">The property name of object(Tween.target).</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween by(string property, Vector3 v)
    {
        tween.addProperty(new TweenVector3Property(target, property).By(v));
        return tween;
    }
    /// <summary>
    /// tween offset by the specified quaternion.
    /// </summary>
    /// <param name="property">The property name of object(Tween.target).</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween by(string property, Quaternion v)
    {
        tween.addProperty(new TweenQuaternionProperty(target, property).By(v));
        return tween;
    }
    /// <summary>
    /// tween offset by the specified vector4.
    /// </summary>
    /// <param name="property">The property name of object(Tween.target).</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween by(string property, Vector4 v)
    {
        tween.addProperty(new TweenVector4Property(target, property).By(v));
        return tween;
    }
    /// <summary>
    /// tween offset by the specified rect.
    /// </summary>
    /// <param name="property">The property name of object(Tween.target).</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween by(string property, Rect v)
    {
        tween.addProperty(new TweenRectProperty(target, property).By(v));
        return tween;
    }
    /// <summary>
    /// tween offset by the specified color.
    /// </summary>
    /// <param name="property">The property name of object(Tween.target).</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween by(string property, Color v)
    {
        tween.addProperty(new TweenColorProperty(target, property).By(v));
        return tween;
    }
    /// <summary>
    /// tween offset by the specified vector3.
    /// lerp by Vector3.Slerp
    /// </summary>
    /// <param name="property">The property name of object(Tween.target).</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween by_bySlerp(string property, Vector3 v)
    {
        tween.addProperty(new TweenVector3SlerpProperty(target, property).By(v));
        return tween;
    }
    /// <summary>
    /// tween offset by the specified quaternion.
    /// lerp by Quaternion.Slerp
    /// </summary>
    /// <param name="property">The property name of object(Tween.target).</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween by_bySlerp(string property, Quaternion v)
    {
        tween.addProperty(new TweenQuaternionSlerpProperty(target, property).By(v));
        return tween;
    }

    //
    /// <summary>
    /// move by specified values.
    /// </summary>
    /// <param name="property">The property name of object(Tween.target).</param>
    /// <param name="velocity">move velocity.</param>
    /// <param name="time">move time.</param>
    /// <param name="dir">move dir.</param>
    /// <param name="delay">delay time.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween move(string property, float velocity, float time, Vector3 dir, float delay /*= 0.0f*/)
    {
        tween.Time(time).Delay(delay).addProperty(new TweenVector3Property(target, property).By(dir * time * velocity));
        return tween;
    }
    /// <summary>
    /// move to target by specified values.
    /// </summary>
    /// <param name="property">The property name of object(Tween.target).</param>
    /// <param name="velocity">move velocity.</param>
    /// <param name="to">move to specified position.</param>
    /// <param name="delay">delay time.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween moveTo(string property, float velocity, Vector3 to, float delay /*= 0.0f*/)
    {
        var tp = new TweenVector3Property(target, property);
        tp.To(to);
        var offset = tp.to - tp.from;
        tween.Time(offset.magnitude / velocity).Delay(delay).addProperty(tp);
        return tween;
    }
    /// <summary>
    /// move to target by specified values.
    /// </summary>
    /// <param name="property">The property name of object(Tween.target).</param>
    /// <param name="velocity">move velocity.</param>
    /// <param name="time">move time.</param>
    /// <param name="to">move to specified position.</param>
    /// <param name="delay">delay time.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween moveTo(string property, float velocity, float time, Vector3 to, float delay /*= 0.0f*/)
    {
        var tp = new TweenVector3Property(target, property);
        var dir = (to - tp.from).normalized;
        tween.Time(time).Delay(delay).addProperty(tp.To(tp.from + dir * velocity * time));
        return tween;
    }
    /// <summary>
    /// move from target by specified values.
    /// </summary>
    /// <param name="property">The property name of object(Tween.target).</param>
    /// <param name="velocity">move velocity.</param>
    /// <param name="from">move from specified position.</param>
    /// <param name="delay">delay time.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween moveFrom(string property, float velocity, Vector3 from, float delay /*= 0.0f*/)
    {
        var tp = new TweenVector3Property(target, property);
        tp.From(from);
        var offset = tp.to - from;
        tween.Time(offset.magnitude / velocity).Delay(delay).addProperty(tp);
        return tween;
    }
    /// <summary>
    /// move by specified values.
    /// </summary>
    /// <param name="property">The property name of object(Tween.target).</param>
    /// <param name="velocity">move velocity.</param>
    /// <param name="from">move from specified position.</param>
    /// <param name="to">move to specified position.</param>
    /// <param name="delay">delay time.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween moveFromTo(string property, float velocity, Vector3 from, Vector3 to, float delay /*= 0.0f*/)
    {
        var offset = to - from;
        tween.Time(offset.magnitude / velocity).Delay(delay);
        return fromTo(property, from, to);
    }
    /// <summary>
    /// move offset by specified values.
    /// </summary>
    /// <param name="property">The property name of object(Tween.target).</param>
    /// <param name="velocity">move velocity.</param>
    /// <param name="offset">move offset.</param>
    /// <param name="delay">delay time.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween moveBy(string property, float velocity, Vector3 offset, float delay /*= 0.0f*/)
    {
        tween.Time(offset.magnitude / velocity).Delay(delay);
        return by(property, offset);
    }

    //
    /// <summary>
    /// move by specified values.
    /// </summary>
    /// <param name="property">The property name of object(Tween.target).</param>
    /// <param name="velocity">move velocity.</param>
    /// <param name="time">move time.</param>
    /// <param name="dir">move dir.</param>
    /// <param name="delay">delay time.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween move(string property, float velocity, float time, float delay /*= 0.0f*/)
    {
        tween.Time(time).Delay(delay).addProperty(new TweenFloatProperty(target, property).By(time * velocity));
        return tween;
    }
    /// <summary>
    /// move to target by specified values.
    /// </summary>
    /// <param name="property">The property name of object(Tween.target).</param>
    /// <param name="velocity">move velocity.</param>
    /// <param name="to">move to specified position.</param>
    /// <param name="delay">delay time.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween moveTo(string property, float velocity, float to, float delay /*= 0.0f*/)
    {
        var tp = new TweenFloatProperty(target, property);
        tp.To(to);
        var offset = Mathf.Abs(tp.to - tp.from);
        tween.Time(offset / velocity).Delay(delay).addProperty(tp);
        return tween;
    }
    /// <summary>
    /// move to target by specified values.
    /// </summary>
    /// <param name="property">The property name of object(Tween.target).</param>
    /// <param name="velocity">move velocity.</param>
    /// <param name="time">move time.</param>
    /// <param name="to">move to specified position.</param>
    /// <param name="delay">delay time.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween moveTo1(string property, float velocity, float time, float delay /*= 0.0f*/)
    {
        var tp = new TweenFloatProperty(target, property);
        tween.Time(time).Delay(delay).addProperty(tp.To(tp.from + velocity * time));
        return tween;
    }
    /// <summary>
    /// move from target by specified values.
    /// </summary>
    /// <param name="property">The property name of object(Tween.target).</param>
    /// <param name="velocity">move velocity.</param>
    /// <param name="from">move from specified position.</param>
    /// <param name="delay">delay time.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween moveFrom(string property, float velocity, float from, float delay /*= 0.0f*/)
    {
        var tp = new TweenFloatProperty(target, property);
        tp.From(from);
        var offset = Mathf.Abs(tp.to - from);
        tween.Time(offset / velocity).Delay(delay).addProperty(tp);
        return tween;
    }
    /// <summary>
    /// move by specified values.
    /// </summary>
    /// <param name="property">The property name of object(Tween.target).</param>
    /// <param name="velocity">move velocity.</param>
    /// <param name="from">move from specified position.</param>
    /// <param name="to">move to specified position.</param>
    /// <param name="delay">delay time.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween moveFromTo(string property, float velocity, float from, float to, float delay /*= 0.0f*/)
    {
        var offset = Mathf.Abs(to - from);
        tween.Time(offset / velocity).Delay(delay);
        return fromTo(property, from, to);
    }
    /// <summary>
    /// move offset by specified values.
    /// </summary>
    /// <param name="property">The property name of object(Tween.target).</param>
    /// <param name="velocity">move velocity.</param>
    /// <param name="offset">move offset.</param>
    /// <param name="delay">delay time.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween moveBy(string property, float velocity, float offset, float delay /*= 0.0f*/)
    {
        tween.Time(Mathf.Abs(offset) / velocity).Delay(delay);
        return by(property, offset);
    }


    //
    /// <summary>
    /// filt by the specified float value.
    /// </summary>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween filter(string property, float v)
    {
        tween.addProperty(new TweenFilterFloatProperty(target, property).FromTo2(0.0f, v));
        return tween;
    }
    /// <summary>
    /// filt by the specified function.
    /// </summary>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween filterFunc(string property, System.Func<float> func)
    {
        tween.addProperty(new TweenDynamicFilterFloatProperty(target, property).FromTo(0.0f, func));
        return tween;
    }
    /// <summary>
    /// filt by the specified vector3 value.
    /// </summary>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween filter(string property, Vector3 v)
    {
        tween.addProperty(new TweenFilterVector3Property(target, property).FromTo2(Vector3.zero, v));
        return tween;
    }
    /// <summary>
    /// filt by the specified function.
    /// </summary>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween filterFunc(string property, System.Func<Vector3> func)
    {
        tween.addProperty(new TweenDynamicFilterVector3Property(target, property).FromTo(Vector3.zero, func));
        return tween;
    }
    /// <summary>
    /// filt by the specified vector3 value.
    /// </summary>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween filter(string property, Quaternion v)
    {
        tween.addProperty(new TweenFilterQuaternionProperty(target, property).FromTo2(Quaternion.identity, v));
        return tween;
    }
    /// <summary>
    /// filt by the specified function.
    /// </summary>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween filterFunc(string property, System.Func<Quaternion> func)
    {
        tween.addProperty(new TweenDynamicFilterQuaternionProperty(target, property).FromTo(Quaternion.identity, func));
        return tween;
    }
}


/// <summary>
/// set the transform propertys.
/// </summary>
public class TransformTweenProxy<TTween> where TTween : Tween
{
    //
    public TTween tween;

    Transform transform;

    public TransformTweenProxy(TTween t)
    {
        transform = Tween.getComponent<Transform>(t.target);

        if (transform == null)
            Debug.LogError("Tween.target is not Transform, target=" + t.target.GetType(), t.id as Object);

        tween = t;
    }
    public TransformTweenProxy(TTween t,Transform tran)
    {
        transform = tran;
        tween = t;
    }

    //
    enum Property
    {
        None,

        localPosition,position,
        localEulerAngles,eulerAngles,
        localRotation,rotation,
        localScale,

        up,forward,right,

        x,y,z,
    }
    Property property = Property.None;
    string propertyStr{get{return property.ToString();}}

    /// <summary>
    /// local position tween. Vector3 type.
    /// </summary>
    public TransformTweenProxy<TTween> localPosition{ get{property = Property.localPosition;  return this;}}
    /// <summary>
    /// position tween. Vector3 type.
    /// </summary>
    public TransformTweenProxy<TTween> position{ get{property = Property.position;  return this;}}

    /// <summary>
    /// local euler angles tween. Vector3 type.
    /// </summary>
    public TransformTweenProxy<TTween> localEulerAngles{ get{property = Property.localEulerAngles;  return this;}}
    /// <summary>
    /// euler angles tween. Vector3 type.
    /// </summary>
    public TransformTweenProxy<TTween> eulerAngles{ get{property = Property.eulerAngles;  return this;}}

    /// <summary>
    /// local rotation tween. Quaternion type.
    /// </summary>
    public TransformTweenProxy<TTween> localRotation{ get{property = Property.localRotation;  return this;}}
    /// <summary>
    /// rotation tween. Quaternion type.
    /// </summary>
    public TransformTweenProxy<TTween> rotation{ get{property = Property.rotation;  return this;}}

    /// <summary>
    /// local scale tween. Vector3 type.
    /// </summary>
    public TransformTweenProxy<TTween> localScale{ get{property = Property.localScale;  return this;}}
    
    /// <summary>
    /// up dir tween. Vector3 type.
    /// </summary>
    public TransformTweenProxy<TTween> up{ get{property = Property.up;  return this;}}
    /// <summary>
    /// forward dir tween. Vector3 type.
    /// </summary>
    public TransformTweenProxy<TTween> forward{ get{property = Property.forward;  return this;}}
    /// <summary>
    /// right dir tween. Vector3 type.
    /// </summary>
    public TransformTweenProxy<TTween> right{ get{property = Property.right;  return this;}}
    
    Property floatProperty = Property.None;
    string floatPropertyStr{ get{return floatProperty.ToString();}}
    /// <summary>
    /// Vector3.x tween. float type.
    /// </summary>
    public TransformTweenProxy<TTween> x{ get{floatProperty = Property.x;  return this;}}
    /// <summary>
    /// Vector3.y tween. float type.
    /// </summary>
    public TransformTweenProxy<TTween> y{ get{floatProperty = Property.y;  return this;}}
    /// <summary>
    /// Vector3.z tween. float type.
    /// </summary>
    public TransformTweenProxy<TTween> z{ get{floatProperty = Property.z;  return this;}}


    //
    /// <summary>
    /// tween to the specified vector3.
    /// it will be start from the current value.
    /// </summary>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween to(Vector3 v)
    {
        tween.addProperty(new TweenVector3Property(transform, propertyStr).To(v));
        property = Property.None;
        return tween;
    }
    public TTween to(System.Func<Vector3> v)
    {
        tween.addProperty(new TweenDynamicVector3Property2(transform, propertyStr).From().DynamicTo(v));
        property = Property.None;
        return tween;
    }
    public TTween toVector3(object v)
    {
        tween.addProperty(new TweenDynamicVector3Property(transform, propertyStr).From().DynamicTo(v));
        property = Property.None;
        return tween;
    }
    /// <summary>
    /// tween to the specified quaternion.
    /// it will be start from the current value.
    /// </summary>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween to(Quaternion v)
    {
        tween.addProperty(new TweenQuaternionProperty(transform, propertyStr).To(v));
        property = Property.None;
        return tween;
    }
    public TTween to(System.Func<Quaternion> v)
    {
        tween.addProperty(new TweenDynamicQuaternionProperty2(transform, propertyStr).From().DynamicTo(v));
        property = Property.None;
        return tween;
    }
    public TTween toQuaternion(object v)
    {
        tween.addProperty(new TweenDynamicQuaternionProperty(transform, propertyStr).From().DynamicTo(v));
        property = Property.None;
        return tween;
    }
    /// <summary>
    /// tween to the specified vector3.
    /// it will be start from the current value.
    /// lerp by Vector3.Slerp
    /// </summary>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween to_bySlerp(Vector3 v)
    {
        tween.addProperty(new TweenVector3SlerpProperty(transform, propertyStr).To(v));
        property = Property.None;
        return tween;
    }
    public TTween to_bySlerp(System.Func<Vector3> v)
    {
        tween.addProperty(new TweenDynamicVector3SlerpProperty2(transform, propertyStr).From().DynamicTo(v));
        property = Property.None;
        return tween;
    }
    public TTween toVector3_bySlerp(object v)
    {
        tween.addProperty(new TweenDynamicVector3SlerpProperty(transform, propertyStr).From().DynamicTo(v));
        property = Property.None;
        return tween;
    }
    /// <summary>
    /// tween to the specified quaternion.
    /// it will be start from the current value.
    /// lerp by Quaternion.Slerp
    /// </summary>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween to_bySlerp(Quaternion v)
    {
        tween.addProperty(new TweenQuaternionSlerpProperty(transform, propertyStr).To(v));
        property = Property.None;
        return tween;
    }
    public TTween to_bySlerp(System.Func<Quaternion> v)
    {
        tween.addProperty(new TweenDynamicQuaternionSlerpProperty2(transform, propertyStr).From().DynamicTo(v));
        property = Property.None;
        return tween;
    }
    public TTween toQuaternion_bySlerp(object v)
    {
        tween.addProperty(new TweenDynamicQuaternionSlerpProperty(transform, propertyStr).From().DynamicTo(v));
        property = Property.None;
        return tween;
    }


    //
    /// <summary>
    /// tween from the specified vector3.
    /// it will be end from the current value.
    /// </summary>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween from(Vector3 v)
    {
        tween.addProperty(new TweenVector3Property(transform, propertyStr).From(v));
        property = Property.None;
        return tween;
    }
    public TTween from(System.Func<Vector3> v)
    {
        tween.addProperty(new TweenDynamicVector3Property2(transform, propertyStr).DynamicFrom(v).To());
        property = Property.None;
        return tween;
    }
    public TTween fromVector3(object v)
    {
        tween.addProperty(new TweenDynamicVector3Property(transform, propertyStr).DynamicFrom(v).To());
        property = Property.None;
        return tween;
    }
    /// <summary>
    /// tween from the specified quaternion.
    /// it will be end from the current value.
    /// </summary>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween from(Quaternion v)
    {
        tween.addProperty(new TweenQuaternionProperty(transform, propertyStr).From(v));
        property = Property.None;
        return tween;
    }
    public TTween from(System.Func<Quaternion> v)
    {
        tween.addProperty(new TweenDynamicQuaternionProperty2(transform, propertyStr).DynamicFrom(v).To());
        property = Property.None;
        return tween;
    }
    public TTween fromQuaternion(object v)
    {
        tween.addProperty(new TweenDynamicQuaternionProperty(transform, propertyStr).DynamicFrom(v).To());
        property = Property.None;
        return tween;
    }
    /// <summary>
    /// tween from the specified vector3.
    /// it will be end from the current value.
    /// lerp by Vector3.Slerp
    /// </summary>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween from_bySlerp(Vector3 v)
    {
        tween.addProperty(new TweenVector3SlerpProperty(transform, propertyStr).From(v));
        property = Property.None;
        return tween;
    }
    public TTween from_bySlerp(System.Func<Vector3> v)
    {
        tween.addProperty(new TweenDynamicVector3SlerpProperty2(transform, propertyStr).DynamicFrom(v).To());
        property = Property.None;
        return tween;
    }
    public TTween fromVector3_bySlerp(object v)
    {
        tween.addProperty(new TweenDynamicVector3SlerpProperty(transform, propertyStr).DynamicFrom(v).To());
        property = Property.None;
        return tween;
    }
    /// <summary>
    /// tween from the specified quaternion.
    /// it will be end from the current value.
    /// lerp by Quaternion.Slerp
    /// </summary>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween from_bySlerp(Quaternion v)
    {
        tween.addProperty(new TweenQuaternionSlerpProperty(transform, propertyStr).From(v));
        property = Property.None;
        return tween;
    }
    public TTween from_bySlerp(System.Func<Quaternion> v)
    {
        tween.addProperty(new TweenDynamicQuaternionSlerpProperty2(transform, propertyStr).DynamicFrom(v).To());
        property = Property.None;
        return tween;
    }
    public TTween fromQuaternion_bySlerp(object v)
    {
        tween.addProperty(new TweenDynamicQuaternionSlerpProperty(transform, propertyStr).DynamicFrom(v).To());
        property = Property.None;
        return tween;
    }

    //
    /// <summary>
    /// tween from the specified vector3 and to the specified vector3.
    /// </summary>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween fromTo(Vector3 f, Vector3 t)
    {
        tween.addProperty(new TweenVector3Property(transform, propertyStr).FromTo(f,t));
        property = Property.None;
        return tween;
    }
    public TTween fromTo(System.Func<Vector3> f, System.Func<Vector3> t)
    {
        tween.addProperty(new TweenDynamicVector3Property2(transform, propertyStr).DynamicFrom(f).DynamicTo(t));
        property = Property.None;
        return tween;
    }
    public TTween fromToVector3(object f, object t)
    {
        tween.addProperty(new TweenDynamicVector3Property(transform, propertyStr).DynamicFrom(f).DynamicTo(t));
        property = Property.None;
        return tween;
    }
    /// <summary>
    /// tween from the specified quaternion and to the specified quaternion.
    /// </summary>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween fromTo(Quaternion f, Quaternion t)
    {
        tween.addProperty(new TweenQuaternionProperty(transform, propertyStr).FromTo(f,t));
        property = Property.None;
        return tween;
    }
    public TTween fromTo(System.Func<Quaternion> f, System.Func<Quaternion> t)
    {
        tween.addProperty(new TweenDynamicQuaternionProperty2(transform, propertyStr).DynamicFrom(f).DynamicTo(t));
        property = Property.None;
        return tween;
    }
    public TTween fromToQuaternion(object f, object t)
    {
        tween.addProperty(new TweenDynamicQuaternionProperty(transform, propertyStr).DynamicFrom(f).DynamicTo(t));
        property = Property.None;
        return tween;
    }
    /// <summary>
    /// tween from the specified vector3 and to the specified vector3.
    /// lerp by Vector3.Slerp
    /// </summary>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween fromTo_bySlerp(Vector3 f, Vector3 t)
    {
        tween.addProperty(new TweenVector3SlerpProperty(transform, propertyStr).FromTo(f,t));
        property = Property.None;
        return tween;
    }
    public TTween fromTo_bySlerp(System.Func<Vector3> f, System.Func<Vector3> t)
    {
        tween.addProperty(new TweenDynamicVector3SlerpProperty2(transform, propertyStr).DynamicFrom(f).DynamicTo(t));
        property = Property.None;
        return tween;
    }
    public TTween fromToVector3_bySlerp(object f, object t)
    {
        tween.addProperty(new TweenDynamicVector3SlerpProperty(transform, propertyStr).DynamicFrom(f).DynamicTo(t));
        property = Property.None;
        return tween;
    }
    /// <summary>
    /// tween from the specified quaternion and to the specified quaternion.
    /// lerp by Quaternion.Slerp
    /// </summary>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween fromTo_bySlerp(Quaternion f, Quaternion t)
    {
        tween.addProperty(new TweenQuaternionSlerpProperty(transform, propertyStr).FromTo(f,t));
        property = Property.None;
        return tween;
    }
    public TTween fromTo_bySlerp(System.Func<Quaternion> f, System.Func<Quaternion> t)
    {
        tween.addProperty(new TweenDynamicQuaternionSlerpProperty2(transform, propertyStr).DynamicFrom(f).DynamicTo(t));
        property = Property.None;
        return tween;
    }
    public TTween fromToQuaternion_bySlerp(object f, object t)
    {
        tween.addProperty(new TweenDynamicQuaternionSlerpProperty(transform, propertyStr).DynamicFrom(f).DynamicTo(t));
        property = Property.None;
        return tween;
    }


    //
    /// <summary>
    /// tween offset by the specified vector3.
    /// </summary>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween by(Vector3 v)
    {
        tween.addProperty(new TweenVector3Property(transform, propertyStr).By(v));
        property = Property.None;
        return tween;
    }
    /// <summary>
    /// tween offset by the specified quaternion.
    /// </summary>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween by(Quaternion v)
    {
        tween.addProperty(new TweenQuaternionProperty(transform, propertyStr).By(v));
        property = Property.None;
        return tween;
    }
    /// <summary>
    /// tween offset by the specified vector3.
    /// lerp by Vector3.Slerp
    /// </summary>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween by_bySlerp(Vector3 v)
    {
        tween.addProperty(new TweenVector3SlerpProperty(transform, propertyStr).By(v));
        property = Property.None;
        return tween;
    }
    /// <summary>
    /// tween offset by the specified quaternion.
    /// lerp by Quaternion.Slerp
    /// </summary>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween by_bySlerp(Quaternion v)
    {
        tween.addProperty(new TweenQuaternionSlerpProperty(transform, propertyStr).By(v));
        property = Property.None;
        return tween;
    }
    
    //
    /// <summary>
    /// to the specified float.
    /// it will be start from the current value.
    /// </summary>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween to(float v)
    {
        tween.addProperty(new TweenTransformFloatProperty(transform, propertyStr + floatProperty).To(v));
        property = Property.None;
        floatProperty = Property.None;
        return tween;
    }
    /// <summary>
    /// from the specified float.
    /// it will be end from the current value.
    /// </summary>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween from(float v)
    {
        tween.addProperty(new TweenTransformFloatProperty(transform, propertyStr + floatProperty).From(v));
        property = Property.None;
        floatProperty = Property.None;
        return tween;
    }
    /// <summary>
    /// tween from the specified float and to the specified float.
    /// </summary>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween fromTo(float f, float t)
    {
        tween.addProperty(new TweenTransformFloatProperty(transform, propertyStr + floatProperty).FromTo(f,t));
        property = Property.None;
        floatProperty = Property.None;
        return tween;
    }
    /// <summary>
    /// tween offset by the specified float.
    /// </summary>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween by(float v)
    {
        tween.addProperty(new TweenTransformFloatProperty(transform, propertyStr + floatProperty).By(v));
        property = Property.None;
        floatProperty = Property.None;
        return tween;
    }

    //
    /// <summary>
    /// move by specified values.
    /// </summary>
    /// <param name="velocity">move velocity.</param>
    /// <param name="time">move time.</param>
    /// <param name="dir">move dir.</param>
    /// <param name="delay">delay time.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween move(float velocity, float time, Vector3 dir, float delay /*= 0.0f*/)
    {
        tween.Time(time).Delay(delay);
        by(dir * time * velocity);
        property = Property.None;
        return tween;
    }
    /// <summary>
    /// move to target by specified values.
    /// </summary>
    /// <param name="velocity">move velocity.</param>
    /// <param name="to">move to specified position.</param>
    /// <param name="delay">delay time.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween moveTo(float velocity, Vector3 to, float delay /*= 0.0f*/)
    {
        tween
            .Delay(delay)
            .addPropertyAndSetTime(new TweenVector3Property(transform, propertyStr).To(to), velocity);
        property = Property.None;
        return tween;
    }
    /// <summary>
    /// move to target by specified values.
    /// </summary>
    /// <param name="velocity">move velocity.</param>
    /// <param name="time">move time.</param>
    /// <param name="to">move to specified position.</param>
    /// <param name="delay">delay time.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween moveTo(float velocity, float time, Vector3 to, float delay /*= 0.0f*/)
    {
        var tp = new TweenVector3Property(transform, propertyStr);
        var dir = (to - tp.from).normalized;
        tween.Time(time).Delay(delay).addProperty(tp.To(tp.from + dir * velocity * time));
        property = Property.None;
        return tween;
    }
    /// <summary>
    /// move from target by specified values.
    /// </summary>
    /// <param name="velocity">move velocity.</param>
    /// <param name="from">move from specified position.</param>
    /// <param name="delay">delay time.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween moveFrom(float velocity, Vector3 from, float delay /*= 0.0f*/)
    {
        var tp = new TweenVector3Property(transform, propertyStr);
        tp.From(from);
        var offset = tp.to - from;
        tween.Time(offset.magnitude / velocity).Delay(delay).addProperty(tp);
        property = Property.None;
        return tween;
    }
    /// <summary>
    /// move by specified values.
    /// </summary>
    /// <param name="velocity">move velocity.</param>
    /// <param name="from">move from specified position.</param>
    /// <param name="to">move to specified position.</param>
    /// <param name="delay">delay time.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween moveFromTo(float velocity, Vector3 from, Vector3 to, float delay /*= 0.0f*/)
    {
        tween
            .Delay(delay)
            .addPropertyAndSetTime(new TweenVector3Property(transform, propertyStr).FromTo(from, to), velocity);
        property = Property.None;
        return tween;
    }
    /// <summary>
    /// move offset by specified values.
    /// </summary>
    /// <param name="velocity">move velocity.</param>
    /// <param name="offset">move offset.</param>
    /// <param name="delay">delay time.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween moveBy(float velocity, Vector3 offset, float delay /*= 0.0f*/)
    {
        tween.Time(offset.magnitude / velocity).Delay(delay);
        by(offset);
        property = Property.None;
        return tween;
    }

    //
    /// <summary>
    /// tween by the spline path.
    /// </summary>
    /// <param name="p">path points.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween splinePath(List<Transform> p)
    {
        tween.addProperty(new TweenSplineProperty(transform, "position").Path(p));
        property = Property.None;
        return tween;
    }

    //
    /// <summary>
    /// filt by the specified float value.
    /// </summary>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween filter(float v)
    {
        tween.addProperty(new TweenFilterTransformFloatProperty(transform, propertyStr + floatProperty).FromTo2(0.0f, v));
        property = Property.None;
        return tween;
    }
    /// <summary>
    /// filt by the specified function.
    /// </summary>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween filterFunc(System.Func<float> func)
    {
        tween.addProperty(new TweenDynamicFilterTransformFloatProperty(transform, propertyStr).FromTo(0.0f, func));
        property = Property.None;
        return tween;
    }
    /// <summary>
    /// filt by the specified vector3 value.
    /// </summary>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween filter(Vector3 v)
    {
        tween.addProperty(new TweenFilterVector3Property(transform, propertyStr).FromTo2(Vector3.zero, v));
        property = Property.None;
        return tween;
    }
    /// <summary>
    /// filt by the specified function.
    /// </summary>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween filterFunc(System.Func<Vector3> func)
    {
        tween.addProperty(new TweenDynamicFilterVector3Property(transform, propertyStr).FromTo(Vector3.zero, func));
        property = Property.None;
        return tween;
    }
    /// <summary>
    /// filt by the specified vector3 value.
    /// </summary>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween filter(Quaternion v)
    {
        tween.addProperty(new TweenFilterQuaternionProperty(transform, propertyStr).FromTo2(Quaternion.identity, v));
        property = Property.None;
        return tween;
    }
    /// <summary>
    /// filt by the specified function.
    /// </summary>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween filterFunc(System.Func<Quaternion> func)
    {
        tween.addProperty(new TweenDynamicFilterQuaternionProperty(transform, propertyStr).FromTo(Quaternion.identity, func));
        property = Property.None;
        return tween;
    }
 

}


/// <summary>
/// set the material propertys.
/// </summary>
public class MaterialTweenProxy<TTween> where TTween : Tween
{
    public TTween tween;

    //
    Material material;


    public MaterialTweenProxy(TTween t)
    {
        var renderer = Tween.getComponent<Renderer>(t.target);

        if (renderer == null)
            Debug.LogError("Tween.target is not have renderer, target=" + t.target.GetType(), t.id as Object);

        material = renderer.material;

        if (material == null)
            Debug.LogError("Tween.target is not have material, target=" + t.target.GetType(), t.id as Object);

        tween = t;
    }
    public MaterialTweenProxy(TTween t,Material mat)
    {
        material = mat;
        tween = t;
    }

    
    //
    protected enum Property
    {
        None,
        
        //Color
        _Color,         //"Main Color"
        _TintColor,     //"Tint Color"
        _Tint,          //"Tint Color"

        _SpecColor,     //"Specular Color"
        _EmisColor,     //"Emissive Color"
        _Emission,      //"Emissive Color"
        _ReflectColor,  //"Reflection Color"

        //float
        _Shininess,     //"Shininess"  Range (0.01, 1)
        _InvFade,       //"Soft Particles Factor", Range(0.01,3.0)
        _Parallax,      //"Height"  Range (0.005, 0.08)
        _EmissionLM,    //"Emission (Lightmapper)"
        _Cutoff,        //"Alpha cutoff"  "Base Alpha cutoff"  Range (0,1)

        r,
        g,
        b,
        a,


        //Vector2d
        mainTextureOffset,
        mainTextureScale,

    }

    //
    /// <summary>
    /// MainColor tween. Color type.
    /// </summary>
    /// <returns>return this instance and set other material tween property</returns>
    public MaterialTweenProxy<TTween> MainColor{ get{colorPropertyStr = Property._Color.ToString();  return this;}}
    /// <summary>
    /// TintColor tween. Color type.
    /// </summary>
    /// <returns>return this instance and set other material tween property</returns>
    public MaterialTweenProxy<TTween> TintColor{ get{colorPropertyStr = Property._TintColor.ToString();  return this;}}
    /// <summary>
    /// SpecularColor tween. Color type.
    /// </summary>
    /// <returns>return this instance and set other material tween property</returns>
    public MaterialTweenProxy<TTween> SpecularColor{ get{colorPropertyStr = Property._SpecColor.ToString();  return this;}}
    /// <summary>
    /// EmissiveColor tween. Color type.
    /// </summary>
    /// <returns>return this instance and set other material tween property</returns>
    public MaterialTweenProxy<TTween> EmissiveColor{ get{colorPropertyStr = Property._EmisColor.ToString();  return this;}}
    /// <summary>
    /// ReflectionColor tween. Color type.
    /// </summary>
    /// <returns>return this instance and set other material tween property</returns>
    public MaterialTweenProxy<TTween> ReflectionColor{ get{colorPropertyStr = Property._ReflectColor.ToString();  return this;}}
    /// <summary>
    /// Shininess tween. float type.
    /// </summary>
    /// <returns>return this instance and set other material tween property</returns>
    public MaterialTweenProxy<TTween> Shininess{ get{floatPropertyStr = Property._Shininess.ToString();  return this;}}
    /// <summary>
    /// SoftParticlesFactor tween. float type.
    /// </summary>
    /// <returns>return this instance and set other material tween property</returns>
    public MaterialTweenProxy<TTween> SoftParticlesFactor{ get{floatPropertyStr = Property._InvFade.ToString();  return this;}}
    /// <summary>
    /// Height tween. float type.
    /// </summary>
    /// <returns>return this instance and set other material tween property</returns>
    public MaterialTweenProxy<TTween> Height{ get{floatPropertyStr = Property._Parallax.ToString();  return this;}}
    /// <summary>
    /// Emission tween. float type.
    /// </summary>
    /// <returns>return this instance and set other material tween property</returns>
    public MaterialTweenProxy<TTween> Emission{ get{floatPropertyStr = Property._EmissionLM.ToString();  return this;}}
    /// <summary>
    /// AlphaCutoff tween. float type.
    /// </summary>
    /// <returns>return this instance and set other material tween property</returns>
    public MaterialTweenProxy<TTween> AlphaCutoff{ get{floatPropertyStr = Property._Cutoff.ToString();  return this;}}
    
    //
    protected string colorPropertyStr = Property.None.ToString();
    /// <summary>
    /// _Color tween. Color type.
    /// </summary>
    /// <returns>return this instance and set other material tween property</returns>
    public MaterialTweenProxy<TTween> _Color{ get{colorPropertyStr = Property._Color.ToString();  return this;}}
    /// <summary>
    /// _TintColor tween. Color type.
    /// </summary>
    /// <returns>return this instance and set other material tween property</returns>
    public MaterialTweenProxy<TTween> _TintColor{ get{colorPropertyStr = Property._TintColor.ToString();  return this;}}
    /// <summary>
    /// _Tint tween. Color type.
    /// </summary>
    /// <returns>return this instance and set other material tween property</returns>
    public MaterialTweenProxy<TTween> _Tint{ get{colorPropertyStr = Property._Tint.ToString();  return this;}}
    /// <summary>
    /// _SpecColor tween. Color type.
    /// </summary>
    /// <returns>return this instance and set other material tween property</returns>
    public MaterialTweenProxy<TTween> _SpecColor{ get{colorPropertyStr = Property._SpecColor.ToString();  return this;}}
    /// <summary>
    /// _EmisColor tween. Color type.
    /// </summary>
    /// <returns>return this instance and set other material tween property</returns>
    public MaterialTweenProxy<TTween> _EmisColor{ get{colorPropertyStr = Property._EmisColor.ToString();  return this;}}
    /// <summary>
    /// _Emission tween. Color type.
    /// </summary>
    /// <returns>return this instance and set other material tween property</returns>
    public MaterialTweenProxy<TTween> _Emission{ get{colorPropertyStr = Property._Emission.ToString();  return this;}}
    /// <summary>
    /// _ReflectColor tween. Color type.
    /// </summary>
    /// <returns>return this instance and set other material tween property</returns>
    public MaterialTweenProxy<TTween> _ReflectColor{ get{colorPropertyStr = Property._ReflectColor.ToString();  return this;}}

    /// <summary>
    /// set the material color name to tween.
    /// </summary>
    /// <param name="property">property name.</param>
    /// <returns>return this instance and set other material tween property</returns>
    public MaterialTweenProxy<TTween> Color(string property)
    {
        colorPropertyStr = property;
        return this;
    }
    
    protected Property rgbaProperty = Property.None;
    protected string rgbaPropertyStr{get{return rgbaProperty.ToString();}}
    /// <summary>
    /// Color.r tween. float type.
    /// </summary>
    /// <returns>return this instance and set other material tween property</returns>
    public MaterialTweenProxy<TTween> r{ get{rgbaProperty = Property.r;  return this;}}
    /// <summary>
    /// Color.g tween. float type.
    /// </summary>
    /// <returns>return this instance and set other material tween property</returns>
    public MaterialTweenProxy<TTween> g{ get{rgbaProperty = Property.g;  return this;}}
    /// <summary>
    /// Color.b tween. float type.
    /// </summary>
    /// <returns>return this instance and set other material tween property</returns>
    public MaterialTweenProxy<TTween> b{ get{rgbaProperty = Property.b;  return this;}}
    /// <summary>
    /// Color.a tween. float type.
    /// </summary>
    /// <returns>return this instance and set other material tween property</returns>
    public MaterialTweenProxy<TTween> a{ get{rgbaProperty = Property.a;  return this;}}


    protected string floatPropertyStr = Property.None.ToString();
    /// <summary>
    /// _shininess tween. float type.
    /// </summary>
    /// <returns>return this instance and set other material tween property</returns>
    public MaterialTweenProxy<TTween> _Shininess{ get{floatPropertyStr = Property._Shininess.ToString();  return this;}}
    /// <summary>
    /// _InvFade tween. float type.
    /// </summary>
    /// <returns>return this instance and set other material tween property</returns>
    public MaterialTweenProxy<TTween> _InvFade{ get{floatPropertyStr = Property._InvFade.ToString();  return this;}}
    /// <summary>
    /// _Parallax tween. float type.
    /// </summary>
    /// <returns>return this instance and set other material tween property</returns>
    public MaterialTweenProxy<TTween> _Parallax{ get{floatPropertyStr = Property._Parallax.ToString();  return this;}}
    /// <summary>
    /// _EmissionLM tween. float type.
    /// </summary>
    /// <returns>return this instance and set other material tween property</returns>
    public MaterialTweenProxy<TTween> _EmissionLM{ get{floatPropertyStr = Property._EmissionLM.ToString();  return this;}}
    /// <summary>
    /// _Cutoff tween. float type.
    /// </summary>
    /// <returns>return this instance and set other material tween property</returns>
    public MaterialTweenProxy<TTween> _Cutoff{ get{floatPropertyStr = Property._Cutoff.ToString();  return this;}}

    /// <summary>
    /// set the material float name to tween.
    /// float type.
    /// </summary>
    /// <param name="property">property name.</param>
    /// <returns>return this instance and set other material tween property</returns>
    public MaterialTweenProxy<TTween> FloatProperty(string property)
    {
        floatPropertyStr = property;
        return this;
    }

    protected string textureOffsetPropertyStr = Property.None.ToString();
    /// <summary>
    /// set the material.TextureOffset property name to tween.
    /// Vector2 type.
    /// </summary>
    /// <param name="property">property name.</param>
    /// <returns>return this instance and set other material tween property</returns>
    public MaterialTweenProxy<TTween> TextureOffsetProperty(string property)
    {
        textureOffsetPropertyStr = property;
        return this;
    }
    protected string textureScaleStrProperty = Property.None.ToString();
    /// <summary>
    /// set the material.TextureScale property name to tween.
    /// Vector2 type.
    /// </summary>
    /// <param name="property">property name.</param>
    /// <returns>return this instance and set other material tween property</returns>
    public MaterialTweenProxy<TTween> MatPropertyTextureScale(string property)
    {
        textureScaleStrProperty = property;
        return this;
    }
    protected string vector4PropertyStr = Property.None.ToString();
    /// <summary>
    /// set the material Vector4 property name to tween.
    /// Vector4 type.
    /// </summary>
    /// <param name="property">property name.</param>
    /// <returns>return this instance and set other material tween property</returns>
    public MaterialTweenProxy<TTween> MatPropertyVector4(string property)
    {
        vector4PropertyStr = property;
        return this;
    }


    //
    /// <summary>
    /// tween to the specified color.
    /// it will be start from the current value.
    /// </summary>
    /// <param name="v">to color value.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween to(Color v)
    {
        tween.addProperty(new TweenMaterialColorProperty(material, colorPropertyStr).To(v));
        colorPropertyStr = Property.None.ToString();
        return tween;
    }
    /// <summary>
    /// tween from the specified color.
    /// it will be end from the current value.
    /// </summary>
    /// <param name="v">from value.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween from(Color v)
    {
        tween.addProperty(new TweenMaterialColorProperty(material, colorPropertyStr).From(v));
        colorPropertyStr = Property.None.ToString();
        return tween;
    }
    /// <summary>
    /// tween from the specified color and to the specified color.
    /// </summary>
    /// <param name="f">from value.</param>
    /// <param name="t">to value.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween fromTo(Color f,Color t)
    {
        tween.addProperty(new TweenMaterialColorProperty(material, colorPropertyStr).FromTo(f,t));
        colorPropertyStr = Property.None.ToString();
        return tween;
    }
    /// <summary>
    /// tween offset by the specified color.
    /// </summary>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween by(Color v)
    {
        tween.addProperty(new TweenMaterialColorProperty(material, colorPropertyStr).By(v));
        colorPropertyStr = Property.None.ToString();
        return tween;
    }
    
    
    //
    /// <summary>
    /// tween to the specified float.
    /// it will be start from the current value.
    /// </summary>
    /// <param name="v">to float value.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween to(float v)
    {
        if(rgbaPropertyStr != Property.None.ToString())
            tween.addProperty(new TweenMaterialColorFloatProperty(material, colorPropertyStr, rgbaPropertyStr).To(v));
        else
            tween.addProperty(new TweenMaterialFloatProperty(material, floatPropertyStr).To(v));
        colorPropertyStr = Property.None.ToString();
        floatPropertyStr = colorPropertyStr;
        return tween;
    }
    /// <summary>
    /// tween from the specified float.
    /// it will be end from the current value.
    /// </summary>
    /// <param name="v">from float value.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween from(float v)
    {
        if(rgbaPropertyStr != Property.None.ToString())
            tween.addProperty(new TweenMaterialColorFloatProperty(material, colorPropertyStr, rgbaPropertyStr).From(v));
        else
            tween.addProperty(new TweenMaterialFloatProperty(material, floatPropertyStr).From(v));
        colorPropertyStr = Property.None.ToString();
        floatPropertyStr = colorPropertyStr;
        return tween;
    }
    /// <summary>
    /// tween from the specified float and to the specified float.
    /// </summary>
    /// <param name="f">from float value.</param>
    /// <param name="t">to float value.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween fromTo(float f,float t)
    {
        if(rgbaPropertyStr != Property.None.ToString())
            tween.addProperty(new TweenMaterialColorFloatProperty(material, colorPropertyStr, rgbaPropertyStr).FromTo(f,t));
        else
            tween.addProperty(new TweenMaterialFloatProperty(material, floatPropertyStr).FromTo(f,t));
        colorPropertyStr = Property.None.ToString();
        floatPropertyStr = colorPropertyStr;
        return tween;
    }
    /// <summary>
    /// tween offset by the specified float.
    /// </summary>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween by(float v)
    {
        if(rgbaPropertyStr != Property.None.ToString())
            tween.addProperty(new TweenMaterialColorFloatProperty(material, colorPropertyStr, rgbaPropertyStr).By(v));
        else
            tween.addProperty(new TweenMaterialFloatProperty(material, floatPropertyStr).By(v));
        colorPropertyStr = Property.None.ToString();
        floatPropertyStr = colorPropertyStr;
        return tween;
    }
    
    //
    /// <summary>
    /// tween to the specified textureOffset or textureScale value.
    /// it will be start from the current value.
    /// </summary>
    /// <param name="v">to value.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween to(Vector2 v)
    {
        if(textureOffsetPropertyStr != Property.None.ToString())
            tween.addProperty(new TweenMaterialTextureOffsetProperty(material, textureOffsetPropertyStr).To(v));
        else
            tween.addProperty(new TweenMaterialTextureScaleProperty(material, textureScaleStrProperty).To(v));

        textureOffsetPropertyStr = Property.None.ToString();
        textureScaleStrProperty = textureOffsetPropertyStr;
        return tween;
    }
    /// <summary>
    /// tween from the specified textureOffset or textureScale value.
    /// it will be end from the current value.
    /// </summary>
    /// <param name="v">from float value.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween from(Vector2 v)
    {
        if(textureOffsetPropertyStr != Property.None.ToString())
            tween.addProperty(new TweenMaterialTextureOffsetProperty(material, textureOffsetPropertyStr).From(v));
        else
            tween.addProperty(new TweenMaterialTextureScaleProperty(material, textureScaleStrProperty).From(v));
        
        textureOffsetPropertyStr = Property.None.ToString();
        textureScaleStrProperty = textureOffsetPropertyStr;
        return tween;
    }
    /// <summary>
    /// tween from the specified textureOffset or textureScale value.
    /// tween to the specified textureOffset or textureScale value.
    /// </summary>
    /// <param name="f">from Vector2 value.</param>
    /// <param name="t">to Vector2 value.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween fromTo(Vector2 f,Vector2 t)
    {
        if(textureOffsetPropertyStr != Property.None.ToString())
            tween.addProperty(new TweenMaterialTextureOffsetProperty(material, textureOffsetPropertyStr).FromTo(f,t));
        else
            tween.addProperty(new TweenMaterialTextureScaleProperty(material, textureScaleStrProperty).FromTo(f,t));
        
        textureOffsetPropertyStr = Property.None.ToString();
        textureScaleStrProperty = textureOffsetPropertyStr;
        return tween;
    }
    /// <summary>
    /// tween offset by the textureOffset or textureScale value.
    /// </summary>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween by(Vector2 v)
    {
        if(textureOffsetPropertyStr != Property.None.ToString())
            tween.addProperty(new TweenMaterialTextureOffsetProperty(material, textureOffsetPropertyStr).By(v));
        else
            tween.addProperty(new TweenMaterialTextureScaleProperty(material, textureScaleStrProperty).By(v));
        
        textureOffsetPropertyStr = Property.None.ToString();
        textureScaleStrProperty = textureOffsetPropertyStr;
        return tween;
    }


    //
    /// <summary>
    /// tween to the specified vector4.
    /// it will be start from the current value.
    /// </summary>
    /// <param name="v">to Vector4 value.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween to(Vector4 v)
    {
        tween.addProperty(new TweenMaterialVector4Property(material, vector4PropertyStr).To(v));
        vector4PropertyStr = Property.None.ToString();
        return tween;
    }
    /// <summary>
    /// tween from the specified Vector4.
    /// it will be end from the current value.
    /// </summary>
    /// <param name="v">from Vector4 value.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween from(Vector4 v)
    {
        tween.addProperty(new TweenMaterialVector4Property(material, vector4PropertyStr).From(v));
        vector4PropertyStr = Property.None.ToString();
        return tween;
    }
    /// <summary>
    /// tween from the specified vector4 and to the specified vector4.
    /// </summary>
    /// <param name="f">from vector4 value.</param>
    /// <param name="t">to vector4 value.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween fromTo(Vector4 f,Vector4 t)
    {
        tween.addProperty(new TweenMaterialVector4Property(material, vector4PropertyStr).FromTo(f,t));
        vector4PropertyStr = Property.None.ToString();
        return tween;
    }
    /// <summary>
    /// tween offset by the specified vector4.
    /// </summary>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween by(Vector4 v)
    {
        tween.addProperty(new TweenMaterialVector4Property(material, vector4PropertyStr).By(v));
        vector4PropertyStr = Property.None.ToString();
        return tween;
    }
}


/// <summary>
/// set the materials propertys.
/// </summary>
public class MaterialsTweenProxy<TTween> : MaterialTweenProxy<TTween> where TTween : Tween
{
    List<Material> materials = new List<Material>();

    public MaterialsTweenProxy(TTween t, Transform parent, bool isShader, params string[] names)
        :base(t, null)
    {
        if(parent == null)
        {
            parent = Tween.getComponent<Transform>(t.target);

            if (parent == null)
                Debug.LogError("Tween.target is not Transform, target=" + t.target.GetType(), t.id as Object);
        }

        
        //
        var rs = parent.GetComponentsInChildren<Renderer>();
        if(names != null && names.Length > 0)
        {
            if (isShader)
            {
                foreach (var r in rs)
                {
                    foreach (var n in names)
                    {
                        if (n == r.material.shader.name)
                            materials.Add(r.material);
                    }
                }
            }
            else
            {
                foreach (var r in rs)
                {
                    foreach (var n in names)
                    {
                        if (n == r.name)
                            materials.Add(r.material);
                    }
                }
            }
        }
        else
        {
            foreach(var r in rs)
            {
                materials.Add(r.material);
            }
        }

        //??????????????????????????????????????????????????????????????????????????????????????
        //这个警告是要的 但是打印信息会造成卡了一下 影响效果 所以这里先注释
        if(materials.Count == 0)
            Debug.LogWarning("materials.Count == 0", t.id as Object);
        //??????????????????????????????????????????????????????????????????????????????????????

        //
        tween = t;
    }
    
    //
    /// <summary>
    /// MainColor tween. Color type.
    /// </summary>
    /// <returns>return this instance and set other material tween property</returns>
    public new MaterialsTweenProxy<TTween> MainColor{ get{colorPropertyStr = Property._Color.ToString();  return this;}}
    /// <summary>
    /// TintColor tween. Color type.
    /// </summary>
    /// <returns>return this instance and set other material tween property</returns>
    public new MaterialsTweenProxy<TTween> TintColor{ get{colorPropertyStr = Property._TintColor.ToString();  return this;}}
    /// <summary>
    /// SpecularColor tween. Color type.
    /// </summary>
    /// <returns>return this instance and set other material tween property</returns>
    public new MaterialsTweenProxy<TTween> SpecularColor{ get{colorPropertyStr = Property._SpecColor.ToString();  return this;}}
    /// <summary>
    /// EmissiveColor tween. Color type.
    /// </summary>
    /// <returns>return this instance and set other material tween property</returns>
    public new MaterialsTweenProxy<TTween> EmissiveColor{ get{colorPropertyStr = Property._EmisColor.ToString();  return this;}}
    /// <summary>
    /// ReflectionColor tween. Color type.
    /// </summary>
    /// <returns>return this instance and set other material tween property</returns>
    public new MaterialsTweenProxy<TTween> ReflectionColor{ get{colorPropertyStr = Property._ReflectColor.ToString();  return this;}}
    /// <summary>
    /// Shininess tween. float type.
    /// </summary>
    /// <returns>return this instance and set other material tween property</returns>
    public new MaterialsTweenProxy<TTween> Shininess{ get{floatPropertyStr = Property._Shininess.ToString();  return this;}}
    /// <summary>
    /// SoftParticlesFactor tween. float type.
    /// </summary>
    /// <returns>return this instance and set other material tween property</returns>
    public new MaterialsTweenProxy<TTween> SoftParticlesFactor{ get{floatPropertyStr = Property._InvFade.ToString();  return this;}}
    /// <summary>
    /// Height tween. float type.
    /// </summary>
    /// <returns>return this instance and set other material tween property</returns>
    public new MaterialsTweenProxy<TTween> Height{ get{floatPropertyStr = Property._Parallax.ToString();  return this;}}
    /// <summary>
    /// Emission tween. float type.
    /// </summary>
    /// <returns>return this instance and set other material tween property</returns>
    public new MaterialsTweenProxy<TTween> Emission{ get{floatPropertyStr = Property._EmissionLM.ToString();  return this;}}
    /// <summary>
    /// AlphaCutoff tween. float type.
    /// </summary>
    /// <returns>return this instance and set other material tween property</returns>
    public new MaterialsTweenProxy<TTween> AlphaCutoff{ get{floatPropertyStr = Property._Cutoff.ToString();  return this;}}
    
    //
    /// <summary>
    /// _Color tween. Color type.
    /// </summary>
    /// <returns>return this instance and set other material tween property</returns>
    public new MaterialsTweenProxy<TTween> _Color{ get{colorPropertyStr = Property._Color.ToString();  return this;}}
    /// <summary>
    /// _TintColor tween. Color type.
    /// </summary>
    /// <returns>return this instance and set other material tween property</returns>
    public new MaterialsTweenProxy<TTween> _TintColor{ get{colorPropertyStr = Property._TintColor.ToString();  return this;}}
    /// <summary>
    /// _Tint tween. Color type.
    /// </summary>
    /// <returns>return this instance and set other material tween property</returns>
    public new MaterialsTweenProxy<TTween> _Tint{ get{colorPropertyStr = Property._Tint.ToString();  return this;}}
    /// <summary>
    /// _SpecColor tween. Color type.
    /// </summary>
    /// <returns>return this instance and set other material tween property</returns>
    public new MaterialsTweenProxy<TTween> _SpecColor{ get{colorPropertyStr = Property._SpecColor.ToString();  return this;}}
    /// <summary>
    /// _EmisColor tween. Color type.
    /// </summary>
    /// <returns>return this instance and set other material tween property</returns>
    public new MaterialsTweenProxy<TTween> _EmisColor{ get{colorPropertyStr = Property._EmisColor.ToString();  return this;}}
    /// <summary>
    /// _Emission tween. Color type.
    /// </summary>
    /// <returns>return this instance and set other material tween property</returns>
    public new MaterialsTweenProxy<TTween> _Emission{ get{colorPropertyStr = Property._Emission.ToString();  return this;}}
    /// <summary>
    /// _ReflectColor tween. Color type.
    /// </summary>
    /// <returns>return this instance and set other material tween property</returns>
    public new MaterialsTweenProxy<TTween> _ReflectColor{ get{colorPropertyStr = Property._ReflectColor.ToString();  return this;}}
    
    /// <summary>
    /// set the material color name to tween.
    /// </summary>
    /// <param name="property">property name.</param>
    /// <returns>return this instance and set other material tween property</returns>
    public new MaterialsTweenProxy<TTween> Color(string property)
    {
        colorPropertyStr = property;
        return this;
    }
    
    /// <summary>
    /// Color.r tween. float type.
    /// </summary>
    /// <returns>return this instance and set other material tween property</returns>
    public new MaterialsTweenProxy<TTween> r{ get{rgbaProperty = Property.r;  return this;}}
    /// <summary>
    /// Color.g tween. float type.
    /// </summary>
    /// <returns>return this instance and set other material tween property</returns>
    public new MaterialsTweenProxy<TTween> g{ get{rgbaProperty = Property.g;  return this;}}
    /// <summary>
    /// Color.b tween. float type.
    /// </summary>
    /// <returns>return this instance and set other material tween property</returns>
    public new MaterialsTweenProxy<TTween> b{ get{rgbaProperty = Property.b;  return this;}}
    /// <summary>
    /// Color.a tween. float type.
    /// </summary>
    /// <returns>return this instance and set other material tween property</returns>
    public new MaterialsTweenProxy<TTween> a{ get{rgbaProperty = Property.a;  return this;}}
    
    /// <summary>
    /// _shininess tween. float type.
    /// </summary>
    /// <returns>return this instance and set other material tween property</returns>
    public new MaterialsTweenProxy<TTween> _Shininess{ get{floatPropertyStr = Property._Shininess.ToString();  return this;}}
    /// <summary>
    /// _InvFade tween. float type.
    /// </summary>
    /// <returns>return this instance and set other material tween property</returns>
    public new MaterialsTweenProxy<TTween> _InvFade{ get{floatPropertyStr = Property._InvFade.ToString();  return this;}}
    /// <summary>
    /// _Parallax tween. float type.
    /// </summary>
    /// <returns>return this instance and set other material tween property</returns>
    public new MaterialsTweenProxy<TTween> _Parallax{ get{floatPropertyStr = Property._Parallax.ToString();  return this;}}
    /// <summary>
    /// _EmissionLM tween. float type.
    /// </summary>
    /// <returns>return this instance and set other material tween property</returns>
    public new MaterialsTweenProxy<TTween> _EmissionLM{ get{floatPropertyStr = Property._EmissionLM.ToString();  return this;}}
    /// <summary>
    /// _Cutoff tween. float type.
    /// </summary>
    /// <returns>return this instance and set other material tween property</returns>
    public new MaterialsTweenProxy<TTween> _Cutoff{ get{floatPropertyStr = Property._Cutoff.ToString();  return this;}}
    
    /// <summary>
    /// set the material float name to tween.
    /// float type.
    /// </summary>
    /// <param name="property">property name.</param>
    /// <returns>return this instance and set other material tween property</returns>
    public new MaterialsTweenProxy<TTween> FloatProperty(string property)
    {
        floatPropertyStr = property;
        return this;
    }
    protected new MaterialsTweenProxy<TTween> TextureOffsetProperty(string property)
    {
        textureOffsetPropertyStr = property;
        return this;
    }
    protected new MaterialsTweenProxy<TTween> MatPropertyTextureScale(string property)
    {
        textureScaleStrProperty = property;
        return this;
    }
    protected new MaterialsTweenProxy<TTween> MatPropertyVector4(string property)
    {
        vector4PropertyStr = property;
        return this;
    }


    //
    /// <summary>
    /// tween to the specified color.
    /// it will be start from the current value.
    /// </summary>
    /// <param name="v">to color value.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public new TTween to(Color v)
    {
        if (materials.Count > 0)
            tween.addProperty(new TweenMaterialsColorProperty(materials, colorPropertyStr).To(v));

        colorPropertyStr = Property.None.ToString();
        return tween;
    }
    /// <summary>
    /// tween from the specified color.
    /// it will be end from the current value.
    /// </summary>
    /// <param name="v">from value.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public new TTween from(Color v)
    {
        if (materials.Count > 0)
            tween.addProperty(new TweenMaterialsColorProperty(materials, colorPropertyStr).From(v));

        colorPropertyStr = Property.None.ToString();
        return tween;
    }
    /// <summary>
    /// tween from the specified color and to the specified color.
    /// </summary>
    /// <param name="f">from value.</param>
    /// <param name="t">to value.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public new TTween fromTo(Color f,Color t)
    {
        if (materials.Count > 0)
            tween.addProperty(new TweenMaterialsColorProperty(materials, colorPropertyStr).FromTo(f, t));
       
        colorPropertyStr = Property.None.ToString();
        return tween;
    }
    /// <summary>
    /// tween offset by the specified color.
    /// </summary>
    /// <returns>return tween instance and set other tween property</returns>
    public new TTween by(Color v)
    {
        if (materials.Count > 0)
            tween.addProperty(new TweenMaterialsColorProperty(materials, colorPropertyStr).By(v));
        
        colorPropertyStr = Property.None.ToString();
        return tween;
    }
    
    
    //
    /// <summary>
    /// tween to the specified float.
    /// it will be start from the current value.
    /// </summary>
    /// <param name="v">to float value.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public new TTween to(float v)
    {
        if (materials.Count > 0)
        {
            if (rgbaPropertyStr != Property.None.ToString())
                tween.addProperty(new TweenMaterialsColorFloatProperty(materials, colorPropertyStr, rgbaPropertyStr).To(v));
            else
                tween.addProperty(new TweenMaterialsFloatProperty(materials, floatPropertyStr).To(v));
        }
        colorPropertyStr = Property.None.ToString();
        floatPropertyStr = colorPropertyStr;
        return tween;
    }
    /// <summary>
    /// tween from the specified float.
    /// it will be end from the current value.
    /// </summary>
    /// <param name="v">from float value.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public new TTween from(float v)
    {
        if (materials.Count > 0)
        {
            if (rgbaPropertyStr != Property.None.ToString())
                tween.addProperty(new TweenMaterialsColorFloatProperty(materials, colorPropertyStr, rgbaPropertyStr).From(v));
            else
                tween.addProperty(new TweenMaterialsFloatProperty(materials, floatPropertyStr).From(v));
        }
        colorPropertyStr = Property.None.ToString();
        floatPropertyStr = colorPropertyStr;
        return tween;
    }
    /// <summary>
    /// tween from the specified float and to the specified float.
    /// </summary>
    /// <param name="f">from float value.</param>
    /// <param name="t">to float value.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public new TTween fromTo(float f,float t)
    {
        if (materials.Count > 0)
        {
        if(rgbaPropertyStr != Property.None.ToString())
            tween.addProperty(new TweenMaterialsColorFloatProperty(materials, colorPropertyStr, rgbaPropertyStr).FromTo(f,t));
        else
            tween.addProperty(new TweenMaterialsFloatProperty(materials, floatPropertyStr).FromTo(f,t));
        }
        colorPropertyStr = Property.None.ToString();
        floatPropertyStr = colorPropertyStr;
        return tween;
    }
    /// <summary>
    /// tween offset by the specified float.
    /// </summary>
    /// <returns>return tween instance and set other tween property</returns>
    public new TTween by(float v)
    {
        if (materials.Count > 0)
        {
            if (rgbaPropertyStr != Property.None.ToString())
                tween.addProperty(new TweenMaterialsColorFloatProperty(materials, colorPropertyStr, rgbaPropertyStr).By(v));
            else
                tween.addProperty(new TweenMaterialsFloatProperty(materials, floatPropertyStr).By(v));
        }
        colorPropertyStr = Property.None.ToString();
        floatPropertyStr = colorPropertyStr;
        return tween;
    }
    
    //
    protected new TTween to(Vector2 v)
    {
        /*if(textureOffsetPropertyStr != Property.None.ToString())
            tween.addProperty(new TweenMaterialsTextureOffsetProperty(materials, textureOffsetPropertyStr).To(v));
        else
            tween.addProperty(new TweenMaterialsTextureScaleProperty(materials, textureScaleStrProperty).To(v));

        textureOffsetPropertyStr = Property.None.ToString();
        textureScaleStrProperty = textureOffsetPropertyStr;*/
        return tween;
    }
    protected new TTween from(Vector2 v)
    {
        /*if(textureOffsetPropertyStr != Property.None.ToString())
            tween.addProperty(new TweenMaterialsTextureOffsetProperty(materials, textureOffsetPropertyStr).From(v));
        else
            tween.addProperty(new TweenMaterialsTextureScaleProperty(materials, textureScaleStrProperty).From(v));
        
        textureOffsetPropertyStr = Property.None.ToString();
        textureScaleStrProperty = textureOffsetPropertyStr;*/
        return tween;
    }
    protected new TTween fromTo(Vector2 f,Vector2 t)
    {
        /*if(textureOffsetPropertyStr != Property.None.ToString())
            tween.addProperty(new TweenMaterialsTextureOffsetProperty(materials, textureOffsetPropertyStr).FromTo(f,t));
        else
            tween.addProperty(new TweenMaterialsTextureScaleProperty(materials, textureScaleStrProperty).FromTo(f,t));
        
        textureOffsetPropertyStr = Property.None.ToString();
        textureScaleStrProperty = textureOffsetPropertyStr;*/
        return tween;
    }
    protected new TTween by(Vector2 v)
    {
        /*if(textureOffsetPropertyStr != Property.None.ToString())
            tween.addProperty(new TweenMaterialsTextureOffsetProperty(materials, textureOffsetPropertyStr).By(v));
        else
            tween.addProperty(new TweenMaterialsTextureScaleProperty(materials, textureScaleStrProperty).By(v));
        
        textureOffsetPropertyStr = Property.None.ToString();
        textureScaleStrProperty = textureOffsetPropertyStr;*/
        return tween;
    }


    //
    protected new TTween to(Vector4 v)
    {
        /*tween.addProperty(new TweenMaterialsVector4Property(materials, vector4PropertyStr).To(v));
        vector4PropertyStr = Property.None.ToString();*/
        return tween;
    }
    protected new TTween from(Vector4 v)
    {
        /*tween.addProperty(new TweenMaterialsVector4Property(materials, vector4PropertyStr).From(v));
        vector4PropertyStr = Property.None.ToString();*/
        return tween;
    }
    protected new TTween fromTo(Vector4 f,Vector4 t)
    {
        /*tween.addProperty(new TweenMaterialsVector4Property(materials, vector4PropertyStr).FromTo(f,t));
        vector4PropertyStr = Property.None.ToString();*/
        return tween;
    }
    protected new TTween by(Vector4 v)
    {
        /*tween.addProperty(new TweenMaterialsVector4Property(materials, vector4PropertyStr).By(v));
        vector4PropertyStr = Property.None.ToString();*/
        return tween;
    }
}


/// <summary>
/// set the audio propertys.
/// </summary>
public class AudioSourceTweenProxy<TTween> where TTween : Tween
{
    public TTween tween;
    //
    AudioSource audio;
    
    public AudioSourceTweenProxy(TTween t)
    {
        audio = Tween.getComponent<AudioSource>(t.target);

        if (audio == null)
            Debug.LogError("Tween.target is not audio, target=" + t.target.GetType(), t.id as Object);

        tween = t;
    }
    public AudioSourceTweenProxy(TTween t,AudioSource a)
    {
        audio = a;
        tween = t;
    }

    //
    enum Property
    {
        None,
        volume,
        dopplerLevel,
        maxDistance,
        minDistance,
        pan,
        panLevel,
        pitch,
        spread,
    }
    Property property = Property.None;
    string propertyStr{get{return property.ToString();}}
    
    /// <summary>
    /// AudioSource.volume tween. float type.
    /// </summary>
    /// <returns>return this instance and set other AudioSource tween property</returns>
    public AudioSourceTweenProxy<TTween> volume{ get{property = Property.volume;  return this;}}
    /// <summary>
    /// AudioSource.dopplerLevel tween. float type.
    /// </summary>
    /// <returns>return this instance and set other AudioSource tween property</returns>
    public AudioSourceTweenProxy<TTween> dopplerLevel{ get{property = Property.dopplerLevel;  return this;}}
    /// <summary>
    /// AudioSource.maxDistance tween. float type.
    /// </summary>
    /// <returns>return this instance and set other AudioSource tween property</returns>
    public AudioSourceTweenProxy<TTween> maxDistance{ get{property = Property.maxDistance;  return this;}}
    /// <summary>
    /// AudioSource.minDistance tween. float type.
    /// </summary>
    /// <returns>return this instance and set other AudioSource tween property</returns>
    public AudioSourceTweenProxy<TTween> minDistance{ get{property = Property.minDistance;  return this;}}
    /// <summary>
    /// AudioSource.pan tween. float type.
    /// </summary>
    /// <returns>return this instance and set other AudioSource tween property</returns>
    public AudioSourceTweenProxy<TTween> pan{ get{property = Property.pan;  return this;}}
    /// <summary>
    /// AudioSource.panLevel tween. float type.
    /// </summary>
    /// <returns>return this instance and set other AudioSource tween property</returns>
    public AudioSourceTweenProxy<TTween> panLevel{ get{property = Property.panLevel;  return this;}}
    /// <summary>
    /// AudioSource.pitch tween. float type.
    /// </summary>
    /// <returns>return this instance and set other AudioSource tween property</returns>
    public AudioSourceTweenProxy<TTween> pitch{ get{property = Property.pitch;  return this;}}
    /// <summary>
    /// AudioSource.spread tween. float type.
    /// </summary>
    /// <returns>return this instance and set other AudioSource tween property</returns>
    public AudioSourceTweenProxy<TTween> spread{ get{property = Property.spread;  return this;}}

    //
    /// <summary>
    /// tween to the specified float.
    /// it will be start from the current value.
    /// </summary>
    /// <param name="v">to float value.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween to(float v)
    {
        tween.addProperty(new TweenFloatProperty(audio, propertyStr).To(v));
        property = Property.None;
        return tween;
    }
    /// <summary>
    /// tween from the specified float.
    /// it will be end from the current value.
    /// </summary>
    /// <param name="v">from float value.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween from(float v)
    {
        tween.addProperty(new TweenFloatProperty(audio, propertyStr).From(v));
        property = Property.None;
        return tween;
    }
    /// <summary>
    /// tween from the specified float and to the specified float.
    /// </summary>
    /// <param name="f">from float value.</param>
    /// <param name="t">to float value.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween fromTo(float f,float t)
    {
        tween.addProperty(new TweenFloatProperty(audio, propertyStr).FromTo(f,t));
        property = Property.None;
        return tween;
    }
    /// <summary>
    /// tween offset by the specified float.
    /// </summary>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween by(float v)
    {
        tween.addProperty(new TweenFloatProperty(audio, propertyStr).By(v));
        property = Property.None;
        return tween;
    }
}


/// <summary>
/// set the light propertys.
/// </summary>
public class LightTweenProxy<TTween> where TTween : Tween
{
    public TTween tween;

    //
    Light light;
    
    public LightTweenProxy(TTween t)
    {
        light = Tween.getComponent<Light>(t.target);

        if (light == null)
            Debug.LogError("Tween.target is not light, target=" + t.target.GetType(), t.id as Object);

        tween = t;
    }
    public LightTweenProxy(TTween t, Light l)
    {
        light = l;
        tween = t;
    }
    

    //
    enum Property
    {
        None,
        areaSize,
        color,
        intensity,
        range,
        spotAngle,
    }
    Property property = Property.None;
    string propertyStr{get{return property.ToString();}}
    
    /// <summary>
    /// Light.areaSize tween. float type.
    /// </summary>
    /// <returns>return this instance and set other Light tween property</returns>
    public LightTweenProxy<TTween> areaSize{ get{property = Property.areaSize;  return this;}}
    /// <summary>
    /// Light.color tween. float type.
    /// </summary>
    /// <returns>return this instance and set other Light tween property</returns>
    public LightTweenProxy<TTween> color{ get{property = Property.color;  return this;}}
    /// <summary>
    /// Light.intensity tween. float type.
    /// </summary>
    /// <returns>return this instance and set other Light tween property</returns>
    public LightTweenProxy<TTween> intensity{ get{property = Property.intensity;  return this;}}
    /// <summary>
    /// Light.range tween. float type.
    /// </summary>
    /// <returns>return this instance and set other Light tween property</returns>
    public LightTweenProxy<TTween> range{ get{property = Property.range;  return this;}}
    /// <summary>
    /// Light.spotAngle tween. float type.
    /// </summary>
    /// <returns>return this instance and set other Light tween property</returns>
    public LightTweenProxy<TTween> spotAngle{ get{property = Property.spotAngle;  return this;}}


    //
    /// <summary>
    /// tween to the specified vector2 value.
    /// it will be start from the current value.
    /// </summary>
    /// <param name="v">to value.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween to(Vector2 v)
    {
        tween.addProperty(new TweenVector2Property(light, propertyStr).To(v));
        property = Property.None;
        return tween;
    }
    /// <summary>
    /// tween from the specified Vector2 value.
    /// it will be end from the current value.
    /// </summary>
    /// <param name="v">from Vector2 value.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween from(Vector2 v)
    {
        tween.addProperty(new TweenVector2Property(light, propertyStr).From(v));
        property = Property.None;
        return tween;
    }
    /// <summary>
    /// tween from the specified Vector2 and to the specified Vector2.
    /// </summary>
    /// <param name="f">from value.</param>
    /// <param name="t">to value.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween fromTo(Vector2 f,Vector2 t)
    {
        tween.addProperty(new TweenVector2Property(light, propertyStr).FromTo(f,t));
        property = Property.None;
        return tween;
    }
    /// <summary>
    /// tween offset by the specified Vector2.
    /// </summary>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween by(Vector2 v)
    {
        tween.addProperty(new TweenVector2Property(light, propertyStr).By(v));
        property = Property.None;
        return tween;
    }
    
    //
    /// <summary>
    /// tween to the specified color.
    /// it will be start from the current value.
    /// </summary>
    /// <param name="v">to color value.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween to(Color v)
    {
        tween.addProperty(new TweenColorProperty(light, propertyStr).To(v));
        property = Property.None;
        return tween;
    }
    /// <summary>
    /// tween from the specified color.
    /// it will be end from the current value.
    /// </summary>
    /// <param name="v">from value.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween from(Color v)
    {
        tween.addProperty(new TweenColorProperty(light, propertyStr).From(v));
        property = Property.None;
        return tween;
    }
    /// <summary>
    /// tween from the specified color and to the specified color.
    /// </summary>
    /// <param name="f">from value.</param>
    /// <param name="t">to value.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween fromTo(Color f,Color t)
    {
        tween.addProperty(new TweenColorProperty(light, propertyStr).FromTo(f,t));
        property = Property.None;
        return tween;
    }
    /// <summary>
    /// tween offset by the specified color.
    /// </summary>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween by(Color v)
    {
        tween.addProperty(new TweenColorProperty(light, propertyStr).By(v));
        property = Property.None;
        return tween;
    }
    
    //
    /// <summary>
    /// tween to the specified float.
    /// it will be start from the current value.
    /// </summary>
    /// <param name="v">to float value.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween to(float v)
    {
        tween.addProperty(new TweenFloatProperty(light, propertyStr).To(v));
        property = Property.None;
        return tween;
    }
    /// <summary>
    /// tween from the specified float.
    /// it will be end from the current value.
    /// </summary>
    /// <param name="v">from float value.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween from(float v)
    {
        tween.addProperty(new TweenFloatProperty(light, propertyStr).From(v));
        property = Property.None;
        return tween;
    }
    /// <summary>
    /// tween from the specified float and to the specified float.
    /// </summary>
    /// <param name="f">from float value.</param>
    /// <param name="t">to float value.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween fromTo(float f,float t)
    {
        tween.addProperty(new TweenFloatProperty(light, propertyStr).FromTo(f,t));
        property = Property.None;
        return tween;
    }
    /// <summary>
    /// tween offset by the specified float.
    /// </summary>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween by(float v)
    {
        tween.addProperty(new TweenFloatProperty(light, propertyStr).By(v));
        property = Property.None;
        return tween;
    }
}

/// <summary>
/// set the camera propertys.
/// </summary>
public class CameraTweenProxy<TTween> where TTween : Tween
{
    public TTween tween;

    //
    Camera camera;
    
    public CameraTweenProxy(TTween t)
    {
        camera = Tween.getComponent<Camera>(t.target);

        if (camera == null)
            Debug.LogError("Tween.target is not camera, target=" + t.target.GetType(), t.id as Object);

        tween = t;
    }
    public CameraTweenProxy(TTween t, Camera l)
    {
        camera = l;
        tween = t;
    }
    

    //
    enum Property
    {
        None,
        aspect,
        backgroundColor,
        depth,
        far,
        farClipPlane,
        fieldOfView,
        fov,
        near,
        nearClipPlane,
        orthographicSize,
        pixelRect,
        rect
    }
    Property property = Property.None;
    string propertyStr{get{return property.ToString();}}
    
    /// <summary>
    /// Camera.aspect tween. float type.
    /// </summary>
    /// <returns>return this instance and set other Camera tween property</returns>
    public CameraTweenProxy<TTween> aspect{ get{property = Property.aspect;  return this;}}
    /// <summary>
    /// Camera.backgroundColor tween. Color type.
    /// </summary>
    /// <returns>return this instance and set other Camera tween property</returns>
    public CameraTweenProxy<TTween> backgroundColor{ get{property = Property.backgroundColor;  return this;}}
    /// <summary>
    /// Camera.depth tween. float type.
    /// </summary>
    /// <returns>return this instance and set other Camera tween property</returns>
    public CameraTweenProxy<TTween> depth{ get{property = Property.depth;  return this;}}
    /// <summary>
    /// Camera.far tween. float type.
    /// </summary>
    /// <returns>return this instance and set other Camera tween property</returns>
    public CameraTweenProxy<TTween> far{ get{property = Property.far;  return this;}}
    /// <summary>
    /// Camera.farClipPlane tween. float type.
    /// </summary>
    /// <returns>return this instance and set other Camera tween property</returns>
    public CameraTweenProxy<TTween> farClipPlane{ get{property = Property.farClipPlane;  return this;}}
    /// <summary>
    /// Camera.fieldOfView tween. float type.
    /// </summary>
    /// <returns>return this instance and set other Camera tween property</returns>
    public CameraTweenProxy<TTween> fieldOfView{ get{property = Property.fieldOfView;  return this;}}
    /// <summary>
    /// Camera.fov tween. float type.
    /// </summary>
    /// <returns>return this instance and set other Camera tween property</returns>
    public CameraTweenProxy<TTween> fov{ get{property = Property.fov;  return this;}}
    /// <summary>
    /// Camera.fov near. float type.
    /// </summary>
    /// <returns>return this instance and set other Camera tween property</returns>
    public CameraTweenProxy<TTween> near{ get{property = Property.near;  return this;}}
    /// <summary>
    /// Camera.fov nearClipPlane. float type.
    /// </summary>
    /// <returns>return this instance and set other Camera tween property</returns>
    public CameraTweenProxy<TTween> nearClipPlane{ get{property = Property.nearClipPlane;  return this;}}
    /// <summary>
    /// Camera.fov orthographicSize. float type.
    /// </summary>
    /// <returns>return this instance and set other Camera tween property</returns>
    public CameraTweenProxy<TTween> orthographicSize{ get{property = Property.orthographicSize;  return this;}}
    /// <summary>
    /// Camera.fov pixelRect. Rect type.
    /// </summary>
    /// <returns>return this instance and set other Camera tween property</returns>
    public CameraTweenProxy<TTween> pixelRect{ get{property = Property.pixelRect;  return this;}}
    /// <summary>
    /// Camera.fov rect. Rect type.
    /// </summary>
    /// <returns>return this instance and set other Camera tween property</returns>
    public CameraTweenProxy<TTween> rect{ get{property = Property.rect;  return this;}}

    //
    /// <summary>
    /// tween to the specified color.
    /// it will be start from the current value.
    /// </summary>
    /// <param name="v">to color value.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween to(Color v)
    {
        tween.addProperty(new TweenColorProperty(camera, propertyStr).To(v));
        property = Property.None;
        return tween;
    }
    /// <summary>
    /// tween from the specified color.
    /// it will be end from the current value.
    /// </summary>
    /// <param name="v">from value.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween from(Color v)
    {
        tween.addProperty(new TweenColorProperty(camera, propertyStr).From(v));
        property = Property.None;
        return tween;
    }
    /// <summary>
    /// tween from the specified color and to the specified color.
    /// </summary>
    /// <param name="f">from value.</param>
    /// <param name="t">to value.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween fromTo(Color f,Color t)
    {
        tween.addProperty(new TweenColorProperty(camera, propertyStr).FromTo(f,t));
        property = Property.None;
        return tween;
    }
    /// <summary>
    /// tween offset by the specified color.
    /// </summary>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween by(Color v)
    {
        tween.addProperty(new TweenColorProperty(camera, propertyStr).By(v));
        property = Property.None;
        return tween;
    }
    
    //
    /// <summary>
    /// tween to the specified float.
    /// it will be start from the current value.
    /// </summary>
    /// <param name="v">to float value.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween to(float v)
    {
        tween.addProperty(new TweenFloatProperty(camera, propertyStr).To(v));
        property = Property.None;
        return tween;
    }
    /// <summary>
    /// tween from the specified float.
    /// it will be end from the current value.
    /// </summary>
    /// <param name="v">from float value.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween from(float v)
    {
        tween.addProperty(new TweenFloatProperty(camera, propertyStr).From(v));
        property = Property.None;
        return tween;
    }
    /// <summary>
    /// tween from the specified float and to the specified float.
    /// </summary>
    /// <param name="f">from float value.</param>
    /// <param name="t">to float value.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween fromTo(float f,float t)
    {
        tween.addProperty(new TweenFloatProperty(camera, propertyStr).FromTo(f,t));
        property = Property.None;
        return tween;
    }
    /// <summary>
    /// tween offset by the specified float.
    /// </summary>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween by(float v)
    {
        tween.addProperty(new TweenFloatProperty(camera, propertyStr).By(v));
        property = Property.None;
        return tween;
    }

    //
    /// <summary>
    /// tween to the specified Rect.
    /// it will be start from the current value.
    /// </summary>
    /// <param name="v">to Rect value.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween to(Rect v)
    {
        tween.addProperty(new TweenRectProperty(camera, propertyStr).To(v));
        property = Property.None;
        return tween;
    }
    /// <summary>
    /// tween from the specified Rect.
    /// it will be end from the current value.
    /// </summary>
    /// <param name="v">from Rect value.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween from(Rect v)
    {
        tween.addProperty(new TweenRectProperty(camera, propertyStr).From(v));
        property = Property.None;
        return tween;
    }
    /// <summary>
    /// tween from the specified Rect and to the specified Rect.
    /// </summary>
    /// <param name="f">from Rect value.</param>
    /// <param name="t">to Rect value.</param>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween fromTo(Rect f,Rect t)
    {
        tween.addProperty(new TweenRectProperty(camera, propertyStr).FromTo(f,t));
        property = Property.None;
        return tween;
    }
    /// <summary>
    /// tween offset by the specified Rect.
    /// </summary>
    /// <returns>return tween instance and set other tween property</returns>
    public TTween by(Rect v)
    {
        tween.addProperty(new TweenRectProperty(camera, propertyStr).By(v));
        property = Property.None;
        return tween;
    }
}


/// <summary>
/// set the tween equation.
/// </summary>
public class EquationTweenProxy<TTween>  where TTween : Tween
{
    public TTween tween;

    public EquationTweenProxy(TTween t)
    {
        tween = t;
    }

    public TTween linear{ get{tween.Equation(Equations.linear, false);  return tween;}}

    public TTween sin{ get{tween.Equation(Equations.sin, false);  return tween;}}
    public TTween sinOnePi{ get{tween.Equation(Equations.sinOnePi, false);  return tween;}}
    public TTween cos{ get{tween.Equation(Equations.cos, false);  return tween;}}
    public TTween cosOnePi{ get{tween.Equation(Equations.cosOnePi, false);  return tween;}}
    public TTween spring{ get{tween.Equation(Equations.spring, false);  return tween;}}

    public TTween inQuad{ get{tween.Equation(Equations.inQuad, false);  return tween;}}
    public TTween outQuad{ get{tween.Equation(Equations.outQuad, false);  return tween;}}
    public TTween inOutQuad{ get{tween.Equation(Equations.inOutQuad, false);  return tween;}}
    public TTween outInQuad{ get{tween.Equation(Equations.outInQuad, false);  return tween;}}

    public TTween inCubic{ get{tween.Equation(Equations.inCubic, false);  return tween;}}
    public TTween outCubic{ get{tween.Equation(Equations.outCubic, false);  return tween;}}
    public TTween inOutCubic{ get{tween.Equation(Equations.inOutCubic, false);  return tween;}}
    public TTween outInCubic{ get{tween.Equation(Equations.outInCubic, false);  return tween;}}

    public TTween inQuart{ get{tween.Equation(Equations.inQuart, false);  return tween;}}
    public TTween outQuart{ get{tween.Equation(Equations.outQuart, false);  return tween;}}
    public TTween inOutQuart{ get{tween.Equation(Equations.inOutQuart, false);  return tween;}}
    public TTween outInQuart{ get{tween.Equation(Equations.outInQuart, false);  return tween;}}

    public TTween inQuint{ get{tween.Equation(Equations.inQuint, false);  return tween;}}
    public TTween outQuint{ get{tween.Equation(Equations.outQuint, false);  return tween;}}
    public TTween inOutQuint{ get{tween.Equation(Equations.inOutQuint, false);  return tween;}}
    public TTween outInQuint{ get{tween.Equation(Equations.outInQuint, false);  return tween;}}

    public TTween inSine{ get{tween.Equation(Equations.inSine, false);  return tween;}}
    public TTween outSine{ get{tween.Equation(Equations.outSine, false);  return tween;}}
    public TTween inOutSine{ get{tween.Equation(Equations.inOutSine, false);  return tween;}}
    public TTween outInSine{ get{tween.Equation(Equations.outInSine, false);  return tween;}}

    public TTween inExpo{ get{tween.Equation(Equations.inExpo, false);  return tween;}}
    public TTween outExpo{ get{tween.Equation(Equations.outExpo, false);  return tween;}}
    public TTween inOutExpo{ get{tween.Equation(Equations.inOutExpo, false);  return tween;}}
    public TTween outInExpo{ get{tween.Equation(Equations.outInExpo, false);  return tween;}}

    public TTween inCirc{ get{tween.Equation(Equations.inCirc, false);  return tween;}}
    public TTween outCirc{ get{tween.Equation(Equations.outCirc, false);  return tween;}}
    public TTween inOutCirc{ get{tween.Equation(Equations.inOutCirc, false);  return tween;}}
    public TTween outInCirc{ get{tween.Equation(Equations.outInCirc, false);  return tween;}}

    public TTween inBounce{ get{tween.Equation(Equations.inBounce, false);  return tween;}}
    public TTween outBounce{ get{tween.Equation(Equations.outBounce, false);  return tween;}}
    public TTween inOutBounce{ get{tween.Equation(Equations.inOutBounce, false);  return tween;}}
    public TTween outInBounce{ get{tween.Equation(Equations.outInBounce, false);  return tween;}}

    public TTween inElastic{ get{tween.Equation(Equations.inElastic, false);  return tween;}}
    public TTween outElastic{ get{tween.Equation(Equations.outElastic, false);  return tween;}}
    public TTween inOutElastic{ get{tween.Equation(Equations.inOutElastic, false);  return tween;}}
    public TTween outInElastic{ get{tween.Equation(Equations.outInElastic, false);  return tween;}}

    public TTween inBack{ get{tween.Equation(Equations.inBack, false);  return tween;}}
    public TTween outBack{ get{tween.Equation(Equations.outBack, false);  return tween;}}
    public TTween inOutBack{ get{tween.Equation(Equations.inOutBack, false);  return tween;}}
    public TTween outInBack{ get{tween.Equation(Equations.outInBack, false);  return tween;}}

    public TTween inBack2 { get { tween.Equation(Equations.inBack2, false); return tween; } }
    public TTween outBack2 { get { tween.Equation(Equations.outBack2, false); return tween; } }
    public TTween inOutBack2 { get { tween.Equation(Equations.inOutBack2, false); return tween; } }
    public TTween outInBack2 { get { tween.Equation(Equations.outInBack2, false); return tween; } }

}

