// Copyright (c) 2012 Xilin Chen (RN)
// Please direct any bugs/comments/suggestions to http://rntween.blogspot.com/

using UnityEngine;
using System.Collections;

public class EquationsExample : MonoBehaviour
{
    public Equations.Enum equations;// = Equations.Enum.linear;
    Transform trans;
    TweenLoop tween;
    void Start()
    {
        //
        name = equations.ToString();

        //
        var tm = this.GetComponentInChildren<TextMesh>();
        tm.text = equations.ToString();
        tm.anchor = TextAnchor.MiddleCenter;
        tm.transform.localPosition = new Vector3(0, -0.35f, 0);
        tm.renderer.enabled = true;

        //
        trans = transform.Find("tween");

        tween = new TweenLoop(trans, 1, 1, -1, true);
        tween.Equation(equations)
            .Obj(this).to("x", 1f)
            .transform.localPosition.y.fromTo(-0.5f, 0.5f)
            .ShowOnStart()
            .play();

        //
        newOtherEquations();
    }

    float _x = 0;
    float x
    {
        get { return _x; }
        set
        {
            _x = value;

            if (tween.isPingPonging)
            {
                var pos = trans.localPosition;
                pos.x = -(tween.currentTime - 0.5f);
                trans.localPosition = pos;
            }
            else
            {
                var pos = trans.localPosition;
                pos.x = tween.currentTime - 0.5f;
                trans.localPosition = pos;
            }
        }
    }


    static bool isNew = false;
    void newOtherEquations()
    {
        if (isNew == false)
        {
            isNew = true;

            //
            var x = 0;
            var y = 0;
            for (var i = Equations.Enum.inQuad; i < Equations.Enum.inCirc; ++i)
            {
                var go = Instantiate(gameObject) as GameObject;
                go.GetComponent<EquationsExample>().equations = (Equations.Enum)i;

                var tran = go.transform;
                tran.position = new Vector3(x * 2.5f, 9.0f - y * 1.25f, 0);

                ++y;
                if (y >= 4)
                {
                    y = 0;
                    ++x;
                }
            }


            x = 0;
            for (var i = Equations.Enum.inCirc; i < Equations.Enum.MaxCount; ++i)
            {
                var go = Instantiate(gameObject) as GameObject;
                go.GetComponent<EquationsExample>().equations = (Equations.Enum)i;

                var tran = go.transform;
                tran.position = new Vector3(x * 2.5f, 3.75f - y * 1.25f, 0);

                ++y;
                if (y >= 4)
                {
                    y = 0;
                    ++x;
                }
            }


            //x = 0;
            for (var i = Equations.Enum.sin; i < Equations.Enum.spring; ++i)
            {
                var go = Instantiate(gameObject) as GameObject;
                go.GetComponent<EquationsExample>().equations = (Equations.Enum)i;

                var tran = go.transform;
                tran.position = new Vector3(x * 2.5f, 3.75f - y * 2.25f, 0);

                ++y;
                if (y >= 2)
                {
                    y = 0;
                    ++x;
                }
            }


            //
            x -= 2;
            y = 2;
            {
                var go = Instantiate(gameObject) as GameObject;
                go.GetComponent<EquationsExample>().equations = Equations.Enum.spring;
                var tran = go.transform;
                tran.position = new Vector3(x * 2.5f, 3.75f - y * 2.0f, 0);
            }
        }
    }
}