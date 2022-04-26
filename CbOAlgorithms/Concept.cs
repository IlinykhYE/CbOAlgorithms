using System.Collections.Generic;
using System.Linq;

namespace CbOAlgorithms
{
    public class Concept
    {
        /// <summary>
        /// Определение Concept
        /// </summary>
        /// <param name="objects"></param>
        /// <param name="attributes"></param>
        public Concept(IEnumerable<string> objects, IEnumerable<string> attributes)
        {
            C = new List<string>();
            C.AddRange(objects);
            D = new List<string>();
            D.AddRange(attributes);
        }

        public List<string> C { get; }
        public List<string> D { get; }


        public override string ToString()
        {
            var str = C.Aggregate("({", (current, obj) => current + "'" + obj + "', ");
            str = str.Trim().Trim(',');
            str += "}, {";
            str = D.Aggregate(str, (current, attr) => current + "'" + attr + "', ");
            str = str.Trim().TrimEnd(',');
            str += "})";

            return str;
        }

        public override int GetHashCode()
        {
            return C.GetHashCode() + D.GetHashCode();
        }

        public bool ObjectEquals(Concept other)
        {
            if (C.Count != other.C.Count) return false;
            var vertObj = C.OrderBy(it => it).ToList();
            var otherVertObj = other.C.OrderBy(it => it).ToList();

            return !vertObj.Where((t, i) => t != otherVertObj[i]).Any();
        }


        public bool AttributeEquals(Concept other)
        {
            if (D.Count != other.D.Count)
            {
                return false;
            }

            var verticleAttribute = D.OrderBy(it => it).ToList();
            var anotherVerticleAttribute = other.D.OrderBy(it => it).ToList();

            return !verticleAttribute.Where((t, i) => t != anotherVerticleAttribute[i]).Any();
        }


        public bool VerticesEquals(Concept other)
        {
            return ObjectEquals(other) && AttributeEquals(other);
        }

        public bool ContainObjects(List<string> objects)
        {
            return objects.All(obj => C.Contains(obj));
        }
    }
}