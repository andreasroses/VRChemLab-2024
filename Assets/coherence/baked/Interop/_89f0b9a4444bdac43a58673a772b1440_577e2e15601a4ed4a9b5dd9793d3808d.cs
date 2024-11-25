// Copyright (c) coherence ApS.
// For all coherence generated code, the coherence SDK license terms apply. See the license file in the coherence Package root folder for more information.

// <auto-generated>
// Generated file. DO NOT EDIT!
// </auto-generated>
namespace Coherence.Generated
{
    using Coherence.ProtocolDef;
    using Coherence.Serializer;
    using Coherence.Brook;
    using Coherence.Entities;
    using Coherence.Log;
    using Coherence.Core;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using UnityEngine;

    public struct _89f0b9a4444bdac43a58673a772b1440_577e2e15601a4ed4a9b5dd9793d3808d : IEntityCommand
    {
        [StructLayout(LayoutKind.Explicit)]
        public struct Interop
        {
            [FieldOffset(0)]
            public System.Single addFill;
        }

        public static unsafe _89f0b9a4444bdac43a58673a772b1440_577e2e15601a4ed4a9b5dd9793d3808d FromInterop(System.IntPtr data, System.Int32 dataSize) 
        {
            if (dataSize != 4) {
                throw new System.Exception($"Given data size is not equal to the struct size. ({dataSize} != 4) " +
                    "for command with ID 12");
            }

            var orig = new _89f0b9a4444bdac43a58673a772b1440_577e2e15601a4ed4a9b5dd9793d3808d();
            var comp = (Interop*)data;
            orig.addFill = comp->addFill;
            return orig;
        }

        public System.Single addFill;
        
        public Entity Entity { get; set; }
        public MessageTarget Routing { get; set; }
        public uint Sender { get; set; }
        public uint GetComponentType() => 12;
        
        public IEntityMessage Clone()
        {
            // This is a struct, so we can safely return
            // a struct copy.
            return this;
        }
        
        public IEntityMapper.Error MapToAbsolute(IEntityMapper mapper, Coherence.Log.Logger logger)
        {
            var err = mapper.MapToAbsoluteEntity(Entity, false, out var absoluteEntity);
            if (err != IEntityMapper.Error.None)
            {
                return err;
            }
            Entity = absoluteEntity;
            return IEntityMapper.Error.None;
        }
        
        public IEntityMapper.Error MapToRelative(IEntityMapper mapper, Coherence.Log.Logger logger)
        {
            var err = mapper.MapToRelativeEntity(Entity, false, out var relativeEntity);
            if (err != IEntityMapper.Error.None)
            {
                return err;
            }
            Entity = relativeEntity;
            return IEntityMapper.Error.None;
        }

        public HashSet<Entity> GetEntityRefs() {
            return default;
        }

        public void NullEntityRefs(Entity entity) {
        }
        
        public _89f0b9a4444bdac43a58673a772b1440_577e2e15601a4ed4a9b5dd9793d3808d(
        Entity entity,
        System.Single addFill
)
        {
            Entity = entity;
            Routing = MessageTarget.All;
            Sender = 0;
            
            this.addFill = addFill; 
        }
        
        public static void Serialize(_89f0b9a4444bdac43a58673a772b1440_577e2e15601a4ed4a9b5dd9793d3808d commandData, IOutProtocolBitStream bitStream)
        {
            bitStream.WriteFloat(commandData.addFill, FloatMeta.NoCompression());
        }
        
        public static _89f0b9a4444bdac43a58673a772b1440_577e2e15601a4ed4a9b5dd9793d3808d Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
        {
            var dataaddFill = bitStream.ReadFloat(FloatMeta.NoCompression());
    
            return new _89f0b9a4444bdac43a58673a772b1440_577e2e15601a4ed4a9b5dd9793d3808d()
            {
                Entity = entity,
                Routing = target,
                addFill = dataaddFill
            };   
        }
    }

}