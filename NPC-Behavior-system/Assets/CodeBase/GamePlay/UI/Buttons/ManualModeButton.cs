using CodeBase.GamePlay.Battle;
using CodeBase.GamePlay.Battle.Conductor;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace CodeBase.GamePlay.UI.Buttons
{
  public class ManualModeButton : MonoBehaviour
  {
    public Button Button;
    private ICombatConductor _combatConductor;

    [Inject]
    private void Construct(ICombatConductor battleConductor) => 
      _combatConductor = battleConductor;

    private void Awake() => 
      Button.onClick.AddListener(SetMode);

    private void Update() => 
      Button.interactable = _combatConductor.Mode == CombatMode.Auto;

    private void SetMode() => 
      _combatConductor.SetMode(CombatMode.Manual);

    private void OnDestroy() => 
      Button.onClick.RemoveListener(SetMode);
  }
}