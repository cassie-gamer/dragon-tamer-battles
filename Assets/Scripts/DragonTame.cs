using UnityEngine;

// Step 2: TAME YOUR DRAGON!
// Be gentle and patient. Feed it fish, pet it, earn its trust.
// When the trust meter is full, your dragon is tamed and ready to battle!
public class DragonTame : MonoBehaviour
{
    [Header("Trust needed to tame")]
    public int trustNeeded = 5;

    [Header("Show trust here")]
    public UnityEngine.UI.Text trustText;

    private int trust = 0;
    private DragonChoice.DragonType dragon;

    public void BeginTaming(DragonChoice.DragonType chosenDragon)
    {
        dragon = chosenDragon;
        trust = 0;
        Debug.Log("Tame your " + dragon + "! Feed it and be gentle!");
        UpdateUI();
    }

    // Call this from a "Feed Fish" button!
    public void FeedFish()
    {
        AddTrust(1);
        Debug.Log("You fed your dragon a fish! It likes you more!");
    }

    // Call this from a "Pet" button!
    public void PetDragon()
    {
        AddTrust(1);
        Debug.Log("You petted your dragon! It purrs happily!");
    }

    void AddTrust(int amount)
    {
        trust += amount;
        UpdateUI();

        if (trust >= trustNeeded)
        {
            Tamed();
        }
    }

    void UpdateUI()
    {
        if (trustText) trustText.text = "Trust: " + trust + "/" + trustNeeded;
    }

    void Tamed()
    {
        Debug.Log("Your " + dragon + " is TAMED! Time for battle!");
        BattleManager battles = FindObjectOfType<BattleManager>();
        if (battles) battles.StartBattles();
    }
}
