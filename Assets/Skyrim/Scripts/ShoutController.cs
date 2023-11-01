using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;
public class ShoutController : Subject
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private PlayerInputAsset playerInput;
    [SerializeField] private List<ShoutSO> shoutList = new();
    [SerializeField] private List<AudioClip> wordsAudio = new();
    [SerializeField] private List<float> wordTiming = new();
    private Dictionary<string, ShoutSO> shoutDictionary = new Dictionary<string, ShoutSO>();
    private bool shoutPhase1 = false;
    private bool shoutPhase2 = false;
    private bool shoutPhase3 = false;
    private float time;


    private float shoutCooldown;
    private void Awake()
    {
        playerInput = new PlayerInputAsset();

    }

    private void OnEnable()
    {
        playerInput.Enable();
        for (int i = 0; i <= 2; i++)
        {
            wordsAudio.Add(shoutList[0].wordAudioList[i]);
            wordTiming.Add(shoutList[0].wordsTiming[i]);
            shoutCooldown = shoutList[0].shoutCooldown;
        }

        for (int i = 0; i < shoutList.Count; i++)
        {
            shoutDictionary.Add(shoutList[i].shoutName, shoutList[i]);
        }
    }


    private void Update()
    {
        Shout();

    }
    private void Shout()
    {
        bool condition = playerInput.Player.Shout.ReadValue<float>() > 0.1f;
        if (condition)
        {
            time += Time.deltaTime;

            if (time >= wordTiming[0] && !shoutPhase1)
            {
                NotifyObservers(ShoutWords.WORD1);
                Debug.Log("FUS");
                shoutPhase1 = true;
                audioSource.clip = wordsAudio[0];
                audioSource.Play();
            }
            if (time >= wordTiming[1] && !shoutPhase2)
            {
                Debug.Log("RO");
                NotifyObservers(ShoutWords.WORD2);
                shoutPhase2 = true;
                audioSource.clip = wordsAudio[1];
                audioSource.Play();
            }
            if (time >= wordTiming[2]/*0.5f + audioSource.clip.length*/ && !shoutPhase3 && !audioSource.isPlaying)
            {
                Debug.Log("DAH");
                NotifyObservers(ShoutWords.WORD3);
                shoutPhase3 = true;
                audioSource.clip = wordsAudio[2];
                audioSource.Play();
            }
        }
    }

    public async void ShoutCooldown()
    {

        await Task.Delay((int)shoutCooldown * 1000);
        time = 0f;
        shoutPhase1 = false;
        shoutPhase2 = false;
        shoutPhase3 = false;
        audioSource.clip = null;
    }

    private void ResetAllShouts(InputAction.CallbackContext context)
    {
        if (context.canceled)
        {
            time = 0f;
            shoutPhase1 = false;
            shoutPhase2 = false;
            shoutPhase3 = false;
            audioSource.clip = null;
        }
        //bool condition = playerInput.Player.ResetShout.ReadValue<float>() > 0.1f;
        //if (condition)
        //{

        //}
    }

    public void OnNotify()
    {

    }

}
