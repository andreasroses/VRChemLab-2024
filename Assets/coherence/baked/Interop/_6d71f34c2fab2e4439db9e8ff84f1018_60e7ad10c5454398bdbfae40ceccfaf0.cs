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

    public struct _6d71f34c2fab2e4439db9e8ff84f1018_60e7ad10c5454398bdbfae40ceccfaf0 : IEntityCommand
    {
        [StructLayout(LayoutKind.Explicit)]
        public struct Interop
        {
            [FieldOffset(0)]
            public System.Int32 alpha;
        }

        public static unsafe _6d71f34c2fab2e4439db9e8ff84f1018_60e7ad10c5454398bdbfae40ceccfaf0 FromInterop(System.IntPtr data, System.Int32 dataSize) 
        {
            if (dataSize != 4) {
                throw new System.Exception($"Given data size is not equal to the struct size. ({dataSize} != 4) " +
                    "for command with ID 9");
            }

            var orig = new _6d71f34c2fab2e4439db9e8ff84f1018_60e7ad10c5454398bdbfae40ceccfaf0();
            var comp = (Interop*)data;
            orig.alpha = comp->alpha;
            return orig;
        }

        public System.Int32 alpha;
        
        public Entity Entity { get; set; }
        public MessageTarget Routing { get; set; }
        public uint Sender { get; set; }
        public uint GetComponentType() => 9;
        
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
        
        public _6d71f34c2fab2e4439db9e8ff84f1018_60e7ad10c5454398bdbfae40ceccfaf0(
        Entity entity,
        System.Int32 alpha
)
        {
            Entity = entity;
            Routing = MessageTarget.All;
            Sender = 0;
            
            this.alpha = alpha; 
        }
        
        public static void Serialize(_6d71f34c2fab2e4439db9e8ff84f1018_60e7ad10c5454398bdbfae40ceccfaf0 commandData, IOutProtocolBitStream bitStream)
        {
            bitStream.WriteIntegerRange(commandData.alpha, 32, -2147483648);
        }
        
        public static _6d71f34c2fab2e4439db9e8ff84f1018_60e7ad10c5454398bdbfae40ceccfaf0 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
        {
            var dataalpha = bitStream.ReadIntegerRange(32, -2147483648);
    
            return new _6d71f34c2fab2e4439db9e8ff84f1018_60e7ad10c5454398bdbfae40ceccfaf0()
            {
                Entity = entity,
                Routing = target,
                alpha = dataalpha
            };   
        }
    }

}