using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]

public class Footstep : MonoBehaviour
{

    private AudioSource m_Audio;
    public AudioClip[] _GrassSounds;
    public AudioClip[] _MudSounds;
    public AudioClip[] _GravelSounds;
    public CharacterController _CharController;
    private Rigidbody _RigBod;
    private bool playSteps;



    void Awake()
    {
        m_Audio = gameObject.AddComponent<AudioSource>();
        _RigBod = _CharController.GetComponent<Rigidbody>();
    }

    void Start()
    {
        StartCoroutine(PlayFootstep());
        playSteps = true;
    }

    void Update()
    {
        if (!_CharController.isGrounded && playSteps)
        {
            playSteps = false;
            StopCoroutine(PlayFootstep());
        }
        else if (_CharController.isGrounded && !playSteps && _CharController.velocity.magnitude > 0.2f)
        {
            StartCoroutine(PlayFootstep());
        }
    }


    IEnumerator PlayFootstep()
    {
        int curSplatIndex = 1;

        switch (curSplatIndex)
        {
            case 0:
                yield return new WaitForSeconds(0.4f);
                m_Audio.PlayOneShot(_GrassSounds[Random.Range(0, _GrassSounds.Length - 1)]);
                break;
            case 1:
                m_Audio.PlayOneShot(_GravelSounds[Random.Range(0, _GravelSounds.Length - 1)]);
                break;
            case 2:
                m_Audio.PlayOneShot(_MudSounds[Random.Range(0, _MudSounds.Length - 1)]);
                break;
        }
    }

}