using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class ShoutController : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private PlayerInputAsset playerInput;
    [SerializeField] private List<ShoutSO> shoutList = new();
    //[SerializeField] private AudioClip[] wordsAudio;
    [SerializeField] private List<AudioClip> wordsAudio = new();
    private bool shoutPhase1 = false;
    private bool shoutPhase2 = false;
    private bool shoutPhase3 = false;
    private string shout;
    private float time;
    private void Awake()
    {
        playerInput = new PlayerInputAsset();
    }
    private void OnEnable()
    {
        playerInput.Enable();
        for (int i = 0; i < 2; i++)
        {
            wordsAudio[i] = shoutList[0].wordAudioList[i];
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

            if (time >= 0f && !shoutPhase1)
            {
                Debug.Log("FUS");
                shoutPhase1 = true;
                audioSource.clip = wordsAudio[0];
                audioSource.Play();
            }
            if (time >= 0.5f && !shoutPhase2)
            {
                Debug.Log("RO");
                shoutPhase2 = true;
                audioSource.clip = wordsAudio[1];
                audioSource.Play();
            }
            if (time >= 0.5f + audioSource.clip.length && !shoutPhase3 && !audioSource.isPlaying)
            {
                Debug.Log("DAH");
                shoutPhase3 = true;
                audioSource.clip = wordsAudio[2];
                audioSource.Play();
            }

        }

    }
}
