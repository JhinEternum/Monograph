using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blacksmith : GAgent
{
    void Start()
    {
        base.Start();
        SubGoal s1 = new SubGoal("Blacksmithing", 1, true);
        goals.Add(s1, 3);
    }
}
