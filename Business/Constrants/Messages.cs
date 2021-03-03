using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constrants
{
    public static class Messages
    {
        public static string BrandAdded = "Marka Eklendi";
        public static string BrandNameInvalid = "Marka adı geçersiz";
        public static string BrandDeleted = "Marka silindi";
        public static string BrandUpdated = "Marka güncellendi";

        public static string MaintenanceTime = "Sistem bakım saati";

        public static string CarAdded = "Araba Eklendi";
        public static string CarDailyPriceInvalid = " Günlük fiyat değeri 0'dan büyük olmalıdır";
        public static string CarNameInvalid = "Araba adı 2 karakterden fazla olmalıdır";
        public static string CarDeleted = "Araba silindi";
        public static string CarUpdated = "Araba güncellendi";

        public static string ColorAdded = "Renk Eklendi";
        public static string ColorNameInvalid = "Renk adı 2 den büyük olmalıdır.";
        public static string ColorDeleted = "Renk silindi";
        public static string ColorUpdated = "Renk güncellendi";

        public static string CustomerAdded = "Müşteri Eklendi";
        public static string CustomerNameInvalid = "Müşteri adı 2 den büyük olmalıdır.";
        public static string CustomerDeleted = "Müşteri silindi";
        public static string CustomerUpdated = "Müşteri güncellendi";

        public static string RentalAdded = "Kiralama Eklendi";
        public static string RentalDeleted = "Kiralama silindi";
        public static string RentalUpdated = "Kiralama güncellendi";

        public static string UserAdded = "Kullanıcı Eklendi";
        public static string UserNameInvalid = "Kullanıcı adı 2 den büyük olmalıdır.";
        public static string UserDeleted = "Kullanıcı silindi";
        public static string UserUpdated = "Kullanıcı güncellendi";

        public static string CarImageAdded = "Resim Eklendi";
        public static string CarImageDeleted = "Resim Silindi";
        public static string CarImageUpdated = "Resim Güncellendi";
        public static string CarImageOverLimit = "Maximum resim limiti aşıldı";
    }
}
