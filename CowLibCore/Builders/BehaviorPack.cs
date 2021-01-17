// Copyright (c) Gecko. All Rights Reserved. Written by Bernie G.

using System.Collections.Generic;
using CowLibCore.Schemas;
using CowLibCore.Schemas.Entity;
using CowLibCore.Schemas.Manifest;

namespace CowLibCore.Builders
{
    public class BehaviorPack
    {
        public BehaviorPack(string name, string @namespace, string rootPath)
        {
            Name = name;
            Namespace = @namespace;
            RootPath = rootPath;
        }

        public ManifestFile Manifest { get; set; }
        public List<EntityFile> Entities { get; set; } = new List<EntityFile>();
        public string Name { get; }
        public string Namespace { get; }
        public string RootPath { get; }


        public ManifestBuilder CreateManifest()
        {
            return new ManifestBuilder(this);
        }

        public EntityBuilder CreateEntity(Identifier identifier)
        {
            return new EntityBuilder(this, identifier);
        }


        /// <summary>
        ///     Saves the entire resource pack and all its files/components.
        /// </summary>
        public void Save()
        {
            new ManifestBuilder(this, Manifest).SaveFile();
            foreach (EntityFile entity in Entities) {
                new EntityBuilder(this, new Identifier(entity.MinecraftEntity.Description.Identifier), entity).SaveFile();
            }
        }
    }
}