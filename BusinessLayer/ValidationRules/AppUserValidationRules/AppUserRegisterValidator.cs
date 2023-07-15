using System;
using DTOLayer.DTOS.AppUserDTOS;
using FluentValidation;


namespace BusinessLayer.ValidationRules.AppUserValidationRules
{
	public class AppUserRegisterValidator:AbstractValidator<AppUserRegisterDTO>
	{
		public AppUserRegisterValidator()
		{
			RuleFor(x => x.Name).NotEmpty().WithMessage("Ad Alanı Boş Geçilemez.");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad Alanı Boş Geçilemez.");
            RuleFor(x => x.Username).NotEmpty().WithMessage("Kullanıcı Adı Boş Geçilemez.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email Alanı Boş Geçilemez.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre Alanı Boş Geçilemez.");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Şifre Tekrar Alanı Boş Geçilemez.");
            RuleFor(x => x.Name).MaximumLength(30).WithMessage("Ad Alanına En Fazla 30 Karakter Girilebilir.");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("Ad Alanına En Az 2 Karakter Girilebilir.");
            RuleFor(x => x.ConfirmPassword).Equal(y => y.Password).WithMessage("Girilen Parolalar Eşleşmiyor.");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Lütfen Geçerli Bir Mail Adresi Giriniz.");

        }
	}
}

