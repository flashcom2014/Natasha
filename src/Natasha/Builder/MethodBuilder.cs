﻿using Natasha.Template;
using System;
using System.Reflection;

namespace Natasha
{
    /// <summary>
    /// 方法脚本构造器
    /// </summary>
    public class MethodBuilder
    {


        public ClassBuilder ClassTemplate;
        public MethodTemplate MethodTemplate;
        public ClassComplier Complier;

        public MethodBuilder()
        {

            ClassTemplate = new ClassBuilder();
            MethodTemplate = new MethodTemplate();
            Complier = new ClassComplier(); 

        }




        /// <summary>
        /// 获取方法脚本
        /// </summary>
        public string MethodScript
        {

            get { return MethodTemplate.Builder().Script; }

        }




        /// <summary>
        /// 重置类型模板
        /// </summary>
        /// <param name="classTemplate">新的类型模板</param>
        /// <returns></returns>
        public virtual MethodBuilder ResetClassTemplate(ClassBuilder classTemplate)
        {

            ClassTemplate = classTemplate;
            return this;

        }




        /// <summary>
        /// 根据委托来定制类型模板
        /// </summary>
        /// <param name="classAction">类模板委托</param>
        /// <returns></returns>
        public virtual MethodBuilder ClassAction(Action<ClassBuilder> classAction)
        {

            classAction(ClassTemplate);
            return this;

        }




        /// <summary>
        /// 重置方法模板
        /// </summary>
        /// <param name="methodTemplate">方法模板</param>
        /// <returns></returns>
        public virtual MethodBuilder ResetBodyTemplate(MethodTemplate methodTemplate)
        {

            MethodTemplate = methodTemplate;
            return this;

        }




        /// <summary>
        /// 根据委托来定制方法模板
        /// </summary>
        /// <param name="methodAction">方法模板委托</param>
        /// <returns></returns>
        public virtual MethodBuilder MethodAction(Action<MethodTemplate> methodAction)
        {

            methodAction(MethodTemplate);
            return this;

        }


        /// <summary>
        /// 编译并返回委托
        /// </summary>
        /// <returns></returns>
        public Delegate Complie(object binder = null)
        {
            return Complier.GetDelegateByScript(ClassTemplate
                .Using(MethodTemplate.UsingRecoder.Types)
                .ClassBody(MethodTemplate.Builder()._script)
                .Builder().Script,
                ClassTemplate.ClassNameScript,
                MethodTemplate.MethodNameScript,
                MethodTemplate.DelegateType,
                binder);

        }

        public T Complie<T>(object binder=null) where T :Delegate
        {
            return Complier.GetDelegateByScript<T>(ClassTemplate
                .Using(MethodTemplate.UsingRecoder.Types)
                .ClassBody(MethodTemplate.Builder()._script)
                .Builder().Script,
                ClassTemplate.ClassNameScript,
                MethodTemplate.MethodNameScript,
                binder);
        }

    }

}