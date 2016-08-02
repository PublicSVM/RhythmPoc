using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Extensions
{
    public static class Extensions
    {
        public static void PlaySafe(this AudioSource audioSource, AudioClip audioClip)
        {
            if (audioClip != null)
            {
                audioSource.PlayOneShot(audioClip);
            }
        }
    }
}
