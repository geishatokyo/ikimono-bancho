// Copyright (c) 2012 Xilin Chen (RN)
// Please direct any bugs/comments/suggestions to http://rntween.blogspot.com/

using UnityEngine;


public class TweenFilterFloatProperty : TweenFloatProperty
{
    public TweenFilterFloatProperty(object target_, string property)
        : base(target_, property)
    {
    }
    public override void onLerp(float t)
    {
        var v = Lerp.Float(start, dest, t);
        setValueToTarget(from + v);
    }

    public override void setStartValueToTarget() { }
    public override void setDestValueToTarget() { }
}

public class TweenDynamicFilterFloatProperty : TweenFloatProperty
{
    public System.Func<float> toFunc;


    public TweenDynamicFilterFloatProperty(object target_, string property)
        : base(target_, property)
    {
        Property(property);
    }

    public TweenDynamicFilterFloatProperty FromTo(float f, System.Func<float> t)
    {
        start = f;
        toFunc = t;
        return this;
    }

    public override void onLerp(float t)
    {
        var v = Lerp.Float(start, toFunc(), t);
        setValueToTarget(from + v);
    }

    public override void setStartValueToTarget() { }
    public override void setDestValueToTarget() { }
}

public class TweenFilterDoubleProperty : TweenDoubleProperty
{
    public TweenFilterDoubleProperty(object target_, string property)
        : base(target_, property)
    {
    }
    public override void onLerp(float t)
    {
        var v = Lerp.Double(start, dest, t);
        setValueToTarget(from + v);
    }

    public override void setStartValueToTarget() { }
    public override void setDestValueToTarget() { }
}

public class TweenFilterVector2Property : TweenVector2Property
{
    public TweenFilterVector2Property(object target_, string property)
        : base(target_, property)
    {
    }
    public override void onLerp(float t)
    {
        var v = Lerp.Vector2(start, dest, t);
        setValueToTarget(from + v);
    }

    public override void setStartValueToTarget() { }
    public override void setDestValueToTarget() { }
}

public class TweenFilterVector3Property : TweenVector3Property
{
    public TweenFilterVector3Property(object target_, string property)
        : base(target_, property)
    {
    }
    public override void onLerp(float t)
    {
        var v = Lerp.Vector3(start, dest, t);
        setValueToTarget(from + v);
    }

    public override void setStartValueToTarget() { }
    public override void setDestValueToTarget() { }

}

public class TweenDynamicFilterVector3Property : TweenVector3Property
{
    public System.Func<Vector3> toFunc;


    public TweenDynamicFilterVector3Property(object target_, string property)
        : base(target_, property)
    {
        Property(property);
    }

    public TweenDynamicFilterVector3Property FromTo(Vector3 f, System.Func<Vector3> t)
    {
        start = f;
        toFunc = t;
        return this;
    }

    public override void onLerp(float t)
    {
        var v = Lerp.Vector3(start, toFunc(), t);
        setValueToTarget(from + v);
    }

    public override void setStartValueToTarget() { }
    public override void setDestValueToTarget() { }
}
public class TweenDynamicFilterQuaternionProperty : TweenQuaternionProperty
{
    public System.Func<Quaternion> toFunc;


    public TweenDynamicFilterQuaternionProperty(object target_, string property)
        : base(target_, property)
    {
        Property(property);
    }

    public TweenDynamicFilterQuaternionProperty FromTo(Quaternion f, System.Func<Quaternion> t)
    {
        start = f;
        toFunc = t;
        return this;
    }

    public override void onLerp(float t)
    {
        var v = Quaternion.Lerp(start, toFunc(), t);
        setValueToTarget(from * v);
    }

    public override void setStartValueToTarget() { }
    public override void setDestValueToTarget() { }
}

public class TweenFilterVector3SlerpProperty : TweenVector3SlerpProperty
{
    public TweenFilterVector3SlerpProperty(object target_, string property)
        : base(target_, property)
    {
    }
    public override void onLerp(float t)
    {
        var v = Vector3.Slerp(start, dest, t);
        setValueToTarget(from + v);
    }

    public override void setStartValueToTarget() { }
    public override void setDestValueToTarget() { }
}

