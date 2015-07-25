﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Agarion.IO.ThreadingTools
{
    /// <summary>
    /// Helps with asynchronous stuff.
    /// </summary>
    public static class AsyncHelper
    {
        /// <summary>
        /// Executes a method in a new thread with parameters.
        /// A timer can be added.
        /// </summary>
        /// <param name="method">The method</param>
        /// <param name="parameters">The parameters of the method</param>
        /// <param name="afterN">Optional. Uses milliseconds. Used for delaying method execution.</param>
        public static void ExecuteMethod(Action<dynamic> method, dynamic parameters, int afterN = 0)
        {
            new Thread(() =>
            {
                Thread.Sleep(afterN);

                method(parameters);
            }).Start();
        }

        /// <summary>
        /// Executes a method in a new thread without parameters.
        /// A timer can be added.
        /// </summary>
        /// <param name="method">The method</param>
        /// <param name="parameters">The parameters of the method</param>
        /// <param name="afterN">Optional. Uses milliseconds. Used for delaying method execution.</param>
        public static void ExecuteMethod(Action method, int afterN = 0)
        {
            new Thread(() =>
            {
                Thread.Sleep(afterN);

                method();
            }).Start();
        }
    }
}