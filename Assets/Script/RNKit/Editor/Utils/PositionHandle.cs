// Copyright (c) 2012 Xilin Chen (RN)
// Please direct any bugs/comments/suggestions to http://rntween.blogspot.com/


using UnityEngine;
using UnityEditor;
using System.Collections;


//必须实例化成静态成员
public static class PositionHandle
{
    //
    public static Transform selectTransform;
    static float clickTime;
    public static void select(Transform transform)
    {
        select(transform, Handles.RectangleCap);
    }

    public static void select(Transform transform, Handles.DrawCapFunction capFunc)
    {
        using (new UndoHelp(transform, "PositionHandle"))
        {
            //
            if (selectTransform == transform)
                transform.position = Handles.PositionHandle(transform.position, Quaternion.identity);

            //
            if (Handles.Button(
                        transform.position,
                        Camera.current.transform.rotation,
                        1,
                        1,
                        capFunc))
            {
                if (Selection.activeTransform != transform)
                {
                    selectTransform = transform;

                    //
                    if ((Time.realtimeSinceStartup - clickTime) < 0.75f)
                    {
                        Selection.activeGameObject = transform.gameObject;
                        clickTime = 0.0f;
                    }
                    clickTime = Time.realtimeSinceStartup;
                }
            }
        }
    }
}
