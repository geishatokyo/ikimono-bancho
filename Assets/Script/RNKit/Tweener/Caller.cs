// Copyright (c) 2012 Xilin Chen (RN)
// Please direct any bugs/comments/suggestions to http://rntween.blogspot.com/

using UnityEngine;
using System;

/// <summary>
/// Caller
///     //example
///     new Caller(1.0f/*delay*/, handle).play();
///     
///     new Caller(10.0f/*time*/, 1.0f/*delay*/, 0.5f/*repeat rate*/, handle1).play();
/// 
///     new Caller(1.0f/*delay*/, 10/*count*/, 0.5f/*repeat rate*/, handle2).play();
///     
/// </summary>
public class Caller : BaseTween
{
    /// <summary>
    /// Initializes a new caller.
    /// </summary>
    /// <param name="delay">The delay time.</param>
    /// <param name="call">The handle function.</param>
    public Caller(float delay, Action call)
        : base(null, 0.0f, delay)
    {
        id = this;
        target = this;

#if UNITY_EDITOR
        _debugName = target.ToString();
#endif

        this.onComplete = call;
    }
    /// <summary>
    /// Initializes a new caller.
    /// </summary>
    /// <param name="time">The time.</param>
    /// <param name="delay">The delay time.</param>
    /// <param name="repeatRate_">The repeat rate time.</param>
    /// <param name="call">The handle function.</param>
    public Caller(float time, float delay, float repeatRate_, Action call)
        : base(null, time, delay)
    {
        id = this;
        target = this;

#if UNITY_EDITOR
        _debugName = target.ToString();
#endif

        _repeatRate = repeatRate_;

        onUpdate = _update;
        onCall = call;
    }
    /// <summary>
    /// Initializes a new caller.
    /// </summary>
    /// <param name="delay">The delay time.</param>
    /// <param name="count_">The call count.</param>
    /// <param name="repeatRate_">The repeat rate time.</param>
    /// <param name="call">The handle function.</param>
    public Caller(float delay, int count_, float repeatRate_, Action call)
        : base(null, count_ * repeatRate_, delay)
    {
        id = this;
        target = this;

#if UNITY_EDITOR
        _debugName = target.ToString();
#endif

        _repeatRate = repeatRate_;

        onUpdate = _update;
        onCall = call;
    }



    //
    [System.Serializable]
    public new class Info
    {
        public float delay;
        public int count;
        public float repeatRate = 1.0f;
    }
    /// <summary>
    /// Initializes a new caller.
    /// </summary>
    /// <param name="info">The caller initialization information.</param>
    /// <param name="call">The call function.</param>
    public Caller(Info info, Action call)
        : base(null, info.count * info.repeatRate, info.delay)
    {
        id = this;
        target = this;

#if UNITY_EDITOR
        _debugName = target.ToString();
#endif

        _repeatRate = info.repeatRate;

        onUpdate = _update;
        onCall = call;
    }



    /// <summary>
    /// Play this tween.
    /// Play success if has no the same old tween
    /// </summary>
    /// <returns>return this instance and set other tween property.</returns>
    public new Caller play()
    {
        return play(TweenerManager.tweener);
    }
    /// <summary>
    /// Play this tween and replace old tween by the same id.
    /// </summary>
    /// <returns>return this instance and set other tween property.</returns>
    public new Caller playAndReplace()
    {
        return playAndReplace(TweenerManager.tweener);
    }
    /// <summary>
    /// Play this tween.
    /// Play success if has no the same old tween
    /// </summary>
    /// <param name="tweener">the specified tweener manager.</param>
    /// <returns>return this instance and set other tween property.</returns>
    public new Caller play(Tweener tweener)
    {
        base.play(tweener);
        return this;
    }
    /// <summary>
    /// Play this tween and replace old tween by the same id.
    /// </summary>
    /// <param name="tweener">the specified tweener manager.</param>
    /// <returns>return this instance and set other tween property.</returns>
    public new Caller playAndReplace(Tweener tweener)
    {
        base.playAndReplace(tweener);
        return this;
    }

#region Private

    float _repeatRate;
    float _callerTime = 0.0f;
    public Action onCall = null;


    void _update()
    {
        if (currentTime >= _callerTime)
        {
            _callerTime += _repeatRate;

            onCall();
        }
    }

#if UNITY_EDITOR
    public override void _logDebug(string msg)
    {
        Debug.LogWarning(msg + ", target=" + _debugName/* + "  target.HashCode=" + target.GetHashCode()*/, id as UnityEngine.Object);
    }
#endif

#endregion

}


