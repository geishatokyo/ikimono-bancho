// Copyright (c) 2012 Xilin Chen (RN)
// Please direct any bugs/comments/suggestions to http://www.blogger.com/profile/04078856863398606871

using UnityEngine;
using UnityEditor;



/// <summary>
/// UndoHelp
/// auto add undo data if mouse down.
/// //����ԭ�� �ڰ�������ʱ���ע��undo ��������Ÿı�target������
/// 
/// 
///     //�༭�������������ؼ�(����button) ���������ַ���ע��undo
///     using (new UndoHelp(obj, "name"))
///     {
///         //...
///     }
/// 
/// 
///     //����ǰ�ť ���������淽��ע��undo
///     if (GUILayout.Button("set", GUILayout.Width(40)))
///     {
///         Undo.RegisterUndo(target.transform, "???.setPos");
///         target.transform.localPosition = posList[i];
///     }
/// </summary>
public class UndoHelp : System.IDisposable
{
    bool _isMouseDown = false;
    Object _obj;
    string _name;

    /// <summary>
    /// Initializes a new instance of the <see cref="UndoHelp"/> class.
    /// </summary>
    /// <param name="obj">The object you want to save undo info for.</param>
    /// <param name="name">The name of the action to undo.</param>
    public UndoHelp(Object obj, string name)
    {
        if (Event.current.type == EventType.mouseDown)  // �Ƿ������
            _isMouseDown = true;

        _obj = obj;
        _name = name;
    }

    /// <summary>
    /// Register Undo if Event.current.type is used and mouse is down.
    /// </summary>
    void System.IDisposable.Dispose()
    {
        if (_isMouseDown && Event.current.type == EventType.used)   //��갴�µ��¼� �Ƿ�ʹ����
        {
            //Debug.Log("isMouseDown && Event.current.type == EventType.used");
            Undo.RegisterUndo(_obj, _name);
        }
    }
}

