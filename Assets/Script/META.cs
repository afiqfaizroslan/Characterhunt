using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class META : MonoBehaviour
{
    public string Name;
    public Sprite Face;
    public bool unlocked;
    public string[] questions = new string[4];
    public string[] answer = new string[4];
    public string[] anim = new string[5];
    public float[] CoolDown = new float[4];

    public string getName()
    {
        return Name;
    }
    public Sprite getFace()
    {
        return Face;
    }

    public string GetQuestion(int index)
    {
        return questions[index];
    }

    public string GetAnswer(int index)
    {
        return answer[index];
    }

    public string GetAnimation(int index)
    {
        return anim[index];
    }

    public float GetCD(int index)
    {
        return CoolDown[index];
    }

    public void Unlocked()
    {
        unlocked = true;
    }

    public bool isUnlocked()
    {
        return unlocked;
    }

}
