// Copyright (c) Gecko. All Rights Reserved. Written by Bernie G.

using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;

namespace CowLibCore.Schemas.Entity
{
    public partial class EntityFile : Identifiable
    {
        public EntityFile(Identifier identifier) : base(identifier)
        {
        }

        public static implicit operator Identifier(EntityFile identifiable)
        {
            return identifiable.Identifier;
        }
    }

    public partial class AddAndRemove
    {
        public static implicit operator AddAndRemove(Identifier componentGroup)
        {
            return new AddAndRemove
                {ComponentGroups = new List<string> {componentGroup}};
        }

        public static implicit operator AddAndRemove(List<Identifier> groups)
        {
            return new AddAndRemove {ComponentGroups = groups.Select(x => x.ToString()).ToList()};
        }

        public static implicit operator AddAndRemove(Identifier[] groups)
        {
            return new AddAndRemove { ComponentGroups = groups.Select(x => x.ToString()).ToList() };
        }
    }

    public partial class ComponentGroup : Identifiable
    {
        public ComponentGroup() : base(Identifier.None)
        {
        }

        public ComponentGroup(Identifier identifier) : base(identifier)
        {
        }

        public static implicit operator Identifier(ComponentGroup identifiable)
        {
            return identifiable.Identifier;
        }
    }
}