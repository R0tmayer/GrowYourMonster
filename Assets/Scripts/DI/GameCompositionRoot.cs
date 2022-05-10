using Core;
using Core.Input;
using Core.Obstacles;
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
        [SerializeField] [Required] private VibrationsConfig _vibrationsVibrationsConfig;
        [SerializeField] [Required] private UpgradesConfig _upgradesUpgradesConfig;
        [SerializeField] [Required] private GameParameters _gameParameters;
        [SerializeField] [Required] private InputJoystickReceiver _inputJoystickReceiver;

        protected override void ComposeDependencies(ICanRegisterContainerBuilder builder)
        {
            builder.Register<VibrationsPlayer>()
                .Register<StatLevelSaver>()
                .RegisterIfNotNull(_vibrationsVibrationsConfig)
                .RegisterIfNotNull(_inputJoystickReceiver)
                .RegisterIfNotNull(_gameParameters)
                .RegisterIfNotNull(_upgradesUpgradesConfig);
        }
    }
}