// Copyright (c) Gecko. All Rights Reserved. Written by Bernie G.

using System;
using System.IO;
using System.Linq;
using CowLib.Schemas;

namespace CowLib.Builders
{
    public class ManifestBuilder : BaseFileFactory<ManifestFile>
    {
        public ManifestBuilder(BehaviorPack pack, ManifestFile file = null) : base(pack, "manifest",
            file ?? new ManifestFile())
        {
            BuiltObject.Header.Name = pack.PackName;
        }

        public override void SaveFile()
        {
            Utils.SaveFile(ToString(), Path.Combine(Pack.RootPath), Name + ".json");
        }


        public override string ToString()
        {
            return BuiltObject.ToJson();
        }

        /// <summary>
        ///     This is the version of your Pack in the format [majorVersion, minorVersion, revision].
        ///     The version number is used when importing a Pack that has been imported before. The new
        ///     Pack will replace the old one if the version is higher, and ignored if it's the same or
        ///     lower
        /// </summary>
        public ManifestBuilder Version(int[] version)
        {
            BuiltObject.Header.Version = version;
            return this;
        }

        /// <summary>
        ///     This is the version of the base game your world template requires, specified as
        ///     [majorVersion, minorVersion, revision].
        ///     We use this to determine what version of the base game resource and behavior packs to
        ///     apply when your content is used.
        /// </summary>
        public ManifestBuilder BaseGameVersion(int[] version)
        {
            BuiltObject.Header.BaseGameVersion = version;
            return this;
        }

        /// <summary>
        ///     This is the minimum version of the game that this Pack was written for. This helps the
        ///     game identify whether any backwards compatibility is needed for your Pack. You should
        ///     always use the highest version currently available when creating packs
        /// </summary>
        public ManifestBuilder MinEngineVersion(int[] version)
        {
            BuiltObject.Header.MinEngineVersion = version;
            return this;
        }


        /// <summary>
        ///     This is a special type of identifier that uniquely identifies this Pack from any other
        ///     Pack. UUIDs are written in the format xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx where each x
        ///     is a hexadecimal value (0-9 or a-f). We recommend using an online service to generate
        ///     this and guarantee their uniqueness (just bing UUID Generator to find some)
        /// </summary>
        public ManifestBuilder Uuid(Guid uuid)
        {
            BuiltObject.Header.Uuid = uuid;
            return this;
        }

        /// <summary>
        ///     This is a short description of the Pack. It will appear in the game below the Name of the
        ///     Pack. We recommend keeping it to 1-2 lines.
        /// </summary>
        public ManifestBuilder Description(string description)
        {
            BuiltObject.Header.Description = description;
            return this;
        }

        /// <summary>
        ///     This section describes the packs that this Pack depends on in order to work. Any packs
        ///     defined here will be automatically added to the world when this one is added if they are
        ///     present, or an error will be shown if they aren't.
        /// </summary>
        public ManifestBuilder AddDependency(Guid uuid, double[] dependencyVersion)
        {
            BuiltObject.Dependencies.Add(new Dependency {
                Uuid = uuid,
                Version = dependencyVersion
            });
            return this;
        }

        public BehaviorPack Finish()
        {
            Pack.Manifest = BuiltObject;
            return Pack;
        }

        /// <summary>
        ///     Name of the author(s) of the Pack
        /// </summary>
        public ManifestBuilder Authors(params string[] authors)
        {
            BuiltObject.Metadata.Authors.AddRange(authors.ToArray());
            return this;
        }

        /// <summary>
        /// The license of the Pack
        /// </summary>
        public ManifestBuilder License(string license)
        {
            BuiltObject.Metadata.License = license;
            return this;
        }
    }
}