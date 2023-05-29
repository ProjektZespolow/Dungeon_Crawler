using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioSource skeletonWalk;
    public AudioSource playerLeftWalk;
    public AudioSource playerRightWalk;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void WalkSound()
    {
        skeletonWalk.Play();
    }

    void PlayerLeftWalkSound()
    {
        playerLeftWalk.Play();
    }
    void PlayerRightWalkSound()
    {
        playerRightWalk.Play();
    }
}
