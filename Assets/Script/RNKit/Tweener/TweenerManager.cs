// Copyright (c) 2012 Xilin Chen (RN)
// Please direct any bugs/comments/suggestions to http://rntween.blogspot.com/

#define USE_SIMPLE_UIMANAGER_APP

using UnityEngine;


/// <summary>
/// TweenerManager
/// auto add script when use tween.
/// </summary>
public class TweenerManager : TUSingleton<TweenerManager>
{
    /// <summary>
    /// tween in witch update function.
    /// </summary>
    public enum TweenerType
    {
        /// <summary>
        /// tweener update in MonoBehaviour.Update function.
        /// </summary>
        TweenerInUpdate,
        /// <summary>
        /// tweener update in MonoBehaviour.LateUpdate function.
        /// </summary>
        TweenerInLateUpdate,
        /// <summary>
        /// tweener update in MonoBehaviour.FixedUpdate function.
        /// </summary>
        TweenerInFixedUpdate,
        /// <summary>
        /// tweener update in MonoBehaviour.Update function and without Time.timeScale.
        /// </summary>
        TweenerWithOutTimeScale,


        /// <summary>
        /// tweener update in AppTweener.Update function.
        /// </summary>
        AppTweener,
        /// <summary>
        /// tweener update in UITweener.Update function.
        /// </summary>
        UITweener,
    }

    /// <summary>
    /// Gets the tweener.
    /// 退出程序时 如果还继续访问这变量 可能会返回null
    /// </summary>
    static public Tweener tweener
    {
        get
        {
            if (singleton != null)
            {
                return singleton._tweener;
            }
            else
            {
                newTweenerManager();
                if (singleton != null)
                    return singleton._tweener;
            }
            return null;
        }
    }
    /// <summary>
    /// Gets the tweenerInLateUpdate.
    /// </summary>
    static public Tweener tweenerInLateUpdate
    {
        get
        {
            if (singleton != null)
            {
                return singleton._tweenerInLateUpdate;
            }
            else
            {
                newTweenerManager();
                if (singleton != null)
                    return singleton._tweenerInLateUpdate;
            }
            return null;
        }
    }
    /// <summary>
    /// Gets the tweenerInFixedUpdate.
    /// </summary>
    static public Tweener tweenerInFixedUpdate
    {
        get
        {
            if (singleton != null)
            {
                return singleton._tweenerInFixedUpdate;
            }
            else
            {
                newTweenerManager();
                if (singleton != null)
                    return singleton._tweenerInFixedUpdate;
            }
            return null;
        }
    }
    /// <summary>
    /// Gets the tweenerWithOutTimeScale.
    /// </summary>
    static public Tweener tweenerWithOutTimeScale
    {
        get
        {
            if (singleton != null)
            {
                return singleton._tweenerWithOutTimeScale;
            }
            else
            {
                newTweenerManager();

                if (singleton != null)
                    return singleton._tweenerWithOutTimeScale;
            }
            return null;
        }
    }


#region Private
    static bool isDestroy = false;
    static void newTweenerManager()
    {
        if (isDestroy)
            return;

        var go = new GameObject();
        var tm = go.AddComponent<TweenerManager>();
        tm.name = "__TweenerManager__";

        GameObject.DontDestroyOnLoad(go);
    }
    protected new void OnDestroy()
    {
        isDestroy = true;
        base.OnDestroy();
    }

    public Tweener _tweener;
    public Tweener _tweenerInLateUpdate;
    public Tweener _tweenerInFixedUpdate;
    public Tweener _tweenerWithOutTimeScale;
    

    new void Awake()
    {
        base.Awake();
        
        if (_tweener != null)
            Debug.LogError("_tweener != null", this);


        if (_tweener == null)
            _tweener = new Tweener();
        if (_tweenerInLateUpdate == null)
            _tweenerInLateUpdate = new Tweener();
        if (_tweenerInFixedUpdate == null)
            _tweenerInFixedUpdate = new Tweener();
        if (_tweenerWithOutTimeScale == null)
            _tweenerWithOutTimeScale = new Tweener();
    }


    static float _lastTime = 0.0f;
    void Update()
    {
        //
        if (Time.deltaTime > 0f)
            _tweener.update(Time.deltaTime);

        //
        if (_tweenerWithOutTimeScale != null)
        {
            //这个时间 不会受到Time.timeScale的影响
            var dt = Time.realtimeSinceStartup - _lastTime;
            _lastTime = Time.realtimeSinceStartup;
            _tweenerWithOutTimeScale.update(dt);
        }
    }
    void LateUpdate()
    {
        if (_tweenerInLateUpdate != null)
        {
            var deltaTime = Time.deltaTime;
            if (deltaTime > 0f)
                _tweenerInLateUpdate.update(deltaTime);
        }
    }
    void FixedUpdate()
    {
        if (_tweenerInFixedUpdate != null)
        {
            var deltaTime = Time.deltaTime;
            if (deltaTime > 0f)
                _tweenerInFixedUpdate.update(deltaTime);
        }
    }

#endregion
}


#if USE_SIMPLE_UIMANAGER_APP
public class UIManager : MonoBehaviour
{
    static Tweener _tweener;
    static public Tweener tweener
    {
        get { return _tweener; }
    }

    void Awake()
    {
        //
        if (_tweener != null)
            Debug.LogError("_tweener != null", this);
        _tweener = new Tweener();
    }
    
    //
    float _lastTime = 0.0f;
    void Update()
    {
        //这个时间 不会受到Time.timeScale的影响
        var dt = Time.realtimeSinceStartup - _lastTime;
        _lastTime = Time.realtimeSinceStartup;
        _tweener.update(dt);
    }
}

public class RNApp : MonoBehaviour
{
    //
    static protected Tweener _tweener;
    static public Tweener tweener
    {
        get { return _tweener; }
    }

    void Awake()
    {
        //
        if (_tweener != null)
            Debug.LogError("_tweener != null", this);
        _tweener = new Tweener();
    }

    protected void Update()
    {
        var deltaTime = Time.deltaTime;
        if (deltaTime > 0f)
            _tweener.update(deltaTime);
    }

}
#endif
