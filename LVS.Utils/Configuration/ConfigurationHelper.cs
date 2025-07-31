﻿using System;
using System.Configuration;

namespace LVS.Utils.Configuration
{
    public class ConfigurationHelper
    {
        public static TResult GetValue<TResult>(string key, Func<TResult> defaultValue = null)
        {
            if (!string.IsNullOrWhiteSpace(key))
            {
                var keyValue = ConfigurationManager.AppSettings[key];
                if (!string.IsNullOrWhiteSpace(key))
                {
                    try
                    {
                        return (TResult)Convert.ChangeType(ConfigurationManager.AppSettings[key], typeof(TResult));
                    }
                    catch (Exception) { }
                }
            }

            if (defaultValue != null)
            {
                try
                {
                    return defaultValue.Invoke();
                }
                catch (Exception) { }
            }

            return default(TResult);
        }
    }
}
