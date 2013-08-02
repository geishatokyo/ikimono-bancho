// Copyright (c) 2012 Xilin Chen (RN)
// Please direct any bugs/comments/suggestions to http://rntween.blogspot.com/

using UnityEngine;
using System.Collections;

/// <summary>
/// This example1 show how tween transform's children materials.
/// it's very simple.
/// </summary>
public class example4 : MonoBehaviour
{
    void Awake()
    {
        new TweenLoop(transform.Find("children"), 1, 0.0f, -1, true)
            .equation.linear
            .materials._Color.r.to(0.0f)    //all the transform children's materials will play tween
            .play();

        new TweenLoop(this, 2, 0.0f, -1, true)
            .equation.linear
            .Materials(transform, "cube", "cube1")._Color.to(Color.black)    //specify transforms's materials to play tween
            //.Materials("cube", "cube1")._Color.to(Color.black)
            .play();
    }
}