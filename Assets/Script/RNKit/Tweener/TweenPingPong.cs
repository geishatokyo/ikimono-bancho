// Copyright (c) 2012 Xilin Chen (RN)
// Please direct any bugs/comments/suggestions to http://rntween.blogspot.com/

using UnityEngine;
using System.Collections;


/// <summary>
/// TweenPingPong
/// 
///     //example
///     new TweenPingPong(Camera.main.transform, 1.0f, 0.0f)
///         .equation.outQuint
///         .transform.position.to(new Vector3(0,1,0))
///         .play();
/// 
/// </summary>
[System.Serializable]
public class TweenPingPong : Tween
{
    /// <summary>
    /// Initializes a new tween of the <see cref="Tween"/> class.
    /// </summary>
    public TweenPingPong()
        : base()
    {
        halfTime = time * 0.5f;

        completeHandle = CompleteHandle.AutoSetValue;
    }

    /// <summary>
    /// Initializes a new TweenPingPong.
    /// </summary>
    /// <param name="target">The target.</param>
    /// <param name="time">The time.</param>
    /// <param name="delay">The delay time.</param>
    public TweenPingPong(object target, float time, float delay /*= 0.0f*/)
        : base(target, time, delay)
    {
        halfTime = time * 0.5f;

        completeHandle = CompleteHandle.AutoSetValue;
    }

    /// <summary>
    /// Initializes a new TweenPingPong.
    /// </summary>
    /// <param name="target">The target.</param>
    /// <param name="info">The TweenPingPong's initialization information.</param>
    public TweenPingPong(object target, Info info)
        : base(target, info)
    {
        halfTime = info.time * 0.5f;
        completeHandle = CompleteHandle.AutoSetValue;
    }


    //
    /// <summary>
    /// set tween id.
    /// </summary>
    /// <param name="id_">The id_.</param>
    /// <returns>return this instance and set other tween property.</returns>
    public new TweenPingPong Id(object id_)
    {
        id = id_;
        return this;
    }

    //
    /// <summary>
    /// Gets the equation proxy and set equation function.
    /// </summary>
    public new EquationTweenProxy<TweenPingPong> equation
    {
        get { return new EquationTweenProxy<TweenPingPong>(this); }
    }
    /// <summary>
    /// Gets the object proxy and set object tween info.
    /// </summary>
    public new ObjectTweenProxy<TweenPingPong> obj
    {
        get { return new ObjectTweenProxy<TweenPingPong>(this); }
    }
    /// <summary>
    /// Gets the transform proxy and set transform tween info.
    /// </summary>
    public new TransformTweenProxy<TweenPingPong> transform
    {
        get { return new TransformTweenProxy<TweenPingPong>(this); }
    }
    /// <summary>
    /// Gets the material proxy and set material tween info.
    /// </summary>
    public new MaterialTweenProxy<TweenPingPong> material
    {
        get { return new MaterialTweenProxy<TweenPingPong>(this); }
    }
    /// <summary>
    /// Gets the materials proxy and set materials tween info.
    /// Set tween info to all the children's materials.
    /// </summary>
    public new MaterialsTweenProxy<TweenPingPong> materials
    {
        get { return new MaterialsTweenProxy<TweenPingPong>(this, null, false); }
    }
    /// <summary>
    /// Gets the audio proxy and set audio tween info.
    /// </summary>
    public new AudioSourceTweenProxy<TweenPingPong> audio
    {
        get { return new AudioSourceTweenProxy<TweenPingPong>(this); }
    }
    /// <summary>
    /// Gets the light proxy and set light tween info.
    /// </summary>
    public new LightTweenProxy<TweenPingPong> light
    {
        get { return new LightTweenProxy<TweenPingPong>(this); }
    }
    /// <summary>
    /// Gets the camera proxy and set camera tween info.
    /// </summary>
    public new CameraTweenProxy<TweenPingPong> camera
    {
        get { return new CameraTweenProxy<TweenPingPong>(this); }
    }

