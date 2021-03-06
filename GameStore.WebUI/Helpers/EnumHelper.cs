﻿using System;
using System.Linq;
using System.Reflection;
using GameStore.Core.CustomAttributes;

namespace GameStore.WebUI.Helpers
{
    public static class EnumHelper<T>
    {
        /// <summary>
        /// Gets a description of the enum.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string GetEnumDescription(string value)
        {
            Type type = typeof (T);
            string name = Enum.GetNames(type)
                .Where(f => f.Equals(value, StringComparison.CurrentCultureIgnoreCase))
                .Select(d => d).FirstOrDefault();

            if (name == null)
            {
                return string.Empty;
            }

            FieldInfo field = type.GetField(name);
            object[] customAttribute = field.GetCustomAttributes(typeof (LocalizedDescriptionAttribute), false);

            return customAttribute.Length > 0 ? ((LocalizedDescriptionAttribute)customAttribute[0]).Description : name;
        }
    }
}