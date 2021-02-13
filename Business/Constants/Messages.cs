namespace Business.Constants
{
    public static class Messages
    {
        public const string CarAdded = "Araba ekleme işlemi başarılı!";

        #region Car Update error messages

        public const string CarUpdateError = "Araba güncellerken hata oluştu!";
        public const string CarShouldHaveMinTwoCharacters = "Araba markası en az 2 karakter olmalı!";
        public const string CarShouldHaveMaxHundredCharacters = "Araba markası en çok 100 karakter olmalı";

        #endregion Car Update error messages

        #region Car Delete error messages

        public const string CarShouldHaveMin2Character = "Araba ismi minimum 2 karakter olmalı";
        public const string CarShouldHaveMin0DailyPrice = "Günlük ücreti sıfırdan büyük olmalı";

        #endregion Car Delete error messages
    }
}