using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/*
public class TweenEnumerator
{
    public BaseTween tween { get; protected set; }

    public TweenEnumerator(BaseTween t)
    {
        tween = t;
    }


    //
    public IEnumerator play()
    {
        while (true)
        {
            yield return null;

            var deltaTime = UnityEngine.Time.deltaTime;

            //
            if (tween.target.Equals(null))
            {
#if UNITY_EDITOR
                //Debug.LogWarning("BaseTween target is delete,name=" + debug_name + " id=" + kv.Key + "  target.HashCode=" + target.GetHashCode());
                tween._logDebug("Tween target is delete");
#endif
                yield break;
            }

            //
            if (tween.isForceFinished)
            {
                tween._onComplete();
                yield break;
            }
            else
            {
                //
                if (tween.isDelaying)
                {
                    if (tween._start(deltaTime))
                    {
                        tween._onStart();
                    }
                }


                //
                if (tween._animate(deltaTime))
                {
                    if (tween._finished())
                    {
                        tween._onComplete();
                        yield break;
                    }
                }
                else
                {
                    tween._onUpdate();
                }
            }
        }
    }
}
*/


public class TweensEnumerator
{
    public List<BaseTween> tweens { get; protected set; }


    public TweensEnumerator()
    {
        tweens = new List<BaseTween>();
    }

    public TweensEnumerator add(BaseTween t)
    {
        tweens.Add(t);
        return this;
    }

    //
    static List<BaseTween> startList = new List<BaseTween>();
    static List<BaseTween> updateList = new List<BaseTween>();
    static List<BaseTween> removeList = new List<BaseTween>();
    public IEnumerator play()
    {
        while (tweens.Count > 0)
        {
            yield return null;

            var deltaTime = UnityEngine.Time.deltaTime;

            foreach (var t in tweens)
            {
                //
                if (t.target.Equals(null))
                {
#if UNITY_EDITOR
                    //Debug.LogWarning("BaseTween target is delete,name=" + t.debug_name + " id=" + kv.Key + "  target.HashCode=" + t.target.GetHashCode());
                    t._logDebug("Tween target is delete");
#endif
                    t.onComplete = null;
                    t.onStart = null;
                    t.onUpdate = null;
                    removeList.Add(t);

                    continue;
                }

                //
                if (t.isForceFinished)
                {
                    removeList.Add(t);
                }
                else
                {
                    //
                    if (t.isDelaying)
                    {
                        if (t._start(deltaTime))
                        {
                            startList.Add(t);
                        }
                    }


                    //
                    if (t._animate(deltaTime))
                    {
                        if (t._finished())
                            removeList.Add(t);
                    }
                    else
                    {
                        updateList.Add(t);
                    }
                }
            }


            //
            foreach (BaseTween t in startList)
            {
                t._onStart();
            }
            startList.Clear();

            //
            foreach (BaseTween t in updateList)
            {
                t._onUpdate();
            }
            updateList.Clear();

            //
            foreach (BaseTween t in removeList)
            {
                tweens.Remove(t);
                t._onComplete();
            }
            removeList.Clear();
        }
    }

}