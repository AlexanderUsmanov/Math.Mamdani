using System.Xml.Linq;

namespace FuzzyLogic.Mamdani.Interfaces
{
    //Функция принадлежности
    public interface IAccessoryFunc
    {
        double GetValue(double x);
        IAccessoryFunc CopyFunc();
        void SetActivatedValue(double x);
        double GetActivatedValue(double x);

        string[] ToStringArray();
        XAttribute[] ToXAttributeArray(params string[] attributesNames);
    }
}
