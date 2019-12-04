using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuAudio : MonoBehaviour
{
        public AudioSource m_AudioSource;

        void Start()
        {
            //Fetch the AudioSource component of the GameObject (make sure there is one in the Inspector)
            m_AudioSource = GetComponent<AudioSource>();
            //Stop the Audio playing
            m_AudioSource.Stop();

        }
        void Update()
        {
            //Turn the loop on and off depending on the Toggle status
            m_AudioSource.loop = true;
        }
}
