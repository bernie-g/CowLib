// Copyright (c) Gecko. All Rights Reserved. Written by Bernie G.

using System.Collections.Generic;
using CowLibCore.Builders;
using CowLibCore.Schemas.Entity;

namespace CowLibCore.Fragments
{
    public static class EntityFragments
    {
        public delegate void EntityFragment<in T>(EntityBuilder builder, ComponentGroup components,
            params T[] parameters);

        #region EntityFragments

        public static readonly EntityFragment<object> EnablePhysics = (builder, components, parameters) => {
            components.MinecraftPhysics = new Physics180 {HasCollision = true, HasGravity = true};
        };

        public static readonly EntityFragment<object> EnableSummoning = (builder, components, parameters) => {
            builder.BuiltObject.MinecraftEntity.Description.IsSummonable = true;
        };

        public static readonly EntityFragment<object> DisableKnockBack = (builder, components, parameters) => {
            builder.BuiltObject.MinecraftEntity.Components.MinecraftKnockbackResistance =
                new KnockbackResistance180 {Value = 1};
        };

        public static readonly EntityFragment<object> DisablePushing = (builder, components, parameters) => {
            builder.BuiltObject.MinecraftEntity.Components.MinecraftPushable = new Pushable180
                {IsPushable = false, IsPushableByPiston = true};
        };

        public static readonly EntityFragment<object> SetExperimental = (builder, components, parameters) => {
            builder.BuiltObject.MinecraftEntity.Description.IsExperimental = true;
        };

        public static readonly EntityFragment<object> SetInvincible = (builder, components, parameters) => {
            builder.BuiltObject.MinecraftEntity.Components.MinecraftDamageSensor = new DamageSensor {
                Triggers = new List<DamageTriggerElement> {new DamageTriggerElement {Cause = DamageTriggerCause.All, DealsDamage = false}}
            };
        };

        public static readonly EntityFragment<object> SetNormalEntity = (builder, components, parameters) => {
            builder.ApplyFragment(EnablePhysics, components);
            builder.ApplyFragment(EnableSummoning, components);
        };

        public static readonly EntityFragment<object> SetFakeBlock = (builder, components, parameters) => {
            builder.ApplyFragment(EnableSummoning, components);
            builder.ApplyFragment(DisablePushing, components);
            builder.ApplyFragment(DisableKnockBack, components);
            builder.ApplyFragment(SetInvincible, components);

            ComponentGroup despawnGroup = builder.CreateComponentGroup(new Identifier(builder.Pack.Namespace,
                Utils.GetUniqueName("despawn", builder.GetEntity().ComponentGroups)));
            EventBase entitySpawnedEvent = builder.OnEntitySpawn();
            entitySpawnedEvent.Add = despawnGroup.Identifier; 
        };

        #endregion
    }
}