// Greg Paolo D. Violan
// Last updated on: 12/31/16
// Game: Animal Run
// PlayerManager

// Imports
using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
///  PlayerManager class controls the player object and its surrounding environments.
///  The player object is animated, automated run, and able to control their jump.
///  It also uses sounds that are triggered depending on different events.
/// </summary>
public class PlayerManager : MonoBehaviour
{
    // Declaring variables
    private Animator _anim;
    private Rigidbody2D _myRigidBody;
    private AudioSource[] _audios;
    private AudioSource _jumpSound, _dyingSound;
    private bool _jumping, _grounded, _jumpSoundPlayed, _dead, _buttonHeld, _start;
    private float _speed, _jumpTimeCounter, _speedMilestoneCount, _timeMouseDown;
	private GameObject _instructions;

    public float speedX, speedMultiplier, speedIncreaseMilestone, jumpSpeedY, jumpTime;
    public ScoreManager scoreManager;
    public ObstacleGenerator obsGen;

    // Initializing variables
    void Start()
    {
        _anim = GetComponent<Animator>();
        _myRigidBody = GetComponent<Rigidbody2D>();
        _audios = GetComponents<AudioSource>();
        _instructions = GameObject.Find("Instructions");
        _jumpSound = _audios[0];
        _dyingSound = _audios[1];
        _jumpTimeCounter = jumpTime;
        _speedMilestoneCount = speedIncreaseMilestone;
        _grounded = false;
        _dead = false;
        _buttonHeld = false;
        _jumpSoundPlayed = false;
        _start = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_anim.GetInteger("State") != 4 && _start)
        {
            _instructions.SetActive(false);                                             // remove instruction display
            MovePlayer(_speed);                                                         // calls the function that moves the player                                                  

            // player jump
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space) || _buttonHeld)
            {
                if (_jumpTimeCounter > 0)
                {
                    PlayJumpSound();
                    Jump();
                    _jumpTimeCounter -= Time.deltaTime;
                }
            }

            // player let go of the jump key thereby it won't let them jump anymore
            if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.Space))
            {
                _jumpTimeCounter = 0;
                _grounded = false;
            }
        }

		if (Input.GetKeyDown(KeyCode.Escape)) 
		{ 
			Application.Quit(); 
		}
    }

    /// <summary>
    /// Moves the player forward.
    /// </summary>
    /// <param name="playerSpeed"></param>
    void MovePlayer(float playerSpeed)
    {
        _myRigidBody.velocity = new Vector3(_speed, _myRigidBody.velocity.y, 0);        // code for player movement

        // setting animations for run and idle
        if (playerSpeed < 0 && !_jumping || playerSpeed > 0 && !_jumping)
        {
            _anim.SetInteger("State", 2);
        }
        if (playerSpeed == 0 && !_jumping)
        {
            _anim.SetInteger("State", 0);
        }

        // increasing speed of the player when it reaches the milestone, also incraese the distance between pipes to make it possible to jump
        // (making the game more harder the longer you play)
        if (transform.position.x > _speedMilestoneCount)
        {
            _speedMilestoneCount += speedIncreaseMilestone;
            speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;
            speedX = speedX * speedMultiplier;

			obsGen.distanceBetweenMinX = obsGen.distanceBetweenMinX * (speedMultiplier - 0.02f);
			obsGen.distanceBetweenMaxX = obsGen.distanceBetweenMaxX * (speedMultiplier - 0.02f);
        }

        _speed = speedX;                                                                // auto run
    }

    /// <summary>
    /// This method is called when the player collides with another object
    /// </summary>
    /// <param name="other"></param>
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            _anim.SetInteger("State", 0);
            _jumping = false;
            _jumpSoundPlayed = false;
            _grounded = true;                                                           // set the player grounded
            _jumpTimeCounter = jumpTime;                                                // reset jump timer

            // hide the score whenever the player touches the ground
            if (scoreManager.IsShow())
            {
                scoreManager.ToggleScoreText();
            }
        }

        // when the player collides with an object tagged as "Objects", it dies
        if (other.gameObject.tag == "Objects")
        {
			Dying ();
        }

		Collider2D collider = other.collider; // collider of object that is gonna collide with the Player
		float rectWidth = this.GetComponent<Collider2D> ().bounds.size.x; // width of Player box collider
		float rectHeight = this.GetComponent<Collider2D> ().bounds.size.y; // height of Player box collider

		if (other.gameObject.tag == "Snowball") // find the object snowball 
		{
			//Dying ();


			Vector3 contactPoint = other.contacts [0].point;
			Vector3 center =  collider.bounds.center;

			if (contactPoint.y > center.y && (contactPoint.x < center.x + rectWidth / 2 && contactPoint.x > center.x - rectWidth / 2 )) {
				_myRigidBody.AddForce (transform.up * 500);
				_jumping = false;
				_jumpSoundPlayed = false;
				_grounded = true;
				_jumpTimeCounter = jumpTime;
			} 
			else 
			{
				Dying ();
			}
			/*
			else if(contactPoint.y < center.y && (contactPoint.x < center.x + rectWidth / 2 && contactPoint.x > center.x - rectWidth / 2 ))
			{
				Dying ();
			}
			else if(contactPoint.x > center.x && (contactPoint.y < center.y + rectHeight / 2 && contactPoint.y > center.y - rectHeight/ 2 ))
			{
				Dying ();
			}
			else if(contactPoint.x < center.x && (contactPoint.y < center.y + rectHeight / 2 && contactPoint.y > center.y - rectHeight/ 2 ))
			{
				Dying ();
			}
			*/

		}

    }
    /// <summary>
    /// When player triggers a score collider, increase player's score
    /// </summary>
    /// <param name="collider"></param>
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Score")
        {
            scoreManager.ToggleScoreText();
            scoreManager.IncreaseScore();
        }
    }

    /// <summary>
    ///  Jumping function.
    /// </summary>
    public void Jump()
    {
        if (_grounded && !_dead)
        {
            _jumping = true;
            _myRigidBody.velocity = (new Vector2(_myRigidBody.velocity.x, jumpSpeedY));
            _anim.SetInteger("State", 3);
        }

    }
    /// <summary>
    /// Play jump sound only when the player is on the ground.
    /// </summary>
    public void PlayJumpSound()
    {
        if (_jumpSoundPlayed) return;
        _jumpSound.Play();
        _jumpSoundPlayed = true;
    }

    /// <summary>
    /// Mobile UI button, when the screen is pressed
    /// </summary>
    /// <param name="eventData"></param>
    public void pressed(BaseEventData eventData)
    {
        _start = true;
        _buttonHeld = true;
    }

    /// <summary>
    /// Mobile UI button, when the screen is not pressed.
    /// </summary>
    /// <param name="eventData"></param>
    public void notpressed(BaseEventData eventData)
    {
        _buttonHeld = false;
        _jumpTimeCounter = 0;
    }

	public bool isDead()
	{
		return _dead;
	}

 	void Dying()
	{
		_anim.SetInteger("State", 4);

		speedX = 0;                                                                 // set speed to 0
		_grounded = false;                                                          // set grounded to false so the player can't jump anymore

		// play dying sound
		if (!_dead)
		{
			_dyingSound.Play();
		}

		_dead = true;                                                               // set player dead

		scoreManager.displayRestartUI ();                                            // display the RestartUI
	}

	public bool start()
	{
		return _start;
	}
}

