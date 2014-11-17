﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Stesnyashki.App_Start;

[assembly: WebActivator.PreApplicationStartMethod(typeof(PreStartApp), "Start")]
namespace Stesnyashki.App_Start
{
    public static class PreStartApp
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Метод запускается один раз перед стартом приложения        
        /// </summary>
        public static void Start()
        {
            logger.Info("Application PreStart");
        }
    }
}