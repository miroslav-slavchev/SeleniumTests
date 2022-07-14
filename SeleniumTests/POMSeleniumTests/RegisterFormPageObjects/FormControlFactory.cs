using OpenQA.Selenium;
using SeleniumTests.POMSeleniumTests.RegisterFormPageObjects.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTests.POMSeleniumTests.RegisterFormPageObjects
{
    public class FormGroupControlFactory
    {
        private List<IWebElement> Elements { get; set; }

        public FormGroupControlFactory(List<IWebElement> elements)
        {
            Elements = elements;
        }

        public List<FormGroupControl> Controls
        {
            get
            {
                List<FormGroupControl> controls = new();
                foreach (var element in Elements)
                {
                    FormGroupControl control = GetControlFromElement(element);
                    controls.Add(control);
                }
                return controls;
            }

        }

        public FormGroupControl GetControl(string name) => Controls.Where(control => control.Name == name).First();

        private FormGroupControl GetControlFromElement(IWebElement element)
        {
            string type = element.GetAttribute("data-form-group-type");

            FormGroupControl control;
            switch (type)
            {
                case "text-input": control = new TextInputControl(element); break;
                case "radio-group": control = new RadioGroupControl(element); break;
                case "checkbox-group": control = new CheckboxGroupControl(element); break;
                case "slider-input": control = new SliderControl(element); break;
                case "text-input-long": control = new TextAreaControl(element); break;
                case "select-input": control = new SelectControl(element); break;
                default: throw new Exception("Unsupported type " + type);
            }
            return control;
        }
    }
}
