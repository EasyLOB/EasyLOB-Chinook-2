using Chinook.Mvc.Resources;
using EasyLOB;
using EasyLOB.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace Chinook.Mvc
{
    public class TaskSimpleViewModel : TaskViewModel
    {
        #region Properties

        public bool XBoolean { get; set; }

        public DateTime? XDateTime { get; set; }

        [Required]
        public double XDouble { get; set; }

        public int? XInteger { get; set; }

        public string XString { get; set; }

        #endregion Properties

        #region Methods

        public TaskSimpleViewModel()
        {
            XBoolean = false;
            XDateTime = null;
            XDouble = 123.45;
            XInteger = null;
            XString = "ABC";
        }

        public TaskSimpleViewModel(string controller, string action, string task,
            bool xBoolean, DateTime? xDateTime, double xDouble, int? xInteger, string xString)
            : this()
        {
            Controller = controller;
            Action = action;
            Task = task;

            XBoolean = xBoolean;
            XDateTime = xDateTime;
            XDouble = xDouble;
            XInteger = xInteger;
            XString = xString;
        }

        public override bool Validate(ZOperationResult operationResult)
        {
            return operationResult.Ok;
        }

        #endregion Methods
    }
}