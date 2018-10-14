using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : CharacterProperty
{
    public EnumManager.PlayerState playerState = EnumManager.PlayerState.Idle;

    private EnumManager.RoleToward playerToward = EnumManager.RoleToward.Down;

    private float v, h;

    public Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        v = Input.GetAxis("Vertical");
        h = Input.GetAxis("Horizontal");



        if (v == 0 && h == 0)
        {

            //animator.CrossFadeInFixedTime("Warrior" + playerState.ToString(), 0f, 0);
        }
        else
        {
            JudgeDir(h, v);
            transform.Translate(new Vector3(h, v, 0) * moveSpeed * Time.deltaTime);
        }
        //如果按下J，攻击
        if (Input.GetKeyDown(KeyCode.J))
        {
            PlayATKAnimByToward();
        }
#endif
        SetAnim();
    }

    public void Move(Vector2 dir)
    {
        JudgeDir(dir.normalized);
        SetAnim();

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
                playerToward = EnumManager.RoleToward.Right;
            }
            else
            {
                playerState = EnumManager.PlayerState.WalkLeft;
                playerToward = EnumManager.RoleToward.Left;
            }
        }
        else
        {
            //上
            if (v > 0)
            {
                playerState = EnumManager.PlayerState.WalkUp;
                playerToward = EnumManager.RoleToward.Up;
            }
            else
            {
                playerState = EnumManager.PlayerState.WalkDown;
                playerToward = EnumManager.RoleToward.Down;
            }
        }
    }
    private void JudgeDir(Vector2 dir)
    {
        animator.speed = 1.0f;

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
    //根据角色朝向播放不同方位的攻击动画
    private void PlayATKAnimByToward()
    {
        switch (playerToward)
        {
            case EnumManager.RoleToward.Up:
                animator.SetTrigger("ATKUp");
                break;
            case EnumManager.RoleToward.Down:
                animator.SetTrigger("ATKDown");
                break;
            case EnumManager.RoleToward.Left: animator.SetTrigger("ATKLeft"); break;
            case EnumManager.RoleToward.Right: animator.SetTrigger("ATKRight"); break;
            default: Debug.LogError("未知朝向"); break;
        }
    }

}
