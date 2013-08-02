// Copyright (c) 2012 Xilin Chen (RN)
// Please direct any bugs/comments/suggestions to http://rntween.blogspot.com/

using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// base class Tween
/// </summary>
public abstract class BaseTween
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BaseTween"/> class.
    /// </summary>
    /// <param name="time">play time.</param>
    /// <param name="delay">delay time.</param>
    protected BaseTween(object target_, float time_, float delay_)
    {
        id = target_;
        target = target_;
        time = time_;
        delay = delay_;

#if UNITY_EDITOR
        _debugName = this.ToString();
#endif
    }
    [System.Serializable]
    public class Info
    {
        public float time;
        public float delay;
    }
    /// <summary>
    /// Initializes a new instance of the <see cref="BaseTween"/> class.
    /// </summary>
    /// <param name="info">The initialization information.</param>
    protected BaseTween(object target_, Info info)
    {
        id = target_;
        target = target_;
        time = info.time;
        delay = info.delay;
        currentTime = -delay;

#if UNITY_EDITOR
        _debugName = this.ToString();
#endif
    }

    /// <summary>
    /// set tween id.
    /// </summary>
    /// <param name="id_">The id_.</param>
    /// <returns>return this instance and set other tween property.</returns>
    public BaseTween Id(object id_)
    {
        id = id_;
#if UNITY_EDITOR
        _debugName += "__" + id_.ToString();
#endif
        return this;
    }

    /// <summary>
    /// set tween time length.
    /// </summary>
    /// <param name="ct">time length.</param>
    /// <returns>return this instance and set other tween property.</returns>
    public BaseTween Time(float t)
    {
        time = t;
        return this;
    }

    /// <summary>
    /// set the delay time.
    /// </summary>
    /// <param name="t">The delay time.</param>
    /// <returns>return this instance and set other tween property.</returns>
    public BaseTween Delay(float d)
    {
        delay = d;
        return this;
    }

    /// <summary>
    /// set tween current time.
    /// </summary>
    /// <param name="ct">current time.</param>
    /// <returns>return this instance and set other tween property.</returns>
    public BaseTween CurrentTime(float ct)
    {
        currentTime = ct;
        return this;
    }

    /// <summary>
    /// set start handler.
    /// </summary>
    /// <param name="start">start handler.</param>
    /// <returns>return this instance and set other tween property.</returns>
    public BaseTween OnStart(Action start)
    {
        onStart = start;
        return this;
    }
    /// <summary>
    /// set update handler.
    /// </summary>
    /// <param name="start">update handler.</param>
    /// <returns>return this instance and set other tween property.</returns>
    public BaseTween OnUpdate(Action update)
    {
        onUpdate = update;
        return this;
    }
    /// <summary>
    /// set complete handler.
    /// </summary>
    /// <param name="start">complete handler.</param>
    /// <returns>return this instance and set other tween property.</returns>
    public BaseTween OnComplete(Action complete)
    {
        onComplete = complete;
        return this;
    }


    /// <summary>
    /// Gets a value indicating whether this tween is playing.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this tween is playing; otherwise, <c>false</c>.
    /// </value>
    public bool isPlaying
    {
        get { return _state == STATE.Playing; }
    }
    /// <summary>
    /// Gets a value indicating whether this tween is pausing.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this tween is pausing; otherwise, <c>false</c>.
    /// </value>
    public bool isPausing
    {
        get { return _state == STATE.Pausing; }
    }
    /// <summary>
    /// Gets a value indicating whether this tween is delaying.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this tween is delaying; otherwise, <c>false</c>.
    /// </value>
    public bool isDelaying
    {
        get { return _state == STATE.Delaying; }
    }
    /// <summary>
    /// Gets a value indicating whether this tween is finished.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this tween is finished; otherwise, <c>false</c>.
    /// </value>
    public bool isFinished
    {
        get { return _state == STATE.Finished || _state == STATE.ForceFinished; }
    }
    /// <summary>
    /// Gets a value indicating whether this tween is force finished.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this tween is force finished; otherwise, <c>false</c>.
    /// </value>
    public bool isForceFinished
    {
        get { return _state == STATE.ForceFinished; }
    }


    /// <summary>
    /// Pauses this tween.
    /// </summary>
    public void pause()
    {
        if (!isPlaying && !isDelaying)
            Debug.LogError("tween is not playing, pls call tween.play", id as UnityEngine.Object);

        _state = STATE.Pausing;
    }
    /// <summary>
    /// Resumes this tween.
    /// </summary>
    public void resume()
    {
        if (!isPausing)
            Debug.LogError("tween is not pause, pls call tween.pause", id as UnityEngine.Object);

        _state = STATE.Playing;
    }
    /// <summary>
    /// Restarts this tween.
    /// It will not call OnStart event.
    /// </summary>
    public void restart()
    {
        if (isFinished)
            Debug.LogError("tween is finished, pls call tween.play.", id as UnityEngine.Object);

        _state = STATE.Playing;
        currentTime = -delay;
    }
    /// <summary>
    /// Finishes this tween.
    /// It will call OnComplete event on this frame.
    /// </summary>
    public void finish()
    {
        _state = STATE.ForceFinished;
    }
    /// <summary>
    /// Removes this tween.
    /// It will not call OnComplete event.
    /// </summary>
    /// <returns>return true if removes is successfully.</returns>
    public bool remove()
    {
        return remove(TweenerManager.tweener);
    }
    /// <summary>
    /// Removes this tween by specified tweener.
    /// It will not call OnComplete event.
    /// </summary>
    /// <param name="tweener">tweener manager.</param>
    /// <returns>return true if removes is successfully.</returns>
    public bool remove(Tweener tweener)
    {
        return tweener.removeTween(this);
    }



    /// <summary>
    /// Play this tween.
    /// Play success if has no the same old tween
    /// </summary>
    /// <returns>return this instance and set other tween property.</returns>
    public BaseTween play()
    {
        return play(TweenerManager.tweener);
    }
    /// <summary>
    /// Play this tween and replace old tween by the same id.
    /// </summary>
    /// <returns>return this instance and set other tween property.</returns>
    public BaseTween playAndReplace()
    {
        return playAndReplace(TweenerManager.tweener);
    }
    /// <summary>
    /// Play this tween.
    /// Play success if has no the same old tween
    /// </summary>
    /// <param name="tweener">the specified tweener manager.</param>
    /// <returns>return this instance and set other tween property.</returns>
    public BaseTween play(Tweener tweener)
    {
        _state = STATE.Delaying;
        currentTime = -delay;
        tweener.addTween(this);
        return this;
    }
    /// <summary>
    /// Play this tween and replace old tween by the same id.
    /// </summary>
    /// <param name="tweener">the specified tweener manager.</param>
    /// <returns>return this instance and set other tween property.</returns>
    public BaseTween playAndReplace(Tweener tweener)
    {
        _state = STATE.Delaying;
        currentTime = -delay;
        tweener.addTweenRemoveLast(this);
        return this;
    }


    /*
    //example0
    IEnumerator foo0()
    {
        yield return StartCoroutine(new Tween(this, 5f, 0f)
            .transform.position.y.to(100)
            .playEnumerator());

        yield return StartCoroutine(new Tween(this, 5f, 0f)
            .transform.position.y.to(200)
            .playEnumerator());
    }
    
    //example1
    IEnumerator foo1()
    {
        var t = new Tween(this,5,0)
            .transform.position.y.to(10f);

        var e = t.playEnumerator();

        while (e.MoveNext())
            yield return null;

        //调用StopCoroutine是直接跳出很函数 不会执行到这的
    }
    */
    public IEnumerator<BaseTween> playEnumerator()
    {
        _state = STATE.Delaying;
        currentTime = -delay;

        while (true)
        {
            yield return this;

            var deltaTime = UnityEngine.Time.deltaTime;

            //
            if (target.Equals(null))
            {
#if UNITY_EDITOR
                //Debug.LogWarning("BaseTween target is delete,name=" + debug_name + " id=" + kv.Key + "  target.HashCode=" + target.GetHashCode());
                _logDebug("Tween target is delete");
#endif
                yield break;
            }

            //
            if (isForceFinished)
            {
                _onComplete();
                yield break;
            }
            else
            {
                //
                if (isDelaying)
                {
                    if (_start(deltaTime))
                    {
                        _onStart();
                    }
                }


                //
                if (_animate(deltaTime))
                {
                    if (_finished())
                    {
                        _onComplete();
                        yield break;
                    }
                }
                else
                {
                    _onUpdate();
                }
            }
        }
    }

    public IEnumerator<BaseTween> playEnumeratorRealtime()
    {
        _state = STATE.Delaying;
        currentTime = -delay;

        var lastTime = UnityEngine.Time.realtimeSinceStartup;
        while (true)
        {
            yield return this;

            var deltaTime = UnityEngine.Time.realtimeSinceStartup - lastTime;
            lastTime = UnityEngine.Time.realtimeSinceStartup;

            //
            if (target.Equals(null))
            {
#if UNITY_EDITOR
                //Debug.LogWarning("BaseTween target is delete,name=" + debug_name + " id=" + kv.Key + "  target.HashCode=" + target.GetHashCode());
                _logDebug("Tween target is delete");
#endif
                yield break;
            }

            //
            if (isForceFinished)
            {
                _onComplete();
                yield break;
            }
            else
            {
                //
                if (isDelaying)
                {
                    if (_start(deltaTime))
                    {
                        _onStart();
                    }
                }


                //
                if (_animate(deltaTime))
                {
                    if (_finished())
                    {
                        _onComplete();
                        yield break;
                    }
                }
                else
                {
                    _onUpdate();
                }
            }
        }
    }





    //
