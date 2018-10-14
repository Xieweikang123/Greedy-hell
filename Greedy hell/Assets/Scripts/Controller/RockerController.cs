using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RockerController : MonoBehaviour, IDragHandler, IEndDragHandler
{
    [SerializeField]
    private GameObject virtualRocker;
    [SerializeField]
    private GameObject movePointBall;

    [SerializeField]
    private PlayerControll playerController;

    private bool isFirstSetPos = true;    //第一次设置虚拟摇杆位置

    private Vector3 dir;
    private Vector3 normalPosition; //初始位置

    private float virtualBallradious;//虚拟球运动半径

    //private bool isDraging = false;     //是否处于拖拽状态 

    private void Start()
    {
        normalPosition = virtualRocker.transform.localPosition;

        virtualBallradious = virtualRocker.GetComponent<RectTransform>().rect.width / 2;
    }

    private void FixedUpdate()
    {
        if(!isFirstSetPos)
             playerController.Move(dir);
    }

    public void OnDrag(PointerEventData eventData)
    {

        Vector3 point;
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(movePointBall.GetComponent<RectTransform>(), eventData.position, Camera.main, out point))
        {
            movePointBall.transform.position = point;
            dir = point - virtualRocker.transform.position;

            //限制虚拟球运动范围
            if (movePointBall.transform.localPosition.magnitude >= virtualBallradious)
            {
                movePointBall.transform.localPosition = dir.normalized * virtualBallradious;
            }

            //首次定位
            if (isFirstSetPos)
            {
                isFirstSetPos = false;
                virtualRocker.transform.position = point;
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //虚拟球复位
        virtualRocker.transform.localPosition = normalPosition;

        movePointBall.transform.localPosition = Vector2.zero;
        //click = false;
        isFirstSetPos = true;

        playerController.animator.speed = 0;
        
    }
}
