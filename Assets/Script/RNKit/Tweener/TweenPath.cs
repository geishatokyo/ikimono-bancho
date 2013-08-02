// Copyright (c) 2012 Xilin Chen (RN)
// Please direct any bugs/comments/suggestions to http://rntween.blogspot.com/

using UnityEngine;
using System.Collections;

/// <summary>
/// position path tween
/// </summary>
public class TweenPath : MonoBehaviour
{
    //
    /// <summary>
    /// tween target.
    /// </summary>
    public Transform target;
    /// <summary>
    /// TweenLoop info.
    /// </summary>
    public TweenLoop.Info info;
    /// <summary>
    /// Tweener type.
    /// </summary>
    public TweenerManager.TweenerType tweenerType = TweenerManager.TweenerType.TweenerInUpdate;
    /// <summary>
    /// Tween trigger event.
    /// </summary>
    public TweenTriggerEvent triggerEvent = 0;

    /// <summary>
    /// is scale tween enable?
    /// </summary>
    public bool scaleEnable = false;
    /// <summary>
    /// is rotation tween enable?
    /// </summary>
    public bool rotationEnable = false;


    /// <summary>
    /// next transform to tween.
    /// </summary>
    public TweenPath nextTransform;



    //
    protected void play(Tweener tweener)
    {
        if(target == null)
            Debug.LogError("target == null");
        var tween = new TweenLoop(target, info);
        tween.Id(info);

        tween.transform.position.toVector3(transform);

        if (scaleEnable && target.localScale != transform.localScale)
            tween.transform.localScale.to(transform.localScale);

        if (rotationEnable && target.rotation != transform.rotation)
            tween.transform.rotation.to(transform.rotation);
        
        if (nextTransform != null
        && ((int)triggerEvent & (int)TweenTriggerEvent.PlayNextOnComplete) > 0)
            tween.onComplete = nextTransform.play;

        tweener.addTween(tween);
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