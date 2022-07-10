using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorProgressChanger : MonoBehaviour
{
    public SpriteRenderer[] sprites;
    public Gradient gradient;
    public float Progress
    {
        set
        {
            RenderProgress();
            _progress = value;
        }
        get
        {
            return _progress;
        }
    }

    [SerializeField]
    [Range(0, 1f)]
    private float _progress;

    public void RenderProgress()
    {
        foreach (var sprite in sprites)
        {
            sprite.color = gradient.Evaluate(Progress);
        }
    }
}
