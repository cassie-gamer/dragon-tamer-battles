using UnityEngine;

// Step 1: PICK YOUR DRAGON!
// Choice 1: Night Fury (like Toothless - black, fast, plasma blasts!)
// Choice 2: Light Fury (white, glowing, beautiful!)
public class DragonChoice : MonoBehaviour
{
    public enum DragonType { NightFury, LightFury }

    [Header("Which dragon did you pick?")]
    public DragonType chosenDragon;

    [Header("Your dragon (set when chosen)")]
    public GameObject dragon;

    // Call this from a "Night Fury" button!
    public void ChooseNightFury()
    {
        chosenDragon = DragonType.NightFury;
        Debug.Log("You chose the Night Fury! Black as night, fast as lightning!");
        StartTaming();
    }

    // Call this from a "Light Fury" button!
    public void ChooseLightFury()
    {
        chosenDragon = DragonType.LightFury;
        Debug.Log("You chose the Light Fury! White and glowing, beautiful and brave!");
        StartTaming();
    }

    void StartTaming()
    {
        DragonTame tamer = FindObjectOfType<DragonTame>();
        if (tamer) tamer.BeginTaming(chosenDragon);
    }
}
