// Copyright (c) 2012 Xilin Chen (RN)
// Please direct any bugs/comments/suggestions to http://rntween.blogspot.com/

using UnityEngine;
using System.Collections;


/// <summary>
/// TweenLoop
/// this tween can loop play.
/// 
///     //example
///     new TweenLoop(cube, 1, 0, -1, true)
///     
///         .equation.inOutCubic
///         .material.MainColor.to(Color.black)
///         .material.SpecularColor.r.to(0.0f)
///         .Material(cube.renderer.material).Shininess.fromTo(0.01f, 1f)
///     
///         .equation.outCubic
///         .material.Color("_ReflectColor").to(Color.white)
///     
///         .play();
/// 
/// 
/// </summary>
[System.Serializable]
public class TweenLoop : Tween
{
    /// <summary>
    /// Initializes a new tween of the <see cref="Tween"/> class.
    /// </summary>
    public TweenLoop()
        : base()
    {
        isPingPonging = false;

        completeHandle = CompleteHandle.AutoSetValue;
    }


    /// <summary>
    /// Initializes a new TweenLoop.
    /// </summary>
    /// <param name="target">The target object.</param>
    /// <param name="time">The time.</param>
    /// <param name="delay">The delay time.</param>
    /// <param name="loopCount_">The loop count.</param>
    /// <param name="pingPong_">if set to <c>true</c> [ping pong_].</param>
    public TweenLoop(object target, float time, float delay, int loopCount_ /*= -1*/, bool pingPong_ /*= false*/)
        : base(target, time, delay)
    {
        loopCount = loopCount_;
        pingPong = pingPong_;

        isPingPonging = false;

        completeHandle = CompleteHandle.AutoSetValue;
    }
    
    //
    [System.Serializable]
    public new class Info : Tween.Info
    {
        public int loopCount = 1;
        public bool pingPong;
    }
    /// <summary>
    /// Initializes a new TweenLoop.
    /// </summary>
    /// <param name="target">The target object.</param>
    /// <param name="info">The TweenLoop's initialization information.</param>
    public TweenLoop(object target, Info info)
        : base(target, info)
    {
        loopCount = info.loopCount;
        pingPong = info.pingPong;

        isPingPonging = false;

        completeHandle = CompleteHandle.AutoSetValue;
    }


    //
    /// <summary>
    /// set loop count.
    /// </summary>
    /// <returns>return this instance and set other tween property.</returns>
    public TweenLoop LoopCount(int c)
    {
        loopCount = c;
        return this;
    }

    /// <summary>
    /// set is pingpong.
    /// </summary>
    /// <param name="pingPong_">if set to <c>true</c> [ping pong_].</param>
    /// <returns>return this instance and set other tween property.</returns>
    public TweenLoop PingPong(bool pingPong_)
    {
        pingPong = pingPong_;
        return this;
    }

    //
    /// <summary>
    /// set tween id.
    /// </summary>
    /// <param name="id_">The id_.</param>
    /// <returns>return this instance and set other tween property.</returns>
    public new TweenLoop Id(object id_)
    {
        id = id_;
        return this;
    }

    //
    /// <summary>
    /// Gets the equation proxy and set equation function.
    /// </summary>
    public new EquationTweenProxy<TweenLoop> equation
    {
        get { return new EquationTweenProxy<TweenLoop>(this); }
    }
    /// <summary>
    /// Gets the object proxy and set object tween info.
    /// </summary>
    public new ObjectTweenProxy<TweenLoop> obj
    {
        get { return new ObjectTweenProxy<TweenLoop>(this); }
    }
    /// <summary>
    /// Gets the transform proxy and set transform tween info.
    /// </summary>
    public new TransformTweenProxy<TweenLoop> transform
    {
        get { return new TransformTweenProxy<TweenLoop>(this); }
    }
    /// <summary>
    /// Gets the material proxy and set material tween info.
    /// </summary>
    public new MaterialTweenProxy<TweenLoop> material
    {
        get { return new MaterialTweenProxy<TweenLoop>(this); }
    }
    /// <summary>
    /// Gets the materials proxy and set materials tween info.
    /// Set tween info to all the children's materials.
    /// </summary>
    public new MaterialsTweenProxy<TweenLoop> materials
    {
        get { return new MaterialsTweenProxy<TweenLoop>(this, null, false); }
    }
    /// <summary>
    /// Gets the audio proxy and set audio tween info.
    /// </summary>
    public new AudioSourceTweenProxy<TweenLoop> audio
    {
        get { return new AudioSourceTweenProxy<TweenLoop>(this); }
    }
    /// <summary>
    /// Gets the light proxy and set light tween info.
    /// </summary>
    public new LightTweenProxy<TweenLoop> light
    {
        get { return new LightTweenProxy<TweenLoop>(this); }
    }
    /// <summary>
    /// Gets the camera proxy and set camera tween info.
    /// </summary>
    public new CameraTweenProxy<TweenLoop> camera
    {
        get { return new CameraTweenProxy<TweenLoop>(this); }
    }
    
