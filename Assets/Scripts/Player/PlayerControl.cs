using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlayerMove))]
    public class PlayerControl : MonoBehaviour
    {
        private PlayerMove character;
        private bool jump;


        private void Awake()
        {
            character = GetComponent<PlayerMove>();
        }


        private void Update()
        {
            if (!jump)
            {
                jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }
        }


        private void FixedUpdate()
        {
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            character.Move(h,jump);
            jump = false;
        }
    }
}
