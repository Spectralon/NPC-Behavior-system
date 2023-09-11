using CodeBase.GamePlay.Battle;
using CodeBase.GamePlay.Battle.Conductor;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace CodeBase.GamePlay.UI.Buttons
{
  public class NextHeroTurnButton : MonoBehaviour
  {
    public Button Button;
    private ICombatConductor _combatConductor;

    [Inject]
    private void Construct(ICombatConductor battleConductor) => 
      _combatConductor = battleConductor;

    private void Awake() => 
      Button.onClick.AddListener(RunBattleConductor);

    private void RunBattleConductor() => 
      _combatConductor.ResumeTurnTimer();

    private void Update() => 
      Button.interactable = _combatConductor.Mode == CombatMode.Manual;

    private void OnDestroy() => 
      Button.onClick.RemoveListener(RunBattleConductor);
  }
}