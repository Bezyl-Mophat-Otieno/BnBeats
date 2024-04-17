using FluentValidation;

namespace BnBEats.api;

public static class DateTimeValidator
{
    public static IRuleBuilderOptions<T, DateTime> AfterSunrise <T>(this IRuleBuilder<T, DateTime> ruleBuilder)
    {
        return ruleBuilder.Must(date => date.Hour >= 6 && date.Hour < 12)
            .WithMessage("The time must be after sunrise");
    }

}
