using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleProgressBar : MonoBehaviour
{
    public GameObject rightMask, leftMask;
    public float Progress
    {
        set
        {
            _progress = value;
            RenderProgress();
        }
        get
        {
            return _progress;
        }
    }

    [SerializeField]
    [Range(0,1f)]
    private float _progress;

    public void RenderProgress()
    {
        if (Progress <= 0.5f)
        {
            leftMask.transform.rotation = Quaternion.Euler(0, 0, 180);
            rightMask.transform.rotation = Quaternion.Euler(0, 0, Mathf.Lerp(360,180, Progress * 2));
        } else {
            leftMask.transform.rotation = Quaternion.Euler(0, 0, Mathf.Lerp(180, 0, (Progress-0.5f) * 2));
            rightMask.transform.rotation = Quaternion.Euler(0, 0, 180);
        }
    }
}
