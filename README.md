# AR Hand Tracking Puzzle Game

Unity ve MediaPipe kullanılarak geliştirilmiş, web kamerası tabanlı bir Artırılmış Gerçeklik (AR) eşleştirme oyunudur. Bu proje, herhangi bir VR/AR donanımı gerektirmeden, sadece görüntü işleme teknolojisi ile 3 boyutlu objelerin 3 eksende (X, Y, Z) kontrolünü sağlar.

## 🎯 Proje Hakkında
Bu proje, ünlü dünya yapılarının (Eyfel Kulesi, Pisa Kulesi vb.) 3D modellerini el hareketleriyle tutup, doğru ülke bayraklarıyla eşleştirmeyi amaçlar. Proje, Unity oyun motoru üzerinde geliştirilmiş olup, el takibi için Google MediaPipe kütüphanesinden yararlanılmıştır.

## 🚀 Temel Özellikler

* **El Takibi (Hand Tracking):** MediaPipe ile elin 21 eklem noktası (landmarks) gerçek zamanlı takip edilir.
* **Yapay Derinlik Algısı (Z Ekseni):** Tek kamera ile derinlik verisi alınamadığı için, elin ekrandaki boyut değişimini baz alan (perspektif temelli) özel bir derinlik algoritması geliştirilmiştir.
* **Tut & Sürükle (Pinch Interaction):** Başparmak ve işaret parmağı birbirine yaklaştığında obje "tutulur", uzaklaştığında "bırakılır".
* **Koordinat Eşleme (Mapping):** Ekran koordinatları (2D) ile Unity dünya koordinatları (3D) arasında manuel kalibrasyon sağlayan bir eşleme sistemi kullanılmıştır.
* **Geri Bildirim Sistemi:**
  * **Görsel:** Objelerin üzerine gelindiğinde büyümesi (Hover Effect).
  * **İşitsel:** Doğru eşleşmede başarı sesi çalınması.
  * **Mekanik:** Doğru hedefe getirilen objenin kilitlenmesi (Snapping).

## 🛠 Kullanılan Teknolojiler ve Scriptler

* **Unity 2022.3**
* **MediaPipe Unity Plugin**
* **C#**

### Önemli Scriptler:
1.  **`HandTipFollower.cs`:** Elin konumunu takip eder, derinlik (Z) ve koordinat (X,Y) hesaplamalarını yapar.
2.  **`InteractionManager.cs`:** Objelerin tutulması, taşınması ve hover efektlerini yönetir.
3.  **`PuzzlePiece.cs`:** Objelerin doğru hedefle (ID eşleşmesi) eşleşip eşleşmediğini kontrol eder.
4.  **`GameManager.cs`:** Skor takibi, ses yönetimi ve UI güncellemelerini yapar.

## 🎮 Nasıl Oynanır?

1.  Uygulamayı başlatın ve web kamerasına izin verin.
2.  Elinizi kameraya gösterin.
3.  İşaret parmağınızı bir yapının (örneğin Eyfel Kulesi) üzerine getirin.
4.  Başparmağınızla işaret parmağınızı birleştirerek (çimdik hareketi) objeyi tutun.
5.  Objeyi ilgili bayrağın üzerine sürükleyin ve parmaklarınızı açarak bırakın.

## 📦 Kurulum

Projeyi kendi bilgisayarınızda çalıştırmak için:

1.  Bu repoyu klonlayın:
    ```bash
    git clone [https://github.com/HasanSarikose/Mixed-Reality-Final-Project.git]
    ```
2.  Unity Hub üzerinden projeyi açın.
3.  `Assets/MediaPipeUnity/Samples/Scenes/Hand Landmark Detection` klasöründeki ana sahneyi başlatın.

---
**Geliştirici:** Hasan Sarıköse
