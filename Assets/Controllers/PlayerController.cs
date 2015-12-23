using UnityEngine;
using UnityEngine.Networking;
using System.Diagnostics;

public class PlayerController : NetworkBehaviour
{
	// Speed of the characters movement
	public float speed = 10.0f;

	public InvokingController invokeControl;
	public SpellController spellControl;


    private Stopwatch castTimer = new Stopwatch();

    void Start()
    {
        castTimer.Start();
    }

    public override void OnStartLocalPlayer()
    {
        invokeControl.spellControl = spellControl;
    }

    // Update is called once per frame
    void Update ()
	{
        if (!isLocalPlayer)
            return;

		// Check inputs
		movePlayer ();

        if (!invokeControl.isInvoking)
        {
            if (Input.GetAxis(Constants.FIRE_LEFT) >= Constants.ON
              && castTimer.Elapsed.Seconds >= 1)
            {
                CmdFireSpell(Constants.FIRE_LEFT, getMouseAngle());
                castTimer.Reset(); castTimer.Start();
            }

            if (Input.GetAxis(Constants.FIRE_RIGHT) >= Constants.ON
                && castTimer.Elapsed.Seconds >= 1)
            {
                CmdFireSpell(Constants.FIRE_RIGHT, getMouseAngle());
                castTimer.Reset(); castTimer.Start();
            }
        }
    }

	// Translates the player based off input
	// PARAMETERS: VOID
	// RETURNS: VOID
	private void movePlayer ()
	{
		float hMove = Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
		float vMove = Input.GetAxis ("Vertical") * speed * Time.deltaTime;
		transform.Translate (hMove, vMove, 0.0f);
	}

    // Tells the Server to fire the given spell
    // PARAMETERS: VOID
    // RETURNS: VOID
    // TODO: Logic to determine the active spell
    [Command]
    private void CmdFireSpell(string axis, Vector3 mouseAngle)
	{
        Spell spell = spellControl.getSpell(axis);

        if(spell != null)
        {
            GameObject spellObj = spell.fire(transform.position, mouseAngle);
            NetworkServer.Spawn(spellObj);
        }
	}

	// Gets the angle between the player and the mouse cursor
	// PARAMTERS: VOID
	// RETURNS: Vector3 containing rotation around Z-axis
	private Vector3 getMouseAngle ()
	{
		Vector3 mScreen = Input.mousePosition;
		Vector3 pScreen = Camera.main.WorldToScreenPoint (transform.position);
		Vector2 offset = mScreen - pScreen;
		float angle = Mathf.Atan2 (offset.y, offset.x) * Mathf.Rad2Deg;
		return new Vector3 (0.0f, 0.0f, angle);
	}
}
