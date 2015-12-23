using UnityEngine;
using UnityEngine.Networking;

public class InvokingController : MonoBehaviour
{
    // The SpellController of the character this controller is working for
    public SpellController spellControl;
    public NetworkIdentity netIdent;

    // TRUE: The respective input is already activate
    // FALSE: The respective input is not active
    private bool leftDown = false;
    private bool rightDown = false;

    // TRUE: The UI is visible and is invoking a spell
    // FALSE: The UI is not visible and is not invoking a spell
    [HideInInspector]
    public bool
        isInvoking = false;

    // The controller starts as hiding the UI
    void Start()
    {
        gameObject.GetComponent<Canvas>().enabled = isInvoking;
    }

    // Each frame...
    // 		If the player wants to invoke...
    //			Show the UI if it isn't being shown
    //		Else...
    //			Hide the UI
    void Update()
    {
        if (!netIdent.isLocalPlayer)
            return;

         if (Input.GetAxis("Invoke") >= Constants.ON)
        {
            if (!isInvoking)
            {
                isInvoking = true;
                gameObject.GetComponent<Canvas>().enabled = isInvoking;
            }
            detectBuild();
        }
        else {
            isInvoking = false;
            gameObject.GetComponent<Canvas>().enabled = isInvoking;
        }
    }

    // Clears the list if the corresponding fire button is activated while invoking
    // PARAMETERS: Nothing
    // RETURNS: Nothing
    // TODO: Perhaps find a cleaner way to do this
    private void detectClear()
    {
        // Only clear when the player first activates
        if (Input.GetAxis(Constants.FIRE_LEFT) >= Constants.ON && !leftDown)
        {
            spellControl.clearElements(Constants.FIRE_LEFT);
            leftDown = true;
        }
        else if (Input.GetAxis(Constants.FIRE_LEFT) < Constants.ON)
        {
            leftDown = false;
        }

        if (Input.GetAxis(Constants.FIRE_RIGHT) >= Constants.ON && !rightDown)
        {
            spellControl.clearElements(Constants.FIRE_RIGHT);
            rightDown = true;
        }
        else if (Input.GetAxis(Constants.FIRE_RIGHT) < Constants.ON)
        {
            rightDown = false;
        }
    }

    private void detectBuild()
    {
        // Only clear when the player first activates
        if (Input.GetAxis(Constants.FIRE_LEFT) < Constants.ON && leftDown)
        {
            spellControl.buildSpell(Constants.FIRE_LEFT);
            spellControl.clearElements(Constants.FIRE_LEFT);
            leftDown = false;
        }
        else if (Input.GetAxis(Constants.FIRE_LEFT) >= Constants.ON)
        {
            leftDown = true;
        }

        if (Input.GetAxis(Constants.FIRE_RIGHT) < Constants.ON && rightDown)
        {
            spellControl.buildSpell(Constants.FIRE_RIGHT);
            spellControl.clearElements(Constants.FIRE_RIGHT);
            rightDown = false;
        }
        else if (Input.GetAxis(Constants.FIRE_RIGHT) >= Constants.ON)
        {
            rightDown = true;
        }
    }
}