/// <summary>
/// CallerLoop
///     //example
///     new CallerLoop(1.0f/*delay*/, 0.5f/*repeat rate*/, handle).play();
///     
///     new CallerLoop(1.0f/*delay*/, 0.5f/*min repeat rate*/, 2.0f/*max repeat rate*/, handle1).play();
/// 
/// </summary>
public class CallerLoop : BaseTween
{
    /// <summary>
    /// Initializes a new caller.
    /// </summary>
    /// <param name="delay">The delay time.</param>
    /// <param name="repeatRate">The repeat rate.</param>
    /// <param name="call">The call function.</param>
    public CallerLoop(float delay, float repeatRate, Action call)
        : base(null, float.MaxValue, delay)
    {
        id = this;
        target = this;

#if UNITY_EDITOR
        _debugName = target.ToString();
#endif

        _minRepeatRate = repeatRate;
        _maxRepeatRate = repeatRate;

        onUpdate = update;
        onCall = call;
    }
    /// <summary>
    /// Initializes a new caller.
    /// the repeat rate is random.
    /// </summary>
    /// <param name="delay">The delay time.</param>
    /// <param name="minRepeatRate">The min repeat rate.</param>
    /// <param name="maxRepeatRate">The max repeat rate.</param>
    /// <param name="call">The handle function.</param>
    public CallerLoop(float delay, float minRepeatRate,float maxRepeatRate, Action call)
        : base(null, float.MaxValue, delay)
    {
        id = this;
        target = this;

#if UNITY_EDITOR
        _debugName = target.ToString();
#endif

        _minRepeatRate = minRepeatRate;
        _maxRepeatRate = maxRepeatRate;

        onUpdate = update;
        onCall = call;
    }



    //
    [System.Serializable]
    public new class Info
    {
        public float delay;
        public float minRepeatRate = 1.0f;
        public float maxRepeatRate = 2.0f;
    }
    /// <summary>
    /// Initializes a new caller.
    /// </summary>
    /// <param name="info">The caller initialization information.</param>
    /// <param name="call">The call function.</param>
    public CallerLoop(Info info, Action call)
        : base(null, float.MaxValue, info.delay)
    {
        id = this;
        target = this;

#if UNITY_EDITOR
        _debugName = target.ToString();
#endif


        _minRepeatRate = info.minRepeatRate;
        _maxRepeatRate = info.maxRepeatRate;


        onUpdate = update;
        onCall = call;
    }



    /// <summary>
    /// Play this tween.
    /// Play success if has no the same old tween
    /// </summary>
    /// <returns>return this instance and set other tween property.</returns>
    public new CallerLoop play()
    {
        return play(TweenerManager.tweener);
    }
    /// <summary>
    /// Play this tween and replace old tween by the same id.
    /// </summary>
    /// <returns>return this instance and set other tween property.</returns>
    public new CallerLoop playAndReplace()
    {
        return playAndReplace(TweenerManager.tweener);
    }
    /// <summary>
    /// Play this tween.
    /// Play success if has no the same old tween
    /// </summary>
    /// <param name="tweener">the specified tweener manager.</param>
    /// <returns>return this instance and set other tween property.</returns>
    public new CallerLoop play(Tweener tweener)
    {
        base.play(tweener);
        return this;
    }
    /// <summary>
    /// Play this tween and replace old tween by the same id.
    /// </summary>
    /// <param name="tweener">the specified tweener manager.</param>
    /// <returns>return this instance and set other tween property.</returns>
    public new CallerLoop playAndReplace(Tweener tweener)
    {
        base.playAndReplace(tweener);
        return this;
    }



#region Private

    float _minRepeatRate;
    float _maxRepeatRate;

    float _callerTime = 0.0f;
    public Action onCall = null;


    void update()
    {
        if (currentTime >= _callerTime)
        {
            _callerTime += UnityEngine.Random.Range(_minRepeatRate, _maxRepeatRate);

            onCall();
        }
    }

    public override bool _finished()
    {
        _callerTime = 0;
        currentTime = 0;
        return false;
    }

#if UNITY_EDITOR
    public override void _logDebug(string msg)
    {
        Debug.LogWarning(msg + ", target=" + _debugName/* + "  target.HashCode=" + target.GetHashCode()*/, id as UnityEngine.Object);
    }
#endif

#endregion

}