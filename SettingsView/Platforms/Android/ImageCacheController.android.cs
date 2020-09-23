﻿using System;

namespace AiForms.Renderers.Droid
{
    /// <summary>
    /// Image cache controller.
    /// </summary>
    [Android.Runtime.Preserve(AllMembers = true)]
    public static class ImageCacheController
    {
        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>The instance.</value>
        public static MemoryLimitedLruCache Instance
        {
            get {
                if (_CacheInstance == null) {
                    _CacheInstance = new MemoryLimitedLruCache(CacheSize);
                    SettingsView._clearCache = Clear;
                }
                return _CacheInstance;
            }
        }

        /// <summary>
        /// Clear this instance.
        /// </summary>
        public static void Clear()
        {
            _CacheInstance?.EvictAll();
            _CacheInstance?.Dispose();
            _CacheInstance = null;
            SettingsView._clearCache = null;
        }

        static readonly int CacheSize = (int)(Java.Lang.Runtime.GetRuntime().MaxMemory() / 1024 / 8);
        static MemoryLimitedLruCache _CacheInstance;
    }
}
