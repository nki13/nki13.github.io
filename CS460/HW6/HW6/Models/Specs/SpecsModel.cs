using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW6.Models.Specs
{
    /// <summary>
    /// This is purely to help me return one thing to the view for Specs
    /// It will hold every an instance of every model I need to fulfill homework
    /// </summary>
    public class SpecsModel
    {
        //So far(feature #1) I only need a Person object
        public Person Person { get; set; }

        // For feature #2 Customer Object
        public Customer Customer { get; set; }

        // For feature #2 Invoice Line object, shown as list
        public List<InvoiceLine> InvoiceLine { get; set; }

    }
}