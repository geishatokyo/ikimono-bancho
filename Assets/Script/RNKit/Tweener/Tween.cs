// Copyright (c) 2012 Xilin Chen (RN)
// Please direct any bugs/comments/suggestions to http://rntween.blogspot.com/

//#define GO_ENABLE

using UnityEngine;
using System.Collections.Generic;


/// <summary>
/// Tween
/// 
///     //example1
///     new Tween(transform, 2, 0)
/// 
///         .equation.inOutCubic
///         .transform.position.to(new Vector3(0, 10, 0))
///         
///         .equation.inSine
///         .transform.localEulerAngles.y.to(360)
///         
///         .HideOnComplete()
///         .play();
///     
/// 
///     //example2
///     IEnumerator foo0()
///     {
///         yield return StartCoroutine(new Tween(this, 5f, 0f)
///             .transform.position.y.to(100)
///             .playEnumerator());
///
///         yield return StartCoroutine(new Tween(this, 5f, 0f)
///             .transform.position.y.to(200)
///             .playEnumerator());
///     }
///    
///     //example3
///     IEnumerator foo1()
///     {
///         var t = new Tween(this,5,0)
///             .transform.position.y.to(10f);
///
///         var e = t.playEnumerator();
///
///         while (e.MoveNext())
///             yield return null;
///
///         //Call StopCoroutine may stop this tween
///     }
///     
/// </summary>
[System.Serializable]
public class Tween : BaseTween
{
    /// <summary>
    /// Initializes a new tween of the <see cref="Tween"/> class.
    /// </summary>
    public Tween()
        : base(null, 1f, 0f)
    {
        _equation = Equations.linear;
    }

    /// <summary>
    /// Initializes a new tween of the <see cref="Tween"/> class.
    /// </summary>
    /// <param name="target_">The target of the tween.</param>
    /// <param name="time">The time.</param>
    /// <param name="delay">The delay time.</param>
    public Tween(object target_, float time, float delay /*= 0.0f*/)
        : base(target_, time, delay)
    {
        if (target_.Equals(null))
            Debug.LogError("target_.Equals(null)", target_ as Object);

        _equation = Equations.linear;

#if UNITY_EDITOR
        _debugName = target.ToString();
#endif
    }

    /// <summary>
    /// Initializes a new tween of the <see cref="Tween"/> class.
    /// </summary>
    /// <param name="target_">The target of the tween.</param>
    public Tween(object target_)
        : base(target_, 1.0f, 0.0f)
    {
        if (target_.Equals(null))
            Debug.LogError("target_.Equals(null)", target_ as Object);

        _equation = Equations.linear;

#if UNITY_EDITOR
        _debugName = target.ToString();
#endif
    }


    [System.Serializable]
    public new class Info : BaseTween.Info
    {
        public Equations.Enum equation = Equations.Enum.linear;
        public bool showOnStart = false;
        public bool playAudioOnStart = false;
        public bool hideOnComplete = false;
        public bool destroyOnComplete = false;
        public CompleteHandle completeHandle = CompleteHandle.DestValue;
    }
    /// <summary>
    /// Initializes a new instance of the <see cref="Tween"/> class.
    /// </summary>
    /// <param name="target_">The target of the tween.</param>
    /// <param name="info">The initialization information.</param>
    public Tween(object target_, Info info)
        : base(target_, info)
    {
        if (target_.Equals(null))
            Debug.LogError("target_.Equals(null)", target_ as Object);

        _equation = Equations.getEquation(info.equation);

        //
        if (info.showOnStart)
            ShowOnStart();

        if (info.playAudioOnStart)
            PlayAudioOnStart();

        if (info.hideOnComplete)
            HideOnComplete();

        if (info.destroyOnComplete)
            DestroyOnComplete();

        completeHandle = info.completeHandle;

#if UNITY_EDITOR
        _debugName = target.ToString();
#endif
    }



