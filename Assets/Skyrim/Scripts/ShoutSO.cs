using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Shout", menuName = "Shouts/New Shout")]
public class ShoutSO : ScriptableObject
{
    public string shoutName;
    public string word1;
    public string word2;
    public string word3;

    public float shoutCooldown;
    public float[] wordsTiming;

    public AudioClip fullShoutAudioClip;
    public AudioClip[] wordAudioList;

    public Dictionary<AudioClip, string> wordDictionary = new();
    public enum WordsOfPower { EMPTY, WORD1, WORD2, WORD3 };

    public WordsOfPower shoutState;

    public void SetAudioSettings()
    {
        for (int i = 0; i < wordsTiming.Length; i++)
        {
            if (i == 0)
                wordsTiming[i] = 0f;
            else
                wordsTiming[i] = wordAudioList[i].length + wordAudioList[i - 1].length;
        }
    }

    public void OnValidate()
    {
        //shoutName = this.GetType().Name;
        SetAudioSettings();
    }
}
