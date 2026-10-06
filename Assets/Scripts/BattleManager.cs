using UnityEngine;

// Step 3: BATTLE! 10 battles against enemy dragons!
// Battles 1-3: WEAK dragons (easy!)
// Battles 4-5: STRONG dragons (tougher!)
// Battles 6-8: SO HARD dragons (very tough!)
// Battles 9-10: BOSS dragons (two bosses - the hardest!)
public class BattleManager : MonoBehaviour
{
    public enum Difficulty { Weak, Strong, VeryHard, Boss }

    [Header("Which battle are you on?")]
    public int currentBattle = 0;

    [Header("Total battles")]
    public int totalBattles = 10;

    [Header("Show battle info here")]
    public UnityEngine.UI.Text battleText;

    public void StartBattles()
    {
        currentBattle = 1;
        Debug.Log("Battle 1 begins! Weak dragon ahead!");
        UpdateUI();
    }

    // Call this when you defeat the enemy dragon!
    public void WinBattle()
    {
        Debug.Log("You won battle " + currentBattle + "!");

        currentBattle++;

        if (currentBattle > totalBattles)
        {
            Victory();
        }
        else
        {
            Debug.Log("Battle " + currentBattle + " begins! " + GetDifficultyName() + " dragon ahead!");
            UpdateUI();
        }
    }

    public Difficulty GetDifficulty()
    {
        if (currentBattle <= 3) return Difficulty.Weak;
        if (currentBattle <= 5) return Difficulty.Strong;
        if (currentBattle <= 8) return Difficulty.VeryHard;
        return Difficulty.Boss;
    }

    string GetDifficultyName()
    {
        Difficulty d = GetDifficulty();
        if (d == Difficulty.Weak) return "Weak";
        if (d == Difficulty.Strong) return "Strong";
        if (d == Difficulty.VeryHard) return "SO HARD";
        return "BOSS";
    }

    // Enemy hits needed based on difficulty
    public int GetEnemyHits()
    {
        Difficulty d = GetDifficulty();
        if (d == Difficulty.Weak) return 3;
        if (d == Difficulty.Strong) return 6;
        if (d == Difficulty.VeryHard) return 10;
        return 15; // Boss!
    }

    void UpdateUI()
    {
        if (battleText) battleText.text = "Battle " + currentBattle + "/" + totalBattles + " - " + GetDifficultyName();
    }

    void Victory()
    {
        Debug.Log("YOU DEFEATED ALL 10 DRAGONS INCLUDING THE TWO BOSSES! You are the Dragon Master!");
        if (battleText) battleText.text = "VICTORY! You are the Dragon Master!";
    }
}
