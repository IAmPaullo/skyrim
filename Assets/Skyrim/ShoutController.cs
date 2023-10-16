using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class ShoutController : MonoBehaviour
{
    [SerializeField] private PlayerInputAsset playerInput;
    bool shout1 = false;
    bool shout2 = false;
    bool shout3 = false;
    string shout;
    float time;
    private void Awake()
    {
        playerInput = new PlayerInputAsset();
    }
    private void OnEnable()
    {
        playerInput.Enable();
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

            if (time >= 1 && !shout1)
            {
                Debug.Log("FUS");
                shout1 = true;
            }
            if (time >= 2 && !shout2)
            {
                Debug.Log("RO");
                shout2 = true;
            }
            if (time >= 3 && !shout3)
            {
                Debug.Log("DAH");
                shout3 = true;
            }

        }

    }
}
