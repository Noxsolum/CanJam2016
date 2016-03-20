using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof(ThirdPersonCharacter))]
    public class ThirdPersonUserControl : MonoBehaviour
    {
        private ThirdPersonCharacter m_Character;
        public ThirdPersonCharacter n_Character; // A reference to the ThirdPersonCharacter on the object
        private Transform m_Cam;                  // A reference to the main camera in the scenes transform
        private Vector3 m_CamForward;             // The current forward direction of the camera
        private Vector3 m_Move;
        private bool m_Jump;                      // the world-relative desired move direction, calculated from the camForward and user input.
        private bool m_Duck;

        private bool running, ducking;
        float runTime = 4.0f, runTimeLimit = 4.0f;
        float duckTime = .5f, duckTimeLimit = .5f;
        bool keyPressed = false;

        [SerializeField] public InputField inputObject;
        [SerializeField] public Slider runSlider;
        public string sSave;

        //ThirdPersonCharacter characterScript = 

        private void Start()
        {
            // get the transform of the main camera
            if (Camera.main != null)
            {
                m_Cam = Camera.main.transform;
            }
            else
            {
                Debug.LogWarning(
                    "Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.");
                // we use self-relative controls in this case, which probably isn't what the user wants, but hey, we warned them!
            }

            // get the third person character ( this should never be null due to require component )
            m_Character = GetComponent<ThirdPersonCharacter>();
        }


        private void Update()
        {
            sSave = inputObject.text;

            runSlider.value = runTime;
        }


        // Fixed update is called in sync with physics
        private void FixedUpdate()
        {
            if (Input.GetKeyDown("left ctrl"))
            {
                keyPressed = true;

                if (inputObject.text == "run")
                    runTime = 0.0f;

                if (inputObject.text == "duck")
                    duckTime = 0.0f;

                inputObject.text = "";
            }

            if (runTime < runTimeLimit)
                running = true;

            if (duckTime < duckTimeLimit)
                ducking = true;

            if (keyPressed)
            {
                if (sSave == "run" || running)
                    m_Move = Vector3.forward;

                if (sSave == "jump")
                    m_Jump = true;

                if (sSave == "duck" || ducking)
                    m_Duck = true;

                keyPressed = false;
                sSave = "";
            }

            runTime += Time.deltaTime;
            duckTime += Time.deltaTime;

            if (runTime >= runTimeLimit)
            {
                keyPressed = false;
                running = false;
                m_Move = new Vector3(0.0f, 0.0f, 0.0f);
            }

            if (duckTime >= duckTimeLimit)
                m_Duck = false;

            // pass all parameters to the character control script
            m_Character.Move(m_Move, m_Duck, m_Jump);
            m_Jump = false;
        }
    }
}