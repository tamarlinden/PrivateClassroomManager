Project: Learning Management API
1) תיאור הפרויקט

המערכת מיועדת לניהול תהליכי הלמידה במסגרת שיעורים פרטניים.
ה‑API מאפשר לנהל את כלל הישויות במערכת: תלמידים, מורים ושיעורים.
באמצעותו ניתן להוסיף, לעדכן, למחוק ולשלוף מידע, וכן לבצע פעולות נוספות כמו עדכון זמינות מורה או שינוי סטטוס של שיעור.

2) ישויות
Entity	תיאור	נתוני דוגמה
Student (תלמיד)	מייצג תלמיד הלומד במערכת	שם, גיל, תחום לימוד, רמת קושי, מורה משויך
Teacher (מורה)	מייצג מורה שמעביר שיעורים פרטניים	שם, תחומי התמחות, שעות פעילות, סטטוס עבודה
Lesson (שיעור)	מייצג שיעור שנקבע בין תלמיד למורה	תאריך, שעה, נושא, סטטוס (נקבע/הושלם/בוטל)
3) מיפוי Routes לפי REST
🟦 Student Routes
פעולה	HTTP	Route
שליפת רשימת תלמידים	GET	/students
שליפת תלמיד לפי מזהה	GET	/students/{id}
הוספת תלמיד	POST	/students
עדכון תלמיד	PUT	/students/{id}
מחיקת תלמיד	DELETE	/students/{id}
עדכון רמת קושי	PUT	/students/{id}/level
🟩 Teacher Routes
פעולה	HTTP	Route
שליפת רשימת מורים	GET	/teachers
שליפת מורה לפי מזהה	GET	/teachers/{id}
הוספת מורה	POST	/teachers
עדכון מורה	PUT	/teachers/{id}
מחיקת מורה	DELETE	/teachers/{id}
עדכון זמינות מורה	PUT	/teachers/{id}/availability
🟥 Lesson Routes
פעולה	HTTP	Route
שליפת רשימת שיעורים	GET	/lessons
שליפת שיעור לפי מזהה	GET	/lessons/{id}
הוספת שיעור	POST	/lessons
עדכון שיעור	PUT	/lessons/{id}
מחיקת שיעור	DELETE	/lessons/{id}
שינוי סטטוס שיעור	PUT	/lessons/{id}/status