    /// <summary>
    /// Gets the object proxy and set object tween info.
    /// </summary>
    /// <param name="o">The other object.</param>
    public new ObjectTweenProxy<TweenLoop> Obj(object o)
    {
        return new ObjectTweenProxy<TweenLoop>(this, o);
    }
    /// <summary>
    /// Gets the transform proxy and set transform tween info.
    /// </summary>
    /// <param name="t">The other transform.</param>
    public new TransformTweenProxy<TweenLoop> Transform(Transform t)
    {
        return new TransformTweenProxy<TweenLoop>(this, t);
    }
    /// <summary>
    /// Gets the material proxy and set material tween info.
    /// </summary>
    /// <param name="m">The other material.</param>
    public new MaterialTweenProxy<TweenLoop> Material(Material m)
    {
        return new MaterialTweenProxy<TweenLoop>(this, m);
    }
    /// <summary>
    /// Gets the material proxy and set material tween info.
    /// </summary>
    /// <param name="m">The other component's material.</param>
    public new MaterialTweenProxy<TweenLoop> Material(Component c)
    {
        return new MaterialTweenProxy<TweenLoop>(this, c.renderer.material);
    }
    /// <summary>
    /// Gets the materials proxy and set materials tween info.
    /// Set tween info to the children's materials by the names.
    /// </summary>
    /// <param name="t">The transform. use target object if t is null.</param>
    /// <param name="names">The names. find the game object name.</param>
    /// <returns></returns>
    public new MaterialsTweenProxy<TweenLoop> Materials(Transform t, params string[] names)
    {
        return new MaterialsTweenProxy<TweenLoop>(this, t, false, names);
    }
    /// <summary>
    /// Gets the materials proxy and set materials tween info.
    /// Set tween info to the children's materials by the names.
    /// </summary>
    /// <param name="names">The names. find the game object name.</param>
    /// <returns></returns>
    public new MaterialsTweenProxy<TweenLoop> Materials(params string[] names)
    {
        return new MaterialsTweenProxy<TweenLoop>(this, null, false, names);
    }
    /// <summary>
    /// Gets the audio proxy and set audio tween info.
    /// </summary>
    /// <param name="t">The other audio.</param>
    public new AudioSourceTweenProxy<TweenLoop> Audio(AudioSource a)
    {
        return new AudioSourceTweenProxy<TweenLoop>(this, a);
    }
    /// <summary>
    /// Gets the audio proxy and set audio tween info.
    /// </summary>
    /// <param name="t">The other component's audio.</param>
    public new AudioSourceTweenProxy<TweenLoop> Audio(Component c)
    {
        return new AudioSourceTweenProxy<TweenLoop>(this, c.audio);
    }
    /// <summary>
    /// Gets the light proxy and set light tween info.
    /// </summary>
    /// <param name="l">The other light.</param>
    public new LightTweenProxy<TweenLoop> Light(Light l)
    {
        return new LightTweenProxy<TweenLoop>(this, l);
    }
    /// <summary>
    /// Gets the light proxy and set light tween info.
    /// </summary>
    /// <param name="l">The other component's light.</param>
    public new LightTweenProxy<TweenLoop> Light(Component c)
    {
        return new LightTweenProxy<TweenLoop>(this, c.light);
    }
    /// <summary>
    /// Gets the camera proxy and set camera tween info.
    /// </summary>
    /// <param name="l">The other component's light.</param>
    public new CameraTweenProxy<TweenLoop> Camera(Camera c)
    {
        return new CameraTweenProxy<TweenLoop>(this, c);
    }
    /// <summary>
    /// Gets the camera proxy and set camera tween info.
    /// </summary>
    /// <param name="l">The other component's light.</param>
    public new CameraTweenProxy<TweenLoop> Camera(Component c)
    {
        return new CameraTweenProxy<TweenLoop>(this, c.camera);
    }


    
    /// <summary>
    /// Play this tween.
    /// Play success if has no the same old tween
    /// </summary>
    /// <returns>return this instance and set other tween property.</returns>
    public new TweenLoop play()
    {
        return play(TweenerManager.tweener);
    }
    /// <summary>
    /// Play this tween and replace old tween by the same id.
    /// </summary>
    /// <returns>return this instance and set other tween property.</returns>
    public new TweenLoop playAndReplace()
    {
        return playAndReplace(TweenerManager.tweener);
    }
    /// <summary>
    /// Play this tween.
    /// Play success if has no the same old tween
    /// </summary>
    /// <param name="tweener">the specified tweener manager.</param>
    /// <returns>return this instance and set other tween property.</returns>
    public new TweenLoop play(Tweener tweener)
    {
        base.play(tweener);
        return this;
    }
    /// <summary>
    /// Play this tween and replace old tween by the same id.
    /// </summary>
    /// <param name="tweener">the specified tweener manager.</param>
    /// <returns>return this instance and set other tween property.</returns>
    public new TweenLoop playAndReplace(Tweener tweener)
    {
        base.playAndReplace(tweener);
        return this;
    }


    //
#region Private

    public bool pingPong = false;
    public bool isPingPonging { get; protected set; }
    public int loopCount = 1;

    protected override float _timeTransform(float curr_time_)
    {
        var t = 0.0f;
        if (pingPong && isPingPonging)
            t = this.time - curr_time_;
        else
            t = curr_time_;
        return t;
    }

    override public bool _finished()
    {
        if (loopCount < 0 || --loopCount > 0)
        {
            if (currentTime >= time)
            {
                if (pingPong)
                    isPingPonging = !isPingPonging;
                
                currentTime = 0;
            }

            return false;
        }


        //
        if (completeHandle == CompleteHandle.AutoSetValue)
        {
            if (pingPong)
            {
                if (isPingPonging)
                {
                    foreach (TweenProperty pd in _propertyList)
                    {
                        pd.setStartValueToTarget();
                    }
                }
                else
                {
                    foreach (TweenProperty pd in _propertyList)
                    {
                        pd.setDestValueToTarget();
                    }
                }
            }
            else
            {
                foreach (TweenProperty pd in _propertyList)
                {
                    pd.setDestValueToTarget();
                }
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

        _state = STATE.Finished;
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