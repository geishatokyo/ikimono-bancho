// Copyright (c) 2012 Xilin Chen (RN)
// Please direct any bugs/comments/suggestions to http://rntween.blogspot.com/

using UnityEngine;
using System.Collections;


public class demo1 : MonoBehaviour
{
    public GameObject[] cuberoots;

    public int createCubeAngle = 30;
    public float createCubeTimeOffset = 0.0001f;

    public GameObject cubePrefab;
    public Tween.Info cubeTweenInfo;

    public static demo1 ins;
    void Awake()
    {
        ins = this;

        //
        foreach (var r in cuberoots)
        {
            r.AddComponent<CubeRoot__>();
        }
    }
}



public class CubeRoot__ : MonoBehaviour
{
    void Awake()
    {
        new TweenLoop(this, (demo1.ins.cubeTweenInfo.time * 0.9f - waveTime) * Random.Range(2.0f, 4.0f), Random.Range(1.0f, 2.0f), -1, false)
            .obj.fromTo("delayTime", demo1.ins.cubeTweenInfo.time * 0.9f - waveTime, 0.0f)
            .play();

        new Caller(1.0f, createCube).play();
    }

    float createDelayTime = 0.01f;
    int createNum = 0;

    const float waveTime = 2.0f;
    float delayTime { get; set; }
    void createCube()
    {
        //
        var point = transform.Find("point");
        var root = transform.Find("root");
        var f = transform.Find("point/from");
        var t = transform.Find("point/to");

        //
        var localEulerAngles = point.localEulerAngles;
        localEulerAngles.z += demo1.ins.createCubeAngle;
        point.localEulerAngles = localEulerAngles;

        //
        var cube = (Instantiate(demo1.ins.cubePrefab) as GameObject).transform;
        cube.parent = root;
        {
            var wave = demo1.ins.cubeTweenInfo.time * 0.9f - waveTime - delayTime;
            cube.gameObject.AddComponent<Cube__>().play(f, t, waveTime, delayTime, wave);
        }


        //
        if (createNum >= 100)
        {
            createNum = 0;
            new Caller(1.0f, createCube).play();
        }
        else
        {
            ++createNum;
            createDelayTime += demo1.ins.createCubeTimeOffset;
            new Caller(createDelayTime, createCube).play();
        }
    }
}

public class Cube__ : MonoBehaviour
{
    public void play(Transform f, Transform t, float waveTime, float delay, float wave)
    {
        //
        transform.rotation = f.rotation;
        transform.position = f.position;
        var fpos = transform.localPosition;
        transform.position = t.position;
        var tpos = transform.localPosition;

        //
        new Tween(transform, demo1.ins.cubeTweenInfo)
            .transform.localPosition.fromTo(fpos, tpos)

            .equation.inCubic
            .transform.localEulerAngles.z.by(360.0f * 2)

            .equation.cos
            .transform.localPosition.x.filter(5.0f)

            .DestroyOnComplete()

            .play();


        //
        new Tween(this, waveTime, delay)
            .equation.sin
            .transform.position.filterFunc(delegate() { return transform.right * wave; })
            .play(TweenerManager.tweenerInLateUpdate);

    }
}

























