using Core.Input;
using Core.Upgrades;
using Core.Vibrations;
using DELTation.DIFramework;
using DELTation.DIFramework.Containers;
using Sirenix.OdinInspector;
using UnityEngine;

namespace DI
{
    public sealed class GameCompositionRoot : DependencyContainerBase
    {
        [SerializeField] [Required] private VibrationsConfig vibrationsVibrationsConfig;
        [SerializeField] [Required] private UpgradesConfig upgradesUpgradesConfig;
        [SerializeField] [Required] private InputJoystickReceiver _inputJoystickReceiver;

        protected override void ComposeDependencies(ICanRegisterContainerBuilder builder)
        {
            builder.Register<VibrationsPlayer>()
                .Register<StatLevelSaver>()
                .RegisterIfNotNull(vibrationsVibrationsConfig)
                .RegisterIfNotNull(_inputJoystickReceiver)
                .RegisterIfNotNull(upgradesUpgradesConfig);
        }
    }
}