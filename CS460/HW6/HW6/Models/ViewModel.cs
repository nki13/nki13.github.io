using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW6.Models
{
    /// <summary>
    /// This is purely to help me return one thing to the view for Specs
    /// It will hold every an instance of every model I need to fulfill homework
    /// </summary>
    public class ViewModel
    {
        //So far(feature #1) I only need a Person Model
        public Person Person { get; set; }
    }
}