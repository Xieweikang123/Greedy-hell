using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RockerController :MonoBehaviour, IDragHandler,IEndDragHandler
{
    private float JoyStickRadius = 50;   //摇杆最大半径

    private RectTransform selfTransform;// 当前物体的Transform组件

    private bool isTouched = false;// 是否触摸了虚拟摇杆

    private Vector2 originPosition; //虚拟摇杆默认位置
    //虚拟摇杆移动方向
    private Vector2 touchedAxis;

    public Vector2 TouchedAxis
    {
        get
        {
            if (touchedAxis.magnitude < JoyStickRadius)
                return touchedAxis.normalized / JoyStickRadius;
            return touchedAxis.normalized;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerDrag);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
    }
}
