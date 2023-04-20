using System.ComponentModel.DataAnnotations;

namespace ZephyrBet.DataAnnotation;

public class MinimumAgeAttribute : ValidationAttribute
{
    private int _minAge;
    private int _maxAge = 100;


    public MinimumAgeAttribute(int minimumAge)
    {
        _minAge = minimumAge;
        ErrorMessage = "{0} Must be at least {1} years of age!";
    }

    public override bool IsValid(object value)
    {
        DateTime date;

        if (DateTime.TryParse(value.ToString(), out date))
            return date.AddYears(_minAge) < DateTime.Now && DateTime.Now < date.AddYears(_maxAge);


        return false;
    }

    public override string FormatErrorMessage(string name)
    {
        return string.Format(ErrorMessageString, name, _minAge);
    }
}