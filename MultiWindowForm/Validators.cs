using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiWindowForm
{
    public static class Validators
    {
        public static bool IsTextEmpty(Control control)
        {
            return control.Text == "";
        }
        public static bool IsMinLength(Control control, int minlength)
        {
            return control.Text.Length >= minlength;
        }

        public static bool IsTextNull(Control control)
        {
            return control.Text == null;
        }
        public static bool IsValidDate(Control control)
        {
            DateTime temp = DateTime.Now;
            return DateTime.TryParse(control.Text, out temp);
        }
    }
}
