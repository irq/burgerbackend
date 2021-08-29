using System;
using CSharpFunctionalExtensions;
using FluentValidation;
using FluentValidation.Validators;

namespace Sion.BurgerBackend.Api.Model
{
    public class ValueObjectValidator<T, TProperty> : PropertyValidator<T, TProperty>
    {
        private readonly Func<TProperty, Result> _valueObjectValidatorFunction;
        private readonly bool _allowNull;

        public ValueObjectValidator(Func<TProperty, Result> valueObjectValidatorFunction, bool allowNull)
        {
            _valueObjectValidatorFunction = valueObjectValidatorFunction;
            _allowNull = allowNull;
        }

        public override bool IsValid(ValidationContext<T> context, TProperty value)
        {
            if (_allowNull && value is null)
            {
                return true;
            }

            var result = _valueObjectValidatorFunction(value);

            if (result.IsFailure)
            {
                context.MessageFormatter.AppendArgument("ErrorMessage", result.Error);
                return false;
            }

            return true;
        }

        public override string Name => "ValueObjectValidator";

        protected override string GetDefaultMessageTemplate(string errorCode)
            => "{ErrorMessage}";
    }

    public static class ValueObjectValidatorExtension
    {
        public static IRuleBuilderOptions<T, TProperty> ValueObjectMustValidate<T, TProperty>(
            this IRuleBuilder<T, TProperty> ruleBuilder,
            Func<TProperty, Result> valueObjectValidatorFunction)
        {
            return ruleBuilder.SetValidator(new ValueObjectValidator<T, TProperty>(valueObjectValidatorFunction, false));
        }

        public static IRuleBuilderOptions<T, TProperty> ValueObjectMustValidateIfSet<T, TProperty>(
            this IRuleBuilder<T, TProperty> ruleBuilder,
            Func<TProperty, Result> valueObjectValidatorFunction)
        {
            return ruleBuilder.SetValidator(new ValueObjectValidator<T, TProperty>(valueObjectValidatorFunction, true));
        }
    }
}
