using BankProject.DtoLayer.Dtos.AppUserDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject.BusinessLayer.ValidationRule.AppUserValidationRules
{
    public class AppUserRegisterValidator:AbstractValidator<AppUserRegisterDto>
    {
        public AppUserRegisterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim alanı boş geçilemez.");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyadı alanı boş geçilemez.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email alani bos geçilemez.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre alani bos geçilemez.");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Şifre tekrar alani bos geçilemez.");


            RuleFor(x => x.Name).MaximumLength(25).WithMessage("İsim en fazla 25 karakter olabilir.");
            RuleFor(x => x.Surname).MaximumLength(25).WithMessage("Soyadı en fazla 25 karakter olabilir.");
            RuleFor(x => x.Email).MaximumLength(50).WithMessage("Email en fazla 50 karakter olabilir.");


            RuleFor(x => x.Name).MinimumLength(2).WithMessage("İsim en az 2 karakter olabilir.");
            RuleFor(x => x.Surname).MinimumLength(2).WithMessage("Soyadı en az 2 karakter olabilir.");
            RuleFor(x => x.Email).MinimumLength(2).WithMessage("Email en az 2 karakter olabilir.");
            RuleFor(x => x.Password).MinimumLength(2).WithMessage("Şifre en az 2 karakter olabilir.");
            RuleFor(x => x.ConfirmPassword).MinimumLength(2).WithMessage("Şifre en az 2 karakter olabilir.");

            RuleFor(x => x.ConfirmPassword).Equal(y => y.Password).WithMessage("Parolalariniz eşleşmiyor.");
            
            RuleFor(x => x.Email).EmailAddress().WithMessage("Geçerli bir mail adresi giriniz.");

        }
    }
}
