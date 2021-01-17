// Copyright (c) Gecko. All Rights Reserved. Written by Bernie G.

using System.IO;
using CowLibCore.Fragments;
using CowLibCore.Schemas.Entity;

namespace CowLibCore.Builders
{
    public class EntityBuilder : BaseFileFactory<EntityFile>
    {
        public EntityBuilder(BehaviorPack pack, Identifier entityIdentifier, EntityFile entity = null) : base(pack,
            entityIdentifier.Path,
            entity ?? new EntityFile(entityIdentifier))
        {
            BuiltObject.MinecraftEntity.Description.Identifier = entityIdentifier;
        }

        public override void SaveFile()
        {
            Utils.SaveFile(ToString(), Path.Combine(Pack.RootPath, "entities"), Name + ".entity.bp.json");
        }

        public Entity GetEntity()
        {
            return BuiltObject.MinecraftEntity;
        }

        public ComponentGroup GetComponents()
        {
            return BuiltObject.MinecraftEntity.Components;
        }

        public ComponentGroup CreateComponentGroup(Identifier identifier)
        {
            ComponentGroup components = new ComponentGroup(identifier);
            BuiltObject.MinecraftEntity.ComponentGroups.Add(identifier, components);
            return components;
        }

        public EntityBuilder ApplyFragment<T>(EntityFragments.EntityFragment<T> fragment,
            ComponentGroup componentGroup = null, params T[] parameters)
        {
            fragment.Invoke(this, componentGroup ?? GetComponents(), parameters);
            return this;
        }

        public EventBase CreateEvent(Identifier eventName)
        {
            EventBase eventBase = new EventBase();
            BuiltObject.MinecraftEntity.Events.Add(eventName, eventBase);
            return eventBase;
        }

        /// <summary>
        /// Event called on an entity that is placed in the level.
        /// </summary>
        /// <returns></returns>
        public EventBase OnEntitySpawn()
        {
            EventBase eventBase = new EventBase();
            BuiltObject.MinecraftEntity.Events.Add(new Identifier("minecraft", "entity_spawned"), eventBase);
            return eventBase;
        }

        /// <summary>
        /// Event called on an entity that is spawned through two entities breeding.
        /// </summary>
        /// <returns></returns>
        public EventBase OnEntityBorn()
        {
            EventBase eventBase = new EventBase();
            BuiltObject.MinecraftEntity.Events.Add(new Identifier("minecraft", "entity_born"), eventBase);
            return eventBase;
        }

        /// <summary>
        ///     Event called on an entity that transforms into another entity.
        /// </summary>
        /// <returns></returns>
        public EventBase OnEntityTransformed()
        {
            EventBase eventBase = new EventBase();
            BuiltObject.MinecraftEntity.Events.Add(new Identifier("minecraft", "entity_transformed"), eventBase);
            return eventBase;
        }


        /// <summary>
        ///     Event called on an entity whose fuse is lit and is ready to explode.
        /// </summary>
        public EventBase OnEntityPrime()
        {
            EventBase eventBase = new EventBase();
            BuiltObject.MinecraftEntity.Events.Add(new Identifier("minecraft", "on_prime"), eventBase);
            return eventBase;
        }

        public override string ToString()
        {
            return BuiltObject.ToJson();
        }

        public BehaviorPack Finish()
        {
            Pack.Entities.Add(BuiltObject);
            return Pack;
        }
    }
}