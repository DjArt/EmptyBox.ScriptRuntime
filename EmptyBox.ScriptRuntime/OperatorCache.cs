using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

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
                    if (TypeChecker.IsNumberType(t1))
                    {
                        _Logarithm = x => OperatorCache<double, T2>.Convert(Math.Log(OperatorCache<T1, double>.Convert(x)));
                    }
                    else
                    {
                        try
                        {
                            //Backport from NET.Standard 1.6+
                            //MethodInfo method = t1.GetTypeInfo().GetMethod("Sin", BindingFlags.Static | BindingFlags.Public);
                            MethodInfo method = t1.GetTypeInfo().GetDeclaredMethod("Log");
                            if (method != null)
                            {
                                _Logarithm = x => OperatorCache<object, T2>.Convert(method.Invoke(null, new[] { OperatorCache<T1, object>.Convert(x) }));
                            }
                            else
                            {
                                _Logarithm = x => OperatorCache<double, T2>.Convert(Math.Sin(OperatorCache<T1, double>.Convert(x)));
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
                    if (TypeChecker.IsNumberType(t1))
                    {
                        _Logarithm10 = x => OperatorCache<double, T2>.Convert(Math.Log10(OperatorCache<T1, double>.Convert(x)));
                    }
                    else
                    {
                        try
                        {
                            //Backport from NET.Standard 1.6+
                            //MethodInfo method = t1.GetTypeInfo().GetMethod("Sin", BindingFlags.Static | BindingFlags.Public);
                            MethodInfo method = t1.GetTypeInfo().GetDeclaredMethod("Log10");
                            if (method != null)
                            {
                                _Logarithm10 = x => OperatorCache<object, T2>.Convert(method.Invoke(null, new[] { OperatorCache<T1, object>.Convert(x) }));
                            }
                            else
                            {
                                _Logarithm10 = x => OperatorCache<double, T2>.Convert(Math.Sin(OperatorCache<T1, double>.Convert(x)));
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

        #region Convert
        private static Func<T1, T2> _Convert;
        private static bool _Init_Convert = false;
        public static Func<T1, T2> Convert
        {
            get
            {
                if (!_Init_Convert)
                {
                    try
                    {
                        var par1 = Expression.Parameter(typeof(T1), "left");
                        Expression t = Expression.MakeUnary(ExpressionType.Convert, par1, typeof(T2));
                        _Convert = Expression.Lambda<Func<T1, T2>>(t, par1).Compile();
                    }
                    catch
                    {
                        _Convert = null;
                    }
                    _Init_Convert = true;
                }
                return _Convert;
            }
        }
        #endregion Convert

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
                    if (TypeChecker.IsNumberType(t1))
                    {
                        _Sin = x => OperatorCache<double, T2>.Convert(Math.Sin(OperatorCache<T1, double>.Convert(x)));
                    }
                    else
                    {
                        try
                        {
                            //Backport from NET.Standard 1.6+
                            //MethodInfo method = t1.GetTypeInfo().GetMethod("Sin", BindingFlags.Static | BindingFlags.Public);
                            MethodInfo method = t1.GetTypeInfo().GetDeclaredMethod("Sin");
                            if (method != null)
                            {
                                _Sin = x => OperatorCache<object, T2>.Convert(method.Invoke(null, new[] { OperatorCache<T1, object>.Convert(x) }));
                            }
                            else
                            {
                                _Sin = x => OperatorCache<double, T2>.Convert(Math.Sin(OperatorCache<T1, double>.Convert(x)));
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
                    if (TypeChecker.IsNumberType(t1))
                    {
                        _Cos = x => OperatorCache<double, T2>.Convert(Math.Cos(OperatorCache<T1, double>.Convert(x)));
                    }
                    else
                    {
                        try
                        {
                            //Backport from NET.Standard 1.6+
                            //MethodInfo method = t1.GetTypeInfo().GetMethod("Cos", BindingFlags.Static | BindingFlags.Public);
                            MethodInfo method = t1.GetTypeInfo().GetDeclaredMethod("Cos");
                            if (method != null)
                            {
                                _Cos = x => OperatorCache<object, T2>.Convert(method.Invoke(null, new[] { OperatorCache<T1, object>.Convert(x) }));
                            }
                            else
                            {
                                _Cos = x => OperatorCache<double, T2>.Convert(Math.Cos(OperatorCache<T1, double>.Convert(x)));
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

        public static void Clear()
        {
            _Negate = null;
            _Init_Negate = false;
            _Logarithm = null;
            _Init_Logarithm = false;
            _Convert = null;
            _Init_Convert = false;
            _Sin = null;
            _Init_Sin = false;
            _Cos = null;
            _Init_Cos = false;
            _Logarithm = null;
            _Init_Logarithm = false;
            _Logarithm10 = null;
            _Init_Logarithm10 = false;
        }
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

        #region Equal
        private static Func<T1, T2, T3> _Equal;
        private static bool _Init_Equal = false;
        public static Func<T1, T2, T3> Equal
        {
            get
            {
                if (!_Init_Equal)
                {
                    try
                    {
                        var par1 = Expression.Parameter(typeof(T1), "left");
                        var par2 = Expression.Parameter(typeof(T2), "right");
                        Expression t = Expression.MakeBinary(ExpressionType.Equal, par1, par2);
                        _Equal = Expression.Lambda<Func<T1, T2, T3>>(t, par1, par2).Compile();
                    }
                    catch
                    {
                        _Equal = null;
                    }
                    _Init_Equal = true;
                }
                return _Equal;
            }
        }
        #endregion Equal

        #region NotEqual
        private static Func<T1, T2, T3> _NotEqual;
        private static bool _Init_NotEqual = false;
        public static Func<T1, T2, T3> NotEqual
        {
            get
            {
                if (!_Init_NotEqual)
                {
                    try
                    {
                        var par1 = Expression.Parameter(typeof(T1), "left");
                        var par2 = Expression.Parameter(typeof(T2), "right");
                        Expression t = Expression.MakeBinary(ExpressionType.NotEqual, par1, par2);
                        _NotEqual = Expression.Lambda<Func<T1, T2, T3>>(t, par1, par2).Compile();
                    }
                    catch
                    {
                        _NotEqual = null;
                    }
                    _Init_NotEqual = true;
                }
                return _NotEqual;
            }
        }
        #endregion NotEqual

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

        #region Power
        private static Func<T1, T2, T3> _Power;
        private static bool _Init_Power = false;
        public static Func<T1, T2, T3> Power
        {
            get
            {
                if (!_Init_Power)
                {
                    Type t1 = typeof(T1);
                    Type t2 = typeof(T2);
                    if (TypeChecker.IsNumberType(t1) && TypeChecker.IsNumberType(t2))
                    {
                        _Power = (x, y) => OperatorCache<double, T3>.Convert(Math.Pow(OperatorCache<T1, double>.Convert(x), OperatorCache<T2, double>.Convert(y)));
                    }
                    else
                    {
                        try
                        {
                            //Backport from NET.Standard 1.6+
                            //MethodInfo method = t1.GetTypeInfo().GetMethod("op_Exponentiation", BindingFlags.Static | BindingFlags.Public);
                            //if (method == null) method = method = t1.GetTypeInfo().GetMethod("Pow", BindingFlags.Static | BindingFlags.Public, null, new[] {t1, t2}, new ParameterModifier[0]);
                            MethodInfo method = t1.GetTypeInfo().GetDeclaredMethod("op_Exponentiation");
                            if (method == null) method = method = t1.GetTypeInfo().GetDeclaredMethod("Pow");
                            if (method != null)
                            {
                                _Power = (x, y) => OperatorCache<object, T3>.Convert(method.Invoke(null, new object[] { x, y }));
                            }
                            else
                            {
                                _Power = null;
                            }
                        }
                        catch
                        {
                            _Power = null;
                        }
                    }
                }
                return _Power;
            }
        }
        #endregion Power

        public static void Clear()
        {
            _Addition = null;
            _Init_Addition = false;
            _Multiply = null;
            _Init_Multiply = false;
            _Subtraction = null;
            _Init_Subtraction = false;
            _Division = null;
            _Init_Division = false;
            _Equal = null;
            _Init_Equal = false;
            _NotEqual = null;
            _Init_NotEqual = false;
            _Power = null;
            _Init_Power = false;
        }
    }
}
