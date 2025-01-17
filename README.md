# **Kargo Ücreti Hesaplama API'si**

Bu proje, **.NET Core API** kullanılarak, müşteri siparişi sırasında girilen desi bilgisine göre otomatik olarak uygun kargo firmasını seçen ve kargo ücretini hesaplayan bir API geliştirilmiştir. Proje, kargo ücreti hesaplamayı sağlar ve siparişle ilgili verileri güncelleyerek ilgili kargo ücretini kaydeder.

---

## **İçerik**
- [Proje Hakkında](#proje-hakkında)
- [Kullanılan Teknolojiler](#kullanılan-teknolojiler)
- [Proje Özellikleri](#proje-özellikleri)

---

## **Proje Hakkında**

Bu API, müşteri siparişi oluşturduğunda girilen desi bilgilerine göre kargo firmasını ve kargo ücretini otomatik olarak hesaplar. Bu işlem, sipariş tablosuna yansıyan kargo ücreti ile tamamlanır.

### **Ana Özellikler:**
- Desi bilgisine göre kargo firmasının otomatik seçimi.
- Kargo ücreti hesaplaması, kargo firma tarifeleri üzerinden yapılır.
- Sipariş tablosuna kargo ücreti eklenir.
- API endpoint'leri, Swagger UI üzerinden test edilebilir.

---

## **Kullanılan Teknolojiler**

- **.NET Core API**: API için kullanılan çapraz platform framework.
- **MSSQL**: Veritabanı olarak Microsoft SQL Server.
- **Swagger UI**: API dokümantasyonu ve test için kullanılır.
- **Entity Framework (Code First Approach)**: Veritabanı işlemleri için ORM.
- **Repository Design Pattern**: Veri erişim katmanının ayrılması ve test edilebilirliğin arttırılması için kullanılır.
- **N-Tier Mimari**: Katmanlı mimari kullanılarak uygulama işlevsellikleri ayrılır.
- **CQRS Design Pattern** Okuma ve yazma işlemleri arasındaki ayrımı sağlayarak, sistemin daha kolay yönetilmesini ve genişletilmesini sağlar.

---

## **Proje Özellikleri**

- **Kargo Ücreti Hesaplama**: Sipariş oluşturulurken, desi bilgisine göre kargo ücreti hesaplanır.
- **Sipariş Yönetimi**: Hesaplanan kargo ücreti siparişle birlikte veritabanına kaydedilir.
- **Veritabanı Entegrasyonu**: Entity Framework ile Code First yaklaşımı kullanarak veritabanı işlemleri yapılır.
- **Swagger UI**: API'nin test edilmesini sağlayan etkileşimli bir arayüz sunar.


