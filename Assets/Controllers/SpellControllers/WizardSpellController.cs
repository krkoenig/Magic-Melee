using UnityEngine;
using UnityEngine.Networking;

public class WizardSpellController : SpellController
{
    enum WizardElement
    {
        AIR = Element.TOP_RHT,
        FIRE = Element.BOT_RHT,
        ARCANE = Element.BOT,
        EARTH = Element.BOT_LFT,
        WATER = Element.TOP_LFT
    }
    ;

    public override void buildSpell(string axis)
    {
        if (isFireball(axis))
            CmdSetFireball(axis);
        if (isBomb(axis))
            CmdSetBomb(axis);
    }

    public void addAir()
    {
        string axis = "";
        if (Input.GetAxis(Constants.FIRE_LEFT) >= Constants.ON)
            axis = Constants.FIRE_LEFT;
        else if (Input.GetAxis(Constants.FIRE_RIGHT) >= Constants.ON)
            axis = Constants.FIRE_RIGHT;

        addElement((Element)WizardElement.AIR, axis);
    }

    public void addFire()
    {
        string axis = "";
        if (Input.GetAxis(Constants.FIRE_LEFT) >= Constants.ON)
            axis = Constants.FIRE_LEFT;
        else if (Input.GetAxis(Constants.FIRE_RIGHT) >= Constants.ON)
            axis = Constants.FIRE_RIGHT;

        addElement((Element)WizardElement.FIRE, axis);
    }

    public void addArcane()
    {
        string axis = "";
        if (Input.GetAxis(Constants.FIRE_LEFT) >= Constants.ON)
            axis = Constants.FIRE_LEFT;
        else if (Input.GetAxis(Constants.FIRE_RIGHT) >= Constants.ON)
            axis = Constants.FIRE_RIGHT;

        addElement((Element)WizardElement.ARCANE, axis);
    }

    public void addEarth()
    {
        string axis = "";
        if (Input.GetAxis(Constants.FIRE_LEFT) >= Constants.ON)
            axis = Constants.FIRE_LEFT;
        else if (Input.GetAxis(Constants.FIRE_RIGHT) >= Constants.ON)
            axis = Constants.FIRE_RIGHT;

        addElement((Element)WizardElement.EARTH, axis);
    }

    public void addWater()
    {
        string axis = "";
        if (Input.GetAxis(Constants.FIRE_LEFT) >= Constants.ON)
            axis = Constants.FIRE_LEFT;
        else if (Input.GetAxis(Constants.FIRE_RIGHT) >= Constants.ON)
            axis = Constants.FIRE_RIGHT;

        addElement((Element)WizardElement.WATER, axis);
    }

    // Checks whether fireball is available for casting
    // PARAMETERS: Whether this is firing the left or right
    // TODO: Move to somewhere better, possibly a child
    // TODO: Call on spell creation rather than on cast
    public bool isFireball(string axis)
    {
        return isPrimary((Element)WizardElement.FIRE, axis) &&
            isSecondary((Element)WizardElement.AIR, axis) &&
            isSecondary((Element)WizardElement.ARCANE, axis) &&
            !isSecondary((Element)WizardElement.EARTH, axis) &&
            !isSecondary((Element)WizardElement.WATER, axis);
    }

    [Command]
    private void CmdSetFireball(string axis)
    {
        if (axis == Constants.FIRE_LEFT)
            leftSpell = new Fireball();
        else if (axis == Constants.FIRE_RIGHT)
            rightSpell = new Fireball();
    }

    public bool isBomb(string axis)
    {
        return isPrimary((Element)WizardElement.FIRE, axis) &&
            isSecondary((Element)WizardElement.EARTH, axis) &&
            !isSecondary((Element)WizardElement.ARCANE, axis) &&
            !isSecondary((Element)WizardElement.AIR, axis) &&
            !isSecondary((Element)WizardElement.WATER, axis);
    }

    [Command]
    private void CmdSetBomb(string axis)
    {
        if (axis == Constants.FIRE_LEFT)
            leftSpell = new Bomb();
        else if (axis == Constants.FIRE_RIGHT)
            rightSpell = new Bomb();
    }
}

