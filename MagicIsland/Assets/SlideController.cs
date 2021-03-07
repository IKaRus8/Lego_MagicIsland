using Cinemachine;
using Unity.LEGO.Behaviours.Triggers;
using Unity.LEGO.Minifig;
using UnityEngine;

public class SlideController : MonoBehaviour
{
	public SkillController player;

	public GameObject nearbyTrigger;

	public new CinemachineVirtualCamera camera;

	public Vector3 forward;

	public Vector3 side;

	public bool isSlide;

	private new Rigidbody rigidbody;

	private bool ready;

	int direction
	{
		get
		{
			int result = 0;

			if (Input.GetKey(KeyCode.A))
			{
				result -= 1;
			}

			if (Input.GetKey(KeyCode.D))
			{
				result += 1;
			}

			return result;
		}
	}

	private void Awake()
	{
		rigidbody = GetComponent<Rigidbody>();

		nearbyTrigger.GetComponentInChildren<NearbyTrigger>().OnActivate += StartSlide;
	}

	private void Update()
	{
		if (isSlide)
		{
			if (!ready)
			{
				StartSlide();
			}

			Vector3 toDir = side * direction;

			rigidbody.AddForce((forward + toDir) * Time.deltaTime);

			player.transform.position = transform.position + new Vector3(0,0.5f,0);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.name == "speedTrigger")
		{
			StopSreedForce();
		}
	}

	private void StartSlide()
	{
		rigidbody.useGravity = true;
		camera.gameObject.SetActive(true);

		player.SetInput(false);
		player.SetAnimatorState(false);

		player.transform.rotation = transform.rotation;

		player.GetComponent<MinifigController>().enabled = false;

		isSlide = true;
		ready = true;
	}

	public void StopSlide()
	{
		camera.gameObject.SetActive(false);

		player.SetInput(true);
		player.SetAnimatorState(true);
		player.GetComponent<MinifigController>().enabled = true;

		isSlide = false;
		ready = false;

		Destroy(gameObject);
	}

	public void StopSreedForce()
	{
		forward = Vector3.zero;
	}
}
