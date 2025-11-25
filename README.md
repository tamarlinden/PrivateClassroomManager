  # PrivateClassroomManager API

## 1) תיאור הפרויקט
המערכת מיועדת לניהול תהליכי הלמידה במסגרת שיעורים פרטניים.  
ה‑API מאפשר לנהל את כלל הישויות במערכת: תלמידים, מורים ושיעורים.  
באמצעותו ניתן להוסיף, לעדכן, למחוק ולשלוף מידע, וכן לבצע פעולות נוספות כמו עדכון זמינות מורה או שינוי סטטוס של שיעור.

---

## 2) ישויות

### א) Student — תלמיד
מייצג תלמיד הלומד במערכת.  
נתונים לדוגמה: שם, גיל, תחום לימוד, רמת קושי, מורה משויך.

### ב) Teacher — מורה
מייצג מורה שמעביר שיעורים פרטניים.  
נתונים לדוגמה: שם, תחומי התמחות, שעות פעילות, סטטוס עבודה.

### ג) Lesson — שיעור
מייצג שיעור שנקבע בין תלמיד למורה.  
נתונים לדוגמה: תאריך, שעה, נושא, סטטוס (נקבע/הושלם/בוטל).

---

## 3) מיפוי Routes לפי REST

### 🟦 Student Routes

| פעולה | HTTP | Route |
|-------|------|-------|
| שליפת רשימת תלמידים | GET | https://school.com/students |
| שליפת תלמיד לפי מזהה | GET | https://school.com/students/{id} |
| הוספת תלמיד | POST | https://school.com/students |
| עדכון תלמיד | PUT | https://school.com/students/{id} |
| מחיקת תלמיד | DELETE | https://school.com/students/{id} |
| **פעולה נוספת:** עדכון רמת קושי | PUT | https://school.com/students/{id}/level |

### 🟩 Teacher Routes

| פעולה | HTTP | Route |
|-------|------|-------|
| שליפת רשימת מורים | GET | https://school.com/teachers |
| שליפת מורה לפי מזהה | GET | https://school.com/teachers/{id} |
| הוספת מורה | POST | https://school.com/teachers |
| עדכון מורה | PUT | https://school.com/teachers/{id} |
| מחיקת מורה | DELETE | https://school.com/teachers/{id} |
| **פעולה נוספת:** עדכון זמינות מורה | PUT | https://school.com/teachers/{id}/availability |

### 🟥 Lesson Routes

| פעולה | HTTP | Route |
|-------|------|-------|
| שליפת רשימת שיעורים | GET | https://school.com/lessons |
| שליפת שיעור לפי מזהה | GET | https://school.com/lessons/{id} |
| הוספת שיעור | POST | https://school.com/lessons |
| עדכון שיעור | PUT | https://school.com/lessons/{id} |
| מחיקת שיעור | DELETE | https://school.com/lessons/{id} |
| **פעולה נוספת:** שינוי סטטוס שיעור | PUT | https://school.com/lessons/{id}/status |
