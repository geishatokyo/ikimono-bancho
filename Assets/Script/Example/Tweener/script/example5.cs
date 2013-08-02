using UnityEngine;
using System.Collections;

public class example5 : MonoBehaviour
{
    //
    IEnumerator Start()
    {
        //
        yield return StartCoroutine(new Tween(this, 2f, 0f)
            .transform.position.y.to(3)
            .playEnumerator());



        //
        var t = new Tween(this, 2, 0)
            .transform.position.y.to(-3);

        var e = t.playEnumerator();

        while (e.MoveNext())
            yield return null;
    }
    
}