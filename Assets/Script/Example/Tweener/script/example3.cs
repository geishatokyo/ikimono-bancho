// Copyright (c) 2012 Xilin Chen (RN)
// Please direct any bugs/comments/suggestions to http://rntween.blogspot.com/

using UnityEngine;
using System.Collections;

/// <summary>
/// This example3 show how to tween material's color and light's color.
/// </summary>
public class example3 : MonoBehaviour
{

    public GameObject cube;
    public Light dirLight;

    void Start()
    {
        new TweenLoop(cube, 1, 0, -1, true)
            .equation.inOutCubic                    //set equation

            .material.MainColor.to(Color.black)     //material.MainColor to black

            .material.SpecularColor.r.to(0.0f)      //material.SpecularColor.r to 0.0f

            .Material(cube.renderer.material).Shininess.fromTo(0.01f, 1f)
                                                    //specify a new material and tween shininess

            .equation.outCubic                      //set a new equation
            .material.Color("_ReflectColor").to(Color.white)
                                                    //specify a material property and tween _ReflectColor to while

            .play();                                //play tween


        new TweenLoop(dirLight, 2, 0, -1, true)     //light tween 
            .equation.inOutCubic                    //set equation
            .light.color.to(Color.black)            //tween light.color to back

            .play();                                //play tween
    }


}