// Copyright (c) 2012 Xilin Chen (RN)
// Please direct any bugs/comments/suggestions to http://rntween.blogspot.com/

using UnityEngine;
using UnityEditor;
using System.Collections;


[CustomEditor(typeof(TweenPath))]
public class TweenPathEditor : Editor
{

    TweenPath tweenPath
    {
        get { return target as TweenPath; }
    }


    SerializedObject so;

    SerializedProperty _target;
    SerializedProperty info;
    SerializedProperty tweenerType;
    SerializedProperty scaleEnable;
    SerializedProperty rotationEnable;
    SerializedProperty nextTransform;



    void OnEnable()
    {
        so = new SerializedObject(target);

        _target = so.FindProperty("target");
        info = so.FindProperty("info");
        tweenerType = so.FindProperty("tweenerType");
        scaleEnable = so.FindProperty("scaleEnable");
        rotationEnable = so.FindProperty("rotationEnable");
        nextTransform = so.FindProperty("nextTransform");
    }

    public override void OnInspectorGUI()
    {
        // Grab the latest data from the object
        so.Update();

        EditorGUILayout.PropertyField(_target);
        tweenPath.triggerEvent = (TweenTriggerEvent)EditorGUILayout.EnumMaskField("trigger event", tweenPath.triggerEvent);
        EditorGUILayout.PropertyField(info, true);
        EditorGUILayout.PropertyField(tweenerType);
        EditorGUILayout.PropertyField(scaleEnable);
        EditorGUILayout.PropertyField(rotationEnable);
        EditorGUILayout.PropertyField(nextTransform);

        // Apply the property, handle undo
        so.ApplyModifiedProperties();


        //EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("add next and select"))
            addNaxtPoint();
        //EditorGUILayout.EndHorizontal();
    }

    void addNaxtPoint()
    {
        var go = Instantiate(tweenPath.gameObject) as GameObject;
        go.transform.parent = tweenPath.transform.parent;

        go.name = "p" + (go.transform.parent.childCount - 1);

        tweenPath.nextTransform = go.GetComponent<TweenPath>();

        PositionHandle.selectTransform = tweenPath.nextTransform.transform;
        Selection.activeGameObject = PositionHandle.selectTransform.gameObject;
    }


    void OnSceneGUI()
    {
        var tp = tweenPath.transform.parent;

        if (tp.childCount > 1)
        {
            foreach (Transform t in tp)
            {
                DrawPathHelper(t);
            }
        }
    }

    public static void DrawPathHelper(Transform t)
    {
        //
        PositionHandle.select(t);

        //
        var n = t.GetComponent<TweenPath>().nextTransform;
        if(n != null)
            Handles.DrawLine(t.position, n.transform.position);
    }


}