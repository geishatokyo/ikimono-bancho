// Copyright (c) 2012 Xilin Chen (RN)
// Please direct any bugs/comments/suggestions to http://rntween.blogspot.com/

using UnityEngine;
using System.Reflection;
using System.Collections.Generic;

/// <summary>
/// base tween property class.
/// </summary>
public abstract class TweenProperty
{
    public Equations.Function _equation;

    //
    public void onTransition(float percentage)
    {
        onLerp(_equation(percentage, 0f, 1f));
    }
    public virtual void onLerp(float t) { }

    public abstract void setStartValueToTarget();

    public abstract void setDestValueToTarget();


    //
    public virtual float getTime(float velocity)
    {
        Debug.LogError("implement this function");
        return 0;
    }
}

public class TTweenProperty<T> : TweenProperty
{
    public object _target;

    public PropertyInfo _property;
    public T start;
    public T dest;

    public TTweenProperty(object target_, string property)
    {
        _target = target_;
        Property(property);
    }
    protected TTweenProperty(object target_)
    {
        _target = target_;
    }

    protected void Property(string property)
    {
        _property = _target.GetType().GetProperty(property, BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
        if (_property == null)
            Debug.LogError("can not find the property, property=" + property, _target as Object);
    }


    //
    public TweenProperty Equation(Equations.Function e)
    {
        _equation = e;
        return this;
    }

    //
    public TweenProperty From(T v)
    {
        dest = (T)_property.GetValue(_target, null);

        start = v;
        _property.SetValue(_target, start, null);
        return this;
    }
    public TweenProperty To(T v)
    {
        start = (T)_property.GetValue(_target, null);

        dest = v;
        return this;
    }
    public TweenProperty FromTo(T f, T t)
    {
        start = f;
        _property.SetValue(_target, start, null);

        dest = t;
        return this;
    }

    public TweenProperty From2(T v)
    {
        dest = (T)_property.GetValue(_target, null);

        start = v;
        return this;
    }
    public TweenProperty FromTo2(T f, T t)
    {
        start = f;
        dest = t;
        return this;
    }

    public T from
    {
        get { return (T)_property.GetValue(_target, null); }
    }
    public T to
    {
        get { return dest; }
    }


    //
    public override void setStartValueToTarget()
    {
        _property.SetValue(_target, start, null);
    }
    public override void setDestValueToTarget()
    {
        _property.SetValue(_target, dest, null);
    }
    protected void setValueToTarget(T v)
    {
        _property.SetValue(_target, v, null);
    }

}

public class TweenFloatProperty : TTweenProperty<float>
{
    public TweenFloatProperty(object target_, string property)
        : base(target_, property)
    {
    }
    protected TweenFloatProperty(object target_)
        : base(target_)
    {
    }
    protected TweenFloatProperty()
        : base(null)
    {
    }

    public override float getTime(float velocity)
    {
        return (this.dest - this.start) / velocity;
    }

    public TweenFloatProperty By(float v)
    {
        start = (float)_property.GetValue(_target, null);
        dest = start + v;
        return this;
    }
    public float dir
    {
        get { return dest - start; }
    }

    public override void onLerp(float t)
    {
        var v = Lerp.Float(start, dest, t);
        setValueToTarget(v);
    }
}

public class TweenDoubleProperty : TTweenProperty<double>
{
    public TweenDoubleProperty(object target_, string property)
        : base(target_, property)
    {
    }
    public override float getTime(float velocity)
    {
        return (float)(this.dest - this.start) / velocity;
    }

    public TweenDoubleProperty By(double v)
    {
        start = (double)_property.GetValue(_target, null);
        dest = start + v;
        return this;
    }
    public double dir
    {
        get { return dest - start; }
    }

    public override void onLerp(float t)
    {
        var v = Lerp.Double(start, dest, t);
        setValueToTarget(v);
    }

}

public class TweenVector2Property : TTweenProperty<Vector2>
{
    public TweenVector2Property(object target_, string property)
        : base(target_, property)
    {
    }
    protected TweenVector2Property()
        : base(null)
    {
    }

    public override float getTime(float velocity)
    {
        return (this.dest - this.start).magnitude / velocity;
    }

    public TweenVector2Property By(Vector2 v)
    {
        start = (Vector2)_property.GetValue(_target, null);
        dest = start + v;
        return this;
    }
    public Vector2 dir
    {
        get { return dest - start; }
    }

    public override void onLerp(float t)
    {
        var v = Lerp.Vector2(start, dest, t);
        setValueToTarget(v);
    }
}

public class TweenVector3Property : TTweenProperty<Vector3>
{
    public TweenVector3Property(object target_, string property)
        : base(target_, property)
    {
    }
    public override float getTime(float velocity)
    {
        return (this.dest - this.start).magnitude / velocity;
    }

