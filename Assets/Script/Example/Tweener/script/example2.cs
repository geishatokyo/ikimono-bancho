// Copyright (c) 2012 Xilin Chen (RN)
// Please direct any bugs/comments/suggestions to http://rntween.blogspot.com/

using UnityEngine;
using System.Collections;

/// <summary>
/// This example2 show how play, pause, restart, finish and remove the tween.
/// </summary>
public class example2 : MonoBehaviour
{
    public TweenLoop.Info tweenInfo;
    public Transform from;
    public Transform to;

    BaseTween _tween;
    void Start()
    {
        play();
	}

    void play()
    {
        _tween = new TweenLoop(this, tweenInfo)             //create a Tween
            .transform.position.fromToVector3(from, to)     //set position tween

            .OnStart(onStart)                               //handle the start event
            .OnComplete(onComplete)                         //handle the complete event

            .play();                                        //play tween
    }

    void OnGUI()
    {
        if (_tween == null)
            return;

        if (_tween.isPlaying)
        {
            if (GUILayout.Button("pause"))
            {
                _tween.pause();
            }
            if (GUILayout.Button("restart"))
            {
                _tween.restart();   //It will not call Tween.OnStart
            }
            if (GUILayout.Button("complete"))
            {
                _tween.finish();    //It will call Tween.OnComplete on next frame
            }
            if (GUILayout.Button("remove"))
            {
                _tween.remove();    //It will not call Tween.OnComplete
            }
        }
        else if (_tween.isPausing)
        {
            if (GUILayout.Button("resume"))
            {
                _tween.resume();
            }
            if (GUILayout.Button("restart"))
            {
                _tween.restart();
            }
            if (GUILayout.Button("complete"))
            {
                _tween.finish();
            }
            if (GUILayout.Button("remove"))
            {
                _tween.remove();
            }
        }
        else if (_tween.isDelaying)
        {
            GUILayout.Button("Delaying");
        }
        else if (_tween.isFinished)
        {
            if (GUILayout.Button("play"))
            {
                play();
            }
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
