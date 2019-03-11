using EmptyBox.ScriptRuntime.Extensions;
using System;
using System.Linq.Expressions;
using System.Reflection;

namespace EmptyBox.ScriptRuntime
{
    public static class OperatorCache<T1, T2>
    {
        #region Negate
        private static Func<T1, T2> _Negate;
        private static bool _Init_Negate = false;
        public static Func<T1, T2> Negate
        {
            get
            {
                if (!_Init_Negate)
                {
                    try
                    {
                        var par1 = Expression.Parameter(typeof(T1), "left");
                        Expression t = Expression.MakeUnary(ExpressionType.Negate, par1, typeof(T2));
                        _Negate =  Expression.Lambda<Func<T1, T2>>(t, par1).Compile();
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
        #endregion Negate
        
        #region Not
        private static Func<T1, T2> _Not;
        private static bool _Init_Not = false;
        public static Func<T1, T2> Not
        {
            get
            {
                if (!_Init_Not)
                {
                    try
                    {
                        var par1 = Expression.Parameter(typeof(T1), "left");
                        Expression t = Expression.MakeUnary(ExpressionType.Not, par1, typeof(T2));
                        _Not =  Expression.Lambda<Func<T1, T2>>(t, par1).Compile();
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
        #endregion Not

        #region Logarithm
        private static Func<T1, T2> _Logarithm;
        private static bool _Init_Logarithm = false;
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
        #endregion Logarithm

        #region Logarithm10
        private static Func<T1, T2> _Logarithm10;
        private static bool _Init_Logarithm10 = false;
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
        #endregion Logarithm10

        #region Cast
        private static Func<T1, T2> _Cast;
        private static bool _Init_Cast = false;
        public static Func<T1, T2> Cast
        {
            get
            {
                if (!_Init_Cast)
                {
                    try
                    {
                        var par1 = Expression.Parameter(typeof(T1), "left");
                        Expression t = Expression.MakeUnary(ExpressionType.Convert, par1, typeof(T2));
                        _Cast = Expression.Lambda<Func<T1, T2>>(t, par1).Compile();
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
        #endregion Cast

        #region Sin
        private static Func<T1, T2> _Sin;
        private static bool _Init_Sin = false;
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
        #endregion Sin

        #region Cos
        private static Func<T1, T2> _Cos;
        private static bool _Init_Cos = false;
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
        #endregion Cos
    }

    public static class OperatorCache<T1, T2, T3>
    {
        #region Addition
        private static Func<T1, T2, T3> _Addition;
        private static bool _Init_Addition = false;
        public static Func<T1, T2, T3> Addition
        {
            get
            {
                if (!_Init_Addition)
                {
                    try
                    {
                        var par1 = Expression.Parameter(typeof(T1), "left");
                        var par2 = Expression.Parameter(typeof(T2), "right");
                        Expression t = Expression.MakeBinary(ExpressionType.Add, par1, par2);
                        _Addition = Expression.Lambda<Func<T1, T2, T3>>(t, par1, par2).Compile();
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
        #endregion Addition
        
        #region And
        private static Func<T1, T2, T3> _And;
        private static bool _Init_And = false;
        public static Func<T1, T2, T3> And
        {
            get
            {
                if (!_Init_And)
                {
                    try
                    {
                        var par1 = Expression.Parameter(typeof(T1), "left");
                        var par2 = Expression.Parameter(typeof(T2), "right");
                        Expression t = Expression.MakeBinary(ExpressionType.And, par1, par2);
                        _And = Expression.Lambda<Func<T1, T2, T3>>(t, par1, par2).Compile();
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
        #endregion And

        #region Or
        private static Func<T1, T2, T3> _Or;
        private static bool _Init_Or = false;
        public static Func<T1, T2, T3> Or
        {
            get
            {
                if (!_Init_Or)
                {
                    try
                    {
                        var par1 = Expression.Parameter(typeof(T1), "left");
                        var par2 = Expression.Parameter(typeof(T2), "right");
                        Expression t = Expression.MakeBinary(ExpressionType.Or, par1, par2);
                        _Or = Expression.Lambda<Func<T1, T2, T3>>(t, par1, par2).Compile();
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
        #endregion Or

        #region XOr
        private static Func<T1, T2, T3> _XOr;
        private static bool _Init_XOr = false;
        public static Func<T1, T2, T3> XOr
        {
            get
            {
                if (!_Init_XOr)
                {
                    try
                    {
                        var par1 = Expression.Parameter(typeof(T1), "left");
                        var par2 = Expression.Parameter(typeof(T2), "right");
                        Expression t = Expression.MakeBinary(ExpressionType.ExclusiveOr, par1, par2);
                        _XOr = Expression.Lambda<Func<T1, T2, T3>>(t, par1, par2).Compile();
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
        #endregion XOr
        
        #region Modulo
        private static Func<T1, T2, T3> _Modulo;
        private static bool _Init_Modulo = false;
        public static Func<T1, T2, T3> Modulo
        {
            get
            {
                if (!_Init_Modulo)
                {
                    try
                    {
                        var par1 = Expression.Parameter(typeof(T1), "left");
                        var par2 = Expression.Parameter(typeof(T2), "right");
                        Expression t = Expression.MakeBinary(ExpressionType.Modulo, par1, par2);
                        _Modulo = Expression.Lambda<Func<T1, T2, T3>>(t, par1, par2).Compile();
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
        #endregion Modulo

        #region Multiply
        private static Func<T1, T2, T3> _Multiply;
        private static bool _Init_Multiply = false;
        public static Func<T1, T2, T3> Multiply
        {
            get
            {
                if (!_Init_Multiply)
                {
                    try
                    {
                        var par1 = Expression.Parameter(typeof(T1), "left");
                        var par2 = Expression.Parameter(typeof(T2), "right");
                        Expression t = Expression.MakeBinary(ExpressionType.Multiply, par1, par2);
                        _Multiply = Expression.Lambda<Func<T1, T2, T3>>(t, par1, par2).Compile();
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
        #endregion Multiply

        #region Subtraction
        private static Func<T1, T2, T3> _Subtraction;
        private static bool _Init_Subtraction = false;
        public static Func<T1, T2, T3> Subtraction
        {
            get
            {
                if (!_Init_Subtraction)
                {
                    try
                    {
                        var par1 = Expression.Parameter(typeof(T1), "left");
                        var par2 = Expression.Parameter(typeof(T2), "right");
                        Expression t = Expression.MakeBinary(ExpressionType.Subtract, par1, par2);
                        _Subtraction = Expression.Lambda<Func<T1, T2, T3>>(t, par1, par2).Compile();
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
        #endregion Subtraction

        #region Division
        private static Func<T1, T2, T3> _Division;
        private static bool _Init_Division = false;
        public static Func<T1, T2, T3> Division
        {
            get
            {
                if (!_Init_Division)
                {
                    try
                    {
                        var par1 = Expression.Parameter(typeof(T1), "left");
                        var par2 = Expression.Parameter(typeof(T2), "right");
                        Expression t = Expression.MakeBinary(ExpressionType.Divide, par1, par2);
                        _Division = Expression.Lambda<Func<T1, T2, T3>>(t, par1, par2).Compile();
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
        #endregion Division

        #region Equality
        private static Func<T1, T2, T3> _Equality;
        private static bool _Init_Equality = false;
        public static Func<T1, T2, T3> Equality
        {
            get
            {
                if (!_Init_Equality)
                {
                    try
                    {
                        var par1 = Expression.Parameter(typeof(T1), "left");
                        var par2 = Expression.Parameter(typeof(T2), "right");
                        Expression t = Expression.MakeBinary(ExpressionType.Equal, par1, par2);
                        _Equality = Expression.Lambda<Func<T1, T2, T3>>(t, par1, par2).Compile();
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
        #endregion Equality

        #region Inequality
        private static Func<T1, T2, T3> _Inequality;
        private static bool _Init_Inequality = false;
        public static Func<T1, T2, T3> Inequality
        {
            get
            {
                if (!_Init_Inequality)
                {
                    try
                    {
                        var par1 = Expression.Parameter(typeof(T1), "left");
                        var par2 = Expression.Parameter(typeof(T2), "right");
                        Expression t = Expression.MakeBinary(ExpressionType.NotEqual, par1, par2);
                        _Inequality = Expression.Lambda<Func<T1, T2, T3>>(t, par1, par2).Compile();
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
        #endregion Ineqaulity

        #region GreaterThan
        private static Func<T1, T2, T3> _GreaterThan;
        private static bool _Init_GreaterThan = false;
        public static Func<T1, T2, T3> GreaterThan
        {
            get
            {
                if (!_Init_GreaterThan)
                {
                    try
                    {
                        var par1 = Expression.Parameter(typeof(T1), "left");
                        var par2 = Expression.Parameter(typeof(T2), "right");
                        Expression t = Expression.MakeBinary(ExpressionType.GreaterThan, par1, par2);
                        _GreaterThan = Expression.Lambda<Func<T1, T2, T3>>(t, par1, par2).Compile();
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
        #endregion GreaterThan

        #region GreaterThanOrEqual
        private static Func<T1, T2, T3> _GreaterThanOrEqual;
        private static bool _Init_GreaterThanOrEqual = false;
        public static Func<T1, T2, T3> GreaterThanOrEqual
        {
            get
            {
                if (!_Init_GreaterThanOrEqual)
                {
                    try
                    {
                        var par1 = Expression.Parameter(typeof(T1), "left");
                        var par2 = Expression.Parameter(typeof(T2), "right");
                        Expression t = Expression.MakeBinary(ExpressionType.GreaterThanOrEqual, par1, par2);
                        _GreaterThanOrEqual = Expression.Lambda<Func<T1, T2, T3>>(t, par1, par2).Compile();
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
        #endregion GreaterThanOrEqual

        #region LessThan
        private static Func<T1, T2, T3> _LessThan;
        private static bool _Init_LessThan = false;
        public static Func<T1, T2, T3> LessThan
        {
            get
            {
                if (!_Init_LessThan)
                {
                    try
                    {
                        var par1 = Expression.Parameter(typeof(T1), "left");
                        var par2 = Expression.Parameter(typeof(T2), "right");
                        Expression t = Expression.MakeBinary(ExpressionType.LessThan, par1, par2);
                        _LessThan = Expression.Lambda<Func<T1, T2, T3>>(t, par1, par2).Compile();
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
        #endregion LessThan

        #region LessThanOrEqual
        private static Func<T1, T2, T3> _LessThanOrEqual;
        private static bool _Init_LessThanOrEqual = false;
        public static Func<T1, T2, T3> LessThanOrEqual
        {
            get
            {
                if (!_Init_LessThanOrEqual)
                {
                    try
                    {
                        var par1 = Expression.Parameter(typeof(T1), "left");
                        var par2 = Expression.Parameter(typeof(T2), "right");
                        Expression t = Expression.MakeBinary(ExpressionType.LessThanOrEqual, par1, par2);
                        _LessThanOrEqual = Expression.Lambda<Func<T1, T2, T3>>(t, par1, par2).Compile();
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
        #endregion LessThanOrEqual

        #region Exponentiation
        private static Func<T1, T2, T3> _Exponentiation;
        private static bool _Init_Exponentiation = false;
        public static Func<T1, T2, T3> Exponentiation
        {
            get
            {
                if (!_Init_Exponentiation)
                {
                    try
                    {
                        var par1 = Expression.Parameter(typeof(T1), "left");
                        var par2 = Expression.Parameter(typeof(T2), "right");
                        Expression t = Expression.MakeBinary(ExpressionType.Power, par1, par2);
                        _Exponentiation = Expression.Lambda<Func<T1, T2, T3>>(t, par1, par2).Compile();
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
        #endregion Exponentiation
        
        #region LeftShift
        private static Func<T1, T2, T3> _LeftShift;
        private static bool _Init_LeftShift = false;
        public static Func<T1, T2, T3> LeftShift
        {
            get
            {
                if (!_Init_LeftShift)
                {
                    try
                    {
                        var par1 = Expression.Parameter(typeof(T1), "left");
                        var par2 = Expression.Parameter(typeof(T2), "right");
                        Expression t = Expression.MakeBinary(ExpressionType.LeftShift, par1, par2);
                        _LeftShift = Expression.Lambda<Func<T1, T2, T3>>(t, par1, par2).Compile();
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
        #endregion LeftShift
        
        #region RightShift
        private static Func<T1, T2, T3> _RightShift;
        private static bool _Init_RightShift = false;
        public static Func<T1, T2, T3> RightShift
        {
            get
            {
                if (!_Init_RightShift)
                {
                    try
                    {
                        var par1 = Expression.Parameter(typeof(T1), "left");
                        var par2 = Expression.Parameter(typeof(T2), "right");
                        Expression t = Expression.MakeBinary(ExpressionType.RightShift, par1, par2);
                        _RightShift = Expression.Lambda<Func<T1, T2, T3>>(t, par1, par2).Compile();
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
        #endregion RightShift
    }
}
