// Copyright (c) 2012 Xilin Chen (RN)
// Please direct any bugs/comments/suggestions to http://rntween.blogspot.com/

/// <summary>
/// Tween trigger event.
/// </summary>
public enum TweenTriggerEvent
{
    playOnAwake = 1 << 0,


    onTouchDown         = 1 << 1,
    onTouchUpAsButton   = 1 << 2,
    onTouchUp           = 1 << 3,
    onTouchOverIn        = 1 << 4,
    onTouchOverOut         = 1 << 5,


    OnMouseEnter = 1 << 6,
    OnMouseExit = 1 << 7,
    OnMouseDown = 1 << 8,
    OnMouseUp = 1 << 9,
    OnMouseUpAsButton = 1 << 10,


    OnTriggerEnter = 1 << 11,
    OnTriggerExit = 1 << 12,

    OnCollisionEnter = 1 << 13,
    OnCollisionExit = 1 << 14,

    PlayNextOnComplete = 1 << 15,//using in TweenTransform2 //法克鱿！ enum只有16位
    //ForceToPlayNextTween = 1 << 21,

    //OnControllerColliderHit = 1 << 0,
    //OnJointBreak = 1 << 0,
    //OnParticleCollision = 1 << 0,
}