#region member data

    /// <summary>
    /// time length for a single loop.
    /// </summary>
    public float time = 1f;

    /// <summary>
    /// delay time.
    /// </summary>
    public float delay = 0f;

    /// <summary>
    /// current time of the tween.
    /// </summary>
    public float currentTime = 0f;

    /// <summary>
    /// tween id.
    /// </summary>
    public object id;

    /// <summary>
    /// the target of the tween.
    /// </summary>
    public object target;

    /// <summary>
    /// call this action only once at initial startup.
    /// </summary>
    public Action onStart = null;
    /// <summary>
    /// call this action in every frame if tween is playing. 
    /// </summary>
    public Action onUpdate = null;
    /// <summary>
    /// call this action whenever tween completes.
    /// </summary>
    public Action onComplete = null;

#endregion


    //
#region Private

    /// <summary>
    /// tween state enum.
    /// </summary>
    protected enum STATE
    {
        Delaying,
        Playing,
        Pausing,
        Finished,
        ForceFinished,
    }

    /// <summary>
    /// current state of the tween.
    /// </summary>
    protected STATE _state = STATE.Delaying;


#if UNITY_EDITOR
    public string _debugName;
    public virtual void _logDebug(string msg)
    {
        Debug.LogWarning(msg + ", target=" + _debugName, id as UnityEngine.Object/* + "  target.HashCode=" + target.GetHashCode()*/);
    }