    //
    /// <summary>
    /// set the time.
    /// </summary>
    /// <param name="t">The time.</param>
    /// <returns>return this instance and set other tween property.</returns>
    public new Tween Time(float t)
    {
        base.Time(t);
        return this;
    }
    /// <summary>
    /// set the delay time.
    /// </summary>
    /// <param name="t">The delay time.</param>
    /// <returns>return this instance and set other tween property.</returns>
    public new Tween Delay(float d)
    {
        base.Delay(d);
        return this;
    }
    /// <summary>
    /// set equation.
    /// </summary>
    /// <param name="e">The equation function.</param>
    /// <param name="setAll">if set to <c>true</c> [set all the propertys].</param>
    /// <returns>return this instance and set other tween property.</returns>
    public Tween Equation(Equations.Function e, bool setAll /*= false*/)
    {
        _equation = e;

        if(setAll)
            foreach (var tp in _propertyList)
                tp._equation = e;
        return this;
    }
    /// <summary>
    /// set equation.
    /// </summary>
    /// <param name="e">The equation function.</param>
    /// <returns>return this instance and set other tween property.</returns>
    public Tween Equation(Equations.Function e)
    {
        _equation = e;

        /*if (false)
            foreach (var tp in _propertyList)
                tp._equation = e;*/
        return this;
    }
    /// <summary>
    /// set equation by the specified equation enum.
    /// </summary>
    /// <param name="e">The equation enum.</param>
    /// <param name="setAll">if set to <c>true</c> [set all].</param>
    /// <returns>return this instance and set other tween property.</returns>
    public Tween Equation(Equations.Enum e, bool setAll /*= false*/)
    {
        return Equation(Equations.getEquation(e), setAll);
    }
    /// <summary>
    /// set equation by the specified equation enum.
    /// </summary>
    /// <param name="e">The equation enum.</param>
    /// <returns>return this instance and set other tween property.</returns>
    public Tween Equation(Equations.Enum e)
    {
        return Equation(Equations.getEquation(e), false);
    }
    /// <summary>
    /// set currents time.
    /// </summary>
    /// <param name="ct">The currents time.</param>
    /// <returns>return this instance and set other tween property.</returns>
    public new Tween CurrentTime(float ct)
    {
        currentTime = ct;
        return this;
    }
    
    /// <summary>
    /// set start handler.
    /// </summary>
    /// <param name="start">start handler.</param>
    /// <returns>return this instance and set other tween property.</returns>
    public new Tween OnStart(System.Action start)
    {
        onStart = start;
        return this;
    }
    /// <summary>
    /// set update handler.
    /// </summary>
    /// <param name="start">update handler.</param>
    /// <returns>return this instance and set other tween property.</returns>
    public new Tween OnUpdate(System.Action update)
    {
        onUpdate = update;
        return this;
    }
    /// <summary>
    /// set complete handler.
    /// </summary>
    /// <param name="start">complete handler.</param>
    /// <returns>return this instance and set other tween property.</returns>
    public new Tween OnComplete(System.Action complete)
    {
        onComplete = complete;
        return this;
    }


    //
    /// <summary>
    /// show target on tween start.
    /// </summary>
    /// <returns>return this instance and set other tween property.</returns>
    public Tween ShowOnStart()
    {
#if UNITY_EDITOR
        if (getComponent() == null)
            Debug.LogError("getComponent() == null, target=" + target.GetType(), target as Object);
#endif
        showOnStart = true;
        _hideInDelay();
        return this;
    }

    /// <summary>
    /// play audio on tween start.
    /// </summary>
    /// <returns>return this instance and set other tween property.</returns>
    public Tween PlayAudioOnStart()
    {
#if UNITY_EDITOR
        if (getComponent() == null)
            Debug.LogError("getComponent() == null, target=" + target.GetType(), target as Object);
#endif
        playAudioOnStart = true;
        return this;
    }

    /// <summary>
    /// set target hide on tween complete.
    /// </summary>
    /// <returns>return this instance and set other tween property.</returns>
    public Tween HideOnComplete()
    {
#if UNITY_EDITOR
        if (getComponent() == null)
            Debug.LogError("getComponent() == null, target=" + target.GetType(), target as Object);
#endif
        hideOnComplete = true;
        return this;
    }

