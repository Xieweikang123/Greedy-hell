using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : CharacterProperty
{
    public EnumManager.PlayerState playerState = EnumManager.PlayerState.Idle;

    private float v, h;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        v = Input.GetAxis("Vertical");
        h = Input.GetAxis("Horizontal");

        if (v == 0 && h == 0)
        {
            playerState = EnumManager.PlayerState.Idle;
            SetAnim();
            return;
        }
        JudgeDir(h, v);
        transform.Translate(new Vector3(h, v, 0) * moveSpeed * Time.deltaTime);

        //如果键盘移动键抬起，将状态置为idle
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            playerState = EnumManager.PlayerState.Idle;
            // print("h :" + h + "   v: " + v);
        }

        SetAnim();
    }

    public void Move(Vector2 dir)
    {
        JudgeDir(dir.normalized);
        transform.Translate(dir.normalized * moveSpeed * Time.fixedDeltaTime);
    }
    /// <summary>
    /// 根据方向判断动画朝向
    /// </summary>
    private void JudgeDir(float h, float v)
    {
        //水平大于竖直位移
        if (Mathf.Abs(v) < Mathf.Abs(h))
        {
            //右
            if (h > 0)
            {
                playerState = EnumManager.PlayerState.WalkRight;
            }
            else
            {
                playerState = EnumManager.PlayerState.WalkLeft;
            }
        }
        else
        {
            //上
            if (v > 0)
            {
                playerState = EnumManager.PlayerState.WalkUp;
            }
            else
            {
                playerState = EnumManager.PlayerState.WalkDown;
            }
        }
    }
    private void JudgeDir(Vector2 dir)
    {
        //水平数值大于竖直
        if (Mathf.Abs(dir.x) > Mathf.Abs(dir.y))
        {
            //右
            if (dir.x > 0)
            {
                playerState = EnumManager.PlayerState.WalkRight;
            }
            else
            {
                playerState = EnumManager.PlayerState.WalkLeft;
            }
        }
        else
        {
            //up
            if (dir.y > 0)
            {
                playerState = EnumManager.PlayerState.WalkUp;
            }
            else
            {
                playerState = EnumManager.PlayerState.WalkDown;
            }
        }
    }

    private void SetAnim()
    {
        animator.SetBool("Idle", false);
        animator.SetBool("WalkUp", false);
        animator.SetBool("WalkDown", false);
        animator.SetBool("WalkLeft", false);
        animator.SetBool("WalkRight", false);

        animator.SetBool(playerState.ToString(), true);

    }

}
