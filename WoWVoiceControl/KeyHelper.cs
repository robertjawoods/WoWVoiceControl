﻿using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Input;

namespace WoWVoiceControl
{
    /// <summary>
    /// Class for performing operations related to key bindings
    /// </summary>
    internal class KeyHelper
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetKeyboardState(byte[] lpKeyState);

        // Gets a list of keys that are currently pressed down as byte array
        private static readonly byte[] DistinctVirtualKeys = Enumerable
            .Range(0, 256)
            .Select(KeyInterop.KeyFromVirtualKey)
            .Where(item => item != Key.None)
            .Distinct()
            .Select(item => (byte)KeyInterop.VirtualKeyFromKey(item))
            .ToArray();

        /// <summary>
        /// Gets all keys that are currently in the down state.
        /// </summary>
        /// <returns>
        /// A collection of all keys that are currently in the down state.
        /// </returns>
        public static IEnumerable<Key> GetDownKeys()
        {
            var keyboardState = new byte[256];
            GetKeyboardState(keyboardState);

            var downKeys = new List<Key>();
            for (var index = 0; index < DistinctVirtualKeys.Length; index++)
            {
                var virtualKey = DistinctVirtualKeys[index];
                if ((keyboardState[virtualKey] & 0x80) != 0)
                {
                    downKeys.Add(KeyInterop.KeyFromVirtualKey(virtualKey));
                }
            }

            return downKeys;
        }

        /// <summary>
        /// Gets a formatted keystring for display.
        /// </summary>
        /// <remarks> e.g. "LeftCtrl + T"</remarks>
        /// <returns>A formatted keybinding string</returns>
        public static string GetFormattedKeyString()
        {
            StringBuilder keyBind = new StringBuilder();

            List<Key> keysPressed = KeyHelper.GetDownKeys().ToList();

            foreach (Key k in keysPressed)
            {
                string key = k.ToString();

                if (key.Contains("Left"))
                    key = key.Remove(0, 4);
                else if (key.Contains("Right"))
                    key = key.Remove(0, 5);

                keyBind.Append(key);

                int index = keysPressed.IndexOf(k);

                if (index == (keysPressed.Count - 1))
                    break;

                keyBind.Append(" + ");
            }

            return keyBind.ToString();
        }

        /// <summary>
        /// Gets a key string from a formatted string.
        /// </summary>
        /// <remarks>"Ctrl + T" becomes "^{T}"</remarks>
        /// <param name="formattedKeyString">The formatted key string</param>
        /// <returns>A key string ready to be passed to SendKeys</returns>
        public static string GetKeyString(string formattedKeyString)
        {
            StringBuilder result = new StringBuilder();

            string keys = formattedKeyString.Replace("+", "");

            string[] individualKeys = keys.Split(' ');

            foreach (string s in individualKeys.Where(s => !s.Equals(string.Empty)))
            {
                string final = s;

                if (final.StartsWith("D"))
                    final = final.Remove(0, 1);
                else if (final.StartsWith("NumPad"))
                    final = final.Remove(0, 6);

                switch (s)
                {
                    case "Ctrl":
                        result.Append("^");
                        break;

                    case "Shift":
                        result.Append("+");
                        break;

                    case "Alt":
                        result.Append("%");
                        break;

                    default:
                        {
                            result.Append("{" + final + "}");
                            break;
                        }
                }
            }
                

            return result.ToString();
        }

        public static string GetFormattedKeyString(string keyString)
        {
            string keys = keyString.Replace("{", string.Empty).Replace("}", string.Empty);

            StringBuilder formattedKeyString = new StringBuilder();

            for (int i = 0; i < keys.Length; i++)
            {
                switch (keys[i])
                {
                    case '+':
                        formattedKeyString.Append("Shift ");
                        break;

                    case '%':
                        formattedKeyString.Append("Alt ");
                        break;

                    case '^':
                        formattedKeyString.Append("Ctrl ");
                        break;

                    default:
                        formattedKeyString.Append($"{keys[i]} ");
                        break;
                }

                if (i != keys.Length - 1)
                    formattedKeyString.Append("+ ");
            }

            return formattedKeyString.ToString();
        }

    }
}
