namespace Business.Constants
{
    public static class Messages
    {
        public const string CarAdded = "Araba ekleme işlemi başarılı!";

        #region Car Update error messages

        public const string CarUpdateError = "Araba güncellerken hata oluştu!";
        public const string CarShouldHaveMinTwoCharacters = "Araba markası en az 2 karakter olmalı!";
        public const string CarShouldHaveMaxHundredCharacters = "Araba markası en çok 100 karakter olmalı";
        public const string CarGotBack = "Araba başarıyla teslim edildi!";
        public const string CarNotGotBack = "Geçersiz bir teselimat işlemi yapılmaya çalışıldı!";

        #endregion Car Update error messages

        #region Car Delete error messages

        public const string CarShouldHaveMin2Character = "Araba ismi minimum 2 karakter olmalı";
        public const string CarShouldHaveMin0DailyPrice = "Günlük ücreti sıfırdan büyük olmalı";

        #endregion Car Delete messages

        #region Car Image messages

        public static string CarImagesAdded = "Aracınız için resimler eklendi!";
        public static string CarImagesNotAdded = "Aracınız için 5 resimden fazla yükleme yapamazsınız!";
        public static string CarImageDeleted = "Araba resmi başarıyla silindi!";
        public static string CarImageUpdated = "Araba resmi güncellendi!";

        #endregion
    }
}