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

    public struct _6d71f34c2fab2e4439db9e8ff84f1018_ae2b95ce393140b6afd00abd4ee3c201 : IEntityCommand
    {
        [StructLayout(LayoutKind.Explicit)]
        public struct Interop
        {
        }

        public static unsafe _6d71f34c2fab2e4439db9e8ff84f1018_ae2b95ce393140b6afd00abd4ee3c201 FromInterop(System.IntPtr data, System.Int32 dataSize) 
        {
            if (dataSize != 0) {
                throw new System.Exception($"Given data size is not equal to the struct size. ({dataSize} != 0) " +
                    "for command with ID 12");
            }

            var orig = new _6d71f34c2fab2e4439db9e8ff84f1018_ae2b95ce393140b6afd00abd4ee3c201();
            var comp = (Interop*)data;
            return orig;
        }

        
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
        
        
        public static void Serialize(_6d71f34c2fab2e4439db9e8ff84f1018_ae2b95ce393140b6afd00abd4ee3c201 commandData, IOutProtocolBitStream bitStream)
        {
        }
        
        public static _6d71f34c2fab2e4439db9e8ff84f1018_ae2b95ce393140b6afd00abd4ee3c201 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
        {
    
            return new _6d71f34c2fab2e4439db9e8ff84f1018_ae2b95ce393140b6afd00abd4ee3c201()
            {
                Entity = entity,
                Routing = target,
            };   
        }
    }

}