// Copyright (c) 2012 Xilin Chen (RN)
// Please direct any bugs/comments/suggestions to http://rntween.blogspot.com/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace RNTween{

public class TweenTransform : MonoBehaviour
{
    /// <summary>
    /// tween target.
    /// </summary>
    public Transform target;

    /// <summary>
    /// Tweener type.
    /// </summary>
    public TweenerManager.TweenerType tweenerType = TweenerManager.TweenerType.TweenerInUpdate;

    /// <summary>
    /// Tween trigger event.
    /// </summary>
    public TweenTriggerEvent triggerEvent = 0;
    //loop all the tweens
    //循环所有的tween
    public bool loop = false;



    /// <summary>
    /// Transform property name.
    /// </summary>
    public enum PropertyName
    {
        localPosition,
        localScale,
        localEulerAngles,

        /*position,
        eulerAngles,

        right,
        up,
        forward,*/
    }

    [System.Serializable]
    public class Info : TweenLoop.Info
    {
        /// <summary>
        /// from Index.
        /// use current Transform.localPosition or Transform.localScale or Transform.localEulerAngles if fromIndex is -1.
        /// </summary>
        public int fromIndex = -1;

        /// <summary>
        /// to Index.
        /// use current Transform.localPosition or Transform.localScale or Transform.localEulerAngles if fromIndex is -1.
        /// </summary>
        public int toIndex = 0;

        /// <summary>
        /// property name enum.
        /// </summary>
        public PropertyName propertyName = PropertyName.localPosition;

        //public bool loop = false;

        /// <summary>
        /// Play state.
        /// </summary>
        public enum PlayState
        {
            None,

            //跟上一个tween同时播放
            Synchronous,

            //上一个tween播放介绍后开始播放
            PlayOnComplete,
        }
        public PlayState playState = PlayState.None;
    }

    /// <summary>
    /// tween info list.
    /// </summary>
    public Info[] tweenInfos;

    /// <summary>
    /// vector list.
    /// </summary>
    public List<Vector3> vectors;

    /// <summary>
    /// current index.
    /// </summary>
    int currIndex = 0;


    //
    void Awake()
    {
        if (target == null)
            target = transform;

        if (vectors.Count == 0)
            Debug.LogError("vectors.Count == 0.     pls add point info in Editor!", this);
        if (tweenInfos.Length == 0)
            Debug.LogError("tweenInfos.Length == 0.     pls set Tween Info in Editor!", this);
    }

    protected void play(Tweener tweener)
    {
        /*if (tweener.hasTween(target)
        && ((int)triggerEvent & (int)TweenTriggerEvent.ForceToPlayNextTween) == 0)
            return;*/

        if (currIndex >= tweenInfos.Length)
        {
            if (loop)
                currIndex = 0;
            else
                return;
        }


        //
        var info = tweenInfos[currIndex];
        var tween = new TweenLoop(target, info);
        tween.Id(info);

        //
        if (info.fromIndex == -1)
        {
            tween.obj.to(info.propertyName.ToString(), vectors[info.toIndex]);
        }
        else if (info.toIndex == -1)
        {
            tween.obj.from(info.propertyName.ToString(), vectors[info.fromIndex]);
        }
        else
        {
            tween.obj.fromTo(info.propertyName.ToString(), vectors[info.fromIndex], vectors[info.toIndex]);
        }

        //
        tweener.addTween(tween);

        //
        ++currIndex;
        if (currIndex >= tweenInfos.Length)
        {
            if (loop)
            {
                currIndex = 0;
                tween.onComplete = play;
            }
        }
        else if (tweenInfos[currIndex].playState == Info.PlayState.PlayOnComplete)
        {
            tween.onComplete = play;
        }
        else if (tweenInfos[currIndex].playState == Info.PlayState.Synchronous)
        {
            play();
        }
    }

    void play()
    {
        //
        if (tweenerType == TweenerManager.TweenerType.TweenerInUpdate)
            play(TweenerManager.tweener);
        else if (tweenerType == TweenerManager.TweenerType.TweenerInLateUpdate)
            play(TweenerManager.tweenerInLateUpdate);
        else if (tweenerType == TweenerManager.TweenerType.TweenerInFixedUpdate)
            play(TweenerManager.tweenerInFixedUpdate);
        else if (tweenerType == TweenerManager.TweenerType.TweenerWithOutTimeScale)
            play(TweenerManager.tweenerWithOutTimeScale);

        else if (tweenerType == TweenerManager.TweenerType.AppTweener)
            play(RNApp.tweener);
        else if (tweenerType == TweenerManager.TweenerType.UITweener)
            play(UIManager.tweener);
        else
            Debug.LogError("", this);
    }

    //
    void Start()
    {
        if (((int)triggerEvent & (int)TweenTriggerEvent.playOnAwake) > 0)
            play();
    }


    //
    void onTouchDown(Vector3 position)
    {
        if (((int)triggerEvent & (int)TweenTriggerEvent.onTouchDown) > 0)
            play();
    }
    void onTouchUpAsButton(Vector3 position)
    {
        if (((int)triggerEvent & (int)TweenTriggerEvent.onTouchUpAsButton) > 0)
            play();
    }
    void onTouchUp(Vector3 position)
    {
        if (((int)triggerEvent & (int)TweenTriggerEvent.onTouchUp) > 0)
            play();
    }
    void onTouchOverIn(Vector3 position)
    {
        if (((int)triggerEvent & (int)TweenTriggerEvent.OnTriggerEnter) > 0)
            play();
    }
    void onTouchOverOut(Vector3 position)
    {
        if (((int)triggerEvent & (int)TweenTriggerEvent.onTouchOverOut) > 0)
            play();
    }

    //
    void OnMouseEnter()
    {
        if (((int)triggerEvent & (int)TweenTriggerEvent.OnMouseEnter) > 0)
            play();
    }
    /*void OnMouseOver()
    {
        if (((int)triggerEvent & (int)TweenTriggerEvent.OnMouseOver) > 0)
            play();
    }*/
    void OnMouseExit()
    {
        if (((int)triggerEvent & (int)TweenTriggerEvent.OnMouseExit) > 0)
            play();
    }
    void OnMouseDown()
    {
        if (((int)triggerEvent & (int)TweenTriggerEvent.OnMouseDown) > 0)
            play();
    }
    void OnMouseUp()
    {
        if (((int)triggerEvent & (int)TweenTriggerEvent.OnMouseUp) > 0)
            play();
    }
    void OnMouseUpAsButton()
    {
        if (((int)triggerEvent & (int)TweenTriggerEvent.OnMouseUpAsButton) > 0)
            play();
    }


    void OnTriggerEnter(Collider other)
    {
        if (((int)triggerEvent & (int)TweenTriggerEvent.OnTriggerEnter) > 0)
            play();
    }
    void OnTriggerExit(Collider other)
    {
        if (((int)triggerEvent & (int)TweenTriggerEvent.OnTriggerExit) > 0)
            play();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (((int)triggerEvent & (int)TweenTriggerEvent.OnCollisionEnter) > 0)
            play();
    }
    void OnCollisionExit(Collision collision)
    {
        if (((int)triggerEvent & (int)TweenTriggerEvent.OnCollisionExit) > 0)
            play();
    }

}
}