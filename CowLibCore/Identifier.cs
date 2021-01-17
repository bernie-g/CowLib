// Copyright (c) Gecko. All Rights Reserved. Written by Bernie G.

using System.Diagnostics.Tracing;
using CowLibCore.Schemas.Entity;
using CowLibCore.Validators;
using Newtonsoft.Json;

namespace CowLibCore
{
    public class Identifier
    {
        public static readonly Identifier None = new Identifier("", "");

        public Identifier(string identifier)
        {
            IdentifierValidator.COMBINED.Validate(identifier);
            string[] parts = identifier.Split(':');
            Namespace = parts[0];
            Path = parts[1];
        }

        public Identifier(string nameSpace, string path)
        {
            IdentifierValidator.PARTS.Validate(nameSpace);
            IdentifierValidator.PARTS.Validate(path);
            Namespace = nameSpace;
            Path = path;
        }

        public string Namespace { get; }
        public string Path { get; }

        public override string ToString()
        {
            return $"{Namespace}:{Path}";
        }

        public static implicit operator string(Identifier i) => i.ToString();
        //public static implicit operator Identifier(string s) => new Identifier(s);
    }

    public class Identifiable
    {
        [JsonIgnore]
        public Identifier Identifier { get; set; }
        
        public Identifiable(Identifier identifier)
        {
            this.Identifier = identifier;
        }

        public static implicit operator Identifier(Identifiable identifiable)
        {
            return identifiable.Identifier;
        }
    }
}