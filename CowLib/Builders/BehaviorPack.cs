// Copyright (c) Gecko. All Rights Reserved. Written by Bernie G.

using System.Collections.Generic;
using CowLib.Schemas;
using CowLib.Validators;
using EntitySchema;

namespace CowLib.Builders
{
    public class BehaviorPack
    {
        public BehaviorPack(string packName, string rootPath)
        {
            PackName = packName;
            RootPath = rootPath;
        }

        public ManifestFile Manifest { get; set; }
        public List<EntityFile> Entities { get; set; } = new List<EntityFile>();
        public string PackName { get; }
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