public class TweenFilterVector4Property : TweenVector4Property
{
    public TweenFilterVector4Property(object target_, string property)
        : base(target_, property)
    {
    }
    public override void onLerp(float t)
    {
        var v = Lerp.Vector4(start, dest, t);
        setValueToTarget(from + v);
    }

    public override void setStartValueToTarget() { }
    public override void setDestValueToTarget() { }
}

public class TweenFilterQuaternionProperty : TweenQuaternionProperty
{
    public TweenFilterQuaternionProperty(object target_, string property)
        : base(target_, property)
    {
    }
    public override void onLerp(float t)
    {
        var v = Quaternion.Lerp(start, dest, t);

        setValueToTarget(from * v);
    }

    public override void setStartValueToTarget() { }
    public override void setDestValueToTarget() { }
}

public class TweenFilterQuaternionSlerpProperty : TweenQuaternionSlerpProperty
{
    public TweenFilterQuaternionSlerpProperty(object target_, string property)
        : base(target_, property)
    {
    }
    public override void onLerp(float t)
    {
        var v = Quaternion.Slerp(start, dest, t);

        setValueToTarget(from * v);
    }

    public override void setStartValueToTarget() { }
    public override void setDestValueToTarget() { }
}

public class TweenFilterRectProperty : TweenRectProperty
{
    public TweenFilterRectProperty(object target_, string property)
        : base(target_, property)
    {
    }
    public override void onLerp(float t)
    {
        var v = Lerp.Rect(start, dest, t);

        Rect p = from;
        v = new Rect(p.x + v.x, p.y + v.y, p.width + v.width, p.height + v.height);

        setValueToTarget(v);
    }

    public override void setStartValueToTarget() { }
    public override void setDestValueToTarget() { }
}

public class TweenFilterColorProperty : TweenColorProperty
{
    public TweenFilterColorProperty(object target_, string property)
        : base(target_, property)
    {
    }
    public override void onLerp(float t)
    {
        var v = Lerp.Color(start, dest, t);
        setValueToTarget(from + v);
    }

    public override void setStartValueToTarget() { }
    public override void setDestValueToTarget() { }
}

public class TweenFilterMaterialColorProperty : TweenMaterialColorProperty
{
    public TweenFilterMaterialColorProperty(Material target_, string property)
        : base(target_, property)
    {
    }
    public override void onLerp(float t)
    {
        var v = Lerp.Color(start, dest, t);
        setValueToTarget(from + v);
    }

    public override void setStartValueToTarget() { }
    public override void setDestValueToTarget() { }
}

public class TweenFilterMaterialColorFloatProperty : TweenMaterialColorFloatProperty
{
    public TweenFilterMaterialColorFloatProperty(Material target_, string matProperty, string colorProperty)
        : base(target_, matProperty, colorProperty)
    {
    }
    public override void onLerp(float t)
    {
        var v = Lerp.Float(this.start, this.dest, t);
        setValueToTarget(from + v);
    }

    public override void setStartValueToTarget() { }
    public override void setDestValueToTarget() { }
}

public class TweenFilterTransformFloatProperty : TweenTransformFloatProperty
{
    public TweenFilterTransformFloatProperty(Transform target_, string floatProperty)
        : base(target_, floatProperty)
    {
    }
    public override void onLerp(float t)
    {
        var v = Lerp.Float(this.start, this.dest, t);
        setValueToTarget(from + v);
    }

    public override void setStartValueToTarget() { }
    public override void setDestValueToTarget() { }
}

public class TweenDynamicFilterTransformFloatProperty : TweenTransformFloatProperty
{
    public System.Func<float> toFunc;

    public TweenDynamicFilterTransformFloatProperty(Transform target_, string floatProperty)
        : base(target_, floatProperty)
    {
    }

    public TweenDynamicFilterTransformFloatProperty FromTo(float f, System.Func<float> t)
    {
        start = f;
        toFunc = t;
        return this;
    }

    public override void onLerp(float t)
    {
        var v = Lerp.Float(this.start, toFunc(), t);
        setValueToTarget(from + v);
    }

    public override void setStartValueToTarget() { }
    public override void setDestValueToTarget() { }
}