    /// <summary>
    /// Auto destroy target on tween complete.
    /// </summary>
    /// <returns>return this instance and set other tween property.</returns>
    public Tween DestroyOnComplete()
    {
#if UNITY_EDITOR
        if (getComponent() == null)
            Debug.LogError("getComponent() == null, target=" + target.GetType(), target as Object);
#endif
        destroyOnComplete = true;
        return this;
    }
    
    /// <summary>
    /// set start value at tween finished.
    /// call this function if use equation sin, cos, sinOnePi and cosOnePi
    /// </summary>
    /// <returns>return this instance and set other tween property.</returns>
    public Tween SetDestValueOnComplete()
    {
        completeHandle = CompleteHandle.DestValue;
        return this;
    }
    public Tween SetStartValueOnComplete()
    {
        completeHandle = CompleteHandle.StartValue;
        return this;
    }
    public Tween SetNoneValueOnComplete()
    {
        completeHandle = CompleteHandle.NoneValue;
        return this;
    }



    //
    /// <summary>
    /// Adds the property.
    /// </summary>
    /// <returns>return this instance and set other tween property.</returns>
    public Tween addProperty(TweenProperty tp)
    {
        if (tp._equation == null)
            tp._equation = _equation;

        _propertyList.Add(tp);
        return this;
    }
    /// <summary>
    /// Adds the property and set velocity.
    /// </summary>
    /// <param name="tp">The tp.</param>
    /// <param name="velocity">The velocity.</param>
    /// <returns>return this instance and set other tween property.</returns>
    public Tween addPropertyAndSetTime(TweenProperty tp, float velocity)
    {
        return addProperty(tp).Time(tp.getTime(velocity));
    }
    /// <summary>
    /// Removes all propertys.
    /// </summary>
    /// <returns>return this instance and set other tween property.</returns>
    public Tween removeAllPropertys()
    {
        this._propertyList.Clear();
        return this;
    }


    //
    /// <summary>
    /// set tween id.
    /// </summary>
    /// <param name="id_">The id_.</param>
    /// <returns>return this instance and set other tween property.</returns>
    public new Tween Id(object id_)
    {
        id = id_;
        return this;
    }

    //
    /// <summary>
    /// Gets the equation proxy and set equation function.
    /// </summary>
    public EquationTweenProxy<Tween> equation
    {
        get { return new EquationTweenProxy<Tween>(this); }
    }
    /// <summary>
    /// Gets the object proxy and set object tween info.
    /// </summary>
    public ObjectTweenProxy<Tween> obj
    {
        get { return new ObjectTweenProxy<Tween>(this); }
    }
    /// <summary>
    /// Gets the transform proxy and set transform tween info.
    /// </summary>
    public TransformTweenProxy<Tween> transform
    {
        get { return new TransformTweenProxy<Tween>(this); }
    }
    /// <summary>
    /// Gets the material proxy and set material tween info.
    /// </summary>
    public MaterialTweenProxy<Tween> material
    {
        get { return new MaterialTweenProxy<Tween>(this); }
    }
    /// <summary>
    /// Gets the materials proxy and set materials tween info.
    /// Set tween info to all the children's materials.
    /// </summary>
    public MaterialsTweenProxy<Tween> materials
    {
        get { return new MaterialsTweenProxy<Tween>(this, null, false); }
    }
    /// <summary>
    /// Gets the audio proxy and set audio tween info.
    /// </summary>
    public AudioSourceTweenProxy<Tween> audio
    {
        get { return new AudioSourceTweenProxy<Tween>(this); }
    }
    /// <summary>
    /// Gets the light proxy and set light tween info.
    /// </summary>
    public LightTweenProxy<Tween> light
    {
        get { return new LightTweenProxy<Tween>(this); }
    }
    /// <summary>
    /// Gets the camera proxy and set camera tween info.
    /// </summary>
    public CameraTweenProxy<Tween> camera
    {
        get { return new CameraTweenProxy<Tween>(this); }
    }

