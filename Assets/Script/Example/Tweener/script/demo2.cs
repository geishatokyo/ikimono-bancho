// Copyright (c) 2012 Xilin Chen (RN)
// Please direct any bugs/comments/suggestions to http://rntween.blogspot.com/

using UnityEngine;
using System.Collections;

public class demo2 : MonoBehaviour
{
    public GameObject button;
    public Transform[] roots;



    public static demo2 ins;
    void Awake()
    {
        ins = this;

    }

    //
    void Start()
    {
        button.AddComponent<__Button>();

        new Caller(1.0f, showNext).play();
    }

    public void showNext()
    {
        show(roots[0]);
        hide(roots[1]);
    }

    class Wrapper
    {
        Transform _transform;
        float _angle = 0.0f;

        Transform _point;


        public Wrapper(Transform transform, Transform point)
        {
            _transform = transform;
            _point = point;
            _angle = 0;
            radiusOffset = 0;
        }


        public float radiusOffset
        {
            get;
            set;
        }

        public float angle
        {
            get { return _angle; }
            set
            {
                _angle = value;

                _transform.localPosition = new Vector3(radiusOffset, 0, 0);
                _transform.localEulerAngles = Vector3.zero;
                _transform.RotateAround(_point.position, _point.forward, _angle);
                _transform.RotateAround(_transform.right, -45);
            }
        }
    }

    static void show(Transform root)
    {
        new Tween(root, 1.0f, 0.0f)
            .equation.outCubic
            .transform.localEulerAngles.from(new Vector3(90, 0, 0))
            .play();


        var count = 0;
        foreach (Transform c in root)
        {
            var ra = new Wrapper(c, root);

            new Tween(ra, 1.0f, 0.0f)
                .equation.outCubic
                .obj.to("radiusOffset", -7.0f)
                .obj.to("angle", 360.0f / root.childCount * count)
                .playAndReplace();

            ++count;
        }
    }

    static void hide(Transform root)
    {
        var a = root.localEulerAngles;
        a.z = -60;
        new Tween(root, 1.0f, 0.0f)
            .equation.inCubic
            .transform.localEulerAngles.to(a)
            .ShowOnStart()
            .HideOnComplete()
            .playAndReplace()
            .onComplete = delegate()
            {
                a.z = 0;
                root.localEulerAngles = a;
            };


        var count = 0;
        foreach (Transform c in root.transform)
        {
            var ra = new Wrapper(c, root);

            var angle = 360.0f / root.childCount * count;
            new Tween(ra, 1.0f, 0.0f)
                .equation.linear
                .obj.fromTo("radiusOffset", -7.0f, -16.0f)  // tween Wrapper.radiusOffset
                .obj.fromTo("angle", angle, angle)          // tween Wrapper.angle
                .playAndReplace();

            ++count;
        }
    }
}


public class __Button : MonoBehaviour
{
    void OnMouseUpAsButton()
    {
        demo2.ins.showNext();

        new Tween(this, 0.5f, 0.0f)
            .equation.outCubic
            .transform.localScale.fromTo(Vector3.one * 0.75f, Vector3.one * 1.0f)
            .playAndReplace();
    }
}