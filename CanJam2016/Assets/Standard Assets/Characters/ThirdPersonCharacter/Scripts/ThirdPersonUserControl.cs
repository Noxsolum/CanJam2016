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
        private Vector3 m_Move;
        private bool m_Jump;                      // the world-relative desired move direction, calculated from the camForward and user input.
        private bool m_Duck;

        private bool running, ducking;
        float runTime = 6.0f, runTimeLimit = 6.0f;
        float duckTime = 1.0f, duckTimeLimit = 1.0f;
        bool keyPressed = false, gameStarted = false;
        float deathTimer = 0.0f, deathTimeLimit = 6.0f;

        [SerializeField] public InputField inputObject;
        [SerializeField] public Slider runSlider;
        [SerializeField] public Text gameOver;
        public string sSave;

        public GameObject explosion;

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

            if (gameStarted)
            {
                if (deathTimer < deathTimeLimit)
                    deathTimer += Time.deltaTime;
                else
                {
                    gameOver.text = "Game Over - Press 'esc' to restart";
                }
            }
        }


        // Fixed update is called in sync with physics
        private void FixedUpdate()
        {
            Vector3 realForward = new Vector3(0.017f, 0.0f, 1.0f);

            if (gameOver.text != "Game Over - Press 'esc' to restart")
            {
                if (Input.GetKeyDown("left ctrl"))
                {
                    keyPressed = true;

                    if (inputObject.text == "run" || inputObject.text == "right" || inputObject.text == "left")
                    {
                        runTime = 0.0f;
                        deathTimer = 0.0f;
                    }

                    if (inputObject.text == "duck")
                        duckTime = 0.0f;

                    inputObject.text = "";

                    gameStarted = true;
                }

                if (runTime < runTimeLimit)
                    running = true;

                if (duckTime < duckTimeLimit)
                    ducking = true;

                if (keyPressed)
                {
                    if (sSave == "run" || running)
                        m_Move = realForward;

                    if (sSave == "left")
                    {
                        m_Move = Vector3.left;
                        print(m_Move);
                    }

                    if (sSave == "right")
                    {
                        m_Move = Vector3.right;
                        print(m_Move);
                    }

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
            else
            {
                explosion.SetActive(true);

                if (Input.GetKeyDown("escape"))
                {
                    Application.LoadLevel(0);
                }
            }
        }
    }
}