    /// <summary>
    /// Gets the object proxy and set object tween info.
    /// </summary>
    /// <param name="o">The other object.</param>
    public ObjectTweenProxy<Tween> Obj(object o)
    {
        return new ObjectTweenProxy<Tween>(this, o);
    }
    /// <summary>
    /// Gets the transform proxy and set transform tween info.
    /// </summary>
    /// <param name="t">The other transform.</param>
    public TransformTweenProxy<Tween> Transform(Transform t)
    {
        return new TransformTweenProxy<Tween>(this, t);
    }
    /// <summary>
    /// Gets the material proxy and set material tween info.
    /// </summary>
    /// <param name="m">The other material.</param>
    public MaterialTweenProxy<Tween> Material(Material m)
    {
        return new MaterialTweenProxy<Tween>(this, m);
    }
    /// <summary>
    /// Gets the material proxy and set material tween info.
    /// </summary>
    /// <param name="m">The other component's material.</param>
    public MaterialTweenProxy<Tween> Material(Component c)
    {
        return new MaterialTweenProxy<Tween>(this, c.renderer.material);
    }
    /// <summary>
    /// Gets the materials proxy and set materials tween info.
    /// Set tween info to the children's materials by the names.
    /// </summary>
    /// <param name="t">The transform. use target object if t is null.</param>
    /// <param name="names">The names. find the game object name.</param>
    /// <returns></returns>
    public MaterialsTweenProxy<Tween> Materials(Transform t, params string[] names)
    {
        return new MaterialsTweenProxy<Tween>(this, t, false, names);
    }
    /// <summary>
    /// Gets the materials proxy and set materials tween info.
    /// Set tween info to the children's materials by the names.
    /// </summary>
    /// <param name="names">The names. find the game object name.</param>
    /// <returns></returns>
    public MaterialsTweenProxy<Tween> Materials(params string[] names)
    {
        return new MaterialsTweenProxy<Tween>(this, null, false, names);
    }
    /// <summary>
    /// Gets the materials proxy and set materials tween info.
    /// Set tween info to the children's materials by the shader name.
    /// </summary>
    /// <param name="names">The shaderNames. find the shader name.</param>
    /// <returns></returns>
    public MaterialsTweenProxy<Tween> MaterialsByShader(Transform t, params string[] shaderNames)
    {
        return new MaterialsTweenProxy<Tween>(this, t, true, shaderNames);
    }
    /// <summary>
    /// Gets the materials proxy and set materials tween info.
    /// Set tween info to the children's materials by the shader name.
    /// </summary>
    /// <param name="names">The shaderNames. find the shader name.</param>
    /// <returns></returns>
    public MaterialsTweenProxy<Tween> MaterialsByShader(params string[] shaderNames)
    {
        return new MaterialsTweenProxy<Tween>(this, null, true, shaderNames);
    }
    /// <summary>
    /// Gets the audio proxy and set audio tween info.
    /// </summary>
    /// <param name="t">The other audio.</param>
    public AudioSourceTweenProxy<Tween> Audio(AudioSource a)
    {
        return new AudioSourceTweenProxy<Tween>(this, a);
    }
    /// <summary>
    /// Gets the audio proxy and set audio tween info.
    /// </summary>
    /// <param name="t">The other component's audio.</param>
    public AudioSourceTweenProxy<Tween> Audio(Component c)
    {
        return new AudioSourceTweenProxy<Tween>(this, c.audio);
    }
    /// <summary>
    /// Gets the light proxy and set light tween info.
    /// </summary>
    /// <param name="l">The other light.</param>
    public LightTweenProxy<Tween> Light(Light l)
    {
        return new LightTweenProxy<Tween>(this, l);
    }
    /// <summary>
    /// Gets the light proxy and set light tween info.
    /// </summary>
    /// <param name="l">The other component's light.</param>
    public LightTweenProxy<Tween> Light(Component c)
    {
        return new LightTweenProxy<Tween>(this, c.light);
    }
    /// <summary>
    /// Gets the camera proxy and set camera tween info.
    /// </summary>
    /// <param name="l">The other component's light.</param>
    public CameraTweenProxy<Tween> Camera(Camera c)
    {
        return new CameraTweenProxy<Tween>(this, c);
    }
    /// <summary>
    /// Gets the camera proxy and set camera tween info.
    /// </summary>
    /// <param name="l">The other component's light.</param>
    public CameraTweenProxy<Tween> Camera(Component c)
    {
        return new CameraTweenProxy<Tween>(this, c.camera);
    }
    /// <summary>
    /// Gets the camera proxy and set Camera.main tween info.
    /// </summary>
    /// <param name="l">The other component's light.</param>
    public CameraTweenProxy<Tween> CameraMain()
    {
        return new CameraTweenProxy<Tween>(this, UnityEngine.Camera.main);
    }

    
    /// <summary>
    /// Play this tween.
    /// Play success if has no the same old tween
    /// </summary>
    /// <returns>return this instance and set other tween property.</returns>
    public new Tween play()
    {
        return play(TweenerManager.tweener);
    }
    /// <summary>
    /// Play this tween and replace old tween by the same id.
    /// </summary>
    /// <returns>return this instance and set other tween property.</returns>
    public new Tween playAndReplace()
    {
        return playAndReplace(TweenerManager.tweener);
    }
    /// <summary>
    /// Play this tween.
    /// Play success if has no the same old tween
    /// </summary>
    /// <param name="tweener">the specified tweener manager.</param>
    /// <returns>return this instance and set other tween property.</returns>
    public new Tween play(Tweener tweener)
    {
        base.play(tweener);
        return this;
    }
    /// <summary>
    /// Play this tween and replace old tween by the same id.
    /// </summary>
    /// <param name="tweener">the specified tweener manager.</param>
    /// <returns>return this instance and set other tween property.</returns>
    public new Tween playAndReplace(Tweener tweener)
    {
        base.playAndReplace(tweener);
        return this;
    }

#region Private
    /// <summary>
    /// equation function
    /// </summary>
    public Equations.Function _equation;
    public bool showOnStart = false;
    public bool playAudioOnStart = false;
    public bool hideOnComplete = false;
    public bool destroyOnComplete = false;
    public enum CompleteHandle
    {
        DestValue,      //set up the final value on complete 结束后设置最终的值
        StartValue,     //set up the start value on complete 结束后设置开始的值
        NoneValue,      //not set up the value on complete   结束后不设任何值
        AutoSetValue,   //automatically set up the value on complete 结束后自动设置开始或结束的值
    }
    public CompleteHandle completeHandle = CompleteHandle.DestValue;


