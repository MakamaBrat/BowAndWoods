using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public MenuTravel menuTravel;
    public Animator missEffect;
    public Animator shotEffect;

    public AudioSource miss;
    public AudioSource shot;
    [Header("Arrows Settings")]
    public int maxArrows = 5;           // Максимальное количество стрел при старте
    private int currentArrows;          // Текущие стрелы
    public Text arrowsText;  // UI для отображения стрел

    [Header("Score Settings")]
    public int currentScore = 0;        // Текущий счёт
    public int bestScore = 0;           // Лучший счёт
    public Text currentScoreText;
    public Text bestScoreText;

    private void OnEnable()
    {
        // При старте даём игроку 5 стрел
        currentArrows = maxArrows;
        UpdateArrowsUI();

        // Загружаем лучший результат
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        UpdateScoreUI();
    }

    // Метод для добавления очков
    public void AddScore(int points)
    {
        currentScore += points;

        // Возвращаем одну стрелу
        currentArrows++;
        UpdateArrowsUI();

        // Обновляем лучший результат
        if (currentScore > bestScore)
        {
            bestScore = currentScore;
            PlayerPrefs.SetInt("BestScore", bestScore);
        }
        shot.Play();
        shotEffect.Play("ShotEffect");
        UpdateScoreUI();
    }

    // Метод обновления UI для стрел
    private void UpdateArrowsUI()
    {
        if (arrowsText != null)
            arrowsText.text = $"{currentArrows}";
    }

    // Метод обновления UI для очков
    private void UpdateScoreUI()
    {
        if (currentScoreText != null)
            currentScoreText.text = $"Score: {currentScore}";

        if (bestScoreText != null)
            bestScoreText.text = $"Best: {bestScore}";
    }

    // Метод для траты стрел
    public bool UseArrow()
    {
        if (currentArrows > 0)
        {
            currentArrows--;
            UpdateArrowsUI();
            return true; // стрелу использовали
        }
        else
        {
            GameOver();
            return false; // стрел нет
        }
    }
    public void PlayMiss()
    {
        miss.Play();
        missEffect.Play("MIssEffect");
    }
    public void GameOver()
    {
        menuTravel.makeMenu(5);
    }
}
