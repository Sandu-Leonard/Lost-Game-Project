using UnityEngine;

public class Goal
{
    public int countNeeded;
    public int countCurrent;
    public bool completed;

    public void IncrementCount(int amount)
    {
        countCurrent = Mathf.Min(countCurrent + 1, countNeeded);
        if (countCurrent >= countNeeded && !completed)
        {
            completed = true;
        }
    }

}
