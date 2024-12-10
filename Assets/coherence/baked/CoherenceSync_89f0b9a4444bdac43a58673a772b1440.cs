// Copyright (c) coherence ApS.
// For all coherence generated code, the coherence SDK license terms apply. See the license file in the coherence Package root folder for more information.

// <auto-generated>
// Generated file. DO NOT EDIT!
// </auto-generated>
namespace Coherence.Generated
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;
    using Coherence.Toolkit;
    using Coherence.Toolkit.Bindings;
    using Coherence.Entities;
    using Coherence.ProtocolDef;
    using Coherence.Brook;
    using Coherence.Toolkit.Bindings.ValueBindings;
    using Coherence.Toolkit.Bindings.TransformBindings;
    using Coherence.Connection;
    using Coherence.SimulationFrame;
    using Coherence.Interpolation;
    using Coherence.Log;
    using Logger = Coherence.Log.Logger;
    using UnityEngine.Scripting;
    
    [UnityEngine.Scripting.Preserve]
    public class Binding_89f0b9a4444bdac43a58673a772b1440_c0bbba8ea6934e0891473cda634adae6 : PositionBinding
    {   
        private global::UnityEngine.Transform CastedUnityComponent;

        protected override void OnBindingCloned()
        {
    	    CastedUnityComponent = (global::UnityEngine.Transform)UnityComponent;
        }

        public override global::System.Type CoherenceComponentType => typeof(WorldPosition);
        public override string CoherenceComponentName => "WorldPosition";
        public override uint FieldMask => 0b00000000000000000000000000000001;

        public override UnityEngine.Vector3 Value
        {
            get { return (UnityEngine.Vector3)(coherenceSync.coherencePosition); }
            set { coherenceSync.coherencePosition = (UnityEngine.Vector3)(value); }
        }

        protected override (UnityEngine.Vector3 value, AbsoluteSimulationFrame simFrame) ReadComponentData(ICoherenceComponentData coherenceComponent, Vector3 floatingOriginDelta)
        {
            var value = ((WorldPosition)coherenceComponent).value;
            if (!coherenceSync.HasParentWithCoherenceSync) { value += floatingOriginDelta; }

            var simFrame = ((WorldPosition)coherenceComponent).valueSimulationFrame;
            
            return (value, simFrame);
        }

        public override ICoherenceComponentData WriteComponentData(ICoherenceComponentData coherenceComponent, AbsoluteSimulationFrame simFrame)
        {
            var update = (WorldPosition)coherenceComponent;
            if (Interpolator.IsInterpolationNone)
            {
                update.value = Value;
            }
            else
            {
                update.value = GetInterpolatedAt(simFrame / InterpolationSettings.SimulationFramesPerSecond);
            }

            update.valueSimulationFrame = simFrame;
            
            return update;
        }

        public override ICoherenceComponentData CreateComponentData()
        {
            return new WorldPosition();
        }    
    }
    
    [UnityEngine.Scripting.Preserve]
    public class Binding_89f0b9a4444bdac43a58673a772b1440_215428c6b6d24d75a10f8c89fe19ddef : RotationBinding
    {   
        private global::UnityEngine.Transform CastedUnityComponent;

        protected override void OnBindingCloned()
        {
    	    CastedUnityComponent = (global::UnityEngine.Transform)UnityComponent;
        }

        public override global::System.Type CoherenceComponentType => typeof(WorldOrientation);
        public override string CoherenceComponentName => "WorldOrientation";
        public override uint FieldMask => 0b00000000000000000000000000000001;

        public override UnityEngine.Quaternion Value
        {
            get { return (UnityEngine.Quaternion)(coherenceSync.coherenceRotation); }
            set { coherenceSync.coherenceRotation = (UnityEngine.Quaternion)(value); }
        }

        protected override (UnityEngine.Quaternion value, AbsoluteSimulationFrame simFrame) ReadComponentData(ICoherenceComponentData coherenceComponent, Vector3 floatingOriginDelta)
        {
            var value = ((WorldOrientation)coherenceComponent).value;

            var simFrame = ((WorldOrientation)coherenceComponent).valueSimulationFrame;
            
            return (value, simFrame);
        }

        public override ICoherenceComponentData WriteComponentData(ICoherenceComponentData coherenceComponent, AbsoluteSimulationFrame simFrame)
        {
            var update = (WorldOrientation)coherenceComponent;
            if (Interpolator.IsInterpolationNone)
            {
                update.value = Value;
            }
            else
            {
                update.value = GetInterpolatedAt(simFrame / InterpolationSettings.SimulationFramesPerSecond);
            }

            update.valueSimulationFrame = simFrame;
            
            return update;
        }

        public override ICoherenceComponentData CreateComponentData()
        {
            return new WorldOrientation();
        }    
    }
    
    [UnityEngine.Scripting.Preserve]
    public class Binding_89f0b9a4444bdac43a58673a772b1440_ec85c7ffef554ee9b9c3394f35745e25 : BoolBinding
    {   
        private global::NetworkedXRGrabInteractable CastedUnityComponent;

        protected override void OnBindingCloned()
        {
    	    CastedUnityComponent = (global::NetworkedXRGrabInteractable)UnityComponent;
        }

        public override global::System.Type CoherenceComponentType => typeof(_89f0b9a4444bdac43a58673a772b1440_3981479094327917996);
        public override string CoherenceComponentName => "_89f0b9a4444bdac43a58673a772b1440_3981479094327917996";
        public override uint FieldMask => 0b00000000000000000000000000000001;

        public override System.Boolean Value
        {
            get { return (System.Boolean)(CastedUnityComponent.isGrabbed); }
            set { CastedUnityComponent.isGrabbed = (System.Boolean)(value); }
        }

        protected override (System.Boolean value, AbsoluteSimulationFrame simFrame) ReadComponentData(ICoherenceComponentData coherenceComponent, Vector3 floatingOriginDelta)
        {
            var value = ((_89f0b9a4444bdac43a58673a772b1440_3981479094327917996)coherenceComponent).isGrabbed;

            var simFrame = ((_89f0b9a4444bdac43a58673a772b1440_3981479094327917996)coherenceComponent).isGrabbedSimulationFrame;
            
            return (value, simFrame);
        }

        public override ICoherenceComponentData WriteComponentData(ICoherenceComponentData coherenceComponent, AbsoluteSimulationFrame simFrame)
        {
            var update = (_89f0b9a4444bdac43a58673a772b1440_3981479094327917996)coherenceComponent;
            if (Interpolator.IsInterpolationNone)
            {
                update.isGrabbed = Value;
            }
            else
            {
                update.isGrabbed = GetInterpolatedAt(simFrame / InterpolationSettings.SimulationFramesPerSecond);
            }

            update.isGrabbedSimulationFrame = simFrame;
            
            return update;
        }

        public override ICoherenceComponentData CreateComponentData()
        {
            return new _89f0b9a4444bdac43a58673a772b1440_3981479094327917996();
        }    
    }

    [UnityEngine.Scripting.Preserve]
    public class CoherenceSync_89f0b9a4444bdac43a58673a772b1440 : CoherenceSyncBaked
    {
        private Entity entityId;
        private Logger logger = Coherence.Log.Log.GetLogger<CoherenceSync_89f0b9a4444bdac43a58673a772b1440>();
        
        private global::LabContainer _89f0b9a4444bdac43a58673a772b1440_a5095b69922c4a87aeeb0c9bd71a479f_CommandTarget;
        private global::LabContainer _89f0b9a4444bdac43a58673a772b1440_577e2e15601a4ed4a9b5dd9793d3808d_CommandTarget;
        private global::LabContainer _89f0b9a4444bdac43a58673a772b1440_3d4ce41069784d68b4d0b166dd98ffc6_CommandTarget;
        private global::LabContainer _89f0b9a4444bdac43a58673a772b1440_b8b234f3424b420db4570a8fbd062db5_CommandTarget;
        private global::LabContainer _89f0b9a4444bdac43a58673a772b1440_d7dc5c545db045a493cf976e2102244d_CommandTarget;
        
        
        private IClient client;
        private CoherenceBridge bridge;
        
        private readonly Dictionary<string, Binding> bakedValueBindings = new Dictionary<string, Binding>()
        {
            ["c0bbba8ea6934e0891473cda634adae6"] = new Binding_89f0b9a4444bdac43a58673a772b1440_c0bbba8ea6934e0891473cda634adae6(),
            ["215428c6b6d24d75a10f8c89fe19ddef"] = new Binding_89f0b9a4444bdac43a58673a772b1440_215428c6b6d24d75a10f8c89fe19ddef(),
            ["ec85c7ffef554ee9b9c3394f35745e25"] = new Binding_89f0b9a4444bdac43a58673a772b1440_ec85c7ffef554ee9b9c3394f35745e25(),
        };
        
        private Dictionary<string, Action<CommandBinding, CommandsHandler>> bakedCommandBindings = new Dictionary<string, Action<CommandBinding, CommandsHandler>>();
        
        public CoherenceSync_89f0b9a4444bdac43a58673a772b1440()
        {
            bakedCommandBindings.Add("a5095b69922c4a87aeeb0c9bd71a479f", BakeCommandBinding__89f0b9a4444bdac43a58673a772b1440_a5095b69922c4a87aeeb0c9bd71a479f);
            bakedCommandBindings.Add("577e2e15601a4ed4a9b5dd9793d3808d", BakeCommandBinding__89f0b9a4444bdac43a58673a772b1440_577e2e15601a4ed4a9b5dd9793d3808d);
            bakedCommandBindings.Add("3d4ce41069784d68b4d0b166dd98ffc6", BakeCommandBinding__89f0b9a4444bdac43a58673a772b1440_3d4ce41069784d68b4d0b166dd98ffc6);
            bakedCommandBindings.Add("b8b234f3424b420db4570a8fbd062db5", BakeCommandBinding__89f0b9a4444bdac43a58673a772b1440_b8b234f3424b420db4570a8fbd062db5);
            bakedCommandBindings.Add("d7dc5c545db045a493cf976e2102244d", BakeCommandBinding__89f0b9a4444bdac43a58673a772b1440_d7dc5c545db045a493cf976e2102244d);
        }
        
        public override Binding BakeValueBinding(Binding valueBinding)
        {
            if (bakedValueBindings.TryGetValue(valueBinding.guid, out var bakedBinding))
            {
                valueBinding.CloneTo(bakedBinding);
                return bakedBinding;
            }
            
            return null;
        }
        
        public override void BakeCommandBinding(CommandBinding commandBinding, CommandsHandler commandsHandler)
        {
            if (bakedCommandBindings.TryGetValue(commandBinding.guid, out var commandBindingBaker))
            {
                commandBindingBaker.Invoke(commandBinding, commandsHandler);
            }
        }
    
        private void BakeCommandBinding__89f0b9a4444bdac43a58673a772b1440_a5095b69922c4a87aeeb0c9bd71a479f(CommandBinding commandBinding, CommandsHandler commandsHandler)
        {
            _89f0b9a4444bdac43a58673a772b1440_a5095b69922c4a87aeeb0c9bd71a479f_CommandTarget = (global::LabContainer)commandBinding.UnityComponent;
            commandsHandler.AddBakedCommand("LabContainer.PourLiquid", "()", SendCommand__89f0b9a4444bdac43a58673a772b1440_a5095b69922c4a87aeeb0c9bd71a479f, ReceiveLocalCommand__89f0b9a4444bdac43a58673a772b1440_a5095b69922c4a87aeeb0c9bd71a479f, MessageTarget.All, _89f0b9a4444bdac43a58673a772b1440_a5095b69922c4a87aeeb0c9bd71a479f_CommandTarget, false);
        }
        
        private void SendCommand__89f0b9a4444bdac43a58673a772b1440_a5095b69922c4a87aeeb0c9bd71a479f(MessageTarget target, object[] args)
        {
            var command = new _89f0b9a4444bdac43a58673a772b1440_a5095b69922c4a87aeeb0c9bd71a479f();
            
        
            client.SendCommand(command, target, entityId);
        }
        
        private void ReceiveLocalCommand__89f0b9a4444bdac43a58673a772b1440_a5095b69922c4a87aeeb0c9bd71a479f(MessageTarget target, object[] args)
        {
            var command = new _89f0b9a4444bdac43a58673a772b1440_a5095b69922c4a87aeeb0c9bd71a479f();
            
            
            ReceiveCommand__89f0b9a4444bdac43a58673a772b1440_a5095b69922c4a87aeeb0c9bd71a479f(command);
        }

        private void ReceiveCommand__89f0b9a4444bdac43a58673a772b1440_a5095b69922c4a87aeeb0c9bd71a479f(_89f0b9a4444bdac43a58673a772b1440_a5095b69922c4a87aeeb0c9bd71a479f command)
        {
            var target = _89f0b9a4444bdac43a58673a772b1440_a5095b69922c4a87aeeb0c9bd71a479f_CommandTarget;
            
            target.PourLiquid();
        }
    
        private void BakeCommandBinding__89f0b9a4444bdac43a58673a772b1440_577e2e15601a4ed4a9b5dd9793d3808d(CommandBinding commandBinding, CommandsHandler commandsHandler)
        {
            _89f0b9a4444bdac43a58673a772b1440_577e2e15601a4ed4a9b5dd9793d3808d_CommandTarget = (global::LabContainer)commandBinding.UnityComponent;
            commandsHandler.AddBakedCommand("LabContainer.AbsorbLiquid", "(System.Single)", SendCommand__89f0b9a4444bdac43a58673a772b1440_577e2e15601a4ed4a9b5dd9793d3808d, ReceiveLocalCommand__89f0b9a4444bdac43a58673a772b1440_577e2e15601a4ed4a9b5dd9793d3808d, MessageTarget.All, _89f0b9a4444bdac43a58673a772b1440_577e2e15601a4ed4a9b5dd9793d3808d_CommandTarget, false);
        }
        
        private void SendCommand__89f0b9a4444bdac43a58673a772b1440_577e2e15601a4ed4a9b5dd9793d3808d(MessageTarget target, object[] args)
        {
            var command = new _89f0b9a4444bdac43a58673a772b1440_577e2e15601a4ed4a9b5dd9793d3808d();
            
            int i = 0;
            command.addFill = (System.Single)args[i++];
        
            client.SendCommand(command, target, entityId);
        }
        
        private void ReceiveLocalCommand__89f0b9a4444bdac43a58673a772b1440_577e2e15601a4ed4a9b5dd9793d3808d(MessageTarget target, object[] args)
        {
            var command = new _89f0b9a4444bdac43a58673a772b1440_577e2e15601a4ed4a9b5dd9793d3808d();
            
            int i = 0;
            command.addFill = (System.Single)args[i++];
            
            ReceiveCommand__89f0b9a4444bdac43a58673a772b1440_577e2e15601a4ed4a9b5dd9793d3808d(command);
        }

        private void ReceiveCommand__89f0b9a4444bdac43a58673a772b1440_577e2e15601a4ed4a9b5dd9793d3808d(_89f0b9a4444bdac43a58673a772b1440_577e2e15601a4ed4a9b5dd9793d3808d command)
        {
            var target = _89f0b9a4444bdac43a58673a772b1440_577e2e15601a4ed4a9b5dd9793d3808d_CommandTarget;
            
            target.AbsorbLiquid((System.Single)(command.addFill));
        }
    
        private void BakeCommandBinding__89f0b9a4444bdac43a58673a772b1440_3d4ce41069784d68b4d0b166dd98ffc6(CommandBinding commandBinding, CommandsHandler commandsHandler)
        {
            _89f0b9a4444bdac43a58673a772b1440_3d4ce41069784d68b4d0b166dd98ffc6_CommandTarget = (global::LabContainer)commandBinding.UnityComponent;
            commandsHandler.AddBakedCommand("LabContainer.LocalFillChange", "(System.SingleSystem.Single)", SendCommand__89f0b9a4444bdac43a58673a772b1440_3d4ce41069784d68b4d0b166dd98ffc6, ReceiveLocalCommand__89f0b9a4444bdac43a58673a772b1440_3d4ce41069784d68b4d0b166dd98ffc6, MessageTarget.All, _89f0b9a4444bdac43a58673a772b1440_3d4ce41069784d68b4d0b166dd98ffc6_CommandTarget, false);
        }
        
        private void SendCommand__89f0b9a4444bdac43a58673a772b1440_3d4ce41069784d68b4d0b166dd98ffc6(MessageTarget target, object[] args)
        {
            var command = new _89f0b9a4444bdac43a58673a772b1440_3d4ce41069784d68b4d0b166dd98ffc6();
            
            int i = 0;
            command.startFill = (System.Single)args[i++];
            command.endFill = (System.Single)args[i++];
        
            client.SendCommand(command, target, entityId);
        }
        
        private void ReceiveLocalCommand__89f0b9a4444bdac43a58673a772b1440_3d4ce41069784d68b4d0b166dd98ffc6(MessageTarget target, object[] args)
        {
            var command = new _89f0b9a4444bdac43a58673a772b1440_3d4ce41069784d68b4d0b166dd98ffc6();
            
            int i = 0;
            command.startFill = (System.Single)args[i++];
            command.endFill = (System.Single)args[i++];
            
            ReceiveCommand__89f0b9a4444bdac43a58673a772b1440_3d4ce41069784d68b4d0b166dd98ffc6(command);
        }

        private void ReceiveCommand__89f0b9a4444bdac43a58673a772b1440_3d4ce41069784d68b4d0b166dd98ffc6(_89f0b9a4444bdac43a58673a772b1440_3d4ce41069784d68b4d0b166dd98ffc6 command)
        {
            var target = _89f0b9a4444bdac43a58673a772b1440_3d4ce41069784d68b4d0b166dd98ffc6_CommandTarget;
            
            target.LocalFillChange((System.Single)(command.startFill),(System.Single)(command.endFill));
        }
    
        private void BakeCommandBinding__89f0b9a4444bdac43a58673a772b1440_b8b234f3424b420db4570a8fbd062db5(CommandBinding commandBinding, CommandsHandler commandsHandler)
        {
            _89f0b9a4444bdac43a58673a772b1440_b8b234f3424b420db4570a8fbd062db5_CommandTarget = (global::LabContainer)commandBinding.UnityComponent;
            commandsHandler.AddBakedCommand("LabContainer.SetHighlightAlpha", "(System.Int32)", SendCommand__89f0b9a4444bdac43a58673a772b1440_b8b234f3424b420db4570a8fbd062db5, ReceiveLocalCommand__89f0b9a4444bdac43a58673a772b1440_b8b234f3424b420db4570a8fbd062db5, MessageTarget.All, _89f0b9a4444bdac43a58673a772b1440_b8b234f3424b420db4570a8fbd062db5_CommandTarget, false);
        }
        
        private void SendCommand__89f0b9a4444bdac43a58673a772b1440_b8b234f3424b420db4570a8fbd062db5(MessageTarget target, object[] args)
        {
            var command = new _89f0b9a4444bdac43a58673a772b1440_b8b234f3424b420db4570a8fbd062db5();
            
            int i = 0;
            command.alpha = (System.Int32)args[i++];
        
            client.SendCommand(command, target, entityId);
        }
        
        private void ReceiveLocalCommand__89f0b9a4444bdac43a58673a772b1440_b8b234f3424b420db4570a8fbd062db5(MessageTarget target, object[] args)
        {
            var command = new _89f0b9a4444bdac43a58673a772b1440_b8b234f3424b420db4570a8fbd062db5();
            
            int i = 0;
            command.alpha = (System.Int32)args[i++];
            
            ReceiveCommand__89f0b9a4444bdac43a58673a772b1440_b8b234f3424b420db4570a8fbd062db5(command);
        }

        private void ReceiveCommand__89f0b9a4444bdac43a58673a772b1440_b8b234f3424b420db4570a8fbd062db5(_89f0b9a4444bdac43a58673a772b1440_b8b234f3424b420db4570a8fbd062db5 command)
        {
            var target = _89f0b9a4444bdac43a58673a772b1440_b8b234f3424b420db4570a8fbd062db5_CommandTarget;
            
            target.SetHighlightAlpha((System.Int32)(command.alpha));
        }
    
        private void BakeCommandBinding__89f0b9a4444bdac43a58673a772b1440_d7dc5c545db045a493cf976e2102244d(CommandBinding commandBinding, CommandsHandler commandsHandler)
        {
            _89f0b9a4444bdac43a58673a772b1440_d7dc5c545db045a493cf976e2102244d_CommandTarget = (global::LabContainer)commandBinding.UnityComponent;
            commandsHandler.AddBakedCommand("LabContainer.Refill", "()", SendCommand__89f0b9a4444bdac43a58673a772b1440_d7dc5c545db045a493cf976e2102244d, ReceiveLocalCommand__89f0b9a4444bdac43a58673a772b1440_d7dc5c545db045a493cf976e2102244d, MessageTarget.All, _89f0b9a4444bdac43a58673a772b1440_d7dc5c545db045a493cf976e2102244d_CommandTarget, false);
        }
        
        private void SendCommand__89f0b9a4444bdac43a58673a772b1440_d7dc5c545db045a493cf976e2102244d(MessageTarget target, object[] args)
        {
            var command = new _89f0b9a4444bdac43a58673a772b1440_d7dc5c545db045a493cf976e2102244d();
            
        
            client.SendCommand(command, target, entityId);
        }
        
        private void ReceiveLocalCommand__89f0b9a4444bdac43a58673a772b1440_d7dc5c545db045a493cf976e2102244d(MessageTarget target, object[] args)
        {
            var command = new _89f0b9a4444bdac43a58673a772b1440_d7dc5c545db045a493cf976e2102244d();
            
            
            ReceiveCommand__89f0b9a4444bdac43a58673a772b1440_d7dc5c545db045a493cf976e2102244d(command);
        }

        private void ReceiveCommand__89f0b9a4444bdac43a58673a772b1440_d7dc5c545db045a493cf976e2102244d(_89f0b9a4444bdac43a58673a772b1440_d7dc5c545db045a493cf976e2102244d command)
        {
            var target = _89f0b9a4444bdac43a58673a772b1440_d7dc5c545db045a493cf976e2102244d_CommandTarget;
            
            target.Refill();
        }
        
        public override void ReceiveCommand(IEntityCommand command)
        {
            switch (command)
            {
                case _89f0b9a4444bdac43a58673a772b1440_a5095b69922c4a87aeeb0c9bd71a479f castedCommand:
                    ReceiveCommand__89f0b9a4444bdac43a58673a772b1440_a5095b69922c4a87aeeb0c9bd71a479f(castedCommand);
                    break;
                case _89f0b9a4444bdac43a58673a772b1440_577e2e15601a4ed4a9b5dd9793d3808d castedCommand:
                    ReceiveCommand__89f0b9a4444bdac43a58673a772b1440_577e2e15601a4ed4a9b5dd9793d3808d(castedCommand);
                    break;
                case _89f0b9a4444bdac43a58673a772b1440_3d4ce41069784d68b4d0b166dd98ffc6 castedCommand:
                    ReceiveCommand__89f0b9a4444bdac43a58673a772b1440_3d4ce41069784d68b4d0b166dd98ffc6(castedCommand);
                    break;
                case _89f0b9a4444bdac43a58673a772b1440_b8b234f3424b420db4570a8fbd062db5 castedCommand:
                    ReceiveCommand__89f0b9a4444bdac43a58673a772b1440_b8b234f3424b420db4570a8fbd062db5(castedCommand);
                    break;
                case _89f0b9a4444bdac43a58673a772b1440_d7dc5c545db045a493cf976e2102244d castedCommand:
                    ReceiveCommand__89f0b9a4444bdac43a58673a772b1440_d7dc5c545db045a493cf976e2102244d(castedCommand);
                    break;
                default:
                    logger.Warning($"CoherenceSync_89f0b9a4444bdac43a58673a772b1440 Unhandled command: {command.GetType()}.");
                    break;
            }
        }
        
        public override List<ICoherenceComponentData> CreateEntity(bool usesLodsAtRuntime, string archetypeName, AbsoluteSimulationFrame simFrame)
        {
            if (!usesLodsAtRuntime)
            {
                return null;
            }
            
            if (Archetypes.IndexForName.TryGetValue(archetypeName, out int archetypeIndex))
            {
                var components = new List<ICoherenceComponentData>()
                {
                    new ArchetypeComponent
                    {
                        index = archetypeIndex,
                        indexSimulationFrame = simFrame,
                        FieldsMask = 0b1
                    }
                };

                return components;
            }
    
            logger.Warning($"Unable to find archetype {archetypeName} in dictionary. Please, bake manually (coherence > Bake)");
            
            return null;
        }
        
        public override void Dispose()
        {
        }
        
        public override void Initialize(Entity entityId, CoherenceBridge bridge, IClient client, CoherenceInput input, Logger logger)
        {
            this.logger = logger.With<CoherenceSync_89f0b9a4444bdac43a58673a772b1440>();
            this.bridge = bridge;
            this.entityId = entityId;
            this.client = client;        
        }
    }

}