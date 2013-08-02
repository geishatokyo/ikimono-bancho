// Copyright (c) 2012 Xilin Chen (RN)
// Please direct any bugs/comments/suggestions to http://rntween.blogspot.com/

using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// Tweener is a tween manager.
/// </summary>
[System.Serializable]
public class Tweener
{
    /// <summary>
    /// frame time.
    /// </summary>
    public float frameTime = 1f / 60f;
    float curFrameTime = 0f;

    //
    Dictionary<object, BaseTween> _tweenDict = new Dictionary<object, BaseTween>();


    /// <summary>
    /// add tween to play.
    /// add fail if _tweenDict has this tween.
    /// </summary>
    /// <param name="t">The tween.</param>
    /// <returns>return true if add tween success.</returns>
    public bool addTween(BaseTween t)
    {
#if UNITY_EDITOR
        if (t.id == null)
            t._logDebug("t.id == null");
#endif
        if (_tweenDict.ContainsKey(t.id))
            return false;

        _tweenDict.Add(t.id, t);
        return true;
    }


    /// <summary>
    /// add tween to play.
    /// remove old tween if this tweener manager has the same tween.
    /// </summary>
    /// <param name="t">The tween.</param>
    /// <returns>return the tween is removes.</returns>
    public BaseTween addTweenRemoveLast(BaseTween t)
    {
#if UNITY_EDITOR
        if (t.id == null)
            t._logDebug("t.id == null");
#endif

        BaseTween r = null;
        if(_tweenDict.ContainsKey(t.id))
            r = _tweenDict[t.id];

        _tweenDict[t.id] = t;

        return r;
    }


    /// <summary>
    /// Removes the tween.
    /// </summary>
    /// <param name="t">The t.</param>
    /// <returns>return true if add tween success.</returns>
    public bool removeTween(BaseTween t)
    {
#if UNITY_EDITOR
        if (t.id == null)
            t._logDebug("t.id == null");
#endif

        if (_tweenDict.ContainsKey(t.id) == true)
        {
            _tweenDict.Remove(t.id);
            t.finish();
            return true;
        }
        return false;
    }
    /// <summary>
    /// Removes the tween by id.
    /// </summary>
    /// <param name="id">The id.</param>
    /// <returns>return true if add tween success.</returns>
    public bool removeById(object id)
    {
        if (id == null)
            return false;

        if (_tweenDict.ContainsKey(id) == true)
        {
            _tweenDict[id].finish();
            _tweenDict.Remove(id);
            return true;
        }
        return false;
    }
    /// <summary>
    /// Removes all tween.
    /// </summary>
    public void removeAll()
    {
#if UNITY_EDITOR
        Debug.LogWarning("remove all tween:");
        foreach (var kv in _tweenDict)
        {
            var t = kv.Value;
            t.finish();
            t._logDebug("remove tween");
        }
#endif
        _tweenDict.Clear();
    }

    /// <summary>
    /// Determines whether the specified id has tween.
    /// </summary>
    /// <param name="id">The id.</param>
    /// <returns>
    ///   <c>true</c> if the specified id has tween; otherwise, <c>false</c>.
    /// </returns>
    public bool hasTween(object id)
    {
		if(id == null)
			return false;
        return _tweenDict.ContainsKey(id);
    }
    /// <summary>
    /// Determines whether the specified t has tween.
    /// </summary>
    /// <param name="t">The tween.</param>
    /// <returns>
    ///   <c>true</c> if the specified t has tween; otherwise, <c>false</c>.
    /// </returns>
    public bool hasTween(BaseTween t)
    {
#if UNITY_EDITOR
        if (t.id == null)
            t._logDebug("t.id == null");
#endif
        return _tweenDict.ContainsKey(t.id);
    }

    /// <summary>
    /// get the tween by id.
    /// </summary>
    public BaseTween getTween(object id)
    {
        return _tweenDict[id];
    }

    //debug info
#if UNITY_EDITOR
    private int tweensCount;
    private float tweeningTimeMs;
#endif

    static List<BaseTween> startList = new List<BaseTween>();
    static List<BaseTween> updateList = new List<BaseTween>();
    static List<BaseTween> removeList = new List<BaseTween>();
    /// <summary>
    /// Updates the tweens in every frame.
    /// </summary>
    /// <param name="deltaTime">The delta time.</param>
    public void update(float deltaTime)
    {
        //
        curFrameTime += deltaTime;
        if (curFrameTime < frameTime)
            return;
        deltaTime = curFrameTime;
        curFrameTime -= deltaTime;


        //debug info
#if UNITY_EDITOR
        tweensCount = _tweenDict.Count;
        tweensCount += 0;//disable warning
        var realtimeSinceStartup = Time.realtimeSinceStartup;
#endif

        foreach (var kv in _tweenDict)
        {
            var t = kv.Value;

            //
            if (t.target.Equals(null))
            {
#if UNITY_EDITOR
                //Debug.LogWarning("BaseTween target is delete,name=" + t.debug_name + " id=" + kv.Key + "  target.HashCode=" + t.target.GetHashCode());
                t._logDebug("Tween target is delete");
#endif
                t.onComplete = null;
                t.onStart = null;
                t.onUpdate = null;
                removeList.Add(t);

                continue;
            }

            //
            if (t.isForceFinished)
            {
                removeList.Add(t);
            }
            else
            {
                //
                if (t.isDelaying)
                {
                    if (t._start(deltaTime))
                    {
                        startList.Add(t);
                    }
                }


                //
                if (t._animate(deltaTime))
                {
                    if (t._finished())
                        removeList.Add(t);
                }
                else
                {
                    updateList.Add(t);
                }
            }
        }


        //
        foreach (BaseTween t in startList)
        {
            t._onStart();
        }
        startList.Clear();

        //
        foreach (BaseTween t in updateList)
        {
            t._onUpdate();
        }
        updateList.Clear();

        //
        foreach (BaseTween t in removeList)
        {
            _tweenDict.Remove(t.id);
            t._onComplete();
        }
        removeList.Clear();


        //debug info
#if UNITY_EDITOR
        tweeningTimeMs = Time.realtimeSinceStartup - realtimeSinceStartup;
        tweeningTimeMs *= 1000f;
#endif
    }




}






