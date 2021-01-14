using RotaryHeart.Lib.SerializableDictionary;
using System;
using UnityEditor;
using UnityEngine;

public enum BuildRuleEnum
{
    //---0面---
    Zero = 0,

    //---1面---
    One_Up = 1100000,
    One_Down = 1010000,
    One_Left = 1001000,
    One_Right = 1000100,
    One_Before = 1000010,
    One_After = 1000001,

    //---2面---
    Two_Up_Down = 2110000,
    Two_Up_Left = 2101000,
    Two_Up_Right = 2100100,
    Two_Up_Before = 2100010,
    Two_Up_After = 2100001,

    Two_Down_Left = 2011000,
    Two_Down_Right = 2010100,
    Two_Down_Before = 2010010,
    Two_Down_After = 2010001,

    Two_Left_Right = 2001100,
    Two_Left_Before = 2001010,
    Two_Left_After = 2001001,

    Two_Right_Before = 2000110,
    Two_Right_After = 2000101,

    Two_Before_After = 2000011,

    //---3面---
    Three_Up_Down_Left = 3111000,
    Three_Up_Down_Right = 3110100,
    Three_Up_Down_Before = 3110010,
    Three_Up_Down_After = 3110001,

    Three_Up_Left_Right = 3101100,
    Three_Up_Left_Before = 3101010,
    Three_Up_Left_After = 3101001,

    Three_Up_Right_Before = 3100110,
    Three_Up_Right_After = 3100101,

    Three_Up_Before_After = 3100011,

    Three_Down_Left_Right = 3011100,
    Three_Down_Left_Before = 3011010,
    Three_Down_Left_After = 3011001,

    Three_Down_Right_Before = 3010110,
    Three_Down_Right_After = 3010101,

    Three_Down_Before_After = 3010011,

    Three_Left_Right_Before = 3001110,
    Three_Left_Right_After = 3001101,

    Three_Left_Before_After = 3001011,

    Three_Right_Before_After = 3000111,

    //---4面---
    Four_Left_Right_Before_After = 4001111,
    Four_Down_Right_Before_After = 4010111,
    Four_Down_Left_Before_After = 4011011,
    Four_Down_Left_Right_After = 4011101,
    Four_Down_Left_Right_Before = 4011110,

    Four_Up_Right_Before_After = 4100111,
    Four_Up_Left_Before_After = 4101011,
    Four_Up_Left_Right_After = 4101101,
    Four_Up_Left_Right_Before = 4101110,

    Four_Up_Down_Before_After = 4110011,
    Four_Up_Down_Right_After = 4110101,
    Four_Up_Down_Right_Before = 4110110,

    Four_Up_Down_Left_After = 4111001,
    Four_Up_Down_Left_Before = 4111010,

    Four_Up_Down_Left_Right = 4111100,

    //---5面---
    Five_Down_Left_Right_Before_After = 5011111,
    Five_Up_Left_Right_Before_After = 5101111,
    Five_Up_Down_Right_Before_After = 5110111,
    Five_Up_Down_Left_Before_After = 5111011,
    Five_Up_Down_Left_Right_After = 5111101,
    Five_Up_Down_Left_Right_Before = 5111110,

    //---6面---
    Six = 6111111,
}

public class BuildRuleEnumTool
{
    public static BuildRuleEnum GetBuildRule(int number, bool up, bool down, bool left, bool right, bool before, bool after)
    {
        int ruleTemp = number * 1000000;
        if (up)
            ruleTemp += 100000;
        if (down)
            ruleTemp += 10000;
        if (left)
            ruleTemp += 1000;
        if (right)
            ruleTemp += 100;
        if (before)
            ruleTemp += 10;
        if (after)
            ruleTemp += 1;
        return (BuildRuleEnum)ruleTemp;
    }

    public static void GetBuildRuleData(BuildRuleEnum buildRule, out int number, out bool up, out bool down, out bool left, out bool right, out bool before, out bool after)
    {
        int ruleTemp = (int)buildRule;
        number = (ruleTemp % 10000000) / 1000000;
        up = (ruleTemp % 1000000) / 100000 == 1 ? true : false;
        down = (ruleTemp % 100000) / 10000 == 1 ? true : false;
        left = (ruleTemp % 10000) / 1000 == 1 ? true : false;
        right = (ruleTemp % 1000) / 100 == 1 ? true : false;
        before = (ruleTemp % 100) / 10 == 1 ? true : false;
        after = (ruleTemp % 10) == 1 ? true : false;
    }
}

[Serializable]
public class BuildRuleDictionary : SerializableDictionaryBase<BuildRuleEnum, GameObject>
{

}