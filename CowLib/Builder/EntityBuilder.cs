using System;
using Newtonsoft.Json;
using EntitySchema;

namespace CowLib.Factory
{
    public class EntityFactory : BaseFileFactory<EntityFile>
    {
        public EntityFactory(string dragonEntity, EntityFile entity = null) : base(dragonEntity, entity ?? new EntityFile())
        {
            
        }

        public override void saveFile()
        {
        }

        public MinecraftEntity getEntity()
        {
            return builtObject.MinecraftEntity;
        }

        public Components getComponents()
        {
            return builtObject.MinecraftEntity.Components;
        }

        public Components createComponentGroup(string name)
        {
            Components components = new Components();
            builtObject.MinecraftEntity.ComponentGroups.Add(name, components);
            return components;
        }
        
        public override string ToString()
        {
            return Serialize.ToJson(builtObject);
        }
    }
}