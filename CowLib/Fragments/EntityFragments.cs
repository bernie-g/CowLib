// Copyright (c) Gecko. All Rights Reserved. Written by Bernie G.

using CowLib.Builders;
using EntitySchema;

namespace CowLib.Fragments
{
    public static class EntityFragments
    {
        public static readonly EntityFragment EnablePhysics = (builder, components, parameters) => {
            components.MinecraftPhysics = new MinecraftPhysics {HasCollision = true, HasGravity = true};
        };

        public static readonly EntityFragment EnableSummoning = (builder, components, parameters) => {
            builder.BuiltObject.MinecraftEntity.Description.IsSummonable = true;
        };

        public static readonly EntityFragment SetExperimental = (builder, components, parameters) => {
            builder.BuiltObject.MinecraftEntity.Description.IsExperimental = true;
        };

        public static readonly EntityFragment SetFurniture = (builder, components, parameters) => {
            builder.ApplyFragment(EnablePhysics, components);
            builder.ApplyFragment(EnableSummoning, components);
        };
    }

    public delegate void EntityFragment(EntityBuilder builder, ComponentGroup components, params object[] parameters);
}