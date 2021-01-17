// Copyright (c) Gecko. All Rights Reserved. Written by Bernie G.

using System.IO;
using CowLib.Fragments;
using EntitySchema;

namespace CowLib.Builders
{
    public class EntityBuilder : BaseFileFactory<EntityFile>
    {
        public EntityBuilder(BehaviorPack pack, Identifier entityIdentifier, EntityFile entity = null) : base(pack, entityIdentifier.Path,
            entity ?? new EntityFile())
        {
            BuiltObject.MinecraftEntity.Description.Identifier = entityIdentifier;
        }

        public override void SaveFile()
        {
            Utils.SaveFile(ToString(), Path.Combine(Pack.RootPath, "entities"), Name + ".entity.bp.json");
        }

        public MinecraftEntity GetEntity()
        {
            return BuiltObject.MinecraftEntity;
        }

        public ComponentGroup GetComponents()
        {
            return BuiltObject.MinecraftEntity.Components;
        }

        public ComponentGroup CreateComponentGroup(Identifier identifier)
        {
            ComponentGroup components = new ComponentGroup();
            BuiltObject.MinecraftEntity.ComponentGroups.Add(identifier, components);
            return components;
        }

        public EntityBuilder ApplyFragment(EntityFragment fragment, ComponentGroup componentGroup = null)
        {
            fragment.Invoke(this, componentGroup ?? this.GetComponents());
            return this;
        }


        public override string ToString()
        {
            return BuiltObject.ToJson();
        }

        public BehaviorPack Finish()
        {
            Pack.Entities.Add(this.BuiltObject);
            return Pack;
        }
    }
}