    protected List<TweenProperty> _propertyList = new List<TweenProperty>();




#if UNITY_EDITOR
    public override void _logDebug(string msg)
    {
        Debug.LogWarning(msg + ", target=" + _debugName/* + "  target.HashCode=" + target.GetHashCode()*/, target as Object);
    }
#endif


    //
    protected override void _onTransition(float curTime_)
    {
        float percentage = curTime_ / time;
        foreach (TweenProperty tp in _propertyList)
        {
            tp.onTransition(percentage);
        }
    }
    public override bool _finished()
    {
        base._finished();

        if (completeHandle == CompleteHandle.DestValue)
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
    public override void _onStart()
    {
        if (showOnStart)
            _visible(true);

        if (playAudioOnStart)
            getComponent().audio.Play();

        base._onStart();
    }


    public override void _onComplete()
    {
        base._onComplete();

        if (destroyOnComplete)
            Object.Destroy(getComponent().gameObject);
        else if (hideOnComplete)
            _visible(false);
    }


    protected void _visible(bool v)
    {
#if GO_ENABLE
        GO.visible(getComponent(), v);
#else
        var renderers = getComponent().GetComponentsInChildren<Renderer>();
        foreach (var r in renderers)
        {
            r.enabled = v;
        }
#endif
    }
    protected void _hideInDelay()
    {
#if GO_ENABLE
        GO.visibleWOCM(getComponent(), false);
#else
        _visible(false);
#endif
    }

    public static T getComponent<T>(object obj) where T : Component
    {
#if GO_ENABLE
        return GO.getComponent<T>(obj);
#else
        var t = obj as T;
        if (t != null)
            return t;

        var com = obj as Component;
        if (com != null)
        {
            t = com.GetComponent<T>();

            if (t != null)
                return t;
        }

        var go = obj as GameObject;
        if (go != null)
        {
            t = go.GetComponent<T>();

            if (t != null)
                return t;
        }

        return null;
#endif
    }

#endregion

}