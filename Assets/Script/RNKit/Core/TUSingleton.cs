// Copyright (c) 2012 Xilin Chen (RN)
// Please direct any bugs/comments/suggestions to http://rntween.blogspot.com/


using UnityEngine;


/// <summary>
/// 
///  public class MyClass : TUSingleton<MyClass>
///  {
///      protected new void Awake()
///      {
///          base.Awake();
///          
///          //todo init ...
///      }
///  }
///     
/// </summary>
/// <typeparam name="T"></typeparam>
/// <remarks></remarks>
public class TUSingleton<T> : MonoBehaviour where T : class
{

    /// <summary>
    /// Gets the singleton.
    /// </summary>
    /// <remarks></remarks>
    static public T singleton
    {
        get;
        protected set;
    }

    /// <summary>
    /// Awakes this instance.
    /// </summary>
    /// <remarks></remarks>
    protected void Awake()
    {
        if (singleton != null)
            Debug.LogError("_singleton != null", this);

        singleton = this as T;
    }

    protected void OnDestroy()
    {
        singleton = null;
    }
}


/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
/// <remarks></remarks>
public class TSingleton<T> where T : class
{
    /// <summary>
    /// Gets the singleton.
    /// </summary>
    /// <remarks></remarks>
    static public T singleton
    {
        get;
        protected set;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="TSingleton&lt;T&gt;"/> class.
    /// </summary>
    /// <remarks></remarks>
    public TSingleton()
    {
        if (singleton != null)
            Debug.LogError("_singleton != null");

        singleton = this as T;
    }
}