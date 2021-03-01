using UnityEngine;
using System.Collections;


	public class PlayerScript : MonoBehaviour
	{

		// The Rewired player id of this character
		public int playerId = 0;

		// The movement speed of this character
		public float moveSpeed = 100.0f;

	public ChargeBar _chargeBar;

		// The bullet speed
		public float bulletSpeed = 15.0f;

		[SerializeField]
		private GameObject _PlayerHandPivot;

		public bool Disabled = true;
		public Sprite Sprite_Disabled;
		public Sprite Sprite_Enabled;
		public GameObject BlinkinEyes;

		private Rigidbody2D _rb;

		private Vector3 _moveVector;
		private Vector3 _aimVector;
		private bool _fire;
		private bool _jump;
		private SpriteRenderer _playerSprite;



		void Awake()
		{
			// Get the Rewired Player object for this player and keep it for the duration of the character's lifetime
			// _player =players.GetPlayer(playerId);

			_rb = GetComponent<Rigidbody2D>();
			_playerSprite = transform.Find("PlayerSprite").GetComponent<SpriteRenderer>();

			if (Disabled)
			{
				//_playerSprite.sprite = Sprite_Disabled;
				_playerSprite.gameObject.SetActive(false);
				BlinkinEyes.SetActive(false);
				_PlayerHandPivot.SetActive(false);
			}

		}



		public void SetPlayerID(int id)
		{
			playerId = id;
		}

		private void Start()
		{
			Cursor.visible = false;
		}

		void Update()
		{
			GetInput();
			ProcessInput();
		}

		private void GetInput()
		{
			

			
				 _moveVector.x = Input.GetAxis("Horizontal");
				 _moveVector.y = Input.GetAxis("Vertical");

				 /*if (_player.GetAxis("Aim Horizontal") != 0 && _player.GetAxis("Aim Vertical") != 0)
				 {
					 _aimVector.x = _player.GetAxis("Aim Horizontal");
					 _aimVector.y = _player.GetAxis("Aim Vertical");
				 }
				 */

				 //print(_aimVector);
				
			

			_fire = Input.GetMouseButtonDown(0);
			  _jump = Input.GetKeyDown(KeyCode.Space);

			// FireWeapon 
			// DropWeapon
			// AbilityQuick
			// AbilityCharged
		}

		private void ProcessInput()
		{
			_rb.velocity = (_moveVector * moveSpeed * Time.deltaTime);

			// Mirror player depending on move vector
			if (_rb.velocity.x > 0)
			{
				_playerSprite.flipX = true;
			}
			else if (_rb.velocity.x < 0)
			{
				_playerSprite.flipX = false;
			}
			else
			{

			}

			if (!Disabled)
			{
				_PlayerHandPivot.transform.right = _aimVector * -1;
			}

			/*if (playerId > 0)
            {
                // Move arm depending on aim vector.
                if (_aimVector != Vector3.zero)
                {
                    _PlayerHandPivot.transform.right = _aimVector * -1;
                }
            }
          */

			// Fun way of using mouse? xD
			// Vector3 VectorToMouse = (Camera.main.ScreenToWorldPoint(Input.mousePosition)+ (Vector3.forward*-1 * transform.position.z)) - new Vector3(transform.position.x, transform.position.y, transform.position.z);
			// _PlayerHandPivot.transform.right = VectorToMouse.normalized * -1;

			Vector3 VectorToMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			VectorToMouse.z = transform.position.z;

			_PlayerHandPivot.transform.right = -1 * (VectorToMouse - transform.position).normalized;

		}




		public float GetSpeed()
		{
			return _rb.velocity.magnitude;
		}




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "PowerBall")
        {
			Destroy(collision.gameObject);
			_chargeBar.ChangeCharge(Random.Range(1f,30f));
        }
    }


}