using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemeyController : MonoBehaviour
{
    private Rigidbody2D m_Rigidbody2D;
	private bool m_FacingRight = true;
	private bool m_Grounded = true;
	[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;
	[SerializeField] private bool m_AirControl = false;
	//[SerializeField] private float m_delayGroundCheck = 0.25f;
	private Vector3 m_Velocity = Vector3.zero;
	public Animator animator;
	public float runSpeed = 1f;
	private float direction = 1;
	public float pointA;
	public float pointB;
	private Vector2 defaultPosition;
	private bool isCatching = false;
	private bool stop = false;
	public Transform playerTransform;
	private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
		defaultPosition = new Vector2(transform.position.x, transform.position.y);
		animator.SetFloat("Speed", Mathf.Abs(runSpeed));
	}

    // Update is called once per frame
    void Update()
    {
		if (!isCatching)
		{
			if (transform.position.x >= defaultPosition.x + pointB && direction == 1)
			{
				Flip();
				direction *= -1;
			}
			else if (transform.position.x <= defaultPosition.x - pointA && direction == -1)
			{
				Flip();
				direction *= -1;
			}
		}
		else if(isCatching && !stop)
		{

			if( transform.position.x > playerTransform.position.x && m_FacingRight)
			{
				Flip();
				direction *= -1;
			}
			else if(transform.position.x < playerTransform.position.x && !m_FacingRight)
			{
				Flip();
				direction *= -1;
			}

			if (transform.position.x == playerTransform.position.x || transform.position.x >= defaultPosition.x + pointB && direction == 1 
				|| transform.position.x <= defaultPosition.x - pointA && direction == -1)
			{
				stop = true;
			}
		}

    }

	void FixedUpdate()
	{
		if (!stop)
		{
			Move(runSpeed);
		}
	}

	public void Move(float move)
	{
		//only control the player if grounded or airControl is turned on
		if (m_Grounded)
		{
			// Move the character by finding the target velocity
			Vector3 targetVelocity = new Vector2(move * 5f *direction, m_Rigidbody2D.velocity.y);
			// And then smoothing it out and applying it to the character
			m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
		}
	}

	public void MoveToPlayer(float move)
	{
		if (m_Grounded)
		{
			Vector2 target = new Vector2(transform.position.x + (playerTransform.position.x - transform.position.x), m_Rigidbody2D.velocity.y);
			m_Rigidbody2D.MovePosition(target*Time.fixedDeltaTime);
		}
	}

	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

		
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
		
	}

	public void OnDetectedPlayer()
	{
		isCatching = true;
	}
	public void OnLostPlayer()
	{
		isCatching = false;
		stop = false;
	}
}
