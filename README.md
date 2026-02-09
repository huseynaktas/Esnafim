#EN

# ESNAFIM – Business Appointment & Management System

ESNAFIM is a backend-focused appointment and business management system designed for local businesses.  
The system enables business owners to manage their businesses, employees, and customer appointments through a role-based and scalable architecture.

The project focuses on clean architecture principles, modular design, and real-world business scenarios.

---

## Key Features

- Multi-role system (Business Owner, Business Employee, Customer)
- Appointment management with time-slot control
- Business and employee-based appointment flows
- Role-based authorization and access control
- Scalable and modular backend architecture

---

## Architecture Overview

The project is developed using a **layered and modular architecture** to ensure maintainability and scalability.

- **API Layer** – Handles HTTP requests and responses
- **Application Layer** – Business logic, use cases, and request handling
- **Domain Layer** – Core entities and business rules
- **Infrastructure Layer** – Database access and external integrations

The architecture allows independent development and testing of each layer.

---

## Technologies & Tools

- ASP.NET Core Web API
- Entity Framework Core
- MSSQL
- JWT Authentication
- Role-Based Authorization
- Repository Pattern
- MediatR

---

## Appointment Workflow

1. Business owners define available businesses and employees
2. Employees manage their availability and working hours
3. Customers select available time slots
4. Appointments are created, approved, or rejected based on business rules
5. Past, pending, and approved appointments are tracked separately

---

## Design Goals

- Clean and readable codebase
- Separation of concerns
- Real-world business logic modeling
- API-first approach
- Easy integration with different client applications

---

## Status

The project is actively developed and continuously improved with new features and refinements.


#TR

# ESNAFIM – İşletme Randevu ve Yönetim Sistemi

ESNAFIM, yerel işletmeler için geliştirilen, randevu ve işletme yönetimini merkezine alan backend odaklı bir sistemdir.  
Proje; işletme sahiplerinin, çalışanların ve müşterilerin ayrı roller üzerinden etkileşime girebildiği ölçeklenebilir ve modüler bir mimari üzerine inşa edilmiştir.

Gerçek hayat senaryoları dikkate alınarak tasarlanan sistem, temiz mimari prensipleri ve sürdürülebilir yazılım yaklaşımı esas alınarak geliştirilmiştir.

---

## Temel Özellikler

- Çok rollü yapı (İşletme Sahibi, Çalışan, Müşteri)
- Zaman dilimi kontrollü randevu yönetimi
- İşletme ve çalışan bazlı randevu akışları
- Rol bazlı yetkilendirme ve erişim kontrolü
- Modüler ve ölçeklenebilir backend mimarisi

---

## Mimari Yapı

Proje, **katmanlı ve modüler mimari** yaklaşımıyla geliştirilmiştir.  
Bu yapı, kodun sürdürülebilirliğini ve test edilebilirliğini artırmayı hedefler.

- **API Katmanı** – HTTP istek ve cevaplarının yönetimi
- **Application Katmanı** – İş kuralları ve kullanım senaryoları
- **Domain Katmanı** – Temel varlıklar ve iş kuralları
- **Infrastructure Katmanı** – Veritabanı işlemleri ve dış bağımlılıklar

Her katman, sorumluluk ayrımı prensibine uygun olarak tasarlanmıştır.

---

## Kullanılan Teknolojiler

- ASP.NET Core Web API
- Entity Framework Core
- MSSQL
- JWT Kimlik Doğrulama
- Rol Bazlı Yetkilendirme
- Repository Pattern
- MediatR

---

## Randevu Akışı

1. İşletme sahipleri işletme ve çalışan tanımlarını oluşturur
2. Çalışanlar uygunluk ve çalışma saatlerini belirler
3. Müşteriler uygun zaman dilimlerini görüntüler
4. Randevular oluşturulur, onaylanır veya reddedilir
5. Geçmiş, bekleyen ve onaylanmış randevular ayrı ayrı yönetilir

---

## Tasarım Hedefleri

- Temiz ve okunabilir kod yapısı
- Katmanlar arası sorumluluk ayrımı
- Gerçek dünya iş kurallarının modellenmesi
- API odaklı geliştirme yaklaşımı
- Farklı istemcilerle kolay entegrasyon

---

## Durum

Proje aktif olarak geliştirilmeye devam etmekte ve yeni özelliklerle sürekli iyileştirilmektedir.
