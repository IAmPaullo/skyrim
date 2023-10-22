using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Shout", menuName = "Shouts/New Shout")]
public class ShoutSO : ScriptableObject
{
    public string word1;
    public string word2;
    public string word3;

    public AudioClip fullShoutAudioClip;
    public AudioClip[] wordAudioList;

    

    public enum WordsOfPower { EMPTY , WORD1, WORD2, WORD3 };

    public WordsOfPower shoutState;

}
