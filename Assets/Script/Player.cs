using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string name;
    public int points;
    public string level;
    public string[] unlocked;
    public string[] badges;

    public void setName(string name)
    {
        this.name = name;
    }

    public void setPoints(int point)
    {
        this.points = point;
    }
    public void setLevel(string level)
    {
        this.level = level;
    }


    public void setUnlocked(string[] unlocked)
    {
        this.unlocked = unlocked;
    }

    public void setBadges(string[] badges)
    {
        this.badges = badges;
    }

    public string getName()
    {
        return name;
    }

    public int getPoints()
    {
        return points;
    }

    public string getLevel()
    {
        return level;
    }

    public string[] getUnlocked()
    {
        return unlocked;
    }

    public string[] getBadges()
    {
        return badges;
    }


}
