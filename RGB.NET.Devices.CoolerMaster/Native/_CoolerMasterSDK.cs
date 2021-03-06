﻿// ReSharper disable UnusedMethodReturnValue.Global
// ReSharper disable UnusedMember.Global

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using RGB.NET.Core.Exceptions;

namespace RGB.NET.Devices.CoolerMaster.Native
{
    // ReSharper disable once InconsistentNaming
    internal static class _CoolerMasterSDK
    {
        #region Libary Management

        private static IntPtr _dllHandle = IntPtr.Zero;

        /// <summary>
        /// Gets the loaded architecture (x64/x86).
        /// </summary>
        internal static string LoadedArchitecture { get; private set; }

        /// <summary>
        /// Reloads the SDK.
        /// </summary>
        internal static void Reload()
        {
            UnloadCMSDK();
            LoadCMSDK();
        }

        private static void LoadCMSDK()
        {
            if (_dllHandle != IntPtr.Zero) return;

            // HACK: Load library at runtime to support both, x86 and x64 with one managed dll
            List<string> possiblePathList = Environment.Is64BitProcess ? CoolerMasterDeviceProvider.PossibleX64NativePaths : CoolerMasterDeviceProvider.PossibleX86NativePaths;
            string dllPath = possiblePathList.FirstOrDefault(File.Exists);
            if (dllPath == null) throw new RGBDeviceException($"Can't find the CoolerMaster-SDK at one of the expected locations:\r\n '{string.Join("\r\n", possiblePathList.Select(Path.GetFullPath))}'");

            _dllHandle = LoadLibrary(dllPath);

            _getSDKVersionPointer = (GetSDKVersionPointer)Marshal.GetDelegateForFunctionPointer(GetProcAddress(_dllHandle, "GetCM_SDK_DllVer"), typeof(GetSDKVersionPointer));
            _setControlDevicenPointer = (SetControlDevicePointer)Marshal.GetDelegateForFunctionPointer(GetProcAddress(_dllHandle, "SetControlDevice"), typeof(SetControlDevicePointer));
            _isDevicePlugPointer = (IsDevicePlugPointer)Marshal.GetDelegateForFunctionPointer(GetProcAddress(_dllHandle, "IsDevicePlug"), typeof(IsDevicePlugPointer));
            _getDeviceLayoutPointer = (GetDeviceLayoutPointer)Marshal.GetDelegateForFunctionPointer(GetProcAddress(_dllHandle, "GetDeviceLayout"), typeof(GetDeviceLayoutPointer));
            _enableLedControlPointer = (EnableLedControlPointer)Marshal.GetDelegateForFunctionPointer(GetProcAddress(_dllHandle, "EnableLedControl"), typeof(EnableLedControlPointer));
            _refreshLedPointer = (RefreshLedPointer)Marshal.GetDelegateForFunctionPointer(GetProcAddress(_dllHandle, "RefreshLed"), typeof(RefreshLedPointer));
            _setLedColorPointer = (SetLedColorPointer)Marshal.GetDelegateForFunctionPointer(GetProcAddress(_dllHandle, "SetLedColor"), typeof(SetLedColorPointer));
        }

        private static void UnloadCMSDK()
        {
            if (_dllHandle == IntPtr.Zero) return;

            // ReSharper disable once EmptyEmbeddedStatement - DarthAffe 20.02.2016: We might need to reduce the internal reference counter more than once to set the library free
            while (FreeLibrary(_dllHandle)) ;
            _dllHandle = IntPtr.Zero;
        }

        [DllImport("kernel32.dll")]
        private static extern IntPtr LoadLibrary(string dllToLoad);

        [DllImport("kernel32.dll")]
        private static extern bool FreeLibrary(IntPtr dllHandle);

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetProcAddress(IntPtr dllHandle, string name);

        #endregion

        #region SDK-METHODS

        #region Pointers

        private static GetSDKVersionPointer _getSDKVersionPointer;
        private static SetControlDevicePointer _setControlDevicenPointer;
        private static IsDevicePlugPointer _isDevicePlugPointer;
        private static GetDeviceLayoutPointer _getDeviceLayoutPointer;
        private static EnableLedControlPointer _enableLedControlPointer;
        private static RefreshLedPointer _refreshLedPointer;
        private static SetLedColorPointer _setLedColorPointer;

        #endregion

        #region Delegates

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int GetSDKVersionPointer();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SetControlDevicePointer(CoolerMasterDevicesIndexes devicesIndexes);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        private delegate bool IsDevicePlugPointer();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate CoolerMasterPhysicalKeyboardLayout GetDeviceLayoutPointer();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        private delegate bool EnableLedControlPointer(bool value);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        private delegate bool RefreshLedPointer(bool autoRefresh);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        private delegate bool SetLedColorPointer(int row, int column, byte r, byte g, byte b);

        #endregion

        // ReSharper disable EventExceptionNotDocumented

        /// <summary>
        /// CM-SDK: Get SDK Dll's Version.
        /// </summary>
        internal static int GetSDKVersion()
        {
            return _getSDKVersionPointer();
        }

        /// <summary>
        /// CM-SDK: set operating device
        /// </summary>
        internal static void SetControlDevice(CoolerMasterDevicesIndexes devicesIndexes)
        {
            _setControlDevicenPointer(devicesIndexes);
        }

        /// <summary>
        /// CM-SDK: verify if the deviced is plugged in
        /// </summary>
        internal static bool IsDevicePlugged()
        {
            return _isDevicePlugPointer();
        }

        /// <summary>
        /// CM-SDK: Obtain current device layout
        /// </summary>
        internal static CoolerMasterPhysicalKeyboardLayout GetDeviceLayout()
        {
            return _getDeviceLayoutPointer();
        }

        /// <summary>
        /// CM-SDK: set control over device’s LED
        /// </summary>
        internal static bool EnableLedControl(bool value)
        {
            return _enableLedControlPointer(value);
        }

        /// <summary>
        /// CM-SDK: Print out the lights setting from Buffer to LED
        /// </summary>
        internal static bool RefreshLed(bool autoRefresh)
        {
            return _refreshLedPointer(autoRefresh);
        }

        /// <summary>
        /// CM-SDK: Set single Key LED color
        /// </summary>
        internal static bool SetLedColor(int row, int column, byte r, byte g, byte b)
        {
            return _setLedColorPointer(row, column, r, g, b);
        }

        // ReSharper restore EventExceptionNotDocumented

        #endregion
    }
}
