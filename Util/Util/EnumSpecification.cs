#region Assembly

using System;
using System.Reflection;
using System.Collections.ObjectModel;
using System.Collections.Generic;

#endregion

namespace QuickCodeSel.Util
{
    public class EnumSpecification
    {
        private EnumSpecification() { }

        public static Dictionary<object, string> List(Type lTipo)
        {
            Dictionary<object, string> List = new Dictionary<object, string>();

            FieldInfo[] FieldsEnum = lTipo.GetFields();
            foreach (dynamic Field in FieldsEnum)
            {
                object[] Atributes = Field.GetCustomAttributes(typeof(AtributeSpecification), true);

                foreach (AtributeSpecification Atribute in Atributes)
                {
                    List.Add(Field.GetValue(lTipo), Atribute.Specification);
                }
            }

            return List;
        }

        public static string Get(Enum lValue)
        {
            Dictionary<object, string> ListlValues = List(lValue.GetType());

            if (ListlValues.ContainsKey(lValue))
            {
                return ListlValues[lValue];
            }

            throw new MissingMemberException(string.Format("The description {0} was not found in {1}.", lValue.ToString(), lValue.GetType().Name));
        }
    }
    
    [AttributeUsage(AttributeTargets.Field)]
    public class AtributeSpecification : Attribute
    {
        private string specification;

        public string Specification { get { return specification; } }

        public AtributeSpecification(string specification)
        {
            this.specification = specification;
        }
    }
}
