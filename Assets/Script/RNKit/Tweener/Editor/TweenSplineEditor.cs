// Copyright (c) 2012 Xilin Chen (RN)
// Please direct any bugs/comments/suggestions to http://rntween.blogspot.com/

using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;


[CustomEditor(typeof(TweenSpline))]
public class TweenSplineEditor : Editor
{
    SerializedObject so;

    new SerializedProperty target;
    SerializedProperty info;
    SerializedProperty tweenerType;
    SerializedProperty rootPath;
    SerializedProperty path;


    TweenSpline tweenSpline
    {
        get { return base.target as TweenSpline; }
    }

    void OnEnable()
    {
        so = new SerializedObject(tweenSpline);

        target = so.FindProperty("target");
        info = so.FindProperty("info");
        tweenerType = so.FindProperty("tweenerType");
        rootPath = so.FindProperty("rootPath");
        path = so.FindProperty("path");


        tweenSpline.updatePath();
        //remove null ref
        var r = new List<Transform>();
        foreach (var p in tweenSpline.path)
            if (p == null)
                r.Add(p);
        foreach (var p in r)
            tweenSpline.path.Remove(p);
    }


    public override void OnInspectorGUI()
    {
        // Grab the latest data from the object
        so.Update();

        EditorGUILayout.PropertyField(target);
        tweenSpline.triggerEvent = (TweenTriggerEvent)EditorGUILayout.EnumMaskField("trigger event", tweenSpline.triggerEvent);
        EditorGUILayout.PropertyField(info, true);
        EditorGUILayout.PropertyField(tweenerType);
        EditorGUILayout.PropertyField(rootPath);
        EditorGUILayout.PropertyField(path,true);


        //
        EditorGUILayout.BeginHorizontal();
        if (tweenSpline.path.Count == 0 && tweenSpline.rootPath == null)
        {
            if (GUILayout.Button("add path root"))
                addPathRoot();
        }
        else
        {
            if (GUILayout.Button("add point"))
                addPoint();

            if (tweenSpline.path.Count > 0)
                if (GUILayout.Button("remove point"))
                    removePoint();
        }
        EditorGUILayout.EndHorizontal();

        // Apply the property, handle undo
        so.ApplyModifiedProperties();
    }


    void OnSceneGUI()
    {
        if (tweenSpline.path.Count > 0)
        {
            DrawPathHelper(tweenSpline.path);
        }
    }

    //
    void addPathRoot()
    {
        var root = new GameObject().transform;
        root.parent = tweenSpline.transform.parent;
        root.name = tweenSpline.name + "_root";
        tweenSpline.rootPath = root;
    }

    void addPoint()
    {
        var p = new GameObject().transform;
        p.name = "p" + tweenSpline.path.Count;

        if (tweenSpline.path == null)
            tweenSpline.path = new List<Transform>();


        //set the parent
        if (tweenSpline.rootPath != null)
            p.parent = tweenSpline.rootPath;
        else if (tweenSpline.path.Count > 0)
            p.parent = tweenSpline.path[0].parent;


        //set the last point's pos
        if (tweenSpline.path.Count > 0)
            p.position = tweenSpline.path[tweenSpline.path.Count - 1].position;
        else
            p.position = tweenSpline.getTarget().position;

        tweenSpline.path.Add(p);

        PositionHandle.selectTransform = p;
    }

    void removePoint()
    {
        var r = tweenSpline.path[tweenSpline.path.Count - 1];
        Object.DestroyImmediate(r.gameObject);

        tweenSpline.path.RemoveAt(tweenSpline.path.Count - 1);
        //pathList.RemoveAt(pathList.Count - 1);
    }


    public static void DrawPathHelper(List<Transform> path)
    {
        foreach (var p in path)
        {
            PositionHandle.select(p);
        }

        if (path.Count > 3)
        {
            //
            Vector3 prevPt = TweenSplineProperty.calculateCRSpline(path, 0);
            //Gizmos.color = color;
            int SmoothAmount = path.Count * 10;
            for (int i = 1; i <= SmoothAmount; i++)
            {
                float pm = (float)i / SmoothAmount;
                Vector3 currPt = TweenSplineProperty.calculateCRSpline(path, pm);

                Handles.DrawLine(currPt, prevPt);

                prevPt = currPt;
            }
        }


        if (path.Count >= 2)
        {
            Handles.DrawLine(path[0].position, path[1].position);
        }

        if (path.Count >= 3)
        {
            Handles.DrawLine(path[path.Count - 2].position, path[path.Count - 1].position);
        }
    }
}