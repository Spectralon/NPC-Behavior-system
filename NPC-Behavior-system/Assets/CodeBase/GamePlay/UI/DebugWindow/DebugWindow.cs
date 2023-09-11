using System.Linq;
using CodeBase.Extensions;
using CodeBase.GamePlay.AI.Reporter;
using CodeBase.GamePlay.Battle;
using CodeBase.GamePlay.Battle.Conductor;
using CodeBase.GamePlay.EntityRegistry;
using UnityEngine;
using Zenject;

namespace CodeBase.GamePlay.UI.DebugWindow
{
  public class DebugWindow : MonoBehaviour
  {
    public EntityActionEntry EntityActionEntryPrefab;
    public DecisionDetailsEntry DecisionDetailsEntryPrefab;
    public DecisionScoresEntry DecisionScoresEntryPrefab;
    public Transform EntriesRoot;

    private ICombatConductor _combatConductor;
    private IEntityRegistry _registry;
    private IAIReporter _aiReporter;

    [Inject]
    private void Construct(ICombatConductor conductor, 
      IEntityRegistry registry,
      IAIReporter aiReporter)
    {
      _aiReporter = aiReporter;
      _combatConductor = conductor;
      _registry = registry;
      
      _combatConductor.EntityActionProduced += OnHeroActionProduced;
      _aiReporter.DecisionDetailsReported += OnDecisionDetailsProduced;
      _aiReporter.DecisionScoresReported += OnDecisionScoresProduced;
    }

    private void OnDestroy()
    {
      _combatConductor.EntityActionProduced -= OnHeroActionProduced;
      _aiReporter.DecisionDetailsReported -= OnDecisionDetailsProduced;
      _aiReporter.DecisionScoresReported -= OnDecisionScoresProduced;
    }

    public void SwitchState() =>
      gameObject.SetActive(!gameObject.activeSelf);

    private void OnHeroActionProduced(EntityAction action)
    {
      Instantiate(EntityActionEntryPrefab, EntriesRoot)
        .With(x => x.EntityName.text = $"{action.Caster.TypeId} [{action.Caster.PlaceNumber}]")
        .With(x => x.AbilityName.text = $"{action.Ability} ({action.AbilityType})")
        .With(x => x.TargetsLine.text = action.TargetIds
          .Aggregate(
            "",
            (current, id) => current + $" {_registry.GetEntity(id).TypeId} [{_registry.GetEntity(id).PlaceNumber}]"));
    }

    private void OnDecisionScoresProduced(DecisionScores scores)
    {
      Instantiate(DecisionScoresEntryPrefab, EntriesRoot)
        .With(x => x.EntityName.text = $"{scores.EntityName}")
        .With(x => x.AbilityName.text = $"")
        .With(x => x.TargetsLine.text = scores.FormattedLine);

    }

    private void OnDecisionDetailsProduced(DecisionDetails details)
    {
      Instantiate(DecisionDetailsEntryPrefab, EntriesRoot)
        .With(x => x.EntityName.text = $"{details.CasterName}")
        .With(x => x.TargetName.text = $"{details.TargetName}")
        .With(x => x.AbilityName.text = $"{details.AbilityName}")
        .With(x => x.TargetsLine.text = details.FormattedLine);
    }
  }
}