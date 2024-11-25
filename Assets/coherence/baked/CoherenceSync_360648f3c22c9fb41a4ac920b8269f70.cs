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
    public class Binding_360648f3c22c9fb41a4ac920b8269f70_4c17ec6441374f78a68558bca06f2c17 : PositionBinding
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
    public class Binding_360648f3c22c9fb41a4ac920b8269f70_17ba4ddc5255425a927c9698240a3697 : RotationBinding
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
    public class Binding_360648f3c22c9fb41a4ac920b8269f70_4b97dfa02aef41778194016e087de7dd : DeepPositionBinding
    {   
        private global::UnityEngine.Transform CastedUnityComponent;

        protected override void OnBindingCloned()
        {
    	    CastedUnityComponent = (global::UnityEngine.Transform)UnityComponent;
        }

        public override global::System.Type CoherenceComponentType => typeof(_360648f3c22c9fb41a4ac920b8269f70_8303579749327279811);
        public override string CoherenceComponentName => "_360648f3c22c9fb41a4ac920b8269f70_8303579749327279811";
        public override uint FieldMask => 0b00000000000000000000000000000001;

        public override UnityEngine.Vector3 Value
        {
            get { return (UnityEngine.Vector3)(CastedUnityComponent.localPosition); }
            set { CastedUnityComponent.localPosition = (UnityEngine.Vector3)(value); }
        }

        protected override (UnityEngine.Vector3 value, AbsoluteSimulationFrame simFrame) ReadComponentData(ICoherenceComponentData coherenceComponent, Vector3 floatingOriginDelta)
        {
            var value = ((_360648f3c22c9fb41a4ac920b8269f70_8303579749327279811)coherenceComponent).position;

            var simFrame = ((_360648f3c22c9fb41a4ac920b8269f70_8303579749327279811)coherenceComponent).positionSimulationFrame;
            
            return (value, simFrame);
        }

        public override ICoherenceComponentData WriteComponentData(ICoherenceComponentData coherenceComponent, AbsoluteSimulationFrame simFrame)
        {
            var update = (_360648f3c22c9fb41a4ac920b8269f70_8303579749327279811)coherenceComponent;
            if (Interpolator.IsInterpolationNone)
            {
                update.position = Value;
            }
            else
            {
                update.position = GetInterpolatedAt(simFrame / InterpolationSettings.SimulationFramesPerSecond);
            }

            update.positionSimulationFrame = simFrame;
            
            return update;
        }

        public override ICoherenceComponentData CreateComponentData()
        {
            return new _360648f3c22c9fb41a4ac920b8269f70_8303579749327279811();
        }    
    }
    
    [UnityEngine.Scripting.Preserve]
    public class Binding_360648f3c22c9fb41a4ac920b8269f70_3fb1d1f0abdd4c069e66a4720a2b68d5 : DeepRotationBinding
    {   
        private global::UnityEngine.Transform CastedUnityComponent;

        protected override void OnBindingCloned()
        {
    	    CastedUnityComponent = (global::UnityEngine.Transform)UnityComponent;
        }

        public override global::System.Type CoherenceComponentType => typeof(_360648f3c22c9fb41a4ac920b8269f70_8303579749327279811);
        public override string CoherenceComponentName => "_360648f3c22c9fb41a4ac920b8269f70_8303579749327279811";
        public override uint FieldMask => 0b00000000000000000000000000000010;

        public override UnityEngine.Quaternion Value
        {
            get { return (UnityEngine.Quaternion)(CastedUnityComponent.localRotation); }
            set { CastedUnityComponent.localRotation = (UnityEngine.Quaternion)(value); }
        }

        protected override (UnityEngine.Quaternion value, AbsoluteSimulationFrame simFrame) ReadComponentData(ICoherenceComponentData coherenceComponent, Vector3 floatingOriginDelta)
        {
            var value = ((_360648f3c22c9fb41a4ac920b8269f70_8303579749327279811)coherenceComponent).rotation;

            var simFrame = ((_360648f3c22c9fb41a4ac920b8269f70_8303579749327279811)coherenceComponent).rotationSimulationFrame;
            
            return (value, simFrame);
        }

        public override ICoherenceComponentData WriteComponentData(ICoherenceComponentData coherenceComponent, AbsoluteSimulationFrame simFrame)
        {
            var update = (_360648f3c22c9fb41a4ac920b8269f70_8303579749327279811)coherenceComponent;
            if (Interpolator.IsInterpolationNone)
            {
                update.rotation = Value;
            }
            else
            {
                update.rotation = GetInterpolatedAt(simFrame / InterpolationSettings.SimulationFramesPerSecond);
            }

            update.rotationSimulationFrame = simFrame;
            
            return update;
        }

        public override ICoherenceComponentData CreateComponentData()
        {
            return new _360648f3c22c9fb41a4ac920b8269f70_8303579749327279811();
        }    
    }
    
    [UnityEngine.Scripting.Preserve]
    public class Binding_360648f3c22c9fb41a4ac920b8269f70_5d7d5008852a493db77bab1832b4b584 : DeepPositionBinding
    {   
        private global::UnityEngine.Transform CastedUnityComponent;

        protected override void OnBindingCloned()
        {
    	    CastedUnityComponent = (global::UnityEngine.Transform)UnityComponent;
        }

        public override global::System.Type CoherenceComponentType => typeof(_360648f3c22c9fb41a4ac920b8269f70_1784774650460060972);
        public override string CoherenceComponentName => "_360648f3c22c9fb41a4ac920b8269f70_1784774650460060972";
        public override uint FieldMask => 0b00000000000000000000000000000001;

        public override UnityEngine.Vector3 Value
        {
            get { return (UnityEngine.Vector3)(CastedUnityComponent.localPosition); }
            set { CastedUnityComponent.localPosition = (UnityEngine.Vector3)(value); }
        }

        protected override (UnityEngine.Vector3 value, AbsoluteSimulationFrame simFrame) ReadComponentData(ICoherenceComponentData coherenceComponent, Vector3 floatingOriginDelta)
        {
            var value = ((_360648f3c22c9fb41a4ac920b8269f70_1784774650460060972)coherenceComponent).position;

            var simFrame = ((_360648f3c22c9fb41a4ac920b8269f70_1784774650460060972)coherenceComponent).positionSimulationFrame;
            
            return (value, simFrame);
        }

        public override ICoherenceComponentData WriteComponentData(ICoherenceComponentData coherenceComponent, AbsoluteSimulationFrame simFrame)
        {
            var update = (_360648f3c22c9fb41a4ac920b8269f70_1784774650460060972)coherenceComponent;
            if (Interpolator.IsInterpolationNone)
            {
                update.position = Value;
            }
            else
            {
                update.position = GetInterpolatedAt(simFrame / InterpolationSettings.SimulationFramesPerSecond);
            }

            update.positionSimulationFrame = simFrame;
            
            return update;
        }

        public override ICoherenceComponentData CreateComponentData()
        {
            return new _360648f3c22c9fb41a4ac920b8269f70_1784774650460060972();
        }    
    }
    
    [UnityEngine.Scripting.Preserve]
    public class Binding_360648f3c22c9fb41a4ac920b8269f70_678a81a06e6545349586219d91bdc881 : DeepRotationBinding
    {   
        private global::UnityEngine.Transform CastedUnityComponent;

        protected override void OnBindingCloned()
        {
    	    CastedUnityComponent = (global::UnityEngine.Transform)UnityComponent;
        }

        public override global::System.Type CoherenceComponentType => typeof(_360648f3c22c9fb41a4ac920b8269f70_1784774650460060972);
        public override string CoherenceComponentName => "_360648f3c22c9fb41a4ac920b8269f70_1784774650460060972";
        public override uint FieldMask => 0b00000000000000000000000000000010;

        public override UnityEngine.Quaternion Value
        {
            get { return (UnityEngine.Quaternion)(CastedUnityComponent.localRotation); }
            set { CastedUnityComponent.localRotation = (UnityEngine.Quaternion)(value); }
        }

        protected override (UnityEngine.Quaternion value, AbsoluteSimulationFrame simFrame) ReadComponentData(ICoherenceComponentData coherenceComponent, Vector3 floatingOriginDelta)
        {
            var value = ((_360648f3c22c9fb41a4ac920b8269f70_1784774650460060972)coherenceComponent).rotation;

            var simFrame = ((_360648f3c22c9fb41a4ac920b8269f70_1784774650460060972)coherenceComponent).rotationSimulationFrame;
            
            return (value, simFrame);
        }

        public override ICoherenceComponentData WriteComponentData(ICoherenceComponentData coherenceComponent, AbsoluteSimulationFrame simFrame)
        {
            var update = (_360648f3c22c9fb41a4ac920b8269f70_1784774650460060972)coherenceComponent;
            if (Interpolator.IsInterpolationNone)
            {
                update.rotation = Value;
            }
            else
            {
                update.rotation = GetInterpolatedAt(simFrame / InterpolationSettings.SimulationFramesPerSecond);
            }

            update.rotationSimulationFrame = simFrame;
            
            return update;
        }

        public override ICoherenceComponentData CreateComponentData()
        {
            return new _360648f3c22c9fb41a4ac920b8269f70_1784774650460060972();
        }    
    }
    
    [UnityEngine.Scripting.Preserve]
    public class Binding_360648f3c22c9fb41a4ac920b8269f70_920c04581dc04c7181a6b89355edb74b : DeepPositionBinding
    {   
        private global::UnityEngine.Transform CastedUnityComponent;

        protected override void OnBindingCloned()
        {
    	    CastedUnityComponent = (global::UnityEngine.Transform)UnityComponent;
        }

        public override global::System.Type CoherenceComponentType => typeof(_360648f3c22c9fb41a4ac920b8269f70_8178940138649331564);
        public override string CoherenceComponentName => "_360648f3c22c9fb41a4ac920b8269f70_8178940138649331564";
        public override uint FieldMask => 0b00000000000000000000000000000001;

        public override UnityEngine.Vector3 Value
        {
            get { return (UnityEngine.Vector3)(CastedUnityComponent.localPosition); }
            set { CastedUnityComponent.localPosition = (UnityEngine.Vector3)(value); }
        }

        protected override (UnityEngine.Vector3 value, AbsoluteSimulationFrame simFrame) ReadComponentData(ICoherenceComponentData coherenceComponent, Vector3 floatingOriginDelta)
        {
            var value = ((_360648f3c22c9fb41a4ac920b8269f70_8178940138649331564)coherenceComponent).position;

            var simFrame = ((_360648f3c22c9fb41a4ac920b8269f70_8178940138649331564)coherenceComponent).positionSimulationFrame;
            
            return (value, simFrame);
        }

        public override ICoherenceComponentData WriteComponentData(ICoherenceComponentData coherenceComponent, AbsoluteSimulationFrame simFrame)
        {
            var update = (_360648f3c22c9fb41a4ac920b8269f70_8178940138649331564)coherenceComponent;
            if (Interpolator.IsInterpolationNone)
            {
                update.position = Value;
            }
            else
            {
                update.position = GetInterpolatedAt(simFrame / InterpolationSettings.SimulationFramesPerSecond);
            }

            update.positionSimulationFrame = simFrame;
            
            return update;
        }

        public override ICoherenceComponentData CreateComponentData()
        {
            return new _360648f3c22c9fb41a4ac920b8269f70_8178940138649331564();
        }    
    }
    
    [UnityEngine.Scripting.Preserve]
    public class Binding_360648f3c22c9fb41a4ac920b8269f70_15823f0fe5fc4f8fb780273b58a5d52e : DeepRotationBinding
    {   
        private global::UnityEngine.Transform CastedUnityComponent;

        protected override void OnBindingCloned()
        {
    	    CastedUnityComponent = (global::UnityEngine.Transform)UnityComponent;
        }

        public override global::System.Type CoherenceComponentType => typeof(_360648f3c22c9fb41a4ac920b8269f70_8178940138649331564);
        public override string CoherenceComponentName => "_360648f3c22c9fb41a4ac920b8269f70_8178940138649331564";
        public override uint FieldMask => 0b00000000000000000000000000000010;

        public override UnityEngine.Quaternion Value
        {
            get { return (UnityEngine.Quaternion)(CastedUnityComponent.localRotation); }
            set { CastedUnityComponent.localRotation = (UnityEngine.Quaternion)(value); }
        }

        protected override (UnityEngine.Quaternion value, AbsoluteSimulationFrame simFrame) ReadComponentData(ICoherenceComponentData coherenceComponent, Vector3 floatingOriginDelta)
        {
            var value = ((_360648f3c22c9fb41a4ac920b8269f70_8178940138649331564)coherenceComponent).rotation;

            var simFrame = ((_360648f3c22c9fb41a4ac920b8269f70_8178940138649331564)coherenceComponent).rotationSimulationFrame;
            
            return (value, simFrame);
        }

        public override ICoherenceComponentData WriteComponentData(ICoherenceComponentData coherenceComponent, AbsoluteSimulationFrame simFrame)
        {
            var update = (_360648f3c22c9fb41a4ac920b8269f70_8178940138649331564)coherenceComponent;
            if (Interpolator.IsInterpolationNone)
            {
                update.rotation = Value;
            }
            else
            {
                update.rotation = GetInterpolatedAt(simFrame / InterpolationSettings.SimulationFramesPerSecond);
            }

            update.rotationSimulationFrame = simFrame;
            
            return update;
        }

        public override ICoherenceComponentData CreateComponentData()
        {
            return new _360648f3c22c9fb41a4ac920b8269f70_8178940138649331564();
        }    
    }
    
    [UnityEngine.Scripting.Preserve]
    public class Binding_360648f3c22c9fb41a4ac920b8269f70_d87f098abce74f2cb9d29a39d414db6b : DeepPositionBinding
    {   
        private global::UnityEngine.Transform CastedUnityComponent;

        protected override void OnBindingCloned()
        {
    	    CastedUnityComponent = (global::UnityEngine.Transform)UnityComponent;
        }

        public override global::System.Type CoherenceComponentType => typeof(_360648f3c22c9fb41a4ac920b8269f70_976679110228619647);
        public override string CoherenceComponentName => "_360648f3c22c9fb41a4ac920b8269f70_976679110228619647";
        public override uint FieldMask => 0b00000000000000000000000000000001;

        public override UnityEngine.Vector3 Value
        {
            get { return (UnityEngine.Vector3)(CastedUnityComponent.localPosition); }
            set { CastedUnityComponent.localPosition = (UnityEngine.Vector3)(value); }
        }

        protected override (UnityEngine.Vector3 value, AbsoluteSimulationFrame simFrame) ReadComponentData(ICoherenceComponentData coherenceComponent, Vector3 floatingOriginDelta)
        {
            var value = ((_360648f3c22c9fb41a4ac920b8269f70_976679110228619647)coherenceComponent).position;

            var simFrame = ((_360648f3c22c9fb41a4ac920b8269f70_976679110228619647)coherenceComponent).positionSimulationFrame;
            
            return (value, simFrame);
        }

        public override ICoherenceComponentData WriteComponentData(ICoherenceComponentData coherenceComponent, AbsoluteSimulationFrame simFrame)
        {
            var update = (_360648f3c22c9fb41a4ac920b8269f70_976679110228619647)coherenceComponent;
            if (Interpolator.IsInterpolationNone)
            {
                update.position = Value;
            }
            else
            {
                update.position = GetInterpolatedAt(simFrame / InterpolationSettings.SimulationFramesPerSecond);
            }

            update.positionSimulationFrame = simFrame;
            
            return update;
        }

        public override ICoherenceComponentData CreateComponentData()
        {
            return new _360648f3c22c9fb41a4ac920b8269f70_976679110228619647();
        }    
    }
    
    [UnityEngine.Scripting.Preserve]
    public class Binding_360648f3c22c9fb41a4ac920b8269f70_1d122660f8aa4bc7bfc5907fe973a7be : DeepRotationBinding
    {   
        private global::UnityEngine.Transform CastedUnityComponent;

        protected override void OnBindingCloned()
        {
    	    CastedUnityComponent = (global::UnityEngine.Transform)UnityComponent;
        }

        public override global::System.Type CoherenceComponentType => typeof(_360648f3c22c9fb41a4ac920b8269f70_976679110228619647);
        public override string CoherenceComponentName => "_360648f3c22c9fb41a4ac920b8269f70_976679110228619647";
        public override uint FieldMask => 0b00000000000000000000000000000010;

        public override UnityEngine.Quaternion Value
        {
            get { return (UnityEngine.Quaternion)(CastedUnityComponent.localRotation); }
            set { CastedUnityComponent.localRotation = (UnityEngine.Quaternion)(value); }
        }

        protected override (UnityEngine.Quaternion value, AbsoluteSimulationFrame simFrame) ReadComponentData(ICoherenceComponentData coherenceComponent, Vector3 floatingOriginDelta)
        {
            var value = ((_360648f3c22c9fb41a4ac920b8269f70_976679110228619647)coherenceComponent).rotation;

            var simFrame = ((_360648f3c22c9fb41a4ac920b8269f70_976679110228619647)coherenceComponent).rotationSimulationFrame;
            
            return (value, simFrame);
        }

        public override ICoherenceComponentData WriteComponentData(ICoherenceComponentData coherenceComponent, AbsoluteSimulationFrame simFrame)
        {
            var update = (_360648f3c22c9fb41a4ac920b8269f70_976679110228619647)coherenceComponent;
            if (Interpolator.IsInterpolationNone)
            {
                update.rotation = Value;
            }
            else
            {
                update.rotation = GetInterpolatedAt(simFrame / InterpolationSettings.SimulationFramesPerSecond);
            }

            update.rotationSimulationFrame = simFrame;
            
            return update;
        }

        public override ICoherenceComponentData CreateComponentData()
        {
            return new _360648f3c22c9fb41a4ac920b8269f70_976679110228619647();
        }    
    }
    
    [UnityEngine.Scripting.Preserve]
    public class Binding_360648f3c22c9fb41a4ac920b8269f70_1b4d0cb66cb24117a037849bda0a43c8 : DeepPositionBinding
    {   
        private global::UnityEngine.Transform CastedUnityComponent;

        protected override void OnBindingCloned()
        {
    	    CastedUnityComponent = (global::UnityEngine.Transform)UnityComponent;
        }

        public override global::System.Type CoherenceComponentType => typeof(_360648f3c22c9fb41a4ac920b8269f70_1778728379703199811);
        public override string CoherenceComponentName => "_360648f3c22c9fb41a4ac920b8269f70_1778728379703199811";
        public override uint FieldMask => 0b00000000000000000000000000000001;

        public override UnityEngine.Vector3 Value
        {
            get { return (UnityEngine.Vector3)(CastedUnityComponent.localPosition); }
            set { CastedUnityComponent.localPosition = (UnityEngine.Vector3)(value); }
        }

        protected override (UnityEngine.Vector3 value, AbsoluteSimulationFrame simFrame) ReadComponentData(ICoherenceComponentData coherenceComponent, Vector3 floatingOriginDelta)
        {
            var value = ((_360648f3c22c9fb41a4ac920b8269f70_1778728379703199811)coherenceComponent).position;

            var simFrame = ((_360648f3c22c9fb41a4ac920b8269f70_1778728379703199811)coherenceComponent).positionSimulationFrame;
            
            return (value, simFrame);
        }

        public override ICoherenceComponentData WriteComponentData(ICoherenceComponentData coherenceComponent, AbsoluteSimulationFrame simFrame)
        {
            var update = (_360648f3c22c9fb41a4ac920b8269f70_1778728379703199811)coherenceComponent;
            if (Interpolator.IsInterpolationNone)
            {
                update.position = Value;
            }
            else
            {
                update.position = GetInterpolatedAt(simFrame / InterpolationSettings.SimulationFramesPerSecond);
            }

            update.positionSimulationFrame = simFrame;
            
            return update;
        }

        public override ICoherenceComponentData CreateComponentData()
        {
            return new _360648f3c22c9fb41a4ac920b8269f70_1778728379703199811();
        }    
    }
    
    [UnityEngine.Scripting.Preserve]
    public class Binding_360648f3c22c9fb41a4ac920b8269f70_558034bdb66d40419854cd5ac9ea00e5 : DeepPositionBinding
    {   
        private global::UnityEngine.Transform CastedUnityComponent;

        protected override void OnBindingCloned()
        {
    	    CastedUnityComponent = (global::UnityEngine.Transform)UnityComponent;
        }

        public override global::System.Type CoherenceComponentType => typeof(_360648f3c22c9fb41a4ac920b8269f70_2000181485725708302);
        public override string CoherenceComponentName => "_360648f3c22c9fb41a4ac920b8269f70_2000181485725708302";
        public override uint FieldMask => 0b00000000000000000000000000000001;

        public override UnityEngine.Vector3 Value
        {
            get { return (UnityEngine.Vector3)(CastedUnityComponent.localPosition); }
            set { CastedUnityComponent.localPosition = (UnityEngine.Vector3)(value); }
        }

        protected override (UnityEngine.Vector3 value, AbsoluteSimulationFrame simFrame) ReadComponentData(ICoherenceComponentData coherenceComponent, Vector3 floatingOriginDelta)
        {
            var value = ((_360648f3c22c9fb41a4ac920b8269f70_2000181485725708302)coherenceComponent).position;

            var simFrame = ((_360648f3c22c9fb41a4ac920b8269f70_2000181485725708302)coherenceComponent).positionSimulationFrame;
            
            return (value, simFrame);
        }

        public override ICoherenceComponentData WriteComponentData(ICoherenceComponentData coherenceComponent, AbsoluteSimulationFrame simFrame)
        {
            var update = (_360648f3c22c9fb41a4ac920b8269f70_2000181485725708302)coherenceComponent;
            if (Interpolator.IsInterpolationNone)
            {
                update.position = Value;
            }
            else
            {
                update.position = GetInterpolatedAt(simFrame / InterpolationSettings.SimulationFramesPerSecond);
            }

            update.positionSimulationFrame = simFrame;
            
            return update;
        }

        public override ICoherenceComponentData CreateComponentData()
        {
            return new _360648f3c22c9fb41a4ac920b8269f70_2000181485725708302();
        }    
    }
    
    [UnityEngine.Scripting.Preserve]
    public class Binding_360648f3c22c9fb41a4ac920b8269f70_ba40df012e854f4896dacb40a1729ac6 : DeepPositionBinding
    {   
        private global::UnityEngine.Transform CastedUnityComponent;

        protected override void OnBindingCloned()
        {
    	    CastedUnityComponent = (global::UnityEngine.Transform)UnityComponent;
        }

        public override global::System.Type CoherenceComponentType => typeof(_360648f3c22c9fb41a4ac920b8269f70_2456403841789217788);
        public override string CoherenceComponentName => "_360648f3c22c9fb41a4ac920b8269f70_2456403841789217788";
        public override uint FieldMask => 0b00000000000000000000000000000001;

        public override UnityEngine.Vector3 Value
        {
            get { return (UnityEngine.Vector3)(CastedUnityComponent.localPosition); }
            set { CastedUnityComponent.localPosition = (UnityEngine.Vector3)(value); }
        }

        protected override (UnityEngine.Vector3 value, AbsoluteSimulationFrame simFrame) ReadComponentData(ICoherenceComponentData coherenceComponent, Vector3 floatingOriginDelta)
        {
            var value = ((_360648f3c22c9fb41a4ac920b8269f70_2456403841789217788)coherenceComponent).position;

            var simFrame = ((_360648f3c22c9fb41a4ac920b8269f70_2456403841789217788)coherenceComponent).positionSimulationFrame;
            
            return (value, simFrame);
        }

        public override ICoherenceComponentData WriteComponentData(ICoherenceComponentData coherenceComponent, AbsoluteSimulationFrame simFrame)
        {
            var update = (_360648f3c22c9fb41a4ac920b8269f70_2456403841789217788)coherenceComponent;
            if (Interpolator.IsInterpolationNone)
            {
                update.position = Value;
            }
            else
            {
                update.position = GetInterpolatedAt(simFrame / InterpolationSettings.SimulationFramesPerSecond);
            }

            update.positionSimulationFrame = simFrame;
            
            return update;
        }

        public override ICoherenceComponentData CreateComponentData()
        {
            return new _360648f3c22c9fb41a4ac920b8269f70_2456403841789217788();
        }    
    }
    
    [UnityEngine.Scripting.Preserve]
    public class Binding_360648f3c22c9fb41a4ac920b8269f70_2076a9075dfa4248b2eaef6f0177032e : DeepRotationBinding
    {   
        private global::UnityEngine.Transform CastedUnityComponent;

        protected override void OnBindingCloned()
        {
    	    CastedUnityComponent = (global::UnityEngine.Transform)UnityComponent;
        }

        public override global::System.Type CoherenceComponentType => typeof(_360648f3c22c9fb41a4ac920b8269f70_2456403841789217788);
        public override string CoherenceComponentName => "_360648f3c22c9fb41a4ac920b8269f70_2456403841789217788";
        public override uint FieldMask => 0b00000000000000000000000000000010;

        public override UnityEngine.Quaternion Value
        {
            get { return (UnityEngine.Quaternion)(CastedUnityComponent.localRotation); }
            set { CastedUnityComponent.localRotation = (UnityEngine.Quaternion)(value); }
        }

        protected override (UnityEngine.Quaternion value, AbsoluteSimulationFrame simFrame) ReadComponentData(ICoherenceComponentData coherenceComponent, Vector3 floatingOriginDelta)
        {
            var value = ((_360648f3c22c9fb41a4ac920b8269f70_2456403841789217788)coherenceComponent).rotation;

            var simFrame = ((_360648f3c22c9fb41a4ac920b8269f70_2456403841789217788)coherenceComponent).rotationSimulationFrame;
            
            return (value, simFrame);
        }

        public override ICoherenceComponentData WriteComponentData(ICoherenceComponentData coherenceComponent, AbsoluteSimulationFrame simFrame)
        {
            var update = (_360648f3c22c9fb41a4ac920b8269f70_2456403841789217788)coherenceComponent;
            if (Interpolator.IsInterpolationNone)
            {
                update.rotation = Value;
            }
            else
            {
                update.rotation = GetInterpolatedAt(simFrame / InterpolationSettings.SimulationFramesPerSecond);
            }

            update.rotationSimulationFrame = simFrame;
            
            return update;
        }

        public override ICoherenceComponentData CreateComponentData()
        {
            return new _360648f3c22c9fb41a4ac920b8269f70_2456403841789217788();
        }    
    }

    [UnityEngine.Scripting.Preserve]
    public class CoherenceSync_360648f3c22c9fb41a4ac920b8269f70 : CoherenceSyncBaked
    {
        private Entity entityId;
        private Logger logger = Coherence.Log.Log.GetLogger<CoherenceSync_360648f3c22c9fb41a4ac920b8269f70>();
        
        
        
        private IClient client;
        private CoherenceBridge bridge;
        
        private readonly Dictionary<string, Binding> bakedValueBindings = new Dictionary<string, Binding>()
        {
            ["4c17ec6441374f78a68558bca06f2c17"] = new Binding_360648f3c22c9fb41a4ac920b8269f70_4c17ec6441374f78a68558bca06f2c17(),
            ["17ba4ddc5255425a927c9698240a3697"] = new Binding_360648f3c22c9fb41a4ac920b8269f70_17ba4ddc5255425a927c9698240a3697(),
            ["4b97dfa02aef41778194016e087de7dd"] = new Binding_360648f3c22c9fb41a4ac920b8269f70_4b97dfa02aef41778194016e087de7dd(),
            ["3fb1d1f0abdd4c069e66a4720a2b68d5"] = new Binding_360648f3c22c9fb41a4ac920b8269f70_3fb1d1f0abdd4c069e66a4720a2b68d5(),
            ["5d7d5008852a493db77bab1832b4b584"] = new Binding_360648f3c22c9fb41a4ac920b8269f70_5d7d5008852a493db77bab1832b4b584(),
            ["678a81a06e6545349586219d91bdc881"] = new Binding_360648f3c22c9fb41a4ac920b8269f70_678a81a06e6545349586219d91bdc881(),
            ["920c04581dc04c7181a6b89355edb74b"] = new Binding_360648f3c22c9fb41a4ac920b8269f70_920c04581dc04c7181a6b89355edb74b(),
            ["15823f0fe5fc4f8fb780273b58a5d52e"] = new Binding_360648f3c22c9fb41a4ac920b8269f70_15823f0fe5fc4f8fb780273b58a5d52e(),
            ["d87f098abce74f2cb9d29a39d414db6b"] = new Binding_360648f3c22c9fb41a4ac920b8269f70_d87f098abce74f2cb9d29a39d414db6b(),
            ["1d122660f8aa4bc7bfc5907fe973a7be"] = new Binding_360648f3c22c9fb41a4ac920b8269f70_1d122660f8aa4bc7bfc5907fe973a7be(),
            ["1b4d0cb66cb24117a037849bda0a43c8"] = new Binding_360648f3c22c9fb41a4ac920b8269f70_1b4d0cb66cb24117a037849bda0a43c8(),
            ["558034bdb66d40419854cd5ac9ea00e5"] = new Binding_360648f3c22c9fb41a4ac920b8269f70_558034bdb66d40419854cd5ac9ea00e5(),
            ["ba40df012e854f4896dacb40a1729ac6"] = new Binding_360648f3c22c9fb41a4ac920b8269f70_ba40df012e854f4896dacb40a1729ac6(),
            ["2076a9075dfa4248b2eaef6f0177032e"] = new Binding_360648f3c22c9fb41a4ac920b8269f70_2076a9075dfa4248b2eaef6f0177032e(),
        };
        
        private Dictionary<string, Action<CommandBinding, CommandsHandler>> bakedCommandBindings = new Dictionary<string, Action<CommandBinding, CommandsHandler>>();
        
        public CoherenceSync_360648f3c22c9fb41a4ac920b8269f70()
        {
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
        
        public override void ReceiveCommand(IEntityCommand command)
        {
            switch (command)
            {
                default:
                    logger.Warning($"CoherenceSync_360648f3c22c9fb41a4ac920b8269f70 Unhandled command: {command.GetType()}.");
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
            this.logger = logger.With<CoherenceSync_360648f3c22c9fb41a4ac920b8269f70>();
            this.bridge = bridge;
            this.entityId = entityId;
            this.client = client;        
        }
    }

}