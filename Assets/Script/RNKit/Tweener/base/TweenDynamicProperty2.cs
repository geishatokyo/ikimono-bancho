// Copyright (c) 2012 Xilin Chen (RN)
// Please direct any bugs/comments/suggestions to http://rntween.blogspot.com/

using UnityEngine;
using System.Reflection;


public class TTweenDynamicProperty2<T, TDerive> : TweenProperty where TDerive : class
{
    public object _target;
    public PropertyInfo _property;

    public T start;
    System.Func<T> _startValue = null;

    public T dest;
    System.Func<T> _destValue = null;


    public TTweenDynamicProperty2(object target, string property)
    {
        _target = target;
        _property = getProperty(_target, property);
    }
    protected TTweenDynamicProperty2(object target)
    {
        _target = target;
    }

    protected PropertyInfo getProperty(object target, string property)
    {
        var pi = target.GetType().GetProperty(property, BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
        if (pi == null)
            Debug.LogError("can not find property,  property=" + property, target as Object);
        return pi;
    }

    //
    public TDerive DynamicFrom(System.Func<T> startValue)
    {
        _startValue = startValue;
        return this as TDerive;
    }
    public TDerive DynamicTo(System.Func<T> destValue)
    {
        _destValue = destValue;
        return this as TDerive;
    }

    public TDerive From(T v)
    {
        start = v;
        _property.SetValue(_target, start, null);
        return this as TDerive;
    }
    public TDerive To(T v)
    {
        dest = v;
        return this as TDerive;
    }
    public TDerive From()
    {
        start = (T)_property.GetValue(_target, null);
        return this as TDerive;
    }
    public TDerive To()
    {
        dest = (T)_property.GetValue(_target, null);
        return this as TDerive;
    }

    public T from
    {
        get
        {
            if (_startValue != null)
                return (T)_startValue();
            return (T)start; 
        }
    }
    public T to
    {
        get
        {
            if (_destValue != null)
                return (T)_destValue();
            return dest;
        }
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
    protected void setValueToTarget(T v)
    {
        _property.SetValue(_target, v, null);
    }

}

public class TweenDynamicFloatProperty2 : TTweenDynamicProperty2<float, TweenDynamicFloatProperty2>
{
    public TweenDynamicFloatProperty2(object target, string property)
        : base(target, property)
    {
    }

    protected TweenDynamicFloatProperty2()
        : base(null)
    {
    }

    public override float getTime(float velocity)
    {
        return (to - from) / velocity;
    }

    public override void onLerp(float t)
    {
        var v = Lerp.Float(from, to, t);
        setValueToTarget(v);
    }
}

public class TweenDynamicDoubleProperty2 : TTweenDynamicProperty2<double, TweenDynamicDoubleProperty2>
{
    public TweenDynamicDoubleProperty2(object target, string property)
        : base(target, property)
    {
    }

    public override float getTime(float velocity)
    {
        return (float)(to - from) / velocity;
    }

    public override void onLerp(float t)
    {
        var v = Lerp.Double(from, to, t);
        setValueToTarget(v);
    }
}

public class TweenDynamicVector2Property2 : TTweenDynamicProperty2<Vector2, TweenDynamicVector2Property2>
{
    public TweenDynamicVector2Property2(object target, string property)
        : base(target, property)
    {
    }
    
    public override float getTime(float velocity)
    {
        return (to - from).magnitude / velocity;
    }

    public override void onLerp(float t)
    {
        var v = Lerp.Vector2(from, to, t);
        setValueToTarget(v);
    }
}

public class TweenDynamicVector3Property2 : TTweenDynamicProperty2<Vector3, TweenDynamicVector3Property2>
{
    public TweenDynamicVector3Property2(object target, string property)
        : base(target, property)
    {
    }

    public override float getTime(float velocity)
    {
        return (to - from).magnitude / velocity;
    }

    public override void onLerp(float t)
    {
        var v = Lerp.Vector3(from, to, t);
        setValueToTarget(v);
    }
}

public class TweenDynamicVector3SlerpProperty2 : TTweenDynamicProperty2<Vector3, TweenDynamicVector3SlerpProperty2>
{
    public TweenDynamicVector3SlerpProperty2(object target, string property)
        : base(target, property)
    {
    }

    public override float getTime(float velocity)
    {
        return (to - from).magnitude / velocity;
    }

    public override void onLerp(float t)
    {
        var v = Vector3.Slerp(from, to, t);//Lerp//Slerp//这两函数 t会限制在0~1的范围内
        setValueToTarget(v);
    }
}

public class TweenDynamicVector4Property2 : TTweenDynamicProperty2<Vector4, TweenDynamicVector4Property2>
{
    public TweenDynamicVector4Property2(object target, string property)
        : base(target, property)
    {
    }

    public override float getTime(float velocity)
    {
        return (to - from).magnitude / velocity;
    }

    public override void onLerp(float t)
    {
        var v = Lerp.Vector4(from, to, t);
        setValueToTarget(v);
    }
}

public class TweenDynamicQuaternionProperty2 : TTweenDynamicProperty2<Quaternion, TweenDynamicQuaternionProperty2>
{
    public TweenDynamicQuaternionProperty2(object target, string property)
        : base(target, property)
    {
    }

    public override void onLerp(float t)
    {
        var v = Quaternion.Lerp(from, to, t);//Slerp//Lerp//这两函数 t会限制在0~1的范围内
        setValueToTarget(v);
    }
}

public class TweenDynamicQuaternionSlerpProperty2 : TTweenDynamicProperty2<Quaternion, TweenDynamicQuaternionSlerpProperty2>
{
    public TweenDynamicQuaternionSlerpProperty2(object target, string property)
        : base(target, property)
    {
    }

    public override void onLerp(float t)
    {
        var v = Quaternion.Slerp(from, to, t);//Slerp//Lerp//这两函数 t会限制在0~1的范围内
        setValueToTarget(v);
    }
}

public class TweenDynamicRectProperty2 : TTweenDynamicProperty2<Rect, TweenDynamicRectProperty2>
{
    public TweenDynamicRectProperty2(object target, string property)
        : base(target, property)
    {
    }

    public override void onLerp(float t)
    {
        var v = Lerp.Rect(from, to, t);
        setValueToTarget(v);
    }
}

public class TweenDynamicColorProperty2 : TTweenDynamicProperty2<Color, TweenDynamicColorProperty2>
{
    public TweenDynamicColorProperty2(object target, string property)
        : base(target, property)
    {
    }
    public TweenDynamicColorProperty2()
        : base(null)
    {
    }

    public override void onLerp(float t)
    {
        var v = Lerp.Color(from, to, t);
        setValueToTarget(v);
    }

}

public class TweenDynamicMaterialColorProperty2 : TweenDynamicColorProperty2
{
    Material _material;
    string _matProperty;

    public TweenDynamicMaterialColorProperty2(Material target, string property)
        : base()
    {
        if (target == null)
            Debug.LogError("target == null", target);


        _material = target;
        _target = this;
        //Property("color");
        _property = getProperty(_target, "color");
        _matProperty = property;
    }

    public TweenDynamicMaterialColorProperty2(Material target, string property, Color start_, Color dest_)
        : base()
    {
        if (target == null)
            Debug.LogError("target == null", target);


        _material = target;
        _target = this;
        //Property("color");
        _property = getProperty(_target, "color");
        _matProperty = property;

        start = start_;
        dest = dest_;
    }

    public Color color
    {
        get { return _material.GetColor(_matProperty); }
        set { _material.SetColor(_matProperty, value); }
    }
}

public class TweenDynamicMaterialColorFloatProperty2 : TweenDynamicFloatProperty2
{

    Material _material;
    string _matProperty;

    public TweenDynamicMaterialColorFloatProperty2(Material target, string matProperty, string colorProperty)
        : base()
    {
        if (target == null)
            Debug.LogError("target == null", target);


        _material = target;
        _target = this;
        //Property(colorProperty);
        _property = getProperty(_target, colorProperty);
        _matProperty = matProperty;
    }
    public TweenDynamicMaterialColorFloatProperty2(Material target, string matProperty, string colorProperty, float start_, float dest_)
        : base()
    {
        if (target == null)
            Debug.LogError("target == null", target);


        _material = target;
        _target = this;
        //Property(colorProperty);
        _property = getProperty(_target, colorProperty);
        _matProperty = matProperty;

        start = start_;
        dest = dest_;
    }


    public float a
    {
        get { return _material.GetColor(_matProperty).a; }
        set
        {
            var c = _material.GetColor(_matProperty);
            c.a = value;
            _material.SetColor(_matProperty, c);
        }
    }
    public float r
    {
        get { return _material.GetColor(_matProperty).r; }
        set
        {
            var c = _material.GetColor(_matProperty);
            c.r = value;
            _material.SetColor(_matProperty, c);
        }
    }
    public float g
    {
        get { return _material.GetColor(_matProperty).g; }
        set
        {
            var c = _material.GetColor(_matProperty);
            c.g = value;
            _material.SetColor(_matProperty, c);
        }
    }
    public float b
    {
        get { return _material.GetColor(_matProperty).b; }
        set
        {
            var c = _material.GetColor(_matProperty);
            c.b = value;
            _material.SetColor(_matProperty, c);
        }
    }
}

public class TweenDynamicTransformFloatProperty2 : TweenDynamicFloatProperty2
{

    Transform _transform;

    public TweenDynamicTransformFloatProperty2(Transform target, string floatProperty)
        : base()
    {
        if (target == null)
            Debug.LogError("target == null", target);

        _transform = target;
        _target = this;
        //Property(floatProperty);
        _property = getProperty(_target, floatProperty);
    }
    public TweenDynamicTransformFloatProperty2(Transform target, string floatProperty, float start_, float dest_)
        : base()
    {
        if (target == null)
            Debug.LogError("target == null", target);


        _transform = target;
        _target = this;
        //Property(floatProperty);
        _property = getProperty(_target, floatProperty);

        start = start_;
        dest = dest_;
    }


    //
    public float positionx
    {
        get { return _transform.position.x; }
        set
        {
            var v = _transform.position;
            v.x = value;
            _transform.position = v;
        }
    }
    public float positiony
    {
        get { return _transform.position.y; }
        set
        {
            var v = _transform.position;
            v.y = value;
            _transform.position = v;
        }
    }
    public float positionz
    {
        get { return _transform.position.z; }
        set
        {
            var v = _transform.position;
            v.z = value;
            _transform.position = v;
        }
    }

    //
    public float localPositionx
    {
        get { return _transform.localPosition.x; }
        set
        {
            var v = _transform.localPosition;
            v.x = value;
            _transform.localPosition = v;
        }
    }
    public float localPositiony
    {
        get { return _transform.localPosition.y; }
        set
        {
            var v = _transform.localPosition;
            v.y = value;
            _transform.localPosition = v;
        }
    }
    public float localPositionz
    {
        get { return _transform.localPosition.z; }
        set
        {
            var v = _transform.localPosition;
            v.z = value;
            _transform.localPosition = v;
        }
    }

    //
    public float eulerAnglesx
    {
        get { return _transform.eulerAngles.x; }
        set
        {
            var v = _transform.localEulerAngles;
            v.x = value;
            _transform.localEulerAngles = v;
        }
    }
    public float eulerAnglesy
    {
        get { return _transform.localEulerAngles.y; }
        set
        {
            var v = _transform.localEulerAngles;
            v.y = value;
            _transform.localEulerAngles = v;
        }
    }
    public float eulerAnglesz
    {
        get { return _transform.localEulerAngles.z; }
        set
        {
            var v = _transform.localEulerAngles;
            v.z = value;
            _transform.localEulerAngles = v;
        }
    }

    //
    public float localEulerAnglesx
    {
        get { return _transform.localEulerAngles.x; }
        set
        {
            var v = _transform.localEulerAngles;
            v.x = value;
            _transform.localEulerAngles = v;
        }
    }
    public float localEulerAnglesy
    {
        get { return _transform.localEulerAngles.y; }
        set
        {
            var v = _transform.localEulerAngles;
            v.y = value;
            _transform.localEulerAngles = v;
        }
    }
    public float localEulerAnglesz
    {
        get { return _transform.localEulerAngles.z; }
        set
        {
            var v = _transform.localEulerAngles;
            v.z = value;
            _transform.localEulerAngles = v;
        }
    }

    //
    public float localScalex
    {
        get { return _transform.localScale.x; }
        set
        {
            var v = _transform.localScale;
            v.x = value;
            _transform.localScale = v;
        }
    }
    public float localScaley
    {
        get { return _transform.localScale.y; }
        set
        {
            var v = _transform.localScale;
            v.y = value;
            _transform.localScale = v;
        }
    }
    public float localScalez
    {
        get { return _transform.localScale.z; }
        set
        {
            var v = _transform.localScale;
            v.z = value;
            _transform.localScale = v;
        }
    }
}