    public TweenVector3Property By(Vector3 v)
    {
        start = (Vector3)_property.GetValue(_target, null);
        dest = start + v;
        return this;
    }
    public Vector3 dir
    {
        get { return dest - start; }
    }

    public override void onLerp(float t)
    {
        var v = Lerp.Vector3(start, dest, t);
        setValueToTarget(v);
    }
}

public class TweenVector3SlerpProperty : TTweenProperty<Vector3>
{
    public TweenVector3SlerpProperty(object target_, string property)
        : base(target_, property)
    {
    }
    public override float getTime(float velocity)
    {
        return (this.dest - this.start).magnitude / velocity;
    }

    public TweenVector3SlerpProperty AddToTween(Tween tween, float velocity)
    {
        tween.addProperty(this).Time((this.dest - this.start).magnitude / velocity);
        return this;
    }

    public TweenVector3SlerpProperty By(Vector3 v)
    {
        start = (Vector3)_property.GetValue(_target, null);
        dest = start + v;
        return this;
    }
    public Vector3 dir
    {
        get { return dest - start; }
    }

    public override void onLerp(float t)
    {
        var v = Vector3.Slerp(start, dest, t);//Lerp//Slerp//这两函数 t会限制在0~1的范围内
        setValueToTarget(v);
    }
}

public class TweenVector4Property : TTweenProperty<Vector4>
{
    public TweenVector4Property(object target_, string property)
        : base(target_, property)
    {
    }
    protected TweenVector4Property()
        : base(null)
    {
    }

    public override float getTime(float velocity)
    {
        return (this.dest - this.start).magnitude / velocity;
    }

    public TweenVector4Property By(Vector4 v)
    {
        start = (Vector4)_property.GetValue(_target, null);
        dest = start + v;
        return this;
    }
    public Vector4 dir
    {
        get { return dest - start; }
    }

    public override void onLerp(float t)
    {
        var v = Lerp.Vector4(start, dest, t);
        setValueToTarget(v);
    }

}

public class TweenQuaternionProperty : TTweenProperty<Quaternion>
{
    public TweenQuaternionProperty(object target_, string property)
        : base(target_, property)
    {
    }
    public TweenQuaternionProperty By(Quaternion v)
    {
        dest = start * v;
        return this;
    }

    public override void onLerp(float t)
    {
        var v = Quaternion.Lerp(start, dest, t);//Slerp//Lerp//这两函数 t会限制在0~1的范围内
        setValueToTarget(v);
    }
}

public class TweenQuaternionSlerpProperty : TTweenProperty<Quaternion>
{
    public TweenQuaternionSlerpProperty(object target_, string property)
        : base(target_, property)
    {
    }
    public TweenQuaternionSlerpProperty By(Quaternion v)
    {
        dest = start * v;
        return this;
    }

    public override void onLerp(float t)
    {
        var v = Quaternion.Slerp(start, dest, t);//Slerp//Lerp//这两函数 t会限制在0~1的范围内

        setValueToTarget(v);
    }

}

public class TweenRectProperty : TTweenProperty<Rect>
{
    public TweenRectProperty(object target_, string property)
        : base(target_, property)
    {
    }

    public TweenRectProperty By(Rect v)
    {
        start = (Rect)_property.GetValue(_target, null);
        dest = new Rect(start.x + v.x, start.y + v.y, start.width + v.width, start.height + v.height);
        return this;
    }

    public override void onLerp(float t)
    {
        var v = Lerp.Rect(start, dest, t);
        setValueToTarget(v);
    }
}

public class TweenColorProperty : TTweenProperty<Color>
{
    public TweenColorProperty(object target_, string property)
        : base(target_, property)
    {
    }
    protected TweenColorProperty()
        : base(null)
    {
    }
    
    public TweenColorProperty By(Color v)
    {
        start = (Color)_property.GetValue(_target, null);
        dest = start + v;
        return this;
    }

    public Color dir
    {
        get { return dest - start; }
    }


    public override void onLerp(float t)
    {
        var v = Lerp.Color(start, dest, t);
        setValueToTarget(v);
    }
}

public class TweenMaterialColorProperty : TweenColorProperty
{
    Material _material;
    string _matProperty;

    public TweenMaterialColorProperty(Material mat, string matProperty)
    {
        _material = mat;
        _target = this;
        Property("color");
        _matProperty = matProperty;
    }

    public Color color
    {
        get { return _material.GetColor(_matProperty); }
        set { _material.SetColor(_matProperty, value); }
    }
}

public class TweenMaterialsColorProperty : TweenColorProperty
{
    List<Material> _materials;
    string _matProperty;

    public TweenMaterialsColorProperty(List<Material> mats, string matProperty)
    {
        _materials = mats;
        _target = this;
        Property("color");
        _matProperty = matProperty;
    }

