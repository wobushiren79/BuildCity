using UnityEditor;
using UnityEngine;

public enum BuildRuleEnum
{
    //---0面---
    Zero = 0,

    //---1面---
    One_Up = 101,
    One_Down = 102,
    One_Left = 103,
    One_Right = 104,
    One_Before = 105,
    One_After = 106,

    //---2面---
    Two_Up_Down = 201,
    Two_Up_Left = 202,
    Two_Up_Right = 203,
    Two_Up_Before = 204,
    Two_Up_After = 205,

    Two_Down_Left = 211,
    Two_Down_Right = 212,
    Two_Down_Before = 213,
    Two_Down_After = 214,

    Two_Left_Right = 221,
    Two_Left_Before = 222,
    Two_Left_After = 223,

    Two_Right_Before = 231,
    Two_Right_After = 232,

    Two_Before_After = 241,

    //---3面---
    Three_Up_Down_Left = 301,
    Three_Up_Down_Right = 302,
    Three_Up_Down_Before = 303,
    Three_Up_Down_After = 304,

    Three_Up_Left_Right = 311,
    Three_Up_Left_Before = 312,
    Three_Up_Left_After = 313,

    Three_Up_Right_Before = 321,
    Three_Up_Right_After = 321,

    Three_Up_Before_After = 331,

    Three_Down_Left_Right = 341,
    Three_Down_Left_Before = 342,
    Three_Down_Left_After = 343,

    Three_Down_Right_Before = 351,
    Three_Down_Right_After = 352,

    Three_Down_Before_After = 361,

    Three_Left_Right_Before = 371,
    Three_Left_Right_After = 372,

    Three_Left_Before_After = 381,

    Three_Right_Before_After = 391,

    //---4面---
    Four_Left_Right_Before_After = 401,
    Four_Down_Right_Before_After = 402,
    Four_Down_Left_Before_After = 403,
    Four_Down_Left_Right_After = 404,
    Four_Down_Left_Right_Before = 405,

    Four_Up_Right_Before_After = 411,
    Four_Up_Left_Before_After = 412,
    Four_Up_Left_Right_After = 413,
    Four_Up_Left_Right_Before = 414,

    Four_Up_Down_Before_After = 421,
    Four_Up_Down_Right_After = 422,
    Four_Up_Down_Right_Before = 423,

    Four_Up_Down_Left_After = 431,
    Four_Up_Down_Left_Before = 432,

    Four_Up_Down_Left_Right = 441,

    //---5面---
    Five_Down_Left_Right_Before_After = 501,
    Five_Up_Left_Right_Before_After = 502,
    Five_Up_Down_Right_Before_After = 503,
    Five_Up_Down_Left_Before_After = 504,
    Five_Up_Down_Left_Right_After = 505,
    Five_Up_Down_Left_Right_Before = 506,

    //---6面---
    Size = 601,
}