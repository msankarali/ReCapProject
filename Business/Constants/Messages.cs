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

        public static string FileExtensionMustBeAnImage = "Resim jpg, jpeg veya png uzantısında olmalı!";

        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";

        public static string AuthorizationDenied = "Yetkiniz yok";

        #endregion
    }
}