#endif

    /// <summary>
    /// _starts the specified delta time.
    /// internal use only.
    /// </summary>
    /// <param name="deltaTime">delta time in one frame.</param>
    /// <returns>return true if the tween can start.</returns>
    public bool _start(float deltaTime)
    {
        if (currentTime <= 0.0 && currentTime + deltaTime > 0.0)
        {
            _state = STATE.Playing;

            return true;
        }

        return false;
    }

    /// <summary>
    /// _animates the specified delta time.
    /// internal use only.
    /// </summary>
    /// <param name="deltaTime">delta time in one frame.</param>
    /// <returns>return true if the tween is finished. </returns>
    public bool _animate(float deltaTime)
    {
        //if (isPlaying == false)
        if (_state == STATE.Pausing)
            return false;

        //test code ... todo... delete this
        if (_state == STATE.Finished)
        {
            return true;
            //Debug.LogError("_state == STATE.Finished");
        }


        //
        currentTime += deltaTime;


        if (currentTime <= 0.0f)
        {
            return false;
        }
        else if (currentTime < time)
        {
            var curTime_ = _timeTransform(currentTime);
            _onTransition(curTime_);
            return false;
        }

        return true;
    }

    /// <summary>
    /// _finisheds this instance.
    /// internal use only.
    /// </summary>
    /// <returns>return true if the tween can finished.</returns>
    public virtual bool _finished()
    {
        _state = STATE.Finished;
        return true;
    }

    public virtual void _onStart()
    {
        if (onStart != null)
            onStart();
    }
    public void _onUpdate()
    {
        if (onUpdate != null)
            onUpdate();
    }
    public virtual void _onComplete()
    {
        if (onComplete != null)
            onComplete();
    }

    /// <summary>
    /// transform the time.
    /// </summary>
    /// <param name="curr_time">transform current time.</param>
    /// <returns>return transform time.</returns>
    protected virtual float _timeTransform(float curr_time)
    {
        return curr_time;
    }
    /// <summary>
    /// handle the object propertys transition.
    /// </summary>
    /// <param name="curTime_">current time.</param>
    protected virtual void _onTransition(float curTime_)
    {
    }


    //
    protected Component getComponent()
    {
        var c = target as Component;
        if (c == null)
        {
            var go = target as GameObject;
            if (go != null)
                c = go.transform;
        }

        return c;
    }

#endregion

}
