using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumManager
{
    //角色朝向
    public enum RoleToward
    {
        Up,
        Down,
        Left,
        Right
    }
    //玩家状态
    public enum PlayerState
    {
        Idle,
        WalkUp,
        WalkDown,
        WalkLeft,
        WalkRight,
        //AtkUp,
        //AtkDown,
        //AtkLeft,
        //AtkRight
    }
}
