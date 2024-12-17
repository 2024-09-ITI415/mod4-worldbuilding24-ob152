using UnityEngine;
using UnityEngine.UI;

public class PageCollector : MonoBehaviour
{
    public int totalPages = 5;          // Total number of pages to collect
    private int pagesCollected = 0;     // Counter for collected pages

    public Text poetryText;             // UI Text to display poetry
    public Text winText;                // UI Text to display win message
    public Text pagesText;              // UI Text to show progress

    // Arrays for poetry lines and translations
    private string[] poetryLines = {
        "قِفَا نَبْكِ مِنْ ذِكْرَى حَبِيبٍ وَمَنْزِلِ", // Stop, let us weep for the memory of a loved one and a dwelling
        "تَرَاكِبُهَا مَحَطُوطَةٌ كَأَنَّهَا نُصُبُ",  // Its structures laid low, as if they were milestones
        "كأَنَّ غُضُونَ النَّخْلِ فِي الرَّوْضِ تَحْتَهُ", // As if the soft curves of the palms in the meadows were beneath it
        "بَاتَتْ تَذْرِفُ الدُّمُوعَ مَثْلَ وَابِلِ",   // Tears fell at night like a pouring rain
        "أَجَارَتَنَا إِنَّا غَرِيبَانِ هَاهُنَا"        // O neighbor, we are strangers here
    };

    private string[] translations = {
        "Stop, let us weep for the memory of a loved one and a dwelling.",
        "Its structures laid low, as if they were milestones.",
        "As if the soft curves of the palms in the meadows were beneath it.",
        "Tears fell at night like a pouring rain.",
        "O neighbor, we are strangers here."
    };

    void Start()
    {
        // Initialize UI Texts
        if (pagesText != null)
            pagesText.text = "Pages Collected: 0 / " + totalPages;

        if (poetryText != null)
            poetryText.text = "";  // Hide poetry text at the start

        if (winText != null)
            winText.text = "";  // Hide win text at the start
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the player collides with an object tagged "Page"
        if (other.CompareTag("Page"))
        {
            pagesCollected++;                  // Increase collected pages count
            Destroy(other.gameObject);         // Remove the collected page

            // Display the poetry line and translation
            if (poetryText != null && pagesCollected <= totalPages)
            {
                poetryText.text = poetryLines[pagesCollected - 1] + "\n" +
                                   translations[pagesCollected - 1];
            }

            // Update the progress text
            if (pagesText != null)
                pagesText.text = "Pages Collected: " + pagesCollected + " / " + totalPages;

            // Check for win condition
            if (pagesCollected >= totalPages)
            {
                WinGame();
            }
        }
    }

    void WinGame()
    {
        // Display win message
        if (winText != null)
        {
            winText.text = "You Win! All Pages Collected!";
            Debug.Log("You Win! All Pages Collected!");
        }
    }
}
