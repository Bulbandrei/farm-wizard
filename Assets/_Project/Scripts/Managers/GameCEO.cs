using UnityEngine;

public class GameCEO : MonoBehaviour
{
    public static event System.Action onGameStateChanged;
    public static event System.Action onLanguageChanged;

    public static GameState State { get; private set; }
    public static Language CurLanguage { get; private set; } = Language.EN;

    public GUIManager guiManager;
    public InputManager inputManager;
    public PlayerManager playerManager;
    public StageManager stageManager;
    public CameraManager cameraManager;

    private void Awake()
    {
        ChangeGameState(GameState.LOADING);

        guiManager.onLanguageSelected += GuiManager_onLanguageSelected;
        guiManager.onStartGameRequested += GuiManager_onStartGameRequested;
        guiManager.onIntroRequested += GuiManager_onIntroRequested;

        playerManager.onPlayerLifeUpdated += PlayerManager_onPlayerLifeUpdated;
        playerManager.onPlayerLifeReachsZero += PlayerManager_onPlayerLifeReachsZero;

        guiManager.Initiate();
        playerManager.Initate();
        stageManager.Initiate();
    }

    private void Start()
    {
        guiManager.Initialize();
        stageManager.Initalize();

        guiManager.ShowDisplay(Displays.LANGUAGE);
    }

    //-----------------CEO------------------

    private void StartGame()
    {
        stageManager.InitalizeStage();

        guiManager.ShowDisplay(Displays.HUD);

        ChangeGameState(GameState.PLAY);
    }

    private void ResetGame()
    {
        stageManager.ResetStage();
        playerManager.ResetPlayer();
    }

    private void ChangeGameState(GameState p_state)
    {
        State = p_state;

        onGameStateChanged?.Invoke();
    }

    public void ChangeLanguage(Language newLang)
    {
        CurLanguage = newLang;
    }

    //-----------------GUI MANAGER------------------

    private void GuiManager_onLanguageSelected(Language p_language)
    {
        CurLanguage = p_language;

        onLanguageChanged?.Invoke();

        guiManager.ShowDisplay(Displays.INTRO);
    }

    private void GuiManager_onStartGameRequested()
    {
        StartGame();
    }

    private void GuiManager_onIntroRequested()
    {
        ResetGame();

        guiManager.ShowDisplay(Displays.INTRO);

        ChangeGameState(GameState.INTRO);
    }

    //-----------------STAGE MANAGER----------------

    //-----------------PLAYER MANAGER----------------

    private void PlayerManager_onPlayerLifeUpdated()
    {
        guiManager.UpdateDisplay(Displays.HUD, 0, Player.Life);
    }

    private void PlayerManager_onPlayerLifeReachsZero()
    {
        ChangeGameState(GameState.GAME_OVER);

        guiManager.ShowDisplay(Displays.GAME_OVER);
    }

}
