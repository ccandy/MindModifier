using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HexMatrics
{
    public const float OuterRad = 10.0f;
    public const float InnerRad = OuterRad * 0.866025404f;

    public static Vector3[] Corners =
    {
        new Vector3(InnerRad, 0.0f, OuterRad * 0.5f),
        new Vector3(InnerRad, 0.0f, 0.0f),
        new Vector3(InnerRad, 0.0f, -OuterRad * 0.5f),
        new Vector3(-InnerRad, 0.0f, -OuterRad * 0.5f),
        new Vector3(-InnerRad, 0.0f, 0.0f),
        new Vector3(-InnerRad, 0.0f, OuterRad * 0.5f),
        new Vector3(0.0f, OuterRad)
    };


}
