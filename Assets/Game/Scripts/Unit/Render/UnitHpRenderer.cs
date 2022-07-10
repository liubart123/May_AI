using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitHpRenderer : MonoBehaviour
{
    public ColorProgressChanger colorProgressChanger;
    public CircleProgressBar circleProgressBar;

    public float HP
    {
        set
        {
            colorProgressChanger.Progress = value;
            circleProgressBar.Progress = value;
            _hp = value;
        }
        get
        {
            return _hp;
        }
    }

    [SerializeField]
    [Range(0, 1f)]
    private float _hp;


    [ContextMenu("renderProgress")]
    public void RenderProgress()
    {
        HP = _hp;
    }
}