    public Color color
    {
        get 
        {
            return _materials[0].GetColor(_matProperty);
        }
        set 
        {
            foreach(var m in _materials)
                m.SetColor(_matProperty, value); 
        }
    }
}

public class TweenMaterialColorFloatProperty : TweenFloatProperty
{
    Material _material;
    string _matProperty;

    public TweenMaterialColorFloatProperty(Material mat, string matProperty, string colorProperty)
    {
        _material = mat;
        _target = this;
        Property(colorProperty);
        _matProperty = matProperty;
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

public class TweenMaterialsColorFloatProperty : TweenFloatProperty
{
    List<Material> _materials;
    string _matProperty;

    public TweenMaterialsColorFloatProperty(List<Material> mats, string matProperty, string colorProperty)
    {
        _materials = mats;
        _target = this;
        Property(colorProperty);
        _matProperty = matProperty;
    }

    public float a
    {
        get { return _materials[0].GetColor(_matProperty).a; }
        set
        {
            foreach (var m in _materials)
            {
                var c = m.GetColor(_matProperty);
                c.a = value;
                m.SetColor(_matProperty, c);
            }
        }
    }
    public float r
    {
        get { return _materials[0].GetColor(_matProperty).r; }
        set
        {
            foreach (var m in _materials)
            {
                var c = m.GetColor(_matProperty);
                c.r = value;
                m.SetColor(_matProperty, c);
            }
        }
    }
    public float g
    {
        get { return _materials[0].GetColor(_matProperty).g; }
        set
        {
            foreach (var m in _materials)
            {
                var c = m.GetColor(_matProperty);
                c.g = value;
                m.SetColor(_matProperty, c);
            }
        }
    }
    public float b
    {
        get { return _materials[0].GetColor(_matProperty).b; }
        set
        {
            foreach (var m in _materials)
            {
                var c = m.GetColor(_matProperty);
                c.b = value;
                m.SetColor(_matProperty, c);
            }
        }
    }
}

public class TweenMaterialFloatProperty : TweenFloatProperty
{
    Material _material;
    string _floatProperty;

    public TweenMaterialFloatProperty(Material mat, string floatProperty)
    {
        _material = mat;
        _target = this;
        Property("Value");
        _floatProperty = floatProperty;
    }

    public float Value
    {
        get { return _material.GetFloat(_floatProperty); }
        set
        {
            _material.SetFloat(_floatProperty, value);
        }
    }
}

public class TweenMaterialsFloatProperty : TweenFloatProperty
{
    List<Material> _materials;
    string _floatProperty;

    public TweenMaterialsFloatProperty(List<Material> mats, string floatProperty)
    {
        _materials = mats;
        _target = this;
        Property("Value");
        _floatProperty = floatProperty;
    }

    public float Value
    {
        get { return _materials[0].GetFloat(_floatProperty); }
        set
        {
            foreach(var m in _materials)
                m.SetFloat(_floatProperty, value);
        }
    }
}

public class TweenMaterialVector4Property : TweenVector4Property
{
    Material _material;
    string _vector4Property;

    public TweenMaterialVector4Property(Material mat, string vector4Property)
    {
        _material = mat;
        _target = this;
        Property("Value");
        _vector4Property = vector4Property;
    }

    public Vector4 Value
    {
        get { return _material.GetVector(_vector4Property); }
        set
        {
            _material.SetVector(_vector4Property, value);
        }
    }
}

public class TweenMaterialTextureOffsetProperty : TweenVector2Property
{
    Material _material;
    string _propertyTO;

    public TweenMaterialTextureOffsetProperty(Material mat, string property)
    {
        if (property == "mainTextureOffset")
        {
            _material = mat;
            _target = _material;
            Property("mainTextureOffset");
            _propertyTO = property;
        }
        else
        {
            _material = mat;
            _target = this;
            Property("Value");
            _propertyTO = property;
        }
    }

    public Vector2 Value
    {
        get { return _material.GetTextureOffset(_propertyTO); }
        set
        {
            _material.SetTextureOffset(_propertyTO, value);
        }
    }
}

public class TweenMaterialTextureScaleProperty : TweenVector2Property
{
    Material _material;
    string _propertyTS;

    public TweenMaterialTextureScaleProperty(Material mat, string property)
    {
        if (property == "mainTextureScale")
        {
            _material = mat;
            _target = _material;
            Property(property);
            _propertyTS = property;
        }
        else
        {
            _material = mat;
            _target = this;
            Property("Value");
            _propertyTS = property;
        }
    }

    public Vector2 Value
    {
        get { return _material.GetTextureScale(_propertyTS); }
        set
        {
            _material.SetTextureScale(_propertyTS, value);
        }
    }
}

public class TweenTransformFloatProperty : TweenFloatProperty
{
    Transform _transform;

    public TweenTransformFloatProperty(Transform target_, string floatProperty)
        : base(null)
    {
        _transform = target_;
        _target = this;
        Property(floatProperty);
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