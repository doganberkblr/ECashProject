
using System;
using System.ComponentModel.DataAnnotations;

namespace DTOLayer.DTOS.AppUserDTOS
{
	public class AppUserRegisterDTO
	{
		//[Required(ErrorMessage="Ad Alanı Zorunludur")]
		//[Display(Name="İsim: ")]
		//[MaxLength(50,ErrorMessage ="En Fazla 50 Karakter Girilebilir.")]
		public string Name { get; set; }
		public string Surname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
		public string Password { get; set; }
		public string ConfirmPassword { get; set; }

	}
}

