using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public abstract class SpellController : NetworkBehaviour
{

    public enum Element
    {
        TOP_RHT,
        BOT_RHT,
        BOT,
        BOT_LFT,
        TOP_LFT
    }
    ;

    protected List<Element> leftElements = new List<Element>();
    protected List<Element> rightElements = new List<Element>();

    protected Spell leftSpell;
    protected Spell rightSpell;

    // Returns whether the given element is the primary element being invoked
    // PARAMETERS: The Element e being checked, and whether its left or right
    // RETURNS: A boolean of whether e is the primary element being invoked
    protected bool isPrimary(Element e, string axis)
    {
        if (axis == Constants.FIRE_RIGHT)
        {
            if (rightElements.Count >= 1)
            {
                return rightElements[0] == e;
            }
        }
        else if (axis == Constants.FIRE_LEFT)
        {
            if (leftElements.Count >= 1)
            {
                return leftElements[0] == e;
            }
        }
        // The input was faulty
        return false;
    }

    // Returns whether the given element is a secondary element being invoked
    // PARAMETERS: The Element e being checked, and whether its left or right
    // RETURNS: A boolean of whether e is a secondary element being invoked
    protected bool isSecondary(Element e, string axis)
    {
        if (axis == Constants.FIRE_RIGHT)
        {
            return rightElements.Contains(e) && rightElements[0] != e;
        }
        else if (axis == Constants.FIRE_LEFT)
        {
            return leftElements.Contains(e) && leftElements[0] != e;
        }
        // The input was faulty
        return false;
    }

    // Adds an element to the list of currently invoked elements
    // TODO: Move somewhere more approriate to allow different type of Elements via inheritance
    protected void addElement(Element e, string axis)
    {
        if (axis == Constants.FIRE_LEFT)
        {
            Debug.Log(e + " added to left");
            leftElements.Add(e);
        }
        else if (axis == Constants.FIRE_RIGHT)
        {
            Debug.Log(e + " added to right");
            rightElements.Add(e);
        }
    }

    public void clearElements(string axis)
    {
        if (axis == Constants.FIRE_LEFT)
        {
            Debug.Log("Left elements cleared");
            leftElements.Clear();
        }
        else if (axis == Constants.FIRE_RIGHT)
        {
            Debug.Log("Right elements cleared");
            rightElements.Clear();
        }
    }

    public abstract void buildSpell(string axis);

    public Spell getSpell(string axis)
    {
        if (axis == Constants.FIRE_LEFT && leftSpell != null)
            return leftSpell;
        else if (axis == Constants.FIRE_RIGHT && rightSpell != null)
            return rightSpell;
        else
            return null;
    }
}
