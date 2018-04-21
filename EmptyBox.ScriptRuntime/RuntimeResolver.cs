using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EmptyBox.ScriptRuntime
{
    public class RuntimeResolver
    {
        List<TypeInfo> DefinedTypes;

        public RuntimeResolver(params Assembly[] assemblies)
        {
            DefinedTypes = new List<TypeInfo>();
            foreach(Assembly asm in assemblies)
            {
                DefinedTypes.AddRange(asm.DefinedTypes);
            }
        }

        public List<TypeInfo> FindType(string name)
        {
            return DefinedTypes.FindAll(x => x.Name == name);
        }
    }
}
