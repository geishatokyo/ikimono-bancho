// Copyright (c) 2012 Xilin Chen (RN)
// Please direct any bugs/comments/suggestions to http://rntween.blogspot.com/

using UnityEngine;
using System.Collections;

/// <summary>
/// This example1 show how tween transform's position localEulerAngles ...
/// You can run example1.scene and click button play and playAndReplace.
/// See the difference between Tween.play and Tween.playAndReplace.
/// </summary>
public class example1 : MonoBehaviour
{
    public Tween.Info tweenInfo;
    public Transform from;
    public Transform to;
    public Transform to1;
    public Transform to2;

    BaseTween _tween;
    void Start()
    {
        play();
    }

    void play()
    {
        _tween = new Tween(this, tweenInfo)                 //create a Tween
            .transform.position.fromToVector3(from, to)     //set position tween

            .equation.linear                                //set new equation
            .transform.localEulerAngles.y.fromTo(0, 360)    //do a 360 rotation

            .OnStart(onStart)                               //handle the start event
            .OnComplete(onComplete)                         //handle the complete event

            .play();                                        //play new this tween if has no the same old tween
    }

    void playAndReplace()
    {
        _tween = new Tween(this, 2, 0)
            .equation.inOutCubic                    //set equation
            .transform.position.toVector3(to1)      //position tween

            .equation.sin                           //set new equation
            .transform.localPosition.x.filter(2.5f) //filt transform.localPosition.x by sin

            .equation.inSine                        //set new equation
            .transform.localEulerAngles.y.to(360)   //do a 360 rotation

            .ShowOnStart()
            .HideOnComplete()                       //hide this game object when the tween is complete

            .OnStart(onStart)                       //handle the start event
            .OnComplete(onComplete)                 //handle the complete event

            .playAndReplace();                      //stop the old tween and play new tween
    }

    void move()
    {
        _tween = new Tween(this)
            .transform.position.moveTo(5.0f, to2.position, 0.0f)

            .OnStart(onStart)                       //handle the start event
            .OnComplete(onComplete)                 //handle the complete event

            .playAndReplace();                      //stop the old tween and play new tween
    }

    void OnGUI()
    {
        if (_tween == null)
            return;

        if (GUILayout.Button("play"))
        {
            play();
        }

        if (GUILayout.Button("playAndReplace"))
        {
            playAndReplace();
        }

        if (GUILayout.Button("move"))
        {
            move();
        }
    }

    void onStart()
    {
        print("tween.onStart");
    }

    void onComplete()
    {
        print("tween.onComplete");
    }
}
