using System;
using System.Collections.Generic;

namespace Mapzen
{
    public class SceneGroup
    {
        [Flags]
        public enum Type
        {
            None = 0,
            Tile = 1 << 0,
            Filter = 1 << 1,
            Layer = 1 << 2,
            Feature = 1 << 3,
            All = ~None,
        }

        public List<SceneGroup> childs;
        public MeshData meshData;
        public string name;
        public Type type;

        public SceneGroup(Type type, string name)
        {
            this.childs = new List<SceneGroup>();
            this.type = type;
            this.name = name;
            this.meshData = new MeshData();
        }

        public static bool Test(Type type, Type options)
        {
            return ((int)type & (int)options) == (int)type;
        }

        public static bool IsLeaf(Type type, Type options)
        {
            return ((int)type ^ (int)options) < (int)type;
        }
    }
}
