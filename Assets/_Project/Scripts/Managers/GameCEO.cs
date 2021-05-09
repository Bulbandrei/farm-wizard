using UnityEngine;

public class GameCEO : MonoBehaviour
{
    public static event System.Action onGameStateChanged;

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

        guiManager.Initiate();
        stageManager.Initiate();
    }

    private void Start()
    {
        guiManager.Initialize();
    }

    //-----------------CEO------------------

    private void StartGame()
    {
        
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

    //-----------------STAGE MANAGER----------------


}
