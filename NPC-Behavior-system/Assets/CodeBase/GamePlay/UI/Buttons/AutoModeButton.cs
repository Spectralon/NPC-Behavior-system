using CodeBase.GamePlay.Battle;
using CodeBase.GamePlay.Battle.Conductor;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace CodeBase.GamePlay.UI.Buttons
{
  public class AutoModeButton : MonoBehaviour
  {
    public Button Button;
    private ICombatConductor _combatConductor;

    [Inject]
    private void Construct(ICombatConductor battleConductor) => 
      _combatConductor = battleConductor;

    private void Awake() => 
      Button.onClick.AddListener(SetMode);

    private void Update() => 
      Button.interactable = _combatConductor.Mode == CombatMode.Manual;

    private void SetMode()
    {
      _combatConductor.SetMode(CombatMode.Auto);
      _combatConductor.ResumeTurnTimer();
    }

    private void OnDestroy() => 
      Button.onClick.RemoveListener(SetMode);
  }
}