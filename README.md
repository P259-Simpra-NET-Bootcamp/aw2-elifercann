[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-24ddc0f5d75046c5622901739e7c5dd533143b0c8e959d652212380cedb1ea36.svg)](https://classroom.github.com/a/iGZu94G3)
# aw2

Asagida verilen modeli kullanarak GetAll, GetById , Put , Post , Delete methodlarini icen bir controller implement ediniz. 

EF ile generic repository ve UnitOfWork kullanabilirsiniz.

Put  ve Post apilerin de model validation hazirlayiniz.  Fluent validation kullaniniz. 

Extra olarak 2 tane alana gore (Query parameter) filtreleme yapan Filter apisi ekleyiniz (GET) ve WHERE sarti ile database den filtreleme yapiniz. 

Generic Repository uzerinde Where sartini implement ediniz. 

SOLID e uymaya ozen gosteriniz . 

Proje icerisinde sadece odev ile ilgili kisimlara yer veriniz. Kullanilmayan controller ve methodlari gondermeyiniz. Yorum satiri gondermeyininiz.

Model icin initial migration dosyasini ekleyiniz. 

Readme file uzerinde nasil calisacagina dair gerekli aciklamalara yer veriniz. 

Email alanini unique olmalidir. 

```
  public class Staff  
    { 
        public int Id { get; set; } 
        public string CreatedBy { get; set; } 
        public DateTime CreatedAt { get; set; } 
        public string FirstName { get; set; } 
        public string LastName { get; set; } 
        public string Email { get; set; } 
        public string Phone { get; set; } 
        public DateTime DateOfBirth { get; set; } 
        public string AddressLine1 { get; set; } 
        public string City { get; set; } 
        public string Country { get; set; } 
        public string Province { get; set; } 
        [NotMapped] 
        public string FullName 
        { 
            get { return FirstName + " " + LastName; } 
        } 
    }
```
Ödev Açıklaması

-Tek bir sınıf olan Staff sınıfı için base sınıfı oluşturulmadı projede sınıflar arttıkça basemodel implement edilecek, entities katmanı içinde model klasörünün altında sınıf tanımı ve veri tabanında tablo oluşturulurken propertylerin hangi özelliklerde olacağı kodlandı.


-Projede repository yapısı kullanıldı.Repositories katmanında abstract klasöründe implement edilecek metotlar kodlandı.Context klasöründe veri tabanı sınıfı oluşturulup config dosyaları içerisinde tanımlandı.EfCore klasöründe repositorymanager ve repositorybase sınıflarında ortak işlemler kodlandı(crud fonksiyonları).StaffRepository sınıfında staff sınıfı için gerekli işlemler kodlandı.Bu katmana migration işlemi yapıldı.İnitial migration dosyası mevcuttur.


-Services katmanında abstract,concrete ve validation klasörleri bulunuyor.Repository katmanından direkt nesneye erişim yapılmasın servis üzerinden işlemler gerçekleştirilmesi için bu servis katmanı oluşturuldu.Doğrulama işlemi validation klasörü içersinde tanımlandı.


-SimApi katmanında api tasarlandı.ContextFactory klasöründe context sınıfının konfigürasyonu yapıldı.Farklı bir kullanım olduğundan tercih edildi.Controllers klasöründe Get,put,post,delete işlemleri tanımladı.Extensions klasöründe servis konfigürasyonları yazıldı sonrasında hepsi Startup.cs klasöründe implement edildi.


-Mevcut sisteminizde projenin çalışabilmesi için appsettings.json dosyasında veri tabanı bağlantınızı kendi server uzantınız olarak değiştirmelisiniz sonrasında veri tabanı işlemlerinin yansıtılması için migration klasörünü silip add-migraiton komutunu çalıştırmalısınız.Ardından veri tabanına yansıması için de update-database komutunu çalıştırmalısınız.Migrations klasörü oluşturulduktan sonra çalıştırıp metotları test edebilirsiniz.
