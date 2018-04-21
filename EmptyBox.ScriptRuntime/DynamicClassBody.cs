using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EmptyBox.ScriptRuntime
{
    public struct DynamicClassBody
    {
        public List<TypeInfo> InheritedInterfaces;
        public Dictionary<ExpressionType, List<KeyValuePair<TypeInfo, Delegate>>> BinaryOperations;
        public Dictionary<ExpressionType, Delegate> UnaryOperations;
        public List<Delegate> StaticMethods;
        public Dictionary<string, List<KeyValuePair<TypeInfo[], Delegate>>> Methods;
        public Dictionary<string, TypeInfo> Properties;
    }
}
