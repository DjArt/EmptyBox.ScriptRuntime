using EmptyBox.ScriptRuntime.Extensions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace EmptyBox.ScriptRuntime.Resolving
{
    public static class OperatorCache
    {
        public static Delegate GetOperator(Type right, Type @return, UnaryOperatorType op)
        {
            switch(op)
            {
                case UnaryOperatorType.Cast:
                    return GetCast(right, @return);
                case UnaryOperatorType.Negate:
                    return GetNegate(right, @return);
                case UnaryOperatorType.Not:
                    return GetNot(right, @return);
                default:
                    throw new NotImplementedException();
            }
        }

        public static Delegate GetOperator(Type left, Type right, Type @return, BinaryOperatorType op)
        {
            switch(op)
            {
                case BinaryOperatorType.Addition:
                    return GetAddition(left, right, @return);
                case BinaryOperatorType.And:
                    return GetAnd(left, right, @return);
                case BinaryOperatorType.Division:
                    return GetDivision(left, right, @return);
                case BinaryOperatorType.Equality:
                    return GetEquality(left, right, @return);
                case BinaryOperatorType.Exponentiation:
                    return GetExponentiation(left, right, @return);
                case BinaryOperatorType.GreaterThat:
                    return GetGreaterThan(left, right, @return);
                case BinaryOperatorType.GreaterThenOrEqual:
                    return GetGreaterThanOrEqual(left, right, @return);
                case BinaryOperatorType.Inequality:
                    return GetInequality(left, right, @return);
                case BinaryOperatorType.LeftShift:
                    return GetLeftShift(left, right, @return);
                case BinaryOperatorType.LessThan:
                    return GetLessThan(left, right, @return);
                case BinaryOperatorType.LessThanOrEqual:
                    return GetLessThanOrEqual(left, right, @return);
                case BinaryOperatorType.Modulo:
                    return GetModulo(left, right, @return);
                case BinaryOperatorType.Multiply:
                    return GetMultiply(left, right, @return);
                case BinaryOperatorType.Or:
                    return GetOr(left, right, @return);
                case BinaryOperatorType.RightShift:
                    return GetRightShift(left, right, @return);
                case BinaryOperatorType.Subtraction:
                    return GetSubtraction(left, right, @return);
                case BinaryOperatorType.XOr:
                    return GetXOr(left, right, @return);
                default:
                    throw new NotImplementedException();
            }
        }

        public static Delegate GetAddition(Type left, Type right, Type @return)
        {
            return typeof(OperatorCache<,,>).MakeGenericType(left, right, @return).GetProperty(OperatorCache<object, object, object>.M_ADDITION).GetMethod.Invoke(null, null) as Delegate;
        }

        public static Delegate GetAnd(Type left, Type right, Type @return)
        {
            return typeof(OperatorCache<,,>).MakeGenericType(left, right, @return).GetProperty(OperatorCache<object, object, object>.M_AND).GetMethod.Invoke(null, null) as Delegate;
        }

        public static Delegate GetDivision(Type left, Type right, Type @return)
        {
            return typeof(OperatorCache<,,>).MakeGenericType(left, right, @return).GetProperty(OperatorCache<object, object, object>.M_DIVISION).GetMethod.Invoke(null, null) as Delegate;
        }

        public static Delegate GetEquality(Type left, Type right, Type @return)
        {
            return typeof(OperatorCache<,,>).MakeGenericType(left, right, @return).GetProperty(OperatorCache<object, object, object>.M_EQUALITY).GetMethod.Invoke(null, null) as Delegate;
        }

        public static Delegate GetExponentiation(Type left, Type right, Type @return)
        {
            return typeof(OperatorCache<,,>).MakeGenericType(left, right, @return).GetProperty(OperatorCache<object, object, object>.M_EXPONENTIATION).GetMethod.Invoke(null, null) as Delegate;
        }

        public static Delegate GetGreaterThan(Type left, Type right, Type @return)
        {
            return typeof(OperatorCache<,,>).MakeGenericType(left, right, @return).GetProperty(OperatorCache<object, object, object>.M_GREATERTHAN).GetMethod.Invoke(null, null) as Delegate;
        }

        public static Delegate GetGreaterThanOrEqual(Type left, Type right, Type @return)
        {
            return typeof(OperatorCache<,,>).MakeGenericType(left, right, @return).GetProperty(OperatorCache<object, object, object>.M_GREATERTHANOREQUAL).GetMethod.Invoke(null, null) as Delegate;
        }

        public static Delegate GetInequality(Type left, Type right, Type @return)
        {
            return typeof(OperatorCache<,,>).MakeGenericType(left, right, @return).GetProperty(OperatorCache<object, object, object>.M_INEQUALITY).GetMethod.Invoke(null, null) as Delegate;
        }

        public static Delegate GetLeftShift(Type left, Type right, Type @return)
        {
            return typeof(OperatorCache<,,>).MakeGenericType(left, right, @return).GetProperty(OperatorCache<object, object, object>.M_LEFTSHIFT).GetMethod.Invoke(null, null) as Delegate;
        }

        public static Delegate GetLessThan(Type left, Type right, Type @return)
        {
            return typeof(OperatorCache<,,>).MakeGenericType(left, right, @return).GetProperty(OperatorCache<object, object, object>.M_LESSTHAN).GetMethod.Invoke(null, null) as Delegate;
        }

        public static Delegate GetLessThanOrEqual(Type left, Type right, Type @return)
        {
            return typeof(OperatorCache<,,>).MakeGenericType(left, right, @return).GetProperty(OperatorCache<object, object, object>.M_LESSTHANOREQUAL).GetMethod.Invoke(null, null) as Delegate;
        }

        public static Delegate GetModulo(Type left, Type right, Type @return)
        {
            return typeof(OperatorCache<,,>).MakeGenericType(left, right, @return).GetProperty(OperatorCache<object, object, object>.M_MODULO).GetMethod.Invoke(null, null) as Delegate;
        }

        public static Delegate GetMultiply(Type left, Type right, Type @return)
        {
            return typeof(OperatorCache<,,>).MakeGenericType(left, right, @return).GetProperty(OperatorCache<object, object, object>.M_MULTIPLY).GetMethod.Invoke(null, null) as Delegate;
        }

        public static Delegate GetOr(Type left, Type right, Type @return)
        {
            return typeof(OperatorCache<,,>).MakeGenericType(left, right, @return).GetProperty(OperatorCache<object, object, object>.M_OR).GetMethod.Invoke(null, null) as Delegate;
        }

        public static Delegate GetRightShift(Type left, Type right, Type @return)
        {
            return typeof(OperatorCache<,,>).MakeGenericType(left, right, @return).GetProperty(OperatorCache<object, object, object>.M_RIGHTSHIFT).GetMethod.Invoke(null, null) as Delegate;
        }

        public static Delegate GetSubtraction(Type left, Type right, Type @return)
        {
            return typeof(OperatorCache<,,>).MakeGenericType(left, right, @return).GetProperty(OperatorCache<object, object, object>.M_SUBTRACTION).GetMethod.Invoke(null, null) as Delegate;
        }

        public static Delegate GetXOr(Type left, Type right, Type @return)
        {
            return typeof(OperatorCache<,,>).MakeGenericType(left, right, @return).GetProperty(OperatorCache<object, object, object>.M_XOR).GetMethod.Invoke(null, null) as Delegate;
        }

        public static Delegate GetCast(Type right, Type @return)
        {
            return typeof(OperatorCache<,>).MakeGenericType(right, @return).GetProperty(OperatorCache<object, object>.M_CAST).GetMethod.Invoke(null, null) as Delegate;
        }

        public static Delegate GetCos(Type right, Type @return)
        {
            return typeof(OperatorCache<,>).MakeGenericType(right, @return).GetProperty(OperatorCache<object, object>.M_COS).GetMethod.Invoke(null, null) as Delegate;
        }

        public static Delegate GetLogarithm(Type right, Type @return)
        {
            return typeof(OperatorCache<,>).MakeGenericType(right, @return).GetProperty(OperatorCache<object, object>.M_LOGARITHM).GetMethod.Invoke(null, null) as Delegate;
        }

        public static Delegate GetLogarithm10(Type right, Type @return)
        {
            return typeof(OperatorCache<,>).MakeGenericType(right, @return).GetProperty(OperatorCache<object, object>.M_LOGARITHM10).GetMethod.Invoke(null, null) as Delegate;
        }

        public static Delegate GetNegate(Type right, Type @return)
        {
            return typeof(OperatorCache<,>).MakeGenericType(right, @return).GetProperty(OperatorCache<object, object>.M_NEGATE).GetMethod.Invoke(null, null) as Delegate;
        }

        public static Delegate GetNot(Type right, Type @return)
        {
            return typeof(OperatorCache<,>).MakeGenericType(right, @return).GetProperty(OperatorCache<object, object>.M_NOT).GetMethod.Invoke(null, null) as Delegate;
        }

        public static Delegate GetSin(Type right, Type @return)
        {
            return typeof(OperatorCache<,>).MakeGenericType(right, @return).GetProperty(OperatorCache<object, object>.M_SIN).GetMethod.Invoke(null, null) as Delegate;
        }

        public static Type GetReturnType(Type right, UnaryOperatorType op)
        {
            return typeof(OperatorCache<>).MakeGenericType(right).GetMethod(OperatorCache<object>.M_GETRESULTTYPE).Invoke(null, new object[] { op }) as Type;
        }

        public static Type GetReturnType(Type left, Type right, BinaryOperatorType op)
        {
            return typeof(OperatorCache<,>).MakeGenericType(left, right).GetMethod(OperatorCache<object>.M_GETRESULTTYPE).Invoke(null, new object[] { op }) as Type;
        }
    }

    public static class OperatorCache<T1>
    {
        internal const string M_GETRESULTTYPE = nameof(GetResultType);

        private static readonly Dictionary<UnaryOperatorType, Type> _ResultTypeCache = new Dictionary<UnaryOperatorType, Type>();
        
        public static Type GetResultType(UnaryOperatorType op)
        {
            if (!_ResultTypeCache.ContainsKey(op))
            {
                try
                {
                    ParameterExpression par0 = Expression.Parameter(typeof(T1));
                    switch (op)
                    {
                        case UnaryOperatorType.Negate:
                            _ResultTypeCache[op] = Expression.Lambda<Func<T1, object>>(Expression.Convert(Expression.Negate(par0), typeof(object)), par0).Compile().Invoke(default).GetType();
                            break;
                        case UnaryOperatorType.Not:
                            _ResultTypeCache[op] = Expression.Lambda<Func<T1, object>>(Expression.Convert(Expression.Not(par0), typeof(object)), par0).Compile().Invoke(default).GetType();
                            break;
                        default:
                            _ResultTypeCache[op] = null;
                            break;
                    }
                }
                catch
                {
                    _ResultTypeCache[op] = null;
                }
            }
            return _ResultTypeCache[op];
        }
    }

    public static class OperatorCache<T1, T2>
    {
        internal const string M_GETRESULTTYPE = nameof(GetResultType);
        internal const string M_CAST = nameof(Cast);
        internal const string M_COS = nameof(Cos);
        internal const string M_LOGARITHM = nameof(Logarithm);
        internal const string M_LOGARITHM10 = nameof(Logarithm10);
        internal const string M_NEGATE = nameof(Negate);
        internal const string M_NOT = nameof(Not);
        internal const string M_SIN = nameof(Sin);

        private static readonly Dictionary<BinaryOperatorType, Type> _ResultTypeCache = new Dictionary<BinaryOperatorType, Type>();
        private static Func<T1, T2> _Negate;
        private static Func<T1, T2> _Not;
        private static Func<T1, T2> _Logarithm;
        private static Func<T1, T2> _Logarithm10;
        private static Func<T1, T2> _Cast;
        private static Func<T1, T2> _Sin;
        private static Func<T1, T2> _Cos;
        private static bool _Init_Negate = false;
        private static bool _Init_Not = false;
        private static bool _Init_Logarithm = false;
        private static bool _Init_Logarithm10 = false;
        private static bool _Init_Cast = false;
        private static bool _Init_Sin = false;
        private static bool _Init_Cos = false;

        public static Type GetResultType(BinaryOperatorType op)
        {
            if (!_ResultTypeCache.ContainsKey(op))
            {
                try
                {
                    ParameterExpression par0 = Expression.Parameter(typeof(T1));
                    ParameterExpression par1 = Expression.Parameter(typeof(T2));
                    BinaryExpression exp0 = null;
                    switch (op)
                    {
                        case BinaryOperatorType.Addition:
                            exp0 = Expression.Add(par0, par1);
                            break;
                        case BinaryOperatorType.And:
                            exp0 = Expression.And(par0, par1);
                            break;
                        case BinaryOperatorType.Division:
                            exp0 = Expression.Divide(par0, par1);
                            break;
                        case BinaryOperatorType.Equality:
                            exp0 = Expression.Equal(par0, par1);
                            break;
                        case BinaryOperatorType.Exponentiation:
                            exp0 = Expression.Power(par0, par1);
                            break;
                        case BinaryOperatorType.GreaterThat:
                            exp0 = Expression.GreaterThan(par0, par1);
                            break;
                        case BinaryOperatorType.GreaterThenOrEqual:
                            exp0 = Expression.GreaterThanOrEqual(par0, par1);
                            break;
                        case BinaryOperatorType.Inequality:
                            exp0 = Expression.NotEqual(par0, par1);
                            break;
                        case BinaryOperatorType.LeftShift:
                            exp0 = Expression.LeftShift(par0, par1);
                            break;
                        case BinaryOperatorType.LessThan:
                            exp0 = Expression.LessThan(par0, par1);
                            break;
                        case BinaryOperatorType.LessThanOrEqual:
                            exp0 = Expression.LessThanOrEqual(par0, par1);
                            break;
                        case BinaryOperatorType.Modulo:
                            exp0 = Expression.Modulo(par0, par1);
                            break;
                        case BinaryOperatorType.Multiply:
                            exp0 = Expression.Multiply(par0, par1);
                            break;
                        case BinaryOperatorType.Or:
                            exp0 = Expression.Or(par0, par1);
                            break;
                        case BinaryOperatorType.RightShift:
                            exp0 = Expression.RightShift(par0, par1);
                            break;
                        case BinaryOperatorType.Subtraction:
                            exp0 = Expression.Subtract(par0, par1);
                            break;
                        case BinaryOperatorType.XOr:
                            exp0 = Expression.ExclusiveOr(par0, par1);
                            break;
                        default:
                            _ResultTypeCache[op] = null;
                            break;
                    }
                    if (exp0 != null)
                    {
                        _ResultTypeCache[op] = Expression.Lambda<Func<T1, T2, object>>(Expression.Convert(exp0, typeof(object)), par0, par1).Compile().Invoke(default, default).GetType();
                    }
                }
                catch
                {
                    _ResultTypeCache[op] = null;
                }
            }
            return _ResultTypeCache[op];
        }
        
        public static Func<T1, T2> Negate
        {
            get
            {
                if (!_Init_Negate)
                {
                    try
                    {
                        var par0 = Expression.Parameter(typeof(T1));
                        _Negate =  Expression.Lambda<Func<T1, T2>>(Expression.Negate(par0), par0).Compile();
                    }
                    catch
                    {
                        _Negate = null;
                    }
                    _Init_Negate = true;
                }
                return _Negate;
            }
        }
        
        public static Func<T1, T2> Not
        {
            get
            {
                if (!_Init_Not)
                {
                    try
                    {
                        var par0 = Expression.Parameter(typeof(T1));
                        _Not =  Expression.Lambda<Func<T1, T2>>(Expression.Not(par0), par0).Compile();
                    }
                    catch
                    {
                        _Not = null;
                    }
                    _Init_Not = true;
                }
                return _Not;
            }
        }
        
        public static Func<T1, T2> Logarithm
        {
            get
            {
                if (!_Init_Logarithm)
                {
                    Type t1 = typeof(T1);
                    if (t1.IsNumericType())
                    {
                        _Logarithm = x => OperatorCache<double, T2>.Cast(Math.Log(OperatorCache<T1, double>.Cast(x)));
                    }
                    else
                    {
                        try
                        {
                            MethodInfo method = t1.GetTypeInfo().GetDeclaredMethod("Log");
                            if (method != null)
                            {
                                _Logarithm = x => OperatorCache<object, T2>.Cast(method.Invoke(null, new[] { OperatorCache<T1, object>.Cast(x) }));
                            }
                            else
                            {
                                _Logarithm = x => OperatorCache<double, T2>.Cast(Math.Sin(OperatorCache<T1, double>.Cast(x)));
                            }
                        }
                        catch
                        {
                            _Logarithm = null;
                        }
                    }
                }
                return _Logarithm;
            }
        }
        
        public static Func<T1, T2> Logarithm10
        {
            get
            {
                if (!_Init_Logarithm10)
                {
                    Type t1 = typeof(T1);
                    if (t1.IsNumericType())
                    {
                        _Logarithm10 = x => OperatorCache<double, T2>.Cast(Math.Log10(OperatorCache<T1, double>.Cast(x)));
                    }
                    else
                    {
                        try
                        {
                            MethodInfo method = t1.GetTypeInfo().GetDeclaredMethod("Log10");
                            if (method != null)
                            {
                                _Logarithm10 = x => OperatorCache<object, T2>.Cast(method.Invoke(null, new[] { OperatorCache<T1, object>.Cast(x) }));
                            }
                            else
                            {
                                _Logarithm10 = x => OperatorCache<double, T2>.Cast(Math.Sin(OperatorCache<T1, double>.Cast(x)));
                            }
                        }
                        catch
                        {
                            _Logarithm10 = null;
                        }
                    }
                }
                return _Logarithm10;
            }
        }
        
        public static Func<T1, T2> Cast
        {
            get
            {
                if (!_Init_Cast)
                {
                    try
                    {
                        var par0 = Expression.Parameter(typeof(T1));
                        _Cast = Expression.Lambda<Func<T1, T2>>(Expression.Convert(par0, typeof(T2)), par0).Compile();
                    }
                    catch
                    {
                        _Cast = null;
                    }
                    _Init_Cast = true;
                }
                return _Cast;
            }
        }
        
        public static Func<T1, T2> Sin
        {
            get
            {
                if (!_Init_Sin)
                {
                    Type t1 = typeof(T1);
                    if (t1.IsNumericType())
                    {
                        _Sin = x => OperatorCache<double, T2>.Cast(Math.Sin(OperatorCache<T1, double>.Cast(x)));
                    }
                    else
                    {
                        try
                        {
                            MethodInfo method = t1.GetTypeInfo().GetDeclaredMethod("Sin");
                            if (method != null)
                            {
                                _Sin = x => OperatorCache<object, T2>.Cast(method.Invoke(null, new[] { OperatorCache<T1, object>.Cast(x) }));
                            }
                            else
                            {
                                _Sin = x => OperatorCache<double, T2>.Cast(Math.Sin(OperatorCache<T1, double>.Cast(x)));
                            }
                        }
                        catch
                        {
                            _Sin = null;
                        }
                    }
                }
                return _Sin;
            }
        }
        
        public static Func<T1, T2> Cos
        {
            get
            {
                if (!_Init_Cos)
                {
                    Type t1 = typeof(T1);
                    if (t1.IsNumericType())
                    {
                        _Cos = x => OperatorCache<double, T2>.Cast(Math.Cos(OperatorCache<T1, double>.Cast(x)));
                    }
                    else
                    {
                        try
                        {
                            MethodInfo method = t1.GetTypeInfo().GetDeclaredMethod("Cos");
                            if (method != null)
                            {
                                _Cos = x => OperatorCache<object, T2>.Cast(method.Invoke(null, new[] { OperatorCache<T1, object>.Cast(x) }));
                            }
                            else
                            {
                                _Cos = x => OperatorCache<double, T2>.Cast(Math.Cos(OperatorCache<T1, double>.Cast(x)));
                            }
                        }
                        catch
                        {
                            _Cos = null;
                        }
                    }
                }
                return _Cos;
            }
        }
    }

    public static class OperatorCache<T1, T2, T3>
    {
        internal const string M_ADDITION = nameof(Addition);
        internal const string M_AND = nameof(And);
        internal const string M_OR = nameof(Or);
        internal const string M_XOR = nameof(XOr);
        internal const string M_MODULO = nameof(Modulo);
        internal const string M_MULTIPLY = nameof(Multiply);
        internal const string M_SUBTRACTION = nameof(Subtraction);
        internal const string M_DIVISION = nameof(Division);
        internal const string M_EQUALITY = nameof(Equality);
        internal const string M_INEQUALITY = nameof(Inequality);
        internal const string M_GREATERTHAN = nameof(GreaterThan);
        internal const string M_GREATERTHANOREQUAL = nameof(GreaterThanOrEqual);
        internal const string M_LESSTHAN = nameof(LessThan);
        internal const string M_LESSTHANOREQUAL = nameof(LessThanOrEqual);
        internal const string M_EXPONENTIATION = nameof(Exponentiation);
        internal const string M_LEFTSHIFT = nameof(LeftShift);
        internal const string M_RIGHTSHIFT = nameof(RightShift);

        private static Func<T1, T2, T3> _Addition;
        private static Func<T1, T2, T3> _And;
        private static Func<T1, T2, T3> _Or;
        private static Func<T1, T2, T3> _XOr;
        private static Func<T1, T2, T3> _Modulo;
        private static Func<T1, T2, T3> _Multiply;
        private static Func<T1, T2, T3> _Subtraction;
        private static Func<T1, T2, T3> _Division;
        private static Func<T1, T2, T3> _Equality;
        private static Func<T1, T2, T3> _Inequality;
        private static Func<T1, T2, T3> _GreaterThan;
        private static Func<T1, T2, T3> _GreaterThanOrEqual;
        private static Func<T1, T2, T3> _LessThan;
        private static Func<T1, T2, T3> _LessThanOrEqual;
        private static Func<T1, T2, T3> _Exponentiation;
        private static Func<T1, T2, T3> _LeftShift;
        private static Func<T1, T2, T3> _RightShift;
        private static bool _Init_Addition = false;
        private static bool _Init_And = false;
        private static bool _Init_Or = false;
        private static bool _Init_XOr = false;
        private static bool _Init_Modulo = false;
        private static bool _Init_Multiply = false;
        private static bool _Init_Subtraction = false;
        private static bool _Init_Division = false;
        private static bool _Init_Equality = false;
        private static bool _Init_Inequality = false;
        private static bool _Init_GreaterThan = false;
        private static bool _Init_GreaterThanOrEqual = false;
        private static bool _Init_LessThan = false;
        private static bool _Init_LessThanOrEqual = false;
        private static bool _Init_Exponentiation = false;
        private static bool _Init_LeftShift = false;
        private static bool _Init_RightShift = false;
        
        public static Func<T1, T2, T3> Addition
        {
            get
            {
                if (!_Init_Addition)
                {
                    try
                    {
                        var par0 = Expression.Parameter(typeof(T1));
                        var par1 = Expression.Parameter(typeof(T2));
                        Expression t = Expression.MakeBinary(ExpressionType.Add, par0, par1);
                        _Addition = Expression.Lambda<Func<T1, T2, T3>>(t, par0, par1).Compile();
                    }
                    catch
                    {
                        _Addition = null;
                    }
                    _Init_Addition = true;
                }
                return _Addition;
            }
        }

        public static Func<T1, T2, T3> And
        {
            get
            {
                if (!_Init_And)
                {
                    try
                    {
                        var par0 = Expression.Parameter(typeof(T1));
                        var par1 = Expression.Parameter(typeof(T2));
                        Expression t = Expression.MakeBinary(ExpressionType.And, par0, par1);
                        _And = Expression.Lambda<Func<T1, T2, T3>>(t, par0, par1).Compile();
                    }
                    catch
                    {
                        _And = null;
                    }
                    _Init_And = true;
                }
                return _And;
            }
        }
        
        public static Func<T1, T2, T3> Or
        {
            get
            {
                if (!_Init_Or)
                {
                    try
                    {
                        var par0 = Expression.Parameter(typeof(T1));
                        var par1 = Expression.Parameter(typeof(T2));
                        Expression t = Expression.MakeBinary(ExpressionType.Or, par0, par1);
                        _Or = Expression.Lambda<Func<T1, T2, T3>>(t, par0, par1).Compile();
                    }
                    catch
                    {
                        _Or = null;
                    }
                    _Init_Or = true;
                }
                return _Or;
            }
        }
        
        public static Func<T1, T2, T3> XOr
        {
            get
            {
                if (!_Init_XOr)
                {
                    try
                    {
                        var par0 = Expression.Parameter(typeof(T1));
                        var par1 = Expression.Parameter(typeof(T2));
                        Expression t = Expression.MakeBinary(ExpressionType.ExclusiveOr, par0, par1);
                        _XOr = Expression.Lambda<Func<T1, T2, T3>>(t, par0, par1).Compile();
                    }
                    catch
                    {
                        _XOr = null;
                    }
                    _Init_XOr = true;
                }
                return _XOr;
            }
        }
        
        public static Func<T1, T2, T3> Modulo
        {
            get
            {
                if (!_Init_Modulo)
                {
                    try
                    {
                        var par0 = Expression.Parameter(typeof(T1));
                        var par1 = Expression.Parameter(typeof(T2));
                        Expression t = Expression.MakeBinary(ExpressionType.Modulo, par0, par1);
                        _Modulo = Expression.Lambda<Func<T1, T2, T3>>(t, par0, par1).Compile();
                    }
                    catch
                    {
                        _Modulo = null;
                    }
                    _Init_Modulo = true;
                }
                return _Modulo;
            }
        }
        
        public static Func<T1, T2, T3> Multiply
        {
            get
            {
                if (!_Init_Multiply)
                {
                    try
                    {
                        var par0 = Expression.Parameter(typeof(T1));
                        var par1 = Expression.Parameter(typeof(T2));
                        Expression t = Expression.MakeBinary(ExpressionType.Multiply, par0, par1);
                        _Multiply = Expression.Lambda<Func<T1, T2, T3>>(t, par0, par1).Compile();
                    }
                    catch
                    {
                        _Multiply = null;
                    }
                    _Init_Multiply = true;
                }
                return _Multiply;
            }
        }
        
        public static Func<T1, T2, T3> Subtraction
        {
            get
            {
                if (!_Init_Subtraction)
                {
                    try
                    {
                        var par0 = Expression.Parameter(typeof(T1));
                        var par1 = Expression.Parameter(typeof(T2));
                        Expression t = Expression.MakeBinary(ExpressionType.Subtract, par0, par1);
                        _Subtraction = Expression.Lambda<Func<T1, T2, T3>>(t, par0, par1).Compile();
                    }
                    catch
                    {
                        _Subtraction = null;
                    }
                    _Init_Subtraction = true;
                }
                return _Subtraction;
            }
        }
        
        public static Func<T1, T2, T3> Division
        {
            get
            {
                if (!_Init_Division)
                {
                    try
                    {
                        var par0 = Expression.Parameter(typeof(T1));
                        var par1 = Expression.Parameter(typeof(T2));
                        Expression t = Expression.MakeBinary(ExpressionType.Divide, par0, par1);
                        _Division = Expression.Lambda<Func<T1, T2, T3>>(t, par0, par1).Compile();
                    }
                    catch
                    {
                        _Division = null;
                    }
                    _Init_Division = true;
                }
                return _Division;
            }
        }
        
        public static Func<T1, T2, T3> Equality
        {
            get
            {
                if (!_Init_Equality)
                {
                    try
                    {
                        var par0 = Expression.Parameter(typeof(T1));
                        var par1 = Expression.Parameter(typeof(T2));
                        Expression t = Expression.MakeBinary(ExpressionType.Equal, par0, par1);
                        _Equality = Expression.Lambda<Func<T1, T2, T3>>(t, par0, par1).Compile();
                    }
                    catch
                    {
                        _Equality = null;
                    }
                    _Init_Equality = true;
                }
                return _Equality;
            }
        }
        
        public static Func<T1, T2, T3> Inequality
        {
            get
            {
                if (!_Init_Inequality)
                {
                    try
                    {
                        var par0 = Expression.Parameter(typeof(T1));
                        var par1 = Expression.Parameter(typeof(T2));
                        Expression t = Expression.MakeBinary(ExpressionType.NotEqual, par0, par1);
                        _Inequality = Expression.Lambda<Func<T1, T2, T3>>(t, par0, par1).Compile();
                    }
                    catch
                    {
                        _Inequality = null;
                    }
                    _Init_Inequality = true;
                }
                return _Inequality;
            }
        }
        
        public static Func<T1, T2, T3> GreaterThan
        {
            get
            {
                if (!_Init_GreaterThan)
                {
                    try
                    {
                        var par0 = Expression.Parameter(typeof(T1));
                        var par1 = Expression.Parameter(typeof(T2));
                        Expression t = Expression.MakeBinary(ExpressionType.GreaterThan, par0, par1);
                        _GreaterThan = Expression.Lambda<Func<T1, T2, T3>>(t, par0, par1).Compile();
                    }
                    catch
                    {
                        _GreaterThan = null;
                    }
                    _Init_GreaterThan = true;
                }
                return _GreaterThan;
            }
        }
        
        public static Func<T1, T2, T3> GreaterThanOrEqual
        {
            get
            {
                if (!_Init_GreaterThanOrEqual)
                {
                    try
                    {
                        var par0 = Expression.Parameter(typeof(T1));
                        var par1 = Expression.Parameter(typeof(T2));
                        Expression t = Expression.MakeBinary(ExpressionType.GreaterThanOrEqual, par0, par1);
                        _GreaterThanOrEqual = Expression.Lambda<Func<T1, T2, T3>>(t, par0, par1).Compile();
                    }
                    catch
                    {
                        _GreaterThanOrEqual = null;
                    }
                    _Init_GreaterThanOrEqual = true;
                }
                return _GreaterThanOrEqual;
            }
        }
        
        public static Func<T1, T2, T3> LessThan
        {
            get
            {
                if (!_Init_LessThan)
                {
                    try
                    {
                        var par0 = Expression.Parameter(typeof(T1));
                        var par1 = Expression.Parameter(typeof(T2));
                        Expression t = Expression.MakeBinary(ExpressionType.LessThan, par0, par1);
                        _LessThan = Expression.Lambda<Func<T1, T2, T3>>(t, par0, par1).Compile();
                    }
                    catch
                    {
                        _LessThan = null;
                    }
                    _Init_LessThan = true;
                }
                return _LessThan;
            }
        }
        
        public static Func<T1, T2, T3> LessThanOrEqual
        {
            get
            {
                if (!_Init_LessThanOrEqual)
                {
                    try
                    {
                        var par0 = Expression.Parameter(typeof(T1));
                        var par1 = Expression.Parameter(typeof(T2));
                        Expression t = Expression.MakeBinary(ExpressionType.LessThanOrEqual, par0, par1);
                        _LessThanOrEqual = Expression.Lambda<Func<T1, T2, T3>>(t, par0, par1).Compile();
                    }
                    catch
                    {
                        _LessThanOrEqual = null;
                    }
                    _Init_LessThanOrEqual = true;
                }
                return _LessThanOrEqual;
            }
        }
        
        public static Func<T1, T2, T3> Exponentiation
        {
            get
            {
                if (!_Init_Exponentiation)
                {
                    try
                    {
                        var par0 = Expression.Parameter(typeof(T1));
                        var par1 = Expression.Parameter(typeof(T2));
                        Expression t = Expression.MakeBinary(ExpressionType.Power, par0, par1);
                        _Exponentiation = Expression.Lambda<Func<T1, T2, T3>>(t, par0, par1).Compile();
                    }
                    catch
                    {
                        _Exponentiation = null;
                    }
                    _Init_Exponentiation = true;
                }
                return _Exponentiation;
            }
        }
        
        public static Func<T1, T2, T3> LeftShift
        {
            get
            {
                if (!_Init_LeftShift)
                {
                    try
                    {
                        var par0 = Expression.Parameter(typeof(T1));
                        var par1 = Expression.Parameter(typeof(T2));
                        Expression t = Expression.MakeBinary(ExpressionType.LeftShift, par0, par1);
                        _LeftShift = Expression.Lambda<Func<T1, T2, T3>>(t, par0, par1).Compile();
                    }
                    catch
                    {
                        _LeftShift = null;
                    }
                    _Init_LeftShift = true;
                }
                return _LeftShift;
            }
        }
        
        public static Func<T1, T2, T3> RightShift
        {
            get
            {
                if (!_Init_RightShift)
                {
                    try
                    {
                        var par0 = Expression.Parameter(typeof(T1));
                        var par1 = Expression.Parameter(typeof(T2));
                        Expression t = Expression.MakeBinary(ExpressionType.RightShift, par0, par1);
                        _RightShift = Expression.Lambda<Func<T1, T2, T3>>(t, par0, par1).Compile();
                    }
                    catch
                    {
                        _RightShift = null;
                    }
                    _Init_RightShift = true;
                }
                return _RightShift;
            }
        }
    }
}
