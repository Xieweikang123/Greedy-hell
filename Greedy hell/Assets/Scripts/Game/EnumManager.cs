using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumManager
{

    private static EnumManager _instance;

    public EnumManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = this;
            return _instance;
        }
    }

    public enum PlayerState
    {
        Idle,
        WalkUp,
        WalkDown,
        WalkLeft,
        WalkRight,
        Attack
    }
}
