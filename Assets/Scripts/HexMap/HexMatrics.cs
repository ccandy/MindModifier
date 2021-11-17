using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HexMatrics
{
    public const float OuterRad = 10.0f;
    public const float InnerRad = OuterRad * 0.866025404f;

    public static Vector3[] Corners =
    {
        new Vector3(0f, 0f, OuterRad),
        new Vector3(InnerRad, 0f, 0.5f * OuterRad),
        new Vector3(InnerRad, 0f, -0.5f * OuterRad),
        new Vector3(0f, 0f, -OuterRad),
        new Vector3(-InnerRad, 0f, -0.5f * OuterRad),
        new Vector3(-InnerRad, 0f, 0.5f * OuterRad),
        new Vector3(0f, 0f, OuterRad)
    };


}
