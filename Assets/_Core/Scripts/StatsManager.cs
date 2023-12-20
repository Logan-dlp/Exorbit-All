using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new_" + nameof(StatsManager))]
public class StatsManager : ScriptableObject
{
    public int handle = 1;
    public int score = 0;
}
