using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EmptyBox.ScriptRuntime
{
    public class DynamicClass : DynamicObject
    {
        protected Dictionary<string, KeyValuePair<TypeInfo, object>> Properties;
        protected Dictionary<ExpressionType, List<KeyValuePair<TypeInfo, Delegate>>> BinaryOperations;
        protected Dictionary<ExpressionType, Delegate> UnaryOperations;
        protected Dictionary<string, List<KeyValuePair<TypeInfo[], Delegate>>> Methods;

        public DynamicClass(DynamicClassBody body)
        {
            Properties = new Dictionary<string, KeyValuePair<TypeInfo, object>>();
            BinaryOperations = new Dictionary<ExpressionType, List<KeyValuePair<TypeInfo, Delegate>>>(body.BinaryOperations);
            UnaryOperations = new Dictionary<ExpressionType, Delegate>(body.UnaryOperations);
            Methods = new Dictionary<string, List<KeyValuePair<TypeInfo[], Delegate>>>(body.Methods);
            foreach (KeyValuePair<string, TypeInfo> pair in body.Properties)
            {
                Properties.Add(pair.Key, new KeyValuePair<TypeInfo, object>(pair.Value, null));
            }
        }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            if (Methods.ContainsKey(binder.Name))
            {
                TypeInfo[] paramtypes = new TypeInfo[args.Length+1];
                paramtypes[0] = typeof(DynamicClass).GetTypeInfo();
                for (int i0 = 0; i0 < args.Length; i0++)
                {
                    paramtypes[i0+1] = args[i0].GetType().GetTypeInfo();
                }
                Delegate operation = Methods[binder.Name].Find(x => x.Key.SequenceEqual(paramtypes)).Value;
                if (operation != null)
                {
                    try
                    {
                        object[] newargs = new object[args.Length + 1];
                        newargs[0] = this;
                        Array.Copy(args, 0, newargs, 1, args.Length);
                        result = operation.DynamicInvoke(newargs);
                        return true;
                    }
                    catch
                    {
                        result = null;
                        return false;
                    }
                }
                else
                {
                    result = null;
                    return false;
                }
            }
            else
            {
                result = null;
                return false;
            }
        }

        public override bool TryBinaryOperation(BinaryOperationBinder binder, object arg, out object result)
        {
            if (BinaryOperations.ContainsKey(binder.Operation))
            {
                Delegate operation = BinaryOperations[binder.Operation].Find(x => x.Key == arg.GetType().GetTypeInfo()).Value;
                if (operation != null)
                {
                    try
                    {
                        result = operation.DynamicInvoke(new object[2] { this, arg });
                        return true;
                    }
                    catch
                    {
                        result = null;
                        return false;
                    }
                }
                else
                {
                    result = null;
                    return false;
                }
            }
            else
            {
                result = null;
                return false;
            }
        }

        public override bool TryUnaryOperation(UnaryOperationBinder binder, out object result)
        {
            if (UnaryOperations.ContainsKey(binder.Operation))
            {
                try
                {
                    result = UnaryOperations[binder.Operation].DynamicInvoke(new object[1] { this });
                    return true;
                }
                catch
                {
                    result = null;
                    return false;
                }
            }
            else
            {
                result = null;
                return false;
            }
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            bool succeed = Properties.TryGetValue(binder.Name, out var handler);
            result = handler.Value;
            return succeed;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            if (Properties.ContainsKey(binder.Name))
            {
                KeyValuePair<TypeInfo, object> handler = Properties[binder.Name];
                if (value.GetType().GetTypeInfo() == handler.Key)
                {
                    Properties[binder.Name] = new KeyValuePair<TypeInfo, object>(handler.Key, value);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