    /// <summary>
    /// Gets the object proxy and set object tween info.
    /// </summary>
    /// <param name="o">The other object.</param>
    public new ObjectTweenProxy<TweenPingPong> Obj(object o)
    {
        return new ObjectTweenProxy<TweenPingPong>(this, o);
    }
    /// <summary>
    /// Gets the transform proxy and set transform tween info.
    /// </summary>
    /// <param name="t">The other transform.</param>
    public new TransformTweenProxy<TweenPingPong> Transform(Transform t)
    {
        return new TransformTweenProxy<TweenPingPong>(this, t);
    }
    /// <summary>
    /// Gets the material proxy and set material tween info.
    /// </summary>
    /// <param name="m">The other material.</param>
    public new MaterialTweenProxy<TweenPingPong> Material(Material m)
    {
        return new MaterialTweenProxy<TweenPingPong>(this, m);
    }
    /// <summary>
    /// Gets the material proxy and set material tween info.
    /// </summary>
    /// <param name="m">The other component's material.</param>
    public new MaterialTweenProxy<TweenPingPong> Material(Component c)
    {
        return new MaterialTweenProxy<TweenPingPong>(this, c.renderer.material);
    }
    /// <summary>
    /// Gets the materials proxy and set materials tween info.
    /// Set tween info to the children's materials by the names.
    /// </summary>
    /// <param name="t">The transform. use target object if t is null.</param>
    /// <param name="names">The names. find the game object name.</param>
    /// <returns></returns>
    public new MaterialsTweenProxy<TweenPingPong> Materials(Transform t, params string[] names)
    {
        return new MaterialsTweenProxy<TweenPingPong>(this, t, false, names);
    }
    /// <summary>
    /// Gets the materials proxy and set materials tween info.
    /// Set tween info to the children's materials by the names.
    /// </summary>
    /// <param name="names">The names. find the game object name.</param>
    /// <returns></returns>
    public new MaterialsTweenProxy<TweenPingPong> Materials(params string[] names)
    {
        return new MaterialsTweenProxy<TweenPingPong>(this, null, false, names);
    }
    /// <summary>
    /// Gets the audio proxy and set audio tween info.
    /// </summary>
    /// <param name="t">The other audio.</param>
    public new AudioSourceTweenProxy<TweenPingPong> Audio(AudioSource a)
    {
        return new AudioSourceTweenProxy<TweenPingPong>(this, a);
    }
    /// <summary>
    /// Gets the audio proxy and set audio tween info.
    /// </summary>
    /// <param name="t">The other component's audio.</param>
    public new AudioSourceTweenProxy<TweenPingPong> Audio(Component c)
    {
        return new AudioSourceTweenProxy<TweenPingPong>(this, c.audio);
    }
    /// <summary>
    /// Gets the light proxy and set light tween info.
    /// </summary>
    /// <param name="l">The other light.</param>
    public new LightTweenProxy<TweenPingPong> Light(Light l)
    {
        return new LightTweenProxy<TweenPingPong>(this, l);
    }
    /// <summary>
    /// Gets the light proxy and set light tween info.
    /// </summary>
    /// <param name="l">The other component's light.</param>
    public new LightTweenProxy<TweenPingPong> Light(Component c)
    {
        return new LightTweenProxy<TweenPingPong>(this, c.light);
    }
    /// <summary>
    /// Gets the camera proxy and set camera tween info.
    /// </summary>
    /// <param name="l">The other component's light.</param>
    public new CameraTweenProxy<TweenPingPong> Camera(Camera c)
    {
        return new CameraTweenProxy<TweenPingPong>(this, c);
    }
    /// <summary>
    /// Gets the camera proxy and set camera tween info.
    /// </summary>
    /// <param name="l">The other component's light.</param>
    public new CameraTweenProxy<TweenPingPong> Camera(Component c)
    {
        return new CameraTweenProxy<TweenPingPong>(this, c.camera);
    }



    /// <summary>
    /// Play this tween.
    /// Play success if has no the same old tween
    /// </summary>
    /// <returns>return this instance and set other tween property.</returns>
    public new TweenPingPong play()
    {
        return play(TweenerManager.tweener);
    }
    /// <summary>
    /// Play this tween and replace old tween by the same id.
    /// </summary>
    /// <returns>return this instance and set other tween property.</returns>
    public new TweenPingPong playAndReplace()
    {
        return playAndReplace(TweenerManager.tweener);
    }
    /// <summary>
    /// Play this tween.
    /// Play success if has no the same old tween
    /// </summary>
    /// <param name="tweener">the specified tweener manager.</param>
    /// <returns>return this instance and set other tween property.</returns>
    public new TweenPingPong play(Tweener tweener)
    {
        base.play(tweener);
        return this;
    }
    /// <summary>
    /// Play this tween and replace old tween by the same id.
    /// </summary>
    /// <param name="tweener">the specified tweener manager.</param>
    /// <returns>return this instance and set other tween property.</returns>
    public new TweenPingPong playAndReplace(Tweener tweener)
    {
        base.playAndReplace(tweener);
        return this;
    }



#region Private

    float halfTime;

    //
    protected override float _timeTransform(float curr_time_)
    {
        if (curr_time_ <= halfTime)
            return curr_time_ * 2;

        return (time - curr_time_) * 2;
    }


    public override bool _finished()
    {
        base._finished();

        if (completeHandle == CompleteHandle.AutoSetValue)
        {
            foreach (TweenProperty pd in _propertyList)
            {
                pd.setStartValueToTarget();
            }
        }
        else if (completeHandle == CompleteHandle.DestValue)
        {
            foreach (TweenProperty tp in _propertyList)
            {
                tp.setDestValueToTarget();
            }
        }
        else if (completeHandle == CompleteHandle.StartValue)
        {
            foreach (TweenProperty tp in _propertyList)
            {
                tp.setStartValueToTarget();
            }
        }

        return true;
    }


    //
#if UNITY_EDITOR
    public override void _logDebug(string msg)
    {
        Debug.LogWarning(msg + ", target=" + _debugName/* + "  target.HashCode=" + target.GetHashCode()*/, target as Object);
    }
#endif

#endregion
}